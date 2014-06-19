using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using OPMedia.UI.Themes;
using OPMedia.Core;
using System.Diagnostics;
using System.Runtime.InteropServices;
using OPMedia.UI.Properties;

using OPMedia.UI.Generic;
using OPMedia.UI.Controls;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.Logging;
using System.Threading;
using OPMedia.Core.GlobalEvents;

namespace OPMedia.UI.Themes
{
    [Flags]
    public enum FormButtons
    {
        None = 0x00,

        Minimize = 0x01,
        Maximize = 0x02,
        Close = 0x04,

        All = 0x07
    }

    public enum ButtonIcons
    {
        Minimize = 0,
        MinimizeHovered,
        Maximize,
        MaximizeHovered,
        Restore,
        RestoreHovered,
        Close,
        CloseHovered,
    }

    public partial class ThemeFormBase : Form
    {
        public const int DefaultCornerSize = 6;
        public const int DefaultTitleBarHeight = 21;
        public const int IconOffset = 4;
        public const int IconSize = 16;

        const int HTLEFT           = 10;
        const int HTRIGHT          = 11;
        const int HTTOP            = 12;
        const int HTTOPLEFT        = 13;
        const int HTTOPRIGHT       = 14;
        const int HTBOTTOM         = 15;
        const int HTBOTTOMLEFT     = 16;
        const int HTBOTTOMRIGHT = 17;
        private ResizeMargin _rmTop;
        private ResizeMargin _rmBottom;
        private ResizeMargin _rmLeft;
        private ResizeMargin _rmRight;
        private ResizeMargin _rmLT;
        private ResizeMargin _rmRT;
        private ResizeMargin _rmLB;
        private ResizeMargin _rmRB;

        string _text = "ABCDE";
        public new string Text
        { 
            get { return _text; } 
            set 
            { 
                _text = value;

                try
                {
                    User32.SetWindowText(Handle, _text);
                }
                catch { }

                ApplyWindowParams();
            } 
        }

        [ReadOnly(true)]
        [Browsable(false)]
        public new AutoScaleMode AutoScaleMode
        { get { return base.AutoScaleMode; } }

        [ReadOnly(true)]
        [Browsable(false)]
        public new SizeF AutoScaleDimensions
        { get { return base.AutoScaleDimensions; } }

        [ReadOnly(true)]
        [Browsable(false)]
        public new SizeF AutoScaleFactor
        { get { return base.AutoScaleFactor; } }
        

        bool _controlBox = true;
        public new bool ControlBox
        { get { return _controlBox; } set { _controlBox = value; } }
                    
        [ReadOnly(true)]
        [Browsable(false)]
        public new FormBorderStyle FormBorderStyle
        { get { return base.FormBorderStyle; } }

        [DefaultValue(DefaultCornerSize)]
        public int CornerSize { get; set; }

        [DefaultValue(FormButtons.All)]
        public FormButtons FormButtons { get; set; }

        private bool _allowResize = true;
        [DefaultValue(true)]
        public bool AllowResize 
        { 
            get { return _allowResize; }
            set
            {
                _allowResize = value;
                foreach (Control ctl in Controls)
                {
                    if (ctl is ResizeMargin)
                    {
                        ctl.Visible = value;
                    }
                }
            }
        }

        private bool _isToolWindow = false;
        [DefaultValue(false)]
        public bool IsToolWindow
        {
            get { return _isToolWindow; }
            set
            {
                _isToolWindow = value;

                FormButtons = FormButtons.Close;
                _titleBarFont = (_isToolWindow) ? ThemeManager.LargeFont : ThemeManager.LargeFont;
            }
        }

        bool _titleBarVisible = true;
        [Browsable(true)]
        public bool TitleBarVisible 
        {
            get { return _titleBarVisible; }
            set { _titleBarVisible = value; ApplyWindowParams(); Invalidate(true); }
        }

        protected Region ContentRegion { get; set; }

