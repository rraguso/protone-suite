using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OPMedia.Core.Logging;
using System.Reflection;
using OPMedia.Runtime.ProTONE.RemoteControl;
using OPMedia.Core.InstanceManagement;
//using OPMedia.Runtime.UdpCommunication;
using OPMedia.Core;
using OPMedia.Runtime.InterProcessCommunication;

namespace OPMedia.Runtime.ProTONE.RemoteControl
{
    #region RemoteControllableApplication
    public sealed class RemoteControllableApplication : SingleInstanceApplication
    {
        #region Members
        private WmCopyDataReceiver _receiver = null;
        #endregion

        #region Methods
        public new static void Start(string appName)
        {
            if (appInstance == null)
            {
                appInstance = new RemoteControllableApplication(appName);
                appInstance.Start(appName);
            }
            else
            {
                Logger.LogError(string.Format("Only one instance of OpMediaApplication (or derived) can be started per process !!"));
            }
        }

        protected override void DoInitialize(string appName)
        {
            base.DoInitialize(appName);
        }

        protected override void DoTerminate()
        {
            _receiver = null;
            base.DoTerminate();
        }
        #endregion

        #region Construction
        private RemoteControllableApplication(string appName)
        {
            _receiver = new WmCopyDataReceiver(appName);
            _receiver.DataReceived += new DataReceivedHandler(_receiver_DataReceived);
        }

        void _receiver_DataReceived(string data)
        {
            BasicCommand cmd = BasicCommand.Create(data);
            EventDispatch.DispatchEvent(BasicCommand.EventName, cmd);
        }
        #endregion
    }
    #endregion
}
