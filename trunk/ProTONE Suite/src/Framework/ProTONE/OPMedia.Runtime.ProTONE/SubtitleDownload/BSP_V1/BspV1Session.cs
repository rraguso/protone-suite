using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Runtime.ProTONE.SubtitleDownload.Base;
using OPMedia.Runtime.ProTONE.BSP_V1;
using System.Globalization;
using OPMedia.Core.Logging;
using System.Net;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Core;
using OPMedia.Runtime.ProTONE.NuSoap;
using System.IO;
using OPMedia.Core.NetworkAccess;
using System.IO.Compression;
using System.ComponentModel;

namespace OPMedia.Runtime.ProTONE.SubtitleDownload.BSP_V1
{
    public class BspV1Session : SubtitleServerSession
    {
        BSPSubtitlesService _wsdl = null;

        #region Construction / Cleanup
        public BspV1Session(string serverUrl, CultureInfo culture)
            : this(serverUrl, string.Empty, string.Empty, culture)
        {
        }

        public BspV1Session(string serverUrl, string username, string password, CultureInfo culture)
            : base(serverUrl, username, password, culture)
        {
            Logger.LogHeavyTrace("BspV1Session: object created");
        }
        #endregion

        protected override void DoInitializeSession()
        {
            _wsdl = new BSPSubtitlesService(_serverUrl);
            _wsdl.Proxy = AppSettings.Instance.GetWebProxy();
            _wsdl.UserAgent = string.Format("{0} v{1}", Constants.PlayerName, SuiteVersion.Version);
        }

        protected override bool IsAuthenticationRequired()
        {
            return true; // BSP subtitles V1 requires authentication
        }

        protected override void DoTestConnection()
        {
            string hello = _wsdl.helloWorld();
        }

        protected override void DoAuthenticate()
        {
            SubtitlesResult res = _wsdl.logIn(_username, _password, _wsdl.UserAgent);
            if (res.result != "200" )
                // not OK
                throw new SubtitleDownloadException("Login to BSP_V1 server has failed", res.status);

            _sessionToken = res.data;
        }

        protected override double GetKeepAliveInterval()
        {
            return 0; // No keepalive mechanism
        }

        protected override void DoKeepAliveSession()
        {
            // No keepalive mechanism
        }

        protected override void DoCleanup()
        {
            _wsdl.Abort();
            _wsdl.Dispose();
            _wsdl = null;
        }

        protected override List<SubtitleInfo> DoGetSubtitles(VideoInfo vi)
        {
            List<SubtitleInfo> retVal = new List<SubtitleInfo>();

            SearchResult res = _wsdl.searchSubtitles(_sessionToken, vi.moviehash, (long)vi.moviebytesize, vi.sublanguageid, vi.imdbid);
            if (res.data != null && res.data.Length > 0)
            {
                foreach (SubtitleData sd in res.data)
                {
                    SubtitleInfo si = new SubtitleInfo();

                    si.IDSubtitleFile = sd.subID.ToString();
                    si.SubFileName = sd.subName;
                    si.MovieName = sd.movieName;
                    si.SubHash = sd.subHash;

                    si.LanguageName = OPMedia.Core.Language.ThreeLetterISOLanguageNameToEnglishName(sd.subLang);

                    si.MovieHash = vi.moviehash;
                    si.SubDownloadLink = sd.subDownloadLink;
                    si.SubFormat = sd.subFormat;

                    retVal.Add(si);
                }
            }

            return retVal;
        }

        protected override Dictionary<string, object> DoGetServerStatistics()
        {
            return new Dictionary<string, object>();
        }

        protected override string DoDownloadSubtitle(string fileName, SubtitleInfo subtitle)
        {
            string destPath = Path.ChangeExtension(fileName, subtitle.SubFormat);
            string downloadPath = Path.ChangeExtension(fileName, "gz");

            bool downloaded = false;
            using (WebFileRetriever wfr = new WebFileRetriever(AppSettings.Instance.ProxySettings,
                subtitle.SubDownloadLink, downloadPath, false))
            {
                downloaded = true;
            }

            if (downloaded)
            {
                using (FileStream compressedSubtitle = new FileStream(downloadPath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                {
                    using (GZipStream str = new GZipStream(compressedSubtitle, CompressionMode.Decompress, false))
                    {
                        using (FileStream outputSubtitle = new FileStream(destPath, FileMode.Create, FileAccess.Write, FileShare.Read))
                        {
                            byte[] buffer = new byte[65536];
                            int read = 0;
                            do
                            {
                                read = str.Read(buffer, 0, buffer.Length);
                                if (read > 0)
                                {
                                    outputSubtitle.Write(buffer, 0, read);
                                }
                            }
                            while (read > 0);
                        }
                    }
                }

                File.Delete(downloadPath);

                return destPath;
            }

            return string.Empty;
        }
    }

}
