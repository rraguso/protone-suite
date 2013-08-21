using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Runtime.InteropServices.ComTypes;

namespace OPMedia.Core.ComTypes
{
    public enum CLIPFORMAT : uint
    {
        CF_BITMAP = 2,
        CF_DIB = 8,
        CF_DIF = 5,
        CF_DSPBITMAP = 130,
        CF_DSPENHMETAFILE = 0x8e,
        CF_DSPMETAFILEPICT = 0x83,
        CF_DSPTEXT = 0x81,
        CF_ENHMETAFILE = 14,
        CF_GDIOBJFIRST = 0x300,
        CF_GDIOBJLAST = 0x3ff,
        CF_HDROP = 15,
        CF_LOCALE = 0x10,
        CF_MAX = 0x11,
        CF_METAFILEPICT = 3,
        CF_OEMTEXT = 7,
        CF_OWNERDISPLAY = 0x80,
        CF_PALETTE = 9,
        CF_PENDATA = 10,
        CF_PRIVATEFIRST = 0x200,
        CF_PRIVATELAST = 0x2ff,
        CF_RIFF = 11,
        CF_SYLK = 4,
        CF_TEXT = 1,
        CF_TIFF = 6,
        CF_UNICODETEXT = 13,
        CF_WAVE = 12
    }

    [Flags]
    public enum CMF : uint
    {
        CMF_CANRENAME = 0x10,
        CMF_DEFAULTONLY = 1,
        CMF_EXPLORE = 4,
        CMF_INCLUDESTATIC = 0x40,
        CMF_NODEFAULT = 0x20,
        CMF_NORMAL = 0,
        CMF_NOVERBS = 8,
        CMF_RESERVED = 0xffff0000,
        CMF_VERBSONLY = 2
    }
  

    [Flags]
    public enum GCS : uint
    {
        HELPTEXT = 1,
        HELPTEXTA = 1,
        HELPTEXTW = 5,
        UNICODE = 4,
        VALIDATE = 2,
        VALIDATEA = 2,
        VALIDATEW = 6,
        VERB = 0,
        VERBA = 0,
        VERBW = 4
    }

