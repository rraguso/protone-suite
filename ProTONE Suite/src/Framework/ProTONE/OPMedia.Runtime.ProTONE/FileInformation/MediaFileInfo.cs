using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using OPMedia.Runtime.ProTONE.Rendering;
using System.IO;
using System.Drawing;
using OPMedia.Runtime.FileInformation;
using OPMedia.Runtime.ProTONE.ExtendedInfo;
using OPMedia.Core.Logging;
using System.Drawing.Design;
using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.Core.TranslationSupport;
using TagLib.Mpeg;

namespace OPMedia.Runtime.ProTONE.FileInformation
{
    public class MediaFileInfo : NativeFileInfo
    {
        public static new readonly MediaFileInfo Empty = new MediaFileInfo();

        public event EventHandler BookmarkCollectionChanged = null;

        private string mediaType;
        private BookmarkFileInfo _bookmarkInfo;

        [Browsable(false)]
        public bool IsVideoFile
        {

            get
            {
                return ((this is VideoFileInfo) && !IsDVDVolume);
            }
        }

        [Browsable(false)]
        public bool IsDVDVolume
        {
            get
            {
                return (this is VideoDvdInformation);
            }
        }


        [Browsable(false)]
        public virtual BookmarkFileInfo BookmarkFileInfo
        { get { return _bookmarkInfo; } }

        [Browsable(false)]
        public Dictionary<TimeSpan, Bookmark> Bookmarks
        { 
            get 
            {
                if (_bookmarkInfo == null)
                    return null;

                return _bookmarkInfo.Bookmarks; 
            } 
        }

        [Browsable(false)]
        public virtual string Title
        {
            get { return base.Name; }
            set { }
        }

        [Browsable(false)]
        public virtual string Artist
        {
            get { return null; }
            set { }
        }

        [Browsable(false)]
        public virtual string Album
        {
            get { return null; }
            set { }
        }

        [Browsable(false)]
        public virtual string Genre
        {
            get { return null; }
            set { }
        }

        [Browsable(false)]
        public virtual string Comments
        {
            get { return null; }
            set { }
        }


        [Browsable(false)]
        public virtual short? Track
        {
            get { return null; }
            set { }
        }

        [Browsable(false)]
        public virtual short? Year
        {
            get { return null; }
            set { }
        }

        [Browsable(false)]
        [ReadOnly(true)]
        public virtual TimeSpan? Duration
        {
            get { return null; }
            set { }
        }

        [Browsable(false)]
        public virtual string MediaType
        {
            get { return mediaType; }
        }

        [Editor("OPMedia.UI.ProTONE.Controls.BookmarkManagement.BookmarkPropertyBrowser, OPMedia.UI.ProTONE", typeof(UITypeEditor))]
        [TranslatableDisplayName("TXT_BOOKMARKLIST")]
        [TranslatableCategory("TXT_EXTRAINFO")]
        [SingleSelectionBrowsable]
        public PlaylistItem BookmarkManager
        {
            get {  return new BoormarkEditablePlaylistItem(this.Path); }
            set { /* dummy setter just to enable drop down editing in property grids */ }
        }

        [Browsable(false)]
        public virtual Image CustomImage
        {
            get { return null; }
        }

        [Browsable(false)]
        public virtual Bitrate? Bitrate
        {
            get { return null; }
            set { }
        }
        
        [Browsable(false)]
        public virtual ChannelMode? Channels
        {
            get { return null; }
            set { }
        }
        
        [Browsable(false)]
        public virtual int? Frequency
        {
            get { return null; }
            set { }
        }

        [Browsable(false)]
        public virtual VSize? VideoSize
        {
            get { return null; }
            set { }
        }

        [Browsable(false)]
        public virtual FrameRate? FrameRate
        {
            get { return null; }
            set { }
        }

        protected override string GetDetailsInner()
        {
            string retVal = string.Empty;
            if (ExtendedInfo != null)
            {
                foreach (KeyValuePair<string, string> kvp in ExtendedInfo)
                {
                    if (string.IsNullOrEmpty(kvp.Key) &&
                        string.IsNullOrEmpty(kvp.Value))
                    {
                        retVal += "\r\n";
                    }
                    else
                    {
                        retVal += string.Format("{0} {1}\r\n", kvp.Key, kvp.Value);
                    }
                }
            }
            return retVal.TrimEnd(new char[] { '\r', '\n' });
        }

