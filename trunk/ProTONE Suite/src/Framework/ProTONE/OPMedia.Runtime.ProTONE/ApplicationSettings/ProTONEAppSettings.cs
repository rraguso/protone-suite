using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Core.ApplicationSettings;
using System.ServiceProcess;
using OPMedia.Core;
using System.IO;
using OPMedia.Core.Utilities;
using Microsoft.Win32;

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

        public static string SubtitleDownloadURIs
        {
            get { return PersistenceProxy.ReadObject("SubtitleDownloadURIs", DefaultSubtitleURIs); }
            set { PersistenceProxy.SaveObject("SubtitleDownloadURIs", value); }
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
        #endregion
    }
}
