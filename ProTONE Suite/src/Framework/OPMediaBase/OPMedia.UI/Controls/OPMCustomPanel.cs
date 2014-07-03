using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.UI.Themes;
using OPMedia.UI.Generic;
using System.Drawing.Drawing2D;

namespace OPMedia.UI.Controls
{
    public class OPMCustomPanel : OPMBaseControl
    {
        bool _hasBorder = true;
        public bool HasBorder
        {
            get { return _hasBorder; }
            set { _hasBorder = value; }
        }

        public int BorderWidth { get; set; }
        public bool Highlight { get; set; }

        public Color BaseColor { get; set; }

        public OPMCustomPanel()
            : base()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ThemeManager.PrepareGraphics(g);

            if (HasBorder)
            {
                Color cb =
                    Enabled ? ThemeManager.BorderColor : ThemeManager.GradientNormalColor2;

                if (Highlight)
                {
                    cb = ThemeManager.HighlightColor;
                }

                using (Brush b = new SolidBrush(this.BackColor))
                using (Pen p = new Pen(cb, BorderWidth))
                {
                    g.FillRectangle(b, ClientRectangle);
                    g.DrawRectangle(p, ClientRectangle);
                }
            }
        }
    }
}