        protected override CreateParams CreateParams
        {
            get
            {
                int CS_DROPSHADOW = 0x00020000;

                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                //cp.ExStyle |= 0x02000000;

                return cp;
            }
        }

        GraphicsPath _borderPath = null;

        Rectangle _rcTitleBar = Rectangle.Empty;

        Rectangle _rcIcon = Rectangle.Empty;
        Rectangle _rcTitle = Rectangle.Empty;
        Rectangle _rcClose = Rectangle.Empty;
        Rectangle _rcMaximize = Rectangle.Empty;
        Rectangle _rcMinimize = Rectangle.Empty;

        Font _titleBarFont = ThemeManager.LargeFont;

        ImageList _btnImgList = null;

        int _iconLeft = 0;
        int _titleLeft = 0;
        int _btnCloseLeft = 0;
        int _btnMinimizeLeft = 0;
        int _btnMaximizeLeft = 0;
        int _titleWidth = 0;
        protected ContentPanel pnlContent;

        FormButtons _hoveredButtons = FormButtons.None;

        private bool _isActive =false;
        public bool IsActive 
        { 
            get
            {
                return _isActive;
            }

            private set
            {
                _isActive = value;
                ApplyDrawingValues();
                Invalidate();
            }
        }
        
        public ThemeFormBase()
        {
            //Initialize the main thread
            if (!DesignMode)
            {
                MainThread.Initialize(this);
            }

            base.AutoScaleDimensions = new SizeF(1, 1);
            base.AutoScaleMode = AutoScaleMode.None;
            base.FormBorderStyle = FormBorderStyle.None;

            InitializeComponent();

            _ttm = new OPMToolTipManager(this);

            this.CornerSize = DefaultCornerSize;
            this.FormButtons = FormButtons.All;
            this.AllowResize = true;

            this.Text = string.Empty;
            this.ControlBox = false;

            this.StartPosition = FormStartPosition.CenterParent;

            foreach(Control ctl in this.Controls)
            {
                if (ctl is ResizeMargin)
                {
                    ctl.BringToFront();
                    ctl.BackColor = Color.Transparent;
                }
            }

            _rmBottom.Tag = HTBOTTOM;
            _rmLB.Tag = HTBOTTOMLEFT;
            _rmLeft.Tag = HTLEFT;
            _rmLT.Tag = HTTOPLEFT;
            _rmRB.Tag = HTBOTTOMRIGHT;
            _rmRight.Tag = HTRIGHT;
            _rmRT.Tag = HTTOPRIGHT;
            _rmTop.Tag = HTTOP;


            this.BackColor = ThemeManager.BackColor;

            this.Load += new EventHandler(ThemeForm_Load);
            this.Resize += new EventHandler(ThemeForm_Resize);

            this.MouseDown += new MouseEventHandler(OnMouseDown);
            this.MouseUp += new MouseEventHandler(OnMouseUp);
            this.MouseMove += new MouseEventHandler(OnMouseMove);
            this.MouseDoubleClick += new MouseEventHandler(ThemeForm_MouseDoubleClick);
            this.MouseHover += new EventHandler(OnMouseHover);
            

            this.Activated += new EventHandler(ThemeFormBase_Activated);
            this.Deactivate += new EventHandler(ThemeFormBase_Deactivate);

            _btnImgList = new ImageList();
            _btnImgList.ImageSize = new Size(IconSize, IconSize);
            _btnImgList.ColorDepth = ColorDepth.Depth24Bit;

            Bitmap bmp = Resources.MinimizeButton.ToBitmap(); bmp.MakeTransparent(Color.Magenta);
            _btnImgList.Images.Add(bmp);
            _btnImgList.Images.Add(bmp);
            bmp = Resources.MaximizeButton.ToBitmap(); bmp.MakeTransparent(Color.Magenta);
            _btnImgList.Images.Add(bmp);
            _btnImgList.Images.Add(bmp);
            bmp = Resources.RestoreButton.ToBitmap(); bmp.MakeTransparent(Color.Magenta);
            _btnImgList.Images.Add(bmp);
            _btnImgList.Images.Add(bmp);
            bmp = Resources.CloseButton.ToBitmap(); bmp.MakeTransparent(Color.Magenta);
            _btnImgList.Images.Add(bmp);
            _btnImgList.Images.Add(bmp);

            this.HandleCreated += new EventHandler(ThemeFormBase_HandleCreated);
            this.HandleDestroyed += new EventHandler(ThemeFormBase_HandleDestroyed);
            this.FormClosing += new FormClosingEventHandler(ThemeFormBase_FormClosing);
            this.FormClosed += new FormClosedEventHandler(ThemeFormBase_FormClosed);
        }

