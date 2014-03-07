#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using System.Reflection;
using System.Diagnostics;
#endregion

namespace OPMedia.Core.Logging
{
    #region Enums
    [Flags]
    public enum SeverityLevels
    {
        /// <summary>
        /// Log an application (generic) trace
        /// (any information that can be useful for debugging).
        /// </summary>
        Trace = 0x01,
        /// <summary>
        /// Log an application (generic) trace
        /// (any information that can be useful for debugging).
        /// </summary>
        HeavyTrace=0x02,
        /// <summary>
        /// Log an application information
        /// (any a change in the application status).
        /// </summary>
        Info=0x04,
        /// <summary>
        /// Log an application warning
        /// (e.g. non-fatal, recoverable errors).
        /// </summary>
        Warning=0x08,
        /// <summary>
        /// Log an application error
        /// (e.g fatal, non-recoverable errors).
        /// </summary>
        Error=0x10,
        /// <summary>
        /// Exceptions logging
        /// </summary>
        Exception=0x20,
        /// <summary>
        /// Automatic logging. Reserved for internal use of logger.
        /// Not to be used in applications
        /// </summary>
        Automatic=0x40,
    }
    #endregion

    public class LogEntry
    {
        #region Members
        private const string StackDumpNotAvailable = "No stack dump available.";
        private DateTime dateTime = DateTime.Now;
        private SeverityLevels severityLevel = SeverityLevels.Trace;
        
        private int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
        private int processId = Process.GetCurrentProcess().Id;
        
        private string appName = "UnknownApplicationName";
        
        private string assemblyName;
        
        private string message;
        private string stackDump = StackDumpNotAvailable;
        #endregion

        #region Properties
        public DateTime DateTime
        { get { return dateTime; } }

        public SeverityLevels SeverityLevel
        { get { return severityLevel; } }

        public string AppName
        { get { return appName; } }

        public int ThreadId
        { get { return threadId; } }

        public int ProcessId
        { get { return processId; } }

        public string Message
        { get { return message; } }

        public string StackDump
        { get { return stackDump; } }

        public string AssemblyName
        { get { return assemblyName; } }

        #endregion

        #region Construction
       
        public LogEntry(SeverityLevels severityLevel, string message, string assemblyName)
        {
            // Store the message
            this.message = message;
            // Store the severity level.
            this.severityLevel = severityLevel;
            // Store the assemblyy name.
            this.assemblyName = assemblyName;

            // For errors, a stack dump may be useful.
            if (severityLevel == SeverityLevels.Error)
            {
                try
                {
                    stackDump = string.Empty;
                    StackTrace st = new StackTrace(true);
                    foreach (StackFrame frame in st.GetFrames())
                    {
                        string fileName =
                            (frame != null && frame.GetFileName() != null && frame.GetFileName().Length > 0) ? 
                            frame.GetFileName() : string.Empty;
                        string line = 
                            (frame != null && frame.GetFileLineNumber() > 0) ? 
                            frame.GetFileLineNumber().ToString() : string.Empty;
                        string methodName =
                            (frame != null && frame.GetMethod() != null) ?
                            frame.GetMethod().ReflectedType + "." + frame.GetMethod().Name : string.Empty;

                        string frameStr = string.Empty;
                        if (methodName.Length > 0)
                        {
                            frameStr += "    at " + methodName;
                        }
                        if (fileName.Length > 0)
                        {
                            frameStr += "    in " + fileName;
                            if (line.Length > 0)
                            {
                                frameStr += ":line " + line;
                            }
                        }

                        stackDump += (frameStr.Length > 0) ? frameStr : "    ???? (symbols not available for this stack frame)";
                        stackDump += "\n";
                    }

                    stackDump = stackDump.TrimEnd(new char[] { '\n' });
                }
                catch
                {
                    stackDump = StackDumpNotAvailable;
                }
            }

            GetAppName();
        }

        public LogEntry(Exception ex, string assemblyName) :
            this(string.Empty, ex, assemblyName)
        {
        }

        public LogEntry(string message, Exception ex, string assemblyName)
        {
            if (message.Length > 0)
            {
                this.message = string.Format("{0}\r\n{1}", message,
                    ErrorDispatcher.GetErrorMessageForException(ex, true));
            }
            else
            {
                this.message = ErrorDispatcher.GetErrorMessageForException(ex, true);
            }

            // This is already an application non-recoverable error.
            severityLevel = SeverityLevels.Exception;
            // Stack dump.
            stackDump = ex.StackTrace;
            // Store the assemblyy name.
            this.assemblyName = assemblyName;

            GetAppName();
        }
        #endregion

        #region Implementation
        private void GetAppName()
        {
            try
            {
                appName = Process.GetCurrentProcess().ProcessName;
            }
            catch
            {
            }
        }

        public override string ToString()
        {
            if (severityLevel == SeverityLevels.Error)
            {
                return string.Format("{0}.{1}|{2}|{3}|{4}|{5}|{6}|{7}\tStack={8}", 
                    dateTime.ToString("dd-MM-yyyy HH:mm:ss"), 
                    dateTime.Millisecond.ToString("000"), 
                    severityLevel.ToString(),
                    processId,
                    threadId,
                    appName, 
                    assemblyName, 
                    message,
                    (stackDump.Equals(StackDumpNotAvailable)) ? StackDumpNotAvailable : "\n" + stackDump);
            }
            else
            {
                return string.Format("{0}.{1}|{2}|{3}|{4}|{5}|{6}|{7}",
                    dateTime.ToString("dd-MM-yyyy HH:mm:ss"), 
                    dateTime.Millisecond.ToString("000"),
                    severityLevel.ToString(),
                    processId,
                    threadId,
                    appName, 
                    assemblyName, 
                    message);
            }
        }
        #endregion
    }
}