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
        public BookmarkFileInfo BookmarkFileInfo
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
            get { return null; }
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
        public virtual Dictionary<string, string> ExtendedInfo
        {
            get { return null; }
            set { }
        }

        //[Browsable(false)]
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
        [TranslatableCategory("TXT_BOOKMARKINFO")]
        [SingleSelectionBrowsable]
        public PlaylistItem BookmarkManager
        {
            get { return new BoormarkEditablePlaylistItem(this.Path); }
        }

        [Browsable(false)]
        public virtual Image CustomImage
        {
            get { return null; }
        }

        public Bookmark GetNearestBookmarkInRange(int timeStamp, int range)
        {
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

        public void SaveBookmarks()
        {
            _bookmarkInfo.SaveBookmarks();
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
            if (!IsURI && !string.IsNullOrEmpty(base.Path))
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

        
    }

}
