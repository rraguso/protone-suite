using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using OPMedia.Core.Logging;

namespace OPMedia.Core
{
    public static class ApplicationInfo
    {
        public static string _appName = null;

        public static void CreateDefaultAddonsConfig()
        {
            // Copy default addons config file if it does not exist
            if (File.Exists(ApplicationInfo.AddonsConfigFile))
            {
                Logger.LogTrace("Addons configuration is already saved in user's settings.");
            }
            else
            {
                Logger.LogTrace("Copying default addons configuration from 'DefaultAddons.config' ...");
                try
                {
                    File.Copy(@".\DefaultAddons.config", ApplicationInfo.AddonsConfigFile);
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            }
        }

        public static void RegisterAppName(Assembly asm)
        {
            if (!(IsPlayer || IsMediaLibrary || IsRCCManager || IsMediaHost || IsUtility))
            {
                try
                {
                    _appName = asm.GetName().Name;
                }
                catch
                {
                    _appName = null;
                }
            }
        }

        public static string ApplicationLaunchPath
        {
            get
            {
                return Application.ExecutablePath;
            }
        }

        public static string ApplicationName
        {
            get
            {
                if (string.IsNullOrEmpty(_appName))
                {
                    return Process.GetCurrentProcess().MainModule.FileVersionInfo.FileDescription;
                }

                return _appName;
            }
        }

        public static string ApplicationBinary
        {
            get
            {
                return Path.GetFileName(ApplicationLaunchPath);
            }
        }

        public static string SettingsFile
        {
            get
            {
                return Path.Combine(SettingsFolder, ApplicationName) + ".config";
            }
        }

        public static string AddonsConfigFile
        {
            get
            {
                return Path.Combine(SettingsFolder, ApplicationName) + ".Addons.config";
            }
        }

        public static string CommonDataFolder
        {
            get
            {
                try
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "OPMedia.CommonDataFolder");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    if (Directory.Exists(path))
                    {
                        return path;
                    }
                }
                catch
                {
                }

                return PathUtils.CurrentDir;
            }
        }

        public static string SettingsFolder
        {
            get
            {
                try
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        ApplicationName);

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    if (Directory.Exists(path))
                    {
                        return path;
                    }
                }
                catch
                {
                }

                return PathUtils.CurrentDir;
            }
        }

        internal static bool IsSuiteApplication
        {
            get
            {
                return (IsPlayer || IsMediaLibrary || IsRCCManager || IsMediaHost || IsShellExtension || IsUtility);
            }
        }

        public static bool IsPlayer
        {
            get
            {
                return string.Compare(ApplicationName, Constants.PlayerName, true) == 0;
            }
        }

        public static bool IsMediaLibrary
        {
            get
            {
                return string.Compare(ApplicationName, Constants.LibraryName, true) == 0;
            }
        }

        public static bool IsRCCManager
        {
            get
            {
                return string.Compare(ApplicationName, Constants.RCCManagerName, true) == 0;
            }
        }

        public static bool IsMediaHost
        {
            get
            {
                return string.Compare(ApplicationName, Constants.MediaHostName, true) == 0;
            }
        }

        public static bool IsShellExtension
        {
            get
            {
                return string.Compare(ApplicationName, Constants.ShellSupportName, true) == 0;
            }
        }

        public static bool IsUtility
        {
            get
            {
                return string.Compare(ApplicationName, Constants.UtilityName, true) == 0;
            }
        }
    }
}
