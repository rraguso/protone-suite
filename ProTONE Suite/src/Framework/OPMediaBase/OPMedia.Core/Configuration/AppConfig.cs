using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using OPMedia.Core;
using System.IO;
using System.Reflection;
using OPMedia.Core.Logging;
using System.ComponentModel;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.GlobalEvents;
using OPMedia.Core.Utilities;
using System.Text.RegularExpressions;
using System.Net;
using System.Globalization;
using Microsoft.Win32;
using System.Security.Principal;
using System.Diagnostics;

namespace OPMedia.Core.Configuration
{
    public enum ProxyType
    {
        NotDefined = -1,
        NoProxy = 0,
        HttpProxy,
        Socks4Proxy,
        Socks5Proxy,
        InternetExplorerProxy,
        ApplicationProxy,

        GlobalProxy,
    }

    public class ProxySettings
    {
        public static ProxySettings Empty = new ProxySettings();
        public ProxyType ProxyType = ProxyType.NoProxy;
        public int ProxyPort = 8080;

        public string ProxyAddress { get; set; }
        public string ProxyUser { get; set; }
        public string ProxyPassword { get; set; }

        private ProxySettings()
        {
            EventDispatch.RegisterHandler(this);
            InitDefaults();
        }

        [EventSink(EventNames.PerformTranslation)]
        public void InitDefaults()
        {
            ProxyAddress = Translator.Translate("TXT_DEFINE_PROXYSERVERADDRESS");
            ProxyUser = Translator.Translate("TXT_DEFINE_PROXYSERVERUSERNAME");
            ProxyPassword = string.Empty;
        }

        ~ProxySettings()
        {
            EventDispatch.UnregisterHandler(this);
        }
    }

    public static class AppConfig
    {
        public const int VerWin2000 = 50;
        public const int VerWinXP = 51;
        public const int VerWinVista = 60;
        public const int VerWin7 = 61;

        static readonly string _configRegPath =
            string.Format("Software\\{0}\\{1}", Constants.CompanyName, Constants.SuiteName);

        static object _languageSyncRoot = new object();
        static System.Windows.Forms.Timer _tmrReadRegistry = null;

        static Dictionary<string, CultureInfo> _cultures = new Dictionary<string, CultureInfo>();

        static string _skinType = string.Empty;
        static string _languageId = InstallLanguageID;

        public static void Save()
        {
            ConfigFileManager.Default.Save();
        }

