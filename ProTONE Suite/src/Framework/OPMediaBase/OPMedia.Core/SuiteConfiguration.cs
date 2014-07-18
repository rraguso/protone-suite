using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using System.ServiceProcess;
using System.Drawing;
using System.Globalization;
using OPMedia.Core.TranslationSupport;
using System.Runtime.InteropServices;
using OPMedia.Core.Logging;
using OPMedia.Core.ApplicationSettings;
using System.Security.Principal;
using OPMedia.Core.Utilities;


namespace OPMedia.Core
{
    public static class SuiteConfiguration
    {
        public const int VerWin2000 =  50;
        public const int VerWinXP =    51;
        public const int VerWinVista = 60;
        public const int VerWin7     = 61;

        static readonly string _configRegPath = 
            string.Format("Software\\{0}\\{1}", Constants.CompanyName, Constants.SuiteName);

        static object _languageSyncRoot = new object();
        static System.Windows.Forms.Timer _tmrReadRegistry = null;

        static Dictionary<string, CultureInfo> _cultures = new Dictionary<string, CultureInfo>();

        static string _skinType = string.Empty;
        static string _languageId = InstallLanguageID;

        static SuiteConfiguration()
        {
            _cultures.Add("en", new CultureInfo("en"));
            _cultures.Add("de", new CultureInfo("de"));
            _cultures.Add("fr", new CultureInfo("fr"));
            _cultures.Add("ro", new CultureInfo("ro"));

            lock (_languageSyncRoot)
            {
                try
                {
                    // Is the install language setting overriden by current user ?
                    using (RegistryKey key = Registry.CurrentUser.Emu_OpenSubKey(ConfigRegPath))
                    {
                        if (key == null)
                        {
                            // Nop, it is not => Read the install language
                            _languageId = InstallLanguageID;
                        }
                        else
                        {
                            _languageId = key.GetValue("LanguageID", InstallLanguageID) as string;
                        }
                    }
                }
                catch
                {
                    _languageId = InstallLanguageID;
                }

                if (string.IsNullOrEmpty(_languageId))
                {
                    _languageId = InstallLanguageID;
                }

                LanguageID = _languageId;

                try
                {
                    using (RegistryKey key = Registry.CurrentUser.Emu_OpenSubKey(ConfigRegPath))
                    {
                        if (key == null)
                        {
                            _skinType = string.Empty;
                        }
                        else
                        {
                            string skinType = key.GetValue("SkinType", string.Empty) as string;
                            if (skinType != _skinType)
                            {
                                _skinType = skinType;
                            }
                        }
                    }
                }
                catch
                {
                    _skinType = string.Empty;
                }

                LanguageID = _languageId;
                SkinType = _skinType;
            }

            _tmrReadRegistry = new System.Windows.Forms.Timer();
            _tmrReadRegistry.Interval = 5000;
            _tmrReadRegistry.Tick += new EventHandler(OnReadRegistry);
            _tmrReadRegistry.Start();
        }

