using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Core;
using System.Drawing;
using OPMedia.UI.Themes;
using System.Reflection;
using OPMedia.UI.Generic;
using OPMedia.UI.Dialogs;
using System.Runtime.InteropServices;
using OPMedia.Core.Utilities;
using OPMedia.Core.Logging;

namespace OPMedia.UI.Controls
{
    public class OPMFontDialog : FontDialog
    {
        public OPMFontDialog()
            : base()
        {
            base.AllowSimulations = false;
            base.ShowEffects = false;
            base.FontMustExist = true;
            base.AllowScriptChange = true;
        }

        protected override IntPtr HookProc(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
        {
            return HookProcHandler.CustomHookProc(hWnd, msg, wparam, lparam, this);
        }
    }

    public class OPMColorDialog : ColorDialog
    {
        public OPMColorDialog()
            : base()
        {
            base.AllowFullOpen = true;
            base.AnyColor = true;
            base.FullOpen = true;
        }

        protected override IntPtr HookProc(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
        {
            return HookProcHandler.CustomHookProc(hWnd, msg, wparam, lparam, this);
        }
    }
}
