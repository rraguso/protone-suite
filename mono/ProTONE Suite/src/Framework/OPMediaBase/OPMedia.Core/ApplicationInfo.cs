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

        

        public static void RegisterAppName(Assembly asm)
        {
            if (IsSuiteApplication == false)
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

        public static bool IsSuiteApplication
        {
            get
            {
                return ApplicationName.StartsWith(Constants.SuiteAppPrefix);
            }
        }
    }
}