        static void OnReadRegistry(object sender, EventArgs e)
        {
            lock (_languageSyncRoot)
            {
                try
                {
                    _tmrReadRegistry.Stop();

                    using (RegistryKey key = Registry.CurrentUser.Emu_OpenSubKey(ConfigRegPath))
                    {
                        if (key != null)
                        {
                            string langId = key.GetValue("LanguageID", InstallLanguageID) as string;
                            if (langId != _languageId)
                            {
                                _languageId = langId;
                                Translator.SetInterfaceLanguage(_languageId);
                            }

                            string skinType = key.GetValue("SkinType", string.Empty) as string;
                            if (skinType != _skinType)
                            {
                                _skinType = skinType;
                                EventDispatch.DispatchEvent(EventNames.ThemeUpdated);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
                finally
                {
                    _tmrReadRegistry.Start();
                }
            }
        }

        #region Generic Purpose API (Level 0 settings)

        public static int OSVersion
        {
            get
            {

                int winVer = Environment.OSVersion.Version.Major * 10;
                winVer += Environment.OSVersion.Version.Minor;
                return winVer;
            }
        }

        public static bool CurrentUserIsAdministrator
        {
            get
            {
                try
                {
                    WindowsIdentity user = WindowsIdentity.GetCurrent();
                    WindowsPrincipal principal = new WindowsPrincipal(user);
                    return principal.IsInRole(WindowsBuiltInRole.Administrator);
                }
                catch
                {
                }

                return false;
            }
        }

        public static string InstallationPath
        {
            get
            {
                string retVal = string.Empty;
                try
                {
                    if (ApplicationInfo.IsSuiteApplication)
                    {
                        RegistryKey key = Registry.LocalMachine.Emu_OpenSubKey(@"SOFTWARE\OPMedia Research\" + Constants.PlayerName);
                        if (key != null)
                        {
                            retVal = key.GetValue("InstallPathOverride") as string;
                        }
                    }

                    if (string.IsNullOrEmpty(retVal))
                    {
                        Assembly asm = Assembly.GetAssembly(typeof(SuiteConfiguration));
                        if (asm != null)
                        {
                            FileInfo fi = new FileInfo(asm.Location);
                            retVal = fi.DirectoryName;
                        }
                    }
                }
                catch
                {
                    retVal = string.Empty;
                }

                return retVal;
            }
        }

        public static string ConfigRegPath
        {
            get
            {
                if (ApplicationInfo.IsSuiteApplication)
                    return _configRegPath;

                return "Software\\" + ApplicationInfo.ApplicationName;
            }
        }

        public static CultureInfo[] SupportedCultures
        {
            get
            {
                CultureInfo[] retVal = new CultureInfo[_cultures.Count];
               _cultures.Values.CopyTo(retVal, 0);
                return retVal;
            }
        }

        public static string SkinType
        {
            get
            {
                return _skinType;
            }

            set
            {
                if (value != _skinType)
                {
                    _skinType = value;
                    EventDispatch.DispatchEvent(EventNames.ThemeUpdated);

                    try
                    {
                        using (RegistryKey key = Registry.CurrentUser.Emu_CreateSubKey(ConfigRegPath))
                        {
                            if (key != null)
                            {
                                key.SetValue("SkinType", value);
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        public static string LanguageID
        {
            get
            {
                if (string.IsNullOrEmpty(_languageId))
                {
                    _languageId = InstallLanguageID;
                }

                return _languageId;
            }

            set
            {
                try
                {
                    if (value != _languageId)
                    {
                        using (RegistryKey key = Registry.CurrentUser.Emu_CreateSubKey(ConfigRegPath))
                        {
                            if (key != null)
                            {
                                key.SetValue("LanguageID", value);
                            }
                        }

                        _languageId = value;
                        Translator.SetInterfaceLanguage(_languageId);
                    }
                }
                catch
                {
                } 
            }
        }

        public static string InstallLanguageID
        {
            get
            {
                using (RegistryKey key = Registry.LocalMachine.Emu_OpenSubKey(ConfigRegPath))
                {
                    if (key != null)
                    {
                        return key.GetValue("InstallLanguageID", "en") as string;
                    }
                }

                return "en";
            }
        }

        public static string HelpUriBase
        {
            get
            {
                if (UseOnlineDocumentation)
                {
                    using (RegistryKey key = Registry.LocalMachine.Emu_OpenSubKey(ConfigRegPath))
                    {
                        if (key != null)
                        {
                            return key.GetValue("HelpUriBase", string.Empty) as string;
                        }
                    }
                }

                return string.Format("file:///{0}/docs", SuiteConfiguration.InstallationPath);
            }
        }

        public static bool UseOnlineDocumentation
        {
            get
            {
                using (RegistryKey key = Registry.LocalMachine.Emu_OpenSubKey(ConfigRegPath))
                {
                    if (key != null)
                    {
                        int val = (int)key.GetValue("UseOnlineDocumentation", 0);
                        return (val != 0);
                    }
                }

                return false;
            }
        }

        public static string DownloadUriBase
        {
            get 
            {
                using (RegistryKey key = Registry.LocalMachine.Emu_OpenSubKey(ConfigRegPath))
                {
                    if (key != null)
                    {
                        return key.GetValue("DownloadUriBase", string.Empty) as string;
                    }
                }

                return string.Empty;
            }
        }
        
        public static bool AllowAutomaticUpdates
        {
            get 
            {
                using (RegistryKey key = Registry.CurrentUser.Emu_OpenSubKey(ConfigRegPath))
                {
                    if (key != null)
                    {
                        int val = (int)key.GetValue("AllowAutomaticUpdates", 1);
                        return (val != 0);
                    }
                }

                return false;
            }
            
            set 
            {
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.Emu_CreateSubKey(ConfigRegPath))
                    {
                        if (key != null)
                        {
                            key.SetValue("AllowAutomaticUpdates", value ? 1 : 0);
                        }
                    }
                }
                catch
                {
                }
            }
        }

        #endregion


        #region Suite installation API

        public static string PlayerInstallationPath
        {
            get
            {
                return Path.Combine(InstallationPath, Constants.PlayerBinary);
            }
        }

        public static string LibraryInstallationPath
        {
            get
            {
                return Path.Combine(InstallationPath, Constants.LibraryBinary);
            }
        }

        public static string MediaHostInstallationPath
        {
            get
            {
                return Path.Combine(InstallationPath, Constants.MediaHostBinary);
            }
        }
        #endregion

        internal static bool RunProcess(string cmdLine, string args, bool wait, bool window=false)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(cmdLine, args);
                psi.CreateNoWindow = !window;
                psi.ErrorDialog = true;
                psi.WindowStyle = (window) ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden;

                Process p = Process.Start(psi);
                if (p != null && wait)
                {
                    p.WaitForExit();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