        void ThemeFormBase_HandleCreated(object sender, EventArgs e)
        {
            ThemeManager.SetDoubleBuffer(this);
        }

        void ThemeFormBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        void ThemeFormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        void ThemeFormBase_HandleDestroyed(object sender, EventArgs e)
        {
            
        }

        void ThemeFormBase_Leave(object sender, EventArgs e)
        {
            IsActive = false;
            Logger.LogHeavyTrace("{0} - Leave", Name);
            Logger.LogHeavyTrace("{0} - IsActive: {1}", Name, IsActive);
        }

        void ThemeFormBase_Enter(object sender, EventArgs e)
        {
            IsActive = true;
            Logger.LogHeavyTrace("{0} - Enter", Name);
            Logger.LogHeavyTrace("{0} - IsActive: {1}", Name, IsActive);
        }

        void ThemeFormBase_Deactivate(object sender, EventArgs e)
        {
            IsActive = false;
            Logger.LogHeavyTrace("{0} - Deactivate", Name);
            Logger.LogHeavyTrace("{0} - IsActive: {1}", Name, IsActive);
        }

        void ThemeFormBase_Activated(object sender, EventArgs e)
        {
            IsActive = true;
            Logger.LogHeavyTrace("{0} - Activated", Name);
            Logger.LogHeavyTrace("{0} - IsActive: {1}", Name, IsActive);
        }

        protected virtual void OnThemeUpdatedInternal()
        {
        }

        [EventSink(EventNames.ThemeUpdated)]
        public void OnThemeUpdated()
        {
            base.BackColor = ThemeManager.BackColor;
            ApplyDrawingValues();
            Invalidate(true);

            OnThemeUpdatedInternal();
        }

