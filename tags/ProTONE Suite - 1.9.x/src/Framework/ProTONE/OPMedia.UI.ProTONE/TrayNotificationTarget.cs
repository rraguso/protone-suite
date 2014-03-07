
using System.Windows.Forms;
using System.Drawing;
using OPMedia.UI.Themes;
using OPMedia.Core;
using System.Collections.Generic;

using OPMedia.UI.Controls;
using System;
using OPMedia.Core.GlobalEvents;
using OPMedia.Core.TranslationSupport;

namespace OPMedia.UI.ProTONE
{
    public class TrayNotificationTarget
    {
        private Form _parent = null;

        ~TrayNotificationTarget()
        {
            EventDispatch.UnregisterHandler(this);
        }

        public TrayNotificationTarget(Form parent)
        {
            _parent = parent;
            EventDispatch.RegisterHandler(this);
        }

        [EventSink(EventNames.ShowMessageBox)]
        public void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            Image img = null;
            Color backColor = ThemeManager.BackColor;

            switch (icon)
            {
                case MessageBoxIcon.Information:
                    img = ImageProvider.GetUser32Icon(User32Icon.Information, true);
                    break;

                case MessageBoxIcon.Warning:
                    img = ImageProvider.GetUser32Icon(User32Icon.Warning, true);
                    break;

                case MessageBoxIcon.Error:
                    img = ImageProvider.GetUser32Icon(User32Icon.Error, true);
                    break;

                case MessageBoxIcon.None:
                default:
                    break;
            }

            Dictionary<string, string> d = null;
            if (message != null)
            {
                d = new Dictionary<string, string>();
                d.Add(message, string.Empty);
            }

            TrayNotificationBox f = new TrayNotificationBox();
            f.HideDelay = 5000;
            f.AnimationType = AnimationType.None;
            f.Show(title, d, img);
        }
    }
}
