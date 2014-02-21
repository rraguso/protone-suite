using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OPMedia.Core.Win32
{
    /// <summary>
    /// Type of share
    /// </summary>
    [Flags]
    public enum ShareType
    {
        /// <summary>Disk share</summary>
        Disk = 0,
        /// <summary>Printer share</summary>
        Printer = 1,
        /// <summary>Device share</summary>
        Device = 2,
        /// <summary>IPC share</summary>
        IPC = 3,
        /// <summary>Special share</summary>
        Special = -2147483648, // 0x80000000,
    }

    /// <summary>Unc name</summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct UNIVERSAL_NAME_INFO
    {
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpUniversalName;
    }

    /// <summary>Share information, NT, level 2</summary>
    /// <remarks>
    /// Requires admin rights to work. 
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHARE_INFO_2
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string NetName;
        public ShareType ShareType;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Remark;
        public int Permissions;
        public int MaxUsers;
        public int CurrentUsers;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Path;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Password;
    }

    /// <summary>Share information, NT, level 1</summary>
    /// <remarks>
    /// Fallback when no admin rights.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHARE_INFO_1
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string NetName;
        public ShareType ShareType;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Remark;
    }

    /// <summary>Share information, Win9x</summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct SHARE_INFO_50
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string NetName;

        public byte bShareType;
        public ushort Flags;

        [MarshalAs(UnmanagedType.LPTStr)]
        public string Remark;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string Path;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string PasswordRW;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string PasswordRO;

        public ShareType ShareType
        {
            get { return (ShareType)((int)bShareType & 0x7F); }
        }
    }

    /// <summary>Share information level 1, Win9x</summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct SHARE_INFO_1_9x
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string NetName;
        public byte Padding;

        public ushort bShareType;

        [MarshalAs(UnmanagedType.LPTStr)]
        public string Remark;

        public ShareType ShareType
        {
            get { return (ShareType)((int)bShareType & 0x7FFF); }
        }
    }


    public class UncUtilities
    {
        #region Constants

        /// <summary>Maximum path length</summary>
        public const int MAX_PATH = 260;
        /// <summary>No error</summary>
        public const int NO_ERROR = 0;
        /// <summary>Access denied</summary>
        public const int ERROR_ACCESS_DENIED = 5;
        /// <summary>Access denied</summary>
        public const int ERROR_WRONG_LEVEL = 124;
        /// <summary>More data available</summary>
        public const int ERROR_MORE_DATA = 234;
        /// <summary>Not connected</summary>
        public const int ERROR_NOT_CONNECTED = 2250;
        /// <summary>Level 1</summary>
        public const int UNIVERSAL_NAME_INFO_LEVEL = 1;
        /// <summary>Max extries (9x)</summary>
        public const int MAX_SI50_ENTRIES = 20;

        #endregion

        /// <summary>Get a UNC name</summary>
        [DllImport("mpr", CharSet = CharSet.Auto)]
        public static extern int WNetGetUniversalName(string lpLocalPath,
            int dwInfoLevel, ref UNIVERSAL_NAME_INFO lpBuffer, ref int lpBufferSize);

        /// <summary>Get a UNC name</summary>
        [DllImport("mpr", CharSet = CharSet.Auto)]
        public static extern int WNetGetUniversalName(string lpLocalPath,
            int dwInfoLevel, IntPtr lpBuffer, ref int lpBufferSize);

        /// <summary>Enumerate shares (NT)</summary>
        [DllImport("netapi32", CharSet = CharSet.Unicode)]
        public static extern int NetShareEnum(string lpServerName, int dwLevel,
            out IntPtr lpBuffer, int dwPrefMaxLen, out int entriesRead,
            out int totalEntries, ref int hResume);

        /// <summary>Enumerate shares (9x)</summary>
        [DllImport("svrapi", CharSet = CharSet.Ansi)]
        public static extern int NetShareEnum(
            [MarshalAs(UnmanagedType.LPTStr)] string lpServerName, int dwLevel,
            IntPtr lpBuffer, ushort cbBuffer, out ushort entriesRead,
            out ushort totalEntries);

        /// <summary>Free the buffer (NT)</summary>
        [DllImport("netapi32")]
        public static extern int NetApiBufferFree(IntPtr lpBuffer);
    }
}
