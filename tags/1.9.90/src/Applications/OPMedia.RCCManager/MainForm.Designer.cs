using System.Windows.Forms;
using OPMedia.UI.Controls;

namespace OPMedia.RCCManager
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrUpdateUi = new System.Windows.Forms.Timer(this.components);
            this.ttMain = new OPMedia.UI.Controls.OPMToolTip(this.components);
            this.btnApplyConfig = new OPMedia.UI.Controls.OPMButton();
            this.btnModifyRemote = new OPMedia.UI.Controls.OPMButton();
            this.btnDeleteRemote = new OPMedia.UI.Controls.OPMButton();
            this.btnAddRemote = new OPMedia.UI.Controls.OPMButton();
            this.cmsTree = new OPMContextMenuStrip();
            this.tsmiChange = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiDelete = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.toolStripSeparator1 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmiEnable = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.msMain = new OPMedia.UI.Controls.OPMMenuStrip();
            this.fileToolStripMenuItem = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiImport = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiImportMerge = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiImportReplace = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiExport = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiExportPartial = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiExportFull = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.toolStripSeparator2 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmiExit = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.txtEditToolStripMenuItem = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiAdd = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiMainChange = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiMainDelete = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.toolStripSeparator3 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmiMainEnable = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.txtHelpToolStripMenuItem = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.txtAppHelpToolStripMenuItem = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiAbout = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.toolStripSeparator4 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.txtShowLogToolStripMenuItem = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.opmLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.tvRemotes = new OPMedia.UI.Controls.OPMTreeView();
            this.pnlContent.SuspendLayout();
            this.cmsTree.SuspendLayout();
            this.msMain.SuspendLayout();
            this.opmLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.opmLayoutPanel1);
            this.pnlContent.Controls.Add(this.msMain);
            // 
            // tmrUpdateUi
            // 
            this.tmrUpdateUi.Enabled = true;
            this.tmrUpdateUi.Interval = 3000;
            this.tmrUpdateUi.Tick += new System.EventHandler(this.tmrUpdateUi_Tick);
            // 
            // ttMain
            // 
            this.ttMain.OwnerDraw = true;
            // 
            // btnApplyConfig
            // 
            this.btnApplyConfig.AccessibleName = "btnApplyConfig";
            this.btnApplyConfig.AutoSize = true;
            this.btnApplyConfig.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApplyConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnApplyConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApplyConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyConfig.Location = new System.Drawing.Point(65, 6);
            this.btnApplyConfig.Margin = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.btnApplyConfig.MaximumSize = new System.Drawing.Size(32, 32);
            this.btnApplyConfig.MinimumSize = new System.Drawing.Size(20, 20);
            this.btnApplyConfig.Name = "btnApplyConfig";
            this.btnApplyConfig.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnApplyConfig.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnApplyConfig.Size = new System.Drawing.Size(20, 20);
            this.btnApplyConfig.TabIndex = 6;
            this.btnApplyConfig.Click += new System.EventHandler(this.btnApplyConfig_Click);
            // 
            // btnModifyRemote
            // 
            this.btnModifyRemote.AccessibleName = "btnModifyRemote";
            this.btnModifyRemote.AutoSize = true;
            this.btnModifyRemote.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnModifyRemote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnModifyRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnModifyRemote.Enabled = false;
            this.btnModifyRemote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifyRemote.Location = new System.Drawing.Point(20, 6);
            this.btnModifyRemote.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnModifyRemote.MaximumSize = new System.Drawing.Size(32, 32);
            this.btnModifyRemote.MinimumSize = new System.Drawing.Size(20, 20);
            this.btnModifyRemote.Name = "btnModifyRemote";
            this.btnModifyRemote.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnModifyRemote.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnModifyRemote.Size = new System.Drawing.Size(20, 20);
            this.btnModifyRemote.TabIndex = 4;
            this.btnModifyRemote.Click += new System.EventHandler(this.btnModifyRemote_Click);
            // 
            // btnDeleteRemote
            // 
            this.btnDeleteRemote.AccessibleName = "btnDeleteRemote";
            this.btnDeleteRemote.AutoSize = true;
            this.btnDeleteRemote.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteRemote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeleteRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteRemote.Enabled = false;
            this.btnDeleteRemote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRemote.Location = new System.Drawing.Point(40, 6);
            this.btnDeleteRemote.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnDeleteRemote.MaximumSize = new System.Drawing.Size(32, 32);
            this.btnDeleteRemote.MinimumSize = new System.Drawing.Size(20, 20);
            this.btnDeleteRemote.Name = "btnDeleteRemote";
            this.btnDeleteRemote.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnDeleteRemote.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnDeleteRemote.Size = new System.Drawing.Size(20, 20);
            this.btnDeleteRemote.TabIndex = 5;
            this.btnDeleteRemote.Click += new System.EventHandler(this.btnDeleteRemote_Click);
            // 
            // btnAddRemote
            // 
            this.btnAddRemote.AccessibleName = "btnAddRemote";
            this.btnAddRemote.AutoSize = true;
            this.btnAddRemote.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddRemote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddRemote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRemote.Location = new System.Drawing.Point(0, 6);
            this.btnAddRemote.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnAddRemote.MaximumSize = new System.Drawing.Size(32, 32);
            this.btnAddRemote.MinimumSize = new System.Drawing.Size(20, 20);
            this.btnAddRemote.Name = "btnAddRemote";
            this.btnAddRemote.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnAddRemote.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnAddRemote.Size = new System.Drawing.Size(20, 20);
            this.btnAddRemote.TabIndex = 3;
            this.btnAddRemote.Click += new System.EventHandler(this.btnAddRemote_Click);
            // 
            // cmsTree
            // 
            this.cmsTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChange,
            this.tsmiDelete,
            this.toolStripSeparator1,
            this.tsmiEnable});
            this.cmsTree.Name = "cmsTree";
            this.cmsTree.Size = new System.Drawing.Size(142, 76);
            this.cmsTree.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTree_Opening);
            // 
            // tsmiChange
            // 
            this.tsmiChange.Image = global::OPMedia.RCCManager.Properties.Resources.Modify;
            this.tsmiChange.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmiChange.Name = "tsmiChange";
            this.tsmiChange.Size = new System.Drawing.Size(141, 22);
            this.tsmiChange.Text = "TXT_CHANGE";
            this.tsmiChange.Click += new System.EventHandler(this.OnMenuChange);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Image = global::OPMedia.RCCManager.Properties.Resources.Delete;
            this.tsmiDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(141, 22);
            this.tsmiDelete.Text = "TXT_DELETE";
            this.tsmiDelete.Click += new System.EventHandler(this.OnMenuDelete);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // tsmiEnable
            // 
            this.tsmiEnable.Name = "tsmiEnable";
            this.tsmiEnable.Size = new System.Drawing.Size(141, 22);
            this.tsmiEnable.Text = "TXT_ENABLE";
            this.tsmiEnable.Click += new System.EventHandler(this.OnMenuEnable);
            // 
            // label1
            // 
            this.label1.AccessibleName = "label1";
            this.label1.AutoSize = true;
            this.opmLayoutPanel1.SetColumnSpan(this.label1, 5);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(0, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 5, 3, 0);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(487, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TXT_REMOTELIST";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // msMain
            // 
            this.msMain.AutoSize = false;
            this.msMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(216)))), ((int)(((byte)(235)))));
            this.msMain.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.msMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.txtEditToolStripMenuItem,
            this.txtHelpToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(490, 21);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiImport,
            this.tsmiExport,
            this.toolStripSeparator2,
            this.tsmiExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(60, 17);
            this.fileToolStripMenuItem.Text = "TXT_FILE";
            // 
            // tsmiImport
            // 
            this.tsmiImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiImportMerge,
            this.tsmiImportReplace});
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.Size = new System.Drawing.Size(156, 22);
            this.tsmiImport.Text = "TXT_IMPORT";
            // 
            // tsmiImportMerge
            // 
            this.tsmiImportMerge.Name = "tsmiImportMerge";
            this.tsmiImportMerge.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.tsmiImportMerge.Size = new System.Drawing.Size(254, 22);
            this.tsmiImportMerge.Text = "TXT_IMPORT_PARTIAL";
            this.tsmiImportMerge.Click += new System.EventHandler(this.tsmiImportMerge_Click);
            // 
            // tsmiImportReplace
            // 
            this.tsmiImportReplace.Name = "tsmiImportReplace";
            this.tsmiImportReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmiImportReplace.Size = new System.Drawing.Size(254, 22);
            this.tsmiImportReplace.Text = "TXT_IMPORT_FULL";
            this.tsmiImportReplace.Click += new System.EventHandler(this.tsmiImportReplace_Click);
            // 
            // tsmiExport
            // 
            this.tsmiExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExportPartial,
            this.tsmiExportFull});
            this.tsmiExport.Name = "tsmiExport";
            this.tsmiExport.Size = new System.Drawing.Size(156, 22);
            this.tsmiExport.Text = "TXT_EXPORT";
            // 
            // tsmiExportPartial
            // 
            this.tsmiExportPartial.Name = "tsmiExportPartial";
            this.tsmiExportPartial.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.tsmiExportPartial.Size = new System.Drawing.Size(250, 22);
            this.tsmiExportPartial.Text = "TXT_EXPORT_PARTIAL";
            this.tsmiExportPartial.Click += new System.EventHandler(this.tsmiExportPartial_Click);
            // 
            // tsmiExportFull
            // 
            this.tsmiExportFull.Name = "tsmiExportFull";
            this.tsmiExportFull.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiExportFull.Size = new System.Drawing.Size(250, 22);
            this.tsmiExportFull.Text = "TXT_EXPORT_FULL";
            this.tsmiExportFull.Click += new System.EventHandler(this.tsmiExportFull_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.ShortcutKeyDisplayString = "Alt+F4";
            this.tsmiExit.Size = new System.Drawing.Size(156, 22);
            this.tsmiExit.Text = "TXT_EXIT";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // txtEditToolStripMenuItem
            // 
            this.txtEditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd,
            this.tsmiMainChange,
            this.tsmiMainDelete,
            this.toolStripSeparator3,
            this.tsmiMainEnable});
            this.txtEditToolStripMenuItem.Name = "txtEditToolStripMenuItem";
            this.txtEditToolStripMenuItem.Size = new System.Drawing.Size(62, 17);
            this.txtEditToolStripMenuItem.Text = "TXT_EDIT";
            this.txtEditToolStripMenuItem.DropDownOpening += new System.EventHandler(this.msEdit_DropDownOpening);
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Image = global::OPMedia.RCCManager.Properties.Resources.Add;
            this.tsmiAdd.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.tsmiAdd.Size = new System.Drawing.Size(199, 22);
            this.tsmiAdd.Text = "TXT_ADD";
            this.tsmiAdd.Click += new System.EventHandler(this.OnMenuAdd);
            // 
            // tsmiMainChange
            // 
            this.tsmiMainChange.Image = global::OPMedia.RCCManager.Properties.Resources.Modify;
            this.tsmiMainChange.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmiMainChange.Name = "tsmiMainChange";
            this.tsmiMainChange.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Return)));
            this.tsmiMainChange.Size = new System.Drawing.Size(199, 22);
            this.tsmiMainChange.Text = "TXT_CHANGE";
            this.tsmiMainChange.Click += new System.EventHandler(this.OnMenuChange);
            // 
            // tsmiMainDelete
            // 
            this.tsmiMainDelete.Image = global::OPMedia.RCCManager.Properties.Resources.Delete;
            this.tsmiMainDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmiMainDelete.Name = "tsmiMainDelete";
            this.tsmiMainDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmiMainDelete.Size = new System.Drawing.Size(199, 22);
            this.tsmiMainDelete.Text = "TXT_DELETE";
            this.tsmiMainDelete.Click += new System.EventHandler(this.OnMenuDelete);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(196, 6);
            // 
            // tsmiMainEnable
            // 
            this.tsmiMainEnable.Name = "tsmiMainEnable";
            this.tsmiMainEnable.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.tsmiMainEnable.Size = new System.Drawing.Size(199, 22);
            this.tsmiMainEnable.Text = "TXT_ENABLE";
            this.tsmiMainEnable.Click += new System.EventHandler(this.OnMenuEnable);
            // 
            // txtHelpToolStripMenuItem
            // 
            this.txtHelpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtHelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtAppHelpToolStripMenuItem,
            this.tsmiAbout,
            this.toolStripSeparator4,
            this.txtShowLogToolStripMenuItem});
            this.txtHelpToolStripMenuItem.Name = "txtHelpToolStripMenuItem";
            this.txtHelpToolStripMenuItem.Size = new System.Drawing.Size(65, 17);
            this.txtHelpToolStripMenuItem.Text = "TXT_HELP";
            // 
            // txtAppHelpToolStripMenuItem
            // 
            this.txtAppHelpToolStripMenuItem.Name = "txtAppHelpToolStripMenuItem";
            this.txtAppHelpToolStripMenuItem.ShortcutKeyDisplayString = "F1";
            this.txtAppHelpToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.txtAppHelpToolStripMenuItem.Text = "TXT_APPHELP";
            this.txtAppHelpToolStripMenuItem.Click += new System.EventHandler(this.tXTAPPHELPToolStripMenuItem_Click);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.AutoToolTip = true;
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.ShortcutKeyDisplayString = "";
            this.tsmiAbout.Size = new System.Drawing.Size(176, 22);
            this.tsmiAbout.Text = "TXT_ABOUT";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(173, 6);
            // 
            // txtShowLogToolStripMenuItem
            // 
            this.txtShowLogToolStripMenuItem.Name = "txtShowLogToolStripMenuItem";
            this.txtShowLogToolStripMenuItem.ShortcutKeyDisplayString = "F12";
            this.txtShowLogToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.txtShowLogToolStripMenuItem.Text = "TXT_SHOWLOG";
            this.txtShowLogToolStripMenuItem.Click += new System.EventHandler(this.tXTSHOWLOGToolStripMenuItem_Click);
            // 
            // opmLayoutPanel1
            // 
            this.opmLayoutPanel1.ColumnCount = 5;
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.opmLayoutPanel1.Controls.Add(this.btnAddRemote, 0, 0);
            this.opmLayoutPanel1.Controls.Add(this.btnModifyRemote, 1, 0);
            this.opmLayoutPanel1.Controls.Add(this.btnDeleteRemote, 2, 0);
            this.opmLayoutPanel1.Controls.Add(this.btnApplyConfig, 3, 0);
            this.opmLayoutPanel1.Controls.Add(this.tvRemotes, 0, 2);
            this.opmLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLayoutPanel1.Location = new System.Drawing.Point(0, 21);
            this.opmLayoutPanel1.Name = "opmLayoutPanel1";
            this.opmLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.opmLayoutPanel1.RowCount = 3;
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmLayoutPanel1.Size = new System.Drawing.Size(490, 331);
            this.opmLayoutPanel1.TabIndex = 7;
            // 
            // tvRemotes
            // 
            this.tvRemotes.AccessibleName = "tvRemotes";
            this.opmLayoutPanel1.SetColumnSpan(this.tvRemotes, 5);
            this.tvRemotes.ContextMenuStrip = this.cmsTree;
            this.tvRemotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRemotes.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvRemotes.FullRowSelect = true;
            this.tvRemotes.HideSelection = false;
            this.tvRemotes.ItemHeight = 20;
            this.tvRemotes.Location = new System.Drawing.Point(0, 44);
            this.tvRemotes.Margin = new System.Windows.Forms.Padding(0);
            this.tvRemotes.Name = "tvRemotes";
            this.tvRemotes.ShowNodeToolTips = true;
            this.tvRemotes.Size = new System.Drawing.Size(490, 287);
            this.tvRemotes.TabIndex = 2;
            this.tvRemotes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRemotes_AfterSelect);
            this.tvRemotes.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvRemotes_MouseClick);
            this.tvRemotes.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvRemotes_NodeMouseDoubleClick);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 380);
            this.MainMenuStrip = this.msMain;
            this.MinimumSize = new System.Drawing.Size(500, 380);
            this.Name = "MainForm";
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.pnlContent.ResumeLayout(false);
            this.cmsTree.ResumeLayout(false);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.opmLayoutPanel1.ResumeLayout(false);
            this.opmLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrUpdateUi;
        private OPMToolTip ttMain;
        private OPMButton btnApplyConfig;
        private OPMButton btnModifyRemote;
        private OPMButton btnDeleteRemote;
        private OPMButton btnAddRemote;
        private OPMLabel label1;
        private OPMContextMenuStrip cmsTree;
        private OPMToolStripMenuItem tsmiChange;
        private OPMToolStripMenuItem tsmiDelete;
        private OPMToolStripSeparator toolStripSeparator1;
        private OPMToolStripMenuItem tsmiEnable;
        private OPMMenuStrip msMain;
        private OPMToolStripMenuItem fileToolStripMenuItem;
        private OPMToolStripSeparator toolStripSeparator2;
        private OPMToolStripMenuItem tsmiExit;
        private OPMToolStripMenuItem tsmiImport;
        private OPMToolStripMenuItem tsmiExport;
        private OPMToolStripMenuItem tsmiImportMerge;
        private OPMToolStripMenuItem tsmiImportReplace;
        private OPMToolStripMenuItem tsmiExportPartial;
        private OPMToolStripMenuItem tsmiExportFull;
        private OPMToolStripMenuItem tsmiAdd;
        private OPMToolStripMenuItem tsmiMainChange;
        private OPMToolStripMenuItem tsmiMainDelete;
        private OPMToolStripSeparator toolStripSeparator3;
        private OPMToolStripMenuItem tsmiMainEnable;
        private OPMToolStripMenuItem tsmiAbout;
        private OPMToolStripSeparator toolStripSeparator4;
        private OPMToolStripMenuItem txtEditToolStripMenuItem;
        private OPMToolStripMenuItem txtHelpToolStripMenuItem;
        private OPMToolStripMenuItem txtAppHelpToolStripMenuItem;
        private OPMToolStripMenuItem txtShowLogToolStripMenuItem;
        private OPMTableLayoutPanel opmLayoutPanel1;
        private OPMTreeView tvRemotes;
    }
}