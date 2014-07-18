using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using OPMedia.Runtime.ProTONE.SubtitleDownload.Osdb;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Core;
using OPMedia.Core.Logging;
using OPMedia.Runtime.ProTONE.SubtitleDownload.Base;
using CookComputing.XmlRpc;
using System.Collections;
using System.IO;
using OPMedia.Core.NetworkAccess;
using System.IO.Compression;

namespace OPMedia.Runtime.ProTONE.SubtitleDownload.Osdb
{
    public class OsdbSession : SubtitleServerSession
    {
        #region Private members
        private OsdbConnection _client = null;
        private object _syncRoot = new object();
        private OsdbServerInfoResponse _serverInfo;
        #endregion

        #region Methods
        public OsdbSearchMoviesOnIMDBResponse SearchMoviesOnIMDB(string query)
        {
            CheckAuthentication("SearchMoviesOnIMDB");

            if (string.IsNullOrEmpty(query))
            {
                throw new SubtitleDownloadException("Cannot perform SearchSubtitles", "Missing query data");
            }

            return _client.SearchMoviesOnIMDB(_sessionToken, query);
        }


        public OsdbSearchSubtitleResponse SearchSubtitles(VideoInfo[] videoInfoList)
        {
            CheckAuthentication("SearchSubtitles");

            if (videoInfoList == null)
            {
                throw new SubtitleDownloadException("Cannot perform SearchSubtitles", "Missing video info data");
            }

            return _client.SearchSubtitles(_sessionToken, videoInfoList);
        }
        #endregion

        #region Construction / Cleanup
        public OsdbSession(string serverUrl, CultureInfo culture)
            : this(serverUrl, string.Empty, string.Empty, culture)
        {
        }

        public OsdbSession(string serverUrl, string username, string password, CultureInfo culture)
            : base(serverUrl, username, password, culture)
        {
            Logger.LogHeavyTrace("OsdbSession: object created");
        }
        #endregion

        #region Base class overrides

        protected override bool IsAuthenticationRequired()
        {
            return true; // OSDB protocol requires authentication
        }

        protected override void DoInitializeSession()
        {
            Logger.LogHeavyTrace("OsdbSession: creating OSDB server connection ...");
            _client = new OsdbConnection(_serverUrl, AppSettings.Instance.ProxySettings);
        }

        protected override void DoTestConnection()
        {
            Logger.LogHeavyTrace("OsdbSession: checking whether URL {0} is valid ...", _serverUrl);
            _serverInfo = _client.GetServerInfo();
        }

        protected override void DoAuthenticate()
        {
            if (string.IsNullOrEmpty(_username))
            {
                Logger.LogHeavyTrace("OsdbSession: Attempt to anonymously login to OSDB server ...");
                _username = string.Empty;
                _password = string.Empty;
            }
            else
            {
                Logger.LogHeavyTrace("OsdbSession: Attempt to login to OSDB server with username {0} ...", _username);
            }

            string lang = _culture.TwoLetterISOLanguageName;
            string userAgent = string.Format("{0} v{1}", Constants.PlayerUserAgent, SuiteVersion.Version);

            OsdbLoginResponse rsp = _client.Login(_username, _password, lang, userAgent);
            if (!rsp.IsOK())
            {
                // Login failed.
                throw new SubtitleDownloadException("Login to OSDB server has failed", rsp.status);
            }

            // Get the session token
            _sessionToken = rsp.token;

            Logger.LogHeavyTrace("OsdbSession: Succesfully logged in.");

        }

        protected override double GetKeepAliveInterval()
        {
            return AppSettings.Instance.KeepAliveInterval;
        }

        protected override void DoKeepAliveSession()
        {
            OsdbStatusResponse rsp = _client.NoOperation(_sessionToken);
            if (!rsp.IsOK())
            {
                // Logout failed.
                Logger.LogError("OsdbSession: No-Operation failed: {0}", rsp.status);
            }
        }

        protected override void DoCleanup()
        {
            try
            {
                Logger.LogHeavyTrace("OsdbSession: Attempt to logout from OSDB server ...");

                OsdbStatusResponse rsp = _client.Logout(_sessionToken);
                if (!rsp.IsOK())
                {
                    // Logout failed.
                    throw new SubtitleDownloadException("Logout from OSDB server has failed", rsp.status);
                }

                Logger.LogHeavyTrace("OsdbSession: Succesfully logged out from OSDB server.");
            }
            finally
            {
                _client = null;

                Logger.LogHeavyTrace("OsdbSession: Object destroyed.");
            }
        }

        protected override List<SubtitleInfo> DoGetSubtitles(VideoInfo vi)
        {
            OsdbSearchSubtitleResponse rsp = _client.SearchSubtitles(_sessionToken, new VideoInfo[] { vi });

            List<SubtitleInfo> retVal = new List<SubtitleInfo>();
            retVal.AddRange(rsp.data);
            return retVal;
        }

        protected override Dictionary<string, object> DoGetServerStatistics()
        {
            Dictionary<string, object> retVal = new Dictionary<string, object>();

            XmlRpcStruct rsp = _client.GetServerInfo2();
            if (rsp != null)
            {
                IDictionaryEnumerator iter = rsp.GetEnumerator();
                while (iter.MoveNext())
                {
                    if (iter.Key != null)
                    {
                        if (retVal.ContainsKey(iter.Key.ToString()))
                        {
                            retVal[iter.Key.ToString()] = iter.Value;
                        }
                        else
                        {
                            retVal.Add(iter.Key.ToString(), iter.Value);
                        }
                    }
                }
            }

            return retVal;
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

        #endregion
    }

    
}
