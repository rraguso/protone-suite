using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using OPMedia.UI.Themes;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using OPMedia.UI.Generic;

namespace OPMedia.UI.Controls
{
    public class OPMTextBox : OPMBaseControl
    {
        bool _isHovered = false;
        bool _hasInput = false;
        protected TextBox txtField;

        #region GUI Properties


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

        #region TextBoxBase-like properties

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue("")]
        public new string Text
        {
            get { return txtField.Text; }
            set { txtField.Text = value; }
        }

        public CharacterCasing CharacterCasing
        {
            get { return txtField.CharacterCasing; }
            set { txtField.CharacterCasing = value; }
        }

        public int MaxLength
        {
            get { return txtField.MaxLength; }
            set { txtField.MaxLength = value; }
        }

        public bool ShortcutsEnabled
        {
            get { return txtField.ShortcutsEnabled; }
            set { txtField.ShortcutsEnabled = value; }
        }

        public char PasswordChar
        {
            get { return txtField.PasswordChar; }
            set { txtField.PasswordChar = value; }
        }

        public new Color BackColor
        {
            get { return txtField.BackColor; }
            set { txtField.BackColor = value; }
        }

        public bool UseSystemPasswordChar
        {
            get { return txtField.UseSystemPasswordChar; }
            set { txtField.UseSystemPasswordChar = value; }
        }

        public ScrollBars ScrollBars
        {
            get { return txtField.ScrollBars; }
            set { txtField.ScrollBars = value; }
        }

        public bool WordWrap
        {
            get { return txtField.WordWrap; }
            set { txtField.WordWrap = value; }
        }

        public bool Multiline
        {
            get { return txtField.Multiline; }
            set 
            { 
                txtField.Multiline = value;
                this.MaximumSize = value ? new Size(0, 0) : new Size(2000, 20);
                this.MinimumSize = value ? new Size(0, 0) : new Size(20, 20);
            }
        }

        public bool ReadOnly
        {
            get { return txtField.ReadOnly; }
            set { txtField.ReadOnly = value; }
        }

        public HorizontalAlignment TextAlign
        {
            get { return txtField.TextAlign; }
            set { txtField.TextAlign = value; }
        }

        #endregion

        public new void Focus()
        {
            base.Select();
            txtField.Select();
            txtField.Focus();
        }

        public void SelectAll()
        {
            txtField.SelectAll();
        }

        public OPMTextBox()
            : base()
        {


            InitializeComponent();
            OnThemeUpdatedInternal();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            txtField.MouseEnter += new EventHandler(OnMouseEnter);
            txtField.MouseLeave += new EventHandler(OnMouseLeave);

            txtField.Enter += new EventHandler(txtField_Enter);
            txtField.Leave += new EventHandler(txtField_Leave);
            txtField.TextChanged += new EventHandler(txtField_TextChanged);

            txtField.KeyDown += new KeyEventHandler(txtField_KeyDown);
        }

        void txtField_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        void txtField_TextChanged(object sender, EventArgs e)
        {
            base.OnTextChanged(e);
        }

        void txtField_Leave(object sender, EventArgs e)
        {
            _hasInput = false;
            Invalidate(true);
        }

        void txtField_Enter(object sender, EventArgs e)
        {
            _hasInput = true;
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

        protected override void OnThemeUpdatedInternal()
        {
            txtField.BackColor = ThemeManager.WndValidColor;
            txtField.ForeColor = GetForeColor();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Color cWnd = Color.Empty, cb = Color.Empty;

            cWnd = Enabled ? ThemeManager.WndValidColor : ThemeManager.BackColor;
            cb = Enabled ? ThemeManager.BorderColor : ThemeManager.GradientNormalColor2;
            int pw = 1;

            if (Enabled && (_isHovered || _hasInput))
            {
                cb = ThemeManager.FocusBorderColor;
                pw = 2;
            }

            ThemeManager.PrepareGraphics(e.Graphics);

            Rectangle rcPath = new Rectangle(1, 1, Width - 2, Height - 2);

            using (Brush b1 = new SolidBrush(ThemeManager.BackColor))
            using (Brush b2 = new SolidBrush(cWnd))
            using (Pen p = new Pen(cb, pw))
            using (GraphicsPath path = ImageProcessing.GenerateRoundCornersBorder(rcPath, ThemeManager.CornerSize)) 
            {
                e.Graphics.FillRectangle(b1, ClientRectangle);
                e.Graphics.FillPath(b2, path);
                e.Graphics.DrawPath(p, path);
            }
        }

        private void InitializeComponent()
        {
            this.txtField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtField
            // 
            this.txtField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtField.Location = new System.Drawing.Point(3, 3);
            this.txtField.Margin = new System.Windows.Forms.Padding(0);
            this.txtField.Name = "txtField";
            this.txtField.Size = new System.Drawing.Size(50, 15);
            this.txtField.TabIndex = 1;
            // 
            // OPMTextBox
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.txtField);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(2000, 20);
            this.MinimumSize = new System.Drawing.Size(20, 20);
            this.Name = "OPMTextBox";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(56, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
