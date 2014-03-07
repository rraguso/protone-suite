using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core;
using OPMedia.Core.Logging;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Runtime;
using OPMedia.UI.Controls;
using OPMedia.Runtime.Shortcuts;
using OPMedia.UI.Dialogs;
using System.Threading;

using OPMedia.Core.GlobalEvents;
using OPMedia.UI.ApplicationUpdate;
using OPMedia.UI.HelpSupport;


namespace OPMedia.UI.Themes
{
    #region ThemeForm

    public partial class ThemeForm : ThemeFormBase
    {

        private Color _bkColor = ThemeManager.BackColor;
        private Color _borderColor = ThemeManager.BorderColor;
        private FontSizes _fontSize = FontSizes.Normal;

        public FontSizes FontSize
        {
            get
            {
                return _fontSize;
            }

            set
            {
                _fontSize = value;

                base.Font = this.Font;

                foreach (Control ctl in this.Controls)
                {
                    if (ctl is OPMBaseControl)
                    {
                        (ctl as OPMBaseControl).FontSize = value;
                    }
                    else
                    {
                        ctl.Font = this.Font;
                    }
                }
            }
        }

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Font Font
        {
            get
            {
                return ThemeManager.GetFontBySize(_fontSize);
            }
        }

        bool _inheritAppIcon = true;
        [DefaultValue(true)]
        public bool InheritAppIcon 
        { get { return _inheritAppIcon; } set { _inheritAppIcon = value; } }

        Icon _icon = null;
        public new Icon Icon
        { get { return _icon; } set { _icon = value; ApplyIcons(); } }

        public new bool ShowInTaskbar
        { get { return base.ShowInTaskbar; } set { base.ShowInTaskbar = value; ApplyIcons(); } }

        public new DialogResult ShowDialog()
        {
            Form owner = null;
            if (this != MainThread.MainWindow)
            {
                owner = MainThread.MainWindow;
            }

            return base.ShowDialog(owner);
        }

        public ThemeForm() : base()
        {
            InitializeComponent();

            this.Visible = false; 
            base.MinimizeBox = false;
            base.MaximizeBox = false;

            this.DoubleBuffered = true;

            this.KeyDown += new KeyEventHandler(ThemeForm_KeyDown);
            this.Load += new EventHandler(ThemeForm_Load);
            this.HandleCreated += new EventHandler(ThemeForm_HandleCreated);
            this.FormClosed += new FormClosedEventHandler(ThemeForm_FormClosed);
            this.Resize += new EventHandler(ThemeForm_Resize);

            this.Shown += new EventHandler(ThemeForm_Shown);

            this.ShowInTaskbar = false;
        }

        void ThemeForm_Shown(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (!(this is MainFrame))
                {
                    IWin32Window owner = MainThread.MainWindow;
                    if (owner == null ||
                        !User32.IsWindow(owner.Handle) ||
                        !User32.IsWindowVisible(owner.Handle))
                    {
                        owner = NativeWindow.FromHandle(User32.GetDesktopWindow());
                    }

                    bool centerParent = (owner != null &&
                         owner != this &&
                         User32.IsWindow(owner.Handle) &&
                         User32.IsWindowVisible(owner.Handle));

                    if (centerParent)
                    {
                        CenterToParent();
                    }
                    else
                    {
                        CenterToScreen();
                    }

                    this.BringToFront();
                    this.Activate();
                }
            }
        }

