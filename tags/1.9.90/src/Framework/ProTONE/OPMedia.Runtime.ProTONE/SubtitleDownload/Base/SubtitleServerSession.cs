using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;
using OPMedia.Core.Logging;
using System.IO;
using OPMedia.Core.NetworkAccess;
using OPMedia.Core.ApplicationSettings;
using System.IO.Compression;
using OPMedia.Runtime.FileInformation;
using OPMedia.Runtime.ProTONE.SubtitleDownload.BSP_V1;
using OPMedia.Runtime.ProTONE.SubtitleDownload.NuSoap;
using OPMedia.Runtime.ProTONE.SubtitleDownload.Osdb;

namespace OPMedia.Runtime.ProTONE.SubtitleDownload.Base
{
    public enum SubtitleServerType
    {
        Osdb = 0,
        NuSoap = 1,
        BSP_V1 = 2,
    }

    public abstract class SubtitleServerSession : IDisposable
    {
        private System.Timers.Timer _tmrKeepAlive = null;

        protected string _serverUrl = string.Empty;
        protected string _username = string.Empty;
        protected string _password = string.Empty;
        protected CultureInfo _culture = null;
        
        protected string _sessionToken = string.Empty;

        #region Factory
        public static SubtitleServerSession Create(SubtitleServerType serverType, string serverUrl, string userName, string password, CultureInfo culture = null)
        {
            SubtitleServerSession session = null;

            try
            {
                switch (serverType)
                {
                    case SubtitleServerType.BSP_V1:
                        session = new BspV1Session(serverUrl, userName, password, culture);
                        break;

                    case SubtitleServerType.NuSoap:
                        session = new NuSoapSession(serverUrl, userName, password, culture);
                        break;

                    case SubtitleServerType.Osdb:
                    default:
                        session = new OsdbSession(serverUrl, userName, password, culture);
                        break;
                }
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }

            return session;
        }
        #endregion

        #region Server session operations
        public Dictionary<string, object> GetServerStatistics()
        {
            return DoGetServerStatistics();
        }

        public List<SubtitleInfo> GetSubtitles(string fileName)
        {
            List<SubtitleInfo> retVal = new List<SubtitleInfo>();

            NativeFileInfo nfi = new NativeFileInfo(fileName, true);
            if (nfi.IsValid)
            {
                string hashCode = FileHash.ToHexadecimal(FileHash.ComputeHash(fileName));

                VideoInfo ovi = new VideoInfo();
                ovi.imdbid = string.Empty;
                ovi.moviehash = hashCode;
                ovi.moviebytesize = nfi.Size.GetValueOrDefault();
                ovi.sublanguageid = "all";

                #region GetSubtitles Commented code - DEBUG PURPOSE ONLY
                // Name the movie "fringe 4x03.avi"                
                //ovi.moviehash = "18379ac9af039390";
                //ovi.moviebytesize = 366876694;
                #endregion

                List<SubtitleInfo> response = DoGetSubtitles(ovi);

                string[] fileNameParts = nfi.Name.ToLowerInvariant().Split(" -.][(){}".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (fileNameParts.Length > 0)
                {
                    List<string> fileNamePartsList = new List<string>(fileNameParts);
                    foreach (SubtitleInfo osf in response)
                    {
                        if (CheckMatch(osf.MovieName, fileNamePartsList))
                        {
                            retVal.Add(osf);
                        }
                        else if (CheckMatch(osf.MovieNameEng, fileNamePartsList))
                        {
                            retVal.Add(osf);
                        }
                        else if (CheckMatch(osf.MovieReleaseName, fileNamePartsList))
                        {
                            retVal.Add(osf);
                        }
                        else if (CheckMatch(osf.SubFileName, fileNamePartsList))
                        {
                            retVal.Add(osf);
                        }

                    }
                }
            }

            return retVal;
        }

        public string DownloadSubtitle(string fileName, SubtitleInfo subtitle)
        {
            if (string.IsNullOrEmpty(subtitle.SubFormat))
            {
                subtitle.SubFormat = "srt";
            }

            return DoDownloadSubtitle(fileName, subtitle);
        }

        #endregion

        #region Constructor
        public SubtitleServerSession(string serverUrl, string username, string password, CultureInfo culture)
        {
            _serverUrl = serverUrl;
            _username = username;
            _password = password;
            _culture = culture ?? Thread.CurrentThread.CurrentUICulture;

            DoInitializeSession();

            DoTestConnection();

            if (IsAuthenticationRequired())
            {
                DoAuthenticate();
            }

            // Create keepalive timer
            // keepAliveInterval == 0 means that no keep alive reoutine is required.
            double keepAliveInterval = GetKeepAliveInterval();
            if (keepAliveInterval > 0)
            {
                _tmrKeepAlive = new System.Timers.Timer();
                _tmrKeepAlive.AutoReset = true;
                _tmrKeepAlive.Interval = keepAliveInterval;
                _tmrKeepAlive.Elapsed += new System.Timers.ElapsedEventHandler(_tmrKeepAlive_Elapsed);
                _tmrKeepAlive.Start();
            }
        }
        #endregion

        #region Implementation
        void _tmrKeepAlive_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_tmrKeepAlive != null)
                _tmrKeepAlive.Stop();

