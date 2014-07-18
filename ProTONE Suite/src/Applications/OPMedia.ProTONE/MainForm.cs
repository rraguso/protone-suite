using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.Core.Logging;
using OPMedia.Runtime.ProTONE.RemoteControl;
using OPMedia.UI.Controls;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Configuration;
using OPMedia.UI;

using System.Reflection;
using OPMedia.UI.Themes;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.Configuration;
using OPMedia.Runtime.Shortcuts;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Runtime;
using OPMedia.Core;
using OPMedia.UI.ProTONE.Controls.MediaPlayer;
using OPMedia.Runtime.ProTONE;

using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.UI.Dialogs;
using OPMedia.Runtime.ProTONE.Rendering.Base;

using OPMedia.Core.GlobalEvents;
using OPMedia.UI.Menus;
using OPMedia.Core.ComTypes;
using OPMedia.UI.ProTONE;
using OPMedia.UI.Properties;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;
using OPMedia.Runtime.ProTONE.Configuration;


namespace OPMedia.ProTONE
{
    public partial class MainForm : MainFrame, ICommandTarget
    {
        private Queue<BasicCommand> commandQueue;
        private Timer commandExecTimer;
        private BasicCommandTarget _commandTarget = null;

        TrayNotificationTarget _msgTarget = null;

        OPMToolTip _tip = new OPMToolTip();

        public void EnqueueCommand(BasicCommand cmd)
        {
            if (cmd != null)
            {
                commandQueue.Enqueue(cmd);
            }
        }

        public new void Dispose()
        {
            mediaPlayer.Dispose();
        }

        public override void SetTitle(string title)
        {
            base.SetTitle(title);
        }

        public MainForm()
            : base("TXT_APP_NAME")
        {
            AppConfig.CanSendToTray = true;
            AppConfig.Save();

            InitializeComponent();

            mnuMediaState.ForeColor = ThemeManager.MenuTextColor;

            mediaPlayer.MinimumSize = new Size(0, 0);

            if (!this.DesignMode)
            {
                commandQueue = new Queue<BasicCommand>();
                commandExecTimer = new Timer();
                commandExecTimer.Enabled = true;
                commandExecTimer.Tick += new EventHandler(OnCommandExecTimerTick);
                commandExecTimer.Interval = 500;
                commandExecTimer.Start();

                cmsMain.Font = ThemeManager.NormalFont;

                notifyIcon.Icon = ImageProvider.GetAppIcon(false);

                this.Resize += new EventHandler(MainForm_Resize);
                this.Shown += new EventHandler(MainForm_Shown);
                this.HandleDestroyed += new EventHandler(MainForm_HandleDestroyed);

                this.mnuTools.Image = Resources.settings;
                this.notifyIcon.ContextMenuStrip = this.cmsMain;
                mediaPlayer.SetRenderingMenu(cmsMain);

                OnPerformTranslation();

                MediaRenderer.DefaultInstance.FilterStateChanged += new FilterStateChangedHandler(OnMediaStateChanged);
                MediaRenderer.DefaultInstance.RenderedStreamTitleChanged += new RenderedStreamTitleChangedHandler(OnStreamTitleChanged);
            }
        }

        void MainForm_HandleDestroyed(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                MediaRenderer.DefaultInstance.FilterStateChanged -= new FilterStateChangedHandler(OnMediaStateChanged);
            }
        }

        int _cmdMenusCount = 0;

        protected override void RegisterMessageBoxTarget()
        {
            _msgTarget = new TrayNotificationTarget(this);
        }

        void MainForm_Shown(object sender, EventArgs e)
        {
            _commandTarget = new BasicCommandTarget(this);

            mediaPlayer.DoLayout();

            BuildThumbnailButtons(true);
        }

        private void BuildThumbnailButtons(bool add)
        {
            if (_commandTarget != null)
            {
                for (OPMShortcut cmd = OPMShortcut.CmdPlay; cmd <= OPMShortcut.CmdLoad; cmd++)
                {
                    string name = cmd.ToString().Replace("Cmd", "btn");

                    Bitmap img = OPMedia.UI.ProTONE.Properties.Resources.ResourceManager.GetImage(name);
                    if (img != null)
                    {
                        string btnTitle = Translator.Translate("TXT_" + cmd.ToString().ToUpperInvariant());
                        TaskbarThumbnailManager.Instance.AddThumbnailButton(btnTitle, img, (int)cmd);
                    }
                }

                TaskbarThumbnailManager.Instance.SubmitThumbnailButtons(add);
            }
        }

        void MainForm_Resize(object sender, EventArgs e)
        {
            mediaPlayer.DoLayout();
        }

        void OnStreamTitleChanged(string newTitle)
        {
            MainThread.Post((d) =>
            {
                SetTitle(mediaPlayer.BuildTitle());
            });
        }