        #region InitializeComponent
        private void InitializeComponent()
        {
            this.pnlContent = new OPMedia.UI.Themes.ContentPanel();
            this._rmTop = new OPMedia.UI.Themes.ResizeMargin();
            this._rmLT = new OPMedia.UI.Themes.ResizeMargin();
            this._rmRT = new OPMedia.UI.Themes.ResizeMargin();
            this._rmRB = new OPMedia.UI.Themes.ResizeMargin();
            this._rmLeft = new OPMedia.UI.Themes.ResizeMargin();
            this._rmLB = new OPMedia.UI.Themes.ResizeMargin();
            this._rmBottom = new OPMedia.UI.Themes.ResizeMargin();
            this._rmRight = new OPMedia.UI.Themes.ResizeMargin();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.TabIndex = 8;
            // 
            // _rmTop
            // 
            this._rmTop.BackColor = System.Drawing.Color.Blue;
            this._rmTop.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this._rmTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._rmTop.Location = new System.Drawing.Point(0, 0);
            this._rmTop.Margin = new System.Windows.Forms.Padding(0);
            this._rmTop.Name = "_rmTop";
            this._rmTop.Size = new System.Drawing.Size(423, 5);
            this._rmTop.TabIndex = 0;
            this._rmTop.TabStop = false;
            this._rmTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._rmTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnResizeMouseMove);
            this._rmTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // _rmLT
            // 
            this._rmLT.BackColor = System.Drawing.Color.Blue;
            this._rmLT.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this._rmLT.Location = new System.Drawing.Point(0, 0);
            this._rmLT.Margin = new System.Windows.Forms.Padding(0);
            this._rmLT.Name = "_rmLT";
            this._rmLT.Size = new System.Drawing.Size(5, 5);
            this._rmLT.TabIndex = 4;
            this._rmLT.TabStop = false;
            this._rmLT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._rmLT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnResizeMouseMove);
            this._rmLT.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // _rmRT
            // 
            this._rmRT.BackColor = System.Drawing.Color.Blue;
            this._rmRT.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this._rmRT.Location = new System.Drawing.Point(271, 0);
            this._rmRT.Margin = new System.Windows.Forms.Padding(0);
            this._rmRT.Name = "_rmRT";
            this._rmRT.Size = new System.Drawing.Size(5, 5);
            this._rmRT.TabIndex = 5;
            this._rmRT.TabStop = false;
            this._rmRT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._rmRT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnResizeMouseMove);
            this._rmRT.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // _rmRB
            // 
            this._rmRB.BackColor = System.Drawing.Color.Blue;
            this._rmRB.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this._rmRB.Location = new System.Drawing.Point(271, 235);
            this._rmRB.Margin = new System.Windows.Forms.Padding(0);
            this._rmRB.Name = "_rmRB";
            this._rmRB.Size = new System.Drawing.Size(5, 5);
            this._rmRB.TabIndex = 7;
            this._rmRB.TabStop = false;
            this._rmRB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._rmRB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnResizeMouseMove);
            this._rmRB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // _rmLeft
            // 
            this._rmLeft.BackColor = System.Drawing.Color.Blue;
            this._rmLeft.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this._rmLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._rmLeft.Location = new System.Drawing.Point(0, 5);
            this._rmLeft.Margin = new System.Windows.Forms.Padding(0);
            this._rmLeft.Name = "_rmLeft";
            this._rmLeft.Size = new System.Drawing.Size(5, 387);
            this._rmLeft.TabIndex = 2;
            this._rmLeft.TabStop = false;
            this._rmLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._rmLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnResizeMouseMove);
            this._rmLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // _rmLB
            // 
            this._rmLB.BackColor = System.Drawing.Color.Blue;
            this._rmLB.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this._rmLB.Location = new System.Drawing.Point(10, 235);
            this._rmLB.Margin = new System.Windows.Forms.Padding(0);
            this._rmLB.Name = "_rmLB";
            this._rmLB.Size = new System.Drawing.Size(5, 5);
            this._rmLB.TabIndex = 6;
            this._rmLB.TabStop = false;
            this._rmLB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._rmLB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnResizeMouseMove);
            this._rmLB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // _rmBottom
            // 
            this._rmBottom.BackColor = System.Drawing.Color.Blue;
            this._rmBottom.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this._rmBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._rmBottom.Location = new System.Drawing.Point(5, 387);
            this._rmBottom.Margin = new System.Windows.Forms.Padding(0);
            this._rmBottom.Name = "_rmBottom";
            this._rmBottom.Size = new System.Drawing.Size(418, 5);
            this._rmBottom.TabIndex = 1;
            this._rmBottom.TabStop = false;
            this._rmBottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._rmBottom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnResizeMouseMove);
            this._rmBottom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // _rmRight
            // 
            this._rmRight.BackColor = System.Drawing.Color.Blue;
            this._rmRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this._rmRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._rmRight.Location = new System.Drawing.Point(418, 5);
            this._rmRight.Margin = new System.Windows.Forms.Padding(0);
            this._rmRight.Name = "_rmRight";
            this._rmRight.Size = new System.Drawing.Size(5, 382);
            this._rmRight.TabIndex = 3;
            this._rmRight.TabStop = false;
            this._rmRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._rmRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnResizeMouseMove);
            this._rmRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // ThemeFormBase
            // 
            this.ClientSize = new System.Drawing.Size(423, 392);
            this.Controls.Add(this._rmRight);
            this.Controls.Add(this._rmBottom);
            this.Controls.Add(this._rmLB);
            this.Controls.Add(this._rmLeft);
            this.Controls.Add(this._rmRB);
            this.Controls.Add(this._rmRT);
            this.Controls.Add(this._rmLT);
            this.Controls.Add(this._rmTop);
            this.Controls.Add(this.pnlContent);
            this.Name = "ThemeFormBase";
            this.ResumeLayout(false);

        }
        #endregion

        #region Form resize and move operations

        /// <summary>
        /// Stores mouse cursor location at the time when the left button was pressed
        /// </summary>
        private Point _mouseDownLocation = Point.Empty;
        private bool _titleDragOperation = false;

        void ThemeForm_Load(object sender, EventArgs e)
        {
            ControlStyles cs = ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw | ControlStyles.CacheText;

            SetStyle(cs, true);

            int minW = Math.Max(200, this.MinimumSize.Width);
            int minH = Math.Max(100, this.MinimumSize.Height);
            this.MinimumSize = new Size(minW, minH);

            ApplyWindowParams();
        }

        FormWindowState _previousState = FormWindowState.Normal;

        void ThemeForm_Resize(object sender, EventArgs e)
        {
            if (Handle != null)
            {
                ApplyWindowParams();
            }

            if (this.WindowState != _previousState)
            {
                try
                {
                    OnWindowStateChanged(_previousState, this.WindowState);
                }
                finally
                {
                    _previousState = this.WindowState;
                }
            }
        }


        public virtual void OnWindowStateChanged(FormWindowState oldState, FormWindowState newState)
        {
        }
        
        private void OnResizeMouseMove(object sender, MouseEventArgs e)
        {
            if (sender is ResizeMargin && e.Button == MouseButtons.Left)
            {
                int dir = (int)(sender as ResizeMargin).Tag;
                User32.ReleaseCapture();
                User32.SendMessage(Handle, (int)Messages.WM_NCLBUTTONDOWN, dir, 0);
            }
        }
        
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (sender is ResizeMargin)
                {
                    (sender as ResizeMargin).Capture = true;
                }
                else if (sender == this && _rcTitle.Contains(e.Location))
                {
                    this.Capture = true;
                    _titleDragOperation = true;
                }

                _mouseDownLocation = e.Location;
            }
        }

        void ThemeForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_rcIcon.Contains(e.Location))
                {
                    Close();
                }
                else if (_rcTitle.Contains(e.Location) && _allowResize && 
                    (FormButtons & FormButtons.Maximize) == FormButtons.Maximize)
                {
                    if (this.WindowState != FormWindowState.Maximized)
                    {
                        this.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                }
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (sender is ResizeMargin)
                {
                    (sender as ResizeMargin).Capture = false;
                }
                else if (sender == this)
                {
                    this.Capture = false;
                    _titleDragOperation = false;

                    if (_rcClose.Width > 0 && _rcClose.Contains(e.Location))
                    {
                        Close();
                    }
                    else if (_rcMinimize.Width > 0 && _rcMinimize.Contains(e.Location))
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }
                    else if (_rcMaximize.Width > 0 && _rcMaximize.Contains(e.Location))
                    {
                        if (this.WindowState != FormWindowState.Maximized)
                        {
                            this.WindowState = FormWindowState.Maximized;
                        }
                        else
                        {
                            this.WindowState = FormWindowState.Normal;
                        }
                    }

                }

                _mouseDownLocation = Point.Empty;
            }
        }

        OPMToolTipManager _ttm = null;

        void OnMouseHover(object sender, EventArgs e)
        {
            MainThread.Post(delegate(object x)
            {
                Point pt = PointToClient(MousePosition);
                if (_rcTitle != Rectangle.Empty && _rcTitle.Contains(pt))
                {
                    Graphics g = this.CreateGraphics();
                    SizeF size = g.MeasureString(_text, _titleBarFont);
                    _ttm.ShowSimpleToolTip(_text);
                    return;
                }

                if (_rcMinimize != Rectangle.Empty && _rcMinimize.Contains(pt))
                {
                    _ttm.ShowSimpleToolTip(Translator.Translate("TXT_BTNMINIMIZE"));
                    return;
                }

                if (_rcMaximize != Rectangle.Empty && _rcMaximize.Contains(pt))
                {
                    string tip = (WindowState != FormWindowState.Maximized) ? 
                        Translator.Translate("TXT_BTNMAXIMIZE") : 
                        Translator.Translate("TXT_BTNRESTOREDOWN");

                    _ttm.ShowSimpleToolTip(tip);
                    return;
                }

                if (_rcClose != Rectangle.Empty && _rcClose.Contains(pt))
                {
                    _ttm.ShowSimpleToolTip(Translator.Translate("TXT_BTNCLOSE"));
                }
            });
        }

        void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_titleDragOperation)
                {
                    int dx = e.X - this._mouseDownLocation.X;
                    int dy = e.Y - this._mouseDownLocation.Y;

                    this.Left += dx;
                    this.Top += dy;
                }
            }

            _hoveredButtons = FormButtons.None;
            if (_rcClose != Rectangle.Empty && _rcClose.Contains(e.Location))
            {
                _hoveredButtons = FormButtons.Close;
            }
            else if (_rcMinimize != Rectangle.Empty && _rcMinimize.Contains(e.Location))
            {
                _hoveredButtons = FormButtons.Minimize;
            }
            else if (_rcMaximize != Rectangle.Empty && _rcMaximize.Contains(e.Location))
            {
                _hoveredButtons = FormButtons.Maximize;
            }
            else if (_rcTitle != Rectangle.Empty && _rcTitle.Contains(e.Location))
            {
            }
            else
            {
                //_tip.Hide(this);
            }

            Invalidate(_rcClose);
            Invalidate(_rcMinimize);
            Invalidate(_rcMaximize);

        }

        #endregion

        #region Drawing code

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeManager.PrepareGraphics(e.Graphics);
            PaintToBuffer(e.Graphics);
        }

        private void PaintToBuffer(Graphics g)
        {
            if (_rcTitleBar != Rectangle.Empty)
            {
                g.FillPath(_brBackground, _borderPath);
                g.DrawPath(_penBorder, _borderPath);

                if (_rcTitleBar != Rectangle.Empty)
                {
                    g.FillRectangle(_brTitlebar, _rcTitleBar);
                }

                g.DrawPath(_penBorder, _borderPath);

                if (_rcTitleBar != Rectangle.Empty)
                {
                    DrawTitleBar(g);
                }

                g.Flush();
            }
            else
            {
                g.FillPath(Brushes.Black, _borderPath);
                g.DrawPath(Pens.Black, _borderPath);
            }
        }

        private void DrawTitleBar(Graphics g)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            sf.Trimming = StringTrimming.EllipsisWord;
            sf.FormatFlags = StringFormatFlags.NoWrap;

            if (_rcIcon.Width > 0)
                g.DrawImage(this.Icon.ToBitmap(), _rcIcon);

            using (Brush b = new SolidBrush(ThemeManager.ForeColor))
            {
                if (_rcTitle.Width > 0)
                {
                    g.DrawString(_text, _titleBarFont, b, _rcTitle, sf);
                }

                if (_rcMinimize.Width > 0)
                {
                    bool hovered = (_hoveredButtons & FormButtons.Minimize) == FormButtons.Minimize;
                    ButtonIcons index = hovered ? ButtonIcons.MinimizeHovered : ButtonIcons.Minimize;
                    DrawButton(g, index, _rcMinimize);
                }

                if (_rcMaximize.Width > 0)
                {
                    bool hovered = (_hoveredButtons & FormButtons.Maximize) == FormButtons.Maximize;
                    ButtonIcons index = ButtonIcons.Minimize;

                    if (WindowState == FormWindowState.Normal)
                    {
                        index = hovered ? ButtonIcons.MaximizeHovered : ButtonIcons.Maximize;
                    }
                    else
                    {
                        index = hovered ? ButtonIcons.RestoreHovered : ButtonIcons.Restore;
                    }

                    DrawButton(g, index, _rcMaximize);
                }

                if (_rcClose.Width > 0)
                {
                    bool hovered = (_hoveredButtons & FormButtons.Close) == FormButtons.Close;
                    ButtonIcons index = hovered ? ButtonIcons.CloseHovered : ButtonIcons.Close;
                    DrawButton(g, index, _rcClose);
                }
            }
        }

        private void DrawButton(Graphics g, ButtonIcons index, Rectangle rc)
        {
            Color cl1 = ThemeManager.BackColor;
            Color cl2 = ThemeManager.BorderColor;
            Color clPen = ThemeManager.BorderColor;

            Color cl1Red = Color.FromArgb(210, 150, 160);
            Color cl2Red = Color.FromArgb(170, 30, 10);

            float percLight = 0.4f;

            int i = (int)index;
            switch (index)
            {
                case ButtonIcons.Minimize:
                    break;
                
                case ButtonIcons.MinimizeHovered:
                    cl1 = ControlPaint.Light(cl1, percLight);
                    cl2 = ThemeManager.WndValidColor;
                    break;

                case ButtonIcons.Maximize:
                    break;
                
                case ButtonIcons.MaximizeHovered:
                    cl1 = ControlPaint.Light(cl1, percLight);
                    cl2 = ThemeManager.WndValidColor;
                    break;
                
                case ButtonIcons.Restore:
                    break;
                
                case ButtonIcons.RestoreHovered:
                    cl1 = ControlPaint.Light(cl1, percLight);
                    cl2 = ThemeManager.WndValidColor;
                    break;

                case ButtonIcons.Close:
                    cl1 = cl1Red;
                    cl2 = cl2Red;
                    break;
                
                case ButtonIcons.CloseHovered:
                    cl1 = ControlPaint.Light(cl1Red, percLight);
                    cl2 = ControlPaint.Light(cl2Red, percLight);
                    break;
            }

            Rectangle rcBorder = new Rectangle(rc.Location, rc.Size);
            rcBorder.Inflate(1, 0);

            using (GraphicsPath path = ImageProcessing.GenerateRoundCornersBorder(rcBorder, 3))
            using (Pen p = new Pen(clPen, 1))
            using (Brush br = new LinearGradientBrush(rc, cl1, cl2, 90f))
            {
                g.DrawPath(p, path);
                g.FillPath(br, path);
            }

            g.DrawImageUnscaled(_btnImgList.Images[(int)index], rc);
        }

        #endregion

        #region helper methods

        private void ApplyWindowParams()
        {
            _borderPath = ImageProcessing.GenerateRoundCornersBorder(ClientRectangle, CornerSize);

            _rmRT.Location = new Point(Width - _rmRT.Width, 0);
            _rmRB.Location = new Point(Width - _rmRB.Width, Height - _rmRB.Height);
            _rmLB.Location = new Point(0, Height - _rmLB.Height);
            _rmLT.Location = new Point(0, 0);

            _rcTitleBar = (TitleBarVisible) ? new Rectangle(0, 0, Width, DefaultTitleBarHeight + 1) : Rectangle.Empty;

            Rectangle rcRegion = new Rectangle(-1, -1, Width + 2, Height + 2);
            GraphicsPath regionPath = ImageProcessing.GenerateRoundCornersBorder(rcRegion, CornerSize + 2);

            if (FormWindowState.Maximized != WindowState)
            {
                base.Region = new Region(regionPath);
            }
            else
            {
                base.Region = null;
            }

            ApplyDrawingValues();
            ApplyTitlebarValues();

            Invalidate(true);
        }

        Brush _brBackground = null;
        Brush _brTitlebar = null;
        Pen _penBorder = null;

        private void ApplyDrawingValues()
        {
            float inactiveLightPercent = 0.6f;

            if (_brBackground != null)
                _brBackground.Dispose();

                _brBackground = new SolidBrush(ThemeManager.BackColor);

            if (_brTitlebar != null)
                _brTitlebar.Dispose();

            if (_rcTitleBar != Rectangle.Empty)
            {
                if (IsActive)
                {
                    _brTitlebar = new LinearGradientBrush(_rcTitleBar,
                        ThemeManager.GradientLTColor, 
                        ThemeManager.GradientRBColor, 90f);
                }
                else
                {
                    _brTitlebar = new LinearGradientBrush(_rcTitleBar,
                        ControlPaint.Light(ThemeManager.GradientLTColor, inactiveLightPercent),
                        ControlPaint.Light(ThemeManager.GradientRBColor, inactiveLightPercent), 
                        90f);
                }
            }

            if (_penBorder != null)
                _penBorder.Dispose();

            if (IsActive)
            {
                _penBorder = new Pen(ThemeManager.BorderColor, 2);
            }
            else
            {
                _penBorder = new Pen(
                     ControlPaint.Light(ThemeManager.BorderColor, inactiveLightPercent), 2);
            }
        }

        private void ApplyTitlebarValues()
        {
            _iconLeft = 0;
            _titleLeft = 0;
            _btnCloseLeft = 0;
            _btnMinimizeLeft = 0;
            _btnMaximizeLeft = 0;

            int start = 0;

            if (this.Icon != null)
            {
                _iconLeft = IconOffset;
            }

            if (!string.IsNullOrEmpty(_text))
            {
                _titleLeft = _iconLeft + IconSize + IconOffset;
            }

            if ((FormButtons & FormButtons.Close) == FormButtons.Close)
            {
                _btnCloseLeft = Width - 6 - IconSize;
            }
            if ((FormButtons & FormButtons.Maximize) == FormButtons.Maximize)
            {
                if (_btnCloseLeft > 0)
                    start = _btnCloseLeft;
                else
                    start = Width;

                _btnMaximizeLeft = start - IconSize - 1;
            }
            if ((FormButtons & FormButtons.Minimize) == FormButtons.Minimize)
            {
                if (_btnMaximizeLeft > 0)
                    start = _btnMaximizeLeft;
                else if (_btnCloseLeft > 0)
                    start = _btnCloseLeft;
                else
                    start = Width;

                _btnMinimizeLeft = start - IconSize - 1;
            }

            start = Width;
            if (_btnCloseLeft > 0)
                start = Math.Min(start, _btnCloseLeft);
            if (_btnMaximizeLeft > 0)
                start = Math.Min(start, _btnMaximizeLeft);
            if (_btnMinimizeLeft > 0)
                start = Math.Min(start, _btnMinimizeLeft);

            _titleWidth = start - IconOffset - _titleLeft;

            _rcIcon = (_iconLeft > 0) ?
                new Rectangle(_iconLeft, IconOffset / 2 + 1, IconSize, IconSize) : Rectangle.Empty;
            _rcTitle = (_titleLeft > 0) ?      
                new Rectangle(_titleLeft, 2, _titleWidth, DefaultTitleBarHeight - 2) : Rectangle.Empty;
            
            _rcMinimize = (_btnMinimizeLeft > 0) ?
                new Rectangle(_btnMinimizeLeft, IconOffset / 2 + 1, IconSize, IconSize) : Rectangle.Empty;
            _rcMaximize = (_btnMaximizeLeft > 0) ?
                new Rectangle(_btnMaximizeLeft, IconOffset / 2 + 1, IconSize, IconSize) : Rectangle.Empty;
            _rcClose = (_btnCloseLeft > 0) ?
                new Rectangle(_btnCloseLeft, IconOffset / 2 + 1, IconSize, IconSize) : Rectangle.Empty;
        }

        #endregion
    }

    public class ToolForm : ThemeForm
    {
        public ToolForm()
            : base()
        {
            this.IsToolWindow = true;
            this.AllowResize = false;
            this.Icon = null;
        }

        public ToolForm(string title)
            : base(title)
        {
            this.IsToolWindow = true;
            this.AllowResize = false;
            this.Icon = null;
        }
    }
}
