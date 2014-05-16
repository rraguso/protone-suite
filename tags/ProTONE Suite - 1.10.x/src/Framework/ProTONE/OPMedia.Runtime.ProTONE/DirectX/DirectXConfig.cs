using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Win32;
using OPMedia.Core;

namespace OPMedia.Runtime.ProTONE.DirectX
{
    public static class DirectXConfig
    {
        public const string DxModuleName = "dxdiagn.dll";
        public const string DxRegPath = @"SOFTWARE\Microsoft\DirectX";
        public static readonly Version Dx1Version = new Version(4, 2, 95); // DirectX 1.0 - there is no DirectX older than this :)
        public static readonly Version Dx9cVersion = new Version("4.9.0.904");
        public static readonly Version Dx10Version = new Version("6.00.6000.16386");

        static Dictionary<Version, string> _dxVersionMap = new Dictionary<Version, string>();

        static DirectXConfig()
        {
            _dxVersionMap.Add(Dx1Version, "DirectX 1.0");
            
            _dxVersionMap.Add(new Version("4.03.00.1096"), "DirectX 2.0");
            _dxVersionMap.Add(new Version("4.04.00.0068"), "DirectX 3.0");
            _dxVersionMap.Add(new Version("4.04.00.0069"), "DirectX 3.0a");
            _dxVersionMap.Add(new Version("4.04.00.0070"), "DirectX 3.0b");
            _dxVersionMap.Add(new Version("4.05.00.0155"), "DirectX 5.0");
            _dxVersionMap.Add(new Version("4.05.01.1600"), "DirectX 5.2");
            _dxVersionMap.Add(new Version("4.05.01.1998"), "DirectX 5.2");
            _dxVersionMap.Add(new Version("4.06.00.0318"), "DirectX 6.0");
            _dxVersionMap.Add(new Version("4.06.02.0436"), "DirectX 6.1");
            _dxVersionMap.Add(new Version("4.06.03.0518"), "DirectX 6.1a");
            _dxVersionMap.Add(new Version("4.07.00.0700"), "DirectX 7.0");
            _dxVersionMap.Add(new Version("4.07.00.0716"), "DirectX 7.0a");
            _dxVersionMap.Add(new Version("4.07.01.3000"), "DirectX 7.1");
            _dxVersionMap.Add(new Version("4.08.00.0400"), "DirectX 8.0");
            _dxVersionMap.Add(new Version("4.08.01.0810"), "DirectX 8.1");
            _dxVersionMap.Add(new Version("4.08.01.0881"), "DirectX 8.1");
            _dxVersionMap.Add(new Version("4.08.01.0901"), "DirectX 8.1a");
            _dxVersionMap.Add(new Version("4.08.02.0134"), "DirectX 8.2");
            _dxVersionMap.Add(new Version("4.09.00.0900"), "DirectX 9.0");
            _dxVersionMap.Add(new Version("4.09.00.0901"), "DirectX 9.0a");
            _dxVersionMap.Add(new Version("4.09.00.0902"), "DirectX 9.0b");
            _dxVersionMap.Add(new Version("4.09.00.0903"), "DirectX 9.0c");

            _dxVersionMap.Add(Dx9cVersion, "DirectX 9.0c");

            _dxVersionMap.Add(Dx10Version, "DirectX 10");
            _dxVersionMap.Add(new Version("6.00.6001.18000"), "DirectX 10.1");
            _dxVersionMap.Add(new Version("6.00.6002.18005"), "DirectX 10.1");
            _dxVersionMap.Add(new Version("6.01.7600.16385"), "DirectX 11");
            _dxVersionMap.Add(new Version("6.00.6002.18107"), "DirectX 11");
            _dxVersionMap.Add(new Version("6.01.7601.17514"), "DirectX 11");
            _dxVersionMap.Add(new Version("6.02.9200.16384"), "DirectX 11.1");
            _dxVersionMap.Add(new Version("6.03.9600.16384"), "DirectX 11.2");
        }

        public static Version GetDirectXVersion(out string friendlyDirectXName)
        {
            friendlyDirectXName = "DirectX 1.0";
            Version dxVersion = Dx1Version;

            // Try getting the version of DXDIAGN.DLL (i.e. detect DirectX newer than 9.0c)
            try
            {
                string dxModulePath = Path.Combine(Environment.SystemDirectory, DxModuleName);
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(dxModulePath);

                dxVersion = new Version(fvi.FileMajorPart, fvi.FileMinorPart, fvi.FileBuildPart, fvi.FilePrivatePart);
            }
            catch
            {
                dxVersion = Dx1Version;
            }

            if (dxVersion.Major < 6 /* Starting with DirectX 10, major version of dxdiagn.dll is 6 */ )
            {
                // Read from Registry
                try
                {
                    using (RegistryKey key = Registry.LocalMachine.Emu_OpenSubKey(DxRegPath))
                    {
                        if (key != null)
                        {
                            string dxVersionStr = key.GetValue("Version") as string;
                            key.Close();

                            dxVersion = new Version(dxVersionStr);
                        }
                    }
                }
                catch
                {
                    dxVersion = Dx1Version;
                }
            }

            friendlyDirectXName = GetDirectXSymbolicVersion(dxVersion);

            return dxVersion;
        }

        public static string GetDirectXSymbolicVersion(Version dxVersion)
        {
            KeyValuePair<Version, string> newestVersionEntry = _dxVersionMap.ElementAt(0);

            foreach (KeyValuePair<Version, string> kvp in _dxVersionMap)
            {
                if (kvp.Key >= dxVersion)
                    break;

                newestVersionEntry = kvp;
            }

            return newestVersionEntry.Value;
        }
    }
}