        void OnMediaStateChanged(FilterState oldState, string oldMedia, FilterState newState, string newMedia)
        {
            string FilterState = string.Empty;
            if (BuildMediaStateString(false, ref FilterState))
            {
                mnuMediaState.Visible = true;

                if (FilterState.Length > 45)
                {
                    mnuMediaState.Text = FilterState.Substring(0, 45) + "...";
                    mnuMediaState.ToolTipText = FilterState.Replace(": ", ":\n");
                }
                else
                {
                    mnuMediaState.Text = FilterState;
                    mnuMediaState.ToolTipText = "";
                }
            }
            else
            {
                mnuMediaState.Visible = false;
            }

            SetTitle(mediaPlayer.BuildTitle());
        }

        [EventSink(EventNames.PerformTranslation)]
        public void OnPerformTranslation()
        {
            Translator.TranslateControl(this, DesignMode);

            mnuPlaylistPlaceholder.Text = Translator.Translate("TXT_PLAYLIST");
            mnuAbout.Text = Translator.Translate("TXT_ABOUT", Translator.Translate("TXT_APP_NAME"));
            mnuTools.Text = Translator.Translate("TXT_MNUTOOLS");
            mnuExit.Text = Translator.Translate("TXT_BTNCLOSE");
            
            ThemeManager.SetFont(this, FontSizes.Normal);

            BuildThumbnailButtons(false);
        }

        bool BuildMediaStateString(bool addTime, ref string message)
        {
            message = MediaRenderer.DefaultInstance.TranslatedFilterState;

            try
            {
                if (!string.IsNullOrEmpty(mediaPlayer.PlayedFileTitle))
                {
                    message += ": " + mediaPlayer.PlayedFileTitle;
                }

                if (addTime)
                {
                    bool running = (MediaRenderer.DefaultInstance.FilterState == FilterState.Running || 
                        MediaRenderer.DefaultInstance.FilterState == FilterState.Paused);

                    if (running)
                    {
                        int pos = (int)MediaRenderer.DefaultInstance.MediaPosition;
                        int len = (int)MediaRenderer.DefaultInstance.MediaLength;

                        const int MaxTrackerLen = 20;
                        int trackerPos = (int)(MaxTrackerLen * pos / len);

                        string currentTime = TimeSpan.FromSeconds(pos).ToString();
                        string totalTime = TimeSpan.FromSeconds(len).ToString();

                        string posStr = string.Empty;
                        for (int i = 0; i < MaxTrackerLen; i++)
                        {
                            posStr += (i == trackerPos) ? "|" : "-";
                        }

                        message += string.Format("\r\n\r\n{0} / {1} [{2}]", currentTime, totalTime, posStr);
                    }
                }
            }
            catch
            {
            }

            return (addTime || !string.IsNullOrEmpty(mediaPlayer.PlayedFileTitle));
        }

        protected override bool IsShortcutAllowed(OPMShortcut cmd)
        {
            // Any command in range is valid.
            return (ShortcutMapper.CmdFirst <= cmd && cmd <= ShortcutMapper.CmdLast);
        }

        private void OnCommandExecTimerTick(object sender, EventArgs e)
        {
            if (commandQueue.Count > 0)
            {
                BasicCommand cmd = commandQueue.Dequeue();
                ProcessCommand(cmd);
            }
        }

        private void ProcessCommand(BasicCommand cmd)
        {
            switch (cmd.CommandType)
            {
                case CommandType.Activate:
                    RevealWindow();
                    mediaPlayer.DoLayout();
                    break;
                case CommandType.Terminate:
                    if (CanTerminate())
                    {
                        Application.Exit();
                    }
                    break;
                case CommandType.PlayFiles:
                    mediaPlayer.PlayFiles(cmd.Args);
                    break;
                case CommandType.EnqueueFiles:
                    mediaPlayer.EnqueueFiles(cmd.Args);
                    break;
                case CommandType.Playback:
                    ProcessPlaybackCommand(cmd.Args);
                    break;

                case CommandType.KeyPress:
                    (cmd as KeyPressCommand).Execute();
                    break;
            }
        }

