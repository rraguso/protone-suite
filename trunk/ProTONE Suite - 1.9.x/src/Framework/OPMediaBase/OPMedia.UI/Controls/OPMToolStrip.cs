using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using OPMedia.UI.Themes;
using System.Drawing.Drawing2D;
using OPMedia.UI.Generic;
using OPMedia.Core;
using System.ComponentModel;
using System.Windows.Forms.Design;
using OPMedia.UI.Controls;
using OPMedia.UI.Properties;

namespace OPMedia.UI.Controls
{
    public class OPMToolStripSplitButton : ToolStripSplitButton
    {
        public OPMToolStripSplitButton()
            : base()
        {
        }


        public OPMToolStripSplitButton(string text)
            : base(text)
        {
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeManager.PrepareGraphics(e.Graphics);

            Color clText = Enabled ? ThemeManager.ForeColor : Color.FromKnownColor(KnownColor.ControlDark);

            Rectangle clientRectangle = new Rectangle(ContentRectangle.X - 2,
                ContentRectangle.Y - 2,
                ContentRectangle.Width + 4,
                ContentRectangle.Height + 4);

            using (SolidBrush b1 = new SolidBrush(ThemeManager.SelectedColor))
            {
                using (Brush b2 = new SolidBrush(ThemeManager.HighlightColor))
                using (Pen p2 = new Pen(ThemeManager.ForeColor))
                {
                    Rectangle rect = clientRectangle;

                    if (Enabled && (Selected || Pressed))
                    {
                        e.Graphics.FillRectangle(b1, rect);

                        rect.Width -= 1;
                        rect.Height -= 1;
                        e.Graphics.DrawRectangle(p2, rect);

                        if (DropDownItems != null && DropDownItems.Count >= 0)
                        {
                            Point pt1 = new Point(clientRectangle.Right - DropDownButtonWidth,
                                clientRectangle.Top);
                            Point pt2 = new Point(clientRectangle.Right - DropDownButtonWidth,
                                clientRectangle.Bottom);

                            e.Graphics.DrawLine(p2, pt1, pt2);
                        }
                    }

                    int xpos = this.Width / 2 - this.Owner.ImageScalingSize.Width / 2 - DropDownButtonWidth / 2;

                    if (Image != null)
                    {
                        Image img = this.Image;
                        if (!Enabled)
                        {
                            Bitmap bmp = new Bitmap(this.Image);
                            ImageProcessing.GrayscaleFilter(ref bmp);
                            bmp.MakeTransparent(Color.Black);
                            img = bmp;
                        }

                        if (string.IsNullOrEmpty(this.Text))
                        {
                            xpos += (this.Height - img.Height) / 2;
                        }

                        e.Graphics.DrawImage(ImageProvider.ScaleImage(img, Owner.ImageScalingSize, true),
                            new Point(xpos, 2));
                    }

                    StringFormat sf = new StringFormat();

                    rect = clientRectangle;
                    rect.Width -= DropDownButtonWidth;

                    switch (TextDirection)
                    {
                        case ToolStripTextDirection.Inherit:
                        case ToolStripTextDirection.Horizontal:
                            sf.LineAlignment = StringAlignment.Near;
                            sf.Alignment = StringAlignment.Center;
                            break;

                        default:
                            sf.FormatFlags |= StringFormatFlags.DirectionVertical | StringFormatFlags.DirectionRightToLeft;
                            sf.LineAlignment = StringAlignment.Center;
                            sf.Alignment = StringAlignment.Center;
                            break;

                    }

                    if (Image != null)
                    {
                        rect.Y += this.Owner.ImageScalingSize.Height;
                        rect.Height -= this.Owner.ImageScalingSize.Height;
                    }

                    using (Brush b = new SolidBrush(clText))
                    {
                        e.Graphics.DrawString(this.Text, this.Font, b, rect, sf);
                    }
                }
            }

            if (DropDownItems != null && DropDownItems.Count >= 0)
            {
                Rectangle rcArrow = new Rectangle(clientRectangle.Right - DropDownButtonWidth,
                    clientRectangle.Top + (clientRectangle.Height - 20) / 2,
                        DropDownButtonWidth, 15);

                using (GraphicsPath gp = ImageProcessing.GenerateCenteredArrow(rcArrow))
                using (Brush b = new SolidBrush(clText))
                using (Pen p = new Pen(b, 1))
                {
                    e.Graphics.FillPath(b, gp);
                    e.Graphics.DrawPath(p, gp);
                }
            }
        }
    }

