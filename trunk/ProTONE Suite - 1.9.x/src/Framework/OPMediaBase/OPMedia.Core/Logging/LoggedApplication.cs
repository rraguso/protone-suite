using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OPMedia.Core.Logging;
using System.Threading;
using System.Reflection;
using OPMedia.Core.InstanceManagement;
using System.IO;
using System.Security.AccessControl;
using OPMedia.Core.NetworkAccess;
using OPMedia.Core.ApplicationSettings;

namespace OPMedia.Core.Logging
{
    public class LoggedApplication : OpMediaApplication
    {
        protected Mutex _appMutex = null;
        protected string _appMutexName = null;

        public new static void Start(string appName)
        {
            if (appInstance == null)
            {
                appInstance = new LoggedApplication();
                appInstance.Start(appName);
            }
            else
            {
                Logger.LogError("Error encountered: {0}",
                    "Only one instance of OpMediaApplication (or derived) can be started per process !!");
            }
        }

        public new static void Stop()
        {
            if (appInstance != null)
            {
                appInstance.Stop();
            }
        }

        public new static void Restart()
        {
            Logger.LogInfo("Application is restarting.");
            OpMediaApplication.Restart();
        }

        protected LoggedApplication()
        {
        }

        ~LoggedApplication()
        {
            LogEntry entry = new LogEntry(SeverityLevels.Info,
                 appName + " application has finished.",
                Assembly.GetCallingAssembly().GetName().Name);
            Logger.WriteLogEntry(entry);
            Logger.WriteLogSessionEnd();
        }

        private void OnApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ErrorDispatcher.DispatchError(e.Exception);
        }

        private void LogException(Exception ex)
        {
            LogEntry entry = new LogEntry("Unhandled exception:", ex,
                Assembly.GetCallingAssembly().GetName().Name);
            Logger.WriteLogEntry(entry);
        }

        protected override void DoInitialize(string appName)
        {
            Logger.LogInfo(appName + " application is starting up ...");

            _appMutexName = appName.Replace(" ", "").ToLowerInvariant() + @".mutex";

            InstallApplicationEventHandlers();
            RegisterAppMutex(appName);
        }

        protected virtual void RegisterAppMutex(string appName)
        {
            bool isNew = false;
            _appMutex = new Mutex(false, "Global\\" + _appMutexName, out isNew);
        }

        private void InstallApplicationEventHandlers()
        {
            Application.ThreadException +=
                new ThreadExceptionEventHandler(OnApplicationThreadException);
        }

        protected override void DoTerminate()
        {
            ReleaseAppMutex();
            Logger.StopLogger();
        }

        protected void ReleaseAppMutex()
        {
            if (_appMutex != null)
            {
                Logger.LogTrace("Tring to release the app instance mutex ...");

                _appMutex.Close();
                _appMutex = null;

                Logger.LogTrace("App instance mutex is released now");

            }
        }
    }
}
