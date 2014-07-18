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

    public class AppSettings : IDisposable
    {
        protected ConfigFileManager _config = null;

        protected static AppSettings _instance = null;
        public static AppSettings Instance
        {
            get
            {
                return _instance;
            }
        }

        public static void RegisterAppInstance(AppSettings instance)
        {
            _instance = instance;
        }


        public AppSettings()
        {
            _config = new ConfigFileManager(ApplicationInfo.SettingsFile);
        }

        public void Dispose()
        {
            Save();
        }
        
        public void Save()
        {
            _config.Save();
        }

        public void Delete()
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
        public int KeepAliveInterval
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

        public IWebProxy GetWebProxy()
        {
            IWebProxy wp = null;
            ProxySettings ps = this.ProxySettings;

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
                
        public ProxySettings ProxySettings
        {
            get
            {
                ProxySettings ps = ProxySettings.Empty;
                ps.ProxyAddress = this.ProxyAddress;
                ps.ProxyPassword = this.ProxyPassword;
                ps.ProxyPort = this.ProxyPort;
                ps.ProxyType = this.ProxyType;
                ps.ProxyUser = this.ProxyUser;

                return ps;
            }

            set
            {
                this.ProxyAddress = value.ProxyAddress;
                this.ProxyPassword = value.ProxyPassword;
                this.ProxyPort = value.ProxyPort;
                this.ProxyType = value.ProxyType;
                this.ProxyUser = value.ProxyUser;
            }
        }

        protected ProxyType ProxyType
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

        protected string ProxyAddress
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

        protected int ProxyPort
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

        protected string ProxyUser
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

        protected string ProxyPassword
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

        public string GetDefaultLoggingFolder()
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

        public bool CanWriteToFolder(string path)
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

        public bool LogEnabled
        {
            get { return _config.GetValue("LogEnabled", true); }
            set { _config.SetValue("LogEnabled", value); }
        }

        public bool LogHeavyTraceLevelEnabled
        {
            get { return _config.GetValue("LogHeavyTraceLevelEnabled", true); }
            set { _config.SetValue("LogHeavyTraceLevelEnabled", value); }
        }

        public bool LogTraceLevelEnabled
        {
            get { return _config.GetValue("LogTraceLevelEnabled", true); }
            set { _config.SetValue("LogTraceLevelEnabled", value); }
        }

        public bool LogInfoLevelEnabled
        {
            get { return _config.GetValue("LogInfoLevelEnabled", true); }
            set { _config.SetValue("LogInfoLevelEnabled", value); }
        }

        public bool LogWarningLevelEnabled
        {
            get { return _config.GetValue("LogWarningLevelEnabled", true); }
            set { _config.SetValue("LogWarningLevelEnabled", value); }
        }

        public bool LogErrorLevelEnabled
        {
            get { return _config.GetValue("LogErrorLevelEnabled", true); }
            set { _config.SetValue("LogErrorLevelEnabled", value); }
        }

        public string LogFilePath
        {
            get { return _config.GetValue("LogFilePath", GetDefaultLoggingFolder()); }
            set { _config.SetValue("LogFilePath", value); }
        }

        public int DaysToKeepLogs
        {
            get { return _config.GetValue("DaysToKeepLogs", 2); }
            set { _config.SetValue("DaysToKeepLogs", value); }
        }


        public bool FilterTraceLevelEnabled
        {
            get { return _config.GetValue("FilterTraceLevelEnabled", true); }
            set { _config.SetValue("FilterTraceLevelEnabled", value); }
        }

        public bool FilterInfoLevelEnabled
        {
            get { return _config.GetValue("FilterInfoLevelEnabled", true); }
            set { _config.SetValue("FilterInfoLevelEnabled", value); }
        }

        public bool FilterWarningLevelEnabled
        {
            get { return _config.GetValue("LogWarningLevelEnabled", true); }
            set { _config.SetValue("FilterWarningLevelEnabled", value); }
        }

        public bool FilterErrorLevelEnabled
        {
            get { return _config.GetValue("FilterErrorLevelEnabled", true); }
            set { _config.SetValue("FilterErrorLevelEnabled", value); }
        }

        public int FilterLogLinesCount
        {
            get { return _config.GetValue("FilterLogLinesCount", 20); }
            set { _config.SetValue("FilterLogLinesCount", value); }
        }
        #endregion

        #region User interface persistence

        protected bool _allowSaveWindowLocation = true;
        public Point WindowLocation
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

        public Size WindowSize
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

        public FormWindowState WindowState
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

        public bool MimimizedToTray
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

        public bool CanSendToTray
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


        public bool FullScreenOn
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

        public Point DetachedWindowLocation
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

        public Size DetachedWindowSize
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

        public FormWindowState DetachedWindowState
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
        public string SearchPaths
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

        public string SearchTexts
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

        public string SearchPatterns
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


        public string SearchTextsMC
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

        public string SearchPatternsMC
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

        public int SplitterDistanceMC
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

        public int VSplitterDistance
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

        public int HSplitterDistance
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


        public string ExplorerLaunchType
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

        public int LastBalance
        {
            get
            {
                return _config.GetValue("LastBalance", 0);
            }

            set
            {
                _config.SetValue("LastBalance", value);
            }
        }

        public int LastVolume
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

        public int LastFilterIndex
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

        public string LastOpenedFolder
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

        public int PL_LastFilterIndex
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

        public string PL_LastOpenedFolder
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

        public string LastExploredFolder
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

        public string LastNavAddon
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

        public bool LoopPlay
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

        public bool ShufflePlaylist
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

        #region timer scheduler
        public int PlaylistEventHandler
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

        public string PlaylistEventData
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


        public int ScheduledEventHandler
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

        public string ScheduledEventData
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

        public TimeSpan ScheduledEventTime
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

        public int ScheduledEventDays
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

        public bool EnableScheduledEvent
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

        public int SchedulerWaitTimerProceed
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
        public int FEMaxProcessedFiles
        {
            get { return _config.GetValue("FEMaxProcessedFiles", 100); }
            set { _config.SetValue("FEMaxProcessedFiles", value); }
        }

        public decimal FEPreviewTimer
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

        public string MCLastOpenedFolder
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

        public bool MCOpenLastCatalog
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

        public bool MCRememberRecentFiles
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

        public int MCRecentFilesCount
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

        public string MCRecentFiles
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
        public bool DisableDVDMenu
        {
            get { return _config.GetValue("DisableDVDMenu", false); }
            set { _config.SetValue("DisableDVDMenu", value); }
        }
        #endregion

        #region Subtitle and OSD

        public int PrefferedSubtitleLang
        {
            get { return _config.GetValue("PrefferedSubtitleLang", 1033); }
            set { _config.SetValue("PrefferedSubtitleLang", value); }
        }

        public bool SubEnabled
        {
            get { return _config.GetValue("SubEnabled", false); }
            set { _config.SetValue("SubEnabled", value); }
        }

        public bool OsdEnabled
        {
            get { return _config.GetValue("OsdEnabled", false); }
            set { _config.SetValue("OsdEnabled", value); }
        }

        public Color OsdColor
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

        public Color SubColor
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

        public Font OsdFont
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

        public Font SubFont
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

        public int OsdPersistTimer
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

        public bool SubtitleDownloadEnabled
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

        public int SubtitleMinimumMovieDuration
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

        public bool MediaStateNotificationsEnabled
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

        public bool SubDownloadedNotificationsEnabled
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

        public bool UseMetadata
        {
            get { return _config.GetValue("UseMetadata", true); }
            set { _config.SetValue("UseMetadata", value); }
        }

        public bool UseFileNameFormat
        {
            get { return _config.GetValue("UseFileNameFormat", true); }
            set { _config.SetValue("UseFileNameFormat", value); }
        }

        public string PlaylistEntryFormat
        {
            get { return _config.GetValue("PlaylistEntryFormat", "<A> - <T>"); }
            set { _config.SetValue("PlaylistEntryFormat", value); }
        }

        public string FileNameFormat
        {
            get { return _config.GetValue("FileNameFormat", "<A> - <T>"); }
            set { _config.SetValue("FileNameFormat", value); }
        }

        public string CustomPlaylistEntryFormats
        {
            get { return _config.GetValue("CustomPlaylistEntryFormats", string.Empty); }
            set { _config.SetValue("CustomPlaylistEntryFormats", value); }
        }

        public string CustomFileNameFormats
        {
            get { return _config.GetValue("CustomFileNameFormats", string.Empty); }
            set { _config.SetValue("CustomFileNameFormats", value); }
        }

        #endregion

       

        
    }
}
