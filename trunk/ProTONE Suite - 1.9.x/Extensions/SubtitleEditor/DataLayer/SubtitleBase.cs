using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Core;

namespace SubtitleEditor.extension.DataLayer
{
    public abstract class SubtitleBase
    {
        public const string TimeDisplayFormat = @"hh\:mm\:ss\.fff";

        protected List<SubtitleElement> _elements = new List<SubtitleElement>();

        public string File
        {
            get
            {
                return _file;
            }
        }

        public List<SubtitleElement> Elements
        {
            get
            {
                return _elements;
            }
        }

        public static SubtitleBase LoadFromFile(string path)
        {
            string ext = PathUtils.GetExtension(path).ToLowerInvariant();
            switch (ext)
            {
                case "sub":
                    return new MicroDvdSubtitle(path);

                case "srt":
                    return new SubRipSubtitle(path);
            }

            return null;
        }

        public SubtitleBase SaveToFile(string path)
        {
            SubtitleBase dest = null;

            string ext = PathUtils.GetExtension(path).ToLowerInvariant();
            switch (ext)
            {
                case "sub":
                    dest = new MicroDvdSubtitle(this);
                    break;

                case "srt":
                    dest = new SubRipSubtitle(this);
                    break;
            }

            if (dest != null)
            {
                dest.SaveInternal(path);
                //ile = path;
            }

            return dest;
        }

        public void Save()
        {
            DoSave();
        }

        protected string _file = string.Empty;

        protected SubtitleBase()
        {
            _elements = new List<SubtitleElement>();
        }

        protected SubtitleBase(SubtitleBase src)
        {
            _elements = new List<SubtitleElement>(src.Elements);
        }

        protected SubtitleBase(string file) : this()
        {
            _file = file;
            _elements.Clear();
            DoLoad();
        }

        private void SaveInternal(string file)
        {
            _file = file;
            DoSave();
        }

        protected abstract void DoSave();
        protected abstract void DoLoad();
    }
}
