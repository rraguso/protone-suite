using OPMedia.UI.Controls;

using System.Windows.Forms;
using OPMedia.Addons.Builtin.Properties;
using System.Drawing;

namespace OPMedia.Addons.Builtin.FileExplorer
{
    partial class AddonPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ilAddon = new System.Windows.Forms.ImageList(this.components);
            this.opmShellList = new OPMedia.UI.Controls.OPMShellListView();
            this.contextMenuStrip = new OPMedia.UI.Controls.OPMContextMenuStrip();
            this.tsmiNewFolder = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiSep0 = new OPMedia.UI.Controls.OPMMenuStripSeparator();
            this.tsmiBack = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiFwd = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiUp = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiSep1 = new OPMedia.UI.Controls.OPMMenuStripSeparator();
            this.tsmiFavorites = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiFavoritesAdd = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiFavoritesManage = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiSep5 = new OPMedia.UI.Controls.OPMMenuStripSeparator();
            this.toolStripSeparator13 = new OPMedia.UI.Controls.OPMMenuStripSeparator();
            this.tsmiSearch = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiReload = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiSep2 = new OPMedia.UI.Controls.OPMMenuStripSeparator();
            this.tsmiCopy = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiCut = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiPaste = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiSep3 = new OPMedia.UI.Controls.OPMMenuStripSeparator();
            this.tsmiRename = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiDelete = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiSep4 = new OPMedia.UI.Controls.OPMMenuStripSeparator();
            this.tsmiID3Wizard = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiSepProTONE = new OPMedia.UI.Controls.OPMMenuStripSeparator();
            this.tsmiProTONEPlay = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiProTONEEnqueue = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.toolStripMain = new OPMedia.UI.Controls.OPMToolStrip();
            this.tsbNewFolder = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbSep0 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsbBack = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbForward = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbUpLevel = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbSep1 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsbDrives = new OPMedia.UI.Controls.OPMToolStripDropDownButton();
            this.tsbFavorites = new OPMedia.UI.Controls.OPMToolStripDropDownButton();
            this.tsbFavoritesAdd = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsbFavoritesManage = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.toolStripSeparator6 = new OPMedia.UI.Controls.OPMMenuStripSeparator();
            this.tsbSep2 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsbSearch = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbReload = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbSep3 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsbCopy = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbCut = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbPaste = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbSep4 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsbRename = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbDelete = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbSep5 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsbID3Wizard = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbCdRipperWizard = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.tableLayoutPanel2 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlHeader = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.contextMenuStrip.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilAddon
            // 
            this.ilAddon.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilAddon.ImageSize = new System.Drawing.Size(64, 64);
            this.ilAddon.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // opmShellList
            // 
            this.opmShellList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.opmShellList.ContextMenuStrip = this.contextMenuStrip;
            this.opmShellList.Cursor = System.Windows.Forms.Cursors.Default;
            this.opmShellList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmShellList.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.opmShellList.LabelEdit = true;
            this.opmShellList.Location = new System.Drawing.Point(0, 0);
            this.opmShellList.Margin = new System.Windows.Forms.Padding(0);
            this.opmShellList.MultiSelect = false;
            this.opmShellList.Name = "opmShellList";
            this.opmShellList.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmShellList.Size = new System.Drawing.Size(1141, 322);
            this.opmShellList.TabIndex = 1;
            this.opmShellList.UseCompatibleStateImageBehavior = false;
            this.opmShellList.View = System.Windows.Forms.View.Details;
            this.opmShellList.DoubleClickDirectory += new OPMedia.UI.Controls.DoubleClickDirectoryEventHandler(this.OnDoubleClickDirectory);
            this.opmShellList.DoubleClickFile += new OPMedia.UI.Controls.DoubleClickFileEventHandler(this.OnDoubleClickFile);
            this.opmShellList.SelectDirectory += new OPMedia.UI.Controls.SelectDirectoryEventHandler(this.OnSelectDirectory);
            this.opmShellList.SelectFile += new OPMedia.UI.Controls.SelectFileEventHandler(this.OnSelectFile);
            this.opmShellList.SelectMultipleItems += new OPMedia.UI.Controls.SelectMultipleItemsEventHandler(this.OnSelectMultipleItems);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.contextMenuStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewFolder,
            this.tsmiSep0,
            this.tsmiBack,
            this.tsmiFwd,
            this.tsmiUp,
            this.tsmiSep1,
            this.tsmiFavorites,
            this.toolStripSeparator13,
            this.tsmiSearch,
            this.tsmiReload,
            this.tsmiSep2,
            this.tsmiCopy,
            this.tsmiCut,
            this.tsmiPaste,
            this.tsmiSep3,
            this.tsmiRename,
            this.tsmiDelete,
            this.tsmiSep4,
            this.tsmiID3Wizard,
            this.tsmiSepProTONE,
            this.tsmiProTONEPlay,
            this.tsmiProTONEEnqueue});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(212, 376);
            // 
            // tsmiNewFolder
            // 
            this.tsmiNewFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiNewFolder.Image = global::OPMedia.Addons.Builtin.Properties.Resources.New;
            this.tsmiNewFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiNewFolder.Name = "tsmiNewFolder";
            this.tsmiNewFolder.Size = new System.Drawing.Size(211, 22);
            this.tsmiNewFolder.Tag = "ToolActionNewFolder";
            this.tsmiNewFolder.Text = "TXT_NEWFOLDER";
            this.tsmiNewFolder.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiSep0
            // 
            this.tsmiSep0.Name = "tsmiSep0";
            this.tsmiSep0.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmiBack
            // 
            this.tsmiBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiBack.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Back16;
            this.tsmiBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiBack.Name = "tsmiBack";
            this.tsmiBack.Size = new System.Drawing.Size(211, 22);
            this.tsmiBack.Tag = "ToolActionBack";
            this.tsmiBack.Text = "TXT_BACK";
            this.tsmiBack.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiFwd
            // 
            this.tsmiFwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiFwd.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Forward16;
            this.tsmiFwd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiFwd.Name = "tsmiFwd";
            this.tsmiFwd.Size = new System.Drawing.Size(211, 22);
            this.tsmiFwd.Tag = "ToolActionFwd";
            this.tsmiFwd.Text = "TXT_FORWARD";
            this.tsmiFwd.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiUp
            // 
            this.tsmiUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiUp.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Up16;
            this.tsmiUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiUp.Name = "tsmiUp";
            this.tsmiUp.Size = new System.Drawing.Size(211, 22);
            this.tsmiUp.Tag = "ToolActionUp";
            this.tsmiUp.Text = "TXT_UP";
            this.tsmiUp.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiSep1
            // 
            this.tsmiSep1.Name = "tsmiSep1";
            this.tsmiSep1.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmiFavorites
            // 
            this.tsmiFavorites.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFavoritesAdd,
            this.tsmiFavoritesManage,
            this.tsmiSep5});
            this.tsmiFavorites.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiFavorites.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiFavorites.Name = "tsmiFavorites";
            this.tsmiFavorites.Size = new System.Drawing.Size(211, 22);
            this.tsmiFavorites.Tag = "ToolActionFavoriteFolders";
            this.tsmiFavorites.Text = "TXT_FAVORITES";
            this.tsmiFavorites.DropDownOpening += new System.EventHandler(this.OnBuildFavoritesMenu);
            // 
            // tsmiFavoritesAdd
            // 
            this.tsmiFavoritesAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiFavoritesAdd.Name = "tsmiFavoritesAdd";
            this.tsmiFavoritesAdd.Size = new System.Drawing.Size(214, 22);
            this.tsmiFavoritesAdd.Tag = "ToolActionFavoritesAdd";
            this.tsmiFavoritesAdd.Text = "TXT_FAVORITES_ADD";
            this.tsmiFavoritesAdd.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiFavoritesManage
            // 
            this.tsmiFavoritesManage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiFavoritesManage.Name = "tsmiFavoritesManage";
            this.tsmiFavoritesManage.Size = new System.Drawing.Size(214, 22);
            this.tsmiFavoritesManage.Tag = "ToolActionFavoritesManage";
            this.tsmiFavoritesManage.Text = "TXT_FAVORITES_MANAGE";
            this.tsmiFavoritesManage.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiSep5
            // 
            this.tsmiSep5.Name = "tsmiSep5";
            this.tsmiSep5.Size = new System.Drawing.Size(211, 6);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmiSearch
            // 
            this.tsmiSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiSearch.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Search16;
            this.tsmiSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiSearch.Name = "tsmiSearch";
            this.tsmiSearch.Size = new System.Drawing.Size(211, 22);
            this.tsmiSearch.Tag = "ToolActionSearch";
            this.tsmiSearch.Text = "TXT_SEARCH";
            this.tsmiSearch.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiReload
            // 
            this.tsmiReload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiReload.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Reload16;
            this.tsmiReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiReload.Name = "tsmiReload";
            this.tsmiReload.Size = new System.Drawing.Size(211, 22);
            this.tsmiReload.Tag = "ToolActionReload";
            this.tsmiReload.Text = "TXT_REFRESH";
            this.tsmiReload.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiSep2
            // 
            this.tsmiSep2.Name = "tsmiSep2";
            this.tsmiSep2.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiCopy.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Copy16;
            this.tsmiCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(211, 22);
            this.tsmiCopy.Tag = "ToolActionCopy";
            this.tsmiCopy.Text = "TXT_COPY";
            this.tsmiCopy.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiCut
            // 
            this.tsmiCut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiCut.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Cut16;
            this.tsmiCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiCut.Name = "tsmiCut";
            this.tsmiCut.Size = new System.Drawing.Size(211, 22);
            this.tsmiCut.Tag = "ToolActionCut";
            this.tsmiCut.Text = "TXT_CUT";
            this.tsmiCut.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiPaste
            // 
            this.tsmiPaste.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiPaste.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Paste16;
            this.tsmiPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiPaste.Name = "tsmiPaste";
            this.tsmiPaste.Size = new System.Drawing.Size(211, 22);
            this.tsmiPaste.Tag = "ToolActionPaste";
            this.tsmiPaste.Text = "TXT_PASTE";
            this.tsmiPaste.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiSep3
            // 
            this.tsmiSep3.Name = "tsmiSep3";
            this.tsmiSep3.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmiRename
            // 
            this.tsmiRename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiRename.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Rename16;
            this.tsmiRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiRename.Name = "tsmiRename";
            this.tsmiRename.Size = new System.Drawing.Size(211, 22);
            this.tsmiRename.Tag = "ToolActionRename";
            this.tsmiRename.Text = "TXT_RENAME";
            this.tsmiRename.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiDelete.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Delete16;
            this.tsmiDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(211, 22);
            this.tsmiDelete.Tag = "ToolActionDelete";
            this.tsmiDelete.Text = "TXT_DELETE";
            this.tsmiDelete.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiSep4
            // 
            this.tsmiSep4.Name = "tsmiSep4";
            this.tsmiSep4.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmiID3Wizard
            // 
            this.tsmiID3Wizard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiID3Wizard.Image = global::OPMedia.Addons.Builtin.Properties.Resources.ID316;
            this.tsmiID3Wizard.Name = "tsmiID3Wizard";
            this.tsmiID3Wizard.Size = new System.Drawing.Size(211, 22);
            this.tsmiID3Wizard.Tag = "ToolActionID3Wizard";
            this.tsmiID3Wizard.Text = "TXT_ID3WIZARD";
            this.tsmiID3Wizard.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiSepProTONE
            // 
            this.tsmiSepProTONE.Name = "tsmiSepProTONE";
            this.tsmiSepProTONE.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmiProTONEPlay
            // 
            this.tsmiProTONEPlay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiProTONEPlay.Image = global::OPMedia.Addons.Builtin.Properties.Resources.player16;
            this.tsmiProTONEPlay.Name = "tsmiProTONEPlay";
            this.tsmiProTONEPlay.Size = new System.Drawing.Size(211, 22);
            this.tsmiProTONEPlay.Tag = "ToolActionProTONEPlay";
            this.tsmiProTONEPlay.Text = "TXT_PROTONE_PLAY";
            this.tsmiProTONEPlay.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiProTONEEnqueue
            // 
            this.tsmiProTONEEnqueue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiProTONEEnqueue.Image = global::OPMedia.Addons.Builtin.Properties.Resources.player16;
            this.tsmiProTONEEnqueue.Name = "tsmiProTONEEnqueue";
            this.tsmiProTONEEnqueue.Size = new System.Drawing.Size(211, 22);
            this.tsmiProTONEEnqueue.Tag = "ToolActionProTONEEnqueue";
            this.tsmiProTONEEnqueue.Text = "TXT_PROTONE_ENQUEUE";
            this.tsmiProTONEEnqueue.Click += new System.EventHandler(this.OnToolAction);
            // 
            // toolStripMain
            // 
            this.toolStripMain.AllowMerge = false;
            this.toolStripMain.AutoSize = false;
            this.toolStripMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.toolStripMain.CanOverflow = false;
            this.toolStripMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripMain.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.toolStripMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.toolStripMain.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewFolder,
            this.tsbSep0,
            this.tsbBack,
            this.tsbForward,
            this.tsbUpLevel,
            this.tsbSep1,
            this.tsbDrives,
            this.tsbFavorites,
            this.tsbSep2,
            this.tsbSearch,
            this.tsbReload,
            this.tsbSep3,
            this.tsbCopy,
            this.tsbCut,
            this.tsbPaste,
            this.tsbSep4,
            this.tsbRename,
            this.tsbDelete,
            this.tsbSep5,
            this.tsbID3Wizard,
            this.tsbCdRipperWizard});
            this.toolStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Padding = new System.Windows.Forms.Padding(0);
            this.toolStripMain.ShowBorder = true;
            this.toolStripMain.Size = new System.Drawing.Size(1141, 46);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.VerticalGradient = true;
            // 
            // tsbNewFolder
            // 
            this.tsbNewFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsbNewFolder.Image = global::OPMedia.Addons.Builtin.Properties.Resources.New;
            this.tsbNewFolder.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbNewFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNewFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewFolder.Name = "tsbNewFolder";
            this.tsbNewFolder.Size = new System.Drawing.Size(98, 43);
            this.tsbNewFolder.Tag = "ToolActionNewFolder";
            this.tsbNewFolder.Text = "TXT_NEWFOLDER";
            this.tsbNewFolder.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbNewFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNewFolder.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbSep0
            // 
            this.tsbSep0.Name = "tsbSep0";
            this.tsbSep0.Size = new System.Drawing.Size(6, 46);
            // 
            // tsbBack
            // 
            this.tsbBack.Enabled = false;
            this.tsbBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsbBack.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Back;
            this.tsbBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbBack.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBack.Name = "tsbBack";
            this.tsbBack.Size = new System.Drawing.Size(59, 43);
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
            this.tsbForward.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsbForward.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Forward;
            this.tsbForward.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbForward.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbForward.Name = "tsbForward";
            this.tsbForward.Size = new System.Drawing.Size(87, 43);
            this.tsbForward.Tag = "ToolActionFwd";
            this.tsbForward.Text = "TXT_FORWARD";
            this.tsbForward.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbForward.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbForward.ToolTipText = "Forward to";
            this.tsbForward.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbUpLevel
            // 
            this.tsbUpLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsbUpLevel.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Up;
            this.tsbUpLevel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbUpLevel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbUpLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpLevel.Name = "tsbUpLevel";
            this.tsbUpLevel.Size = new System.Drawing.Size(46, 43);
            this.tsbUpLevel.Tag = "ToolActionUp";
            this.tsbUpLevel.Text = "TXT_UP";
            this.tsbUpLevel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbUpLevel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbUpLevel.ToolTipText = "Up to";
            this.tsbUpLevel.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbSep1
            // 
            this.tsbSep1.Name = "tsbSep1";
            this.tsbSep1.Size = new System.Drawing.Size(6, 46);
            // 
            // tsbDrives
            // 
            this.tsbDrives.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsbDrives.Image = global::OPMedia.Addons.Builtin.Properties.Resources.DiskDrive;
            this.tsbDrives.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDrives.ImageScalingSize = new System.Drawing.Size(16, 16);
            this.tsbDrives.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDrives.Name = "tsbDrives";
            this.tsbDrives.Size = new System.Drawing.Size(78, 43);
            this.tsbDrives.Tag = "ToolActionListDrives";
            this.tsbDrives.Text = "TXT_DRIVES";
            this.tsbDrives.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDrives.ToolTipText = "Change logical drive";
            this.tsbDrives.DropDownOpening += new System.EventHandler(this.OnBuildDriveButtonMenu);
            this.tsbDrives.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnDriveChosen);
            // 
            // tsbFavorites
            // 
            this.tsbFavorites.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFavoritesAdd,
            this.tsbFavoritesManage,
            this.toolStripSeparator6});
            this.tsbFavorites.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsbFavorites.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbFavorites.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFavorites.ImageScalingSize = new System.Drawing.Size(16, 16);
            this.tsbFavorites.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFavorites.Name = "tsbFavorites";
            this.tsbFavorites.Size = new System.Drawing.Size(97, 43);
            this.tsbFavorites.Tag = "ToolActionFavoriteFolders";
            this.tsbFavorites.Text = "TXT_FAVORITES";
            this.tsbFavorites.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbFavorites.ToolTipText = "Favorite Folders";
            this.tsbFavorites.DropDownOpening += new System.EventHandler(this.OnBuildFavoritesMenu);
            // 
            // tsbFavoritesAdd
            // 
            this.tsbFavoritesAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsbFavoritesAdd.Name = "tsbFavoritesAdd";
            this.tsbFavoritesAdd.Size = new System.Drawing.Size(202, 22);
            this.tsbFavoritesAdd.Tag = "ToolActionFavoritesAdd";
            this.tsbFavoritesAdd.Text = "TXT_FAVORITES_ADD";
            this.tsbFavoritesAdd.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbFavoritesManage
            // 
            this.tsbFavoritesManage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsbFavoritesManage.Name = "tsbFavoritesManage";
            this.tsbFavoritesManage.Size = new System.Drawing.Size(202, 22);
            this.tsbFavoritesManage.Tag = "ToolActionFavoritesManage";
            this.tsbFavoritesManage.Text = "TXT_FAVORITES_MANAGE";
            this.tsbFavoritesManage.Click += new System.EventHandler(this.OnToolAction);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(199, 6);
            // 
            // tsbSep2
            // 
            this.tsbSep2.Name = "tsbSep2";
            this.tsbSep2.Size = new System.Drawing.Size(6, 46);
            // 
            // tsbSearch
            // 
            this.tsbSearch.Enabled = false;
            this.tsbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsbSearch.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Search;
            this.tsbSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(73, 43);
            this.tsbSearch.Tag = "ToolActionSearch";
            this.tsbSearch.Text = "TXT_SEARCH";
            this.tsbSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSearch.ToolTipText = "Search files or folders ...";
            this.tsbSearch.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbReload
            // 
            this.tsbReload.Enabled = false;
            this.tsbReload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsbReload.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Reload;
            this.tsbReload.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbReload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReload.Name = "tsbReload";
            this.tsbReload.Size = new System.Drawing.Size(78, 43);
            this.tsbReload.Tag = "ToolActionReload";
            this.tsbReload.Text = "TXT_REFRESH";
            this.tsbReload.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbReload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbReload.ToolTipText = "Refresh file list";
            this.tsbReload.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbSep3
            // 
            this.tsbSep3.Name = "tsbSep3";
            this.tsbSep3.Size = new System.Drawing.Size(6, 46);
            // 
            // tsbCopy
            // 
            this.tsbCopy.Enabled = false;
            this.tsbCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsbCopy.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Copy;
            this.tsbCopy.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(59, 43);
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
            this.tsbCut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsbCut.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Cut;
            this.tsbCut.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCut.Name = "tsbCut";
            this.tsbCut.Size = new System.Drawing.Size(52, 43);
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
            this.tsbPaste.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsbPaste.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Paste;
            this.tsbPaste.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.Size = new System.Drawing.Size(62, 43);
            this.tsbPaste.Tag = "ToolActionPaste";
            this.tsbPaste.Text = "TXT_PASTE";
            this.tsbPaste.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbPaste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPaste.ToolTipText = "Paste selection";
            this.tsbPaste.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbSep4
            // 
            this.tsbSep4.Name = "tsbSep4";
            this.tsbSep4.Size = new System.Drawing.Size(6, 46);
            // 
            // tsbRename
            // 
            this.tsbRename.Enabled = false;
            this.tsbRename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsbRename.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Rename;
            this.tsbRename.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbRename.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRename.Name = "tsbRename";
            this.tsbRename.Size = new System.Drawing.Size(76, 43);
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
            this.tsbDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsbDelete.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Delete;
            this.tsbDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(68, 43);
            this.tsbDelete.Tag = "ToolActionDelete";
            this.tsbDelete.Text = "TXT_DELETE";
            this.tsbDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDelete.ToolTipText = "Delete ";
            this.tsbDelete.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbSep5
            // 
            this.tsbSep5.Name = "tsbSep5";
            this.tsbSep5.Size = new System.Drawing.Size(6, 46);
            // 
            // tsbID3Wizard
            // 
            this.tsbID3Wizard.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbID3Wizard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsbID3Wizard.Image = global::OPMedia.Addons.Builtin.Properties.Resources.ID3;
            this.tsbID3Wizard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbID3Wizard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbID3Wizard.Name = "tsbID3Wizard";
            this.tsbID3Wizard.Size = new System.Drawing.Size(91, 43);
            this.tsbID3Wizard.Tag = "ToolActionID3Wizard";
            this.tsbID3Wizard.Text = "TXT_ID3WIZARD";
            this.tsbID3Wizard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbID3Wizard.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbCdRipperWizard
            // 
            this.tsbCdRipperWizard.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbCdRipperWizard.Image = global::OPMedia.Addons.Builtin.Properties.Resources.blank_cd;
            this.tsbCdRipperWizard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbCdRipperWizard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCdRipperWizard.Name = "tsbCdRipperWizard";
            this.tsbCdRipperWizard.Size = new System.Drawing.Size(149, 43);
            this.tsbCdRipperWizard.Tag = "ToolActionCdRipper";
            this.tsbCdRipperWizard.Text = "TXT_CDRIPPERWIZARD";
            this.tsbCdRipperWizard.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStripMain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1141, 368);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.opmShellList, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pnlHeader, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 46);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1141, 322);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlHeader.Size = new System.Drawing.Size(1141, 1);
            this.pnlHeader.TabIndex = 2;
            // 
            // AddonPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AddonPanel";
            this.Size = new System.Drawing.Size(1141, 368);
            this.HandleCreated += new System.EventHandler(this.OnLoad);
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList ilAddon;
        private OPMToolStrip toolStripMain;
        private OPMShellListView opmShellList;
        private OPMToolStripButton tsbBack;
        private OPMToolStripButton tsbForward;
        private OPMToolStripButton tsbUpLevel;
        private OPMToolStripSeparator tsbSep2;
        private OPMToolStripButton tsbReload;
        private OPMToolStripSeparator tsbSep3;
        private OPMToolStripButton tsbCopy;
        private OPMToolStripButton tsbCut;
        private OPMToolStripButton tsbPaste;
        private OPMToolStripSeparator tsbSep4;
        private OPMToolStripButton tsbRename;
        private OPMToolStripButton tsbDelete;
        private OPMToolStripSeparator tsbSep5;
        private OPMToolStripButton tsbSearch;
        private OPMToolStripDropDownButton tsbFavorites;
        private OPMToolStripMenuItem tsbFavoritesAdd;
        private OPMToolStripMenuItem tsbFavoritesManage;
        private OPMMenuStripSeparator toolStripSeparator6;
        private OPMToolStripSeparator tsbSep1;
        private OPMContextMenuStrip contextMenuStrip;
        private OPMToolStripMenuItem tsmiBack;
        private OPMToolStripMenuItem tsmiFwd;
        private OPMToolStripMenuItem tsmiUp;
        private OPMMenuStripSeparator toolStripSeparator13;
        private OPMToolStripMenuItem tsmiSearch;
        private OPMToolStripMenuItem tsmiReload;
        private OPMMenuStripSeparator tsmiSep2;
        private OPMToolStripMenuItem tsmiCopy;
        private OPMToolStripMenuItem tsmiCut;
        private OPMToolStripMenuItem tsmiPaste;
        private OPMMenuStripSeparator tsmiSep3;
        private OPMToolStripMenuItem tsmiRename;
        private OPMToolStripMenuItem tsmiDelete;
        private OPMMenuStripSeparator tsmiSep4;
        private OPMMenuStripSeparator tsmiSep1;
        private OPMToolStripMenuItem tsmiFavorites;
        private OPMMenuStripSeparator tsmiSep5;
        private OPMToolStripDropDownButton tsbDrives;
        private OPMToolStripMenuItem tsmiID3Wizard;
        private OPMToolStripButton tsbID3Wizard;
        private OPMToolStripMenuItem tsmiFavoritesAdd;
        private OPMToolStripMenuItem tsmiFavoritesManage;
        private OPMMenuStripSeparator tsmiSepProTONE;
        private OPMToolStripMenuItem tsmiProTONEPlay;
        private OPMToolStripMenuItem tsmiProTONEEnqueue;
        private OPMTableLayoutPanel tableLayoutPanel1;
        private OPMTableLayoutPanel tableLayoutPanel2;
        private OPMFlowLayoutPanel pnlHeader;
        private OPMToolStripButton tsbCdRipperWizard;
        private OPMToolStripButton tsbNewFolder;
        private OPMToolStripSeparator tsbSep0;
        private OPMToolStripMenuItem tsmiNewFolder;
        private OPMMenuStripSeparator tsmiSep0;
       
        
    }
}
