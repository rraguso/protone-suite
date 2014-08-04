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
        const string KERNEL32 = "kernel32.dll";
        public const int MAX_PATH = 260;
        public const int MAX_FILES = 65536;
        public const int MAX_FILE_BUFFER = 4 * MAX_PATH * MAX_FILES;


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

        public enum DriveTypes : uint
        {
            DRIVE_UNKNOWN = 0,
            DRIVE_NO_ROOT_DIR,
            DRIVE_REMOVABLE,
            DRIVE_FIXED,
            DRIVE_REMOTE,
            DRIVE_CDROM,
            DRIVE_RAMDISK
        };

        //DesiredAccess values
        public const uint GENERIC_READ = 0x80000000;
        public const uint GENERIC_WRITE = 0x40000000;
        public const uint GENERIC_EXECUTE = 0x20000000;
        public const uint GENERIC_ALL = 0x10000000;

        //Share constants
        public const uint FILE_SHARE_READ = 0x00000001;
        public const uint FILE_SHARE_WRITE = 0x00000002;
        public const uint FILE_SHARE_DELETE = 0x00000004;

        //CreationDisposition constants
        public const uint CREATE_NEW = 1;
        public const uint CREATE_ALWAYS = 2;
        public const uint OPEN_EXISTING = 3;
        public const uint OPEN_ALWAYS = 4;
        public const uint TRUNCATE_EXISTING = 5;

        public const uint IOCTL_CDROM_READ_TOC = 0x00024000;
        public const uint IOCTL_STORAGE_CHECK_VERIFY = 0x002D4800;
        public const uint IOCTL_CDROM_RAW_READ = 0x0002403E;
        public const uint IOCTL_STORAGE_MEDIA_REMOVAL = 0x002D4804;
        public const uint IOCTL_STORAGE_EJECT_MEDIA = 0x002D4808;
        public const uint IOCTL_STORAGE_LOAD_MEDIA = 0x002D480C;

        public const uint IOCTL_CDROM_READ_TOC_EX = 0x00024054;

        [StructLayout(LayoutKind.Sequential)]
        public struct TRACK_DATA
        {
            public byte Reserved;
            private byte BitMapped;
            public byte Control
            {
                get
                {
                    return (byte)(BitMapped & 0x0F);
                }
                set
                {
                    BitMapped = (byte)((BitMapped & 0xF0) | (value & (byte)0x0F));
                }
            }
            public byte Adr
            {
                get
                {
                    return (byte)((BitMapped & (byte)0xF0) >> 4);
                }
                set
                {
                    BitMapped = (byte)((BitMapped & (byte)0x0F) | (value << 4));
                }
            }
            public byte TrackNumber;
            public byte Reserved1;
            /// <summary>
            /// Don't use array to avoid array creation
            /// </summary>
            public byte Address_0;
            public byte Address_1;
            public byte Address_2;
            public byte Address_3;
        };

        public const int MAXIMUM_NUMBER_TRACKS = 100;

        [StructLayout(LayoutKind.Sequential)]
        public class TrackDataList
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAXIMUM_NUMBER_TRACKS * 8)]
            private byte[] Data;
            public TRACK_DATA this[int Index]
            {
                get
                {
                    if ((Index < 0) | (Index >= MAXIMUM_NUMBER_TRACKS))
                    {
                        throw new IndexOutOfRangeException();
                    }
                    TRACK_DATA res;
                    GCHandle handle = GCHandle.Alloc(Data, GCHandleType.Pinned);
                    try
                    {
                        IntPtr buffer = handle.AddrOfPinnedObject();
                        buffer = (IntPtr)(buffer.ToInt32() + (Index * Marshal.SizeOf(typeof(TRACK_DATA))));
                        res = (TRACK_DATA)Marshal.PtrToStructure(buffer, typeof(TRACK_DATA));
                    }
                    finally
                    {
                        handle.Free();
                    }
                    return res;
                }
            }
            public TrackDataList()
            {
                Data = new byte[MAXIMUM_NUMBER_TRACKS * Marshal.SizeOf(typeof(TRACK_DATA))];
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class CDROM_TOC
        {
            public ushort Length;
            public byte FirstTrack = 0;
            public byte LastTrack = 0;

            public TrackDataList TrackData;

            public CDROM_TOC()
            {
                TrackData = new TrackDataList();
                Length = (ushort)Marshal.SizeOf(this);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class PREVENT_MEDIA_REMOVAL
        {
            public byte PreventMediaRemoval = 0;
        }

        public enum TRACK_MODE_TYPE { YellowMode2, XAForm2, CDDA }
        [StructLayout(LayoutKind.Sequential)]
        public class RAW_READ_INFO
        {
            public long DiskOffset = 0;
            public uint SectorCount = 0;
            public TRACK_MODE_TYPE TrackMode = TRACK_MODE_TYPE.CDDA;
        }

        public const int MINIMUM_CDROM_READ_TOC_EX_SIZE = 2;

        public enum CDROM_READ_TOC_EX_FORMAT
        {
            TOC,
            SESSION,
            FULL_TOC,
            PMA,
            ATIP,
            CDTEXT
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct CDROM_READ_TOC_EX
        {
            public uint bitVector;

            public CDROM_READ_TOC_EX_FORMAT Format
            {
                get { return ((CDROM_READ_TOC_EX_FORMAT)((this.bitVector & 15u))); }
                set { this.bitVector = (uint)((byte)value | this.bitVector); }
            }

            public uint Reserved1
            {
                get { return ((uint)(((this.bitVector & 112u) / 16))); }
                set { this.bitVector = ((uint)(((value * 16) | this.bitVector))); }
            }

            public uint Msf
            {
                get { return ((uint)(((this.bitVector & 128u) / 128))); }
                set { this.bitVector = ((uint)(((value * 128) | this.bitVector))); }
            }

            public byte SessionTrack;
            public byte Reserved2;
            public byte Reserved3;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class CDROM_TOC_CD_TEXT_DATA
        {
            public ushort Length;
            public byte Reserved1;
            public byte Reserved2;
            public CDROM_TOC_CD_TEXT_DATA_BLOCK_ARRAY Descriptors;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public sealed class CDROM_TOC_CD_TEXT_DATA_BLOCK_ARRAY
        {
            internal CDROM_TOC_CD_TEXT_DATA_BLOCK_ARRAY() { data = new byte[MaxIndex * Marshal.SizeOf(typeof(CDROM_TOC_CD_TEXT_DATA_BLOCK))]; }

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MINIMUM_CDROM_READ_TOC_EX_SIZE * MAXIMUM_NUMBER_TRACKS * 18)]
            private byte[] data;

            public int MaxIndex
            {
                get { return MINIMUM_CDROM_READ_TOC_EX_SIZE * MAXIMUM_NUMBER_TRACKS; }
            }

            public CDROM_TOC_CD_TEXT_DATA_BLOCK this[int idx]
            {
                get
                {
                    if ((idx < 0) || (idx >= MaxIndex)) throw new IndexOutOfRangeException();

                    CDROM_TOC_CD_TEXT_DATA_BLOCK res;

                    GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);

                    try
                    {
                        IntPtr buffer = hData.AddrOfPinnedObject();

                        buffer = (IntPtr)(buffer.ToInt32() + (idx * Marshal.SizeOf(typeof(CDROM_TOC_CD_TEXT_DATA_BLOCK))));

                        res = (CDROM_TOC_CD_TEXT_DATA_BLOCK)Marshal.PtrToStructure(buffer, typeof(CDROM_TOC_CD_TEXT_DATA_BLOCK));
                    }
                    finally
                    {
                        hData.Free();
                    }

                    return res;
                }
            }
        }

        public enum CDROM_CD_TEXT_PACK : byte
        {
            ALBUM_NAME = 0x80,
            PERFORMER = 0x81,
            SONGWRITER = 0x82,
            COMPOSER = 0x83,
            ARRANGER = 0x84,
            MESSAGES = 0x85,
            DISC_ID = 0x86,
            GENRE = 0x87,
            TOC_INFO = 0x88,
            TOC_INFO2 = 0x89,
            UPC_EAN = 0x8e,
            SIZE_INFO = 0x8f
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct CDROM_TOC_CD_TEXT_DATA_BLOCK
        {
            public CDROM_CD_TEXT_PACK PackType;

            public byte bitVector1;

            public byte TrackNumber
            {
                get { return ((byte)((this.bitVector1 & 127u))); }
                set { this.bitVector1 = ((byte)((value | this.bitVector1))); }
            }

            public byte ExtensionFlag
            {
                get { return ((byte)(((this.bitVector1 & 128u) / 128))); }
                set { this.bitVector1 = ((byte)(((value * 128) | this.bitVector1))); }
            }

            public byte SequenceNumber;

            public byte bitVector2;

            public byte CharacterPosition
            {
                get { return ((byte)((this.bitVector2 & 15u))); }
                set { this.bitVector2 = ((byte)((value | this.bitVector2))); }
            }

            public byte BlockNumber
            {
                get { return ((byte)(((this.bitVector2 & 112u) / 16))); }
                set { this.bitVector2 = ((byte)(((value * 16) | this.bitVector2))); }
            }

            public byte Unicode
            {
                get { return ((byte)(((this.bitVector2 & 128u) / 128))); }
                set { this.bitVector2 = ((byte)(((value * 128) | this.bitVector2))); }
            }

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
            public byte[] TextBuffer;

            public string Text
            {
                get { return (Unicode == 1) ? ASCIIEncoding.ASCII.GetString(TextBuffer) : UTF32Encoding.UTF8.GetString(TextBuffer); }
            }

            public ushort CRC;
        }

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
#if HAVE_MONO
        public static void OutputDebugString(string _text)
        {
        }

        public static void CopyMemory(IntPtr Destination, IntPtr Source, int Length)
        {
        }

        public static DriveTypes GetDriveType(string drive)
        {
            return DriveTypes.DRIVE_FIXED;
        }

        public static IntPtr CreateFile(string FileName, uint DesiredAccess,
          uint ShareMode, IntPtr lpSecurityAttributes,
          uint CreationDisposition, uint dwFlagsAndAttributes,
          IntPtr hTemplateFile)
        {
            return IntPtr.Zero;
        }

        public static int CloseHandle(IntPtr hObject)
        {
            return -1;
        }

        public static int DeviceIoControl(IntPtr hDevice, uint IoControlCode,
          IntPtr lpInBuffer, uint InBufferSize,
          IntPtr lpOutBuffer, uint nOutBufferSize,
          ref uint lpBytesReturned,
          IntPtr lpOverlapped)
        {
            return -1;
        }

        public static int DeviceIoControl(IntPtr hDevice, uint IoControlCode,
          IntPtr InBuffer, uint InBufferSize,
          [Out] CDROM_TOC OutTOC, uint OutBufferSize,
          ref uint BytesReturned,
          IntPtr Overlapped)
        {
            return -1;
        }

        public static int DeviceIoControl(IntPtr hDevice, uint IoControlCode,
          [In] PREVENT_MEDIA_REMOVAL InMediaRemoval, uint InBufferSize,
          IntPtr OutBuffer, uint OutBufferSize,
          ref uint BytesReturned,
          IntPtr Overlapped)
        {
            return -1;
        }

        public static int DeviceIoControl(IntPtr hDevice, uint IoControlCode,
          [In] RAW_READ_INFO rri, uint InBufferSize,
          [In, Out] byte[] OutBuffer, uint OutBufferSize,
          ref uint BytesReturned,
          IntPtr Overlapped)
        {
            return -1;
        }

        public static Int32 GlobalSize(IntPtr hmem)
        {
            return -1;
        }

        public static IntPtr LoadLibrary(string lpModuleName)
        {
            return IntPtr.Zero;
        }

        public static IntPtr GetModuleHandle(string lpModuleName)
        {
            return IntPtr.Zero;
        }

        public static IntPtr GetProcAddress(IntPtr hModule, string lpProcName)
        {
            return IntPtr.Zero;
        }

        public static long GetVolumeInformation(string PathName, StringBuilder VolumeNameBuffer, UInt32 VolumeNameSize,
            ref UInt32 VolumeSerialNumber, ref UInt32 MaximumComponentLength, ref UInt32 FileSystemFlags,
            StringBuilder FileSystemNameBuffer, UInt32 FileSystemNameSize)
        {
            return 0;
        }

        public static int GetLastError()
        {
            return -1;
        }

        public static bool FreeLibrary(IntPtr hModule)
        {
            return false;
        }

        public static bool CopyFileEx(string lpExistingFileName, string lpNewFileName,
            CopyProgressRoutine lpProgressRoutine, IntPtr lpData, ref bool pbCancel, int dwCopyFlags)
        {
            return false;
        }

        public static uint GetPrivateProfileInt(string lpAppName, string lpKeyName,
           int nDefault, string lpFileName)
        {
            return 0xFFFFFFFF;
        }

        public static uint GetPrivateProfileString(
           string lpAppName,
           string lpKeyName,
           string lpDefault,
           StringBuilder lpReturnedString,
           uint nSize,
           string lpFileName)
        {
            return 0xFFFFFFFF;
        }

        public static bool WritePrivateProfileString(string lpAppName,
           string lpKeyName, string lpString, string lpFileName)
        {
            return false;
        }
#else
        [DllImport(KERNEL32, EntryPoint = "OutputDebugStringW", CharSet = CharSet.Unicode)]
        public static extern void OutputDebugString(string _text);

        [DllImport(KERNEL32, EntryPoint = "RtlMoveMemory")]
        public static extern void CopyMemory(IntPtr Destination, IntPtr Source, [MarshalAs(UnmanagedType.U4)] int Length);

        [DllImport(KERNEL32)]
        public extern static DriveTypes GetDriveType(string drive);

        /// <summary>
        /// Win32 CreateFile function, look for complete information at Platform SDK
        /// </summary>
        /// <param name="FileName">In order to read CD data FileName must be "\\.\\D:" where D is the CDROM drive letter</param>
        /// <param name="DesiredAccess">Must be GENERIC_READ for CDROMs others access flags are not important in this case</param>
        /// <param name="ShareMode">O means exlusive access, FILE_SHARE_READ allow open the CDROM</param>
        /// <param name="lpSecurityAttributes">See Platform SDK documentation for details. NULL pointer could be enough</param>
        /// <param name="CreationDisposition">Must be OPEN_EXISTING for CDROM drives</param>
        /// <param name="dwFlagsAndAttributes">0 in fine for this case</param>
        /// <param name="hTemplateFile">NULL handle in this case</param>
        /// <returns>INVALID_HANDLE_VALUE on error or the handle to file if success</returns>
        [DllImport(KERNEL32, SetLastError = true)]
        public extern static IntPtr CreateFile(string FileName, uint DesiredAccess,
          uint ShareMode, IntPtr lpSecurityAttributes,
          uint CreationDisposition, uint dwFlagsAndAttributes,
          IntPtr hTemplateFile);

        /// <summary>
        /// The CloseHandle function closes an open object handle.
        /// </summary>
        /// <param name="hObject">Handle to an open object.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport(KERNEL32, SetLastError = true)]
        public extern static int CloseHandle(IntPtr hObject);

        /// <summary>
        /// Most general form of DeviceIoControl Win32 function
        /// </summary>
        /// <param name="hDevice">Handle of device opened with CreateFile, <see cref="Ripper.Win32Functions.CreateFile"/></param>
        /// <param name="IoControlCode">Code of DeviceIoControl operation</param>
        /// <param name="lpInBuffer">Pointer to a buffer that contains the data required to perform the operation.</param>
        /// <param name="InBufferSize">Size of the buffer pointed to by lpInBuffer, in bytes.</param>
        /// <param name="lpOutBuffer">Pointer to a buffer that receives the operation's output data.</param>
        /// <param name="nOutBufferSize">Size of the buffer pointed to by lpOutBuffer, in bytes.</param>
        /// <param name="lpBytesReturned">Receives the size, in bytes, of the data stored into the buffer pointed to by lpOutBuffer. </param>
        /// <param name="lpOverlapped">Pointer to an OVERLAPPED structure. Discarded for this case</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
        [DllImport(KERNEL32, SetLastError = true)]
        public extern static int DeviceIoControl(IntPtr hDevice, uint IoControlCode,
          IntPtr lpInBuffer, uint InBufferSize,
          IntPtr lpOutBuffer, uint nOutBufferSize,
          ref uint lpBytesReturned,
          IntPtr lpOverlapped);

        /// <summary>
        /// Overload version of DeviceIOControl to read the TOC (Table of contents)
        /// </summary>
        /// <param name="hDevice">Handle of device opened with CreateFile, <see cref="Ripper.Win32Functions.CreateFile"/></param>
        /// <param name="IoControlCode">Must be IOCTL_CDROM_READ_TOC for this overload version</param>
        /// <param name="InBuffer">Must be <code>IntPtr.Zero</code> for this overload version </param>
        /// <param name="InBufferSize">Must be 0 for this overload version</param>
        /// <param name="OutTOC">TOC object that receive the CDROM TOC</param>
        /// <param name="OutBufferSize">Must be <code>(UInt32)Marshal.SizeOf(CDROM_TOC)</code> for this overload version</param>
        /// <param name="BytesReturned">Receives the size, in bytes, of the data stored into OutTOC</param>
        /// <param name="Overlapped">Pointer to an OVERLAPPED structure. Discarded for this case</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
        [DllImport(KERNEL32, SetLastError = true)]
        public extern static int DeviceIoControl(IntPtr hDevice, uint IoControlCode,
          IntPtr InBuffer, uint InBufferSize,
          [Out] CDROM_TOC OutTOC, uint OutBufferSize,
          ref uint BytesReturned,
          IntPtr Overlapped);


        /// <summary>
        /// Overload version of DeviceIOControl to lock/unlock the CD
        /// </summary>
        /// <param name="hDevice">Handle of device opened with CreateFile, <see cref="Ripper.Win32Functions.CreateFile"/></param>
        /// <param name="IoControlCode">Must be IOCTL_STORAGE_MEDIA_REMOVAL for this overload version</param>
        /// <param name="InMediaRemoval">Set the lock/unlock state</param>
        /// <param name="InBufferSize">Must be <code>(UInt32)Marshal.SizeOf(PREVENT_MEDIA_REMOVAL)</code> for this overload version</param>
        /// <param name="OutBuffer">Must be <code>IntPtr.Zero</code> for this overload version </param>
        /// <param name="OutBufferSize">Must be 0 for this overload version</param>
        /// <param name="BytesReturned">A "dummy" varible in this case</param>
        /// <param name="Overlapped">Pointer to an OVERLAPPED structure. Discarded for this case</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
        [DllImport(KERNEL32, SetLastError = true)]
        public extern static int DeviceIoControl(IntPtr hDevice, uint IoControlCode,
          [In] PREVENT_MEDIA_REMOVAL InMediaRemoval, uint InBufferSize,
          IntPtr OutBuffer, uint OutBufferSize,
          ref uint BytesReturned,
          IntPtr Overlapped);

        /// <summary>
        /// Overload version of DeviceIOControl to read digital data
        /// </summary>
        /// <param name="hDevice">Handle of device opened with CreateFile, <see cref="Ripper.Win32Functions.CreateFile"</param>
        /// <param name="IoControlCode">Must be IOCTL_CDROM_RAW_READ for this overload version</param>
        /// <param name="rri">RAW_READ_INFO structure</param>
        /// <param name="InBufferSize">Size of RAW_READ_INFO structure</param>
        /// <param name="OutBuffer">Buffer that will receive the data to be read</param>
        /// <param name="OutBufferSize">Size of the buffer</param>
        /// <param name="BytesReturned">Receives the size, in bytes, of the data stored into OutBuffer</param>
        /// <param name="Overlapped">Pointer to an OVERLAPPED structure. Discarded for this case</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
        [DllImport(KERNEL32, SetLastError = true)]
        public extern static int DeviceIoControl(IntPtr hDevice, uint IoControlCode,
          [In] RAW_READ_INFO rri, uint InBufferSize,
          [In, Out] byte[] OutBuffer, uint OutBufferSize,
          ref uint BytesReturned,
          IntPtr Overlapped);

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
        public extern static int GetLastError();

        [DllImport(KERNEL32, CharSet = CharSet.Auto)]
        public extern static bool FreeLibrary(IntPtr hModule);

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
#endif
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
