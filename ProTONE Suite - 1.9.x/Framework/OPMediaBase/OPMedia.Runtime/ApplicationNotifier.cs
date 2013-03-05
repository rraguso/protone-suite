using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.TranslationSupport;

namespace OPMedia.Runtime
{
    public delegate void ApplicationNotifyMessageHandler(string message, string title, ToolTipIcon icon);

    public class ApplicationNotifier
    {
        public static event ApplicationNotifyMessageHandler ApplicationNotifyMessage = null;

        public static void NotifyMessage(string message, string title, ToolTipIcon icon)
        {
            if (ApplicationNotifyMessage != null)
            {
                // The hosting app has registered an ApplicationNotifyMessageHandler
                ApplicationNotifyMessage(message, title, icon);
            }
            else
            {
                // Apps that did not register an ApplicationNotifyMessageHandler
                // will get a standard MessageBox window

                MessageBoxIcon msgIcon = MessageBoxIcon.None;
                switch (icon)
                {
                    case ToolTipIcon.Info:
                        msgIcon = MessageBoxIcon.Information;
                        break;
                    case ToolTipIcon.Warning:
                        msgIcon = MessageBoxIcon.Warning;
                        break;
                    case ToolTipIcon.Error:
                        msgIcon = MessageBoxIcon.Error;
                        break;
                    case ToolTipIcon.None:
                    default:
                        msgIcon = MessageBoxIcon.None;
                        break;
                }

                MessageBox.Show(message, title, MessageBoxButtons.OK, msgIcon);
            }
        }
    }
}