    [ComImport, Guid("E8025004-1C42-11d2-BE2C-00A0C9A83DA1"), ComVisible(false), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IColumnProvider
    {
        [PreserveSig]
        int Initialize(LPCSHCOLUMNINIT psci);
        [PreserveSig]
        int GetColumnInfo(int dwIndex, out SHCOLUMNINFO psci);
        [PreserveSig]
        int GetItemData(LPCSHCOLUMNID pscid, LPCSHCOLUMNDATA pscd, out object pvarData);
    }

    [ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214e4-0000-0000-c000-000000000046")]
    public interface IContextMenu
    {
        [PreserveSig]
        int QueryContextMenu(
            IntPtr /*HMENU*/ hMenu,
            uint iMenu,
            uint idCmdFirst,
            uint idCmdLast,
            uint uFlags);

        void InvokeCommand(IntPtr pici);

        void GetCommandString(
            UIntPtr idCmd,
            uint uFlags,
            IntPtr pReserved,
            StringBuilder pszName,
            uint cchMax);
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CMINVOKECOMMANDINFO
    {
        public uint cbSize;
        public CMIC fMask;
        public IntPtr hwnd;
        public IntPtr verb;
        [MarshalAs(UnmanagedType.LPStr)]
        public string parameters;
        [MarshalAs(UnmanagedType.LPStr)]
        public string directory;
        public int nShow;
        public uint dwHotKey;
        public IntPtr hIcon;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CMINVOKECOMMANDINFOEX
    {
        public uint cbSize;
        public CMIC fMask;
        public IntPtr hwnd;
        public IntPtr verb;
        [MarshalAs(UnmanagedType.LPStr)]
        public string parameters;
        [MarshalAs(UnmanagedType.LPStr)]
        public string directory;
        public int nShow;
        public uint dwHotKey;
        public IntPtr hIcon;
        [MarshalAs(UnmanagedType.LPStr)]
        public string title;
        public IntPtr verbW;
        public string parametersW;
        public string directoryW;
        public string titleW;
        POINT ptInvoke;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct POINT
    {
        public int X;
        public int Y;
    }

    [Flags]
    public enum CMIC : uint
    {
        CMIC_MASK_ICON = 0x00000010,
        CMIC_MASK_HOTKEY = 0x00000020,
        CMIC_MASK_NOASYNC = 0x00000100,
        CMIC_MASK_FLAG_NO_UI = 0x00000400,
        CMIC_MASK_UNICODE = 0x00004000,
        CMIC_MASK_NO_CONSOLE = 0x00008000,
        CMIC_MASK_ASYNCOK = 0x00100000,
        CMIC_MASK_NOZONECHECKS = 0x00800000,
        CMIC_MASK_FLAG_LOG_USAGE = 0x04000000,
        CMIC_MASK_SHIFT_DOWN = 0x10000000,
        CMIC_MASK_PTINVOKE = 0x20000000,
        CMIC_MASK_CONTROL_DOWN = 0x40000000
    }

    [ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214e8-0000-0000-c000-000000000046")]
    public interface IShellExtInit
    {
        void Initialize(
            IntPtr /*LPCITEMIDLIST*/ pidlFolder,
            IntPtr /*LPDATAOBJECT*/ pDataObj,
            IntPtr /*HKEY*/ hKeyProgID);
    }

    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode), ComVisible(false)]
    public class LPCSHCOLUMNDATA
    {
        public uint dwFlags;
        public uint dwFileAttributes;
        public uint dwReserved;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pwszExt;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=260)]
        public string wszFile;
    }

    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public class LPCSHCOLUMNID
    {
        public Guid fmtid;
        public uint pid;
    }

    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode), ComVisible(false)]
    public class LPCSHCOLUMNINIT
    {
        public uint dwFlags;
        public uint dwReserved;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=260)]
        public string wszFolder;
    }

    [ComVisible(false)]
    public enum LVCFMT
    {
        BITMAP_ON_RIGHT = 0x1000,
        CENTER = 2,
        COL_HAS_IMAGES = 0x8000,
        IMAGE = 0x800,
        JUSTIFYMASK = 3,
        LEFT = 0,
        RIGHT = 1
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MENUITEMINFO
    {
        public int cbSize;
        public uint fMask;
        public uint fType;
        public uint fState;
        public int wID;
        public IntPtr hSubMenu;
        public IntPtr hbmpChecked;
        public IntPtr hbmpUnchecked;
        public IntPtr dwItemData;
        public string dwTypeData;
        public uint cch;
        public IntPtr hbmpItem;
    }

    [Flags]
    public enum MF : uint
    {
        APPEND = 0x100,
        BITMAP = 4,
        BYCOMMAND = 0,
        BYPOSITION = 0x400,
        CHANGE = 0x80,
        CHECKED = 8,
        DEFAULT = 0x1000,
        DELETE = 0x200,
        DISABLED = 2,
        ENABLED = 0,
        GRAYED = 1,
        HELP = 0x4000,
        HILITE = 0x80,
        INSERT = 0,
        MENUBARBREAK = 0x20,
        MENUBREAK = 0x40,
        MOUSESELECT = 0x8000,
        OWNERDRAW = 0x100,
        POPUP = 0x10,
        REMOVE = 0x1000,
        RIGHTJUSTIFY = 0x4000,
        SEPARATOR = 0x800,
        STRING = 0,
        SYSMENU = 0x2000,
        UNCHECKED = 0,
        UNHILITE = 0,
        USECHECKBITMAPS = 0x200
    }

    

    [Flags]
    public enum MFS : uint
    {
        BOTTOMGAPDROP = 0x40000000,
        CACHEDBMP = 0x20000000,
        CHECKED = 8,
        DEFAULT = 0x1000,
        DISABLED = 3,
        ENABLED = 0,
        GAPDROP = 0xc0000000,
        GRAYED = 3,
        HILITE = 0x80,
        HOTTRACKDRAWN = 0x10000000,
        MASK = 0x108b,
        TOPGAPDROP = 0x80000000,
        UNCHECKED = 0,
        UNHILITE = 0
    }

    [Flags]
    public enum MIIM : uint
    {
        BITMAP = 0x80,
        CHECKMARKS = 8,
        DATA = 0x20,
        FTYPE = 0x100,
        ID = 2,
        STATE = 1,
        STRING = 0x40,
        SUBMENU = 4,
        TYPE = 0x10
    }

    [ComVisible(false), Flags]
    public enum SHCOLSTATE
    {
        EXTENDED = 0x40,
        HIDDEN = 0x100,
        ONBYDEFAULT = 0x10,
        PREFER_VARCMP = 0x200,
        SECONDARYUI = 0x80,
        SLOW = 0x20,
        TYPE_DATE = 3,
        TYPE_INT = 2,
        TYPE_STR = 1,
        TYPEMASK = 15
    }

    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public struct SHCOLUMNID
    {
        public Guid fmtid;
        public uint pid;
    }

    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode, Pack=1), ComVisible(false)]
    public struct SHCOLUMNINFO
    {
        public SHCOLUMNID scid;
        public ushort vt;
        public LVCFMT fmt;
        public uint cChars;
        public SHCOLSTATE csFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=80)]
        public string wszTitle;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0x80)]
        public string wszDescription;
    }

    [ComImportAttribute()]
    [GuidAttribute("c43dc798-95d1-4bea-9030-bb99e2983a1a")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITaskbarList4
    {
        // ITaskbarList
        [PreserveSig]
        void HrInit();
        [PreserveSig]
        void AddTab(IntPtr hwnd);
        [PreserveSig]
        void DeleteTab(IntPtr hwnd);
        [PreserveSig]
        void ActivateTab(IntPtr hwnd);
        [PreserveSig]
        void SetActiveAlt(IntPtr hwnd);

        // ITaskbarList2
        [PreserveSig]
        void MarkFullscreenWindow(
            IntPtr hwnd,
            [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

        // ITaskbarList3
        [PreserveSig]
        void SetProgressValue(IntPtr hwnd, UInt64 ullCompleted, UInt64 ullTotal);
        [PreserveSig]
        void SetProgressState(IntPtr hwnd, TaskbarProgressBarStatus tbpFlags);
        [PreserveSig]
        void RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);
        [PreserveSig]
        void UnregisterTab(IntPtr hwndTab);
        [PreserveSig]
        void SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);
        [PreserveSig]
        void SetTabActive(IntPtr hwndTab, IntPtr hwndInsertBefore, uint dwReserved);
        [PreserveSig]
        int ThumbBarAddButtons(
            IntPtr hwnd,
            uint cButtons,
            [MarshalAs(UnmanagedType.LPArray)] ThumbButton[] pButtons);
        [PreserveSig]
        int ThumbBarUpdateButtons(
            IntPtr hwnd,
            uint cButtons,
            [MarshalAs(UnmanagedType.LPArray)] ThumbButton[] pButtons);
        [PreserveSig]
        void ThumbBarSetImageList(IntPtr hwnd, IntPtr himl);
        [PreserveSig]
        void SetOverlayIcon(
          IntPtr hwnd,
          IntPtr hIcon,
          [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);
        [PreserveSig]
        void SetThumbnailTooltip(
            IntPtr hwnd,
            [MarshalAs(UnmanagedType.LPWStr)] string pszTip);
        [PreserveSig]
        void SetThumbnailClip(
            IntPtr hwnd,
            IntPtr prcClip);

        // ITaskbarList4
        void SetTabProperties(IntPtr hwndTab, SetTabPropertiesOption stpFlags);
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ThumbButton
    {
        /// <summary>
        /// WPARAM value for a THUMBBUTTON being clicked.
        /// </summary>
        public const int Clicked = 0x1800;

        [MarshalAs(UnmanagedType.U4)]
        public ThumbButtonMask Mask;
        public uint Id;
        public uint Bitmap;
        public IntPtr Icon;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string Tip;
        [MarshalAs(UnmanagedType.U4)]
        public ThumbButtonOptions Flags;
    }

    public enum KnownDestinationCategory
    {
        Frequent = 1,
        Recent
    }

    public enum ShellAddToRecentDocs
    {
        Pidl = 0x1,
        PathA = 0x2,
        PathW = 0x3,
        AppIdInfo = 0x4,       // indicates the data type is a pointer to a SHARDAPPIDINFO structure
        AppIdInfoIdList = 0x5, // indicates the data type is a pointer to a SHARDAPPIDINFOIDLIST structure
        Link = 0x6,            // indicates the data type is a pointer to an IShellLink instance
        AppIdInfoLink = 0x7,   // indicates the data type is a pointer to a SHARDAPPIDINFOLINK structure 
    }

    public enum TaskbarProgressBarStatus
    {
        NoProgress = 0,
        Indeterminate = 0x1,
        Normal = 0x2,
        Error = 0x4,
        Paused = 0x8
    }

    public enum TaskbarActiveTabSetting
    {
        UseMdiThumbnail = 0x1,
        UseMdiLivePreview = 0x2
    }

    public enum ThumbButtonMask
    {
        Bitmap = 0x1,
        Icon = 0x2,
        Tooltip = 0x4,
        THB_FLAGS = 0x8
    }

    [Flags]
    public enum ThumbButtonOptions
    {
        Enabled = 0x00000000,
        Disabled = 0x00000001,
        DismissOnClick = 0x00000002,
        NoBackground = 0x00000004,
        Hidden = 0x00000008,
        NonInteractive = 0x00000010
    }

    public enum SetTabPropertiesOption
    {
        None = 0x0,
        UseAppThumbnailAlways = 0x1,
        UseAppThumbnailWhenActive = 0x2,
        UseAppPeekAlways = 0x4,
        UseAppPeekWhenActive = 0x8
    }

}
