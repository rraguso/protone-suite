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
        public static void Save()
        {
            ConfigFileManager.Default.Save();
        }

        #region Level 1 settings using Settings File (Combined per-app and per-user settings)

        #region Network preferences
        public static int KeepAliveInterval
        {
            get
            {
                return ConfigFileManager.Default.GetValue("KeepAliveInterval", 5 * 60 * 1000);
            }
            set
            {
                ConfigFileManager.Default.SetValue("KeepAliveInterval", value);
            }
        }

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


        public static bool FullScreenOn
        {
            get
            {
                return ConfigFileManager.Default.GetValue("FullScreenOn", false);
            }

            set
            {
                ConfigFileManager.Default.SetValue("FullScreenOn", value);
            }
        }

        public static Point DetachedWindowLocation
        {
            get
            {
                try
                {
                    string str = ConfigFileManager.Default.GetValue("DetachedWindowLocation");
                    if (!string.IsNullOrEmpty(str))
                    {
                        return (Point)new PointConverter().ConvertFromInvariantString(str);
                    }
                }
                catch
                {
                }

                Point ptFallback = new Point(100, 100);

                ConfigFileManager.Default.SetValue("DetachedWindowLocation", new PointConverter().ConvertToInvariantString(ptFallback));

                return ptFallback;
            }
            set
            {
                if ((value.X >= 0) && (value.Y >= 0))
                {
                    ConfigFileManager.Default.SetValue("DetachedWindowLocation", new PointConverter().ConvertToInvariantString(value));
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
                    string str = ConfigFileManager.Default.GetValue("DetachedWindowSize");
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
                    ConfigFileManager.Default.SetValue("DetachedWindowSize", new SizeConverter().ConvertToInvariantString(value));
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
                    normal = (FormWindowState)ConfigFileManager.Default.GetValue("DetachedWindowState", 0);
                }
                catch
                {
                }
                return normal;
            }
            set
            {
                ConfigFileManager.Default.SetValue("DetachedWindowState", (int)value);
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


        #region Application state persistence

        


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

        #endregion

        #region timer scheduler
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

        #endregion


        #region Media catalog addon

        

        #endregion

        #region DVD Information
        public static bool DisableDVDMenu
        {
            get { return ConfigFileManager.Default.GetValue("DisableDVDMenu", false); }
            set { ConfigFileManager.Default.SetValue("DisableDVDMenu", value); }
        }
        #endregion

        #region Subtitle and OSD

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
        #endregion

        #region Playlist formatting

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
