using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPMedia.Core
{
    public class EventNames
    {
        public const string PerformTranslation =    "PerformTranslation";
        public const string ExecuteShortcut =       "ExecuteShortcut";
        public const string KeymapChanged =         "KeymapChanged";
        public const string ShowMessageBox =        "ShowMessageBox";

        public const string SetMainStatusBar =      "SetMainStatusBar";

        public const string NewVersionAvailable =   "NewVersionAvailable";
        public const string CheckForUpdates =       "CheckForUpdates";

        public const string RefreshItems =          "RefreshItems";

        /// <summary>
        /// Event fired by Theme Manager after it has updated the theme
        /// </summary>
        public const string ThemeUpdated =           "ThemeUpdated";
    }
}
