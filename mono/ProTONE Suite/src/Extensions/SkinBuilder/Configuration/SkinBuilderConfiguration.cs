using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Core.Configuration;

namespace OPMedia.SkinBuilder.Configuration
{
    public class SkinBuilderConfiguration 
    {
        public static string LastOpenedFolder
        {
            get
            {
                return ConfigFileManager.Default.GetValue("LastOpenedFolder", string.Empty);
            }
            set
            {
                ConfigFileManager.Default.SetValue("LastOpenedFolder", value);
            }
        }

        public static bool OpenLastFile
        {
            get
            {
                return ConfigFileManager.Default.GetValue("OpenLastFile", false);
            }
            set
            {
                ConfigFileManager.Default.SetValue("OpenLastFile", value);
            }
        }

        public static bool RememberRecentFiles
        {
            get
            {
                return ConfigFileManager.Default.GetValue("RememberRecentFiles", false);
            }
            set
            {
                ConfigFileManager.Default.SetValue("RememberRecentFiles", value);
            }
        }

        public static int RecentFilesCount
        {
            get
            {
                return ConfigFileManager.Default.GetValue("RecentFilesCount", 5);
            }
            set
            {
                ConfigFileManager.Default.SetValue("RecentFilesCount", value);
            }
        }

        public static string RecentFiles
        {
            get
            {
                return ConfigFileManager.Default.GetValue("RecentFiles", string.Empty);
            }
            set
            {
                ConfigFileManager.Default.SetValue("RecentFiles", value);
            }
        }
    }
}
