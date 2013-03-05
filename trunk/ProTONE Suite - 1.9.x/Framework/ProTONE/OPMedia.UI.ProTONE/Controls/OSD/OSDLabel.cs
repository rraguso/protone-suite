using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;


namespace OPMedia.UI.ProTONE.Controls.OSD
{
    public class OSDLabel : Label
    {
        public OSDLabel()
            : base()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
        }

        int BlurAmt = 4;
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.CompositingMode = CompositingMode.SourceOver;

            using (Brush b1 = new SolidBrush(ForeColor))
            {
                for (int x = 0; x <= BlurAmt; x++)
                {
                    for (int y = 0; y <= BlurAmt; y++)
                    {
                        g.DrawString(Text, Font, Brushes.Black, new Point(x, y));
                    }
                }

                g.DrawString(Text, Font, b1, new Point(BlurAmt / 2, BlurAmt / 2));
            }
        }
    }
}
