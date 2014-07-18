using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OPMedia.Core;
using System.IO;
using System.Diagnostics;
using OPMedia.Core.Configuration;

namespace OPMedia.Core.InstanceManagement
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

            AppConfig.Save();
            Application.Restart();
            Process.GetCurrentProcess().Kill();
        }

        protected abstract void DoInitialize(string appName);
        protected abstract void DoTerminate();
    }
}
