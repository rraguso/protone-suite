#region Copyright � 2008 OPMedia Research
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	ExtractIcons.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using OPMedia.Core;
using System.IO;
using System.Runtime.InteropServices;
using System.Resources;
using OPMedia.Core.Properties;
using System.Reflection;
#endregion


namespace OPMedia.Core
{
    public enum Shell32Icon
    {
        BlankFile =      0,
        GenericFile =    1,
        GenericFolder =  4,
        
        DriveRemovable = 7,
        DriveFixed =     8,
        DriveNetwork =   9,
        DriveNoRoot =    10,
        DriveCdrom =     11,
        DriveRamdisk =   12,
        
        Internet =       13,
        DesktopFolder =  34,
        DriveUnknown =   53,

        GenericFileSystem = 84,

        DvdDisk = 113,
        CompactDisk = 188,
        
        AutomaticProcess = 165,
    }

    public enum User32Icon
    {
        Application = 0,
        Warning = 1,
        Question = 2,
        Error = 3,
        Information = 4,
        Program = 5,
    }

    public static class ImageProvider
    {
        public static Image GenericFileIcon = GetShell32Icon(Shell32Icon.GenericFile, false);
        static Dictionary<string, Image> fileTypeIcons = new Dictionary<string, Image>();

        public static readonly Image ApplicationIconLarge = null;
        public static readonly Image ApplicationIcon = null;

        static ImageProvider()
        {
            Icon icon = GetAppIcon(true);
            if (icon != null)
                ApplicationIconLarge = icon.ToBitmap();

            icon = GetAppIcon();
            if (icon != null)
                ApplicationIcon = icon.ToBitmap();
        }

        
        public static string ImageToString(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                byte[] array = ms.ToArray();
                return Convert.ToBase64String(array);
            }
        }

        public static Image StringToImage(string imageString)
        {
            if (!string.IsNullOrEmpty(imageString))
            {
                byte[] array = Convert.FromBase64String(imageString);
                return Image.FromStream(new MemoryStream(array));
            }

            return null;
        }

        public static Icon GetAppIcon(bool largeIcon = false)
        {
            //if (ApplicationInfo.IsPlayer)
            //{
            //    return ResizeIcon(Resources.player, largeIcon);
            //}
            //else if (ApplicationInfo.IsMediaLibrary)
            //{
            //    return ResizeIcon(Resources.catalog, largeIcon);
            //}
            //else if (ApplicationInfo.IsRCCManager)
            //{
            //    return ResizeIcon(Resources.ir_remote, largeIcon);
            //}

            try
            {
                return _GetIcon(Assembly.GetEntryAssembly().Location, largeIcon);
            }
            catch { }

            return null;
        }
        
        public static Image GetIconOfFileType(string ext)
        {
            Image retVal = GenericFileIcon;
            if (fileTypeIcons.ContainsKey(ext))
            {
                retVal = fileTypeIcons[ext];
            }
            else
            {
                try
                {
                    string tempFile = Path.ChangeExtension(Path.GetTempFileName(), ext.Trim(".".ToCharArray()));
                    File.Create(tempFile).Close();

                    Image icon = GetIcon(tempFile, false);
                    if (icon != null)
                    {
                        fileTypeIcons.Add(ext, icon);
                        retVal = icon;
                    }

                    File.Delete(tempFile);
                }
                catch
                {
                }
            }

            return retVal;
        }

        public static Image GetIcon(string strPath, bool largeIcon = false)
        {
            Icon icon = _GetIcon(strPath, largeIcon);
            if (icon != null)
            {
                Image retVal = icon.ToBitmap();
                if (retVal == null)
                {
                    return GetShell32Icon(Shell32Icon.GenericFile, largeIcon);
                }
                else
                {
                    return retVal.Resize(largeIcon);
                }
            }

            return null;
        }

