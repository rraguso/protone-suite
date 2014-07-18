using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Core.Logging;
using System.Collections.Specialized;
using System.Configuration;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Xml;
using OPMedia.Core.Configuration;
using OPMedia.Core;

namespace OPMedia.Core.Logging
{
    public class LoggingConfiguration
    {
        private static LoggingConfiguration instance = new LoggingConfiguration();

        private bool heavyTraceLevelEnabled = true;
        private bool traceLevelEnabled = true;
        private bool infoLevelEnabled = true;
        private bool warningLevelEnabled = true;
        private bool errorLevelEnabled = true;
        private bool loggingEnabled = true;
        private string logFilePath = AppConfig.GetDefaultLoggingFolder();
        private int daysToKeepLogs = 2;

        private LoggingConfiguration()
        {
            try
            {
                ReadConfiguration();
            }
            catch
            {
            }
        }

        public static bool HeavyTraceLevelEnabled
        {
            get
            {
#if HAVE_HEAVY_TRACE
                return instance.heavyTraceLevelEnabled;
#else   
                return false;
#endif
            }

            set
            {
#if HAVE_HEAVY_TRACE
                instance.heavyTraceLevelEnabled = value;
#endif
            }
        }

        public static bool TraceLevelEnabled
        {
            get
            {
                return instance.traceLevelEnabled;
            }
            set
            {
                instance.traceLevelEnabled = value;
            }
        }

        public static bool InfoLevelEnabled
        {
            get
            {
                return instance.infoLevelEnabled;
            }
            set
            {
                instance.infoLevelEnabled = value;
            }
        }

        public static bool WarningLevelEnabled
        {
            get
            {
                return instance.warningLevelEnabled;
            }

            set
            {
                instance.warningLevelEnabled = value;
            }
        }

        public static bool ErrorLevelEnabled
        {
            get
            {
                return instance.errorLevelEnabled;
            }

            set
            {
                instance.errorLevelEnabled = value;
            }
        }

        public static bool LoggingEnabled
        {
            get
            {
                return instance.loggingEnabled;
            }

            set
            {
                instance.loggingEnabled = value;
            }
        }

        public static string ReportEnabledLevels()
        {
            string retVal = string.Empty;
            if (LoggingEnabled)
            {
                if (TraceLevelEnabled)
                {
                    retVal += "LogTrace ";
                }
                if (InfoLevelEnabled)
                {
                    retVal += "LogInfo ";
                }
                if (WarningLevelEnabled)
                {
                    retVal += "LogWarning ";
                }
                if (ErrorLevelEnabled)
                {
                    retVal += "LogError ";
                }
                if (retVal.Length <= 0)
                {
                    retVal = "No logging levels defined. Only exceptions will be logged.";
                }
            }
            return retVal;
        }

        public static string LogFilePath
        {
            get
            {
                return instance.logFilePath;
            }

            set
            {
                instance.logFilePath = value;
            }
        }

        public static int DaysToKeepLogs
        {
            get
            {
                return instance.daysToKeepLogs;
            }

            set
            {
                instance.daysToKeepLogs = value;
            }
        }

        private void ReadConfiguration()
        {
            
            loggingEnabled = AppConfig.LogEnabled;
            traceLevelEnabled = AppConfig.LogTraceLevelEnabled;
            infoLevelEnabled = AppConfig.LogInfoLevelEnabled;
            warningLevelEnabled = AppConfig.LogWarningLevelEnabled;
            errorLevelEnabled = AppConfig.LogErrorLevelEnabled;

            heavyTraceLevelEnabled = AppConfig.LogHeavyTraceLevelEnabled;
            logFilePath = AppConfig.LogFilePath;
            daysToKeepLogs = AppConfig.DaysToKeepLogs;
        }

        public static void SaveConfiguration()
        {
            if (AppConfig.LogEnabled != instance.loggingEnabled)
                AppConfig.LogEnabled = instance.loggingEnabled;

            if (AppConfig.LogTraceLevelEnabled != instance.traceLevelEnabled)
                AppConfig.LogTraceLevelEnabled = instance.traceLevelEnabled;

            if (AppConfig.LogInfoLevelEnabled != instance.infoLevelEnabled)
                AppConfig.LogInfoLevelEnabled = instance.infoLevelEnabled;

            if (AppConfig.LogWarningLevelEnabled != instance.warningLevelEnabled)
                AppConfig.LogWarningLevelEnabled = instance.warningLevelEnabled;

            if (AppConfig.LogErrorLevelEnabled != instance.errorLevelEnabled)
                AppConfig.LogErrorLevelEnabled = instance.errorLevelEnabled;

            if (AppConfig.LogHeavyTraceLevelEnabled != instance.heavyTraceLevelEnabled)
                AppConfig.LogHeavyTraceLevelEnabled = instance.heavyTraceLevelEnabled;

            if (AppConfig.LogFilePath != instance.logFilePath)
                AppConfig.LogFilePath = instance.logFilePath;

            if (AppConfig.DaysToKeepLogs != instance.daysToKeepLogs)
                AppConfig.DaysToKeepLogs = instance.daysToKeepLogs;
        }
    }
}

