using System.Windows.Forms;
using System.Drawing;
using System;
using System.Drawing.Drawing2D;
using OPMedia.UI.Themes;
using System.ComponentModel;
using OPMedia.Core.TranslationSupport;
using System.Drawing.Text;
using OPMedia.UI.Generic;

namespace OPMedia.UI.Controls
{
    public class OPMTabControl : TabControl
    {
        public new ImageList ImageList { get; set;}

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Font Font { get { return base.Font; } }

        [DefaultValue(TextImageRelation.ImageBeforeText)]
        public TextImageRelation TextImageRelation { get; set; }

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Point Padding
        {
            get { return base.Padding; }
        }

        private Timer _tmr = null;

        public OPMTabControl()
            : base()
        {
            base.ImageList = new ImageList();

            this.ImageList = new ImageList();
            this.ImageList.ColorDepth = ColorDepth.Depth32Bit;
            this.ImageList.ImageSize = new Size(16, 16);
            this.ImageList.TransparentColor = Color.Magenta;

            this.TextImageRelation = TextImageRelation.ImageBeforeText;

            this.SizeMode = TabSizeMode.Normal;

            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            base.Font = ThemeManager.VeryLargeFont;
            base.FontHeight = ThemeManager.VeryLargeFont.Height;

            base.Padding = new Point(1, 1);

            this.SelectedIndexChanged += new EventHandler(OPMTabControl_SelectedIndexChanged);

            _tmr = new Timer();
            _tmr.Interval = 500;
            _tmr.Tick += new EventHandler(_tmr_Tick);
            _tmr.Start();
        }

        void _tmr_Tick(object sender, EventArgs e)
        {
            try
            {
                _tmr.Stop();

                for (int i = 0; i < base.TabPages.Count; i++)
                {
                    TabPage tp = TabPages[i];

                    Padding p = new Padding(5, 10, 5, 5);
                    if (tp.Padding != p)
                    {
                        tp.Padding = p;
                    }
                    if (tp.BackColor != ThemeManager.BackColor)
                    {
                        tp.BackColor = ThemeManager.BackColor;
                    }
                }
            }
            finally
            {
                _tmr.Start();
            }
        }
        
        void OPMTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Invalidate(true);
        }        

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.CompositingMode = CompositingMode.SourceOver;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Rectangle rcx = new Rectangle(
                ClientRectangle.Left,
                ClientRectangle.Top + ItemSize.Height + 2,
                ClientRectangle.Width - 2, 
                ClientRectangle.Height - ItemSize.Height - 4);

            using (Pen p = new Pen(ThemeManager.BorderColor))
            using (GraphicsPath path = ImageProcessing.GenerateRoundCornersBorder(rcx, ThemeManager.CornerSize))
            {
                //e.Graphics.DrawRectangle(p, rcx);
                e.Graphics.DrawPath(p, path);
            }

