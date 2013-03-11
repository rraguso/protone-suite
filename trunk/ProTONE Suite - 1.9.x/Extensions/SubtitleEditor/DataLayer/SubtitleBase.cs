using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Core;
using System.IO;
using OPMedia.Runtime.ProTONE.Rendering;

namespace SubtitleEditor.extension.DataLayer
{
    public abstract class SubtitleBase
    {
        public const string TimeDisplayFormat = @"hh\:mm\:ss\.fff";
        public const string RtfContainerTemplate =
            @"{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fnil\fcharset238 Arial;}}{\colortbl;\red255\green255\blue255;}\viewkind4\uc1\pard\lang1033\fs24\f1\cf1 <TEXT>}";


        protected List<SubtitleElement> _elements = new List<SubtitleElement>();

        public string File
        {
            get
            {
                return _file;
            }
        }

        public string VideoFile { get; set; }

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

            LookupVideoFile();
        }

        private void LookupVideoFile()
        {
            string fileName = Path.GetFileNameWithoutExtension(_file).ToLowerInvariant();

            string folder = Path.GetDirectoryName(_file);
            IEnumerable<String> files = Directory.EnumerateFiles(folder);
            if (files != null && files.Count() > 0)
            {
                foreach (string file in files)
                {
                    if (file.ToLowerInvariant() == _file.ToLowerInvariant())
                        continue; // same file as the subtitle, not interesting

                    string ext = PathUtils.GetExtension(file);
                    if (MediaRenderer.SupportedVideoTypes.Contains(ext))
                    {
                        // There is a video file, check for name match
                        string videoFileName = Path.GetFileNameWithoutExtension(file).ToLowerInvariant();
                        if (fileName == videoFileName)
                        {
                            // Same name as the subtitle file. We have a winner.
                            VideoFile = file;
                            return;
                        }
                    }
                }
            }

            VideoFile = string.Empty;
        }

        private void SaveInternal(string file)
        {
            _file = file;
            DoSave();
            LookupVideoFile();
        }

        protected abstract void DoSave();
        protected abstract void DoLoad();


        public static string GenerateRtf(string subText)
        {
            subText = subText
                .Replace("<b>", @"\b ")
                .Replace("</b>", @"\b0")
                .Replace("<i>", @"\i ")
                .Replace("</i>", @"\i0 ")
                .Replace("<u>", @"\ul ")
                .Replace("</u>", @"\ulnone ")
                .Replace("<s>", @"\strike ")
                .Replace("</s>", @"\strike0 ")
                .Replace("\r\n", @"\par ")
                .Replace("\r", @"\par ")
                .Replace("\n", @"\par ")
                ;

            string rtf = subText;// StringUtils.ConvertDiacriticalsToRtfTags(subText);

            return RtfContainerTemplate.Replace("<TEXT>", rtf);
        }
    }
}
