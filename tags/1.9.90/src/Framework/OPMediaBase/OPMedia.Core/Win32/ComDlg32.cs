using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OPMedia.Core.Win32
{
    public delegate uint OFNHookProcOldStyle(IntPtr hdlg, uint uiMsg, int wParam, int lParam); 

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class OpenFileName
    {
        public int lStructSize;
        public IntPtr hwndOwner;
        public IntPtr hInstance;
        public string lpstrFilter;
        public IntPtr lpstrCustomFilter;
        public int nMaxCustFilter;
        public int nFilterIndex;

        [MarshalAs(UnmanagedType.LPTStr, SizeConst=0x2000)]
        public string lpstrFile;
        
        public int nMaxFile;
        public IntPtr lpstrFileTitle;
        public int nMaxFileTitle;
        public string lpstrInitialDir;
        public string lpstrTitle;
        public int Flags;
        public short nFileOffset;
        public short nFileExtension;
        public string lpstrDefExt;
        public IntPtr lCustData;
        public OFNHookProcOldStyle lpfnHook;
        public string lpTemplateName;
        public IntPtr pvReserved;
        public int dwReserved;
        public int FlagsEx; 
    }

    public enum CommonDialogFlags : int
    {
        OFN_READONLY = 0x00000001,
        OFN_OVERWRITEPROMPT = 0x00000002,
        OFN_HIDEREADONLY = 0x00000004,
        OFN_NOCHANGEDIR = 0x00000008,
        OFN_SHOWHELP = 0x00000010,
        OFN_ENABLEHOOK = 0x00000020,
        OFN_ENABLETEMPLATE = 0x00000040,
        OFN_ENABLETEMPLATEHANDLE = 0x00000080,
        OFN_NOVALIDATE = 0x00000100,
        OFN_ALLOWMULTISELECT = 0x00000200,
        OFN_EXTENSIONDIFFERENT = 0x00000400,
        OFN_PATHMUSTEXIST = 0x00000800,
        OFN_FILEMUSTEXIST = 0x00001000,
        OFN_CREATEPROMPT = 0x00002000,
        OFN_SHAREAWARE = 0x00004000,
        OFN_NOREADONLYRETURN = 0x00008000,
        OFN_NOTESTFILECREATE = 0x00010000,
        OFN_NONETWORKBUTTON = 0x00020000,
        OFN_NOLONGNAMES = 0x00040000,
        
        OFN_EXPLORER = 0x00080000, // new look commdlg,
        OFN_NODEREFERENCELINKS = 0x00100000,
        OFN_LONGNAMES = 0x00200000, // force long names for 3.x modules,
        OFN_ENABLEINCLUDENOTIFY = 0x00400000, // send include message to
        
        OFN_ENABLESIZING = 0x00800000,
        OFN_DONTADDTORECENT = 0x02000000,
        OFN_FORCESHOWHIDDEN = 0x10000000, // Show All files including
        
        
        OFN_EX_NOPLACESBAR = 0x00000001, 
    }

    public class ComDlg32
    {
        const string COMDLG32 = "comdlg32.dll";

        [DllImport(COMDLG32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool GetOpenFileName([In, Out] OpenFileName ofn);

        [DllImport(COMDLG32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool GetSaveFileName([In, Out] OpenFileName ofn);
    }
}
