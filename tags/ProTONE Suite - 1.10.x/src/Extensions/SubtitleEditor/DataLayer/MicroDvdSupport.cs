using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OPMedia.Runtime.ProTONE.FileInformation;
using SubtitleEditor.Rendering;

namespace SubtitleEditor.extension.DataLayer
{
    internal sealed class MicroDvdSupport : BaseSubtitleSupport
    {
        string _file = string.Empty;

        internal MicroDvdSupport(Subtitle sub, string file) 
            : base(sub, file)
        {
        }

        protected override void DoLoad(string file)
        {
        }

        protected override void DoSave(string file)
        {
        }

        /*
        internal MicroDvdSubtitle(Subtitle src)
        {
            Elements.Clear();
            foreach (SubtitleElement elem in src.Elements)
            {
                MicroDvdSubtitleElement srElem = new MicroDvdSubtitleElement(elem);
                Elements.Add(srElem);
            }
        }

        protected override void DoSave()
        {
            using (FileStream fs = new FileStream(_file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (SubtitleElement element in _elements)
                {
                    element.SaveElement(sw);
                }
            }
        }

        protected override void DoLoad()
        {
            using (FileStream fs = new FileStream(_file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(fs))
            {
                while (!sr.EndOfStream)
                {
                    try
                    {
                        MicroDvdSubtitleElement element = new MicroDvdSubtitleElement(sr);
                        _elements.Add(element);

                    }
                    catch { }
                }
            }
        }

        protected override void SyncTimeWithFrames()
        {
            VideoFileInfo vfi = MediaRendererInstance.Instance.QueryVideoMediaInfo(VideoFile);
            if (vfi != null && vfi.IsValid)
            {
                double fps = vfi.FrameRate.GetValueOrDefault().Value;
                if (fps > 0)
                {
                    foreach (SubtitleElement se in Elements)
                    {
                        se.StartTime = TimeSpan.FromSeconds( se.StartFrames / fps );
                        se.EndTime = TimeSpan.FromSeconds( se.EndFrames / fps );
                    }
                }
            }
        }
        */
    }
    /*
    public class MicroDvdSubtitleElement : SubtitleElement
    {
        public MicroDvdSubtitleElement(SubtitleElement se)
            : base(se)
        {
        }

        public MicroDvdSubtitleElement(StreamReader sr)
            : base(sr)
        {
        }

        protected override void DoReadFromStream(StreamReader sr)
        {
            string s = sr.ReadLine();
            ProcessLine(s);
        }

        private void ProcessLine(string s)
        {
            string[] fields = s.Replace("}", "{").Split("{".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (fields.Length > 2)
            {
                StartFrames = int.Parse(fields[0]);
                EndFrames = int.Parse(fields[1]);

                string start = string.Format("{{{0}}}{{{1}}}", fields[0], fields[1]);
                string content = s.Replace(start, "");
                ParseContent(content);
            }
        }

        private void ParseContent(string content)
        {
            string[] lines = content.Split("|".ToCharArray());

            string appendToContent = "";

            StringBuilder sb = new StringBuilder();

            foreach (string line in lines)
            {
                sb.Append(ParseLine(line, ref appendToContent));
                sb.Append("|");
            }

            if (!string.IsNullOrEmpty(appendToContent))
            {
                sb.Append(appendToContent);
            }

            Lines.AddRange(sb.ToString().Trim("|".ToCharArray()).Split("|".ToCharArray()));
        }

        private string ParseLine(string line, ref string appendToContent)
        {
            string[] fields = line.Replace("}", "{").Split("{".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string prefix = "";
            string suffix = "";

            for (int i = 0; i < fields.Length - 1; i++)
            {
                ParseControlCode(fields[i], ref prefix, ref suffix, ref appendToContent);
            }

            // Last field is the text itself, other fields are control codes
            return prefix + fields[fields.Length - 1] + suffix;
        }

        private void ParseControlCode(string p, ref string prefix, ref string lineSuffix, ref string contentSuffix)
        {
            if (p.Length < 3 || p[1] != ':')
                return; // invalid control code

            char code = p[0];
            string control = p.Substring(2);

            switch (code)
            {
                case 'y':
                    prefix += BuildFontFormatters(control);
                    lineSuffix += prefix.Replace("<", "</");
                    break;

                case 'Y':
                    prefix += BuildFontFormatters(control);
                    contentSuffix += prefix.Replace("<", "</");
                    break;

                case 'c':
                case 'C':
                case 's':
                case 'S':
                case 'f':
                case 'F':
                case 'p':
                case 'P':
                case 'h':
                case 'H':
                    // These are all valid codes but we ignore them for now ...
                    break;
            }
        }

        private string BuildFontFormatters(string control)
        {
            string retVal = "";

            if (control.Contains("i"))
            {
                retVal += "<i>";
            }
            if (control.Contains("b"))
            {
                retVal += "<b>";
            }
            if (control.Contains("u"))
            {
                retVal += "<u>";
            }
            if (control.Contains("s"))
            {
                retVal += "<s>";
            }
            return retVal;
        }

        protected override void DoWriteToStream(StreamWriter sw)
        {
            //string start = StartTime.ToString(SubtitleBase.TimeDisplayFormat);
            //string end = EndTime.ToString(SubtitleBase.TimeDisplayFormat);
            //string timeLine = string.Format("{0} --> {1}", start, end);
            //sw.WriteLine(timeLine);
            //sw.Write(Lines);

            sw.Write(string.Format("{{{0}}}{{{1}}}", StartFrames, EndFrames));

            StringBuilder sb = new StringBuilder();
            foreach(string line in Lines)
            {
                sb.Append(line);
                sb.Append("|");
            }

            string content = sb.ToString().Trim("|".ToCharArray());
            content = content.Replace("</i>", "").Replace("</b>", "").Replace("</s>", "").Replace("</u>", "");
            content = content.Replace("<i>", "{y:i}").Replace("<b>", "{y:b}").Replace("<s>", "{y:s}").Replace("<u>", "{y:u}");

            sw.WriteLine(content);
        }
    }*/
}
