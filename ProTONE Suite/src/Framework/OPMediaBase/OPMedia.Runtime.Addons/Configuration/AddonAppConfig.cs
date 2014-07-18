using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Core.Configuration;
using System.Windows.Forms;

namespace OPMedia.Runtime.Addons.Configuration
{
    public static class AddonAppConfig
    {
        public static int VSplitterDistance
        {
            get
            {
                return ConfigFileManager.Default.GetValue("VSplitterDistance",
                    4 * Screen.PrimaryScreen.Bounds.Width / 9);
            }

            set
            {
                ConfigFileManager.Default.SetValue("VSplitterDistance", value);
            }
        }

        public static int HSplitterDistance
        {
            get
            {
                return ConfigFileManager.Default.GetValue("HSplitterDistance",
                    Screen.PrimaryScreen.Bounds.Height / 3 - 50);
            }

            set
            {
                ConfigFileManager.Default.SetValue("HSplitterDistance", value);
            }
        }

        public static string LastNavAddon
        {
            get
            {
                return ConfigFileManager.Default.GetValue("LastNavAddon", "FileExplorer");
            }

            set
            {
                ConfigFileManager.Default.SetValue("LastNavAddon", value);
            }
        }

        public static int MaxProcessedEntries
        {
            get { return ConfigFileManager.Default.GetValue("MaxProcessedEntries", 100); }
            set { ConfigFileManager.Default.SetValue("MaxProcessedEntries", value); }
        }
    }
}
