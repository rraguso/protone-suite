using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.Addons.AddonsBase.Navigation;
using OPMedia.UI.Controls;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.Addons.Configuration;
using OPMedia.UI.Themes;
using SubtitleEditor.extension.Configuration;
using OPMedia.Runtime.ProTONE.SubtitleDownload;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Core.GlobalEvents;
using OPMedia.UI.ProTONE.GlobalEvents;
using OPMedia.Runtime.Shortcuts;
using SubtitleEditor.extension.DataLayer;
using OPMedia.UI.Controls.Dialogs;
using OPMedia.Runtime.Addons.AddonsBase;
using OPMedia.Runtime.Addons;
using OPMedia.Core.ApplicationSettings;
using System.IO;

namespace SubtitleEditor.Navigation
{
    public partial class AddonPanel : NavBaseCtl
    {
        private OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMToolStrip toolStripMain;
        private OPMToolStripButton tsbNew;
        private OPMToolStripSplitButton tsbOpen;
        private OPMToolStripButton tsbSave;
        private OPMToolStripButton tsbSaveAs;
        private OPMToolStripSeparator toolStripSeparator1;
        private OPMToolStripButton tsbBack;
        private OPMToolStripButton tsbForward;
        private OPMToolStripSeparator toolStripSeparator7;
        private OPMToolStripButton tsbSearch;
        private OPMToolStripButton tsbReload;
        private OPMToolStripSeparator toolStripSeparator2;
        private OPMToolStripButton tsbCopy;
        private OPMToolStripButton tsbCut;
        private OPMToolStripButton tsbPaste;
        private OPMToolStripSeparator tssCopyPaste;
        private OPMToolStripButton tsbRename;
        private OPMToolStripButton tsbDelete;
        private OPMToolStripSeparator tssMergeCatalogs;
        private ContextMenuStrip contextMenuStrip;
        private IContainer components;
        private OPMToolStripMenuItem tsmiBack;
        private OPMToolStripMenuItem tsmiFwd;
        private OPMToolStripSeparator tsmiSep1;
        private OPMToolStripMenuItem tsmiSearch;
        private OPMToolStripMenuItem tsmiReload;
        private OPMToolStripSeparator tsmiSep2;
        private OPMToolStripMenuItem tsmiCopy;
        private OPMToolStripMenuItem tsmiCut;
        private OPMToolStripMenuItem tsmiPaste;
        private OPMToolStripSeparator tsmiCopyPaste;
        private OPMToolStripMenuItem tsmiRename;
        private OPMToolStripMenuItem tsmiDelete;


        bool _operationInProgress = false;
        private System.Windows.Forms.Timer updateUiTimer;
        private extension.Navigation.SubtitleListView lvSubtitles;

        public Subtitle _sub = Subtitle.Empty;

        public override List<string> HandledFileTypes
        {
            get
            {
                return MediaRenderer.GetSupportedFileProvider().SupportedSubtitles;
            }
        }

        public override string GetHelpTopic()
        {
            return "SubtitleEditor";
        }

        public AddonPanel()
        {
            InitializeComponent();

            this.HandleCreated += new EventHandler(AddonPanel_HandleCreated);

            this.AddonImage = OPMedia.UI.ProTONE.Properties.Resources.ResourceManager.GetImage("subtitles");
            this.SmallAddonImage = OPMedia.UI.ProTONE.Properties.Resources.ResourceManager.GetImage("subtitles16");

            updateUiTimer = new System.Windows.Forms.Timer();
            updateUiTimer.Enabled = true;
            updateUiTimer.Interval = 500;
            updateUiTimer.Start();
            updateUiTimer.Tick += new EventHandler(updateUiTimer_Tick);

            lvSubtitles.SelectedIndexChanged += new EventHandler(lvSubtitles_SelectedIndexChanged);
        }

