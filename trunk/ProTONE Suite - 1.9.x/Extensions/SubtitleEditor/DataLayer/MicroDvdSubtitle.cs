using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SubtitleEditor.extension.DataLayer
{
    internal sealed class MicroDvdSubtitle : SubtitleBase
    {
        internal MicroDvdSubtitle(string file)
            : base(file)
        {
        }
        
        internal MicroDvdSubtitle(SubtitleBase src)
            : base(src)
        {
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
    }

    public class MicroDvdSubtitleElement : SubtitleElement
    {
        public MicroDvdSubtitleElement(StreamReader sr)
            : base(sr)
        {
        }

        protected override void DoReadFromStream(StreamReader sr)
        {
        }

        protected override void DoWriteToStream(StreamWriter sw)
        {
        }

        protected override string BuildRtfDisplay()
        {
            return "";
        }

    }
}
