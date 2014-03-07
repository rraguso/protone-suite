using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using OPMedia.Runtime.TranslationSupport;

namespace OPMedia.Runtime.DisplayAdapterInformation
{
    public partial class MonitorInfo
    {
        public string Name { get; protected set; }
        public bool IsPrimary { get; protected set; }
        public Size Resolution { get; protected set; }
        public Rectangle WorkingArea { get; protected set; }

        private bool isFakeDevice = true;

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            MonitorInfo mi = obj as MonitorInfo;
            if (mi != null)
            {
                return this.Name.Equals(mi.Name);
            }

            return false;
        }

        public override string ToString()
        {
            if (isFakeDevice)
                return Name;

            string str = string.Format("{0} [{1}x{2}]", Name, Resolution.Width, Resolution.Height);
            if (IsPrimary)
            {
                str += Translator.Translate("TXT_PRIMARY_MONITOR");
            }

            return str;
        }

        public MonitorInfo(string name)
        {
            this.Name = name;
            this.WorkingArea = new Rectangle(0, 0, 1, 1);
            this.Resolution = new Size(1, 1);
            this.IsPrimary = false;

            isFakeDevice = true;
        }

        public MonitorInfo(Screen scr)
        {
            string[] fields = scr.DeviceName.Split(new char[] {'\\', '\0', '.'}, StringSplitOptions.RemoveEmptyEntries);
            if (fields == null || fields.Length < 1)
                throw new ArgumentException("Could not identify the display name", "scr");

            this.Name = fields[0];
            this.WorkingArea = scr.WorkingArea;
            this.Resolution = scr.Bounds.Size;
            this.IsPrimary = scr.Primary;

            isFakeDevice = false;
        }
    }
}