    #region OPMToolStrip

    public class OPMToolStrip : ToolStrip
    {
        public new ToolStripRenderMode RenderMode { get { return base.RenderMode; } }
        public new ToolStripRenderer Renderer { get { return base.Renderer; } }

        public bool ShowBorder
        {
            get { return (Renderer as OPMToolStripRenderer).ShowBorder; }
            set { (Renderer as OPMToolStripRenderer).ShowBorder = value; }
        }

        public bool VerticalGradient
        {
            get { return (Renderer as OPMToolStripRenderer).VerticalGradient; }
            set { (Renderer as OPMToolStripRenderer).VerticalGradient = value; }
        }


        public OPMToolStrip()
            : base()
        {
            this.ForeColor = ThemeManager.ForeColor;
            this.BackColor = ThemeManager.BackColor;

            base.Renderer = new OPMToolStripRenderer();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            float angle = VerticalGradient ? 90f : 0f;

            using (LinearGradientBrush br = new LinearGradientBrush(ClientRectangle,
                ThemeManager.BackColor, ThemeManager.GradientRBColor, angle))
            {
                e.Graphics.FillRectangle(br, ClientRectangle);
            }
        }
    }

    #endregion

    #region Renderers

    public class OPMMenuStripRenderer : ToolStripRenderer
    {
        public bool ShowBorder { get; set; }
        public bool VerticalGradient { get; set; }

        public OPMMenuStripRenderer()
            : base()
        {
            this.ShowBorder = true;
            this.VerticalGradient = false;
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            ThemeManager.PrepareGraphics(e.Graphics);

            base.OnRenderToolStripBackground(e);

            Rectangle rc = new Rectangle(
                e.AffectedBounds.Left,
                e.AffectedBounds.Top,
                e.AffectedBounds.Width - 1,
                e.AffectedBounds.Height - 1);

            using (Pen p = new Pen(ThemeManager.SelectedColor, 1))
            {
                e.Graphics.DrawRectangle(p, rc);
            }

            if (e.ToolStrip != null)
            {
                using (Pen p = new Pen(e.ToolStrip.BackColor, 1))
                {
                    Point p1 = new Point(e.ConnectedArea.Left, rc.Top);
                    Point p2 = new Point(e.ConnectedArea.Right, rc.Top);

                    e.Graphics.DrawLine(p, p1, p2);
                }
            }
        }

        
    }


    public class OPMToolStripRenderer : ToolStripRenderer
    {
        public bool ShowBorder { get; set; }
        public bool VerticalGradient { get; set; }

        public OPMToolStripRenderer()
            : base()
        {
            this.ShowBorder = true;
            this.VerticalGradient = false;

        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (ShowBorder)
            {
                ThemeManager.PrepareGraphics(e.Graphics);

                using (Pen p = new Pen(ThemeManager.SelectedColor, 1))
                {
                    Point p1, p2 = Point.Empty;

                    if (VerticalGradient)
                    {
                        p1 = new Point(e.AffectedBounds.Left, e.AffectedBounds.Bottom - 1);
                        p2 = new Point(e.AffectedBounds.Right, e.AffectedBounds.Bottom - 1);
                    }
                    else
                    {
                        p1 = new Point(e.AffectedBounds.Right - 1, e.AffectedBounds.Top);
                        p2 = new Point(e.AffectedBounds.Right - 1, e.AffectedBounds.Bottom);
                    }

                    e.Graphics.DrawLine(p, p1, p2);
                }
            }
        }
    }

    #endregion


    #region OPMToolStripButton

    public class OPMToolStripButton : ToolStripButton
    {
        public OPMToolStripButton() : base()
        {
        }


