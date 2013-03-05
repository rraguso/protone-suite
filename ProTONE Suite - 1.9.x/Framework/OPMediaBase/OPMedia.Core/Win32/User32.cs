using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace OPMedia.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public int Width { get { return Right - Left; } }
        public int Height { get { return Bottom - Top; } }

        public Rectangle ToRectangle()
        {
            return new Rectangle(Left, Top, Width, Height);
        }

        public static RECT FromRectangle(Rectangle rc)
        {
            RECT rcx = new RECT();
            rcx.Left = rc.Left;
            rcx.Top = rc.Top;
            rcx.Right = rc.Right;
            rcx.Bottom = rc.Bottom;

            return rcx;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
        public IntPtr hwnd;
        public IntPtr hwndInsertAfter;
        public int x;
        public int y;
        public int cx;
        public int cy;
        public uint flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct COMBOBOXINFO
    {
        public int cbSize;
        public RECT rcItem;
        public RECT rcButton;
        public int stateButton;
        public IntPtr hwndCombo;
        public IntPtr hwndItem;
        public IntPtr hwndList;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct HDITEM
    {
        public uint mask;
        public int cxy;
        public IntPtr pszText;
        public IntPtr hbm;
        public int cchTextMax;
        public int fmt;
        public IntPtr lParam;
        public int iImage;
        public int iOrder;
        public uint type;
        public IntPtr pvFilter;
    }
    
    [Flags]
    public enum WindowStyle : uint
    {
        Popup = 0x80000000,
        Overlapped = 0,
        TabStop = 0x00010000,
        MaximizeBox = 0x00010000,
        MinimizeBox = 0x00020000,
        Group = 0x00020000,
        ThickFrame = 0x00040000,
        SysMenu = 0x00080000,
        HScroll = 0x00100000,
        VScroll = 0x00200000,
        DlgFrame = 0x00400000,
        Border = 0x00800000,
        Caption = 0x00C00000,
        Maximize = 0x01000000,
        ClipChildren = 0x02000000,
        ClipSiblings = 0x04000000,
        Disabled = 0x08000000,
        Visible = 0x10000000,
        Minimize = 0x20000000,
        Child = 0x40000000,
    }

    public enum ScrollBarConstants
    {
        SB_HORZ = 0,
        SB_VERT = 0x1,
        SB_THUMBPOSITION = 4,
    }

    [Flags]
    public enum WindowExtendedStyles
    {
        WS_EX_DLGMODALFRAME = 0x00000001,
        WS_EX_NOPARENTNOTIFY = 0x00000004,
        WS_EX_TOPMOST = 0x00000008,
        WS_EX_ACCEPTFILES = 0x00000010,
        WS_EX_TRANSPARENT = 0x00000020,
        WS_EX_MDICHILD = 0x00000040,
        WS_EX_TOOLWINDOW = 0x00000080,
        WS_EX_WINDOWEDGE = 0x00000100,
        WS_EX_CLIENTEDGE = 0x00000200,
        WS_EX_CONTEXTHELP = 0x00000400,
        WS_EX_RIGHT = 0x00001000,
        WS_EX_LEFT = 0x00000000,
        WS_EX_RTLREADING = 0x00002000,
        WS_EX_LTRREADING = 0x00000000,
        WS_EX_LEFTSCROLLBAR = 0x00004000,
        WS_EX_RIGHTSCROLLBAR = 0x00000000,
        WS_EX_CONTROLPARENT = 0x00010000,
        WS_EX_STATICEDGE = 0x00020000,
        WS_EX_APPWINDOW = 0x00040000,
        WS_EX_OVERLAPPEDWINDOW = 0x00000300,
        WS_EX_PALETTEWINDOW = 0x00000188,
        WS_EX_LAYERED = 0x00080000
    }

    public enum Messages
    {
        WM_NULL = 0x0000,
        WM_CREATE = 0x0001,
        WM_DESTROY = 0x0002,
        WM_MOVE = 0x0003,
        WM_SIZE = 0x0005,
        WM_ACTIVATE = 0x0006,
        WM_SETFOCUS = 0x0007,
        WM_KILLFOCUS = 0x0008,
        WM_ENABLE = 0x000A,
        WM_SETREDRAW = 0x000B,
        WM_SETTEXT = 0x000C,
        WM_GETTEXT = 0x000D,
        WM_GETTEXTLENGTH = 0x000E,
        WM_PAINT = 0x000F,
        WM_CLOSE = 0x0010,
        WM_QUERYENDSESSION = 0x0011,
        WM_QUIT = 0x0012,
        WM_QUERYOPEN = 0x0013,
        WM_ERASEBKGND = 0x0014,
        WM_SYSCOLORCHANGE = 0x0015,
        WM_ENDSESSION = 0x0016,
        WM_SHOWWINDOW = 0x0018,
        WM_CTLCOLOR = 0x0019,
        WM_WININICHANGE = 0x001A,
        WM_SETTINGCHANGE = 0x001A,
        WM_DEVMODECHANGE = 0x001B,
        WM_ACTIVATEAPP = 0x001C,
        WM_FONTCHANGE = 0x001D,
        WM_TIMECHANGE = 0x001E,
        WM_CANCELMODE = 0x001F,
        WM_SETCURSOR = 0x0020,
        WM_MOUSEACTIVATE = 0x0021,
        WM_CHILDACTIVATE = 0x0022,
        WM_QUEUESYNC = 0x0023,
        WM_GETMINMAXINFO = 0x0024,
        WM_PAINTICON = 0x0026,
        WM_ICONERASEBKGND = 0x0027,
        WM_NEXTDLGCTL = 0x0028,
        WM_SPOOLERSTATUS = 0x002A,
        WM_DRAWITEM = 0x002B,
        WM_MEASUREITEM = 0x002C,
        WM_DELETEITEM = 0x002D,
        WM_VKEYTOITEM = 0x002E,
        WM_CHARTOITEM = 0x002F,
        WM_SETFONT = 0x0030,
        WM_GETFONT = 0x0031,
        WM_SETHOTKEY = 0x0032,
        WM_GETHOTKEY = 0x0033,
        WM_QUERYDRAGICON = 0x0037,
        WM_COMPAREITEM = 0x0039,
        WM_GETOBJECT = 0x003D,
        WM_COMPACTING = 0x0041,
        WM_COMMNOTIFY = 0x0044,
        WM_WINDOWPOSCHANGING = 0x0046,
        WM_WINDOWPOSCHANGED = 0x0047,
        WM_POWER = 0x0048,
        WM_COPYDATA = 0x004A,
        WM_CANCELJOURNAL = 0x004B,
        WM_NOTIFY = 0x004E,
        WM_INPUTLANGCHANGEREQUEST = 0x0050,
        WM_INPUTLANGCHANGE = 0x0051,
        WM_TCARD = 0x0052,
        WM_HELP = 0x0053,
        WM_USERCHANGED = 0x0054,
        WM_NOTIFYFORMAT = 0x0055,
        WM_CONTEXTMENU = 0x007B,
        WM_STYLECHANGING = 0x007C,
        WM_STYLECHANGED = 0x007D,
        WM_DISPLAYCHANGE = 0x007E,
        WM_GETICON = 0x007F,
        WM_SETICON = 0x0080,
        WM_NCCREATE = 0x0081,
        WM_NCDESTROY = 0x0082,
        WM_NCCALCSIZE = 0x0083,
        WM_NCHITTEST = 0x0084,
        WM_NCPAINT = 0x0085,
        WM_NCACTIVATE = 0x0086,
        WM_GETDLGCODE = 0x0087,
        WM_SYNCPAINT = 0x0088,
        WM_NCMOUSEMOVE = 0x00A0,
        WM_NCLBUTTONDOWN = 0x00A1,
        WM_NCLBUTTONUP = 0x00A2,
        WM_NCLBUTTONDBLCLK = 0x00A3,
        WM_NCRBUTTONDOWN = 0x00A4,
        WM_NCRBUTTONUP = 0x00A5,
        WM_NCRBUTTONDBLCLK = 0x00A6,
        WM_NCMBUTTONDOWN = 0x00A7,
        WM_NCMBUTTONUP = 0x00A8,
        WM_NCMBUTTONDBLCLK = 0x00A9,
        WM_NCXBUTTONDOWN = 0x00AB,
        WM_NCXBUTTONUP = 0x00AC,
        WM_NCXBUTTONDBLCLK = 0x00AD,

        WM_INPUT = 0x00FF,
        
        WM_KEYDOWN = 0x0100,
        WM_KEYUP = 0x0101,
        WM_CHAR = 0x0102,
        WM_DEADCHAR = 0x0103,
        WM_SYSKEYDOWN = 0x0104,
        WM_SYSKEYUP = 0x0105,
        WM_SYSCHAR = 0x0106,
        WM_SYSDEADCHAR = 0x0107,
        WM_KEYLAST = 0x0108,
        WM_IME_STARTCOMPOSITION = 0x010D,
        WM_IME_ENDCOMPOSITION = 0x010E,
        WM_IME_COMPOSITION = 0x010F,
        WM_IME_KEYLAST = 0x010F,
        WM_INITDIALOG = 0x0110,
        WM_COMMAND = 0x0111,
        WM_SYSCOMMAND = 0x0112,
        WM_TIMER = 0x0113,
        WM_HSCROLL = 0x0114,
        WM_VSCROLL = 0x0115,
        WM_INITMENU = 0x0116,
        WM_INITMENUPOPUP = 0x0117,
        WM_MENUSELECT = 0x011F,
        WM_MENUCHAR = 0x0120,
        WM_ENTERIDLE = 0x0121,
        WM_MENURBUTTONUP = 0x0122,
        WM_MENUDRAG = 0x0123,
        WM_MENUGETOBJECT = 0x0124,
        WM_UNINITMENUPOPUP = 0x0125,
        WM_MENUCOMMAND = 0x0126,
        WM_CTLCOLORMSGBOX = 0x0132,
        WM_CTLCOLOREDIT = 0x0133,
        WM_CTLCOLORLISTBOX = 0x0134,
        WM_CTLCOLORBTN = 0x0135,
        WM_CTLCOLORDLG = 0x0136,
        WM_CTLCOLORSCROLLBAR = 0x0137,
        WM_CTLCOLORSTATIC = 0x0138,
        WM_MOUSEMOVE = 0x0200,
        WM_LBUTTONDOWN = 0x0201,
        WM_LBUTTONUP = 0x0202,
        WM_LBUTTONDBLCLK = 0x0203,
        WM_RBUTTONDOWN = 0x0204,
        WM_RBUTTONUP = 0x0205,
        WM_RBUTTONDBLCLK = 0x0206,
        WM_MBUTTONDOWN = 0x0207,
        WM_MBUTTONUP = 0x0208,
        WM_MBUTTONDBLCLK = 0x0209,
        WM_MOUSEWHEEL = 0x020A,
        WM_XBUTTONDOWN = 0x020B,
        WM_XBUTTONUP = 0x020C,
        WM_XBUTTONDBLCLK = 0x020D,
        WM_PARENTNOTIFY = 0x0210,
        WM_ENTERMENULOOP = 0x0211,
        WM_EXITMENULOOP = 0x0212,
        WM_NEXTMENU = 0x0213,
        WM_SIZING = 0x0214,
        WM_CAPTURECHANGED = 0x0215,
        WM_MOVING = 0x0216,
        WM_DEVICECHANGE = 0x0219,
        WM_MDICREATE = 0x0220,
        WM_MDIDESTROY = 0x0221,
        WM_MDIACTIVATE = 0x0222,
        WM_MDIRESTORE = 0x0223,
        WM_MDINEXT = 0x0224,
        WM_MDIMAXIMIZE = 0x0225,
        WM_MDITILE = 0x0226,
        WM_MDICASCADE = 0x0227,
        WM_MDIICONARRANGE = 0x0228,
        WM_MDIGETACTIVE = 0x0229,
        WM_MDISETMENU = 0x0230,
        WM_ENTERSIZEMOVE = 0x0231,
        WM_EXITSIZEMOVE = 0x0232,
        WM_DROPFILES = 0x0233,
        WM_MDIREFRESHMENU = 0x0234,
        WM_IME_SETCONTEXT = 0x0281,
        WM_IME_NOTIFY = 0x0282,
        WM_IME_CONTROL = 0x0283,
        WM_IME_COMPOSITIONFULL = 0x0284,
        WM_IME_SELECT = 0x0285,
        WM_IME_CHAR = 0x0286,
        WM_IME_REQUEST = 0x0288,
        WM_IME_KEYDOWN = 0x0290,
        WM_IME_KEYUP = 0x0291,
        WM_MOUSEHOVER = 0x02A1,
        WM_MOUSELEAVE = 0x02A3,
        WM_CUT = 0x0300,
        WM_COPY = 0x0301,
        WM_PASTE = 0x0302,
        WM_CLEAR = 0x0303,
        WM_UNDO = 0x0304,
        WM_RENDERFORMAT = 0x0305,
        WM_RENDERALLFORMATS = 0x0306,
        WM_DESTROYCLIPBOARD = 0x0307,
        WM_DRAWCLIPBOARD = 0x0308,
        WM_PAINTCLIPBOARD = 0x0309,
        WM_VSCROLLCLIPBOARD = 0x030A,
        WM_SIZECLIPBOARD = 0x030B,
        WM_ASKCBFORMATNAME = 0x030C,
        WM_CHANGECBCHAIN = 0x030D,
        WM_HSCROLLCLIPBOARD = 0x030E,
        WM_QUERYNEWPALETTE = 0x030F,
        WM_PALETTEISCHANGING = 0x0310,
        WM_PALETTECHANGED = 0x0311,
        WM_HOTKEY = 0x0312,
        WM_GETSYSMENU = 0x0313,

        WM_PRINT = 0x0317,
        WM_PRINTCLIENT = 0x0318,
        WM_APPCOMMAND = 0x0319,


        
        WM_THEME_CHANGED = 0x031A,
        WM_HANDHELDFIRST = 0x0358,
        WM_HANDHELDLAST = 0x035F,
        WM_AFXFIRST = 0x0360,
        WM_AFXLAST = 0x037F,
        WM_PENWINFIRST = 0x0380,
        WM_PENWINLAST = 0x038F,

        WM_APP = 0x8000,
        WM_USER = 0x0400,
        
        WM_REFLECT = WM_USER + 0x1c00,

        WM_GRAPH_EVENT = WM_APP + 1,	// message from filter graph

        SC_CLOSE = 0xF060,
 
    }

    [Flags]
    public enum SetWindowPosFlags
    {
        SWP_NONE = 0x0000,
        SWP_NOSIZE = 0x0001,
        SWP_NOMOVE = 0x0002,
        SWP_NOZORDER = 0x0004,
        SWP_NOREDRAW = 0x0008,
        SWP_NOACTIVATE = 0x0010,
        SWP_FRAMECHANGED = 0x0020,
        SWP_SHOWWINDOW = 0x0040,
        SWP_HIDEWINDOW = 0x0080,
        SWP_NOCOPYBITS = 0x0100,
        SWP_NOOWNERZORDER = 0x0200,
        SWP_NOSENDCHANGING = 0x0400,
        SWP_DRAWFRAME = 0x0020,
        SWP_NOREPOSITION = 0x0200,
        SWP_DEFERERASE = 0x2000,
        SWP_ASYNCWINDOWPOS = 0x4000
    }

    public enum ShowWindowStyles : short
    {
        SW_HIDE = 0,
        SW_SHOWNORMAL = 1,
        SW_NORMAL = 1,
        SW_SHOWMINIMIZED = 2,
        SW_SHOWMAXIMIZED = 3,
        SW_MAXIMIZE = 3,
        SW_SHOWNOACTIVATE = 4,
        SW_SHOW = 5,
        SW_MINIMIZE = 6,
        SW_SHOWMINNOACTIVE = 7,
        SW_SHOWNA = 8,
        SW_RESTORE = 9,
        SW_SHOWDEFAULT = 10,
        SW_FORCEMINIMIZE = 11,
        SW_MAX = 11
    }

    [Flags]
    public enum MFMENU : uint
    {
        MF_BYCOMMAND = 0,
        MF_BYPOSITION = 0x400,
        MF_CHECKED = 8,
        MF_DISABLED = 2,
        MF_ENABLED = 0,
        MF_GRAYED = 1,
        MF_HILITE = 0x80,
        MF_POPUP = 0x10,
        MF_SEPARATOR = 0x800,
        MF_STRING = 0,
        MF_UNCHECKED = 0
    }

    [Flags]
    public enum RedrawWindowFlags : uint
    {
        RDW_INVALIDATE          = 0x0001,
        RDW_INTERNALPAINT       = 0x0002,
        RDW_ERASE               = 0x0004,
        RDW_VALIDATE            = 0x0008,
        RDW_NOINTERNALPAINT     = 0x0010,
        RDW_NOERASE             = 0x0020,
        RDW_NOCHILDREN          = 0x0040,
        RDW_ALLCHILDREN         = 0x0080,
        RDW_UPDATENOW           = 0x0100,
        RDW_ERASENOW            = 0x0200,
        RDW_FRAME               = 0x0400,
        RDW_NOFRAME             = 0x0800,
    }

    public enum HeaderItemFlags
    {
        HDI_FORMAT = 0x0004,
        HDF_LEFT = 0x0000,
        HDF_STRING = 0x4000,
        HDF_SORTUP = 0x0400,
        HDF_SORTDOWN = 0x0200,
        LVM_FIRST = 0x1000,
        LVM_GETHEADER = (LVM_FIRST + 31),
        HDM_FIRST = 0x1200,
        HDM_GETITEM = HDM_FIRST + 11,
        HDM_SETITEM = HDM_FIRST + 12,

        HDM_LAYOUT = HDM_FIRST + 5,
    }

    // struct used to set node properties
    [StructLayout(LayoutKind.Sequential)]
    public struct TVITEM
    {
        public int mask;
        public IntPtr hItem;
        public int state;
        public int stateMask;
        [MarshalAs(UnmanagedType.LPTStr)]
        public String lpszText;
        public int cchTextMax;
        public int iImage;
        public int iSelectedImage;
        public int cChildren;
        public IntPtr lParam;
    }

    public enum TreeViewItemFlags
    {
        // constants used to hide a checkbox
        TVIF_STATE = 0x8,
        TVIS_STATEIMAGEMASK = 0xF000,
        TV_FIRST = 0x1100,
        TVM_SETITEM = TV_FIRST + 63,
    }

    public enum SendMessageTimeoutFlags
    {
        SMTO_NORMAL = 0x0000,
        SMTO_BLOCK = 0x0001,
        SMTO_ABORTIFHUNG = 0x0002,
        SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct COPYDATASTRUCT
    {
        public UIntPtr dwData;
        public uint cbData;
        public IntPtr lpData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HDLAYOUT
    {
        public IntPtr prc;   // RECT*
        public IntPtr pwpos; // WINDOWPOS*
    }

    /// <summary>
    /// Helper class that holds all the data types and unmanaged
    /// functions imported from User32.dll. Refer to 
    /// MSDN documentation for further information.
    /// </summary>
    public class User32
    {
        const string USER32 = "user32.dll";

        #region OS_Dependent




        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, ref RECT rect);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, StringBuilder lParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr Handle, Int32 msg, IntPtr wParam, ref HDITEM lParam);


        // Import the SendMessage function for use with COPYDATASTRUCT
        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hwnd, Int32 msg, Int32 hwndFrom, ref COPYDATASTRUCT cds);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern void GetWindowText(IntPtr h, StringBuilder s, int nMaxCount);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern void GetClassName(IntPtr h, StringBuilder s, int nMaxCount);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout(
            IntPtr windowHandle,
            int Msg,
            IntPtr wParam,
            ref COPYDATASTRUCT cds,
            SendMessageTimeoutFlags flags,
            int timeout,
            out IntPtr result);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout(
            IntPtr windowHandle,
            [MarshalAs(UnmanagedType.U4)]
                int Msg,
            IntPtr wParam,
            IntPtr lParam,
            SendMessageTimeoutFlags flags,
            int timeout,
            out IntPtr result);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(IntPtr hwnd, Int32 msg, Int32 hwndFrom, ref COPYDATASTRUCT cds);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(int hWnd, uint Msg, int wParam, int lParam);


        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern int DestroyWindow(IntPtr hWnd);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern int DestroyIcon(IntPtr hIcon);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern int GetDlgCtrlID(IntPtr hwndCtl);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public extern static System.IntPtr GetWindowDC(System.IntPtr hWnd);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public extern static System.IntPtr GetDCEx(System.IntPtr hWnd, IntPtr hRgn, uint flags);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public extern static bool GetClientRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public extern static bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        
        [DllImport(USER32, CharSet = CharSet.Auto)]
        public extern static System.IntPtr GetTopWindow(System.IntPtr hWnd);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public extern static System.IntPtr GetDesktopWindow();

        [DllImport(USER32, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowText(IntPtr hWnd, string lpString);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, SetWindowPosFlags flags);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool InsertMenu(IntPtr hmenu, uint position, MFMENU uflags, IntPtr uIDNewItemOrSubmenu, string text);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool InvalidateRect(IntPtr hWnd, int ignored, bool erase);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern int GetMenuItemCount(IntPtr hMenu);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool SetMenuItemBitmaps(IntPtr hMenu, uint uPosition, MFMENU uFlags,
            IntPtr hBitmapUnchecked, IntPtr hBitmapChecked);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool RedrawWindow(IntPtr hWnd, ref Rectangle lprcUpdate, IntPtr hrgnUpdate, uint flags);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowStyles nCmdShow);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool IsWindow(IntPtr hWnd);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool IsWindow(int hWnd);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref COMBOBOXINFO pcbi);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateWindowEx(
           uint dwExStyle,string lpClassName,string lpWindowName, uint dwStyle,int x,int y,        
           int nWidth,int nHeight,IntPtr hWndParent,IntPtr hMenu,IntPtr hInstance,IntPtr lpParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr GetActiveWindow();

        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern int EnumWindows(EnumWindowProc lpEnumFunc, IntPtr lParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool EnumChildWindows(IntPtr hWndParent, EnumWindowProc lpEnumFunc, IntPtr lParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        #endregion


        public static int LOWORD(long l)
        {
            return (short)(l & 0xFFFF);
        }

        public static int HIWORD(long l)
        {
            return (short)(l >> 0x10);
        }

        public static int GET_Y_LPARAM(IntPtr lParam)
        {
            return (short)HIWORD((long)lParam);
        }

        public static int GET_X_LPARAM(IntPtr lParam)
        {
            return (short)LOWORD((long)lParam);
        }

        public static int MakeLong(short lowWord, short hiWord)
        {
            return (int)(((ushort)lowWord) | (uint)(hiWord << 16));
        }

        public static int MakeLParam(int loWord, int hiWord)
        {
            int res = (int)((hiWord << 16) | (loWord & 0xffff));
            return res;
        }


 

    }
}


      

