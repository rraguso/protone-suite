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

namespace OPMedia.Core.ApplicationSettings
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

    public static class AppSettings
    {
        private static ConfigFileManager _config = null;

        static AppSettings()
        {
            _config = new ConfigFileManager(ApplicationInfo.SettingsFile);
        }

        public static void Save()
        {
            _config.Save();
        }

        public static void Delete()
        {
            try
            {
                File.Delete(ApplicationInfo.SettingsFile);
            }
            catch(Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }

            try
            {
                Directory.Delete(ApplicationInfo.SettingsFolder);
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        #region Network preferences
        public static int KeepAliveInterval
        {
            get
            {
                return _config.GetValue("KeepAliveInterval", 5 * 60 * 1000);
            }
            set
            {
                _config.SetValue("KeepAliveInterval", value);
            }
        }

        public static IWebProxy GetWebProxy()
        {
            IWebProxy wp = null;
            ProxySettings ps = AppSettings.ProxySettings;

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
                ps.ProxyAddress = AppSettings.ProxyAddress;
                ps.ProxyPassword = AppSettings.ProxyPassword;
                ps.ProxyPort = AppSettings.ProxyPort;
                ps.ProxyType = AppSettings.ProxyType;
                ps.ProxyUser = AppSettings.ProxyUser;

                return ps;
            }

            set
            {
                AppSettings.ProxyAddress = value.ProxyAddress;
                AppSettings.ProxyPassword = value.ProxyPassword;
                AppSettings.ProxyPort = value.ProxyPort;
                AppSettings.ProxyType = value.ProxyType;
                AppSettings.ProxyUser = value.ProxyUser;
            }
        }

        private static ProxyType ProxyType
        {
            get
            {
                return (ProxyType)_config.GetValue("ProxyType", (int)ProxyType.NoProxy);
            }
            set
            {
                _config.SetValue("ProxyType", (int)value);
            }
        }

        private static string ProxyAddress
        {
            get
            {
                return _config.GetValue("ProxyAddress", "your.proxy.address");
            }
            set
            {
                _config.SetValue("ProxyAddress", value);
            }
        }

        private static int ProxyPort
        {
            get
            {
                return _config.GetValue("ProxyPort", 8080);
            }
            set
            {
                _config.SetValue("ProxyPort", value);
            }
        }

        private static string ProxyUser
        {
            get
            {
                return _config.GetValue("ProxyUser", "user.name");
            }
            set
            {
                _config.SetValue("ProxyUser", value);
            }
        }

        private static string ProxyPassword
        {
            get
            {
                return _config.GetValue("ProxyPassword", string.Empty);
            }
            set
            {
                _config.SetValue("ProxyPassword", value);
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
            get { return _config.GetValue("LogEnabled", true) && !SuiteConfiguration.LogFullyDisabled; }
            set { _config.SetValue("LogEnabled", value); }
        }

        public static bool LogHeavyTraceLevelEnabled
        {
            get { return _config.GetValue("LogHeavyTraceLevelEnabled", true); }
            set { _config.SetValue("LogHeavyTraceLevelEnabled", value); }
        }

        public static bool LogTraceLevelEnabled
        {
            get { return _config.GetValue("LogTraceLevelEnabled", true); }
            set { _config.SetValue("LogTraceLevelEnabled", value); }
        }

        public static bool LogInfoLevelEnabled
        {
            get { return _config.GetValue("LogInfoLevelEnabled", true); }
            set { _config.SetValue("LogInfoLevelEnabled", value); }
        }

        public static bool LogWarningLevelEnabled
        {
            get { return _config.GetValue("LogWarningLevelEnabled", true); }
            set { _config.SetValue("LogWarningLevelEnabled", value); }
        }

        public static bool LogErrorLevelEnabled
        {
            get { return _config.GetValue("LogErrorLevelEnabled", true); }
            set { _config.SetValue("LogErrorLevelEnabled", value); }
        }

        public static string LogFilePath
        {
            get { return _config.GetValue("LogFilePath", GetDefaultLoggingFolder()); }
            set { _config.SetValue("LogFilePath", value); }
        }

        public static int DaysToKeepLogs
        {
            get { return _config.GetValue("DaysToKeepLogs", 2); }
            set { _config.SetValue("DaysToKeepLogs", value); }
        }


        public static bool FilterTraceLevelEnabled
        {
            get { return _config.GetValue("FilterTraceLevelEnabled", true); }
            set { _config.SetValue("FilterTraceLevelEnabled", value); }
        }

        public static bool FilterInfoLevelEnabled
        {
            get { return _config.GetValue("FilterInfoLevelEnabled", true); }
            set { _config.SetValue("FilterInfoLevelEnabled", value); }
        }

        public static bool FilterWarningLevelEnabled
        {
            get { return _config.GetValue("LogWarningLevelEnabled", true); }
            set { _config.SetValue("FilterWarningLevelEnabled", value); }
        }

        public static bool FilterErrorLevelEnabled
        {
            get { return _config.GetValue("FilterErrorLevelEnabled", true); }
            set { _config.SetValue("FilterErrorLevelEnabled", value); }
        }

        public static int FilterLogLinesCount
        {
            get { return _config.GetValue("FilterLogLinesCount", 20); }
            set { _config.SetValue("FilterLogLinesCount", value); }
        }
        #endregion

        #region User interface persistence

        private static bool _allowSaveWindowLocation = true;
        public static Point WindowLocation
        {
            get
            {
                Point point = new Point(100, 100);
                if (ApplicationInfo.IsPlayer)
                {
                    point = new Point((Screen.PrimaryScreen.Bounds.Width - 440) / 2, (Screen.PrimaryScreen.Bounds.Height - 300) / 2);
                }
                else if (ApplicationInfo.IsMediaLibrary)
                {
                    point = new Point(Screen.PrimaryScreen.Bounds.Width / 6, Screen.PrimaryScreen.Bounds.Height / 6);
                }
                else if (ApplicationInfo.IsRCCManager)
                {
                    point = new Point((Screen.PrimaryScreen.Bounds.Width - 510) / 2, (Screen.PrimaryScreen.Bounds.Height - 430) / 2);
                }

                try
                {
                    string str = _config.GetValue("WindowLocation");
                    if (!string.IsNullOrEmpty(str))
                    {
                        point = (Point)new PointConverter().ConvertFromInvariantString(str);
                    }
                }
                catch
                {
                }

                return point;
                //return GetValidMonitorLocation(point, ref _allowSaveWindowLocation);
            }
            set
            {
                if (_allowSaveWindowLocation && (value.X >= 0) && (value.Y >= 0))
                {
                    _config.SetValue("WindowLocation", new PointConverter().ConvertToInvariantString(value));
                }
            }
        }

        public static Size WindowSize
        {
            get
            {
                Size size = new Size(800, 600);
                if (ApplicationInfo.IsPlayer)
                {
                    size = new Size(440, 300);
                }
                else if (ApplicationInfo.IsMediaLibrary)
                {
                    size = new Size(2 * Screen.PrimaryScreen.Bounds.Width / 3, 2 * Screen.PrimaryScreen.Bounds.Height / 3);
                }
                else if (ApplicationInfo.IsRCCManager)
                {
                    size = new Size(510, 430);
                }
                    
                try
                {
                    string str = _config.GetValue("WindowSize");
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
                    _config.SetValue("WindowSize", new SizeConverter().ConvertToInvariantString(value));
                }
            }
        }

        public static FormWindowState WindowState
        {
            get
            {
                try
                {
                    return (FormWindowState)_config.GetValue("WindowState", (int)FormWindowState.Normal);
                }
                catch
                {
                }

                return FormWindowState.Normal;
            }
            set
            {
                _config.SetValue("WindowState", (int)value);
            }
        }

        public static bool MimimizedToTray
        {
            get
            {
                return (_config.GetValue("MimimizedToTray", false) && CanSendToTray);
            }

            set
            {
                _config.SetValue("MimimizedToTray", value && CanSendToTray);
            }
        }

        public static bool CanSendToTray
        {
            get
            {
                return _config.GetValue("CanSendToTray", false);
            }

            set
            {
                _config.SetValue("CanSendToTray", value);
            }
        }


        public static bool FullScreenOn
        {
            get
            {
                return _config.GetValue("FullScreenOn", false);
            }

            set
            {
                _config.SetValue("FullScreenOn", value);
            }
        }

        public static int RenderPanelWidth
        {
            get
            {
                return _config.GetValue("RenderPanelWidth", 400);
            }

            set
            {
                _config.SetValue("RenderPanelWidth", value);
            }
        }

        public static int HideMouseTimer
        {
            get
            {
                return _config.GetValue("HideMouseTimer", 6000);
            }

            set
            {
                _config.SetValue("HideMouseTimer", value);
            }
        }

        public static bool IgnoreMouseMove
        {
            get
            {
                return _config.GetValue("IgnoreMouseMove", true);
            }

            set
            {
                _config.SetValue("IgnoreMouseMove", value);
            }
        }

        public static Point DetachedWindowLocation
        {
            get
            {
                try
                {
                    string str = _config.GetValue("DetachedWindowLocation");
                    if (!string.IsNullOrEmpty(str))
                    {
                        return (Point)new PointConverter().ConvertFromInvariantString(str);
                    }
                }
                catch
                {
                }

                Point ptFallback = new Point(100, 100);

                _config.SetValue("DetachedWindowLocation", new PointConverter().ConvertToInvariantString(ptFallback));

                return ptFallback;
            }
            set
            {
                if ((value.X >= 0) && (value.Y >= 0))
                {
                    _config.SetValue("DetachedWindowLocation", new PointConverter().ConvertToInvariantString(value));
                }
            }
        }

        public static Size DetachedWindowSize
        {
            get
            {
                Size size = new Size(800, 600);
                try
                {
                    string str = _config.GetValue("DetachedWindowSize");
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
                    _config.SetValue("DetachedWindowSize", new SizeConverter().ConvertToInvariantString(value));
                }
            }
        }

        public static FormWindowState DetachedWindowState
        {
            get
            {
                FormWindowState normal = FormWindowState.Normal;
                try
                {
                    normal = (FormWindowState)_config.GetValue("DetachedWindowState", 0);
                }
                catch
                {
                }
                return normal;
            }
            set
            {
                _config.SetValue("DetachedWindowState", (int)value);
            }
        }

        
        #endregion

        #region Application state persistence
        public static string SearchPaths
        {
            get
            {
                return _config.GetValue("SearchPaths", string.Empty);
            }

            set
            {
                _config.SetValue("SearchPaths", value);
            }
        }

        public static string SearchTexts
        {
            get
            {
                return _config.GetValue("SearchTexts", string.Empty);
            }

            set
            {
                _config.SetValue("SearchTexts", value);
            }
        }

        public static string SearchPatterns
        {
            get
            {
                return _config.GetValue("SearchPatterns", string.Empty);
            }

            set
            {
                _config.SetValue("SearchPatterns", value);
            }
        }


        public static string SearchTextsMC
        {
            get
            {
                return _config.GetValue("SearchTextsMC", string.Empty);
            }

            set
            {
                _config.SetValue("SearchTextsMC", value);
            }
        }

        public static string SearchPatternsMC
        {
            get
            {
                return _config.GetValue("SearchPatternsMC", string.Empty);
            }

            set
            {
                _config.SetValue("SearchPatternsMC", value);
            }
        }

        public static int SplitterDistanceMC
        {
            get
            {
                return _config.GetValue("SplitterDistanceMC", 200);
            }

            set
            {
                _config.SetValue("SplitterDistanceMC", value);
            }
        }

        public static int VSplitterDistance
        {
            get
            {
                return _config.GetValue("VSplitterDistance", 
                    4 * Screen.PrimaryScreen.Bounds.Width / 9);
            }

            set
            {
                _config.SetValue("VSplitterDistance", value);
            }
        }

        public static int HSplitterDistance
        {
            get
            {
                return _config.GetValue("HSplitterDistance",
                    Screen.PrimaryScreen.Bounds.Height / 3 - 50);
            }

            set
            {
                _config.SetValue("HSplitterDistance", value);
            }
        }


        public static string ExplorerLaunchType
        {
            get
            {
                return _config.GetValue("ExplorerLaunchType", "EnqueueFiles");
            }

            set
            {
                _config.SetValue("ExplorerLaunchType", value);
            }
        }

        public static int LastVolume
        {
            get
            {
                return _config.GetValue("LastVolume", 5000);
            }

            set
            {
                _config.SetValue("LastVolume", value);
            }
        }

        public static int LastFilterIndex
        {
            get
            {
                return _config.GetValue("LastFilterIndex", 0);
            }

            set
            {
                _config.SetValue("LastFilterIndex", value);
            }
        }

        public static string LastOpenedFolder
        {
            get
            {
                return _config.GetValue("LastOpenedFolder", PathUtils.CurrentDir);
            }

            set
            {
                _config.SetValue("LastOpenedFolder", value);
            }
        }

        public static int PL_LastFilterIndex
        {
            get
            {
                return _config.GetValue("PL_LastFilterIndex", 0);
            }

            set
            {
                _config.SetValue("PL_LastFilterIndex", value);
            }
        }

        public static string PL_LastOpenedFolder
        {
            get
            {
                return _config.GetValue("PL_LastOpenedFolder", PathUtils.CurrentDir);
            }

            set
            {
                _config.SetValue("PL_LastOpenedFolder", value);
            }
        }

        public static string LastExploredFolder
        {
            get
            {
                return _config.GetValue("LastExploredFolder", PathUtils.CurrentDir);
            }

            set
            {
                _config.SetValue("LastExploredFolder", value);
            }
        }

        public static string LastNavAddon
        {
            get
            {
                return _config.GetValue("LastNavAddon", "FileExplorer");
            }

            set
            {
                _config.SetValue("LastNavAddon", value);
            }
        }

        public static bool LoopPlay
        {
            get
            {
                return _config.GetValue("LoopPlay", false);
            }

            set
            {
                _config.SetValue("LoopPlay", value);
            }
        }

        public static bool ShufflePlaylist
        {
            get
            {
                return _config.GetValue("ShufflePlaylist", true);
            }

            set
            {
                _config.SetValue("ShufflePlaylist", value);
            }
        }

        #endregion

        #region Remote control and communication
        public static bool AllowRemoteCommands
        {
            get
            {
                return _config.GetValue("AllowRemoteCommands", false);
            }

            set
            {
                _config.SetValue("AllowRemoteCommands", value);
            }
        }
        #endregion

        #region timer scheduler
        public static int PlaylistEventHandler
        {
            get
            {
                return _config.GetValue("PlaylistEventHandler", 0);
            }
            set
            {
                _config.SetValue("PlaylistEventHandler", value);
            }
        }

        public static string PlaylistEventData
        {
            get
            {
                return _config.GetValue("PlaylistEventData", string.Empty);
            }
            set
            {
                _config.SetValue("PlaylistEventData", value);
            }
        }


        public static int ScheduledEventHandler
        {
            get
            {
                return _config.GetValue("ScheduledEventHandler", 0);
            }
            set
            {
                _config.SetValue("ScheduledEventHandler", value);
            }
        }

        public static string ScheduledEventData
        {
            get
            {
                return _config.GetValue("ScheduledEventData", string.Empty);
            }
            set
            {
                _config.SetValue("ScheduledEventData", value);
            }
        }

        public static TimeSpan ScheduledEventTime
        {
            get
            {
                return _config.GetValue("ScheduledEventTime", new TimeSpan(0, 0, 0));
            }
            set
            {
                _config.SetValue("ScheduledEventTime", value);
            }
        }

        public static int ScheduledEventDays
        {
            get
            {
                return _config.GetValue("ScheduledEventDays", 0);
            }
            set
            {
                _config.SetValue("ScheduledEventDays", value);
            }
        }

        public static bool EnableScheduledEvent
        {
            get
            {
                return _config.GetValue("EnableScheduledEvent", false);
            }
            set
            {
                _config.SetValue("EnableScheduledEvent", value);
            }
        }

        public static int SchedulerWaitTimerProceed
        {
            get
            {
                return _config.GetValue("SchedulerWaitTimerProceed", 2);
            }
            set
            {
                _config.SetValue("SchedulerWaitTimerProceed", value);
            }
        }

        #endregion

        #region File explorer addon
        public static int FEMaxProcessedFiles
        {
            get { return _config.GetValue("FEMaxProcessedFiles", 100); }
            set { _config.SetValue("FEMaxProcessedFiles", value); }
        }

        public static decimal FEPreviewTimer
        {
            get 
            {
                try
                {
                    return (decimal)new DecimalConverter().ConvertFromInvariantString(
                        _config.GetValue("FEPreviewTimer",
                            new DecimalConverter().ConvertToInvariantString(0.5M)));
                }
                catch { }

                return 0.5M; 
            }

            set 
            { 
                _config.SetValue("FEPreviewTimer", 
                    new DecimalConverter().ConvertToInvariantString(value)); 
            }
        }
        #endregion

        #region Media catalog addon

        public static string MCLastOpenedFolder
        {
            get
            {
                return _config.GetValue("MCLastOpenedFolder", string.Empty);
            }
            set
            {
                _config.SetValue("MCLastOpenedFolder", value);
            }
        }

        public static bool MCOpenLastCatalog
        {
            get
            {
                return _config.GetValue("MCOpenLastCatalog", false);
            }
            set
            {
                _config.SetValue("MCOpenLastCatalog", value);
            }
        }

        public static bool MCRememberRecentFiles
        {
            get
            {
                return _config.GetValue("MCRememberRecentFiles", false);
            }
            set
            {
                _config.SetValue("MCRememberRecentFiles", value);
            }
        }

        public static int MCRecentFilesCount
        {
            get
            {
                return _config.GetValue("MCRecentFilesCount", 5);
            }
            set
            {
                _config.SetValue("MCRecentFilesCount", value);
            }
        }

        public static string MCRecentFiles
        {
            get
            {
                return _config.GetValue("MCRecentFiles", string.Empty);
            }
            set
            {
                _config.SetValue("MCRecentFiles", value);
            }
        }

        #endregion

        #region DVD Information
        public static int DVDScannerInterval
        {
            get { return _config.GetValue("DVDScannerInterval", 5); }
            set { _config.SetValue("DVDScannerInterval", value); }
        }

        public static bool DisableDVDMenu
        {
            get { return _config.GetValue("DisableDVDMenu", false); }
            set { _config.SetValue("DisableDVDMenu", value); }
        }
        #endregion

        #region Bookmark management
        public static bool GroupBookmarkWithMedia
        {
            get
            {
                return _config.GetValue("GroupBookmarkWithMedia", true);
            }
            set
            {
                _config.SetValue("GroupBookmarkWithMedia", value);
            }
        }
        #endregion

        #region Subtitle and OSD

        public static int SUB_LastFilterIndex
        {
            get
            {
                return _config.GetValue("SUB_LastFilterIndex", 0);
            }

            set
            {
                _config.SetValue("SUB_LastFilterIndex", value);
            }
        }

        public static string SUB_LastOpenedFolder
        {
            get
            {
                return _config.GetValue("SUB_LastOpenedFolder", PathUtils.CurrentDir);
            }

            set
            {
                _config.SetValue("SUB_LastOpenedFolder", value);
            }
        }

        public static int PrefferedSubtitleLang
        {
            get { return _config.GetValue("PrefferedSubtitleLang", 1033); }
            set { _config.SetValue("PrefferedSubtitleLang", value); }
        }

        public static bool SubEnabled
        {
            get { return _config.GetValue("SubEnabled", false); }
            set { _config.SetValue("SubEnabled", value); }
        }

        public static bool OsdEnabled
        {
            get { return _config.GetValue("OsdEnabled", false); }
            set { _config.SetValue("OsdEnabled", value); }
        }

        public static Color OsdColor
        {
            get
            {
                int argb = _config.GetValue("OsdColor", Color.White.ToArgb());
                return Color.FromArgb(argb);
            }

            set
            {
                _config.SetValue("OsdColor", value.ToArgb());
            }
        }

        public static Color SubColor
        {
            get
            {
                int argb = _config.GetValue("SubColor", Color.White.ToArgb());
                return Color.FromArgb(argb);
            }

            set
            {
                _config.SetValue("SubColor", value.ToArgb());
            }
        }

        static Font DefSubAndOsdFont = new Font("Segoe UI", 12f, FontStyle.Bold, GraphicsUnit.Point);

        public static Font OsdFont
        {
            get
            {
                string _f = _config.GetValue("OsdFont", new FontConverter().ConvertToInvariantString(DefSubAndOsdFont));
                Font f = (Font)new FontConverter().ConvertFromInvariantString(_f);
                byte charSet = (byte)_config.GetValue("OsdFontCharSet", DefSubAndOsdFont.GdiCharSet);
                return new Font(f.FontFamily, f.Size, f.Style, f.Unit, charSet);
            }

            set
            {
                _config.SetValue("OsdFont", new FontConverter().ConvertToInvariantString(value));
                _config.SetValue("OsdFontCharSet", value.GdiCharSet);
            }
        }

        public static Font SubFont
        {
            get
            {
                string _f = _config.GetValue("SubFont", new FontConverter().ConvertToInvariantString(DefSubAndOsdFont));
                Font f = (Font)new FontConverter().ConvertFromInvariantString(_f);
                byte charSet = (byte)_config.GetValue("SubFontCharSet", DefSubAndOsdFont.GdiCharSet);
                return new Font(f.FontFamily, f.Size, f.Style, f.Unit, charSet);
            }

            set
            {
                _config.SetValue("SubFont", new FontConverter().ConvertToInvariantString(value));
                _config.SetValue("SubFontCharSet", value.GdiCharSet);
            }
        }

        public static int OsdPersistTimer
        {
            get
            {
                return _config.GetValue("OsdPersistTimer", 4000);
            }

            set
            {
                _config.SetValue("OsdPersistTimer", value);
            }
        }

        public static bool SubtitleDownloadEnabled
        {
            get
            {
                return _config.GetValue("SubtitleDownloadEnabled", true);
            }

            set
            {
                _config.SetValue("SubtitleDownloadEnabled", value);
            }
        }

        public static string SubtitleDownloadURIs
        {
            get
            {
                return _config.GetValue("SubtitleDownloadURIs", SuiteConfiguration.DefaultSubtitleURIs);
            }

            set
            {
                _config.SetValue("SubtitleDownloadURIs", value);
            }
        }

        public static int SubtitleMinimumMovieDuration
        {
            get
            {
                return _config.GetValue("SubtitleMinimumMovieDuration", 20 /* 20 minutes */);
            }

            set
            {
                _config.SetValue("SubtitleMinimumMovieDuration", value);
            }
        }

        public static bool MediaStateNotificationsEnabled
        {
            get
            {
                return _config.GetValue("MediaStateNotificationsEnabled", true);
            }

            set
            {
                _config.SetValue("MediaStateNotificationsEnabled", value);
            }
        }

        public static bool SubDownloadedNotificationsEnabled
        {
            get
            {
                return _config.GetValue("SubDownloadedNotificationsEnabled", true);
            }

            set
            {
                _config.SetValue("SubDownloadedNotificationsEnabled", value);
            }
        }
        #endregion

        #region Playlist formatting

        public static bool UseMetadata
        {
            get { return _config.GetValue("UseMetadata", true); }
            set { _config.SetValue("UseMetadata", value); }
        }

        public static bool UseFileNameFormat
        {
            get { return _config.GetValue("UseFileNameFormat", true); }
            set { _config.SetValue("UseFileNameFormat", value); }
        }

        public static string PlaylistEntryFormat
        {
            get { return _config.GetValue("PlaylistEntryFormat", "<A> - <T>"); }
            set { _config.SetValue("PlaylistEntryFormat", value); }
        }

        public static string FileNameFormat
        {
            get { return _config.GetValue("FileNameFormat", "<A> - <T>"); }
            set { _config.SetValue("FileNameFormat", value); }
        }

        public static string CustomPlaylistEntryFormats
        {
            get { return _config.GetValue("CustomPlaylistEntryFormats", string.Empty); }
            set { _config.SetValue("CustomPlaylistEntryFormats", value); }
        }

        public static string CustomFileNameFormats
        {
            get { return _config.GetValue("CustomFileNameFormats", string.Empty); }
            set { _config.SetValue("CustomFileNameFormats", value); }
        }

        #endregion

        #region Monitor Affinity

        public static string PreferredMonitorName
        {
            get { return _config.GetValue("PreferredMonitorName", "DISPLAY1"); }
            set { _config.SetValue("PreferredMonitorName", value); }
        }

        public static string FallbackMonitorName
        {
            get { return _config.GetValue("FallbackMonitorName", "DISPLAY1"); }
            set { _config.SetValue("FallbackMonitorName", value); }
        }

        #endregion

        #region Non-Suite settings
        public static string LanguageID
        {
            get
            {
                return _config.GetValue("LanguageID", "en");
            }

            set
            {
                _config.SetValue("LanguageID", value);
            }
        }

        public static int SkinType
        {
            get
            {
                return _config.GetValue("SkinType", (int)Theme.Default.Value);
            }

            set
            {
                _config.SetValue("SkinType", value);
            }
        }
        #endregion
    }
}
