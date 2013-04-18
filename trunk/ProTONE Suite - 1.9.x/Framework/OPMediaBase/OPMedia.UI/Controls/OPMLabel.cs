using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using OPMedia.Core;
using OPMedia.UI.Themes;
using OPMedia.UI.Generic;

using System.ComponentModel;
using OPMedia.Core.GlobalEvents;

namespace OPMedia.UI.Controls
{
    [ToolboxBitmap(typeof(Label))]
    public class OPMLabel : Label
    {
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

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color BackColor { get { return base.BackColor; } }

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

        Color _overrideBackColor = Color.Empty;
        public Color OverrideBackColor
        {
            get { return _overrideBackColor; }
            set { _overrideBackColor = value; Invalidate(true); }
        }

        private Color GetBackColor()
        {
            if (_overrideBackColor != Color.Empty)
                return _overrideBackColor;

            return ThemeManager.BackColor;
        }
        #endregion

        #endregion

        public OPMLabel()
            : base()
        {
            base.FlatStyle = FlatStyle.Flat;
            base.TextAlign = ContentAlignment.MiddleLeft;

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            this.DoubleBuffered = true;

            this.FontSize = FontSizes.Normal;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            ThemeManager.PrepareGraphics(e.Graphics);

            Color c1 = GetBackColor();
            Color cText = Enabled ? GetForeColor() : Color.FromKnownColor(KnownColor.ControlDark);

            Rectangle rc = ClientRectangle;

            using (Brush b = new SolidBrush(c1))
            {
                e.Graphics.FillRectangle(b, rc);
            }

            if (Image != null)
            {
                Point p = new Point(2 + rc.Location.X, rc.Location.Y + (this.Height - Image.Height) / 2);
                e.Graphics.DrawImageUnscaled(Image, p);

                rc.Offset(Image.Width + 5, 0);
            }

            using (Brush b = new SolidBrush(cText))
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignments.FromContentAlignment(TextAlign).Alignment;
                sf.LineAlignment = StringAlignments.FromContentAlignment(TextAlign).LineAlignment;
                sf.Trimming = StringTrimming.EllipsisWord;
                //sf.FormatFlags = StringFormatFlags.NoClip;
                
                sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

                e.Graphics.DrawString(this.Text, this.Font, b, rc, sf);
            }
        }
    }

    public class OPMLinkLabel : LinkLabel
    {
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

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color BackColor { get { return base.BackColor; } }

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color LinkColor { get { return base.LinkColor; } }

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color DisabledLinkColor { get { return base.DisabledLinkColor; } }

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color ForeColor { get { return base.ForeColor; } }

        public OPMLinkLabel()
            : base()
        {
            OnThemeUpdated();

            EventDispatch.RegisterHandler(this);
            this.HandleDestroyed += new EventHandler(OPMLinkLabel_HandleDestroyed);
        }

        void OPMLinkLabel_HandleDestroyed(object sender, EventArgs e)
        {
            EventDispatch.UnregisterHandler(this);
        }

        [EventSink(EventNames.ThemeUpdated)]
        public void OnThemeUpdated()
        {
            base.BackColor = ThemeManager.BackColor;
            base.LinkColor = ThemeManager.LinkColor;
            base.ForeColor = ThemeManager.ForeColor;
            base.DisabledLinkColor = ThemeManager.ForeColor;
        }

    }

    public class OPMHeaderLabel : OPMLabel
    {
        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color OverrideForeColor { get { return base.OverrideForeColor; } }

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color OverrideBackColor { get { return base.OverrideBackColor; } }

        public OPMHeaderLabel()
            : base()
        {
            OnThemeUpdated();

             EventDispatch.RegisterHandler(this);
             this.HandleDestroyed += new EventHandler(OPMLinkLabel_HandleDestroyed);
        }

        void OPMLinkLabel_HandleDestroyed(object sender, EventArgs e)
        {
            EventDispatch.UnregisterHandler(this);
        }

        [EventSink(EventNames.ThemeUpdated)]
        public void OnThemeUpdated()
        {
            base.OverrideBackColor = ThemeManager.SelectedColor;
            base.OverrideForeColor = ThemeManager.ForeColor;
        }
    }
}
