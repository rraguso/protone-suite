using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Runtime.Addons;
using OPMedia.Runtime.Addons.ApplicationSettings;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Runtime.ProTONE.ApplicationSettings;
using System.ComponentModel;

namespace OPMedia.Addons.Builtin.ApplicationSettings
{
    public static class BuiltinAddonSettings
    {
        public static string SearchPaths
        {
            get
            {
                return ConfigFileManager.Default.GetValue("SearchPaths", string.Empty);
            }

            set
            {
                ConfigFileManager.Default.SetValue("SearchPaths", value);
            }
        }

        public static string SearchTexts
        {
            get
            {
                return ConfigFileManager.Default.GetValue("SearchTexts", string.Empty);
            }

            set
            {
                ConfigFileManager.Default.SetValue("SearchTexts", value);
            }
        }

        public static string SearchPatterns
        {
            get
            {
                return ConfigFileManager.Default.GetValue("SearchPatterns", string.Empty);
            }

            set
            {
                ConfigFileManager.Default.SetValue("SearchPatterns", value);
            }
        }


        public static string SearchTextsMC
        {
            get
            {
                return ConfigFileManager.Default.GetValue("SearchTextsMC", string.Empty);
            }

            set
            {
                ConfigFileManager.Default.SetValue("SearchTextsMC", value);
            }
        }

        public static string SearchPatternsMC
        {
            get
            {
                return ConfigFileManager.Default.GetValue("SearchPatternsMC", string.Empty);
            }

            set
            {
                ConfigFileManager.Default.SetValue("SearchPatternsMC", value);
            }
        }

        public static int SplitterDistanceMC
        {
            get
            {
                return ConfigFileManager.Default.GetValue("SplitterDistanceMC", 200);
            }

            set
            {
                ConfigFileManager.Default.SetValue("SplitterDistanceMC", value);
            }
        }

        public static decimal FEPreviewTimer
        {
            get
            {
                try
                {
                    return (decimal)new DecimalConverter().ConvertFromInvariantString(
                    ConfigFileManager.Default.GetValue("FEPreviewTimer",
                        new DecimalConverter().ConvertToInvariantString(0.5M)));
                }
                catch { }

                return 0.5M;
            }

            set
            {
                ConfigFileManager.Default.SetValue("FEPreviewTimer",
                    new DecimalConverter().ConvertToInvariantString(value));
            }
        }

        public static string MCLastOpenedFolder
        {
            get
            {
                return ConfigFileManager.Default.GetValue("MCLastOpenedFolder", string.Empty);
            }
            set
            {
                ConfigFileManager.Default.SetValue("MCLastOpenedFolder", value);
            }
        }

        public static bool MCOpenLastCatalog
        {
            get
            {
                return ConfigFileManager.Default.GetValue("MCOpenLastCatalog", false);
            }
            set
            {
                ConfigFileManager.Default.SetValue("MCOpenLastCatalog", value);
            }
        }

        public static bool MCRememberRecentFiles
        {
            get
            {
                return ConfigFileManager.Default.GetValue("MCRememberRecentFiles", false);
            }
            set
            {
                ConfigFileManager.Default.SetValue("MCRememberRecentFiles", value);
            }
        }

        public static int MCRecentFilesCount
        {
            get
            {
                return ConfigFileManager.Default.GetValue("MCRecentFilesCount", 5);
            }
            set
            {
                ConfigFileManager.Default.SetValue("MCRecentFilesCount", value);
            }
        }

        public static string MCRecentFiles
        {
            get
            {
                return ConfigFileManager.Default.GetValue("MCRecentFiles", string.Empty);
            }
            set
            {
                ConfigFileManager.Default.SetValue("MCRecentFiles", value);
            }
        }

    }
}