            //for (int i = 0; i < base.TabPages.Count; i++)
            //{
            //    PaintTabPageHeader(i, e.Graphics);
            //}
        }

        private void PaintTabPageHeader(int i, Graphics graphics)
        {
            int pw = 1;
            Color c1 = Color.Empty, c2 = Color.Empty, cb = Color.Empty, cText = Color.Empty;

            c1 = Enabled ? ThemeManager.GradientNormalColor1 : ThemeManager.BackColor;
            c2 = Enabled ? ThemeManager.GradientNormalColor2 : ThemeManager.BackColor;
            cb = Enabled ? ThemeManager.BorderColor : ThemeManager.GradientNormalColor2;
            cText = Enabled ? ThemeManager.ForeColor : Color.FromKnownColor(KnownColor.ControlDark);

            TabPage tp = TabPages[i];

            Rectangle rcDraw = base.GetTabRect(i);

            bool selected = (SelectedTab == tp);
            bool isLast = (TabPages.Count - 1 <= i);
            bool isPrev = (SelectedIndex == (i + 1));
            
            Rectangle rcx = new Rectangle(
                rcDraw.Left - 2, 
                rcDraw.Top,
                rcDraw.Width, 
                rcDraw.Height);
            Rectangle rcx2 = new Rectangle(
                rcDraw.Left - 1,
                rcDraw.Top + 1,
                rcDraw.Width - 2,
                rcDraw.Height);

            using (Brush b = new LinearGradientBrush(rcx, c1, c2, 90))
            using (Pen p = new Pen(cb))
            using (GraphicsPath path = ImageProcessing.GenerateRoundCornersBorder(rcx, ThemeManager.CornerSize))
            {
                //graphics.FillRectangle(b, rcx);
                //graphics.DrawRectangle(p, rcx);
                graphics.FillPath(b, path);
                graphics.DrawPath(p, path);
            }

            if (selected)
            {
                using (Brush b = new SolidBrush(ThemeManager.BackColor))
                {
                    rcx2.Width += 1;
                    graphics.FillRectangle(b, rcx2);
                }
            }
            else if (!isLast && !isPrev)
            {
                Point p1 = new Point(rcDraw.Right - 2, rcDraw.Top + 2);
                Point p2 = new Point(rcDraw.Right - 2, rcDraw.Bottom - 2);
                Point p3 = new Point(rcDraw.Right - 2, rcDraw.Top + 2);
                Point p4 = new Point(rcDraw.Right - 2, rcDraw.Bottom - 2);
                
                using (Pen pen1 = new Pen(cText))
                using (Pen pen2 = new Pen(cb))
                {
                    graphics.DrawLine(pen1, p1, p2);
                    graphics.DrawLine(pen2, p3, p4);
                }
            }

            #region Draw image

            int textOffset = 4;
            Image img = GetTabPageImage(tp);

            if (img != null)
            {
                int size = Math.Min(rcDraw.Height - 4, img.Height);
                textOffset += size;
                Rectangle rcImage = Rectangle.Empty;

                int diff = 0;
                switch (this.TextImageRelation)
                {
                    case TextImageRelation.ImageBeforeText:
                        diff = (rcDraw.Height - size) / 2;
                        rcImage = new Rectangle(rcDraw.Left, rcDraw.Top + diff, size, size);
                        break;

                    case TextImageRelation.ImageAboveText:
                        diff = (rcDraw.Width - size) / 2;
                        rcImage = new Rectangle(rcDraw.Left + diff, rcDraw.Top + 4, size, size);
                        break;
                }

                graphics.DrawImage(img, rcImage);
            }
            #endregion

            #region Draw text
            Rectangle rcText = Rectangle.Empty;
                
            switch (this.TextImageRelation)
            {
                case TextImageRelation.ImageBeforeText:
                    rcText = new Rectangle(rcDraw.Left + textOffset, rcDraw.Top, rcDraw.Width - textOffset, rcDraw.Height);
                    break;

                case TextImageRelation.ImageAboveText:
                    rcText = new Rectangle(rcDraw.Left, rcDraw.Top + textOffset, rcDraw.Width, rcDraw.Height - textOffset);
                    break;
            }

            StringFormat fmt = new StringFormat();
            fmt.Trimming = StringTrimming.EllipsisCharacter;
            fmt.FormatFlags = StringFormatFlags.NoWrap;

            switch (this.TextImageRelation)
            {
                case TextImageRelation.ImageBeforeText:
                    fmt.Alignment = StringAlignment.Near;
                    fmt.LineAlignment = StringAlignment.Center;
                    break;

                case TextImageRelation.ImageAboveText:
                    fmt.Alignment = StringAlignment.Center;
                    fmt.LineAlignment = StringAlignment.Center;
                    break;
            }

            using (Brush tb = new SolidBrush(cText))
            {
                if (selected)
                {
                    graphics.DrawString(tp.Text, ThemeManager.NormalBoldFont, tb, rcText, fmt);
                }
                else
                {
                    graphics.DrawString(tp.Text, ThemeManager.NormalFont, tb, rcText, fmt);
                }
            }

            #endregion
        }

        private Image GetTabPageImage(TabPage tp)
        {
            Image img = null;

            //if (tp is OPMTabPage)
            //{
            //    img = (tp as OPMTabPage).Image;
            //}

            if (img == null && ImageList != null && ImageList.Images.Count > 0)
            {
                if (tp.ImageIndex < ImageList.Images.Count)
                {
                    img = ImageList.Images[tp.ImageIndex];
                }

                if (img == null && ImageList.Images.ContainsKey(tp.ImageKey))
                {
                    img = ImageList.Images[tp.ImageKey];
                }
            }

            return img;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            pevent.Graphics.CompositingMode = CompositingMode.SourceOver;
            pevent.Graphics.CompositingQuality = CompositingQuality.GammaCorrected;
            pevent.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rc = new Rectangle(-1, -1, Width + 2, Height + 2);

            using (Brush b = new SolidBrush(ThemeManager.BackColor))
            {
                pevent.Graphics.FillRectangle(b, rc);
            }
        }
    }

    public class OPMTabPage : TabPage
    {
        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Font Font { get { return base.Font; } }

        public Control Control
        {
            get
            {
                if (Controls.Count > 0)
                {
                    return Controls[0];
                }

                return null;
            }
        }

        public OPMTabPage()
            : base()
        {
            base.Font = ThemeManager.VeryLargeFont;
        }

        public OPMTabPage(string title = "", Control control = null)
        {
            this.Text = title;
            base.Font = ThemeManager.VeryLargeFont;

            if (control != null)
            {
                this.Controls.Add(control);
            }

        }
    }
}

