using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Core;
using System.Runtime.InteropServices;
using OPMedia.Core.Logging;

namespace OPMedia.Runtime.InterProcessCommunication
{
    public static class WmCopyDataSender
    {
        public static bool SendData(string appName, string data)
        {
            Logger.LogTrace("WmCopyDataSender.SendData to {0}: {1}", appName, data);

            string wndName = appName.Replace(".", "_").Replace(" ", "").Trim().ToUpperInvariant()
                +"_WMCOPYDATA";

            IntPtr hWnd = User32.FindWindow(null, wndName);
            if (hWnd == IntPtr.Zero)
            {
                Logger.LogTrace("WmCopyDataSender.SendData to {0}: {1} ... window not found: {2}", appName, data, wndName);
                return false;
            }

            byte[] sb = Encoding.Unicode.GetBytes(data);

            COPYDATASTRUCT cds = new COPYDATASTRUCT();
            cds.dwData = UIntPtr.Zero;
            cds.lpData = Marshal.StringToHGlobalUni(data);
            cds.cbData = (uint)Kernel32.GlobalSize(cds.lpData);

            //IntPtr lpStruct = Marshal.AllocHGlobal(Marshal.SizeOf(cds));
            //Marshal.StructureToPtr(cds, lpStruct, false);

            IntPtr ret = IntPtr.Zero;
            User32.SendMessageTimeout(hWnd, (int)Messages.WM_COPYDATA, IntPtr.Zero, ref cds,
                SendMessageTimeoutFlags.SMTO_ABORTIFHUNG, 200, out ret);

            if (ret.ToInt32() != 1)
                return false;

            return true;
        }
    }
}