        void ThemeForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                int th = TitleBarVisible ? DefaultTitleBarHeight : 0;
                pnlContent.SetLocation(new Point(5, th + 2));
                pnlContent.SetSize(new Size(this.Width - 10, this.Height - th - 7));
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlContent.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            // 
            // ThemeForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "ThemeForm";
            this.ResumeLayout(false);

        }

        public ThemeForm(string title)
            : this()
        {
            SetTitle(title);
        }

        [EventSink(EventNames.ExecuteShortcut)]
        public void ExecuteShortcut(OPMShortcutEventArgs args)
        {
            Logger.LogHeavyTrace("{0} - IsActive: {1}", Name, IsActive);

            bool isActiveForm = this.IsActive;
            //bool isMainForm = (this is MainApplicationForm);
            //bool isInTray = !Visible || (WindowState == FormWindowState.Minimized);

            if (!args.Handled)
            {
                switch (args.cmd)
                {
                    case OPMShortcut.CmdOpenHelp:
                        if (IsActive || (this is LogFileConsoleDialog))
                        {
                            FireHelpRequest();
                            args.Handled = true;
                        }
                        return;

                    case OPMShortcut.CmdShowLogConsole:
                        LogFileConsoleDialog.ShowLogConsole();

                        args.Handled = true;
                        return;

                    default:
                        // Do nothing
                        break;
                }

                OnExecuteShortcut(args);
            }
        }

        public virtual void OnExecuteShortcut(OPMShortcutEventArgs args) { }

        public virtual void FireHelpRequest() 
        {
            HelpTarget.HelpRequest(this.Name);
        }

        void ThemeForm_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessKeyDown(e.KeyData, e.Modifiers);
        }

        protected bool ProcessKeyDown(Keys key, Keys modifiers)
        {
            if (modifiers == Keys.None &&
                (key == Keys.Escape || key == Keys.Enter) &&
                AllowCloseOnEnterOrEscape())
            {
                DialogResult = (key == Keys.Escape) ?
                    DialogResult.Cancel : DialogResult.OK;

                Close();
                return false;
            }
            else
            {
                OPMShortcut cmd = ShortcutMapper.MapCommand(key);
                if (IsShortcutAllowed(cmd))
                {
                    ShortcutMapper.DispatchCommand(cmd);
                    return false;
                }
            }

            return true;
        }

        protected virtual bool IsShortcutAllowed(OPMShortcut cmd)
        {
            // By default we don't allow any command but Help and Show Log

            switch (cmd)
            {
                case OPMShortcut.CmdOpenHelp:
                case OPMShortcut.CmdShowLogConsole:
                    return true;

                default:
                    return false;
            }
        }

        string _title = string.Empty;

        delegate void SetTitleDelegate(string title);
        public virtual void SetTitle(string title)
        {
            if (InvokeRequired)
            {
                Invoke(new SetTitleDelegate(SetTitle), new object[] { title });
                return;
            }

            base.Text = Translator.Translate(title);
        }

        protected virtual bool AllowCloseOnEnterOrEscape()
        {
            return true;
        }

        protected virtual bool CanUpdateInterfaceStyle()
        {
            return true;
        }

        void ThemeForm_HandleCreated(object sender, EventArgs e)
        {
            ApplyIcons();
            EventDispatch.RegisterHandler(this);
        }

        void ThemeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventDispatch.UnregisterHandler(this);
        }

        void ThemeForm_Load(object sender, EventArgs e)
        {
            Translator.TranslateControl(this, DesignMode);
        }

        public void ApplyIcons()
        {
            if (_inheritAppIcon)
            {
                _icon = ImageProvider.GetAppIcon(true);
            }

            base.ShowIcon = true;
            base.Icon = _icon;
        }

        protected virtual bool OnChangeWindowState(FormWindowState requestedState)
        {
            return false;
        }

    }

    #endregion

    #region ThemeFrame
    public class ThemeFrame : ThemeForm
    {
        public ThemeFrame(string title) : base(title)
        {
        }

        public ThemeFrame()
            : this(string.Empty)
        {
        }
    }
    #endregion

    #region MainFrame

    public class MainFrame : ThemeFrame
    {
        private ThemedMessageBoxTarget _messageTarget;
        private ApplicationUpdateHelper _updateHelper;

        public MainFrame(string title) : base(title)
        {
            base.MinimizeBox = true;
            base.MaximizeBox = true;

            AttachEvents();

            this.ShowInTaskbar = true;
        }

        public MainFrame()
            : this(string.Empty)
        {
        }

        private void AttachEvents()
        {
            if (!DesignMode)
            {
                this.Shown += new EventHandler(OnShown);
                this.HandleDestroyed += new EventHandler(OnHandleDestroyed);
            }

            _updateHelper = new ApplicationUpdateHelper();

            RegisterMessageBoxTarget();
        }

        protected virtual void RegisterMessageBoxTarget()
        {
            _messageTarget = new ThemedMessageBoxTarget();
        }

        void OnMove(object sender, EventArgs e)
        {
            if (previousState == FormWindowState.Normal && 
                WindowState == FormWindowState.Normal)
            {
                // Only persist position if moving in normal state.
                // Does not make sense to persist position when maximized or minimized.
                PersistPosition();
            }
        }

        FormWindowState previousState = FormWindowState.Normal;
        void OnResize(object sender, EventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Maximized:
                    // Entering Maximized -- must persist state.
                    PersistState();
                    break;

                case FormWindowState.Normal:
                    if (previousState == FormWindowState.Maximized)
                    {
                        // Normal after Maximized -- must restore previous position.
                        RestorePosition();
                    }
                    else if (previousState == FormWindowState.Normal)
                    {
                        // Only persist position if resizing in normal state.
                        // Does not make sense to persist position when maximized or minimized.
                        PersistPosition();
                    }
                    break;

                case FormWindowState.Minimized:
                    // Entering Maximized -- must hide the window.
                    // ConcealWindow takes care if this actually must happen 
                    // (As indicated by CanSendToTray app setting).
                    ConcealWindow();
                    break;
            }

            previousState = WindowState;
        }

        void OnHandleDestroyed(object sender, EventArgs e)
        {
            // When exiting save everything.

            PersistTrayState();
            PersistState();
            PersistPosition();

            AppSettings.Save();
        }

        void OnShown(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                // Restore previous state / position when starting up.
                RestoreTrayState();
                RestoreState();
                RestorePosition();

                previousState = WindowState;

                this.Resize += new EventHandler(OnResize);
                this.Move += new EventHandler(OnMove);
            }
        }

        protected void ConcealWindow()
        {
            if (AppSettings.CanSendToTray)
            {
                PersistPosition();
                //PersistState();

                Hide();

                PersistTrayState();

                OnConcealWindow();
            }
        }

        protected void RevealWindow()
        {
            Show();
            ApplyIcons();
            BringToFront();

            PersistTrayState();
            RestoreState();
            RestorePosition();

            Activate();

            OnRevealWindow();
        }

        protected virtual void OnRevealWindow() { }
        protected virtual void OnConcealWindow() { }

        protected void PersistPosition()
        {
            if (!_positionRestored) return;

            if (Visible && this.WindowState == FormWindowState.Normal)
            {
                AppSettings.WindowLocation = this.Location;
                AppSettings.WindowSize = this.Size;
            }
        }

        protected void PersistState()
        {
            if (!_stateRestored) return;

            if (Visible)
            {
                AppSettings.WindowState = this.WindowState;
            }
        }

        protected void PersistTrayState()
        {
            if (!_trayStateRestored) return;

            AppSettings.MimimizedToTray = !Visible;
        }

        bool _positionRestored = false;
        protected void RestorePosition()
        {
            if (Visible && WindowState == FormWindowState.Normal)
            {
                // Get the display rectangle
                Rectangle displayRect = Screen.GetWorkingArea(this);

                Point restoreLocation = AppSettings.WindowLocation;
                Size restoreSize = AppSettings.WindowSize;

                if (!displayRect.Contains(restoreLocation))
                {
                    // Bring the left top corner into view
                    restoreLocation = new Point(0, 0);
                }

                // Check whether the original window size combined with actual location fits the screen.
                // If it does not fit the screen adjust the window size so as it will fit the best.
                restoreSize.Width = Math.Min(restoreSize.Width, displayRect.Width - restoreLocation.X);
                restoreSize.Height = Math.Min(restoreSize.Height, displayRect.Height - restoreLocation.Y);

                this.Location = restoreLocation;
                this.Size = restoreSize;
            }

            _positionRestored = true;
        }

        bool _stateRestored = false;
        protected void RestoreState()
        {
            if (Visible)
            {
                this.WindowState = AppSettings.WindowState;
            }

            _stateRestored = true;
        }

        bool _trayStateRestored = false;
        protected void RestoreTrayState()
        {
            if (AppSettings.MimimizedToTray)
                Hide();
            else
                Show();

            _trayStateRestored = true;
        }

        
    }

    #endregion
}