        private static Icon _GetIcon(string strPath, bool largeIcon = false)
        {
            SHFILEINFO info = new SHFILEINFO();
            int cbFileInfo = Marshal.SizeOf(info);
            
            Shell32.SHGetFileInfo(strPath, 256, ref info, (uint)cbFileInfo, (uint)SHGetFileInfoConstants.SHGFI_SYSICONINDEX);

            Icon retVal = null;

            try
            {
                IntPtr hIL = IntPtr.Zero;
                int iImageList = largeIcon ? 0x2 /*SHIL_EXTRALARGE*/ : 0x1 /*SHIL_SMALL*/;
                Guid riid = Shell32.IID_IImageList;

                if (Shell32.SHGetImageList(iImageList, ref riid, ref hIL) == WinError.S_OK && hIL != IntPtr.Zero)
                {
                    IntPtr hIcon = ComCtl32.ImageList_GetIcon(hIL, info.iIcon, 0);
                    if (hIcon != IntPtr.Zero)
                    {
                        retVal = Icon.FromHandle(hIcon).Clone() as Icon;
                        User32.DestroyIcon(hIcon);
                    }
                }
            }
            catch
            {
            }

            return retVal;
        }

        public static Image GetDesktopIcon(bool largeIcon)
        {
            return GetShell32Icon(Shell32Icon.DesktopFolder, largeIcon);
        }

        public static Image GetShell32Icon(Shell32Icon type, bool largeIcon)
        {
            switch (type)
            {
                case Shell32Icon.DvdDisk:
                    return Resources.DVD;

                case Shell32Icon.CompactDisk:
                    return Resources.CDA;

                case Shell32Icon.Internet:
                    return Resources.Internet;

                default:
                    break;

            }


            // Use icons provided by Shell32.dll itself
            return GetIcon(Environment.SystemDirectory + PathUtils.DirectorySeparator + "shell32.dll",
                (int)type, largeIcon);
        }

        public static Image GetUser32Icon(User32Icon type, bool largeIcon)
        {
            // Use icons provided by User32.dll itself
            return GetIcon(Environment.SystemDirectory + PathUtils.DirectorySeparator + "user32.dll",
                (int)type, largeIcon);
        }

        public static Icon ToIcon(this Bitmap bmp, uint argbTRansparentColor = 0xFFFF00FF)
        {
            try
            {
                bmp.MakeTransparent(Color.FromArgb((int)argbTRansparentColor));
                return Icon.FromHandle(bmp.GetHicon());
            }
            catch
            {
            }

            return GetAppIcon();
        }

        public static Image Resize(this Image img, bool largeIcon)
        {
            Size iconSize = largeIcon ? new Size(32, 32) : new Size(16, 16);
            return ScaleImage(img, iconSize, true);
        }

        public static Image ScaleImage(Image img, Size newScale, bool forced = false)
        {
            if (img != null)
            {
                if (img.Size.Height > newScale.Height || forced)
                {
                    Bitmap bmp = new Bitmap(img, newScale);
                    bmp.MakeTransparent(Color.Magenta);
                    return bmp;
                }
            }

            return img;
        }
        
        public static Icon ResizeIcon(Icon src, bool largeIcon)
        {
            if (src != null)
            {
                Size iconSize = largeIcon ? new Size(32, 32) : new Size(16, 16);

                if (src.Size.Width != iconSize.Width || src.Size.Height != iconSize.Height)
                    return new Icon(src, iconSize);

                return src;
            }

            return null;
        }
        
        public static Image GetIcon(string file, int iconIndex, bool largeIcon)
        {
            IntPtr[] handlesIconLarge = new IntPtr[1] { IntPtr.Zero };
            IntPtr[] handlesIconSmall = new IntPtr[1] { IntPtr.Zero };

            try
            {
                uint i = Shell32.ExtractIconEx(file, iconIndex, handlesIconLarge, handlesIconSmall, 1);
                if (i > 0)
                {
                    if (largeIcon && handlesIconLarge[0] != IntPtr.Zero)
                        return (Icon.FromHandle(handlesIconLarge[0]).Clone() as Icon).ToBitmap();
                    else if (handlesIconSmall[0] != IntPtr.Zero)
                        return (Icon.FromHandle(handlesIconSmall[0]).Clone() as Icon).ToBitmap();
                }
            }
            catch { }
            finally
            {
                // RELEASE RESOURCES
                if (handlesIconLarge[0] != IntPtr.Zero)
                    User32.DestroyIcon(handlesIconLarge[0]);

                if (handlesIconSmall[0] != IntPtr.Zero)
                    User32.DestroyIcon(handlesIconSmall[0]);
            }

            return null;
        }
    }
}
