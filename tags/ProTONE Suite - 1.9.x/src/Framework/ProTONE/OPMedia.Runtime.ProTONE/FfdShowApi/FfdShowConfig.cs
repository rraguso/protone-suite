using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using OPMedia.Core;
using Microsoft.Win32;

namespace OPMedia.Runtime.ProTONE.FfdShowApi
{
    public static class FfdShowConfig
    {
        public const string ModuleName = "ffdshow.ax";
        public const string CLSID = "{4DB2B5D9-4556-4340-B189-AD20110D953F}";
        public static string InstallLocation { get; private set; }

        static FfdShowConfig()
        {
            InstallLocation = null;
            try
            {
                string keyPath = string.Format(@"SOFTWARE\Classes\CLSID\{0}\InprocServer32", CLSID);
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath))
                {
                    if (key != null)
                    {
                        InstallLocation = key.GetValue("") as string;
                    }
                }
            }
            catch
            {
                InstallLocation = null;
            }
        }

        public static void DoConfigureVideo(IntPtr hWndParent)
        {
            IntPtr hWnd = WindowHelper.FindWindow("ffdshow_tray");
            if (hWnd != IntPtr.Zero)
            {
                User32.SendMessage(hWnd, FFDShowConstants.MSG_TRAYICON, 1, (int)Messages.WM_LBUTTONDBLCLK);
            }
            else
            {
                AsyncCallUnsafeDelegate("configure", hWndParent);
            }
        }

        public static void DoConfigureAudio(IntPtr hWndParent)
        {
            IntPtr hWnd = WindowHelper.FindWindow("ffdshowaudio_tray");
            if (hWnd != IntPtr.Zero)
            {
                User32.SendMessage(hWnd, FFDShowConstants.MSG_TRAYICON, 1, (int)Messages.WM_LBUTTONDBLCLK);
            }
            else
            {
                AsyncCallUnsafeDelegate("configureAudio", hWndParent);
            }
        }

        class FfdShowConfigureData
        {
            public FfdShowCfgDelegate _delegate = null;
            public IntPtr _hwnd = IntPtr.Zero;
            public bool _isDynamicDelegate = false;

            public FfdShowConfigureData(FfdShowCfgDelegate dlg, IntPtr hWnd)
            {
                _delegate = dlg;
                _hwnd = hWnd;
            }

            public FfdShowConfigureData(IntPtr func, IntPtr hWnd)
            {
                _delegate = Marshal.GetDelegateForFunctionPointer(func, typeof(FfdShowCfgDelegate))
                    as FfdShowCfgDelegate;

                if (_delegate == null)
                    throw new ArgumentException("Cannot retrieve dynamic delegate");

                _hwnd = hWnd;
                _isDynamicDelegate = true;
            }
        };

        private delegate void FfdShowCfgDelegate(IntPtr hwnd, IntPtr hinst, string lpCmdLine, ShowWindowStyles nCmdShow);

        private static void AsyncCallUnsafeDelegate(string fncName, IntPtr hWnd)
        {
            FfdShowConfigureData data = null;
            IntPtr module = IntPtr.Zero;

            module = Kernel32.GetModuleHandle(ModuleName);
            if (module == IntPtr.Zero)
            {
                module = Kernel32.LoadLibrary(InstallLocation);
            }
            
            if (module != IntPtr.Zero)
            {
                IntPtr proc = Kernel32.GetProcAddress(module, fncName);
                if (proc != IntPtr.Zero)
                {
                    try
                    {
                        data = new FfdShowConfigureData(proc, hWnd);
                    }
                    catch
                    {
                        data = null;
                    }
                }
            }

            if (data != null)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(CallUnsafeDelegate), data);
            }
        }


        private static void CallUnsafeDelegate(object state)
        {
            try
            {
                FfdShowConfigureData data = state as FfdShowConfigureData;
                if (data != null && data._delegate != null)
                {
                    string cwd = Directory.GetCurrentDirectory();

                    if (!data._isDynamicDelegate)
                    {
                        Directory.SetCurrentDirectory(Path.GetDirectoryName(InstallLocation));
                    }

                    unsafe
                    {
                        Ole32.CoUninitialize();

                        if (data._delegate != null)
                        {
                            data._delegate(data._hwnd, IntPtr.Zero, string.Empty, ShowWindowStyles.SW_NORMAL);
                        }
                    }

                    if (!data._isDynamicDelegate)
                    {
                        Directory.SetCurrentDirectory(cwd);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
