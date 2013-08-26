using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.OSDependentLayer;
using System.Windows.Forms;
using OPMedia.Runtime.Shortcuts;

namespace OPMedia.Runtime.TranslationSupport
{
    public class KeymapChangeNotifyTarget : MethodEventTarget
    {
        public KeymapChangeNotifyTarget(MethodInvoker callback)
            : base(EventNames.KeymapChanged, callback)
        {
        }
    }

    public delegate void ShortcutHandler(OPMShortcutEventArgs args);
    public class ShortcutEventTarget : EventTarget
    {
        private ShortcutHandler _callback = null;

        public ShortcutEventTarget(ShortcutHandler callback)
            : base(EventNames.ExecuteShortcut)
        {
            _callback = callback;
        }

        public override void ProcessNotification(string eventName, object[] eventData)
        {
            if (_callback != null)
            {
                OPMShortcutEventArgs args = (OPMShortcutEventArgs)eventData[0];
                if (!args.IsHandled)
                {
                    _callback(args);
                }
            }
        }
    }
}
