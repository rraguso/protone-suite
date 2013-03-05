using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Core;
using System.Runtime.InteropServices;

namespace OPMedia.Runtime.InterProcessCommunication
{
    public delegate void DataReceivedHandler(string data);

    public sealed class WmCopyDataReceiver : IDisposable
    {
        private WmCopyDataWindow _wnd;

        public event DataReceivedHandler DataReceived = null;

        public WmCopyDataReceiver(string appName)
        {
            appName = appName.Replace(".", "_").Replace(" ", "").Trim().ToUpperInvariant();
            _wnd = new WmCopyDataWindow(appName);
            _wnd.DataReceived += new DataReceivedHandler(_wnd_DataReceived);
        }

        void _wnd_DataReceived(string data)
        {
            if (DataReceived != null)
            {
                DataReceived(data);
            }
        }

        ~WmCopyDataReceiver()
        {
            Dispose();
        }

        public void Dispose()
        {
            _wnd.DestroyHandle();
        }
    }

    internal sealed class WmCopyDataWindow : NativeWindow
    {
        internal event DataReceivedHandler DataReceived = null;

        internal WmCopyDataWindow(string wndName)
        {
            CreateParams cp = new CreateParams();
            cp.ClassName = "Message";
            cp.Caption = wndName + "_WMCOPYDATA";
            cp.Width = cp.Height = 0;
            cp.X = cp.Y = 10000;

            try
            {
                CreateHandle(cp);
            }
            catch
            {
                int err = Kernel32.GetLastError();
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (int)Messages.WM_COPYDATA:
                    {
                        COPYDATASTRUCT cds = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
                        string strData = Marshal.PtrToStringUni(cds.lpData);

                        if (DataReceived != null)
                        {
                            DataReceived(strData);
                        }
                    }
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}
