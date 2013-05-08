using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OPMedia.Runtime.Logging;
using System.Reflection;
using System.Security.AccessControl;
using OPMedia.OSDependentLayer;

namespace OPMedia.Runtime.InstanceManagement
{
    #region Exception classes
    public class MultipleInstancesException : Exception
    {
        public MultipleInstancesException(string message)
            : base(message)
        {
        }
    }
    #endregion

    #region SingleInstanceApplication
    public class SingleInstanceApplication : LoggedApplication
    {
        #region Methods
        public static new void Start(string appName)
        {
            if (appInstance == null)
            {
                appInstance = new SingleInstanceApplication();
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
            appInstance.Stop();
        }
        #endregion

        #region Construction
        protected SingleInstanceApplication()
        {
        }
        #endregion

        #region Implementation
        protected override void RegisterAppMutex(string appName)
        {
            bool isPrimaryInstance = false;

            try
            {
                using (Mutex m = Mutex.OpenExisting(_appMutexName, MutexRights.ReadPermissions))
                {
                }

                // SECONDARY INSTANCE
                Logger.LogTrace("Succesfully opened the mutex with name: {0}", _appMutexName);
                Logger.LogTrace("=> Apparently it's a secondary app instance.");
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                // PRIMARY INSTANCE
                Logger.LogTrace("Could not open the mutex with name: {0}", _appMutexName);
                Logger.LogTrace("=> Apparently it's the primary app instance");
                isPrimaryInstance = true;
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }

            if (isPrimaryInstance)
            {
                _appMutex = new Mutex(true, _appMutexName);
            }
            else
            {
                // Raise exception to notify the secondary instance that it must terminate.
                ReleaseAppMutex();
                throw new MultipleInstancesException(
                    string.Format("Another instance of app: {0} is already running.", appName));
            }
        }
       
        #endregion
    }
    #endregion
}
