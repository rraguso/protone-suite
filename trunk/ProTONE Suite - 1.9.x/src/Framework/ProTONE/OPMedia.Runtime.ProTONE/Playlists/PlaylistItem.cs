#region Copyright © 2008 OPMedia Research
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	PlaylistItem.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Core.TranslationSupport;
using System.Windows.Forms;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Runtime.ProTONE.ExtendedInfo;
using System.ComponentModel;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Core.Utilities;
#endregion

namespace OPMedia.Runtime.ProTONE.Playlists
{
    // This item appears in main playlist and in Playlist menu item of main menu
    public class PlaylistItem
    {
        protected MediaFileInfo mi = MediaFileInfo.Empty;

        public bool IsVideo
        {
            get
            {
                return (mi is VideoFileInfo);
            }
        }

        [Browsable(false)]
        public MediaFileInfo MediaFileInfo
        {
            get { return mi; }
        }

        public virtual string Path
        {
            get
            {
                return mi.Path;
            }
        }

        public virtual string DisplayName
        {
            get
            {
                string retVal = string.Empty;

                 string artist =string.Empty;
                 string album = string.Empty;
                 string title = string.Empty;
                 string genre = string.Empty;
                 string comments = string.Empty;
                 string track = string.Empty;
                 string year = string.Empty;

                if (AppSettings.UseMetadata)
                {
                    // Format using metadata
                    artist = mi.Artist;
                    album = mi.Album;
                    title = mi.Title;
                    genre = mi.Genre;
                    comments = mi.Comments;
                    track = (mi.Track.HasValue) ? mi.Track.GetValueOrDefault().ToString("d2") : string.Empty;
                    year = (mi.Year.HasValue) ? mi.Year.GetValueOrDefault().ToString("d4") : string.Empty;
                }

                if (AppSettings.UseFileNameFormat)
                {
                    // First - parse the file name
                    string name = mi.Name;
                    if (!string.IsNullOrEmpty(mi.Extension))
                    {
                        name = name.Replace(mi.Extension, string.Empty);
                    }

                    Dictionary<string, string> fileTokens = StringUtils.Tokenize(name, AppSettings.FileNameFormat);

                    // Second - replace formatting fields with data from file name where available
                    if (fileTokens != null && fileTokens.Count > 0)
                    {
                        artist =   GetFieldValue(artist,   GetTokenValue(fileTokens, "<A>"));
                        album =    GetFieldValue(album,    GetTokenValue(fileTokens, "<B>"));
                        title =    GetFieldValue(title,    GetTokenValue(fileTokens, "<T>"));
                        genre =    GetFieldValue(genre,    GetTokenValue(fileTokens, "<G>"));
                        comments = GetFieldValue(comments, GetTokenValue(fileTokens, "<C>"));
                        track =    GetFieldValue(track,    GetTokenValue(fileTokens, "<#>"));
                        year =     GetFieldValue(year,     GetTokenValue(fileTokens, "<Y>"));
                    }
                }

                if (AppSettings.UseMetadata || AppSettings.UseFileNameFormat)
                {
                    // Format entries if any formatting rules are applied

                    retVal = AppSettings.PlaylistEntryFormat;
                    StringUtils.ReplaceToken(ref retVal, "<A", artist ?? string.Empty);
                    StringUtils.ReplaceToken(ref retVal, "<B", album ?? string.Empty);
                    StringUtils.ReplaceToken(ref retVal, "<T", title ?? string.Empty);
                    StringUtils.ReplaceToken(ref retVal, "<G", genre ?? string.Empty);
                    StringUtils.ReplaceToken(ref retVal, "<C", comments ?? string.Empty);
                    StringUtils.ReplaceToken(ref retVal, "<#", track ?? string.Empty);
                    StringUtils.ReplaceToken(ref retVal, "<Y", year ?? string.Empty);
                }

                retVal = retVal.Trim();
                retVal = retVal.Trim(new char[] { '-' });
                retVal = retVal.Trim();

                if (string.IsNullOrEmpty(retVal))
                {
                    // Use file name
                    retVal = mi.Name;
                }

                return retVal;
            }
        }

        public virtual string Type
        {
            get
            {
                return mi.MediaType;
            }
        }

        public virtual int TrackNumber
        {
            get
            {
                return (int)(mi.Track.GetValueOrDefault());
            }
        }

        public virtual TimeSpan Duration
        {
            get
            {
                TimeSpan ts = mi.Duration.GetValueOrDefault();
                return new TimeSpan(ts.Hours, ts.Minutes, ts.Seconds);
            }

            set
            {
                mi.Duration = value;
            }
        }

