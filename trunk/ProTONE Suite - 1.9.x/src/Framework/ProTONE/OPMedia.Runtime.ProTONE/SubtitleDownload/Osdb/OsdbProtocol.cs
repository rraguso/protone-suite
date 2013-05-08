using System;
using System.Collections.Generic;
using System.Text;
using CookComputing.XmlRpc;
using System.Runtime.InteropServices;
using OPMedia.Runtime.ProTONE.SubtitleDownload.Base;

namespace OPMedia.Runtime.ProTONE.SubtitleDownload.Osdb
{
    public class StatusParser
    {
        public static bool IsOK(string status)
        {
            if (status != null)
            {
                string[] rspData = status.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (rspData.Length >= 2)
                {
                    string code = rspData[0];
                    switch (code)
                    {
                        case "200" /* 200 OK */:
                        case "206" /* 206 Partial content; message */:
                            return true;
                    }
                }
            }

            return false;
        }
    }

    public interface IOsdbProtocol : IXmlRpcProxy
    {
        #region Session handling
        [XmlRpcMethod("LogIn")]
        OsdbLoginResponse Login(string username, string password, string language, string useragent);

        [XmlRpcMethod("LogOut")]
        OsdbStatusResponse LogOut(string token);

        [XmlRpcMethod("NoOperation")]
        OsdbStatusResponse NoOperation(string token);
        #endregion

        #region Search and download

        [XmlRpcMethod("SearchSubtitles")]
        XmlRpcStruct DownloadSubtitles2(string token, int[] subtitleFileIDs);

        [XmlRpcMethod("SearchSubtitles")]
        OsdbDownloadSubtitlesResponse DownloadSubtitles(string token, int[] subtitleFileIDs);
        
        [XmlRpcMethod("SearchSubtitles")]
        OsdbSearchSubtitleResponse SearchSubtitles(string token, VideoInfo[] videoInfoList);

        [XmlRpcMethod("SearchMoviesOnIMDB")]
        OsdbSearchMoviesOnIMDBResponse SearchMoviesOnIMDB(string token, string query);
        #endregion

        #region Reporting and rating
        [XmlRpcMethod("ServerInfo")]
        OsdbServerInfoResponse ServerInfo();

        [XmlRpcMethod("ServerInfo")]
        XmlRpcStruct ServerInfo2();
        #endregion
    }
}
