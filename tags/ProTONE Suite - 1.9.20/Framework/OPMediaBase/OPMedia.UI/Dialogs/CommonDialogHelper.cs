using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OPMedia.Core;
using System.Diagnostics;
using OPMedia.UI.Themes;
using OPMedia.UI.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using OPMedia.Core.Win32;
using System.Drawing;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Controls.Dialogs;
using OPMedia.UI.Dialogs;

namespace OPMedia.UI.Controls
{
    public static class CommonDialogHelper
    {
        public static OPMOpenFileDialog NewOPMOpenFileDialog()
        {
            OPMOpenFileDialog dlg = new OPMOpenFileDialog();
            dlg.Multiselect = false;
            return dlg;
        }

        public static OPMSaveFileDialog NewOPMSaveFileDialog()
        {
            OPMSaveFileDialog dlg = new OPMSaveFileDialog();
            dlg.AddExtension = true;
            dlg.CreatePrompt = true;
            dlg.OverwritePrompt = true;
            return dlg;
        }

        public static OPMFolderBrowserDialog NewOPMFolderBrowserDialog()
        {
            OPMFolderBrowserDialog dlg = new OPMFolderBrowserDialog();
            dlg.ShowNewFolderButton = true;
            dlg.SelectedPath = PathUtils.CurrentDir;

            return dlg;
        }
    }
    
    internal static class HookProcHandler
    {
        internal static bool CustomHookProc(ref Message m, CommonDialog parent)
        {
            m.Result = CustomHookProc(m.HWnd, m.Msg, m.WParam, m.LParam, parent);
            return (m.Result != IntPtr.Zero);
        }

        internal static IntPtr CustomHookProc(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam, CommonDialog parent)
        {
            switch (msg)
            {
                case (int)Messages.WM_CTLCOLORDLG:
                    return Gdi32.CreateSolidBrush(ColorHelper.BGR(ThemeManager.BackColor));

                case (int)Messages.WM_CTLCOLORSTATIC:
                case (int)Messages.WM_CTLCOLORBTN:
                    {
                        Gdi32.SetTextColor(wparam, ColorHelper.BGR(ThemeManager.ForeColor));
                        Gdi32.SetBkColor(wparam, ColorHelper.BGR(ThemeManager.BackColor));
                        return Gdi32.CreateSolidBrush(ColorHelper.BGR(ThemeManager.BackColor));
                    }

                case (int)Messages.WM_CTLCOLOREDIT:
                case (int)Messages.WM_CTLCOLORLISTBOX:
                    {
                        Gdi32.SetTextColor(wparam, ColorHelper.BGR(ThemeManager.WndTextColor));
                        Gdi32.SetBkColor(wparam, ColorHelper.BGR(ThemeManager.WndValidColor));
                        return Gdi32.CreateSolidBrush(ColorHelper.BGR(ThemeManager.WndValidColor));
                    }

                case (int)Messages.WM_NCACTIVATE:
                    {
                        IntPtr param = IntPtr.Zero;
                        if (parent != null)
                        {
                            GCHandle gch = GCHandle.Alloc(parent);
                            param = GCHandle.ToIntPtr(gch);

                            if (parent is FontDialog)
                            {
                                User32.SetWindowText(hWnd, Translator.Translate("TXT_FONT"));
                            }
                            else if (parent is ColorDialog)
                            {
                                User32.SetWindowText(hWnd, Translator.Translate("TXT_CHOOSE_COLOR"));
                            }
                        }

                        User32.EnumChildWindows(hWnd, new User32.EnumWindowProc(CommonDialogWrapper.EnumWindows), param);
                    }
                    break;

            }

            return IntPtr.Zero;
        }
    }
    
    public class CommonDialogWrapper : NativeWindow, IDisposable
    {
        IntPtr _hwnd = IntPtr.Zero;
        bool _watchForActivate = false;
        CommonDialog _parent;

        public CommonDialogWrapper(CommonDialog parent)
        {
            _parent = parent;
            AssignDummyWindow();
            _watchForActivate = true;
        }