            try
            {
                DoKeepAliveSession();
            }
            finally
            {
                if (_tmrKeepAlive != null)
                    _tmrKeepAlive.Start();
            }
        }

        protected void CheckAuthentication(string operationName)
        {
            if (IsAuthenticationRequired() && string.IsNullOrEmpty(_sessionToken))
            {
                throw new SubtitleDownloadException("Cannot perform " + operationName, "Not yet logged in");
            }
        }

        public void Dispose()
        {
            if (_tmrKeepAlive != null)
            {
                _tmrKeepAlive.Stop();
                _tmrKeepAlive = null;
            }

            DoCleanup();
            
            _sessionToken = null;
        }

        protected bool CheckMatch(string movieName, List<string> fileNamePartsList)
        {
            if (string.IsNullOrEmpty(movieName) ||
                fileNamePartsList == null || fileNamePartsList.Count == 0)
                return false;


            string[] movieNameParts = movieName
                .ToLowerInvariant()
                .Trim(Path.GetInvalidFileNameChars())
                .Split(" -.][(){}".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (movieNameParts.Length > 0)
            {
                List<string> movieNamePartsList = new List<string>(movieNameParts);
                int matchCounter = 0;

                foreach (string movieNamePart in movieNameParts)
                {
                    // Do we have a partial name match ?
                    if (fileNamePartsList.Contains(movieNamePart))
                        matchCounter++;

                    // Would current movie name part indicate it's a TV series ?
                    // I.e. S01E04 or 01x04
                    else if (CheckSeriesMovieName(movieNamePart, fileNamePartsList))
                        return true;

                    if (matchCounter >= 2)
                        return true;
                }
            }

            return false;
        }

        protected bool CheckSeriesMovieName(string movieNamePart, List<string> fileNamePartsList)
        {
            int movieEpisode = 0, movieSeason = 0;

            if (GetSeriesMovieCounters(movieNamePart, out movieSeason, out movieEpisode))
            {
                foreach (string fileNamePart in fileNamePartsList)
                {
                    int e = 0, s = 0;
                    if (GetSeriesMovieCounters(fileNamePart, out s, out e))
                    {
                        if (s == movieSeason && e == movieEpisode)
                            return true;
                    }
                }
            }

            return false;
        }

        protected bool GetSeriesMovieCounters(string fields, out int season, out int episode)
        {
            string[] seriesFields = fields.ToLowerInvariant().Split(
                "sex".ToCharArray() /* no obscene meaning ... these letters REALLY are our delimters ! :D */,
                StringSplitOptions.RemoveEmptyEntries);

            if (seriesFields.Length > 1)
            {
                bool s = int.TryParse(seriesFields[0], out season);
                bool e = int.TryParse(seriesFields[1], out episode);
                return s && e;
            }
            else if (seriesFields.Length == 1)
            {
                bool e = int.TryParse(seriesFields[0], out episode);
                season = 0;
                return e;
            }

            season = episode = -1;
            return false;
        }
        #endregion

        protected abstract void DoInitializeSession();
        protected abstract bool IsAuthenticationRequired();
        protected abstract void DoTestConnection();
        protected abstract void DoAuthenticate();
        protected abstract double GetKeepAliveInterval();
        protected abstract void DoKeepAliveSession();
        protected abstract void DoCleanup();

        protected abstract List<SubtitleInfo> DoGetSubtitles(VideoInfo vi);
        protected abstract Dictionary<string, object> DoGetServerStatistics();
        protected abstract string DoDownloadSubtitle(string fileName, SubtitleInfo subtitle);
    }
}
