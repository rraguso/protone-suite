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
       

        public static Bitmap Brightness(Image b, float brightness)
        {
            Bitmap bDest = new Bitmap(b.Width, b.Height, b.PixelFormat);

            float adjustedBrightness = brightness - 1.0f;

            // Create the ImageAttributes object and apply the ColorMatrix
            ImageAttributes attributes = new System.Drawing.Imaging.ImageAttributes();
            ColorMatrix brightnessMatrix = new ColorMatrix(new float[][]{
                new float[] {1, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 0, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {brightness, brightness, brightness, 0, 1}
            });
            attributes.SetColorMatrix(brightnessMatrix);

            // Use a new Graphics object from the new image.
            using (Graphics g = Graphics.FromImage(bDest))
            {
                // Draw the original image using the ImageAttributes created above.
                g.DrawImage(b,
                            new Rectangle(0, 0, b.Width, b.Height),
                            0, 0, b.Width, b.Height,
                            GraphicsUnit.Pixel,
                            attributes);
            }

            return bDest;
        }

        public static Bitmap ColorShift(Image b, Color cs)
        {
            Bitmap bDest = new Bitmap(b.Width, b.Height, b.PixelFormat);

            // Create the ImageAttributes object and apply the ColorMatrix
            ImageAttributes attributes = new System.Drawing.Imaging.ImageAttributes();
            ColorMatrix shiftMatrix = new ColorMatrix(new float[][]{
                new float[] {1, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {cs.R/255f, cs.G/255f, cs.B/255f, 0, 1}
            });
            attributes.SetColorMatrix(shiftMatrix);

            // Use a new Graphics object from the new image.
            using (Graphics g = Graphics.FromImage(bDest))
            {
                // Draw the original image using the ImageAttributes created above.
                g.DrawImage(b,
                            new Rectangle(0, 0, b.Width, b.Height),
                            0, 0, b.Width, b.Height,
                            GraphicsUnit.Pixel,
                            attributes);
            }

            return bDest;
        }

        public static Bitmap Inversion(Image b)
        {
            Bitmap bDest = new Bitmap(b.Width, b.Height, b.PixelFormat);

            // Create the ImageAttributes object and apply the ColorMatrix
            ImageAttributes attributes = new System.Drawing.Imaging.ImageAttributes();
            ColorMatrix inversionMatrix = new ColorMatrix(new float[][]{
                new float[] {-1, 0, 0, 0, 0},
                new float[] {0, -1, 0, 0, 0},
                new float[] {0, 0, -1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {.99f, .99f, .99f, 0, 1}
            });
            attributes.SetColorMatrix(inversionMatrix);

            // Use a new Graphics object from the new image.
            using (Graphics g = Graphics.FromImage(bDest))
            {
                // Draw the original image using the ImageAttributes created above.
                g.DrawImage(b,
                            new Rectangle(0, 0, b.Width, b.Height),
                            0, 0, b.Width, b.Height,
                            GraphicsUnit.Pixel,
                            attributes);
            }

            return bDest;
        }

        public static Bitmap Grayscale(Image b, float brightnessAdjust = 1)
        {
            Bitmap bDest = new Bitmap(b.Width, b.Height, b.PixelFormat);

            // Create the ImageAttributes object and apply the ColorMatrix
            ImageAttributes attributes = new System.Drawing.Imaging.ImageAttributes();
            ColorMatrix grayscaleMatrix = new ColorMatrix(new float[][]{
                new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                new float[] {0.587f, 0.587f, 0.587f, 0, 0},
                new float[] {0.114f, 0.114f, 0.114f, 0, 0},
                new float[] {     0,      0,      0, 1, 0},
                new float[] {     0,      0,      0, 0, 1}
            });
            attributes.SetColorMatrix(grayscaleMatrix);

            // Use a new Graphics object from the new image.
            using (Graphics g = Graphics.FromImage(bDest))
            {
                // Draw the original image using the ImageAttributes created above.
                g.DrawImage(b,
                            new Rectangle(0, 0, b.Width, b.Height),
                            0, 0, b.Width, b.Height,
                            GraphicsUnit.Pixel,
                            attributes);
            }

            if (brightnessAdjust != 1.0f)
                return Brightness(bDest, brightnessAdjust);

            return bDest;
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
                for (int j = 0; j < sizeY; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    if (c.ToArgb() == oldColor.ToArgb())
                    {
                        bmp.SetPixel(i, j, newColor);
                    }
                }
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
