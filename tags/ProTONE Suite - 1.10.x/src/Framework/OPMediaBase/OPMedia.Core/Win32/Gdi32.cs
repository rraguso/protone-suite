using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Reflection;

namespace OPMedia.Core
{
    /// <summary>
    /// Enumeration for the raster operations used in BitBlt.
    /// In C++ these are actually #define. But to use these
    /// constants with C#, a new enumeration type is defined.
    /// </summary>
    public enum TernaryRasterOperations
    {
        SRCCOPY = 0x00CC0020, /* dest = source                   */
        SRCPAINT = 0x00EE0086, /* dest = source OR dest           */
        SRCAND = 0x008800C6, /* dest = source AND dest          */
        SRCINVERT = 0x00660046, /* dest = source XOR dest          */
        SRCERASE = 0x00440328, /* dest = source AND (NOT dest )   */
        NOTSRCCOPY = 0x00330008, /* dest = (NOT source)             */
        NOTSRCERASE = 0x001100A6, /* dest = (NOT src) AND (NOT dest) */
        MERGECOPY = 0x00C000CA, /* dest = (source AND pattern)     */
        MERGEPAINT = 0x00BB0226, /* dest = (NOT source) OR dest     */
        PATCOPY = 0x00F00021, /* dest = pattern                  */
        PATPAINT = 0x00FB0A09, /* dest = DPSnoo                   */
        PATINVERT = 0x005A0049, /* dest = pattern XOR dest         */
        DSTINVERT = 0x00550009, /* dest = (NOT dest)               */
        BLACKNESS = 0x00000042, /* dest = BLACK                    */
        WHITENESS = 0x00FF0062, /* dest = WHITE                    */
    };

    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
    public class LOGFONT 
    {
        public int lfHeight;
        public int lfWidth;
        public int lfEscapement;
        public int lfOrientation;
        public int lfWeight;
        public byte lfItalic;
        public byte lfUnderline;
        public byte lfStrikeOut;
        public byte lfCharSet;
        public byte lfOutPrecision;
        public byte lfClipPrecision;
        public byte lfQuality;
        public byte lfPitchAndFamily;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szFaceName;
    };
    
    public class Gdi32
    {
        const string GDI32 = "gdi32.dll";

#if HAVE_MONO

        public static IntPtr CreateSolidBrush(int crColor)
        {
            return IntPtr.Zero;
        }

        public static uint SetTextColor(IntPtr hdc, int crColor)
        {
            return uint.MinValue;
        }

        public static uint SetBkColor(IntPtr hdc, int crColor)
        {
            return uint.MinValue;
        }

#else

        [DllImport(GDI32, ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateSolidBrush(int crColor);

        [DllImport(GDI32, ExactSpelling = true, SetLastError = true)]
        public static extern uint SetTextColor(IntPtr hdc, int crColor);

        [DllImport(GDI32, ExactSpelling = true, SetLastError = true)]
        public static extern uint SetBkColor(IntPtr hdc, int crColor);

#endif

    }
}
