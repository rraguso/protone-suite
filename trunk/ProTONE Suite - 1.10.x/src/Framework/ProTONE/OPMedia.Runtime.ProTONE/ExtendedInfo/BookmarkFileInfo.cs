using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.FileInformation;
using System.IO;
using OPMedia.Core.Logging;
using System.ComponentModel;
using System.Drawing.Design;
using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core;

namespace OPMedia.Runtime.ProTONE.ExtendedInfo
{
    public class BookmarkFileInfo : NativeFileInfo
    {
        string _path = string.Empty;
        public event EventHandler BookmarkCollectionChanged = null;

        Dictionary<TimeSpan, Bookmark> _bookmarks = new Dictionary<TimeSpan, Bookmark>();

        [Browsable(false)]
        public Dictionary<TimeSpan, Bookmark> Bookmarks
        { get { return _bookmarks; } }

        [Browsable(true)]
        [TranslatableCategory("TXT_BOOKMARKINFO")]
        [TranslatableDisplayName("TXT_ISORPHAN")]
        public bool IsOrphan
        { get { return !File.Exists(ParentMediaFile); } }

        [Browsable(true)]
        [TranslatableDisplayName("TXT_PARENTMEDIAFILE")]
        [TranslatableCategory("TXT_BOOKMARKINFO")]
        public string ParentMediaFile
        { get { return base.Path.Replace(".bmk", string.Empty); } }

        [Browsable(true)]
        [Editor("OPMedia.UI.ProTONE.Controls.BookmarkManagement.BookmarkPropertyBrowser, OPMedia.UI.ProTONE", typeof(UITypeEditor))]
        [TranslatableDisplayName("TXT_BOOKMARKLIST")]
        [TranslatableCategory("TXT_BOOKMARKINFO")]
        public PlaylistItem BookmarkManager
        {
            get { return new BoormarkEditablePlaylistItem(this.ParentMediaFile); }
        }

        public BookmarkFileInfo()
            : base()
        {
        }

        public BookmarkFileInfo(string path, bool throwExceptionOnInvalid)
            : base(path, false)
        {
            _path = path;

            string extension = PathUtils.GetExtension(path);
            if (!base.IsValid || extension != "bmk")
            {
                if (throwExceptionOnInvalid)
                    throw new FileLoadException("Unexpected file type: " + extension,
                            path);

                return;
            }
                
            LoadBookmarks(false, throwExceptionOnInvalid);
        }

        internal void LoadBookmarks(bool raiseEvent, bool throwException)
        {
            _bookmarks.Clear();

            try
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        if (!line.StartsWith("#"))
                        {
                            Bookmark bmk = Bookmark.FromString(line);
                            if (bmk != null)
                            {
                                if (_bookmarks.ContainsKey(bmk.PlaybackTime))
                                {
                                    _bookmarks[bmk.PlaybackTime] = bmk;
                                }
                                else
                                {
                                    _bookmarks.Add(bmk.PlaybackTime, bmk);
                                }
                            }
                        }

                        line = sr.ReadLine();
                    }
                }

                if (raiseEvent && BookmarkCollectionChanged != null)
                {
                    BookmarkCollectionChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                if (throwException)
                {
                    ErrorDispatcher.DispatchError(ex);
                }
                else
                {
                    Logger.LogException(ex);
                }
            }
        }

        internal void SaveBookmarks()
        {
            try
            {
                if (_bookmarks.Count > 0)
                {
                    using (StreamWriter sw = new StreamWriter(_path))
                    {
                        sw.WriteLine("#BOOKMARK[TIME|TITLE]");
                        sw.WriteLine("#BEGIN");
                        foreach (KeyValuePair<TimeSpan, Bookmark> item in _bookmarks)
                        {
                            sw.WriteLine(item.Value.ToString());
                        }
                        sw.WriteLine("#END");
                    }
                }
                else
                {
                    // Erase empty bookmark file
                    if (File.Exists(_path))
                    {
                        FileAttributes fa = File.GetAttributes(_path);
                        File.SetAttributes(_path, fa ^ fa);
                        File.Delete(_path);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }

            if (File.Exists(_path))
            {
                LoadBookmarks(true, true);
            }
            
            if (BookmarkCollectionChanged != null)
            {
                BookmarkCollectionChanged(null, null);
            }

        }
    }
}
