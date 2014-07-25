using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using System.Drawing.Drawing2D;
using OPMedia.UI.Generic;
using System.ComponentModel;

namespace OPMedia.UI.Controls
{
    public class OPMCheckBox : CheckBox
    {
        bool _isHovered = false;

        #region GUI Properties

        #region Font Size

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
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

        private Color GetForeColor()
        {
            if (_overrideForeColor != Color.Empty)
                return _overrideForeColor;

            return ThemeManager.ForeColor;
        }
        #endregion

        #endregion


        public OPMCheckBox()
            : base()
        {
            this.FlatStyle = FlatStyle.Flat;

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.DoubleBuffered = true;

            this.Paint += new PaintEventHandler(OPMCheckBox_Paint);
            this.MouseEnter += new EventHandler(OnMouseEnter);
            this.MouseLeave += new EventHandler(OnMouseLeave);

            this.FontSize = FontSizes.Normal;
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

        void OPMCheckBox_Paint(object sender, PaintEventArgs e)
        {
            ThemeManager.PrepareGraphics(e.Graphics);

            int pw = 1;
            Color c1 = Color.Empty, c2 = Color.Empty, cb = Color.Empty, cText = Color.Empty;

            c1 = Enabled ? ThemeManager.GradientNormalColor1 : ThemeManager.BackColor;
            cb = Enabled ? ThemeManager.BorderColor : ThemeManager.GradientNormalColor2;
            cText = Enabled ? ThemeManager.ForeColor : Color.FromKnownColor(KnownColor.ControlDark);

            if (Enabled && (_isHovered || Focused))
            {
                if (_isHovered && Focused)
                {
                    c1 = ThemeManager.GradientFocusHoverColor1;
                    cb = ThemeManager.FocusBorderColor;
                    //pw = 2;
                }
                else if (Focused)
                {
                    c1 = ThemeManager.GradientFocusColor1;
                    cb = ThemeManager.FocusBorderColor;
                    //pw = 2;
                }
                else
                {
                    c1 = ThemeManager.GradientHoverColor1;
                }
            }

            Rectangle rcFill = new Rectangle(-1, 0, Width + 1, Height);

            using (Brush b = new SolidBrush(ThemeManager.BackColor))
            {
                e.Graphics.FillRectangle(b, rcFill);
            }

            ButtonState bs = Checked ? ButtonState.Checked : ButtonState.Normal;
            bs |= ButtonState.Flat;

            // Get the size of the checkbox glyph (depending on OS settings this may vary)
            Size sz = CheckBoxRenderer.GetGlyphSize(e.Graphics, CheckBoxState.UncheckedNormal);
            sz = new System.Drawing.Size(sz.Width, sz.Height);

            Rectangle rcGlyph = new Rectangle(1, (Height - sz.Height) / 2,
                sz.Width - 2, sz.Height - 2);
            Rectangle rcCheck = new Rectangle(rcGlyph.Left + 2, rcGlyph.Top + 2,
                rcGlyph.Width - 4, rcGlyph.Width - 4);
            Rectangle rcText = new Rectangle(rcGlyph.Right + 2, 0, Width - rcGlyph.Width - 2,
                Height);

            int d = 2 * rcCheck.Width / 3;

            using (Brush b = new SolidBrush(c1))
            using (Pen p = new Pen(cb, pw))
            using (GraphicsPath path = ImageProcessing.GenerateRoundCornersBorder(rcGlyph, 
                ThemeManager.CornerSize > 0 ? 2 : 0))
            {
                e.Graphics.FillPath(b, path);
                e.Graphics.DrawPath(p, path);
            }

            using (Brush b = new SolidBrush(cText))
            using (Pen p = new Pen(b, 2))
            {
                switch (CheckState)
                {
                    case CheckState.Checked:
                        e.Graphics.DrawLine(p, rcCheck.Left, rcCheck.Top + d, rcCheck.Right - d, rcCheck.Bottom);
                        e.Graphics.DrawLine(p, rcCheck.Right - d, rcCheck.Bottom, rcCheck.Right, rcCheck.Top);
                        break;

                    case CheckState.Indeterminate:
                        e.Graphics.FillRectangle(b, rcCheck);
                        break;
                }
            }

            using (Brush b = new SolidBrush(cText))
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignments.FromContentAlignment(TextAlign).Alignment;
                sf.LineAlignment = StringAlignments.FromContentAlignment(TextAlign).LineAlignment;
                sf.Trimming = StringTrimming.EllipsisWord;
                //sf.FormatFlags = StringFormatFlags.NoWrap;
                sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

                e.Graphics.DrawString(this.Text, this.Font, b, rcText, sf);
            }
        }


    }
}
