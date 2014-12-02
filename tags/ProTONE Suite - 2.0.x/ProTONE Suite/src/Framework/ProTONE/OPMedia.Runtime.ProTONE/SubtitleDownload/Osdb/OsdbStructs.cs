using System;
using System.Collections.Generic;
using System.Text;
using CookComputing.XmlRpc;
using OPMedia.Runtime.ProTONE.SubtitleDownload.Base;

namespace OPMedia.Runtime.ProTONE.SubtitleDownload.Osdb
{
    public struct OsdbLoginResponse
    {
        public string token;
        public string status;
        public double seconds;

        public bool IsOK()
        {
            return StatusParser.IsOK(status);
        }
    }

    public struct OsdbStatusResponse
    {
        public string status;
        public double seconds;

        public bool IsOK()
        {
            return StatusParser.IsOK(status);
        }
    }

    public struct OsdbServerInfoResponse
    {
        public string xmlrpc_version;
        public string xmlrpc_url;
        public string application;
        public string contact;
        public string website_url;
        public int users_online_total;
        public int users_online_program;
        public int users_loggedin;
        public string users_max_alltime;
        public string users_registered;
        public string subs_downloads;
        public string subs_subtitle_files;
        public string movies_total;
        public string movies_aka;
        public string total_subtitles_languages;
        public XmlRpcStruct last_update_strings;
        public double seconds;
    }

    public struct OsdbSearchSubtitleResponse
    {
        public SubtitleInfo[] data;
        public double seconds;
    }
    
    public struct OsdbImdbMovieInformation
    {
        public string id;
        public string title;
    }

    public struct OsdbSearchMoviesOnIMDBResponse
    {
        public string status;
        public OsdbImdbMovieInformation[] data;
        public double seconds;
    }

    public struct SubtitleContents 
    {
        public int idsubtitlefile;
        public string data;
    }

    public struct OsdbDownloadSubtitlesResponse
    {
        public SubtitleContents[] data;
        public double seconds;
    }

}