        public Bookmark GetNearestBookmarkInRange(int timeStamp, int range)
        {
            if (_bookmarkInfo == null ||
                _bookmarkInfo.Bookmarks == null ||
                _bookmarkInfo.Bookmarks.Values == null)
                return null;

            // Try to locate the closest bookmark in range
            Bookmark prevBmk = Bookmark.Empty;

            List<Bookmark> bmkList = new List<Bookmark>(_bookmarkInfo.Bookmarks.Values);
            bmkList.Sort(Bookmark.CompareByTime);

            foreach (Bookmark bmk in bmkList)
            {
                int bmkSeconds = (int)bmk.PlaybackTime.TotalSeconds;
                if (Math.Abs(timeStamp - bmkSeconds) <= range)
                {
                    prevBmk = bmk;
                    break;
                }
            }

            if (prevBmk != Bookmark.Empty)
            {
                Logger.LogHeavyTrace("Extract Bookmark: " + prevBmk.ToString());
            }

            return (prevBmk != Bookmark.Empty) ? prevBmk : null;
        }

        public void LoadBookmarks(bool throwException)
        {
            _bookmarkInfo.LoadBookmarks(true, throwException);
        }

        public void SaveBookmarks(bool reloadAfterSave)
        {
            _bookmarkInfo.SaveBookmarks(reloadAfterSave);
        }

        protected MediaFileInfo()
            : base()
        {
        }

        protected MediaFileInfo(string path, bool throwExceptionOnInvalid)
            : base(path, throwExceptionOnInvalid)
        {
            BuildFields();
        }

        private void BuildFields()
        {
            if (IsURI)
            {
                mediaType = "URL";
            }
            else if (!string.IsNullOrEmpty(base.Path))
            {
                try
                {
                    string mediaName = base.Name;
                    mediaType = base.Extension.Trim(new char[] { '.' }).ToLowerInvariant();
                    MediaRenderer renderer = MediaRenderer.DefaultInstance;
                    
                    if (!MediaRenderer.AllMediaTypes.Contains(mediaType))
                    {
                        throw new FileLoadException("Unexpected file type: " + mediaType,
                            base.Path);
                    }

                    // Check for bookmark file
                    string bookmarkPath = string.Format("{0}.bmk", base.Path);
                    _bookmarkInfo = new BookmarkFileInfo(bookmarkPath, false);

                    _bookmarkInfo.BookmarkCollectionChanged += 
                        new EventHandler(_bookmarkInfo_BookmarkCollectionChanged);
                }
                catch (FileLoadException)
                {
                    throw;
                }
                catch (FileNotFoundException)
                {
                    throw;
                }
                catch
                {
                }
            }
        }

        void _bookmarkInfo_BookmarkCollectionChanged(object sender, EventArgs e)
        {
            if (BookmarkCollectionChanged != null)
            {
                BookmarkCollectionChanged(sender, e);
            }
        }

        public virtual void DeepLoad()
        {
        }

        public static MediaFileInfo FromPath(string path)
        {
            return FromPath(path, false);
        }

        public static MediaFileInfo FromPath(string path, bool deepLoad)
        {
            MediaFileInfo mi = new MediaFileInfo(path, true);

            if (!mi.IsURI)
            {
                try
                {
                    if (!MediaRenderer.AllMediaTypes.Contains(mi.MediaType))
                    {
                        throw new FileLoadException("Unexpected file type: " + mi.MediaType,
                            path);
                    }
                }
                catch (FileLoadException)
                {
                    throw;
                }
                catch
                {
                }
            }

            if (MediaRenderer.SupportedVideoTypes.Contains(mi.MediaType))
            {
                // video file
                return MediaRenderer.DefaultInstance.QueryVideoMediaInfo(path);
            }
            else
            {
                // audio file or playlist
                switch (mi.MediaType)
                {
                    case "cda":
                        return new CDAFileInfo(path, deepLoad);

                    case "mp1":
                    case "mp2":
                    case "mp3":
                        // MPEG 1 Layer 1/2/3 with ID3 metadata
                        return new ID3FileInfo(path, deepLoad);

                    case "wav":
                    case "mpa":
                    case "au":
                    case "aif":
                    case "aiff":
                    case "snd":
                    case "mid":
                    case "midi":
                    case "rmi":
                    case "raw":
                    case "wma":
                    case "dctmp":
                    case "dat":
                    default:
                        // Other formats (no metadata available)
                        return mi;
                }
            }
        }



        public virtual void Rebuild()
        {
        }

        public virtual void Save()
        {
        }

        public virtual void Clear()
        {
        }

        public MediaFileInfoSlim Slim()
        {
            if (this is ID3FileInfo || this is CDAFileInfo)
                return new AudioFileInfoSlim(this);
            else if (this is VideoFileInfo)
                return new VideoFileInfoSlim(this);
            else
                return new MediaFileInfoSlim(this);

        }
    }

    public class MediaFileInfoSlim
    {
        protected MediaFileInfo _mfi = null;

        public MediaFileInfoSlim(MediaFileInfo mfi)
        {
            _mfi = mfi;
        }

