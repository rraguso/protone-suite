#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Threading;
using System.ComponentModel;
using System.IO;
using System.Globalization;
using OPMedia.OSDependentLayer;
#endregion

namespace OPMedia.Runtime.Logging
{
    #region Logger
    public class Logger
    {
        const string LogDateFormat = "dd-MM-yyyy";

        static object _readWriteLock = new object();

        #region Members
        private static Logger instance = new Logger();
        private Queue<LogEntry> entries = new Queue<LogEntry>();
        private System.Threading.Thread loggerThread = null;
        private bool loggerThreadMustRun = true;
        private static long sessionID;

        private static string assemblyLocation;
        private static string logFileFolder;

        #endregion

        #region Methods
        public static void CopyCurrentLogFile(string path)
        {
            string fileName = GetCurrentLogFileName();
            if (!string.IsNullOrEmpty(fileName))
            {
                File.Copy(fileName, path, true);
            }

            Logger.LogInfo("Log file contents was copied to: " + path);
        }

        public static void PurgeCurrentLogFile()
        {
            string fileName = GetCurrentLogFileName();
            if (!string.IsNullOrEmpty(fileName))
            {
                File.Delete(fileName);
            }

            Logger.LogInfo("Log file contents was purged.");
        }

        public static string GetCurrentLogFolder()
        {
            return logFileFolder;
        }

        public static string GetCurrentLogFileName()
        {
            string currentDayStamp = DateTime.Now.ToString(LogDateFormat);
            string appName = Assembly.GetEntryAssembly().GetName().Name;

            string logFilePath =
                System.IO.Path.Combine(logFileFolder, appName + "_" + currentDayStamp + ".log");

            if (File.Exists(logFilePath))
            {
                return logFilePath;
            }

            return string.Empty;
        }

        public static List<string> GetCurrentLogFileLines(SeverityLevels filter)
        {
            return GetCurrentLogFileLines(filter, 0);
        }

        public static List<string> GetCurrentLogFileLines(SeverityLevels filter, int lineCount)
        {
            return GetCurrentLogFileLines(filter, lineCount, false);
        }

        public static List<string> GetCurrentLogFileLines(SeverityLevels filter, int lineCount, bool lastRows)
        {
            string logFile = GetCurrentLogFileName();
            lock (_readWriteLock)
            {
                return GetLogFileLines(filter, logFile, lineCount, lastRows);
            }
        }

        public static List<string> GetLogFileLines(SeverityLevels filter, string logFile, int lineCount, bool lastRows)
        {
            return LogFileReader.ReadLogFileLines(filter, logFile, lineCount, lastRows);
        }

        public static void LogTranslationTrace(string format, params object[] args)
        {
            string message = string.Format(format, args);
#if DEBUG
            Debug.WriteLine("UNTRANSLATED: " + message);
#endif
            if (LoggingConfiguration.HeavyTraceLevelEnabled)
            {
                LogEntry entry = new LogEntry(SeverityLevels.HeavyTrace, message,
                    Assembly.GetCallingAssembly().GetName().Name);
                instance.EnqueueLogEntry(entry);
            }
        }

        public static void LogHelpTrace(string format, params object[] args)
        {
            string message = string.Format(format, args);
#if DEBUG
            Debug.WriteLine("HELP: " + message);
#endif
            if (LoggingConfiguration.HeavyTraceLevelEnabled)
            {
                LogEntry entry = new LogEntry(SeverityLevels.HeavyTrace, message,
                    Assembly.GetCallingAssembly().GetName().Name);
                instance.EnqueueLogEntry(entry);
            }
        }

        public static void LogHeavyTrace(string format, params object[] args)
        {
            string message = string.Format(format, args);
#if DEBUG
            Debug.WriteLine("HWY: " + message);
#endif
            if (LoggingConfiguration.HeavyTraceLevelEnabled)
            {
                LogEntry entry = new LogEntry(SeverityLevels.HeavyTrace, message,
                    Assembly.GetCallingAssembly().GetName().Name);
                instance.EnqueueLogEntry(entry);
            }
        }

        public static void LogTrace(string format, params object[] args)
        {
            string message = string.Format(format, args);
#if DEBUG
            Debug.WriteLine("TRC: " + message);
#endif
            if (LoggingConfiguration.TraceLevelEnabled)
            {
                LogEntry entry = new LogEntry(SeverityLevels.Trace, message,
                    Assembly.GetCallingAssembly().GetName().Name);
                instance.EnqueueLogEntry(entry);
            }
        }

