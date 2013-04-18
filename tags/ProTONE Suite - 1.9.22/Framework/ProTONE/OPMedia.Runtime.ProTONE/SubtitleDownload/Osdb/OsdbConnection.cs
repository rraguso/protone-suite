using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Core.Logging;
using OPMedia.Core.ApplicationSettings;
using System.Net;
using System.Collections;
using OPMedia.Runtime.ProTONE.SubtitleDownload.Base;
using CookComputing.XmlRpc;

namespace OPMedia.Runtime.ProTONE.SubtitleDownload.Osdb
{
    internal class OsdbConnection : IDisposable
    {
        private IOsdbProtocol _proxy = null;
        public readonly object SyncRoot = new object();

        public OsdbDownloadSubtitlesResponse DownloadSubtitles(string token, int[] subtitleFileIDs)
        {
            lock (SyncRoot)
            {
                return _proxy.DownloadSubtitles(token, subtitleFileIDs);
            }
        }

        public OsdbSearchMoviesOnIMDBResponse SearchMoviesOnIMDB(string token, string query)
        {
            lock (SyncRoot)
            {
                return _proxy.SearchMoviesOnIMDB(token, query);
            }
        }
        
        public OsdbSearchSubtitleResponse SearchSubtitles(string token, VideoInfo[] videoInfoList)
        {
            lock (SyncRoot)
            {
                return _proxy.SearchSubtitles(token, videoInfoList);
            }
        }

        public OsdbServerInfoResponse GetServerInfo()
        {
            lock (SyncRoot)
            {
                return _proxy.ServerInfo();
            }
        }

        public XmlRpcStruct GetServerInfo2()
        {
            lock (SyncRoot)
            {
                return _proxy.ServerInfo2();
            }
        }

        public OsdbLoginResponse Login(string username, string password, string language, string useragent)
        {
            lock (SyncRoot)
            {
                return _proxy.Login(username, password, language, useragent);
            }
        }

        public OsdbStatusResponse Logout(string token)
        {
            lock (SyncRoot)
            {
                return _proxy.LogOut(token);
            }
        }

        public OsdbStatusResponse NoOperation(string token)
        {
            lock (SyncRoot)
            {
                return _proxy.NoOperation(token);
            }
        }

        public OsdbConnection(string osdbServerUrl, ProxySettings ps)
        {
            _proxy = XmlRpcProxyGen.Create<IOsdbProtocol>();
            _proxy.Url = osdbServerUrl;

            IWebProxy wp = null;

            if (ps == null || ps.ProxyType == ProxyType.NoProxy)
            {
                wp = new WebProxy();
            }
            else if (ps.ProxyType != ProxyType.InternetExplorerProxy)
            {
                wp = new WebProxy(ps.ProxyAddress, ps.ProxyPort);
                wp.Credentials = new NetworkCredential(ps.ProxyUser, ps.ProxyPassword);
                (wp as WebProxy).BypassProxyOnLocal = true;
            }

            _proxy.Proxy = wp;
        }

        #region IDisposable Members

        public void Dispose()
        {
            _proxy = null;
        }

        #endregion

    }
}
