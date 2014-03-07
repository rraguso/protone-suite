using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Core.Utilities;

namespace OPMedia.Runtime.ProTONE.ExtendedInfo
{
    public class Bookmark
    {
        public static readonly Bookmark Empty = new Bookmark();

        string _title = string.Empty;
        TimeSpan _playbackTime = new TimeSpan();

        public string Title
        { get { return _title; } set { _title = value; } }

        public TimeSpan PlaybackTime
        { get { return _playbackTime; } set { _playbackTime = value; } }

        public double PlaybackTimeInSeconds
        { get { return _playbackTime.TotalSeconds; } }

        public override string ToString()
        {
            return string.Format("{0}|{1}", 
                new TimeSpanConverter().ConvertToInvariantString(_playbackTime), 
                _title.Replace(";", " "));
        }

        public static int CompareByTime(Bookmark bmk1, Bookmark bmk2)
        {
            return TimeSpan.Compare(bmk1.PlaybackTime, bmk2.PlaybackTime);
        }

        public static Bookmark FromString(string bmkStr)
        {
            string[] fields = StringUtils.ToStringArray(bmkStr, '|');
            if (fields != null && fields.Length == 2)
            {
                return new Bookmark(fields[1], fields[0]);
            }

            return Bookmark.Empty;
        }

        public Bookmark(string title, TimeSpan playbackTime)
        {
            _title = title;
            _playbackTime = playbackTime;
        }

        public Bookmark(string title, int playbackTime)
        {
            _title = title;
            _playbackTime = TimeSpan.FromSeconds(playbackTime);
        }

        private Bookmark()
        {
            _title = string.Empty;
            _playbackTime = new TimeSpan();
        }

        private Bookmark(string title, string playbackTime)
        {
            _title = title;
            _playbackTime = (TimeSpan)new TimeSpanConverter().ConvertFromInvariantString(playbackTime);
        }

        public static DateTime MinimumDate
        {
            get
            {
                return new DateTime(1900, 1, 1, 0, 0, 0);
            }
        }

        public static DateTime MaximumDate
        {
            get
            {
                return new DateTime(1900, 1, 1, 23, 59, 59);
            }
        }
    }


    public class BookmarkSubItem : PlaylistSubItem
    {
        Bookmark _bookmark = null;

        public BookmarkSubItem(PlaylistItem parent, Bookmark bookmark)
            : base(bookmark.Title, parent)
        {
            _bookmark = bookmark;
            _hint = new BookmarkStartHint(bookmark);
        }

        public BookmarkSubItem(PlaylistItem parent, string name)
            : base(name, parent)
        {
        }
    }

    public class AudioCdSubItem : PlaylistSubItem
    {
        public AudioCdSubItem(PlaylistItem parent, string name)
            : base(name, parent)
        {
        }
    }

    public class BookmarkStartHint : RenderingStartHint
    {
        public Bookmark Bookmark = Bookmark.Empty;

        public override bool IsSubtitleHint
        {
            get { return false; }
        }

        public override string ToString()
        {
            return Bookmark.ToString();
        }

        public BookmarkStartHint(Bookmark bookmark)
        {
            Bookmark = bookmark;
        }
    }

}
