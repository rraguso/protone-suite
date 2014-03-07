﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using OPMedia.UI.Generic;
using System.Drawing;
using OPMedia.UI.Themes;
using OPMedia.Core;
using System.Drawing.Text;
using OPMedia.Core.GlobalEvents;
using System.ComponentModel;

namespace OPMedia.UI.Controls
{
    [ToolboxBitmap(typeof(Button))]
    public class OPMButton : Button
    {
        bool _isKeyDown = false;
        bool _isMouseDown = false;
        bool _isHovered = false;

        #region GUI Properties

        #region Font Size

        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Font Font { get { return base.Font; } }

        FontSizes _fontSizes = FontSizes.Normal;
        [DefaultValue(FontSizes.Normal)]
        public FontSizes FontSize
        {
            get { return _fontSizes; }
            set
            {
                ThemeManager.SetFont(this, value);
                _fontSizes = value;

                Invalidate(true);
            }
        }
        #endregion

        #region Override settings

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color ForeColor { get { return base.ForeColor; } }

        Color _overrideForeColor = Color.Empty;
        public Color OverrideForeColor
        {
            get { return _overrideForeColor; }
            set { _overrideForeColor = value; Invalidate(true); }
        }

        Color _overrideBackColor = Color.Empty;
        public Color OverrideBackColor
        {
            get { return _overrideBackColor; }
            set { _overrideBackColor = value; Invalidate(true); }
        }

        private Color GetForeColor()
        {
            if (_overrideForeColor != Color.Empty)
                return _overrideForeColor;

            return ThemeManager.ForeColor;
        }

        #endregion

        #endregion


        public OPMButton()
            : base()
        {
            this.FlatStyle = FlatStyle.Flat;

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.DoubleBuffered = true;

            this.MouseEnter += new EventHandler(OnMouseEnter);
            this.MouseLeave += new EventHandler(OnMouseLeave);
            this.MouseDown += new MouseEventHandler(OnMouseDown);
            this.MouseUp += new MouseEventHandler(OnMouseUp);
            this.KeyDown += new KeyEventHandler(OnKeyDown);
            this.KeyUp += new KeyEventHandler(OnKeyUp);

            this.FontSize = FontSizes.Normal;
        }

        void OnKeyUp(object sender, KeyEventArgs e)
        {
            _isKeyDown = false;
            Invalidate(true);
        }

        void OnKeyDown(object sender, KeyEventArgs e)
        {
            _isKeyDown  = false;
            if (Enabled && e.Modifiers == Keys.None)
            {
                switch(e.KeyData)
                {
                    case Keys.Space:
                    case Keys.Enter:
                        _isKeyDown = true;
                        break;

                    default:
                        _isKeyDown = false;
                        break;
                }
            }

            Invalidate(true);
        }

        void OnMouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
            Invalidate(true);
        }

        void OnMouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown = Enabled;
            Invalidate(true);
        }

        void OnMouseLeave(object sender, EventArgs e)
        {
            _isHovered = false;
            Invalidate(true);
        }

        void OnMouseEnter(object sender, EventArgs e)
        {
            _isHovered = Enabled;
            Invalidate(true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeManager.PrepareGraphics(e.Graphics);
            base.OnPaint(e);

            Color c1 = Enabled ? ThemeManager.GradientLTColor : Color.FromKnownColor(KnownColor.ControlLight);
            Color c2 = Enabled ? ThemeManager.GradientRBColor : Color.FromKnownColor(KnownColor.ControlLight);
            Color cb = Enabled ? ThemeManager.BorderColor : Color.FromKnownColor(KnownColor.ControlDark);
            Color cText = Enabled ? GetForeColor() : Color.FromKnownColor(KnownColor.ControlDark);

            int bw = 1;

            if (_overrideBackColor != Color.Empty)
            {
                c1 = c2 = _overrideBackColor;
            }

            if (_isHovered)
            {
                c2 = ThemeManager.WndValidColor;
            }

            if (Enabled && (_isHovered || Focused))
            {
                bw = 2;

                if (Focused)
                {
                    cb = ThemeManager.HighlightColor;
                }
                else
                {
                    cb = ThemeManager.BorderColor;
                }
            }

            Rectangle rcb = ClientRectangle;
            rcb.Inflate(1, 1);

            using (Brush b = new SolidBrush(ThemeManager.BackColor))
            using (Pen p = new Pen(b, 4))
            {
                e.Graphics.FillRectangle(b, rcb);
            }

            Rectangle rc = ClientRectangle;
            
            if (_isMouseDown || _isKeyDown)
            {
                rc = new Rectangle(1, 1, Width, Height);
            }

            using (GraphicsPath gp = ImageProcessing.GenerateRoundCornersBorder(rc, 4))
            using (LinearGradientBrush b = new LinearGradientBrush(rc, c1, c2, 90f))
            using (Pen p = new Pen(cb, bw))
            {
                e.Graphics.FillPath(b, gp);
                e.Graphics.DrawPath(p, gp);
            }

            if (this.Image != null)
            {
                Rectangle rcImage = new Rectangle(
                    (rc.Size.Width - Image.Size.Width) / 2,
                    (rc.Size.Height - Image.Size.Height) / 2,
                    rc.Size.Width, rc.Size.Height);

                int l = Math.Max(2, rcImage.Left);
                int t = Math.Max(2, rcImage.Top);
                rcImage.Location = new Point(l, t);

                int w = Math.Min(Image.Width, rcImage.Size.Width);
                int h = Math.Min(Image.Height, rcImage.Size.Height);
                rcImage.Size = new System.Drawing.Size(w, h);

                e.Graphics.DrawImage(Image, rcImage);
            }
            else
            {
                using (Brush b = new SolidBrush(cText))
                {
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignments.FromContentAlignment(TextAlign).Alignment;
                    sf.LineAlignment = StringAlignments.FromContentAlignment(TextAlign).LineAlignment;
                    sf.Trimming = StringTrimming.EllipsisWord;
                    //sf.FormatFlags = StringFormatFlags.NoWrap;

                    sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

                    e.Graphics.DrawString(this.Text, this.Font, b, rc, sf);
                }
            }
            
        }
    }
}