        public static void LogInfo(string format, params object[] args)
        {
            string message = string.Format(format, args);
#if DEBUG
            Debug.WriteLine("INF: " + message);
#endif
            if (LoggingConfiguration.InfoLevelEnabled)
            {
                LogEntry entry = new LogEntry(SeverityLevels.Info, message,
                    Assembly.GetCallingAssembly().GetName().Name);
                instance.EnqueueLogEntry(entry);
            }
        }

        public static void LogWarning(string format, params object[] args)
        {
            string message = string.Format(format, args);
#if DEBUG
            Debug.WriteLine("WRN: " + message);
#endif
            if (LoggingConfiguration.WarningLevelEnabled)
            {
                LogEntry entry = new LogEntry(SeverityLevels.Warning, message,
                    Assembly.GetCallingAssembly().GetName().Name);
                instance.EnqueueLogEntry(entry);
            }
        }

        public static void LogError(string format, params object[] args)
        {
            string message = string.Format(format, args);
#if DEBUG
            Debug.WriteLine("ERR: " + message);
#endif
            if (LoggingConfiguration.ErrorLevelEnabled)
            {
                LogEntry entry = new LogEntry(SeverityLevels.Error, message,
                    Assembly.GetCallingAssembly().GetName().Name);
                instance.EnqueueLogEntry(entry);
            }
        }

        public static void LogException(Exception ex)
        {
            LogException(ex, string.Empty);
        }

        public static void LogException(Exception ex, string format, params object[] args)
        {
            string message = string.Format(format, args);
#if DEBUG
            Debug.WriteLine("EXC: " + ErrorDispatcher.GetErrorMessageForException(ex, true));
#endif
            if (LoggingConfiguration.LoggingEnabled)
            {
                LogEntry entry = new LogEntry(message, ex,
                    Assembly.GetCallingAssembly().GetName().Name);
                instance.EnqueueLogEntry(entry);
            }
        }

        public static void LogComPortData(string comName, byte[] bytes)
        {
            if (LoggingConfiguration.LoggingEnabled &&
                LoggingConfiguration.HeavyTraceLevelEnabled)
            {
                if (!LoggingConfiguration.LoggingEnabled)
                {
                    return;
                }

                System.IO.TextWriter logWriter = null;

                try
                {
                    if (!Directory.Exists(logFileFolder))
                    {
                        Directory.CreateDirectory(logFileFolder);
                    }

                    string currentDayStamp = DateTime.Now.ToString(LogDateFormat);
                    string logFilePath =
                        System.IO.Path.Combine(logFileFolder, comName + "_" + currentDayStamp + ".log");

                    logWriter = System.IO.File.AppendText(logFilePath);

                    logWriter.Write(Encoding.ASCII.GetString(bytes));
                }
                catch
                {
                }
                finally
                {
                    if (logWriter != null)
                    {
                        // Ensure file is not kept open.
                        logWriter.Close();
                    }
                }
            }
        }

        public static void StopLogger()
        {
            if (LoggingConfiguration.LoggingEnabled)
            {
                if (instance.loggerThread.IsAlive)
                {
                    LogTrace("Logger thread was requested to stop...");
                    instance.loggerThreadMustRun = false;
                    instance.loggerThread.Join();

                    LogEntry entry = new LogEntry(SeverityLevels.Info,
                        "Logger thread has stopped.",
                        Assembly.GetCallingAssembly().GetName().Name);
                    WriteLogEntry(entry);
                }
            }
        }

        public static void LogTimeDifference(string text, DateTime start)
        {
            int diff = (int)DateTime.Now.Subtract(start).TotalMilliseconds;
            Logger.LogHeavyTrace("{0}: operation took {1} msec", text, diff);
        }

        #endregion

        #region Construction
        private Logger()
        {
            if (LoggingConfiguration.LoggingEnabled)
            {
                assemblyLocation = Assembly.GetExecutingAssembly().Location;

                logFileFolder = LoggingConfiguration.LogFilePath;
                if (string.IsNullOrEmpty(logFileFolder) || logFileFolder == PathUtils.CurrentDir)
                {
                    logFileFolder = new System.IO.FileInfo(assemblyLocation).Directory.FullName;
                }

                WriteLogSessionStart();

                loggerThread = new System.Threading.Thread(
                    new System.Threading.ThreadStart(ThreadLoop));
                loggerThread.Start();
            }
        }

        #endregion

        #region Implementation
        private void EnqueueLogEntry(LogEntry entry)
        {
            lock (entries)
            {
                // Don't add any more entries after thread was requested to stop.
                if (loggerThreadMustRun)
                {
                    entries.Enqueue(entry);
                }
            }
        }

        private LogEntry DequeueLogEntry()
        {
            lock (entries)
            {
                if (entries.Count > 0)
                {
                    return entries.Dequeue();
                }
                else
                {
                    return null;
                }
            }
        }