        public virtual string Details
        {
            get
            {
                string retVal = string.Empty;
                if (MediaInfo != null)
                {
                    foreach (KeyValuePair<string, string> kvp in mi.ExtendedInfo)
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
                return retVal.TrimEnd(new char[]{'\r', '\n'});
            }
        }

        public virtual Dictionary<string, string> MediaInfo
        {
            get
            {
                return mi.ExtendedInfo;
            }
        }

        public virtual Dictionary<PlaylistSubItem, List<PlaylistSubItem>> GetSubmenu()
        {
            if (mi.Bookmarks != null && mi.Bookmarks.Count > 0)
            {
                return CreateBookmarksSubmenu();
            }
            else
            {
                if (mi is CDAFileInfo)
                {
                    return CreateAudioCdSubmenu();
                }

                // Don't insert anything.
                // This is a regular file item.
                return null;
            }
        }

        private Dictionary<PlaylistSubItem, List<PlaylistSubItem>> CreateAudioCdSubmenu()
        {
            Dictionary<PlaylistSubItem, List<PlaylistSubItem>> submenu =
                            new Dictionary<PlaylistSubItem, List<PlaylistSubItem>>();

            submenu.Add(new AudioCdSubItem(this, "Read CDDB", "CDDB"), null);
            submenu.Add(new AudioCdSubItem(this, "Read CD-Text", "CDTEXT"), null);

            return submenu;
        }

        private Dictionary<PlaylistSubItem, List<PlaylistSubItem>> CreateBookmarksSubmenu()
        {
            Dictionary<PlaylistSubItem, List<PlaylistSubItem>> submenu =
                            new Dictionary<PlaylistSubItem, List<PlaylistSubItem>>();

            PlaylistSubItem title = new BookmarkSubItem(this, "Bookmarks");

            List<PlaylistSubItem> bookmarks = new List<PlaylistSubItem>();

            if (mi.Bookmarks != null && mi.Bookmarks.Count > 0)
            {
                foreach (Bookmark bmk in mi.Bookmarks.Values)
                {
                    BookmarkSubItem bmkSubItem = new BookmarkSubItem(this, bmk);
                    bookmarks.Add(bmkSubItem);
                }
            }

            submenu.Add(title, bookmarks);

            return submenu;
        }

        public virtual void DeepLoad()
        {
            if (mi != null)
            {
                mi.DeepLoad();
            }
        }

        public virtual bool MoveToSubitem(PlaylistSubItem subItem)
        {
            // No subitems to move to ...
            return false;
        }

        public override string ToString()
        {
            return mi.Name;
        }

        public PlaylistItem(string itemPath, bool deepLoad) : this(itemPath, false, deepLoad)
        {
        }

        public PlaylistItem(string itemPath, bool isDvd, bool deepLoad)
        {
            if (isDvd)
                mi = new VideoDvdInformation(itemPath);
            else
                mi = MediaFileInfo.FromPath(itemPath, deepLoad);
        }

        private string GetTokenValue(Dictionary<string, string> tokens, string token)
        {
            if (tokens != null && tokens.Count > 0 && tokens.ContainsKey(token))
                return tokens[token];

            return string.Empty;
        }

        private string GetFieldValue(string field1, string field2)
        {
            string retVal = field1;

            if (string.IsNullOrEmpty(retVal))
            {
                retVal = field2;
            }
            if (string.IsNullOrEmpty(retVal))
            {
                retVal = string.Empty;
            }

            return retVal;
        }
    }

    public class BoormarkEditablePlaylistItem : PlaylistItem
    {
        public BoormarkEditablePlaylistItem(string itemPath) : base(itemPath, false)
        {
        }

        public override string ToString()
        {
            int count = 0;
            if (base.MediaFileInfo.Bookmarks != null)
            {
                count = base.MediaFileInfo.Bookmarks.Count;
            }

            return Translator.Translate("TXT_BOOKMARK_COUNT", count);
        }
    }

    // This item appears in the drop down menu
    // that may be attached to a playlist item
    public abstract class PlaylistSubItem
    {
        protected string _name = string.Empty;
        public string Name { get { return _name; } }

        protected PlaylistItem _parent = null;
        public PlaylistItem Parent
        { get { return _parent; } }

        protected RenderingStartHint _hint = null;
        public RenderingStartHint StartHint
        { get { return _hint; } }

        public virtual string ParentMediaPath
        {
            get
            {
                return _parent.Path;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        public PlaylistSubItem(string name, PlaylistItem parent)
        {
            _name = name;
            _parent = parent;
        }
    }
}

