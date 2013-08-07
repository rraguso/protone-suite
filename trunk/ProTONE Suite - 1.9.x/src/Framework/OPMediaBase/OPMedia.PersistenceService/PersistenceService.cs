using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using OPMedia.Core;
using OPMedia.Core.Logging;
using OPMedia.Runtime.ServiceHelpers;

namespace OPMedia.PersistenceService
{
    public partial class PersistenceService : ServiceBase
    {
        ServiceHelper _sh = null;
        
        public PersistenceService()
        {
            InitializeComponent();
            this.ServiceName = Constants.PersistenceServiceShortName;
        }

        [STAThread]
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                Debug.Listeners.Add(new ConsoleTraceListener(false));

                // Start as stand-alone app
                new PersistenceService().RunStandAlone(Environment.GetCommandLineArgs());
            }
            else
            {
                // Start Windows Service
                Run(new PersistenceService());
            }
        }

        public void RunStandAlone(string[] args)
        {
            OnStart(args);

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();

            OnStop();
        }

        protected override void OnStart(string[] args)
        {
            LoggedApplication.Start(this.ServiceName);
            Logger.LogInfo("Service preparing to start ...");

            try
            {
                StartServiceHelper();
                Logger.LogInfo("Service started with success.");
            }
            catch (Exception ex)
            {
                Logger.LogInfo("Service failed to start correctly. {0}", ex.Message);
                Stop();
            }
        }

        protected override void OnStop()
        {
            Logger.LogInfo("Service preparing to stop ...");

            try
            {
                StopServiceHelper();
                Logger.LogInfo("Service stopped with success.");
            }
            catch (Exception ex)
            {
                Logger.LogInfo("Service failed to stop correctly. {0}", ex.Message);
            }

            LoggedApplication.Stop();
        }

        protected override void OnCustomCommand(int command)
        {
            try
            {
                ServiceCommand sc = (ServiceCommand)command;
                switch (sc)
                {
                    case ServiceCommand.Reconfigure:
                        Reconfigure();
                        break;

                    case ServiceCommand.QueryStatus:
                        QueryStatus();
                        break;
                }
            }
            catch
            {
            }
        }

        private void Reconfigure()
        {
            try
            {
                Logger.LogInfo("Service preparing to reconfigure ...");

                StopServiceHelper();
                StartServiceHelper();

                Logger.LogInfo("Service reconfigured with success ...");
            }
            catch (Exception ex)
            {
                Logger.LogInfo("Service failed to reconfigure. {0}", ex.Message);
            }
        }

        internal void StartServiceHelper()
        {
            Logger.LogInfo("Service helper preparing to start ...");

            _sh = new ServiceHelper();
            _sh.Start();

            Logger.LogInfo("Service helper started succesfully !");
        }

        private void StopServiceHelper()
        {
            Logger.LogInfo("Service helper preparing to stop ...");

            if (_sh != null)
            {
                _sh.Stop();
                _sh = null;
            }

            Logger.LogInfo("Service helper stopped succesfully !");
        }

        private void QueryStatus()
        {
        }
       
    }
}
