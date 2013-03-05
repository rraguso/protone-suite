using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OPMedia.OSDependentLayer;
using System.IO;
using System.Diagnostics;
using OPMedia.Runtime.ApplicationSettings;

namespace OPMedia.Runtime.InstanceManagement
{
    public abstract class OpMediaApplication
    {
        protected static OpMediaApplication appInstance = null;

        protected string appName;

        protected OpMediaApplication()
        {
        }

        public void Start(string appName)
        {
            this.appName = appName;
            DoInitialize(appName);
        }

        public void Stop()
        {
            DoTerminate();
        }

        public static void Restart()
        {
            if (appInstance != null)
            {
                appInstance.DoTerminate();
            }

            AppSettings.Save();
            Application.Restart();
            Process.GetCurrentProcess().Kill();
        }

        protected abstract void DoInitialize(string appName);
        protected abstract void DoTerminate();
    }
}
