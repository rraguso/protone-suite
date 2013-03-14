using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OPMedia.Core.Utilities;
using System.Windows.Forms;
using OPMedia.Runtime.ProTONE.FileInformation;
using SubtitleEditor.Rendering;

namespace SubtitleEditor.extension.DataLayer
{
    internal sealed class SubRipSupport : BaseSubtitleSupport
    {
        internal SubRipSupport(Subtitle sub, string file)
            : base(sub, file)
        {
        }

        protected override void DoLoad(string file)
        {
             using (FileStream fs = new FileStream(_file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
             using (StreamReader sr = new StreamReader(fs, Encoding.Default))
             {
                 while (!sr.EndOfStream)
                 {
                     lineIndex = 0;
                     SubtitleElement se = new SubtitleElement();
                     _sub.Elements.Add(se);

                     try
                     {
                         for (; ; )
                         {
                             try
                             {
                                 string s = sr.ReadLine();
                                 if (ProcessLine(se, s))
                                     break;
                             }
                             catch (IOException)
                             {
                                 break;
                             }
                         }
                     }
                     catch 
                     { 
                     }
                 }
             }
        }

        int lineIndex = 0;

        private bool ProcessLine(SubtitleElement se, string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            if (lineIndex == 0)
            {
                // Subtitles are numbered sequentially, starting at 1
                // If not, format is invalid
                int i = int.Parse(s);
            }
            else if (lineIndex == 1)
            {
                // The time format used is hours:minutes:seconds,milliseconds

                s = s.Replace("-->", "|");
                string[] fields = s.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (fields.Length != 2)
                    throw new FormatException();

                se.StartTime = TimeSpan.Parse(fields[0].Trim().Replace(",", "."));
                se.EndTime = TimeSpan.Parse(fields[1].Trim().Replace(",", "."));

                if (_sub.VideoFileInfo != null && _sub.VideoFileInfo.IsValid)
                {
                    double fps = _sub.VideoFileInfo.FrameRate.GetValueOrDefault().Value;
                    se.StartFrames = (int)(fps * se.StartTime.TotalSeconds);
                    se.EndFrames = (int)(fps * se.EndTime.TotalSeconds);
                }
            }
            else if (lineIndex > 1)
            {
                se.Lines.Add(s);
            }

            lineIndex++;
            return false;
        }

        protected override void DoSave(string file)
        {
            using (FileStream fs = new FileStream(_file, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
            {
                int i = 1;

                foreach (SubtitleElement se in _sub.Elements)
                {
                    sw.WriteLine(i++);

                    string start = se.StartTime.ToString(Subtitle.TimeDisplayFormat.Replace(".fff", ",fff"));
                    string end = se.EndTime.ToString(Subtitle.TimeDisplayFormat.Replace(".fff", ",fff"));
                    string timeLine = string.Format("{0} --> {1}", start, end);
                    sw.WriteLine(timeLine);
                    foreach (string line in se.Lines)
                    {
                        sw.WriteLine(line);
                    }
                    sw.WriteLine();
                }
            }
        }

        //internal SubRipSupport(Subtitle src)
        //{
        //    Elements.Clear();
        //    foreach (SubtitleElement elem in src.Elements)
        //    {
        //        SubRipSubtitleElement srElem = new SubRipSubtitleElement(elem);
        //        Elements.Add(srElem);
        //    }
        //}
        
        //protected override void DoSave()
        //{
        //    using (FileStream fs = new FileStream(_file, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
        //    using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
        //    {
        //        int i = 1;

        //        foreach (SubtitleElement element in _elements)
        //        {
        //            sw.WriteLine(i++);
        //            element.SaveElement(sw);
        //            sw.WriteLine();
        //        }
        //    }
        //}

        //protected override void DoLoad()
        //{
        //    using (FileStream fs = new FileStream(_file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        //    using (StreamReader sr = new StreamReader(fs, Encoding.Default))
        //    {
        //        while (!sr.EndOfStream)
        //        {
        //            try
        //            {
        //                SubRipSubtitleElement element = new SubRipSubtitleElement(sr);
        //                _elements.Add(element);

        //            }
        //            catch { }
        //        }
        //    }
        //}

        //protected override void SyncTimeWithFrames()
        //{
        //    VideoFileInfo vfi = MediaRendererInstance.Instance.QueryVideoMediaInfo(VideoFile);
        //    if (vfi != null && vfi.IsValid)
        //    {
        //        double fps = vfi.FrameRate.GetValueOrDefault().Value;

        //        foreach (SubtitleElement se in Elements)
        //        {
        //            se.StartFrames = (int)(fps * se.StartTime.TotalSeconds);
        //            se.EndFrames = (int)(fps * se.EndTime.TotalSeconds);
        //        }
        //    }
        //}

    }
    /*
    public class SubRipSubtitleElement : SubtitleElement
    {
        int lineIndex = 0;

        public SubRipSubtitleElement(SubtitleElement se)
            : base(se)
        {
        }

        public SubRipSubtitleElement(StreamReader sr)
            : base(sr)
        {
        }

        protected override void DoReadFromStream(StreamReader sr)
        {
            for(;;)
            {
                try
                {
                    string s = sr.ReadLine();
                    if (ProcessLine(s))
                        break;
                }
                catch (IOException)
                {
                    break;
                }
            }
        }

        private bool ProcessLine(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            if (lineIndex == 0)
            {
                // Subtitles are numbered sequentially, starting at 1
                // If not, format is invalid
                int i = int.Parse(s);
            }
            else if (lineIndex == 1)
            {
                // The time format used is hours:minutes:seconds,milliseconds

                s = s.Replace("-->", "|");
                string[] fields = s.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (fields.Length != 2)
                    throw new FormatException();

                StartTime = TimeSpan.Parse(fields[0].Trim().Replace(",", "."));
                EndTime = TimeSpan.Parse(fields[1].Trim().Replace(",", "."));
            }
            else if (lineIndex > 1)
            {
                Lines.Add(s);
            }

            lineIndex++;
            return false;
        }

        protected override void DoWriteToStream(StreamWriter sw)
        {
            string start = StartTime.ToString(Subtitle.TimeDisplayFormat);
            string end = EndTime.ToString(Subtitle.TimeDisplayFormat);
            string timeLine = string.Format("{0} --> {1}", start, end);
            sw.WriteLine(timeLine);
            sw.Write(Lines);
        }

       

        
    }*/
}