        static AppConfig()
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
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(ConfigRegPath))
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
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(ConfigRegPath))
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
            if (DetectRegistryChanges)
            {
                lock (_languageSyncRoot)
                {
                    try
                    {
                        _tmrReadRegistry.Stop();

                        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(ConfigRegPath))
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
        }

        #region Generic Purpose API (Level 0 settings)

        private static bool _allowGUISetup = true;
        private static object _allowGUISetupLock = new object();
        public static bool AllowRealtimeGUISetup
        {
            get
            {
                lock (_allowGUISetupLock)
                {
                    return _allowGUISetup;
                }
            }
            set
            {
                lock (_allowGUISetupLock)
                {
                    _allowGUISetup = value;
                    DetectRegistryChanges = value;
                }
            }
        }

        private static bool _detectRegistryChanges = true;
        private static object _registryChangesLock = new object();
        public static bool DetectRegistryChanges
        { 
            get 
            {
                lock (_registryChangesLock)
                {
                    return _detectRegistryChanges;
                }
            } 
            set 
            {
                lock (_registryChangesLock)
                {
                    _detectRegistryChanges = value;
                }
            } 
        }

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
                        RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OPMedia Research\ProTONE Suite");
                        if (key != null)
                        {
                            retVal = key.GetValue("InstallPathOverride") as string;
                        }
                    }

                    if (string.IsNullOrEmpty(retVal))
                    {
                        Assembly asm = Assembly.GetAssembly(typeof(AppConfig));
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
                        using (RegistryKey key = Registry.CurrentUser.CreateSubKey(ConfigRegPath))
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
                        using (RegistryKey key = Registry.CurrentUser.CreateSubKey(ConfigRegPath))
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
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(ConfigRegPath))
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
                try
                {
                    if (UseOnlineDocumentation)
                    {
                        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(ConfigRegPath))
                        {
                            if (key != null)
                            {
                                string val = key.GetValue("HelpUriBase", string.Empty) as string;
                                if (!string.IsNullOrEmpty(val))
                                {
                                    Version ver = new Version(SuiteVersion.Version);
                                    val = val.Replace("#VERSION#", string.Format("{0}.{1}", ver.Major, ver.Minor));
                                    return val;
                                }
                            }
                        }
                    }
                }
                catch { }

                return string.Format("file:///{0}/docs", AppConfig.InstallationPath);
            }
        }

        public static bool UseOnlineDocumentation
        {
            get
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(ConfigRegPath))
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
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(ConfigRegPath))
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
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(ConfigRegPath))
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
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(ConfigRegPath))
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
        
        

        #region Level 1 settings using Settings File (Combined per-app and per-user settings)

        #region Network preferences
       

        public static IWebProxy GetWebProxy()
        {
            IWebProxy wp = null;
            ProxySettings ps = ProxySettings;

            if (ps == null || ps.ProxyType == ProxyType.NoProxy)
            {
                wp = new WebProxy();
            }
            else if (ps.ProxyType != ProxyType.InternetExplorerProxy)
            {
                wp = new WebProxy(ps.ProxyAddress, ps.ProxyPort);
                wp.Credentials = new NetworkCredential(ps.ProxyUser, ps.ProxyPassword);
                (wp as WebProxy).BypassProxyOnLocal = true;
            }

            return wp;
        }
                
        public static ProxySettings ProxySettings
        {
            get
            {
                ProxySettings ps = ProxySettings.Empty;
                ps.ProxyAddress = ProxyAddress;
                ps.ProxyPassword = ProxyPassword;
                ps.ProxyPort = ProxyPort;
                ps.ProxyType = ProxyType;
                ps.ProxyUser = ProxyUser;

                return ps;
            }

            set
            {
                ProxyAddress = value.ProxyAddress;
                ProxyPassword = value.ProxyPassword;
                ProxyPort = value.ProxyPort;
                ProxyType = value.ProxyType;
                ProxyUser = value.ProxyUser;
            }
        }

        public static ProxyType ProxyType
        {
            get
            {
                return (ProxyType)ConfigFileManager.Default.GetValue("ProxyType", (int)ProxyType.NoProxy);
            }
            set
            {
                ConfigFileManager.Default.SetValue("ProxyType", (int)value);
            }
        }

        public static string ProxyAddress
        {
            get
            {
                return ConfigFileManager.Default.GetValue("ProxyAddress", "your.proxy.address");
            }
            set
            {
                ConfigFileManager.Default.SetValue("ProxyAddress", value);
            }
        }

        public static int ProxyPort
        {
            get
            {
                return ConfigFileManager.Default.GetValue("ProxyPort", 8080);
            }
            set
            {
                ConfigFileManager.Default.SetValue("ProxyPort", value);
            }
        }

        public static string ProxyUser
        {
            get
            {
                return ConfigFileManager.Default.GetValue("ProxyUser", "user.name");
            }
            set
            {
                ConfigFileManager.Default.SetValue("ProxyUser", value);
            }
        }

        public static string ProxyPassword
        {
            get
            {
                return ConfigFileManager.Default.GetValue("ProxyPassword", string.Empty);
            }
            set
            {
                ConfigFileManager.Default.SetValue("ProxyPassword", value);
            }
        }
        #endregion

        #region Logging

        public static string GetDefaultLoggingFolder()
        {
            try
            {
                string installPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                string defaultPath = Path.Combine(installPath, "Logs");

                if (CanWriteToFolder(defaultPath))
                    return defaultPath;

                defaultPath = Path.Combine(ApplicationInfo.SettingsFolder, "Logs");
                if (CanWriteToFolder(defaultPath))
                    return defaultPath;
            }
            catch
            {
            }

            return Path.GetTempPath();
        }

        public static bool CanWriteToFolder(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string randomName = StringUtils.GenerateRandomToken(32);
                string randomFilePath = Path.Combine(path, randomName);

                StreamWriter sw = File.CreateText(randomFilePath);
                if (sw != null)
                {
                    sw.WriteLine(randomName);
                    sw.Close();
                }

                if (File.Exists(randomFilePath))
                {
                    File.Delete(randomFilePath);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LogEnabled
        {
            get { return ConfigFileManager.Default.GetValue("LogEnabled", true); }
            set { ConfigFileManager.Default.SetValue("LogEnabled", value); }
        }

        public static bool LogHeavyTraceLevelEnabled
        {
            get { return ConfigFileManager.Default.GetValue("LogHeavyTraceLevelEnabled", true); }
            set { ConfigFileManager.Default.SetValue("LogHeavyTraceLevelEnabled", value); }
        }

        public static bool LogTraceLevelEnabled
        {
            get { return ConfigFileManager.Default.GetValue("LogTraceLevelEnabled", true); }
            set { ConfigFileManager.Default.SetValue("LogTraceLevelEnabled", value); }
        }

        public static bool LogInfoLevelEnabled
        {
            get { return ConfigFileManager.Default.GetValue("LogInfoLevelEnabled", true); }
            set { ConfigFileManager.Default.SetValue("LogInfoLevelEnabled", value); }
        }

        public static bool LogWarningLevelEnabled
        {
            get { return ConfigFileManager.Default.GetValue("LogWarningLevelEnabled", true); }
            set { ConfigFileManager.Default.SetValue("LogWarningLevelEnabled", value); }
        }

        public static bool LogErrorLevelEnabled
        {
            get { return ConfigFileManager.Default.GetValue("LogErrorLevelEnabled", true); }
            set { ConfigFileManager.Default.SetValue("LogErrorLevelEnabled", value); }
        }

        public static string LogFilePath
        {
            get { return ConfigFileManager.Default.GetValue("LogFilePath", GetDefaultLoggingFolder()); }
            set { ConfigFileManager.Default.SetValue("LogFilePath", value); }
        }

        public static int DaysToKeepLogs
        {
            get { return ConfigFileManager.Default.GetValue("DaysToKeepLogs", 2); }
            set { ConfigFileManager.Default.SetValue("DaysToKeepLogs", value); }
        }


        public static bool FilterTraceLevelEnabled
        {
            get { return ConfigFileManager.Default.GetValue("FilterTraceLevelEnabled", true); }
            set { ConfigFileManager.Default.SetValue("FilterTraceLevelEnabled", value); }
        }

        public static bool FilterInfoLevelEnabled
        {
            get { return ConfigFileManager.Default.GetValue("FilterInfoLevelEnabled", true); }
            set { ConfigFileManager.Default.SetValue("FilterInfoLevelEnabled", value); }
        }

        public static bool FilterWarningLevelEnabled
        {
            get { return ConfigFileManager.Default.GetValue("LogWarningLevelEnabled", true); }
            set { ConfigFileManager.Default.SetValue("FilterWarningLevelEnabled", value); }
        }

        public static bool FilterErrorLevelEnabled
        {
            get { return ConfigFileManager.Default.GetValue("FilterErrorLevelEnabled", true); }
            set { ConfigFileManager.Default.SetValue("FilterErrorLevelEnabled", value); }
        }

        public static int FilterLogLinesCount
        {
            get { return ConfigFileManager.Default.GetValue("FilterLogLinesCount", 20); }
            set { ConfigFileManager.Default.SetValue("FilterLogLinesCount", value); }
        }
        #endregion

        #region User interface persistence

        public static Point WindowLocation
        {
            get
            {
                Point point = new Point(100, 100);
                if (ApplicationInfo.IsSuiteApplication)
                {
                    point = new Point(Screen.PrimaryScreen.Bounds.Width / 6, Screen.PrimaryScreen.Bounds.Height / 6);
                }

                try
                {
                    string str = ConfigFileManager.Default.GetValue("WindowLocation");
                    if (!string.IsNullOrEmpty(str))
                    {
                        point = (Point)new PointConverter().ConvertFromInvariantString(str);
                    }
                }
                catch
                {
                }

                return point;
            }
            set
            {
                if ((value.X >= 0) && (value.Y >= 0))
                {
                    ConfigFileManager.Default.SetValue("WindowLocation", new PointConverter().ConvertToInvariantString(value));
                }
            }
        }

        public static Size WindowSize
        {
            get
            {
                Size size = new Size(800, 600);
                if (ApplicationInfo.IsSuiteApplication)
                {
                    size = new Size(2 * Screen.PrimaryScreen.Bounds.Width / 3, 2 * Screen.PrimaryScreen.Bounds.Height / 3);
                }
                    
                try
                {
                    string str = ConfigFileManager.Default.GetValue("WindowSize");
                    if (!string.IsNullOrEmpty(str))
                    {
                        size = (Size)new SizeConverter().ConvertFromInvariantString(str);
                    }
                }
                catch
                {
                }
                return size;
            }
            set
            {
                if ((value.Width >= 0) && (value.Height >= 0))
                {
                    ConfigFileManager.Default.SetValue("WindowSize", new SizeConverter().ConvertToInvariantString(value));
                }
            }
        }

        public static FormWindowState WindowState
        {
            get
            {
                try
                {
                    return (FormWindowState)ConfigFileManager.Default.GetValue("WindowState", (int)FormWindowState.Normal);
                }
                catch
                {
                }

                return FormWindowState.Normal;
            }
            set
            {
                ConfigFileManager.Default.SetValue("WindowState", (int)value);
            }
        }

        public static bool MimimizedToTray
        {
            get
            {
                return (ConfigFileManager.Default.GetValue("MimimizedToTray", false) && CanSendToTray);
            }

            set
            {
                ConfigFileManager.Default.SetValue("MimimizedToTray", value && CanSendToTray);
            }
        }

        public static bool CanSendToTray
        {
            get
            {
                return ConfigFileManager.Default.GetValue("CanSendToTray", false);
            }

            set
            {
                ConfigFileManager.Default.SetValue("CanSendToTray", value);
            }
        }
        
        #endregion

        #region Application state persistence
        public static string LastExploredFolder
        {
            get
            {
                return ConfigFileManager.Default.GetValue("LastExploredFolder", PathUtils.CurrentDir);
            }

            set
            {
                ConfigFileManager.Default.SetValue("LastExploredFolder", value);
            }
        }
        #endregion

        #endregion

        internal static bool RunProcess(string cmdLine, string args, bool wait, bool window = false)
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
