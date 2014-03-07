using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SubtitleEditor.extension.DataLayer
{
    public class SubtitleElement
    {
        public int StartFrames { get; set; }
        public int EndFrames { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<string> Lines { get; set; }
        
        public string RtfDisplay
        {
            get
            {
                return GenerateRtf(Lines);
            }
        }

        protected string GenerateRtf(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in list)
            {
                sb.AppendLine(s);
            }

            return Subtitle.GenerateRtf(sb.ToString());
        }

        public string ContentsForNavigationPanel
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (string line in Lines)
                {
                    sb.Append("[");
                    sb.Append(line);
                    sb.Append("] ");
                }

                return sb.ToString().Trim();
            }
        }

        public SubtitleElement()
        {
            this.StartTime = TimeSpan.MinValue;
            this.EndTime = TimeSpan.MinValue;
            this.StartFrames = 0;
            this.EndFrames = 0;
            this.Lines = new List<string>();
        }
    }
}
