using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Core;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.UI.Themes;
using OPMedia.UI;
using OPMedia.Core.GlobalEvents;

namespace OPMedia.Runtime
{
    public class ThemedMessageBoxTarget
    {
        public ThemedMessageBoxTarget()
        {
            EventDispatch.RegisterHandler(this);
        }

        [EventSink(EventNames.ShowMessageBox)]
        public void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageDisplay.Show(message, title, icon);
        }

        ~ThemedMessageBoxTarget()
        {
            EventDispatch.UnregisterHandler(this);
        }
    }
}