        public OPMToolStripButton(string text)
            : base(text)
        {
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeManager.PrepareGraphics(e.Graphics);

            bool isHighlight = Enabled && (Selected || Checked);
            Color clText = Enabled ? ThemeManager.ForeColor : Color.FromKnownColor(KnownColor.ControlDark);

            Rectangle clientRectangle = new Rectangle(ContentRectangle.X - 2,
                ContentRectangle.Y - 2,
                ContentRectangle.Width + 4,
                ContentRectangle.Height + 4);

            using (SolidBrush b1 = new SolidBrush(ThemeManager.SelectedColor))
            {
                using (Brush b2 = new SolidBrush(ThemeManager.HighlightColor))
                using (Pen p2 = new Pen(ThemeManager.ForeColor))
                {
                    Rectangle rect = clientRectangle;

                    if (isHighlight)
                    {
                        if (Checked && !Selected)
                            e.Graphics.FillRectangle(b2, rect);
                        else
                            e.Graphics.FillRectangle(b1, rect);

                        rect.Width -= 1;
                        rect.Height -= 1;
                        e.Graphics.DrawRectangle(p2, rect);
                    }

                    int xpos = this.Width / 2 - this.Owner.ImageScalingSize.Width / 2;

                    if (Image != null)
                    {
                        Image img = this.Image;
                        if (!Enabled)
                        {
                            Bitmap bmp = new Bitmap(this.Image);
                            ImageProcessing.GrayscaleFilter(ref bmp);
                            bmp.MakeTransparent(Color.Black);
                            img = bmp;
                        }

                        int ypos = 2;

                        if (string.IsNullOrEmpty(this.Text))
                        {
                            ypos += (this.Height - img.Height) / 2;
                        }

                        e.Graphics.DrawImage(ImageProvider.ScaleImage(img, Owner.ImageScalingSize, true),
                            new Point(xpos, ypos));
                    }

                    StringFormat sf = new StringFormat();

                    rect = clientRectangle;

                    switch (TextDirection)
                    {
                        case ToolStripTextDirection.Inherit:
                        case ToolStripTextDirection.Horizontal:
                            sf.LineAlignment = StringAlignment.Near;
                            sf.Alignment = StringAlignment.Center;
                            break;

                        default:
                            sf.FormatFlags |= StringFormatFlags.DirectionVertical | StringFormatFlags.DirectionRightToLeft;
                            sf.LineAlignment = StringAlignment.Center;
                            sf.Alignment = StringAlignment.Center;
                            break;

                    }

                    if (Image != null)
                    {
                        rect.Y += this.Owner.ImageScalingSize.Height;
                        rect.Height -= this.Owner.ImageScalingSize.Height;
                    }

                    using (Brush b = new SolidBrush(clText))
                    {
                        e.Graphics.DrawString(this.Text, this.Font, b, rect, sf);
                    }
                }
            }
        }
    }

    #endregion

    #region OPMToolStripDropDownButton

    public class OPMToolStripDropDownButton : ToolStripDropDownButton
    {
        public Size ImageScalingSize { get; set; }

        public OPMToolStripDropDownButton()
            : base()
        {
            this.ImageScalingSize = new Size(16, 16);
        }


        public OPMToolStripDropDownButton(string text)
            : base(text)
        {
            this.ImageScalingSize = new Size(16, 16);
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeManager.PrepareGraphics(e.Graphics);

            Color clText = Enabled ? ThemeManager.ForeColor : Color.FromKnownColor(KnownColor.ControlDark);

            Rectangle clientRectangle = new Rectangle(ContentRectangle.X - 2,
                ContentRectangle.Y - 2,
                ContentRectangle.Width + 4,
                ContentRectangle.Height + 4);

            using (SolidBrush b1 = new SolidBrush(ThemeManager.SelectedColor))
            {
                using (Brush b2 = new SolidBrush(ThemeManager.HighlightColor))
                using (Pen p2 = new Pen(ThemeManager.ForeColor))
                {
                    Rectangle rect = clientRectangle;

                    if (Selected || Pressed)
                    {
                        e.Graphics.FillRectangle(b1, rect);

                        rect.Width -= 1;
                        rect.Height -= 1;
                        e.Graphics.DrawRectangle(p2, rect);
                    }

                    int xpos = this.Width / 2 - this.Owner.ImageScalingSize.Width / 2;

                    if (Image != null)
                    {
                        Image img = this.Image;
                        if (!Enabled)
                        {
                            Bitmap bmp = new Bitmap(this.Image);
                            ImageProcessing.GrayscaleFilter(ref bmp);
                            bmp.MakeTransparent(Color.Black);
                            img = bmp;
                        }

                        e.Graphics.DrawImage(ImageProvider.ScaleImage(img, Owner.ImageScalingSize, true),
                            new Point(xpos, 2));
                    }

                    StringFormat sf = new StringFormat();

                    rect = clientRectangle;

                    switch (TextDirection)
                    {
                        case ToolStripTextDirection.Inherit:
                        case ToolStripTextDirection.Horizontal:
                            sf.LineAlignment = StringAlignment.Near;
                            sf.Alignment = StringAlignment.Center;
                            break;

                        default:
                            sf.FormatFlags |= StringFormatFlags.DirectionVertical | StringFormatFlags.DirectionRightToLeft;
                            sf.LineAlignment = StringAlignment.Center;
                            sf.Alignment = StringAlignment.Center;
                            break;

                    }

                    if (Image != null)
                    {
                        rect.Y += this.Owner.ImageScalingSize.Height;
                        rect.Height -= this.Owner.ImageScalingSize.Height;
                    }

                    using (Brush b = new SolidBrush(clText))
                    {
                        e.Graphics.DrawString(this.Text, this.Font, b, rect, sf);
                    }
                }
            }

            Rectangle rcArrow = new Rectangle(clientRectangle.Right - 15, 
                clientRectangle.Top + (clientRectangle.Height - 25) / 2,
                    15, 15);

            using (GraphicsPath gp = ImageProcessing.GenerateCenteredArrow(rcArrow))
            using (Brush b = new SolidBrush(clText))
            using (Pen p = new Pen(b, 1))
            {
                e.Graphics.FillPath(b, gp);
                e.Graphics.DrawPath(p, gp);
            }
        }
    }