        private void ProcessPlaybackCommand(string[] args)
        {
            try
            {
                OPMShortcut cmd = (OPMShortcut)Enum.Parse(typeof(OPMShortcut), args[0]);
                ShortcutMapper.DispatchCommand(cmd);
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        private bool CanTerminate()
        {
            return true;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MainThread.AreModalFormsOpen)
                return;

            if (Visible)
            {
                ConcealWindow();
            }
            else
            {
                RevealWindow();
                mediaPlayer.DoLayout();
            }
        }

        protected override void OnRevealWindow()
        {
            BuildThumbnailButtons(true);
        }

        bool _tipActive = false;

        void notifyIcon_MouseMove(object sender, MouseEventArgs e)
        {
            string info = string.Empty;
            if (!_tipActive && BuildMediaStateString(true, ref info))
            {
                _tipActive = true;

                TrayNotificationBox f = new TrayNotificationBox();
                f.HideDelay = 3000;
                f.FormClosed += new FormClosedEventHandler(f_FormClosed);
                f.ShowSimple(info);
            }
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            _tipActive = false;
        }

        public void NotifyMenuClick(object sender, System.EventArgs e)
        {
            mediaPlayer.HandlePlaylistItemMenuClick(sender, e);
        }

        private void VolumeScalePositionChanged(double newVal)
        {
            mediaPlayer.SetVolume(newVal);
        }

        private void TimeScalePositionChanged(double newVal)
        {
            mediaPlayer.MoveToPosition(newVal);
        }

        void cmsMain_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = MainThread.AreModalFormsOpen;

            cmsMain.SuspendLayout();

            while (_cmdMenusCount > 0)
            {
                cmsMain.Items.RemoveAt(0);
                _cmdMenusCount--;
            }

            _cmdMenusCount = new MenuBuilder<ContextMenuStrip>(null).BuildCommandsMenu(0,
                    new MenuWrapper<ContextMenuStrip>(cmsMain), new EventHandler(NotifyMenuClick));

            foreach (ToolStripItem tsi in cmsMain.Items)
            {
                if (tsi == mnuMediaState)
                    continue;

                string text = tsi.Text;

                if (text.Length > 45)
                {
                    tsi.Text = text.Substring(0, 45) + "...";
                    tsi.ToolTipText = text;
                }
                else
                {
                    tsi.ToolTipText = "";
                }
                
                if (tsi is OPMToolStripMenuItem && tsi.Tag != null)
                {
                    switch((OPMShortcut)tsi.Tag)
                    {
                        case OPMShortcut.CmdToggleShuffle:
                            (tsi as OPMToolStripMenuItem).Checked = ProTONEConfig.ShufflePlaylist;
                            break;
                        case OPMShortcut.CmdPlaylistEnd:
                            (tsi as OPMToolStripMenuItem).Checked = SystemScheduler.PlaylistEventEnabled;
                            break;
                        case OPMShortcut.CmdLoopPlay:
                            (tsi as OPMToolStripMenuItem).Checked = ProTONEConfig.LoopPlay;
                            break;
                    }

                    if (tsi.Tag != null)
                    {
                        (tsi as OPMToolStripMenuItem).ShortcutKeyDisplayString =
                            ShortcutMapper.GetShortcutString((OPMShortcut)tsi.Tag);
                    }
                }
            }

            // Dummy playlist item  - required to prevent initial "delayed" opening
            mnuPlaylistPlaceholder.DropDownItems.Add(string.Empty);
            mnuPlaylistPlaceholder.DropDownOpening += new EventHandler(mnuPlaylist_DropDownOpening);

            mnuTools.DropDownItems.Add(string.Empty);
            mnuTools.DropDownOpening += new EventHandler(mnuTools_DropDownOpening);

            volumeScale.Width = timeScale.Width = 250;

            cmsMain.ResumeLayout();
        }

        void mnuTools_DropDownOpening(object sender, EventArgs e)
        {
            mnuTools.DropDownItems.Clear();
            new MenuBuilder<OPMToolStripMenuItem>(null).AttachToolsMenu(
               new MenuWrapper<OPMToolStripMenuItem>(mnuTools), new EventHandler(NotifyMenuClick));
        }

        public void mnuPlaylist_DropDownOpening(object sender, EventArgs e)
        {
            mnuPlaylistPlaceholder.DropDownItems.Clear();
            mediaPlayer.BuildPlaylistMenu(mnuPlaylistPlaceholder, new EventHandler(NotifyMenuClick));

            foreach (ToolStripItem tsi in mnuPlaylistPlaceholder.DropDownItems)
            {
                string text = tsi.Text;

                if (text.Length > 45)
                {
                    tsi.Text = text.Substring(0, 45) + "...";
                    tsi.ToolTipText = text;
                }
                else
                {
                    tsi.ToolTipText = "";
                }

            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            this.Close();
        }

        void OnAbout(object sender, System.EventArgs e)
        {
            MessageDisplay.ShowAboutBox();
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == (int)Messages.WM_COMMAND)
                {
                    if (ThumbButton.Clicked == User32.HIWORD((long)m.WParam))
                    {
                        int id = User32.LOWORD((long)m.WParam);

                        if (!MainThread.AreModalFormsOpen)
                        {
                            ShortcutMapper.DispatchCommand((OPMShortcut)id);

                            // If an application processes this message, it should return zero.
                            m.Result = IntPtr.Zero;
                        }
                    }
                }
            }
            catch { }

            base.WndProc(ref m);
        }

        protected override void OnThemeUpdatedInternal()
        {
            mnuMediaState.ForeColor = ThemeManager.MenuTextColor;
        }
    }
}