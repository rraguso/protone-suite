using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Runtime.ProTONE.Rendering.Cdda.Freedb;
using OPMedia.Runtime.ProTONE.Rendering.Cdda;
using System.ComponentModel;
using OPMedia.Core;
using System.Net;
using OPMedia.Core.Logging;
using OPMedia.Runtime.ProTONE.Rendering.Cdda.FreeDb;
using System.IO;
using System.IO.Compression;
using System.Data;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.FileInformation;
using OPMedia.Runtime.ProTONE.ExtendedInfo;
using OPMedia.Runtime.ProTONE.Playlists;

namespace OPMedia.Runtime.ProTONE.FileInformation
{
    public class CDAFileInfo : MediaFileInfo
    {
        static Dictionary<string, CDEntry> _cdEntries = new Dictionary<string, CDEntry>();

        CDEntry _cdEntry = null;
        int _track = -1;
        int _duration = 0;

        static string _fileName = string.Empty;

        static CDAFileInfo()
        {
            _fileName = System.IO.Path.Combine(ApplicationInfo.SettingsFolder, "FreeDbLite.dat");
            LoadCdEntries();
        }

        private static void LoadCdEntries()
        {
            CDEntryDataSet ds = new CDEntryDataSet();

            if (System.IO.File.Exists(_fileName))
            {
                try
                {
                    using (FileStream inputStream = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (GZipStream zipStream = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                        if (zipStream != null)
                        {
                            ds.ReadXml(zipStream);
                            zipStream.Close();
                            inputStream.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            }

            if (ds.CD != null && ds.CD.Rows != null && ds.CD.Rows.Count > 0)
            {
                foreach (DataRow row in ds.CD.Rows)
                {
                    CDEntryDataSet.CDRow cdRow = row as CDEntryDataSet.CDRow;
                    if (cdRow != null)
                    {
                        CDEntry cdEntry = null;

                        if (_cdEntries.ContainsKey(cdRow.Discid))
                        {
                            cdEntry = _cdEntries[cdRow.Discid];
                        }
                        else
                        {
                            cdEntry = new CDEntry();
                            cdEntry.Artist = cdRow.Artist;
                            cdEntry.Discid = cdRow.Discid;
                            cdEntry.Genre = cdRow.Genre;
                            //cdEntry.PlayOrder = cdRow.Pl
                            cdEntry.Title = cdRow.Album;
                            cdEntry.Year = cdRow.Year;

                            _cdEntries.Add(cdRow.Discid, cdEntry);
                        }

                        cdEntry.Tracks.Add(new Track(cdRow.Title, cdRow.ExtendedData));
                    }
                }
            }
        }

        private static void SaveCdEntries()
        {
            CDEntryDataSet ds = new CDEntryDataSet();
            foreach (KeyValuePair<string, CDEntry> cdEntry in _cdEntries)
            {
                if (cdEntry.Value.Tracks != null)
                {
                    int trackNumber = 1;
                    foreach (Track t in cdEntry.Value.Tracks)
                    {
                        ds.CD.AddCDRow(cdEntry.Key, trackNumber.ToString(), cdEntry.Value.Artist,
                            cdEntry.Value.Title, t.Title, cdEntry.Value.Year, cdEntry.Value.Genre, t.ExtendedData);

                        trackNumber++;
                    }
                }
            }
            ds.AcceptChanges();

            if (ds.CD != null && ds.CD.Rows != null && ds.CD.Rows.Count > 0)
            {
                using (FileStream outputStream = new FileStream(_fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                using (GZipStream zipStream = new GZipStream(outputStream, CompressionMode.Compress))
                {
                    if (zipStream != null)
                    {
                        ds.WriteXml(zipStream);
                        zipStream.Close();
                        outputStream.Close();
                    }
                }
            }
        }

        [Browsable(false)]
        [ReadOnly(true)]
        public new PlaylistItem BookmarkManager
        {
            get { return null; }
        }

        [TranslatableDisplayName("TXT_TITLE")]
        [TranslatableCategory("TXT_CDTRACKINFO")]
        [Browsable(true)]
        [ReadOnly(true)]
        public override string Title
        {
            get
            {
                if (_cdEntry != null)
                {
                    Track tr = _cdEntry.Tracks[_track - 1];
                    return tr.Title;
                }

                return null;
            }
            
            
        }

        [TranslatableDisplayName("TXT_ARTIST")]
        [TranslatableCategory("TXT_CDTRACKINFO")]
        [Browsable(true)]
        [ReadOnly(true)]
        public override string Artist
        {
            get { return _cdEntry != null ? _cdEntry.Artist : string.Empty; }
            
        }

        [TranslatableDisplayName("TXT_ALBUM")]
        [TranslatableCategory("TXT_CDTRACKINFO")]
        [Browsable(true)]
        public override string Album
        {
            get { return _cdEntry != null ? _cdEntry.Title : string.Empty; }
            
        }

        [TranslatableDisplayName("TXT_GENRE")]
        [TranslatableCategory("TXT_CDTRACKINFO")]
        [Browsable(true)]
        [ReadOnly(true)]
        public override string Genre
        {
            get { return _cdEntry != null ? _cdEntry.Genre : string.Empty; }
            
        }

        [Browsable(false)]
        public override string Comments
        {
            get { return string.Empty; }
            
        }


        [TranslatableDisplayName("TXT_TRACK")]
        [TranslatableCategory("TXT_CDTRACKINFO")]
        [SingleSelectionBrowsable]
        [ReadOnly(true)]
        public override short? Track
        {
            get { return (short)_track; }
            
        }

        [TranslatableDisplayName("TXT_YEAR")]
        [TranslatableCategory("TXT_CDTRACKINFO")]
        [Browsable(true)]
        [ReadOnly(true)]
        public override short? Year
        {
            get { return _cdEntry != null ? short.Parse(_cdEntry.Year) : new Nullable<short>(); }
            
        }

        [Browsable(false)]
        public override Dictionary<string, string> ExtendedInfo
        {
            get
            {
                Dictionary<string, string> info = new Dictionary<string, string>();

                info.Add("TXT_DURATION:", Duration.GetValueOrDefault().ToString());
                //info.Add("TXT_BITRATE:", Bitrate.GetValueOrDefault().ToString());
                //info.Add("TXT_CHANNELS:", Channels.GetValueOrDefault().ToString());
                //info.Add("TXT_FREQUENCY:", Frequency.GetValueOrDefault().ToString());

                if (_cdEntry != null)
                {
                    info.Add(string.Empty, null); // separator
                    bool removeSep = true;

                    if (!string.IsNullOrEmpty(Album))
                    {
                        removeSep = false;
                        info.Add("TXT_ALBUM:", Album);
                    }
                    if (!string.IsNullOrEmpty(Artist))
                    {
                        removeSep = false;
                        info.Add("TXT_ARTIST:", Artist);
                    }
                    if (!string.IsNullOrEmpty(Title))
                    {
                        removeSep = false;
                        info.Add("TXT_TITLE:", Title);
                    }
                    if (!string.IsNullOrEmpty(Genre))
                    {
                        removeSep = false;
                        info.Add("TXT_GENRE:", Genre);
                    }
                    //if (!string.IsNullOrEmpty(Comments))
                    //{
                    //    removeSep = false;
                    //    info.Add("TXT_COMMENTS:", Comments);
                    //}
                    if (Track.HasValue)
                    {
                        removeSep = false;
                        info.Add("TXT_TRACK:", Track.GetValueOrDefault().ToString());
                    }
                    if (Year.HasValue)
                    {
                        removeSep = false;
                        info.Add("TXT_YEAR:", Year.GetValueOrDefault().ToString());
                    }

                    if (removeSep)
                    {
                        info.Remove(string.Empty);
                    }
                }

                return info;
            }
           
            
        }

        [TranslatableDisplayName("TXT_DURATION")]
        [TranslatableCategory("TXT_CDTRACKINFO")]
        [SingleSelectionBrowsable]
        [ReadOnly(true)]
        public override TimeSpan? Duration
        {
            get
            {
                return TimeSpan.FromSeconds(_duration);
            }

            
        }

        [Browsable(false)]
        public override string MediaType
        {
            get { return "CDA"; }
        }

        public CDAFileInfo(string path, bool deepLoad)
            : base(path, false)
        {
            try
            {
                string rootPath = System.IO.Path.GetPathRoot(path);
                if (!string.IsNullOrEmpty(rootPath))
                {
                    char letter = rootPath.ToUpperInvariant()[0];
                    using (CDDrive cd = new CDDrive())
                    {
                        if (cd.Open(letter) && cd.Refresh())
                        {
                            string trackStr = path.Replace(rootPath, "").ToLowerInvariant().Replace("track", "").Replace(".cda", "");
                            _track = -1;
                            if (int.TryParse(trackStr, out _track) && _track > 0)
                            {
                                if (cd.IsAudioTrack(_track))
                                {
                                    // CD-Text not available, try to get info from CDDB
                                    _duration = cd.GetSeconds(_track);
                                    
                                    string diskId = cd.GetCDDBDiskID();

                                    if (_cdEntries.ContainsKey(diskId))
                                    {
                                        _cdEntry = _cdEntries[diskId];
                                        return;
                                    }
                                    else
                                    {
                                        TrackCollection tracks = null;
                                        if (cd.ReadCDText(out tracks))
                                        {
                                            _cdEntry = new CDEntry();
                                            _cdEntry.Tracks = tracks;
                                        }
                                        else
                                        {
                                            using (FreedbHelper fdb = new FreedbHelper("freedb.freedb.org", 8880))
                                            {
                                                string query = cd.GetCDDBQuery();
                                                QueryResult qr;
                                                QueryResultCollection coll;
                                                string s = fdb.Query(query, out qr, out coll);

                                                if (qr == null && coll != null && coll.Count > 0)
                                                {
                                                    qr = coll[0];
                                                }

                                                if (qr != null)
                                                {
                                                    s = fdb.Read(qr, out _cdEntry);
                                                }
                                            }
                                        }

                                        if (_cdEntry != null)
                                        {
                                            if (_cdEntries.ContainsKey(diskId))
                                            {
                                                _cdEntries[diskId] = _cdEntry;
                                            }
                                            else
                                            {
                                                _cdEntries.Add(diskId, _cdEntry);
                                                SaveCdEntries();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    _cdEntry = null;
                }
            }
            catch(Exception ex) 
            {
                Logger.LogException(ex);
                _cdEntry = null;
            }
        }
    }
}
