using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.Remoting;
using OPMedia.Runtime;
using System.Windows.Forms;
using OPMedia.Core;
using OPMedia.Core.Utilities;

namespace OPMedia.ServiceHelper.RCCService.OutputPins
{
    public class HotkeyOutputPin : OutputPin
    {
        public override string TranslateToOutputPinFormat(string data, RCCServiceConfig.RemoteButtonsRow button)
        {
            // keyCode, repeat, command, windowName, remoteName
            return string.Format("{0},{1},{2},{3},{4}",
                data, 0, button.OutputData, button.TargetWndName, button.RemoteName);
        }

        public override bool IsConfigurable
        {
            get { return false; }
        }

        protected override string GetConfigDataInternal(string initialCfgData)
        {
            return null;
        }

        protected override void ConfigureInternal()
        {
            // Nothing to configure. This pin works with standard settings.
        }

        protected override void StartInternal()
        {
            // Nothing to do on start
        }

        protected override void StopInternal()
        {
            // Nothing to do on stop
        }

        protected override void SendRequestInternal(OPMedia.Runtime.Remoting.SerializableObject request)
        {
            if (request is RemoteString)
            {
                string data = (request as RemoteString).Value;
                string[] args = StringUtils.ToStringArray(data, ',');

                string keyCode = "", repeat = "", command = "", windowName = "", remoteName = "";

                int i = 0;
                if (args.Length > i)
                    keyCode = args[i++];
                if (args.Length > i)
                    repeat = args[i++];
                if (args.Length > i)
                    command = args[i++];
                if (args.Length > i)
                    windowName = args[i++];
                if (args.Length > i)
                    remoteName = args[i++];

                IntPtr hWnd = User32.FindWindow(windowName, null);
                if (hWnd != IntPtr.Zero)
                {
                    KeysConverter kc = new KeysConverter();
                    Keys k = (Keys)kc.ConvertFromInvariantString(command);
                    KeyEventArgs kea = new KeyEventArgs(k);

                    // Key down
                    int msg = (int)Messages.WM_KEYDOWN;
                    User32.PostMessage(hWnd, msg, kea.KeyValue, 0);
                }
            }
        }
    }
}
