using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;
using OPMedia.Core;
using OPMedia.Core.Configuration;
using OPMedia.Runtime.ProTONE.Configuration;

namespace OPMedia.Runtime.ProTONE.Utilities
{
    public enum KnownFileType
    {
        AudioFile,
        VideoFile,
        Playlist,
        Bookmark,
        Catalog,
        Subtitle,
    }

    public interface ISupportedFileProvider
    {
        List<string> SupportedAudioTypes { get; }
        List<string> SupportedHDVideoTypes { get; }
        List<string> SupportedVideoTypes { get; }
        List<string> SupportedPlaylists { get; }
        List<string> SupportedSubtitles { get; }
    }

    public static class SuiteRegistrationSupport
    {
        static readonly Dictionary<string, KnownFileType> _knownFileTypes = new Dictionary<string, KnownFileType>();
        static readonly Dictionary<KnownFileType, string> _launchPaths = new Dictionary<KnownFileType, string>();
        static readonly Dictionary<KnownFileType, string> _descriptions = new Dictionary<KnownFileType, string>();

        public class KnownFileTypeInfo
        {
            public string FileType { get; private set; }
            public KnownFileType KnownFileType { get; private set; }
            public string LaunchPath { get; private set; }
            public string Description { get; private set; }
            public string MediaType { get; private set; }

            public bool IsValid { get; private set; }

            public KnownFileTypeInfo(string fileType, bool forceSetting, bool restoreLegacyMediaType)
            {
                try
                {
                    this.FileType = fileType.ToLowerInvariant();

                    if (_knownFileTypes.ContainsKey(this.FileType))
                    {
                        this.KnownFileType = _knownFileTypes[this.FileType];
                        this.LaunchPath = _launchPaths[this.KnownFileType];
                        this.Description = _descriptions[this.KnownFileType];

                        if (string.IsNullOrEmpty(this.Description))
                        {
                            this.Description = string.Format("OPMedia {0} (.{1})", this.KnownFileType, fileType);
                        }

                        this.MediaType = string.Format("OPMedia.{0}", this.KnownFileType);

                        IsValid = GetFileClass(forceSetting, restoreLegacyMediaType);
                        return;
                    }
                }
                catch { }

                IsValid = false;
            }

            private bool GetFileClass(bool forceSetting, bool restoreLegacyMediaType)
            {
                string newMediaType = string.Empty;
                string keyPath = string.Format(".{0}", this.FileType);

                using (RegistryKey key = (forceSetting) ?
                    Registry.ClassesRoot.Emu_CreateSubKey(keyPath) :
                    Registry.ClassesRoot.Emu_OpenSubKey(keyPath))
                {
                    if (key != null)
                    {
                        if (forceSetting)
                        {
                            // First erase all existing subkeys
                            string[] subKeyNames = key.GetSubKeyNames();
                            foreach (string subKeyName in subKeyNames)
                            {
                                try
                                {
                                    key.DeleteSubKeyTree(subKeyName);
                                }
                                catch
                                {
                                }
                            }

                            keyPath = string.Format(@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.{0}", this.FileType);
                            using (RegistryKey key2 = Registry.CurrentUser.Emu_CreateSubKey(keyPath))
                            {
                                if (key2 != null)
                                {
                                    subKeyNames = key2.GetSubKeyNames();
                                    foreach (string subKeyName in subKeyNames)
                                    {
                                        try
                                        {
                                            key2.DeleteSubKeyTree(subKeyName);
                                        }
                                        catch
                                        {
                                            try
                                            {
                                                key2.DeleteSubKey(subKeyName);
                                            }
                                            catch { }
                                        }
                                    }
                                }
                            }
                        }

                        if (restoreLegacyMediaType)
                        {
                            string legacyMediaType = key.GetValue("LegacyMediaType") as string;
                            if (!string.IsNullOrEmpty(legacyMediaType))
                            {
                                key.SetValue("", legacyMediaType);
                                key.DeleteValue("LegacyMediaType");
                            }
                            else
                            {
                                key.SetValue("", "");
                            }
                        }
                        else
                        {
                            if (forceSetting)
                            {
                                string oldMediaType = key.GetValue("") as string;
                                if (oldMediaType != null && oldMediaType != this.MediaType)
                                {
                                    key.SetValue("LegacyMediaType", oldMediaType);
                                }

                                key.SetValue("", this.MediaType);
                            }
                            else
                            {
                                this.MediaType = key.GetValue("") as string;
                            }
                        }

                        key.Close();
                        return true;
                    }

                    return false;
                }
            }
        }

