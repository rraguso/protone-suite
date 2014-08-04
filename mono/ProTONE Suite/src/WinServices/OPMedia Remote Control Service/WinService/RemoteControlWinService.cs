using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceProcess;
using OPMedia.ServiceHelper.RCCService;
using OPMedia.Core.Logging;
using OPMedia.Core;
using OPMedia.Runtime.ServiceHelpers;
using OPMedia.Runtime;
using OPMedia.Runtime.ProTONE;

namespace OPMedia.Services.RCCService
{
    partial class RemoteControlWinService : ServiceBase
    {
        RemoteControlServiceHelper _rcsh = null;

        public RemoteControlWinService()
        {
            InitializeComponent();
            this.ServiceName = ProTONEConstants.RCCServiceShortName;
        }

        [STAThread]
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                Debug.Listeners.Add(new ConsoleTraceListener(false));

                // Start as stand-alone app
                new RemoteControlWinService().RunStandAlone(Environment.GetCommandLineArgs());
            }
            else
            {
                // Start Windows Service
                Run(new RemoteControlWinService());
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
            catch(Exception ex)
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

            _rcsh = new RemoteControlServiceHelper();
            _rcsh.Start();

            Logger.LogInfo("Service helper started succesfully !");
        }

        private void StopServiceHelper()
        {
            Logger.LogInfo("Service helper preparing to stop ...");

            if (_rcsh != null)
            {
                _rcsh.Stop();
                _rcsh = null;
            }

            Logger.LogInfo("Service helper stopped succesfully !");
        }

        private void QueryStatus()
        {
        }
    }
}
