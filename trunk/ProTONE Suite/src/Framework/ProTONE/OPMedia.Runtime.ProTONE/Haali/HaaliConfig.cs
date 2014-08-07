using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using OPMedia.Core;
using Microsoft.Win32;

namespace OPMedia.Runtime.ProTONE.Haali
{
    public static class HaaliConfig
    {
        public const string ModuleName = "splitter.ax";
        public const string CLSID = "{55DA30FC-F16B-49FC-BAA5-AE59FC65F82D}";
        public static string InstallLocation { get; private set; }

        static HaaliConfig()
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
    }
}
