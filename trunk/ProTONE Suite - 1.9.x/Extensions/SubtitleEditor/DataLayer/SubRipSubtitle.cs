using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OPMedia.Core.Utilities;
using System.Windows.Forms;

namespace SubtitleEditor.extension.DataLayer
{
    internal sealed class SubRipSubtitle : SubtitleBase
    {
        internal SubRipSubtitle(string file)
            : base(file)
        {
        }

        internal SubRipSubtitle(SubtitleBase src)
            : base(src)
        {
        }


        protected override void DoSave()
        {
            using (FileStream fs = new FileStream(_file, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
            {
                int i = 1;

                foreach (SubtitleElement element in _elements)
                {
                    sw.WriteLine(i++);
                    element.SaveElement(sw);
                    sw.WriteLine();
                }
            }
        }

        protected override void DoLoad()
        {
            using (FileStream fs = new FileStream(_file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(fs, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    try
                    {
                        SubRipSubtitleElement element = new SubRipSubtitleElement(sr);
                        _elements.Add(element);

                    }
                    catch { }
                }
            }
        }
    }

    public class SubRipSubtitleElement : SubtitleElement
    {
        int lineIndex = 0;

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
            string start = StartTime.ToString(SubtitleBase.TimeDisplayFormat);
            string end = EndTime.ToString(SubtitleBase.TimeDisplayFormat);
            string timeLine = string.Format("{0} --> {1}", start, end);
            sw.WriteLine(timeLine);
            sw.Write(Lines);
        }

        protected override string BuildRtfDisplay()
        {
            return GenerateRtf(Lines);
        }

        protected override void SetRtfDisplay(string value)
        {
            string txt = value.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
            int index = txt.IndexOf(@"\fs24");
            txt = txt.Substring(index + 5).TrimEnd('}');
            txt = txt.Replace(@"\lang1048", "");
            txt = txt.Replace(@"\lang1033", "");
            txt = txt.Replace(@"\f0", "").Replace(@"\f1", "").Replace(@"\f2", "");
            txt = txt.Replace(@"\par", "\n").Trim().Trim('\n');

            txt = StringUtils.ConvertRtfTagsToDiacriticals(txt);

            
        }

        private string GenerateRtf(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in list)
            {
                sb.AppendLine(s);
            }

            return GenerateRtf(sb.ToString());
        }

        const string RtfContainerTemplate =
            @"{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fnil\fcharset238 Arial;}}\viewkind4\uc1\pard\lang1033\fs24 \f1 <TEXT>}";


        private string GenerateRtf(string subText)
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