        static SuiteRegistrationSupport()
        {
            _launchPaths.Add(KnownFileType.AudioFile, ProTONEConfig.PlayerInstallationPath);
            _launchPaths.Add(KnownFileType.VideoFile, ProTONEConfig.PlayerInstallationPath);
            _launchPaths.Add(KnownFileType.Playlist, ProTONEConfig.PlayerInstallationPath);
            _launchPaths.Add(KnownFileType.Bookmark, ProTONEConfig.PlayerInstallationPath);
            _launchPaths.Add(KnownFileType.Catalog, ProTONEConfig.LibraryInstallationPath);
            //_launchPaths.Add(KnownFileType.Subtitle, AppConfig.LibraryInstallationPath);
            _launchPaths.Add(KnownFileType.Subtitle, "");

            _descriptions.Add(KnownFileType.AudioFile, "");
            _descriptions.Add(KnownFileType.VideoFile, "");
            _descriptions.Add(KnownFileType.Playlist, "");
            _descriptions.Add(KnownFileType.Bookmark, ProTONEConstants.BookmarkFileTypeDesc);
            _descriptions.Add(KnownFileType.Catalog, ProTONEConstants.CatalogFileTypeDesc);
            _descriptions.Add(KnownFileType.Subtitle, ProTONEConstants.SubtitleFileTypeDesc);
        }

        public static void Init(ISupportedFileProvider provider)
        {
            _knownFileTypes.Clear();

            foreach (string s in provider.SupportedAudioTypes)
            {
                try
                {
                    _knownFileTypes.Add(s.ToLowerInvariant(), KnownFileType.AudioFile);
                }
                catch { }
            }

            foreach (string s in provider.SupportedVideoTypes)
            {
                try
                {
                    _knownFileTypes.Add(s.ToLowerInvariant(), KnownFileType.VideoFile);
                }
                catch { }
            }

            foreach (string s in provider.SupportedPlaylists)
            {
                try
                {
                    _knownFileTypes.Add(s.ToLowerInvariant(), KnownFileType.Playlist);
                }
                catch { }
            }

            foreach (string s in provider.SupportedSubtitles)
            {
                try
                {
                    _knownFileTypes.Add(s.ToLowerInvariant(), KnownFileType.Subtitle);
                }
                catch { }
            }

            _knownFileTypes.Add("bmk", KnownFileType.Bookmark);
            _knownFileTypes.Add("ctx", KnownFileType.Catalog);
        }

        #region File registration API

        public static void RegisterKnownFileTypes()
        {
            foreach (string s in _knownFileTypes.Keys)
            {
                RegisterFileType(s, true);
            }

            RegisterFileType("bmk", true);
            RegisterFileType("ctx", true);
        }

        public static void UnregisterKnownFileTypes()
        {
            foreach (string s in _knownFileTypes.Keys)
            {
                UnregisterFileType(s, true);
            }

            UnregisterFileType("bmk", true);
            UnregisterFileType("ctx", true);
        }

