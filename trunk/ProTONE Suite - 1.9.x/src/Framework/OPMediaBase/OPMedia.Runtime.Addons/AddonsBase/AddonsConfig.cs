using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Core.Logging;
using System.IO;
using System.Diagnostics;
using OPMedia.UI;
using OPMedia.Core;
using System.Windows.Forms;
using OPMedia.Runtime.Addons.Configuration;
using OPMedia.Runtime;
using OPMedia.UI.Configuration;
using System.Reflection;
using System.Globalization;

namespace OPMedia.Runtime.Addons.AddonsBase
{
    public static class AddonsConfig
    {
        static string[] _navAddons = null;
        static string[] _propAddons = null;
        static string[] _previewAddons = null;

        static Dictionary<string, string> _assemblies = new Dictionary<string, string>();
        static string filePath = string.Empty;

        public static string AddonsConfigFile
        {
            get
            {
                return filePath;
            }

        }

        public static string[] NavigationAddons
        {
            get
            {
                return _navAddons;
            }
            
        }

        public static string[] PropertyAddons
        {
            get
            {
                return _propAddons;
            }
        }

        public static string[] PreviewAddons
        {
            get
            {
                return _previewAddons;
            }
        }

        public static bool IsInitialConfig { get; set; }

        public static string GetAssemblyInfo(string addonName)
        {
            if (_assemblies.Count > 0 &&
                _assemblies.ContainsKey(addonName))
            {
                return _assemblies[addonName];
            }

            return string.Empty;
        }

        public static void Init() { }

        static AddonsConfig()
        {
            IsInitialConfig = false;

            filePath = string.Format(@"{0}{1}{2}.Addons.config",
                    ApplicationInfo.SettingsFolder, PathUtils.DirectorySeparator,
                    ApplicationInfo.ApplicationName);

            //SettingsForm.InitAddonCfg +=
              //  new SettingsForm.InitAddonCfgHandler(SettingsForm_InitAddonCfg);

            try
            {
                ConfigFileManager config = new ConfigFileManager(filePath);

                UninstallMarkedItems(config);

                _navAddons = ReadAddonConfig(config, "NavigationAddons");
                _previewAddons = ReadAddonConfig(config, "PreviewAddons");
                _propAddons = ReadAddonConfig(config, "PropertyAddons");
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        private static string[] ReadAddonConfig(ConfigFileManager config, string keyBase)
        {
            string[] names = null;
            string namesRaw = config.GetValue(keyBase);

            if (!string.IsNullOrEmpty(namesRaw))
            {
                names = namesRaw.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string name in names)
                {
                    _assemblies.Add(name, config.GetValue(name));
                }
            }

            return names;
        }

        internal static void MarkForUninstall(string assembly)
        {
            ConfigFileManager config = new ConfigFileManager(filePath);
            string markedForUninstall = config.GetValue("MarkedForUninstall", string.Empty);

            List<string> filesToDelete = new List<string>();

            IEnumerable<string> files = Directory.EnumerateFiles(Application.StartupPath, string.Format("{0}*", assembly));
            if (files != null)
            {
                foreach (string asmFile in files)
                {
                    Assembly asm = Assembly.LoadFrom(asmFile);
                    if (asm != null)
                    {
                        filesToDelete.Add(asmFile);

                        foreach (CultureInfo ci in SuiteConfiguration.SupportedCultures)
                        {
                            try
                            {
                                Assembly satAsm = asm.GetSatelliteAssembly(ci);
                                if (satAsm != null)
                                {
                                    string path = satAsm.Location.ToLowerInvariant();
                                    if (!filesToDelete.Contains(path))
                                    {
                                        filesToDelete.Add(path.ToLowerInvariant());
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.LogException(ex);
                            }
                        }

                        foreach (string file in filesToDelete)
                        {
                            markedForUninstall += file;
                            markedForUninstall += "|";
                        }
                    }
                }
            }

            config.SetValue("MarkedForUninstall", markedForUninstall);
            config.Save();
        }

        private static void UninstallMarkedItems(ConfigFileManager config)
        {
            string[] names = null;
            string namesRaw = config.GetValue("MarkedForUninstall");

            if (!string.IsNullOrEmpty(namesRaw))
            {
                names = namesRaw.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string name in names)
                {
                    try
                    {
                        UninstallAddonLibrary(name);
                    }
                    catch(Exception ex)
                    {
                        //ErrorDispatcher.DispatchError(ex);
                        Logger.LogException(ex);
                    }
                }

                config.DeleteValue("MarkedForUninstall");
                config.Save();
            }
        }

        private static void UninstallAddonLibrary(string name)
        {
            FileInfo fi = new FileInfo(name);
            fi.Attributes ^= fi.Attributes;
            fi.Delete();
        }

        internal static void InstallAddonLibrary(string fileName)
        {
            try
            {
                List<string> filesToCopy = new List<string>();

                Assembly asm = Assembly.LoadFrom(fileName);
                if (asm != null)
                {
                    filesToCopy.Add(asm.Location.ToLowerInvariant());

                    foreach (CultureInfo ci in SuiteConfiguration.SupportedCultures)
                    {
                        try
                        {
                            Assembly satAsm = asm.GetSatelliteAssembly(ci);
                            if (satAsm != null)
                            {
                                string path = satAsm.Location.ToLowerInvariant();
                                if (!filesToCopy.Contains(path))
                                {
                                    filesToCopy.Add(path.ToLowerInvariant());
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            Logger.LogException(ex);
                        }
                    }

                    foreach (string file in filesToCopy)
                    {
                        CopyToRunLocation(file.ToLowerInvariant(), 
                            Path.GetDirectoryName(fileName.ToLowerInvariant()));
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        private static void CopyToRunLocation(string filePath, string baseFilePath)
        {
            string diffPath = filePath.Replace(baseFilePath, string.Empty);
            string destFileName = string.Format("{0}{1}{2}", 
                Application.StartupPath, PathUtils.DirectorySeparator, diffPath).Replace(@"\\", @"\");

            string destFolder = Path.GetDirectoryName(destFileName);
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }

            File.Copy(filePath, destFileName, true);
        }
    }
}
