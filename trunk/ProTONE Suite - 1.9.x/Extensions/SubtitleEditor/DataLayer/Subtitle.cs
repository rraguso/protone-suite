using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Core;
using System.IO;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Runtime.ProTONE.FileInformation;
using SubtitleEditor.Rendering;

namespace SubtitleEditor.extension.DataLayer
{
    public class Subtitle
    {
        public static Subtitle Empty = new Subtitle();

        public const string TimeDisplayFormat = @"hh\:mm\:ss\.fff";
        public const string RtfContainerTemplate =
            @"{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fnil\fcharset238 Arial;}}{\colortbl;\red255\green255\blue255;}\viewkind4\uc1\pard\lang1033\fs24\f1\cf1 <TEXT>}";


        protected List<SubtitleElement> _elements = new List<SubtitleElement>();

        public string File { get; protected set; }

        public VideoFileInfo VideoFileInfo { get; private set; }

        public List<SubtitleElement> Elements
        {
            get
            {
                return _elements;
            }
        }

        public bool IsEmpty 
        {
            get
            {
                return (string.IsNullOrEmpty(File));

            }
        }

        protected Subtitle()
        {
            File = string.Empty;
        }

        public Subtitle(string file) : this()
        {
            File = file;
            LookupVideoFile();
            LoadFromFile(File);
        }

        public void LoadFromFile(string path)
        {
            string ext = PathUtils.GetExtension(path).ToLowerInvariant();
            switch (ext)
            {
                case "sub":
                    new MicroDvdSupport(this, path).Load();
                    break;

                case "srt":
                    new SubRipSupport(this, path).Load();
                    break;
            }
        }

        public void SaveToFile(string path)
        {
            string ext = PathUtils.GetExtension(path).ToLowerInvariant();
            switch (ext)
            {
                case "sub":
                    new MicroDvdSupport(this, path).Save();
                    break;

                case "srt":
                    new SubRipSupport(this, path).Save();
                    break;
            }
        }

        public void Save()
        {
            SaveToFile(File);
        }
       
        private void LookupVideoFile()
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(File).ToLowerInvariant();

                string folder = Path.GetDirectoryName(File);
                IEnumerable<String> files = Directory.EnumerateFiles(folder);
                if (files != null && files.Count() > 0)
                {
                    foreach (string file in files)
                    {
                        if (file.ToLowerInvariant() == File.ToLowerInvariant())
                            continue; // same file as the subtitle, not interesting

                        string ext = PathUtils.GetExtension(file);
                        if (MediaRenderer.SupportedVideoTypes.Contains(ext))
                        {
                            // There is a video file, check for name match
                            string videoFileName = Path.GetFileNameWithoutExtension(file).ToLowerInvariant();
                            if (fileName == videoFileName)
                            {
                                // Same name as the subtitle file. We have a winner.
                                VideoFileInfo = MediaRendererInstance.Instance.QueryVideoMediaInfo(file);
                                return;
                            }
                        }
                    }
                }
            }
            catch
            {
            }

            VideoFileInfo = null;
        }

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
