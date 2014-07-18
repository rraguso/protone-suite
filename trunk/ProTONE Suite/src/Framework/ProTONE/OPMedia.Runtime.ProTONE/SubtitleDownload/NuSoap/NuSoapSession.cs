using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.ProTONE.SubtitleDownload.Base;
using OPMedia.Runtime.ProTONE.NuSoap;
using System.Net;
using OPMedia.Core.Configuration;
using OPMedia.Core;
using OPMedia.Core.Logging;
using System.Globalization;
using System.IO.Compression;
using System.IO;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace OPMedia.Runtime.ProTONE.SubtitleDownload.NuSoap
{
    public class NuSoapSession : SubtitleServerSession
    {
        NuSoapWsdl _wsdl = null;

        #region Construction / Cleanup
        public NuSoapSession(string serverUrl, CultureInfo culture)
            : this(serverUrl, string.Empty, string.Empty, culture)
        {
        }

        public NuSoapSession(string serverUrl, string username, string password, CultureInfo culture)
            : base(serverUrl, username, password, culture)
        {
            Logger.LogHeavyTrace("NuSoapSession: object created");
        }
        #endregion

        protected override void DoInitializeSession()
        {
            _wsdl = new NuSoapWsdl(_serverUrl);
            _wsdl.Proxy = AppConfig.GetWebProxy();
            _wsdl.UserAgent = string.Format("{0} v{1}", Constants.PlayerName, SuiteVersion.Version);
        }

        protected override bool IsAuthenticationRequired()
        {
            return false;
        }

        protected override void DoTestConnection()
        {
            OPMedia.Runtime.ProTONE.NuSoap.Language[] langs = _wsdl.getLanguages();
        }

        protected override void DoAuthenticate()
        {
            // No authentication
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

            SubtitleFile[] subtitles = _wsdl.searchSubtitlesByHash(vi.moviehash, vi.sublanguageid, 0, 100);
            if (subtitles != null && subtitles.Length > 0)
            {
                foreach (SubtitleFile sf in subtitles)
                {
                    SubtitleInfo si = new SubtitleInfo();

                    si.IDSubtitleFile = sf.cod_subtitle_file.ToString();
                    si.SubFileName = sf.file_name;
                    si.SubHash = sf.sub_hash;
                    si.LanguageName = sf.language;
                    si.MovieHash = vi.moviehash;
                    si.SubFormat = PathUtils.GetExtension(sf.file_name);

                    retVal.Add(si);
                }
            }

            return retVal;
        }

        protected override Dictionary<string, object> DoGetServerStatistics()
        {
            return new Dictionary<string, object>();
        }

        protected override string DoDownloadSubtitle(string fileName, SubtitleInfo si)
        {
            OPMedia.Runtime.ProTONE.NuSoap.SubtitleDownload sd = new OPMedia.Runtime.ProTONE.NuSoap.SubtitleDownload();
            int x = 0;
            int.TryParse(si.IDSubtitleFile, out x);

            sd.cod_subtitle_file = x;
            sd.movie_hash = si.MovieHash;

            string destPath = Path.ChangeExtension(fileName, si.SubFormat);

            SubtitleArchive[] archives = _wsdl.downloadSubtitles(new OPMedia.Runtime.ProTONE.NuSoap.SubtitleDownload[] { sd });

            if (archives != null && archives.Length > 0)
            {
                byte[] decodedBytes = Convert.FromBase64String(archives[0].data);

                using (MemoryStream compressedSubtitle = new MemoryStream(decodedBytes))
                {
                    using (InflaterInputStream str = new InflaterInputStream(compressedSubtitle))
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

                return destPath;
            }

            return string.Empty;
        }
    }
}