        private static void ThreadLoop()
        {
            LogInfo( "Logger thread loop has begun ...");

            // Purge old log files on startup
            PurgeOldLogFiles();

            while (instance.loggerThreadMustRun ||
                    instance.entries.Count > 0)
            {
                ProcessQueue();

                DateTime now = DateTime.Now;
                if (now.Minute % 60 == 0)
                {
                    // Each hour of continous uptime, purge old log files
                    PurgeOldLogFiles();
                }

                System.Threading.Thread.Sleep(10);
            }
            
            LogEntry entry = new LogEntry(SeverityLevels.Info,
                "Logger thread loop has terminated.",
                Assembly.GetCallingAssembly().GetName().Name);
            WriteLogEntry(entry);
        }

        private static void PurgeOldLogFiles()
        {
            string[] logFiles = Directory.GetFiles(LoggingConfiguration.LogFilePath, "*.log");

            foreach (string logFile in logFiles)
            {
                try
                {
                    if (File.Exists(logFile))
                    {
                        string name = Path.GetFileNameWithoutExtension(logFile);
                        DateTime logFileDate = GetDateFromLogFileName(name);

                        TimeSpan diff = DateTime.Now.Subtract(logFileDate);
                        if (diff.Days >= LoggingConfiguration.DaysToKeepLogs)
                        {
                            // Old file. Delete it.
                            File.Delete(logFile);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogEntry entry = new LogEntry(SeverityLevels.Exception,
                        ex.Message, "Logger thread");

                    WriteLogEntry(entry);
                }
            }
        }

        private static DateTime GetDateFromLogFileName(string logFile)
        {
            DateTime retVal = DateTime.MaxValue;

            if (logFile.Length > LogDateFormat.Length)
            {
                string date = logFile.Substring(logFile.Length - LogDateFormat.Length);

                DateTime dt;
                DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                dtfi.ShortDatePattern = LogDateFormat;

                if (DateTime.TryParse(date, dtfi, DateTimeStyles.AssumeLocal, 
                    out dt))
                {
                    retVal = dt;
                }
            }
            
            return retVal;
        }

        private static void ProcessQueue()
        {
            LogEntry lastEntry = instance.DequeueLogEntry();
            if (lastEntry != null)
            {
                WriteLogEntry(lastEntry);
            }
        }

        internal static void WriteLogEntry(LogEntry entry)
        {
            WriteLogString(entry.AppName, entry.ToString());
        }

        private static void WriteLogSessionStart()
        {
            string appName = Process.GetCurrentProcess().ProcessName;
            DateTime now = DateTime.Now;
            sessionID = now.Ticks;

            LogEntry entry = new LogEntry(SeverityLevels.Automatic, "BEGIN_LOG_SESSION", 
                Assembly.GetCallingAssembly().GetName().Name);

            WriteLogEntry(entry);

            string msg = string.Format("Application started with LogLevels: {0}.", 
                LoggingConfiguration.ReportEnabledLevels());

            entry = new LogEntry(SeverityLevels.Info,
                msg, Assembly.GetCallingAssembly().GetName().Name);

            WriteLogEntry(entry);
        }

        internal static void WriteLogSessionEnd()
        {
            string appName = Process.GetCurrentProcess().ProcessName;
            DateTime now = DateTime.Now;

            string msg = string.Format("Application ended.");

            LogEntry entry = new LogEntry(SeverityLevels.Info,
                msg, Assembly.GetCallingAssembly().GetName().Name);

            WriteLogEntry(entry);

            entry = new LogEntry(SeverityLevels.Automatic, "END_LOG_SESSION",
                Assembly.GetCallingAssembly().GetName().Name);

            WriteLogEntry(entry);
        }

        private static void WriteLogString(string appName, string message)
        {
            if (!LoggingConfiguration.LoggingEnabled)
            {
                return;
            }

            System.IO.TextWriter logWriter = null;

            try
            {
                if (!Directory.Exists(logFileFolder))
                {
                    Directory.CreateDirectory(logFileFolder);
                }

                string currentDayStamp = DateTime.Now.ToString(LogDateFormat);
                string logFilePath =
                    System.IO.Path.Combine(logFileFolder, appName + "_" + currentDayStamp + ".log");

                logWriter = System.IO.File.AppendText(logFilePath);


                string logLine = string.Format("~~{0:X20}|{1}", sessionID, message);

                lock (_readWriteLock)
                {
                    logWriter.WriteLine(logLine);
                }
            }
            catch
            {
            }
            finally
            {
                if (logWriter != null)
                {
                    // Ensure file is not kept open.
                    logWriter.Close();
                }
            }
        }
        #endregion
    }
    #endregion
}