        public void Save()
        {
            if (_mfi != null) _mfi.Save();
        }

        [TranslatableDisplayName("TXT_TITLE")]
        [TranslatableCategory("TXT_TAGINFO")]
        [ReadOnly(true)]
        public string Title
        {
            get { return (_mfi != null) ? _mfi.Title : null; }
            set { if (_mfi != null) _mfi.Title = value; }
        }

    }

    public class VideoFileInfoSlim : MediaFileInfoSlim
    {
        public VideoFileInfoSlim(MediaFileInfo mfi)
            : base(mfi)
        {
        }

        [TranslatableDisplayName("TXT_VIDEO_SIZE")]
        [TranslatableCategory("TXT_MEDIAINFO")]
        [SingleSelectionBrowsable]
        [ReadOnly(true)]
        public VSize? VideoSize
        {
            get { return (_mfi != null) ? _mfi.VideoSize : null; }
        }

        [TranslatableDisplayName("TXT_FRAME_RATE")]
        [TranslatableCategory("TXT_MEDIAINFO")]
        [SingleSelectionBrowsable]
        [ReadOnly(true)]
        public FrameRate? FrameRate
        {
            get { return (_mfi != null) ? _mfi.FrameRate : null; }
        }

        [TranslatableDisplayName("TXT_DURATION")]
        [TranslatableCategory("TXT_MEDIAINFO")]
        [ReadOnly(true)]
        public TimeSpan? Duration
        {
            get { return (_mfi != null) ? _mfi.Duration : null; }
        }

    }

    public class AudioFileInfoSlim : MediaFileInfoSlim
    {
        public AudioFileInfoSlim(MediaFileInfo mfi) 
            : base(mfi)
        {
        }

        [TranslatableDisplayName("TXT_ARTIST")]
        [TranslatableCategory("TXT_TAGINFO")]
        public string Artist
        {
            get { return (_mfi != null) ? _mfi.Artist : null; }
            set { if (_mfi != null) _mfi.Artist = value; }
        }

        [TranslatableDisplayName("TXT_ALBUM")]
        [TranslatableCategory("TXT_TAGINFO")]
        public string Album
        {
            get { return (_mfi != null) ? _mfi.Album : null; }
            set { if (_mfi != null) _mfi.Album = value; }
        }

        [TranslatableDisplayName("TXT_GENRE")]
        [TranslatableCategory("TXT_TAGINFO")]
        [Editor("OPMedia.Runtime.ProTONE.GenrePropertyBrowser, OPMedia.Runtime.ProTONE", typeof(UITypeEditor))]
        public string Genre
        {
            get { return (_mfi != null) ? _mfi.Genre : null; }
            set { if (_mfi != null) _mfi.Genre = value; }
        }

        [TranslatableDisplayName("TXT_COMMENTS")]
        [TranslatableCategory("TXT_TAGINFO")]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            typeof(UITypeEditor)), Localizable(true)]
        public string Comments
        {
            get { return (_mfi != null) ? _mfi.Comments : null; }
            set { if (_mfi != null) _mfi.Comments = value; }
        }

        [TranslatableDisplayName("TXT_TRACK")]
        [TranslatableCategory("TXT_TAGINFO")]
        [DefaultValue((short)1)]
        public short? Track
        {
            get { return (_mfi != null) ? _mfi.Track : null; }
            set { if (_mfi != null) _mfi.Track = value; }
        }

        [TranslatableDisplayName("TXT_YEAR")]
        [TranslatableCategory("TXT_TAGINFO")]
        public short? Year
        {
            get { return (_mfi != null) ? _mfi.Year : null; }
            set { if (_mfi != null) _mfi.Year = value; }
        }

        [TranslatableDisplayName("TXT_BITRATE")]
        [TranslatableCategory("TXT_MEDIAINFO")]
        public Bitrate? Bitrate
        {
            get { return (_mfi != null) ? _mfi.Bitrate : null; }
        }

        [TranslatableDisplayName("TXT_CHANNELS")]
        [TranslatableCategory("TXT_MEDIAINFO")]
        public ChannelMode? Channels
        {
            get { return (_mfi != null) ? _mfi.Channels : null; }
        }

        [TranslatableDisplayName("TXT_FREQUENCY")]
        [TranslatableCategory("TXT_MEDIAINFO")]
        public int? Frequency
        {
            get { return (_mfi != null) ? _mfi.Frequency : null; }
        }

        [TranslatableDisplayName("TXT_DURATION")]
        [TranslatableCategory("TXT_MEDIAINFO")]
        [ReadOnly(true)]
        public TimeSpan? Duration
        {
            get { return (_mfi != null) ? _mfi.Duration : null; }
        }
    }
}
