using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;
using System.IO;

namespace OPMedia.Core
{
    /// <summary>
    /// Helper class that holds all the data types and unmanaged
    /// functions imported from Kernel32.dll. Refer to 
    /// MSDN documentation for further information.
    /// </summary>
    public class Kernel32
    {
        public enum CopyFileCallbackAction
        {
            Continue = 0,
            Cancel = 1,
            Stop = 2,
            Quiet = 3
        }

        [Flags]
        public enum CopyFileOptions
        {
            None = 0x0,
            FailIfDestinationExists = 0x1,
            Restartable = 0x2,
            AllowDecryptedDestination = 0x8,
            All = FailIfDestinationExists | Restartable | AllowDecryptedDestination
        }

        public class CopyProgressData
        {
            private FileInfo _source = null;
            private FileInfo _destination = null;
            private CopyFileCallback _callback = null;
            private object _state = null;

            public CopyProgressData(FileInfo source, FileInfo destination,
                CopyFileCallback callback, object state)
            {
                _source = source;
                _destination = destination;
                _callback = callback;
                _state = state;
            }

            public int CallbackHandler(
                long totalFileSize, long totalBytesTransferred,
                long streamSize, long streamBytesTransferred,
                int streamNumber, int callbackReason,
                IntPtr sourceFile, IntPtr destinationFile, IntPtr data)
            {
                if (callbackReason == 0)
                {
                    return (int)_callback(_source, _destination, _state,
                        totalFileSize, totalBytesTransferred);
                }

                return(int) CopyFileCallbackAction.Continue;
            }
        }

        public delegate int CopyProgressRoutine(
                    long totalFileSize, long TotalBytesTransferred, long streamSize,
                    long streamBytesTransferred, int streamNumber, int callbackReason,
                    IntPtr sourceFile, IntPtr destinationFile, IntPtr data);

        public delegate CopyFileCallbackAction CopyFileCallback(
            FileInfo source, FileInfo destination, object state,
            long totalFileSize, long totalBytesTransferred);

        const string KERNEL32 = "kernel32.dll";
        public const int MAX_PATH = 260;
        public const int MAX_FILES = 65536;
        public const int MAX_FILE_BUFFER = 4 * MAX_PATH * MAX_FILES;

        #region OS-Independent
        public static string GetVolumeInformation(string strDriveLetter, ref string label)
        {
            uint serNum = 0;
            uint maxCompLen = 0;
            StringBuilder VolLabel = new StringBuilder(MAX_PATH); // Label
            UInt32 VolFlags = new UInt32();
            StringBuilder FSName = new StringBuilder(MAX_PATH); // File System Name

            long Ret = GetVolumeInformation(strDriveLetter, VolLabel, (UInt32)VolLabel.Capacity, ref serNum,
                ref maxCompLen, ref VolFlags, FSName, (UInt32)FSName.Capacity);

            label = VolLabel.ToString();

            return Convert.ToString(serNum);
        }

        public static string GetVolumeSerialNumber(string strDriveLetter)
        {
            uint serNum = 0;
            uint maxCompLen = 0;
            StringBuilder VolLabel = new StringBuilder(MAX_PATH); // Label
            UInt32 VolFlags = new UInt32();
            StringBuilder FSName = new StringBuilder(MAX_PATH); // File System Name

            long Ret = GetVolumeInformation(strDriveLetter, VolLabel, (UInt32)VolLabel.Capacity, ref serNum,
                ref maxCompLen, ref VolFlags, FSName, (UInt32)FSName.Capacity);

            return Convert.ToString(serNum);
        }
        #endregion

        #region OS_Dependent

        [DllImport(KERNEL32, CharSet = CharSet.Unicode)]
        public static extern int GetLocaleInfo(
            // The locale identifier.
           int Locale,
            // The information type.
           int LCType,
            // The buffer size.
           [In, MarshalAs(UnmanagedType.LPWStr)] string lpLCData, int cchData
         );

        // Import the GlobalSize function
        [DllImport(KERNEL32, CharSet = CharSet.Auto)]
        public static extern Int32 GlobalSize(IntPtr hmem);

        [DllImport(KERNEL32, CharSet = CharSet.Auto)]
        public static extern IntPtr LoadLibrary(string lpModuleName);

        [DllImport(KERNEL32, CharSet=CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport(KERNEL32)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport(KERNEL32, CharSet = CharSet.Auto)]
        public static extern long GetVolumeInformation(string PathName, StringBuilder VolumeNameBuffer, UInt32 VolumeNameSize,
            ref UInt32 VolumeSerialNumber, ref UInt32 MaximumComponentLength, ref UInt32 FileSystemFlags,
            StringBuilder FileSystemNameBuffer, UInt32 FileSystemNameSize);

        [DllImport(KERNEL32, CharSet = CharSet.Auto)]
        public static extern uint FormatMessage(uint dwFlags, IntPtr lpSource,
            uint dwMessageId, uint dwLanguageId, [Out] StringBuilder lpBuffer,
            uint nSize, IntPtr Arguments);
        
        [DllImport(KERNEL32, CharSet = CharSet.Auto)]
        public extern static int GetLastError();

        [DllImport(KERNEL32, CharSet = CharSet.Auto)]
        public extern static bool FreeLibrary(IntPtr hModule);

        [DllImport(KERNEL32, CharSet = CharSet.Auto)]
        public extern static void CloseHandle(IntPtr hModule);

        [DllImport(KERNEL32, CharSet = CharSet.Auto)]
        public extern static uint WinExec(string lpCmdLine, uint uCmdShow);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(KERNEL32, CharSet = CharSet.Auto)]
        public static extern bool CopyFileEx(string lpExistingFileName, string lpNewFileName,
            CopyProgressRoutine lpProgressRoutine, IntPtr lpData, ref bool pbCancel, int dwCopyFlags);

        [DllImport(KERNEL32, CharSet = CharSet.Auto)]
        public static extern uint GetPrivateProfileInt(string lpAppName, string lpKeyName,
           int nDefault, string lpFileName);

        [DllImport(KERNEL32, CharSet = CharSet.Auto)]
        public static extern uint GetPrivateProfileString(
           string lpAppName,
           string lpKeyName,
           string lpDefault,
           StringBuilder lpReturnedString,
           uint nSize,
           string lpFileName);

        [DllImport(KERNEL32, CharSet = CharSet.Auto)]
        public static extern bool WritePrivateProfileString(string lpAppName,
           string lpKeyName, string lpString, string lpFileName);

        #endregion
    }

    public static class WinError
    {
        public const int S_OK = 0x0000;
        public const int S_FALSE = 0x0001;
        public const int E_FAIL = -2147467259;
        public const int E_INVALIDARG = -2147024809;
        public const int E_OUTOFMEMORY = -2147024882;
        public const int STRSAFE_E_INSUFFICIENT_BUFFER = -2147024774;

        public const uint SEVERITY_SUCCESS = 0;
        public const uint SEVERITY_ERROR = 1;

        /// <summary>
        /// Create an HRESULT value from component pieces.
        /// </summary>
        /// <param name="sev">The severity to be used</param>
        /// <param name="fac">The facility to be used</param>
        /// <param name="code">The error number</param>
        /// <returns>A HRESULT constructed from the above 3 values</returns>
        public static int MAKE_HRESULT(uint sev, uint fac, uint code)
        {
            return (int)((sev << 31) | (fac << 16) | code);
        }
    }
}