    #endregion

    #region StatusStripButton

    [DesignerCategory("code")]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip)]
    public class StatusStripButton : ToolStripControlHost
    {
        public new event EventHandler Click = null;

        public OPMButton Button
        {
            get
            {
                return this.Control as OPMButton;
            }
        }

        public StatusStripButton()
            : base(new OPMButton())
        {
            Button.Click += new EventHandler(Button_Click);
        }

        void Button_Click(object sender, EventArgs e)
        {
            if (Click != null)
            {
                Click(sender, e);
            }

        }
    }

    #endregion

    public class OPMToolStripSeparator : ToolStripSeparator
    {
    }

    #region OPMMenuStrip

    public class OPMMenuStrip : MenuStrip
    {
        public new ToolStripRenderMode RenderMode { get { return base.RenderMode; } }
        public new ToolStripRenderer Renderer { get { return base.Renderer; } }

        private bool ShowBorder
        {
            get { return (Renderer as OPMMenuStripRenderer).ShowBorder; }
            set { (Renderer as OPMMenuStripRenderer).ShowBorder = value; }
        }

        private bool VerticalGradient
        {
            get { return (Renderer as OPMMenuStripRenderer).VerticalGradient; }
            set { (Renderer as OPMMenuStripRenderer).VerticalGradient = value; }
        }

        public OPMMenuStrip()
            : base()
        {
            this.ForeColor = ThemeManager.ForeColor;
            this.BackColor = ThemeManager.BackColor;

            base.Renderer = new OPMMenuStripRenderer();
            
            this.VerticalGradient = true;
            this.ShowBorder = false;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            float angle = VerticalGradient ? 90f : 0f;

            using (LinearGradientBrush br = new LinearGradientBrush(ClientRectangle,
                ThemeManager.BackColor, ThemeManager.GradientLTColor, angle))
            {
                e.Graphics.FillRectangle(br, ClientRectangle);
            }
        }
    }

    #endregion

    #region OPMToolStripMenuItem

    public class OPMToolStripDropDownMenuItem : OPMToolStripMenuItem
    {
        private OPMToolStripDropDownButton Button { get; set; }
        public Size ImageScalingSize
        {
            get
            {
                return Button.ImageScalingSize;
            }
        }

        public OPMToolStripDropDownMenuItem(OPMToolStripDropDownButton button)
            : base()
        {
        }
    }

    public class OPMToolStripMenuItem : ToolStripMenuItem
    {
        public OPMToolStripMenuItem()
            : base()
        {
        }


        public OPMToolStripMenuItem(string text)
            : base(text)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            bool header = (Parent is OPMMenuStrip);
            bool highlight = (Selected || Checked || Pressed);
            
            Color clText = Color.Black;
            Color clBack = header ? Color.FromKnownColor(KnownColor.MenuBar) : ThemeManager.BackColor;

            if (Enabled)
            {
                if (header)
                {
                    if (SuiteConfiguration.SkinType == ThemeEnum.Black)
                    {
                        clText = highlight ? ThemeManager.SelectedColor : ThemeManager.ForeColor;
                    }
                    else
                    {
                        clText = ThemeManager.ForeColor;
                    }
                }
                else
                {
                    if (SuiteConfiguration.SkinType == ThemeEnum.Black)
                    {
                        clText = highlight ? ThemeManager.ForeColor : ThemeManager.SelectedColor;
                    }
                    else
                    {
                        clText = ThemeManager.ForeColor;
                    }
                }
            }
            else
            {
                clText = Color.FromKnownColor(KnownColor.ControlDark);
            }

            ThemeManager.PrepareGraphics(e.Graphics);


            Rectangle clientRectangle = Rectangle.Empty;

            if (header)
            {
                clientRectangle = new Rectangle(ContentRectangle.X + 2, ContentRectangle.Y - 1,
                    ContentRectangle.Width - 5, ContentRectangle.Height + 2);
            }
            else
            {
                clientRectangle = new Rectangle(ContentRectangle.X, ContentRectangle.Y - 1, 
                    ContentRectangle.Width, ContentRectangle.Height + 2);
            }

            using (SolidBrush b1 = new SolidBrush(clBack))
            {
                using (SolidBrush b2 = new SolidBrush(ThemeManager.CheckedMenuColor))
                {
                    Rectangle rect = clientRectangle;

                    if (Enabled && highlight)
                    {
                        if (Enabled)
                        {
                            if (Checked && !Selected)
                                e.Graphics.FillRectangle(b2, rect);
                            else
                                e.Graphics.FillRectangle(b1, rect);
                        }

                        if (!header)
                        {
                            rect.Height -= 1;
                        }

                        using (Pen p = new Pen(ThemeManager.SelectedColor, 1))
                        {
                            e.Graphics.DrawRectangle(p, rect);
                        }

                        if (Pressed)
                        {
                            using (Pen p = new Pen(ThemeManager.BackColor, 1))
                            {
                                Point p1 = new Point(rect.Left, rect.Bottom + 1);
                                Point p2 = new Point(rect.Right, rect.Bottom + 1);
                                e.Graphics.DrawLine(p, p1, p2);
                            }
                        }
                    }

                    StringAlignment hAlign = header ? StringAlignment.Center : StringAlignment.Near;

                    if (Image != null)
                    {
                        Point ptOffset = header ? new Point(1, 4) : new Point(4, 4);

                        int w = 0;

                        if (this is OPMToolStripDropDownMenuItem)
                        {
                            e.Graphics.DrawImage(Image, new Rectangle(ptOffset, Image.Size));
                            w = Image.Width;
                        }
                        else
                        {
                            Image img = ImageProvider.ScaleImage(Image, Owner.ImageScalingSize, false);
                            e.Graphics.DrawImage(img, new Rectangle(ptOffset, Owner.ImageScalingSize));
                            w = img.Width;
                        }

                        if (header)
                        {
                            rect.X += ptOffset.X + w;
                            rect.Width -= ptOffset.X + w;
                        }

                        hAlign = StringAlignment.Near;
                    }

                    if (DropDownItems != null && DropDownItems.Count > 0 && !header)
                    {
                        Image unscaled = Resources.menuChildren;
                        e.Graphics.DrawImage(ImageProvider.ScaleImage(unscaled, unscaled.Size, true),
                            new Point(rect.Width - 9, 8));
                    }

                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.FormatFlags = StringFormatFlags.NoWrap;
                    sf.Alignment = hAlign;
                    sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

                    if (!header)
                    {
                        rect.X += 25;
                        rect.Width -= 30;
                    }

                    using (Brush b = new SolidBrush(clText))
                    {
                        e.Graphics.DrawString(Text, this.Font, b, rect, sf);

                        if (!string.IsNullOrEmpty(ShortcutKeyDisplayString))
                        {
                            sf = new StringFormat();
                            sf.FormatFlags = StringFormatFlags.NoWrap;
                            sf.LineAlignment = StringAlignment.Center;
                            sf.Alignment = StringAlignment.Far;
                            sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

                            e.Graphics.DrawString(ShortcutKeyDisplayString, this.Font, b, rect, sf);
                        }
                    }
                }
            }

        }
    }

    #endregion
}

