using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SubtitleEditor.extension.DataLayer
{
    public abstract class SubtitleElement
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
                return BuildRtfDisplay();
            }
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

        public SubtitleElement(StreamReader stream)
        {
            StartTime = EndTime = TimeSpan.MinValue;
            StartFrames = EndFrames = 0;
            Lines = new List<string>();

            DoReadFromStream(stream);
        }

        public void SaveElement(StreamWriter stream)
        {
            DoWriteToStream(stream);
        }
        
        protected abstract void DoReadFromStream(StreamReader sr);
        protected abstract void DoWriteToStream(StreamWriter sr);
        protected abstract string BuildRtfDisplay();
    }
}