        public static void RegisterFileType(string fileType, bool regMediaType)
        {
            KnownFileTypeInfo info = new KnownFileTypeInfo(fileType, true, false);

            if (info.IsValid)
            {
                if (regMediaType)
                {
                    // ==== Register media type ====
                    using (RegistryKey mediaTypeKey = Registry.ClassesRoot.Emu_CreateSubKey(info.MediaType))
                    {
                        if (mediaTypeKey != null)
                        {
                            mediaTypeKey.SetValue("", info.MediaType);
                        }

                        // ==== Register icon ====
                        using (RegistryKey defaultIconKey = mediaTypeKey.Emu_CreateSubKey("DefaultIcon"))
                        {
                            if (defaultIconKey != null)
                            {
                                string newValue = string.Format(@"{0}\Resources\{1}.ico", AppConfig.InstallationPath, info.KnownFileType);
                                defaultIconKey.SetValue("", newValue);
                            }
                        }

                        if (File.Exists(info.LaunchPath))
                        {
                            using (RegistryKey shellKey = mediaTypeKey.Emu_CreateSubKey("shell"))
                            {
                                if (shellKey != null)
                                {
                                    // ==== Change default action to OPEN ====
                                    shellKey.SetValue("", "open");

                                    // ==== Update OPEN action command ====
                                    using (RegistryKey key = shellKey.Emu_CreateSubKey("open\\command"))
                                    {
                                        if (key != null)
                                        {
                                            key.SetValue("", string.Format("\"{0}\" launch \"%L\"", info.LaunchPath));
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            mediaTypeKey.DeleteSubKeyTree("shell", false);
                        }
                    }
                }
            }
        }

        public static void UnregisterFileType(string fileType, bool unregMediaType)
        {
            KnownFileTypeInfo info = new KnownFileTypeInfo(fileType, true, true);

            if (info.IsValid)
            {
                if (unregMediaType)
                {
                    // ==== Unregister media type ====
                    using (RegistryKey mediaTypeKey = Registry.ClassesRoot.Emu_CreateSubKey(info.MediaType))
                    {
                        if (mediaTypeKey != null)
                        {
                            mediaTypeKey.SetValue("", "");

                            // ==== Unregister icon ====
                            using (RegistryKey defaultIconKey = mediaTypeKey.Emu_CreateSubKey("DefaultIcon"))
                            {
                                if (defaultIconKey != null)
                                {
                                    defaultIconKey.SetValue("", "");
                                }
                            }

                            mediaTypeKey.DeleteSubKeyTree("shell", false);
                        }
                    }
                }
            }
        }

        public static bool IsFileTypeRegistered(string fileType)
        {
            try
            {
                KnownFileTypeInfo info = new KnownFileTypeInfo(fileType, false, false);

                string keyPath = string.Format("{0}\\shell\\open\\command", info.MediaType);
                string expectedOpenCommand = string.Format("\"{0}\" launch \"%L\"", info.LaunchPath);

                using (RegistryKey key = Registry.ClassesRoot.Emu_OpenSubKey(keyPath))
                {
                    if (key != null)
                    {
                        string openCommand = key.GetValue("") as string;
                        return (openCommand == expectedOpenCommand);
                    }
                }
            }
            catch
            {
            }

            return false;
        }

        #endregion

        #region Context menu handler register/unregister

        public static void RegisterContextMenuHandler()
        {
            // File context menu handler
            string keyName = @"*\shellex\ContextMenuHandlers\" + ProTONEConstants.PlayerName;
            using (RegistryKey key = Registry.ClassesRoot.Emu_CreateSubKey(keyName))
            {
                // Set the default value of the key.
                if (key != null)
                {
                    key.SetValue(null, ProTONEConstants.CanonicShellIntegrationSuportGuid);
                }
            }

            // Folder context menu handler
            keyName = @"Directory\shellex\ContextMenuHandlers\" + ProTONEConstants.PlayerName;
            using (RegistryKey key = Registry.ClassesRoot.Emu_CreateSubKey(keyName))
            {
                // Set the default value of the key.
                if (key != null)
                {
                    key.SetValue(null, ProTONEConstants.CanonicShellIntegrationSuportGuid);
                }
            }

            // Drive context menu handler
            keyName = @"Drive\shellex\ContextMenuHandlers\" + ProTONEConstants.PlayerName;
            using (RegistryKey key = Registry.ClassesRoot.Emu_CreateSubKey(keyName))
            {
                // Set the default value of the key.
                if (key != null)
                {
                    key.SetValue(null, ProTONEConstants.CanonicShellIntegrationSuportGuid);
                }
            }
        }

        public static void UnregisterContextMenuHandler()
        {
            // File context menu handler
            try
            {
                Registry.ClassesRoot.DeleteSubKeyTree(@"*\shellex\ContextMenuHandlers\" + ProTONEConstants.PlayerName);
            }
            catch { }

            // Folder context menu handler
            try
            {
                Registry.ClassesRoot.DeleteSubKeyTree(@"Directory\shellex\ContextMenuHandlers\" + ProTONEConstants.PlayerName);
            }
            catch { }

            // Drive context menu handler
            try
            {
                Registry.ClassesRoot.DeleteSubKeyTree(@"Drive\shellex\ContextMenuHandlers\" + ProTONEConstants.PlayerName);
            }
            catch { }
        }

        public static bool IsContextMenuHandlerRegistered()
        {
            try
            {
                string fileHandlerGuid = "1";
                string folderHandlerGuid = "2"; // init with different values so as they are not equal

                using (RegistryKey key = Registry.ClassesRoot.Emu_OpenSubKey(@"*\shellex\ContextMenuHandlers\" + ProTONEConstants.PlayerName))
                {
                    if (key != null)
                    {
                        fileHandlerGuid = key.GetValue("") as string;
                    }
                }

                using (RegistryKey key = Registry.ClassesRoot.Emu_OpenSubKey(@"Directory\shellex\ContextMenuHandlers\" + ProTONEConstants.PlayerName))
                {
                    if (key != null)
                    {
                        folderHandlerGuid = key.GetValue("") as string;
                    }
                }

                return (fileHandlerGuid == folderHandlerGuid && folderHandlerGuid == ProTONEConstants.CanonicShellIntegrationSuportGuid);
            }
            catch
            {
                return false;
            }

        }
        #endregion

        public static void ReloadFileAssociations()
        {
            Shell32.SHChangeNotify(HChangeNotifyEventID.SHCNE_ASSOCCHANGED,
                HChangeNotifyFlags.SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero);
        }
    }
}
