using System;
using System.Collections.Generic;
using System.Text;

namespace OPMedia.Runtime.ProTONE.SubtitleDownload.Base
{
    public struct VideoInfo
    {
        public string sublanguageid;
        public string moviehash;
        public double moviebytesize;
        public string imdbid;
    }

    public struct SubtitleInfo
    {
        public string IDSubMovieFile;
        public string MovieHash;
        public string MovieByteSize;
        public string MovieTimeMS;
        public string IDSubtitleFile;
        public string SubFileName;
        public string SubActualCD;
        public string SubSize;
        public string SubHash;
        public string IDSubtitle;
        public string UserID;
        public string SubLanguageID;
        public string SubFormat;
        public string SubSumCD;
        public string SubAuthorComment;
        public string SubAddDate;
        public string SubBad;
        public string SubRating;
        public string SubDownloadsCnt;
        public string MovieReleaseName;
        public string IDMovie;
        public string IDMovieImdb;
        public string MovieName;
        public string MovieNameEng;
        public string MovieYear;
        public string MovieImdbRating;
        public string UserNickName;
        public string ISO639;
        public string LanguageName;
        public string SubDownloadLink;
        public string ZipDownloadLink;
    }

    public class SubtitleDownloadException : Exception
    {
        public SubtitleDownloadException(string msg, string details)
            : base(string.Format("{0} ({1}).", msg, details))
        {
        }
    }
}
