using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics;

namespace OPMedia.UI.Generic
{
    [Flags]
    public enum CornersPosition
    {
        None = 0x00,
        LeftTop = 0x01,
        RightTop = 0x02,
        RightBottom = 0x04,
        LeftBottom = 0x08,
        All = 0x0F
    }

    public class ImageProcessing
    {
       

        public static void BrightnessFilter(ref Bitmap b, int nBrightness)
        {
            if (nBrightness < -255 || nBrightness > 255)
                return;

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            int nVal = 0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width * 3;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nVal = (int)(p[0] + nBrightness);

                        if (nVal < 0) nVal = 0;
                        if (nVal > 255) nVal = 255;

                        p[0] = (byte)nVal;

                        ++p;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);
        }

        public static void InversionFilter(ref Bitmap b)
        {
            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), 
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width * 3;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        p[0] = (byte)(255 - p[0]);
                        ++p;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);
        }

        public static void GrayscaleFilter(ref Bitmap b)
        {
            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;

                byte red, green, blue;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        blue = p[0];
                        green = p[1];
                        red = p[2];

                        p[0] = p[1] = p[2] = (byte)(.299 * red + .587 * green + .114 * blue);

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);
        }

        public static GraphicsPath GenerateCenteredArrow(Rectangle rcArrow)
        {
            GraphicsPath gp = new GraphicsPath();
            List<Point> pts = new List<Point>();

            pts.Add(new Point(rcArrow.Left + rcArrow.Width / 3 - 1, rcArrow.Top + rcArrow.Height / 3 + 1));
            pts.Add(new Point(rcArrow.Right - rcArrow.Width / 3 + 1, rcArrow.Top + rcArrow.Height / 3 + 1));
            pts.Add(new Point(rcArrow.Right - rcArrow.Width / 2, rcArrow.Bottom - rcArrow.Height / 3 - 1));

            gp.AddLine(pts[0], pts[1]);
            gp.AddLine(pts[1], pts[2]);
            gp.AddLine(pts[2], pts[0]);

            // This will automatically add the missing lines
            gp.CloseAllFigures();
            gp.Flatten();

            return gp;
        }



        public static GraphicsPath GenerateRoundCornersBorder(Rectangle rcSource, int cornerSize = 3, CornersPosition corners = CornersPosition.All)
        {
            GraphicsPath borderPath = new GraphicsPath();

            cornerSize = cornerSize & 0x0F;
            if (cornerSize > 0)
            {
                int c = 2 * cornerSize;
                int l = rcSource.Left;
                int t = rcSource.Top;
                int r = rcSource.Right;
                int b = rcSource.Bottom;

                // left, top corner
                if ((corners & CornersPosition.LeftTop) == CornersPosition.LeftTop)
                    borderPath.AddArc(l, t, c, c, 180, 90);
                else
                    borderPath.AddLine(l, t, l, t);

                // right, top corner
                if ((corners & CornersPosition.RightTop) == CornersPosition.RightTop) 
                    borderPath.AddArc(r - c, t, c, c, -90, 90);
                else
                    borderPath.AddLine(r, t, r, t);

                // right, bottom corner
                if ((corners & CornersPosition.RightBottom) == CornersPosition.RightBottom)
                    borderPath.AddArc(r - c, b - c, c, c, 0, 90);
                else
                    borderPath.AddLine(r, b, r, b);

                // left, bottom corner
                if ((corners & CornersPosition.LeftBottom) == CornersPosition.LeftBottom)
                    borderPath.AddArc(l, b - c, c, c, 90, 90);
                else
                    borderPath.AddLine(l, b, l, b);

                // This will automatically add the missing lines
                borderPath.CloseAllFigures();
                borderPath.Flatten();
            }
            else
            {
                borderPath.AddRectangle(rcSource);
            }

            return borderPath;
        }

        public static void AddGridToBitmap(Bitmap bmp, int hLineCount, int vLineCount, Color gridColor)
        {
            if (bmp != null)
            {
                const int MinGridResolution = 5;

                int sizeX = bmp.Width;
                int sizeY = bmp.Height;

                if (sizeX / vLineCount < MinGridResolution)
                {
                    vLineCount = sizeX / MinGridResolution;
                }
                if (sizeY / hLineCount < MinGridResolution)
                {
                    hLineCount = sizeY / MinGridResolution;
                }

                // VLines
                for (int i = 0; i < sizeX; i += (sizeX / vLineCount))
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        bmp.SetPixel(i, j, gridColor);
                    }
                }

                // HLines
                for (int j = 0; j < sizeY; j += (sizeY / hLineCount))
                {
                    for (int i = 0; i < sizeX; i++)
                    {
                        bmp.SetPixel(i, j, gridColor);
                    }
                }
            }
        }

        public static void ReplaceColor(Bitmap bmp, Color oldColor, Color newColor)
        {
            int sizeX = bmp.Width;
            int sizeY = bmp.Height;

            for (int i = 0; i < sizeX; i++)
            {
                //Debug.Write("[");

                for (int j = 0; j < sizeY; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    //Debug.Write(c.ToString() + ",");

                    if (c.ToArgb() == oldColor.ToArgb())
                    {
                        bmp.SetPixel(i, j, newColor);
                    }
                }

                //Debug.WriteLine("]");
            }
        }

        public static void DrawStringToBitmap(Bitmap bmp, int x, int y, Font fontText, Color clText, string text)
        {
            if (bmp != null)
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CompositingMode = CompositingMode.SourceCopy;

                    using (Brush b = new SolidBrush(clText))
                    {
                        g.DrawString(text, fontText, b, x, y);
                    }
                }
            }
        }
    }

}
