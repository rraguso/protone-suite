#define _LOG_ 

using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.Logging;
using System.Collections.Specialized;
using System.Configuration;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Xml;
using OPMedia.Runtime.ApplicationSettings;
using OPMedia.OSDependentLayer;

namespace OPMedia.Runtime.Logging
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
        private string logFilePath = AppSettings.GetDefaultLoggingFolder();
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

        public static bool IsDebugConfig
        {
            get
            {
#if (DEBUG && _LOG_)                
                return true;
#else
                return false;
#endif
            }
        }

        public static bool HeavyTraceLevelEnabled
        {
            get
            {
                return instance.heavyTraceLevelEnabled && IsDebugConfig;
            }

            set
            {
                instance.heavyTraceLevelEnabled = value && IsDebugConfig;
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
            if (IsDebugConfig)
            {
                loggingEnabled = true;
                traceLevelEnabled = true;
                infoLevelEnabled = true;
                warningLevelEnabled = true;
                errorLevelEnabled = true;
            }
            else
            {
                loggingEnabled = AppSettings.LogEnabled;
                traceLevelEnabled = AppSettings.LogTraceLevelEnabled;
                infoLevelEnabled = AppSettings.LogInfoLevelEnabled;
                warningLevelEnabled = AppSettings.LogWarningLevelEnabled;
                errorLevelEnabled = AppSettings.LogErrorLevelEnabled;
            }

            heavyTraceLevelEnabled = AppSettings.LogHeavyTraceLevelEnabled;
            logFilePath = AppSettings.LogFilePath;
            daysToKeepLogs = AppSettings.DaysToKeepLogs;
        }

        public static void SaveConfiguration()
        {
            if (AppSettings.LogEnabled != instance.loggingEnabled)
                AppSettings.LogEnabled = instance.loggingEnabled;

            if (AppSettings.LogTraceLevelEnabled != instance.traceLevelEnabled)
                AppSettings.LogTraceLevelEnabled = instance.traceLevelEnabled;

            if (AppSettings.LogInfoLevelEnabled != instance.infoLevelEnabled)
                AppSettings.LogInfoLevelEnabled = instance.infoLevelEnabled;

            if (AppSettings.LogWarningLevelEnabled != instance.warningLevelEnabled)
                AppSettings.LogWarningLevelEnabled = instance.warningLevelEnabled;

            if (AppSettings.LogErrorLevelEnabled != instance.errorLevelEnabled)
                AppSettings.LogErrorLevelEnabled = instance.errorLevelEnabled;

            if (AppSettings.LogHeavyTraceLevelEnabled != instance.heavyTraceLevelEnabled)
                AppSettings.LogHeavyTraceLevelEnabled = instance.heavyTraceLevelEnabled;

            if (AppSettings.LogFilePath != instance.logFilePath)
                AppSettings.LogFilePath = instance.logFilePath;

            if (AppSettings.DaysToKeepLogs != instance.daysToKeepLogs)
                AppSettings.DaysToKeepLogs = instance.daysToKeepLogs;
        }
    }
}