        void lvSubtitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSubtitles.SelectedItems.Count > 0)
            {
                SubtitleElement elem = lvSubtitles.SelectedItems[0].Tag as SubtitleElement;

                string item = (_sub != null) ? _sub.File : string.Empty;
                List<string> items = new List<string>();
                items.Add(item);

                base.RaiseNavigationAction(NavActionType.ActionSelectFile, items, elem);
                base.RaiseNavigationAction(NavActionType.ActionReloadPreview, items, elem);
            }
        }

        void updateUiTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                updateUiTimer.Stop();

                //if (AppSettings.MCRememberRecentFiles)
                //{
                //    tsbOpen.DropDownButtonWidth = 15;
                //}
                //else
                //{
                //    tsbOpen.DropDownButtonWidth = 1;
                //    tsbOpen.DropDownItems.Clear();
                //}

                SuspendLayout();
                OnUpdateUi(toolStripMain.Items);
                OnUpdateUi(contextMenuStrip.Items);
                ResumeLayout();

                //DisplayCurrentPath();
            }
            finally
            {
                updateUiTimer.Start();
            }
        }

        void AddonPanel_HandleCreated(object sender, EventArgs e)
        {
            string launchPath = this.Tag as string;
            //opmLabel1.Text = launchPath;

            OnPerformTranslation();

            lvSubtitles.Subtitle = _sub;
        }

        protected override OPMedia.UI.Configuration.BaseCfgPanel GetBaseCfgPanel()
        {
            return new SubtitleEditorCfgPanel();
        }

        #region Auto-generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.toolStripMain = new OPMedia.UI.Controls.OPMToolStrip();
            this.tsbNew = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbOpen = new OPMedia.UI.Controls.OPMToolStripSplitButton();
            this.tsbSave = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbSaveAs = new OPMedia.UI.Controls.OPMToolStripButton();
            this.toolStripSeparator1 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsbBack = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbForward = new OPMedia.UI.Controls.OPMToolStripButton();
            this.toolStripSeparator7 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsbSearch = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbReload = new OPMedia.UI.Controls.OPMToolStripButton();
            this.toolStripSeparator2 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsbCopy = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbCut = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbPaste = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tssCopyPaste = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsbRename = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbDelete = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tssMergeCatalogs = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.lvSubtitles = new SubtitleEditor.extension.Navigation.SubtitleListView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiBack = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiFwd = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiSep1 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmiSearch = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiReload = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiSep2 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmiCopy = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiCut = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiPaste = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiCopyPaste = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmiRename = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiDelete = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 1;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Controls.Add(this.toolStripMain, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.lvSubtitles, 0, 1);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 2;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(1123, 613);
            this.opmTableLayoutPanel1.TabIndex = 1;
            // 
            // toolStripMain
            // 
            this.toolStripMain.AllowMerge = false;
            this.toolStripMain.AutoSize = false;
            this.toolStripMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.toolStripMain.CanOverflow = false;
            this.toolStripMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbOpen,
            this.tsbSave,
            this.tsbSaveAs,
            this.toolStripSeparator1,
            this.tsbBack,
            this.tsbForward,
            this.toolStripSeparator7,
            this.tsbSearch,
            this.tsbReload,
            this.toolStripSeparator2,
            this.tsbCopy,
            this.tsbCut,
            this.tsbPaste,
            this.tssCopyPaste,
            this.tsbRename,
            this.tsbDelete,
            this.tssMergeCatalogs});
            this.toolStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Padding = new System.Windows.Forms.Padding(0);
            this.toolStripMain.ShowBorder = true;
            this.toolStripMain.Size = new System.Drawing.Size(1123, 48);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.VerticalGradient = true;
            // 
            // tsbNew
            // 
            this.tsbNew.Image = global::SubtitleEditor.extension.Properties.Resources.New;
            this.tsbNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(60, 45);
            this.tsbNew.Tag = "ToolActionNew";
            this.tsbNew.Text = "TXT_NEW";
            this.tsbNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNew.ToolTipText = "Create new catalog";
            this.tsbNew.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = global::SubtitleEditor.extension.Properties.Resources.Open;
            this.tsbOpen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsbOpen.Size = new System.Drawing.Size(76, 45);
            this.tsbOpen.Tag = "ToolActionOpen";
            this.tsbOpen.Text = "TXT_OPEN";
            this.tsbOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbOpen.ToolTipText = "Open catalog";
            this.tsbOpen.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbSave
            // 
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = global::SubtitleEditor.extension.Properties.Resources.Save;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(61, 45);
            this.tsbSave.Tag = "ToolActionSave";
            this.tsbSave.Text = "TXT_SAVE";
            this.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSave.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbSaveAs
            // 
            this.tsbSaveAs.Enabled = false;
            this.tsbSaveAs.Image = global::SubtitleEditor.extension.Properties.Resources.SaveAs;
            this.tsbSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAs.Name = "tsbSaveAs";
            this.tsbSaveAs.Size = new System.Drawing.Size(78, 45);
            this.tsbSaveAs.Tag = "ToolActionSaveAs";
            this.tsbSaveAs.Text = "TXT_SAVE_AS";
            this.tsbSaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSaveAs.Click += new System.EventHandler(this.OnToolAction);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbBack
            // 
            this.tsbBack.Enabled = false;
            this.tsbBack.Image = global::SubtitleEditor.extension.Properties.Resources.Back;
            this.tsbBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbBack.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBack.Name = "tsbBack";
            this.tsbBack.Size = new System.Drawing.Size(62, 45);
            this.tsbBack.Tag = "ToolActionBack";
            this.tsbBack.Text = "TXT_BACK";
            this.tsbBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbBack.ToolTipText = "Back to ";
            this.tsbBack.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbForward
            // 
            this.tsbForward.Enabled = false;
            this.tsbForward.Image = global::SubtitleEditor.extension.Properties.Resources.Forward;
            this.tsbForward.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbForward.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbForward.Name = "tsbForward";
            this.tsbForward.Size = new System.Drawing.Size(86, 45);
            this.tsbForward.Tag = "ToolActionFwd";
            this.tsbForward.Text = "TXT_FORWARD";
            this.tsbForward.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbForward.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbForward.ToolTipText = "Forward to";
            this.tsbForward.Click += new System.EventHandler(this.OnToolAction);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbSearch
            // 
            this.tsbSearch.Enabled = false;
            this.tsbSearch.Image = global::SubtitleEditor.extension.Properties.Resources.Search;
            this.tsbSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(74, 45);
            this.tsbSearch.Tag = "ToolActionSearch";
            this.tsbSearch.Text = "TXT_SEARCH";
            this.tsbSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSearch.ToolTipText = "Search ...";
            this.tsbSearch.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbReload
            // 
            this.tsbReload.Enabled = false;
            this.tsbReload.Image = global::SubtitleEditor.extension.Properties.Resources.Reload;
            this.tsbReload.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbReload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReload.Name = "tsbReload";
            this.tsbReload.Size = new System.Drawing.Size(79, 45);
            this.tsbReload.Tag = "ToolActionReload";
            this.tsbReload.Text = "TXT_REFRESH";
            this.tsbReload.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbReload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbReload.ToolTipText = "Reload";
            this.tsbReload.Click += new System.EventHandler(this.OnToolAction);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbCopy
            // 
            this.tsbCopy.Enabled = false;
            this.tsbCopy.Image = global::SubtitleEditor.extension.Properties.Resources.Copy;
            this.tsbCopy.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(65, 45);
            this.tsbCopy.Tag = "ToolActionCopy";
            this.tsbCopy.Text = "TXT_COPY";
            this.tsbCopy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCopy.ToolTipText = "Copy selection";
            this.tsbCopy.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbCut
            // 
            this.tsbCut.Enabled = false;
            this.tsbCut.Image = global::SubtitleEditor.extension.Properties.Resources.Cut;
            this.tsbCut.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCut.Name = "tsbCut";
            this.tsbCut.Size = new System.Drawing.Size(57, 45);
            this.tsbCut.Tag = "ToolActionCut";
            this.tsbCut.Text = "TXT_CUT";
            this.tsbCut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbCut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCut.ToolTipText = "Cut selection";
            this.tsbCut.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbPaste
            // 
            this.tsbPaste.Enabled = false;
            this.tsbPaste.Image = global::SubtitleEditor.extension.Properties.Resources.Paste;
            this.tsbPaste.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.Size = new System.Drawing.Size(66, 45);
            this.tsbPaste.Tag = "ToolActionPaste";
            this.tsbPaste.Text = "TXT_PASTE";
            this.tsbPaste.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbPaste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPaste.ToolTipText = "Paste selection";
            this.tsbPaste.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tssCopyPaste
            // 
            this.tssCopyPaste.Name = "tssCopyPaste";
            this.tssCopyPaste.Size = new System.Drawing.Size(6, 48);
            this.tssCopyPaste.Tag = "";
            // 
            // tsbRename
            // 
            this.tsbRename.Enabled = false;
            this.tsbRename.Image = global::SubtitleEditor.extension.Properties.Resources.Rename;
            this.tsbRename.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbRename.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRename.Name = "tsbRename";
            this.tsbRename.Size = new System.Drawing.Size(76, 45);
            this.tsbRename.Tag = "ToolActionRename";
            this.tsbRename.Text = "TXT_RENAME";
            this.tsbRename.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbRename.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbRename.ToolTipText = "Rename Selection";
            this.tsbRename.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Image = global::SubtitleEditor.extension.Properties.Resources.Delete;
            this.tsbDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(74, 45);
            this.tsbDelete.Tag = "ToolActionDelete";
            this.tsbDelete.Text = "TXT_DELETE";
            this.tsbDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDelete.ToolTipText = "Delete ";
            this.tsbDelete.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tssMergeCatalogs
            // 
            this.tssMergeCatalogs.Name = "tssMergeCatalogs";
            this.tssMergeCatalogs.Size = new System.Drawing.Size(6, 48);
            // 
            // lvSubtitles
            // 
            this.lvSubtitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSubtitles.Location = new System.Drawing.Point(3, 51);
            this.lvSubtitles.MultiSelect = false;
            this.lvSubtitles.Name = "lvSubtitles";
            this.lvSubtitles.OverrideBackColor = System.Drawing.Color.Empty;
            this.lvSubtitles.Size = new System.Drawing.Size(1117, 559);
            this.lvSubtitles.Subtitle = null;
            this.lvSubtitles.TabIndex = 2;
            this.lvSubtitles.UseCompatibleStateImageBehavior = false;
            this.lvSubtitles.View = System.Windows.Forms.View.Details;
            this.lvSubtitles.GridLines = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBack,
            this.tsmiFwd,
            this.tsmiSep1,
            this.tsmiSearch,
            this.tsmiReload,
            this.tsmiSep2,
            this.tsmiCopy,
            this.tsmiCut,
            this.tsmiPaste,
            this.tsmiCopyPaste,
            this.tsmiRename,
            this.tsmiDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 242);
            // 
            // tsmiBack
            // 
            this.tsmiBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiBack.Image = global::SubtitleEditor.extension.Properties.Resources.Back16;
            this.tsmiBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiBack.Name = "tsmiBack";
            this.tsmiBack.Size = new System.Drawing.Size(152, 22);
            this.tsmiBack.Tag = "ToolActionBack";
            this.tsmiBack.Text = "TXT_BACK";
            this.tsmiBack.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiFwd
            // 
            this.tsmiFwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiFwd.Image = global::SubtitleEditor.extension.Properties.Resources.Forward16;
            this.tsmiFwd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiFwd.Name = "tsmiFwd";
            this.tsmiFwd.Size = new System.Drawing.Size(152, 22);
            this.tsmiFwd.Tag = "ToolActionFwd";
            this.tsmiFwd.Text = "TXT_FORWARD";
            this.tsmiFwd.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiSep1
            // 
            this.tsmiSep1.Name = "tsmiSep1";
            this.tsmiSep1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiSearch
            // 
            this.tsmiSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiSearch.Image = global::SubtitleEditor.extension.Properties.Resources.Search16;
            this.tsmiSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiSearch.Name = "tsmiSearch";
            this.tsmiSearch.Size = new System.Drawing.Size(152, 22);
            this.tsmiSearch.Tag = "ToolActionSearch";
            this.tsmiSearch.Text = "TXT_SEARCH";
            this.tsmiSearch.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiReload
            // 
            this.tsmiReload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiReload.Image = global::SubtitleEditor.extension.Properties.Resources.Reload16;
            this.tsmiReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiReload.Name = "tsmiReload";
            this.tsmiReload.Size = new System.Drawing.Size(152, 22);
            this.tsmiReload.Tag = "ToolActionReload";
            this.tsmiReload.Text = "TXT_REFRESH";
            this.tsmiReload.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiSep2
            // 
            this.tsmiSep2.Name = "tsmiSep2";
            this.tsmiSep2.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiCopy.Image = global::SubtitleEditor.extension.Properties.Resources.Copy16;
            this.tsmiCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(152, 22);
            this.tsmiCopy.Tag = "ToolActionCopy";
            this.tsmiCopy.Text = "TXT_COPY";
            this.tsmiCopy.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiCut
            // 
            this.tsmiCut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiCut.Image = global::SubtitleEditor.extension.Properties.Resources.Cut16;
            this.tsmiCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiCut.Name = "tsmiCut";
            this.tsmiCut.Size = new System.Drawing.Size(152, 22);
            this.tsmiCut.Tag = "ToolActionCut";
            this.tsmiCut.Text = "TXT_CUT";
            this.tsmiCut.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiPaste
            // 
            this.tsmiPaste.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiPaste.Image = global::SubtitleEditor.extension.Properties.Resources.Paste16;
            this.tsmiPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiPaste.Name = "tsmiPaste";
            this.tsmiPaste.Size = new System.Drawing.Size(152, 22);
            this.tsmiPaste.Tag = "ToolActionPaste";
            this.tsmiPaste.Text = "TXT_PASTE";
            this.tsmiPaste.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiCopyPaste
            // 
            this.tsmiCopyPaste.Name = "tsmiCopyPaste";
            this.tsmiCopyPaste.Size = new System.Drawing.Size(149, 6);
            this.tsmiCopyPaste.Tag = "";
            // 
            // tsmiRename
            // 
            this.tsmiRename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiRename.Image = global::SubtitleEditor.extension.Properties.Resources.Rename16;
            this.tsmiRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiRename.Name = "tsmiRename";
            this.tsmiRename.Size = new System.Drawing.Size(152, 22);
            this.tsmiRename.Tag = "ToolActionRename";
            this.tsmiRename.Text = "TXT_RENAME";
            this.tsmiRename.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiDelete.Image = global::SubtitleEditor.extension.Properties.Resources.Delete16;
            this.tsmiDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(152, 22);
            this.tsmiDelete.Tag = "ToolActionDelete";
            this.tsmiDelete.Text = "TXT_DELETE";
            this.tsmiDelete.Click += new System.EventHandler(this.OnToolAction);
            // 
            // AddonPanel
            // 
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.Name = "AddonPanel";
            this.Size = new System.Drawing.Size(1123, 613);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        [EventSink(EventNames.PerformTranslation)]
        public void OnPerformTranslation()
        {
            Translator.TranslateControl(this, DesignMode);
            Translator.TranslateToolStrip(toolStripMain, DesignMode);
            Translator.TranslateToolStrip(contextMenuStrip, DesignMode);
        }

        [EventSink(EventNames.ExecuteShortcut)]
        public void OnExecuteShortcut(OPMShortcutEventArgs args)
        {
            if (FindForm() != null && !args.Handled)
            {
                switch (args.cmd)
                {
                    case OPMShortcut.CmdGenericRename:
                        HandleAction(ToolAction.ToolActionRename);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdGenericNew:
                        HandleAction(ToolAction.ToolActionNew);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdGenericOpen:
                        HandleAction(ToolAction.ToolActionOpen);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdGenericSave:
                        HandleAction(ToolAction.ToolActionSave);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdGenericDelete:
                        HandleAction(ToolAction.ToolActionDelete);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdGenericRefresh:
                        HandleAction(ToolAction.ToolActionReload);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdGenericSearch:
                        HandleAction(ToolAction.ToolActionSearch);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdNavigateBack:
                        HandleAction(ToolAction.ToolActionBack);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdNavigateForward:
                        HandleAction(ToolAction.ToolActionFwd);
                        args.Handled = true;
                        break;
                }
            }
        }

        private void OnToolAction(object sender, EventArgs e)
        {
            HandleToolAction(sender as ToolStripItem);
        }

        private void HandleToolAction(ToolStripItem tsi)
        {
            if (tsi == null || string.IsNullOrEmpty(tsi.Tag as string))
                return;

            ToolAction action = (ToolAction)Enum.Parse(typeof(ToolAction),
                   tsi.Tag as string);

            HandleAction(action);
        }

        private bool IsToolActionEnabled(ToolAction action)
        {
            if (_operationInProgress)
                return false;

            for (int i = 0; i < contextMenuStrip.Items.Count; i++)
            {
                ToolStripItem btn = contextMenuStrip.Items[i] as ToolStripItem;

                if (btn == null ||
                    string.IsNullOrEmpty(btn.Tag as string))
                {
                    // Not an action button, continue.
                    continue;
                }

                if ((btn.Tag as string).ToLowerInvariant() == action.ToString().ToLowerInvariant())
                {
                    return btn.Enabled;
                }
            }

            for (int i = 0; i < toolStripMain.Items.Count; i++)
            {
                ToolStripItem btn = toolStripMain.Items[i] as ToolStripItem;

                if (btn == null ||
                    string.IsNullOrEmpty(btn.Tag as string))
                {
                    // Not an action button, continue.
                    continue;
                }

                if ((btn.Tag as string).ToLowerInvariant() == action.ToString().ToLowerInvariant())
                {
                    return btn.Enabled;
                }
            }

            return true;
        }

        private void OnUpdateUi(ToolStripItemCollection tsic)
        {
            if (tsic == null)
                return;

            tsmiCopyPaste.Visible = tssCopyPaste.Visible = false;

            for (int i = 0; i < tsic.Count; i++)
            {
                ToolStripItem btn = tsic[i] as ToolStripItem;

                if (btn == null)
                    continue;

                btn.Enabled = true;

                string tag = btn.Tag as string;
                if (string.IsNullOrEmpty(tag))
                {
                    continue;
                }

                ToolAction action = ToolAction.ToolActionNothing;
                try
                {
                    action = (ToolAction)Enum.Parse(typeof(ToolAction), tag);
                }
                catch
                {
                    action = ToolAction.ToolActionNothing;
                }

                if (action == ToolAction.ToolActionNothing)
                {
                    continue;
                }

                //List<string> selItems = GetSelectedVPaths();

                switch (action)
                {
                    case ToolAction.ToolActionNew:
                        BuildMenuText(btn, "TXT_NEW", string.Empty, OPMShortcut.CmdGenericNew);
                        break;

                    case ToolAction.ToolActionOpen:
                        BuildMenuText(btn, "TXT_OPEN", string.Empty, OPMShortcut.CmdGenericOpen);
                        break;

                    case ToolAction.ToolActionSave:
                        BuildMenuText(btn, "TXT_SAVE", string.Empty, OPMShortcut.CmdGenericSave);
                        // TODO FIX
                        //btn.Enabled = (_cat != null);
                        break;

                    case ToolAction.ToolActionSaveAs:
                        BuildMenuText(btn, "TXT_SAVE_AS", string.Empty, OPMShortcut.CmdOutOfRange);
                        // TODO FIX
                        //btn.Enabled = (_cat != null);
                        break;

                    case ToolAction.ToolActionBack:
                        // TODO FIX
                        //btn.Enabled = ExploreBackTarget != null;
                        //BuildMenuText(btn, "TXT_BACK", ExploreBackTarget, OPMShortcut.CmdNavigateBack);
                        break;

                    case ToolAction.ToolActionFwd:
                        // TODO FIX
                        //btn.Enabled = ExploreForwardTarget != null;
                        //BuildMenuText(btn, "TXT_FORWARD", ExploreForwardTarget, OPMShortcut.CmdNavigateForward);
                        break;

                    case ToolAction.ToolActionSearch:
                        BuildMenuText(btn, "TXT_SEARCH", string.Empty, OPMShortcut.CmdGenericSearch);
                        // TODO FIX
                        //btn.Enabled = (_cat != null);
                        break;

                    case ToolAction.ToolActionReload:
                        BuildMenuText(btn, "TXT_REFRESH", string.Empty, OPMShortcut.CmdGenericRefresh);
                        // TODO FIX
                        //btn.Enabled = (_curFolder != null);
                        break;

                    case ToolAction.ToolActionDelete:
                        BuildMenuText(btn, "TXT_DELETE", string.Empty, OPMShortcut.CmdGenericDelete);
                        // TODO FIX
                        //btn.Enabled = GetSelectedVPaths().Count > 0;
                        break;

                    case ToolAction.ToolActionCopy:
                    case ToolAction.ToolActionCut:
                        // TODO FIX
                        //
                        btn.Visible = false;
                        btn.Enabled = false;
                        break;

                    case ToolAction.ToolActionPaste:
                        // TODO FIX
                        //
                        btn.Visible = false;
                        btn.Enabled = false;
                        break;

                    case ToolAction.ToolActionRename:
                        BuildMenuText(btn, "TXT_RENAME", string.Empty, OPMShortcut.CmdGenericRename);
                        // TODO FIX
                        //
                        //btn.Enabled = GetSelectedVPaths().Count == 1;
                        break;
                }
            }
        }

        private void HandleAction(ToolAction action)
        {
            if (!IsToolActionEnabled(action))
                return;

            switch (action)
            {
                case ToolAction.ToolActionNew:
                    _sub = Subtitle.Empty;
                    lvSubtitles.Subtitle = _sub;
                    break;

                case ToolAction.ToolActionOpen:
                    {
                        OPMOpenFileDialog dlg = CommonDialogHelper.NewOPMOpenFileDialog();
                        dlg.Title = Translator.Translate("TXT_OPEN_SUBTITLE");
                        dlg.Filter = "Subtitle files (*.srt, *.sub)|*.srt;*.sub||";//Translator.Translate("TXT_CATALOG_FILTER");
                        dlg.InitialDirectory = AppSettings.SUB_LastOpenedFolder;

                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            _sub = new Subtitle(dlg.FileName);

                            AppSettings.SUB_LastOpenedFolder = Path.GetDirectoryName(dlg.FileName);

                            lvSubtitles.Subtitle = _sub;

                            List<string> items = new List<string>();
                            items.Add(dlg.FileName);

                            base.RaiseNavigationAction(NavActionType.ActionDoubleClickFile, items, _sub);

                            if (_sub.Elements != null && _sub.Elements.Count > 0)
                            {
                                lvSubtitles.Select();
                                lvSubtitles.Focus();
                                lvSubtitles.Items[0].Selected = true;
                                //base.RaiseNavigationAction(NavActionType.ActionReloadPreview, items, _sub.Elements[0]);
                            }
                        }
                    }
                    break;
                
                case ToolAction.ToolActionSave:
                    if (_sub.IsEmpty)
                    {
                        goto saveas;
                    }
                    else
                    {
                        _sub.Save();
                    }
                    break;

                case ToolAction.ToolActionSaveAs:
                saveas:
                    {
                        OPMSaveFileDialog dlg = CommonDialogHelper.NewOPMSaveFileDialog();
                        dlg.Title = Translator.Translate("TXT_SAVE_SUBTITLE");
                        dlg.Filter = "Subtitle files (*.srt, *.sub)|*.srt;*.sub||";//Translator.Translate("TXT_CATALOG_FILTER");
                        dlg.AddExtension = true;
                        dlg.DefaultExt = "srt";
                        dlg.InitialDirectory = AppSettings.SUB_LastOpenedFolder;

                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            _sub.SaveToFile(dlg.FileName);

                            AppSettings.SUB_LastOpenedFolder = Path.GetDirectoryName(dlg.FileName);
                        }
                    }
                    break;
                
                case ToolAction.ToolActionDelete:
                    break;
                
                case ToolAction.ToolActionBack:
                    break;
                
                case ToolAction.ToolActionFwd:
                    break;
                
                case ToolAction.ToolActionSearch:
                    break;
                
                case ToolAction.ToolActionRename:
                    break;
            }
        }

        private void BuildMenuText(ToolStripItem tsm, string tag, string param, OPMShortcut command)
        {
            tsm.ToolTipText =
                (tsm.Enabled && !string.IsNullOrEmpty(param)) ?
                Translator.Translate(tag) + ": " + param :
                Translator.Translate(tag);
            tsm.Text = Translator.Translate(tag);

            if (tsm is OPMToolStripMenuItem)
            {
                tsm.Text = tsm.ToolTipText;
                if (command != OPMShortcut.CmdOutOfRange)
                {
                    (tsm as OPMToolStripMenuItem).ShortcutKeyDisplayString =
                        ShortcutMapper.GetShortcutString(command);
                }
            }
            else
            {
                if (command != OPMShortcut.CmdOutOfRange)
                {
                    tsm.ToolTipText +=
                        string.Format(" ({0})", ShortcutMapper.GetShortcutString(command));
                }

                // TODO FIX
                //if (command == OPMShortcut.CmdGenericOpen && _recentFiles.Count > 0 && AppSettings.MCRememberRecentFiles)
                //{
//                    tsm.ToolTipText += "\r\n" + Translator.Translate("TXT_OPENRECENTFILEDROPDOWN");
  //              }
            }
        }
    }

    internal enum ToolAction : int
    {
        ToolActionNothing = -1,

        ToolActionNew = 0,
        ToolActionOpen,
        ToolActionSave,
        ToolActionSaveAs,

        ToolActionBack,
        ToolActionFwd,

        ToolActionSearch,
        ToolActionReload,

        ToolActionCopy,
        ToolActionCut,
        ToolActionPaste,

        ToolActionRename,
        ToolActionDelete,

    }
}
