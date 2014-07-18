﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Core.ApplicationSettings;
using System.ServiceProcess;
using OPMedia.Core;
using System.IO;
using OPMedia.Core.Utilities;
using Microsoft.Win32;
using System.Drawing;

namespace OPMedia.Runtime.ProTONE.ApplicationSettings
{
    public enum CddaInfoSource
    {
        // Don't read audio cd info
        None = 0,
        // Read CD-text only
        CdText,
        // Read CDDB only
        Cddb,
        // Try CD-text first then CDDB [Default]
        CdText_Cddb,
        // Try CDDB first then CD-text
        Cddb_CdText
    }

    [Flags]
    public enum MediaScreen
    {
        None = 0x00,

        Playlist = 0x01,
        TrackInfo = 0x02,
        SignalAnalisys = 0x04,
        BookmarkInfo = 0x08,

        All = 0xFF
    }

    [Flags]
    public enum SignalAnalisysFunction
    {
        None = 0x00,

        VUMeter = 0x01,
        Waveform = 0x02,
        Spectrogram = 0x04,

        All = 0xFF
    }

    public static class ProTONEAppSettings
    {
        #region RCC Service API (Calculated Level 2 settings)
        public static bool IsRCCServiceInstalled
        {
            get
            {
                try
                {
                    ServiceController sc = new ServiceController(Constants.RCCServiceShortName);
                    ServiceControllerStatus scs = sc.Status;
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static string RCCManagerInstallationPath
        {
            get
            {
                return Path.Combine(SuiteConfiguration.InstallationPath, Constants.RCCManagerBinary);
            }
        }

        public static string RCCServiceInstallationPath
        {
            get
            {
                return Path.Combine(SuiteConfiguration.InstallationPath, Constants.RCCServiceBinary);
            }
        }
        #endregion

        #region Level 2 Settings using Persistence Service (Per-suite settings)

        public static CddaInfoSource AudioCdInfoSource
        {
            get { return PersistenceProxy.ReadObject("AudioCdInfoSource", CddaInfoSource.CdText_Cddb); }
            set { PersistenceProxy.SaveObject("AudioCdInfoSource", value); }
        }

        public static string CddbServerName
        {
            get { return PersistenceProxy.ReadObject("CddbServerName", "freedb.freedb.org"); }
            set { PersistenceProxy.SaveObject("CddbServerName", value); }
        }

        public static int CddbServerPort
        {
            get { return PersistenceProxy.ReadObject("CddbServerPort", 8880); }
            set { PersistenceProxy.SaveObject("CddbServerPort", value); }
        }

        #endregion

        #region Level 2 Settings using Registry (Per-user settings)

        public static string DefaultSubtitleURIs
        {
            get
            {
                return @"BSP_V1;http://api.bsplayer-subtitles.com/v1.php;1\Osdb;http://api.opensubtitles.org/xml-rpc;1\NuSoap;http://api.getsubtitle.com/server.php;0";
            }
        }

        private static List<string> __favoriteFolders = null;

        public static List<string> GetFavoriteFolders(string favFoldersHiveName)
        {
            if (__favoriteFolders == null)
            {
                __favoriteFolders = new List<string>();

                using (RegistryKey key = Registry.CurrentUser.Emu_CreateSubKey(SuiteConfiguration.ConfigRegPath))
                {
                    if (key != null)
                    {
                        string str = key.GetValue(favFoldersHiveName, string.Empty) as string;
                        if (!string.IsNullOrEmpty(str))
                        {
                            string[] favFolders = StringUtils.ToStringArray(str, '?');
                            __favoriteFolders.AddRange(favFolders);
                        }
                    }
                }
            }

            return __favoriteFolders;
        }

        public static void SetFavoriteFolders(List<string> folders, string favFoldersHiveName)
        {
            __favoriteFolders.Clear();
            __favoriteFolders.AddRange(folders);

            using (RegistryKey key = Registry.CurrentUser.Emu_CreateSubKey(SuiteConfiguration.ConfigRegPath))
            {
                if (key != null)
                {
                    string favFolders = StringUtils.FromStringArray(__favoriteFolders.ToArray(), '?');
                    if (favFolders == null)
                        favFolders = string.Empty;

                    key.SetValue(favFoldersHiveName, favFolders);
                }
            }
        }


        public static bool UseLinkedFiles
        {
            get { return (PersistenceProxy.ReadObject("UseLinkedFiles", 1) != 0); }
            set { PersistenceProxy.SaveObject("UseLinkedFiles", value ? 1 : 0); }
        }

        static Dictionary<string, string> _table = null;
        public static Dictionary<string, string> LinkedFilesTable
        {
            get
            {
                _table = new Dictionary<string, string>();

                try
                {
                    using (RegistryKey key = Registry.CurrentUser.Emu_CreateSubKey(SuiteConfiguration.ConfigRegPath))
                    {
                        if (key != null)
                        {
                            string st = key.GetValue("LinkedFiles", string.Empty) as string;
                            string[] pairs = StringUtils.ToStringArray(st, '\\');
                            if (pairs != null && pairs.Length > 0)
                            {
                                foreach (string pair in pairs)
                                {
                                    string[] nameValue = StringUtils.ToStringArray(pair, '/');
                                    if (nameValue != null && nameValue.Length > 0)
                                    {
                                        string name = nameValue[0];
                                        string value = nameValue.Length > 1 ? nameValue[1] : string.Empty;

                                        try
                                        {
                                            _table.Add(name, value);
                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                }

                return _table;
            }

            set
            {
                try
                {
                    if (value != null)
                    {
                        string str = string.Empty;
                        foreach (KeyValuePair<string, string> kvp in value)
                        {
                            str += kvp.Key;
                            str += "/";
                            str += kvp.Value;
                            str += "\\";
                        }

                        str = str.Trim('\\').Trim('/');

                        using (RegistryKey key = Registry.CurrentUser.Emu_CreateSubKey(SuiteConfiguration.ConfigRegPath))
                        {
                            if (key != null)
                            {
                                key.SetValue("LinkedFiles", str);
                            }
                        }
                    }

                    _table = value;
                }
                catch
                {
                }
            }
        }

        public static string[] GetChildFileTypes(string fileType)
        {
            if (_table == null)
                _table = LinkedFilesTable;

            foreach (KeyValuePair<string, string> kvp in _table)
            {
                List<string> types = new List<string>(StringUtils.ToStringArray(kvp.Key, ';'));
                if (types.Contains(fileType.ToUpperInvariant()))
                {
                    return StringUtils.ToStringArray(kvp.Value, ';');
                }
            }

            return null;
        }

        public static string[] GetParentFileTypes(string fileType)
        {
            foreach (KeyValuePair<string, string> kvp in _table)
            {
                List<string> types = new List<string>(StringUtils.ToStringArray(kvp.Value, ';'));
                if (types.Contains(fileType.ToUpperInvariant()))
                {
                    return StringUtils.ToStringArray(kvp.Key, ';');
                }
            }

            return null;
        }
        #endregion

        #region Level 2 Settings using Settings File (Combined per-app and per-user settings)

        public static string SubtitleDownloadURIs
        {
            get { return ConfigFileManager.Default.GetValue("SubtitleDownloadURIs", DefaultSubtitleURIs); }
            set { ConfigFileManager.Default.GetValue("SubtitleDownloadURIs", value); }
        }

        public static MediaScreen ShowMediaScreens
        {
            get { return (MediaScreen)ConfigFileManager.Default.GetValue("ShowMediaScreens", (int)MediaScreen.All); }
            set { ConfigFileManager.Default.SetValue("ShowMediaScreens", (int)value); }
        }

        public static SignalAnalisysFunction SignalAnalisysFunctions
        {
            get { return (SignalAnalisysFunction)ConfigFileManager.Default.GetValue("SignalAnalisysFunctions", (int)SignalAnalisysFunction.All); }
            set { ConfigFileManager.Default.SetValue("SignalAnalisysFunctions", (int)value); }
        }


        public static string ExplorerLaunchType
        {
            get
            {
                return ConfigFileManager.Default.GetValue("ExplorerLaunchType", "EnqueueFiles");
            }

            set
            {
                ConfigFileManager.Default.SetValue("ExplorerLaunchType", value);
            }
        }

        public static int LastBalance
        {
            get
            {
                return ConfigFileManager.Default.GetValue("LastBalance", 0);
            }

            set
            {
                ConfigFileManager.Default.SetValue("LastBalance", value);
            }
        }

        public static int LastVolume
        {
            get
            {
                return ConfigFileManager.Default.GetValue("LastVolume", 5000);
            }

            set
            {
                ConfigFileManager.Default.SetValue("LastVolume", value);
            }
        }

        public static int LastFilterIndex
        {
            get
            {
                return ConfigFileManager.Default.GetValue("LastFilterIndex", 0);
            }

            set
            {
                ConfigFileManager.Default.SetValue("LastFilterIndex", value);
            }
        }

        public static string LastOpenedFolder
        {
            get
            {
                return ConfigFileManager.Default.GetValue("LastOpenedFolder", PathUtils.CurrentDir);
            }

            set
            {
                ConfigFileManager.Default.SetValue("LastOpenedFolder", value);
            }
        }

        public static int PL_LastFilterIndex
        {
            get
            {
                return ConfigFileManager.Default.GetValue("PL_LastFilterIndex", 0);
            }

            set
            {
                ConfigFileManager.Default.SetValue("PL_LastFilterIndex", value);
            }
        }

        public static string PL_LastOpenedFolder
        {
            get
            {
                return ConfigFileManager.Default.GetValue("PL_LastOpenedFolder", PathUtils.CurrentDir);
            }

            set
            {
                ConfigFileManager.Default.SetValue("PL_LastOpenedFolder", value);
            }
        }



        public static bool LoopPlay
        {
            get
            {
                return ConfigFileManager.Default.GetValue("LoopPlay", false);
            }

            set
            {
                ConfigFileManager.Default.SetValue("LoopPlay", value);
            }
        }

        public static bool ShufflePlaylist
        {
            get
            {
                return ConfigFileManager.Default.GetValue("ShufflePlaylist", true);
            }

            set
            {
                ConfigFileManager.Default.SetValue("ShufflePlaylist", value);
            }
        }

        public static int PlaylistEventHandler
        {
            get
            {
                return ConfigFileManager.Default.GetValue("PlaylistEventHandler", 0);
            }
            set
            {
                ConfigFileManager.Default.SetValue("PlaylistEventHandler", value);
            }
        }

        public static string PlaylistEventData
        {
            get
            {
                return ConfigFileManager.Default.GetValue("PlaylistEventData", string.Empty);
            }
            set
            {
                ConfigFileManager.Default.SetValue("PlaylistEventData", value);
            }
        }


        public static int ScheduledEventHandler
        {
            get
            {
                return ConfigFileManager.Default.GetValue("ScheduledEventHandler", 0);
            }
            set
            {
                ConfigFileManager.Default.SetValue("ScheduledEventHandler", value);
            }
        }

        public static string ScheduledEventData
        {
            get
            {
                return ConfigFileManager.Default.GetValue("ScheduledEventData", string.Empty);
            }
            set
            {
                ConfigFileManager.Default.SetValue("ScheduledEventData", value);
            }
        }

        public static TimeSpan ScheduledEventTime
        {
            get
            {
                return ConfigFileManager.Default.GetValue("ScheduledEventTime", new TimeSpan(0, 0, 0));
            }
            set
            {
                ConfigFileManager.Default.SetValue("ScheduledEventTime", value);
            }
        }

        public static int ScheduledEventDays
        {
            get
            {
                return ConfigFileManager.Default.GetValue("ScheduledEventDays", 0);
            }
            set
            {
                ConfigFileManager.Default.SetValue("ScheduledEventDays", value);
            }
        }

        public static bool EnableScheduledEvent
        {
            get
            {
                return ConfigFileManager.Default.GetValue("EnableScheduledEvent", false);
            }
            set
            {
                ConfigFileManager.Default.SetValue("EnableScheduledEvent", value);
            }
        }

        public static int SchedulerWaitTimerProceed
        {
            get
            {
                return ConfigFileManager.Default.GetValue("SchedulerWaitTimerProceed", 2);
            }
            set
            {
                ConfigFileManager.Default.SetValue("SchedulerWaitTimerProceed", value);
            }
        }

        public static bool DisableDVDMenu
        {
            get { return ConfigFileManager.Default.GetValue("DisableDVDMenu", false); }
            set { ConfigFileManager.Default.SetValue("DisableDVDMenu", value); }
        }

        public static int PrefferedSubtitleLang
        {
            get { return ConfigFileManager.Default.GetValue("PrefferedSubtitleLang", 1033); }
            set { ConfigFileManager.Default.SetValue("PrefferedSubtitleLang", value); }
        }

        public static bool SubEnabled
        {
            get { return ConfigFileManager.Default.GetValue("SubEnabled", false); }
            set { ConfigFileManager.Default.SetValue("SubEnabled", value); }
        }

        public static bool OsdEnabled
        {
            get { return ConfigFileManager.Default.GetValue("OsdEnabled", false); }
            set { ConfigFileManager.Default.SetValue("OsdEnabled", value); }
        }

        public static Color OsdColor
        {
            get
            {
                int argb = ConfigFileManager.Default.GetValue("OsdColor", Color.White.ToArgb());
                return Color.FromArgb(argb);
            }

            set
            {
                ConfigFileManager.Default.SetValue("OsdColor", value.ToArgb());
            }
        }

        public static Color SubColor
        {
            get
            {
                int argb = ConfigFileManager.Default.GetValue("SubColor", Color.White.ToArgb());
                return Color.FromArgb(argb);
            }

            set
            {
                ConfigFileManager.Default.SetValue("SubColor", value.ToArgb());
            }
        }

        static Font DefSubAndOsdFont = new Font("Segoe UI", 12f, FontStyle.Bold, GraphicsUnit.Point);

        public static Font OsdFont
        {
            get
            {
                string _f = ConfigFileManager.Default.GetValue("OsdFont", new FontConverter().ConvertToInvariantString(DefSubAndOsdFont));
                Font f = (Font)new FontConverter().ConvertFromInvariantString(_f);
                byte charSet = (byte)ConfigFileManager.Default.GetValue("OsdFontCharSet", DefSubAndOsdFont.GdiCharSet);
                return new Font(f.FontFamily, f.Size, f.Style, f.Unit, charSet);
            }

            set
            {
                ConfigFileManager.Default.SetValue("OsdFont", new FontConverter().ConvertToInvariantString(value));
                ConfigFileManager.Default.SetValue("OsdFontCharSet", value.GdiCharSet);
            }
        }

        public static Font SubFont
        {
            get
            {
                string _f = ConfigFileManager.Default.GetValue("SubFont", new FontConverter().ConvertToInvariantString(DefSubAndOsdFont));
                Font f = (Font)new FontConverter().ConvertFromInvariantString(_f);
                byte charSet = (byte)ConfigFileManager.Default.GetValue("SubFontCharSet", DefSubAndOsdFont.GdiCharSet);
                return new Font(f.FontFamily, f.Size, f.Style, f.Unit, charSet);
            }

            set
            {
                ConfigFileManager.Default.SetValue("SubFont", new FontConverter().ConvertToInvariantString(value));
                ConfigFileManager.Default.SetValue("SubFontCharSet", value.GdiCharSet);
            }
        }

        public static int OsdPersistTimer
        {
            get
            {
                return ConfigFileManager.Default.GetValue("OsdPersistTimer", 4000);
            }

            set
            {
                ConfigFileManager.Default.SetValue("OsdPersistTimer", value);
            }
        }

        public static bool SubtitleDownloadEnabled
        {
            get
            {
                return ConfigFileManager.Default.GetValue("SubtitleDownloadEnabled", true);
            }

            set
            {
                ConfigFileManager.Default.SetValue("SubtitleDownloadEnabled", value);
            }
        }

        public static int SubtitleMinimumMovieDuration
        {
            get
            {
                return ConfigFileManager.Default.GetValue("SubtitleMinimumMovieDuration", 20 /* 20 minutes */);
            }

            set
            {
                ConfigFileManager.Default.SetValue("SubtitleMinimumMovieDuration", value);
            }
        }

        public static bool MediaStateNotificationsEnabled
        {
            get
            {
                return ConfigFileManager.Default.GetValue("MediaStateNotificationsEnabled", true);
            }

            set
            {
                ConfigFileManager.Default.SetValue("MediaStateNotificationsEnabled", value);
            }
        }

        public static bool SubDownloadedNotificationsEnabled
        {
            get
            {
                return ConfigFileManager.Default.GetValue("SubDownloadedNotificationsEnabled", true);
            }

            set
            {
                ConfigFileManager.Default.SetValue("SubDownloadedNotificationsEnabled", value);
            }
        }

        public static bool UseMetadata
        {
            get { return ConfigFileManager.Default.GetValue("UseMetadata", true); }
            set { ConfigFileManager.Default.SetValue("UseMetadata", value); }
        }

        public static bool UseFileNameFormat
        {
            get { return ConfigFileManager.Default.GetValue("UseFileNameFormat", true); }
            set { ConfigFileManager.Default.SetValue("UseFileNameFormat", value); }
        }

        public static string PlaylistEntryFormat
        {
            get { return ConfigFileManager.Default.GetValue("PlaylistEntryFormat", "<A> - <T>"); }
            set { ConfigFileManager.Default.SetValue("PlaylistEntryFormat", value); }
        }

        public static string FileNameFormat
        {
            get { return ConfigFileManager.Default.GetValue("FileNameFormat", "<A> - <T>"); }
            set { ConfigFileManager.Default.SetValue("FileNameFormat", value); }
        }

        public static string CustomPlaylistEntryFormats
        {
            get { return ConfigFileManager.Default.GetValue("CustomPlaylistEntryFormats", string.Empty); }
            set { ConfigFileManager.Default.SetValue("CustomPlaylistEntryFormats", value); }
        }

        public static string CustomFileNameFormats
        {
            get { return ConfigFileManager.Default.GetValue("CustomFileNameFormats", string.Empty); }
            set { ConfigFileManager.Default.SetValue("CustomFileNameFormats", value); }
        }

        #endregion
    }
}