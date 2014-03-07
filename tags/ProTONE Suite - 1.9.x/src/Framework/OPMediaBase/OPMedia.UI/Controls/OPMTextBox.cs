using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using OPMedia.UI.Themes;
using System.Drawing.Drawing2D;
using OPMedia.UI.Generic;
using OPMedia.Core;
using OPMedia.UI.Controls;
using System.Diagnostics;
using OPMedia.Core.GlobalEvents;

namespace OPMedia.UI.Controls
{
    public class OPMTextBox : TextBox
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

            return ThemeManager.WndTextColor;
        }
        #endregion

        #endregion

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new BorderStyle BorderStyle
        { get { return base.BorderStyle; } }

        static Timer _tmrApplyColor = null;

        public bool IsHovered { get; private set; }

        public OPMTextBox()
            : base()
        {
            base.BorderStyle = BorderStyle.FixedSingle;
            //base.TextAlign = HorizontalAlignment.Left;
            //base.Multiline = true;

            if (_tmrApplyColor == null)
            {
                _tmrApplyColor = new Timer();
                _tmrApplyColor.Interval = 100;
                _tmrApplyColor.Tick += new EventHandler(_tmrApplyColor_Tick);
                _tmrApplyColor.Start();
            }

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.FontSize = FontSizes.Normal;

            this.HandleDestroyed += new EventHandler(OPMTextBox_HandleDestroyed);

            this.MouseEnter += new EventHandler(OnMouseEnter);
            this.MouseLeave += new EventHandler(OnMouseLeave);
            this.Enter += new EventHandler(OnEnter);
            this.Leave += new EventHandler(OnLeave);
        
            this.HandleCreated += new EventHandler(OPMTextBox_HandleCreated);
            this.EnabledChanged += new EventHandler(OPMTextBox_EnabledChanged);
        }

        void OPMTextBox_EnabledChanged(object sender, EventArgs e)
        {
            SetColors();
        }

        void OPMTextBox_HandleCreated(object sender, EventArgs e)
        {
            SetColors();
        }

        void OnLeave(object sender, EventArgs e)
        {
            //_isHovered = false;
            Invalidate(true);
        }
        void OnEnter(object sender, EventArgs e)
        {
            //_isHovered = false;
            Invalidate(true);
        }

        void OnMouseLeave(object sender, EventArgs e)
        {
            IsHovered = false;
            Invalidate(true);
        }

        void OnMouseEnter(object sender, EventArgs e)
        {
            IsHovered = Enabled;
            Invalidate(true);
        }

        void OPMTextBox_HandleDestroyed(object sender, EventArgs e)
        {
            _tmrApplyColor.Tick -= new EventHandler(_tmrApplyColor_Tick);
        }

        void _tmrApplyColor_Tick(object sender, EventArgs e)
        {
            SetColors();
        }

        Rectangle GetFormattingRectangle()
        {
            Rectangle rc = Rectangle.Empty;

            try
            {
                RECT erc = new RECT();
                User32.SendMessage(Handle, EM_GETRECT, 0, ref erc);
                rc = erc.ToRectangle();
            }
            catch { }
            
            return rc;
        }


        const int EM_GETRECT = 0x00B2;
        const int EM_SETRECT = 0x00B3;

        [EventSink(EventNames.ThemeUpdated)]
        public void SetColors()
        {
            base.BackColor =
                Enabled ? ThemeManager.WndValidColor : Color.FromKnownColor(KnownColor.ControlLight);
            base.ForeColor =
                Enabled ? GetForeColor() : Color.FromKnownColor(KnownColor.ControlDark);
        }
    }
}