        private void AssignDummyWindow()
        {
            _hwnd = User32.CreateWindowEx(0, "Message", null, 0x10000000, 0, 0, 0, 0,
                new IntPtr(-3), IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

            if (IntPtr.Zero == _hwnd || !User32.IsWindow(_hwnd))
                throw new ApplicationException("Unable to create a dummy window");

            AssignHandle(_hwnd);
        }


        public void Dispose()
        {
            if (_hwnd != IntPtr.Zero)
            {
                User32.DestroyWindow(_hwnd);
                DestroyHandle();
                _hwnd = IntPtr.Zero;
            }
        }

        void DialogWrappper_Disposed(object sender, EventArgs e)
        {
            Dispose();
        }

        #region Overrides
        //this is a child window for the whole Dialog
        protected override void WndProc(ref Message m)
        {
            const int GWL_STYLE = -16;

            m.Result = IntPtr.Zero;

            if (HookProcHandler.CustomHookProc(ref m, _parent))
                return;

            switch (m.Msg)
            {
                case (int)Messages.WM_NCACTIVATE:
                    if (_watchForActivate)//WM_NCACTIVATE works too
                    {
                        //Now the Dialog is visible and about to enter the modal loop 
                        _watchForActivate = false;

                        ReleaseHandle();//release the dummy window
                        AssignHandle(m.LParam);

                        int lStyle = User32.GetWindowLong(m.LParam, GWL_STYLE);
                        lStyle &= ~(int)(WindowStyle.ThickFrame | WindowStyle.Minimize | 
                            WindowStyle.Maximize);
                        User32.SetWindowLong(m.LParam, GWL_STYLE, lStyle);

                        IntPtr param = IntPtr.Zero;
                        if (_parent != null)
                        {
                            GCHandle gch = GCHandle.Alloc(_parent);
                            param = GCHandle.ToIntPtr(gch);

                            if (_parent is FolderBrowserDialog)
                            {
                                User32.SetWindowText(m.LParam, Translator.Translate("TXT_SELECT_FOLDER"));
                            }
                        }

                        User32.EnumChildWindows(m.LParam, new User32.EnumWindowProc(EnumWindows), param);
                    }
                    break;

                default:
                    break;
            }
            base.WndProc(ref m);
        }
        #endregion

        internal static bool EnumWindows(IntPtr hwnd, IntPtr param)
        {
            CommonDialog parent = null;

            try
            {
                if (param != IntPtr.Zero)
                {
                    GCHandle gch = GCHandle.FromIntPtr(param);
                    parent = gch.Target as CommonDialog;
                }
            }
            catch { }

            StringBuilder sb = new StringBuilder(256);
            User32.GetClassName(hwnd, sb, 256);

            string className = sb.ToString().ToLowerInvariant();
            if (className.Contains("scrollbar"))
            {
                // Hide the sizing grips, they look ugly on skinned window
                User32.ShowWindow(hwnd, ShowWindowStyles.SW_HIDE);
                //return false;
            }

            int ctrlId = User32.GetDlgCtrlID(hwnd);

            switch (ctrlId)
            {
                case (int)DialogItem.btnOK:
                    User32.SetWindowText(hwnd, Translator.Translate("TXT_OK"));
                    break;
                case (int)DialogItem.btnCancel:
                    User32.SetWindowText(hwnd, Translator.Translate("TXT_CANCEL"));
                    break;
            }

            if (parent is FileDialog)
            {
                switch (ctrlId)
                {
                    case (int)DialogItem.txtFileType:
                        User32.SetWindowText(hwnd, Translator.Translate("TXT_FILE_TYPE") + ":");
                        break;
                    case (int)DialogItem.txtFileName:
                        User32.SetWindowText(hwnd, Translator.Translate("TXT_FILENAME") + ":");
                        break;
                    case (int)DialogItem.txtLookIn:
                        User32.SetWindowText(hwnd, Translator.Translate("TXT_LOOK_IN") + ":");
                        break;
                }
            }
            else if (parent is FolderBrowserDialog)
            {
                
            }
            else if (parent is FontDialog)
            {
                switch (ctrlId)
                {
                    case (int)DialogItem.txtSample:
                        User32.SetWindowText(hwnd, Translator.Translate("TXT_SAMPLE"));
                        break;
                    case (int)DialogItem.txtFont:
                        User32.SetWindowText(hwnd, Translator.Translate("TXT_FONT"));
                        break;
                    case (int)DialogItem.txtFontStyle:
                        User32.SetWindowText(hwnd, Translator.Translate("TXT_FONT_STYLE"));
                        break;
                    case (int)DialogItem.txtSize:
                        User32.SetWindowText(hwnd, Translator.Translate("TXT_SIZE") + ":");
                        break;
                    case (int)DialogItem.txtScript:
                        User32.SetWindowText(hwnd, Translator.Translate("TXT_SCRIPT") + ":");
                        break;
                }
            }
            else if (parent is ColorDialog)
            {
            }

            return true;
        }

        internal enum DialogItem : int
        {
            btnOK = 1,
            btnCancel = 2,

            txtSample = 0x431,
            
            txtFont = 0x440,
            txtFontStyle = 0x441,
            txtSize = 0x442,
            txtScript = 0x446,

            txtFileType = 0x441,
            txtFileName = 0x442,
            txtLookIn = 0x443,
        }
    }
}
