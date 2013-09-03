using OPMedia.UI.Controls;
using System.Windows.Forms;
using OPMedia.Addons.Builtin.Properties;

namespace OPMedia.Addons.Builtin.FileExplorer.SearchWizard.Controls
{
    partial class WizFESearchStep1Ctl
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
            this.cmbSearchText = new OPMedia.UI.Controls.OPMEditableComboBox();
            this.cmbSearchPattern = new OPMedia.UI.Controls.OPMEditableComboBox();
            this.label3 = new OPMedia.UI.Controls.OPMLabel();
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.chkNoCase = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkRecursive = new OPMedia.UI.Controls.OPMCheckBox();
            this.lbAttributes = new System.Windows.Forms.CheckedListBox();
            this.chkAttrSearch = new OPMedia.UI.Controls.OPMCheckBox();
            this.txtSearchPath = new OPMedia.UI.Controls.OPMTextBox();
            this.label2 = new OPMedia.UI.Controls.OPMLabel();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.btnSearch = new OPMedia.UI.Controls.StatusStripButton();
            this.ssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lvResults = new OPMedia.UI.Controls.OPMListView();
            this.colImage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new OPMedia.UI.Controls.OPMContextMenuStrip();
            this.tsmiDelete = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.toolStripSeparator1 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmiID3Wizard = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiSep4 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmiProTONEPlay = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiProTONEEnqueue = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiSepProTONE = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.goToItemToolStripMenuItem = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.chkPropSearch = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkOption1 = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkOption2 = new OPMedia.UI.Controls.OPMCheckBox();
            this.flowLayoutPanel1 = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.flowLayoutPanel2 = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.tableLayoutPanel2 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlLayoutSec = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.kryptonLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.pnlPatternOptions = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.pnlSearchOptions = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.btnBrowse = new OPMedia.UI.Controls.OPMButton();
            this.statusBar.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlLayoutSec.SuspendLayout();
            this.pnlPatternOptions.SuspendLayout();
            this.pnlSearchOptions.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbSearchText
            // 
            this.cmbSearchText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSearchText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSearchText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSearchText.DropDownWidth = 367;
            this.cmbSearchText.FormattingEnabled = true;
            this.cmbSearchText.Location = new System.Drawing.Point(325, 56);
            this.cmbSearchText.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cmbSearchText.Name = "cmbSearchText";
            this.cmbSearchText.Size = new System.Drawing.Size(318, 21);
            this.cmbSearchText.TabIndex = 7;
            this.cmbSearchText.TextChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // cmbSearchPattern
            // 
            this.cmbSearchPattern.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSearchPattern.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSearchPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSearchPattern.DropDownWidth = 279;
            this.cmbSearchPattern.FormattingEnabled = true;
            this.cmbSearchPattern.Location = new System.Drawing.Point(0, 16);
            this.cmbSearchPattern.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cmbSearchPattern.Name = "cmbSearchPattern";
            this.cmbSearchPattern.Size = new System.Drawing.Size(317, 21);
            this.cmbSearchPattern.TabIndex = 1;
            this.cmbSearchPattern.TextChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(325, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label3.Name = "label3";
            this.label3.OverrideBackColor = System.Drawing.Color.Empty;
            this.label3.OverrideForeColor = System.Drawing.Color.Empty;
            this.label3.Size = new System.Drawing.Size(318, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "TXT_SEARCHVALUE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.pnlLayoutSec.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(643, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_SEARCHPATTERN_FE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkNoCase
            // 
            this.chkNoCase.AutoSize = true;
            this.chkNoCase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkNoCase.Location = new System.Drawing.Point(0, 0);
            this.chkNoCase.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.chkNoCase.Name = "chkNoCase";
            this.chkNoCase.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkNoCase.Size = new System.Drawing.Size(172, 17);
            this.chkNoCase.TabIndex = 9;
            this.chkNoCase.Text = "TXT_CASEINSENSITIVESEARCH";
            this.chkNoCase.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // chkRecursive
            // 
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRecursive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRecursive.Location = new System.Drawing.Point(0, 80);
            this.chkRecursive.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkRecursive.Size = new System.Drawing.Size(317, 20);
            this.chkRecursive.TabIndex = 8;
            this.chkRecursive.Text = "TXT_RECURSIVESEARCH";
            this.chkRecursive.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // lbAttributes
            // 
            this.lbAttributes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbAttributes.CheckOnClick = true;
            this.pnlLayoutSec.SetColumnSpan(this.lbAttributes, 3);
            this.lbAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAttributes.FormattingEnabled = true;
            this.lbAttributes.IntegralHeight = false;
            this.lbAttributes.Location = new System.Drawing.Point(0, 123);
            this.lbAttributes.Margin = new System.Windows.Forms.Padding(0);
            this.lbAttributes.MultiColumn = true;
            this.lbAttributes.Name = "lbAttributes";
            this.lbAttributes.Size = new System.Drawing.Size(643, 73);
            this.lbAttributes.TabIndex = 12;
            this.lbAttributes.Click += new System.EventHandler(this.OnSettingsChanged);
            // 
            // chkAttrSearch
            // 
            this.chkAttrSearch.AutoSize = true;
            this.chkAttrSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkAttrSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAttrSearch.Location = new System.Drawing.Point(0, 103);
            this.chkAttrSearch.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.chkAttrSearch.Name = "chkAttrSearch";
            this.chkAttrSearch.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkAttrSearch.Size = new System.Drawing.Size(317, 17);
            this.chkAttrSearch.TabIndex = 10;
            this.chkAttrSearch.Text = "TXT_ATTRIBUTESEARCH";
            this.chkAttrSearch.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // txtSearchPath
            // 
            this.txtSearchPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSearchPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchPath.Location = new System.Drawing.Point(0, 0);
            this.txtSearchPath.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearchPath.Name = "txtSearchPath";
            this.txtSearchPath.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtSearchPath.ReadOnly = true;
            this.txtSearchPath.Size = new System.Drawing.Size(293, 22);
            this.txtSearchPath.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(0, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label2.Name = "label2";
            this.label2.OverrideBackColor = System.Drawing.Color.Empty;
            this.label2.OverrideForeColor = System.Drawing.Color.Empty;
            this.label2.Size = new System.Drawing.Size(317, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "TXT_SEARCHFOLDER";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.Transparent;
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusBar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.statusBar.GripMargin = new System.Windows.Forms.Padding(0);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearch,
            this.ssStatus,
            this.pbProgress});
            this.statusBar.Location = new System.Drawing.Point(0, 0);
            this.statusBar.Name = "statusBar";
            this.statusBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusBar.Size = new System.Drawing.Size(643, 31);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusStrip1";
            this.statusBar.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = false;
            this.btnSearch.AutoToolTip = true;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(74, 25);
            this.btnSearch.Text = "TXT_SEARCH";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ssStatus
            // 
            this.ssStatus.AutoSize = false;
            this.ssStatus.AutoToolTip = true;
            this.ssStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(548, 26);
            this.ssStatus.Spring = true;
            this.ssStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbProgress
            // 
            this.pbProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pbProgress.AutoSize = false;
            this.pbProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.pbProgress.Enabled = false;
            this.pbProgress.Maximum = 10000;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(100, 25);
            this.pbProgress.Visible = false;
            // 
            // lvResults
            // 
            this.lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colImage,
            this.colPath});
            this.pnlLayoutSec.SetColumnSpan(this.lvResults, 3);
            this.lvResults.ContextMenuStrip = this.contextMenuStrip;
            this.lvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvResults.Font = new System.Drawing.Font("Segoe UI", 7.25F);
            this.lvResults.Location = new System.Drawing.Point(0, 212);
            this.lvResults.Margin = new System.Windows.Forms.Padding(0);
            this.lvResults.MultiSelect = false;
            this.lvResults.Name = "lvResults";
            this.lvResults.OverrideBackColor = System.Drawing.Color.Empty;
            this.lvResults.Size = new System.Drawing.Size(643, 307);
            this.lvResults.TabIndex = 14;
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Details;
            this.lvResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvResults_MouseDoubleClick);
            this.lvResults.Resize += new System.EventHandler(this.OnResize);
            // 
            // colImage
            // 
            this.colImage.Name = "colImage";
            this.colImage.Text = "-";
            this.colImage.Width = 7;
            // 
            // colPath
            // 
            this.colPath.Name = "colPath";
            this.colPath.Text = "TXT_PATH";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.contextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.contextMenuStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDelete,
            this.toolStripSeparator1,
            this.tsmiID3Wizard,
            this.tsmiSep4,
            this.tsmiProTONEPlay,
            this.tsmiProTONEEnqueue,
            this.tsmiSepProTONE,
            this.goToItemToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(202, 132);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.OnMenuOpening);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiDelete.Image = global::OPMedia.Addons.Builtin.Properties.Resources.Delete;
            this.tsmiDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(201, 22);
            this.tsmiDelete.Tag = "ToolActionDelete";
            this.tsmiDelete.Text = "TXT_DELETE";
            this.tsmiDelete.Click += new System.EventHandler(this.OnToolAction);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // tsmiID3Wizard
            // 
            this.tsmiID3Wizard.Image = global::OPMedia.Addons.Builtin.Properties.Resources.ID3;
            this.tsmiID3Wizard.Name = "tsmiID3Wizard";
            this.tsmiID3Wizard.Size = new System.Drawing.Size(201, 22);
            this.tsmiID3Wizard.Tag = "ToolActionID3Wizard";
            this.tsmiID3Wizard.Text = "TXT_ID3WIZARD";
            this.tsmiID3Wizard.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiSep4
            // 
            this.tsmiSep4.Name = "tsmiSep4";
            this.tsmiSep4.Size = new System.Drawing.Size(198, 6);
            // 
            // tsmiProTONEPlay
            // 
            this.tsmiProTONEPlay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiProTONEPlay.Image = global::OPMedia.Addons.Builtin.Properties.Resources.player16;
            this.tsmiProTONEPlay.Name = "tsmiProTONEPlay";
            this.tsmiProTONEPlay.Size = new System.Drawing.Size(201, 22);
            this.tsmiProTONEPlay.Tag = "ToolActionProTONEPlay";
            this.tsmiProTONEPlay.Text = "TXT_PROTONE_PLAY";
            this.tsmiProTONEPlay.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiProTONEEnqueue
            // 
            this.tsmiProTONEEnqueue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.tsmiProTONEEnqueue.Image = global::OPMedia.Addons.Builtin.Properties.Resources.player16;
            this.tsmiProTONEEnqueue.Name = "tsmiProTONEEnqueue";
            this.tsmiProTONEEnqueue.Size = new System.Drawing.Size(201, 22);
            this.tsmiProTONEEnqueue.Tag = "ToolActionProTONEEnqueue";
            this.tsmiProTONEEnqueue.Text = "TXT_PROTONE_ENQUEUE";
            this.tsmiProTONEEnqueue.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiSepProTONE
            // 
            this.tsmiSepProTONE.Name = "tsmiSepProTONE";
            this.tsmiSepProTONE.Size = new System.Drawing.Size(198, 6);
            // 
            // goToItemToolStripMenuItem
            // 
            this.goToItemToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.goToItemToolStripMenuItem.Name = "goToItemToolStripMenuItem";
            this.goToItemToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.goToItemToolStripMenuItem.Tag = "ToolActionJumpToItem";
            this.goToItemToolStripMenuItem.Text = "TXT_JUMPTOITEM";
            this.goToItemToolStripMenuItem.Click += new System.EventHandler(this.OnToolAction);
            // 
            // chkPropSearch
            // 
            this.chkPropSearch.AutoSize = true;
            this.chkPropSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPropSearch.Location = new System.Drawing.Point(175, 0);
            this.chkPropSearch.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.chkPropSearch.Name = "chkPropSearch";
            this.chkPropSearch.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkPropSearch.Size = new System.Drawing.Size(136, 17);
            this.chkPropSearch.TabIndex = 11;
            this.chkPropSearch.Text = "TXT_PROPERTYSEARCH";
            this.chkPropSearch.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // chkOption1
            // 
            this.chkOption1.AutoSize = true;
            this.chkOption1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkOption1.Location = new System.Drawing.Point(0, 0);
            this.chkOption1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.chkOption1.Name = "chkOption1";
            this.chkOption1.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkOption1.Size = new System.Drawing.Size(90, 17);
            this.chkOption1.TabIndex = 2;
            this.chkOption1.Text = "TXT_OPTION1";
            this.chkOption1.Visible = false;
            this.chkOption1.CheckedChanged += new System.EventHandler(this.OnBookmarksCheckedChanged);
            // 
            // chkOption2
            // 
            this.chkOption2.AutoSize = true;
            this.chkOption2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkOption2.Location = new System.Drawing.Point(93, 0);
            this.chkOption2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.chkOption2.Name = "chkOption2";
            this.chkOption2.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkOption2.Size = new System.Drawing.Size(90, 17);
            this.chkOption2.TabIndex = 3;
            this.chkOption2.Text = "TXT_OPTION2";
            this.chkOption2.Visible = false;
            this.chkOption2.CheckedChanged += new System.EventHandler(this.OnBookmarksCheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(337, 92);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 16;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(337, 22);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.flowLayoutPanel2.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel2.TabIndex = 17;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.pnlLayoutSec.SetColumnSpan(this.tableLayoutPanel2, 3);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.statusBar, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 519);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(643, 31);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pnlLayoutSec
            // 
            this.pnlLayoutSec.ColumnCount = 3;
            this.pnlLayoutSec.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlLayoutSec.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.pnlLayoutSec.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlLayoutSec.Controls.Add(this.kryptonLabel1, 0, 7);
            this.pnlLayoutSec.Controls.Add(this.tableLayoutPanel2, 0, 9);
            this.pnlLayoutSec.Controls.Add(this.lvResults, 0, 8);
            this.pnlLayoutSec.Controls.Add(this.label1, 0, 0);
            this.pnlLayoutSec.Controls.Add(this.label2, 0, 2);
            this.pnlLayoutSec.Controls.Add(this.label3, 2, 2);
            this.pnlLayoutSec.Controls.Add(this.lbAttributes, 0, 6);
            this.pnlLayoutSec.Controls.Add(this.chkRecursive, 0, 4);
            this.pnlLayoutSec.Controls.Add(this.cmbSearchPattern, 0, 1);
            this.pnlLayoutSec.Controls.Add(this.chkAttrSearch, 0, 5);
            this.pnlLayoutSec.Controls.Add(this.cmbSearchText, 2, 3);
            this.pnlLayoutSec.Controls.Add(this.pnlPatternOptions, 2, 1);
            this.pnlLayoutSec.Controls.Add(this.pnlSearchOptions, 2, 4);
            this.pnlLayoutSec.Controls.Add(this.opmTableLayoutPanel1, 0, 3);
            this.pnlLayoutSec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLayoutSec.Location = new System.Drawing.Point(0, 0);
            this.pnlLayoutSec.Name = "pnlLayoutSec";
            this.pnlLayoutSec.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlLayoutSec.RowCount = 10;
            this.pnlLayoutSec.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLayoutSec.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLayoutSec.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLayoutSec.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLayoutSec.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLayoutSec.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLayoutSec.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLayoutSec.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLayoutSec.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLayoutSec.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLayoutSec.Size = new System.Drawing.Size(643, 550);
            this.pnlLayoutSec.TabIndex = 21;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.AutoSize = true;
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kryptonLabel1.Location = new System.Drawing.Point(0, 199);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.kryptonLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.kryptonLabel1.Size = new System.Drawing.Size(317, 13);
            this.kryptonLabel1.TabIndex = 22;
            this.kryptonLabel1.Text = "TXT_RESULTS";
            this.kryptonLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPatternOptions
            // 
            this.pnlPatternOptions.AutoSize = true;
            this.pnlPatternOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlPatternOptions.Controls.Add(this.chkOption1);
            this.pnlPatternOptions.Controls.Add(this.chkOption2);
            this.pnlPatternOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPatternOptions.Location = new System.Drawing.Point(325, 16);
            this.pnlPatternOptions.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlPatternOptions.Name = "pnlPatternOptions";
            this.pnlPatternOptions.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlPatternOptions.Size = new System.Drawing.Size(318, 21);
            this.pnlPatternOptions.TabIndex = 20;
            // 
            // pnlSearchOptions
            // 
            this.pnlSearchOptions.AutoSize = true;
            this.pnlSearchOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSearchOptions.Controls.Add(this.chkNoCase);
            this.pnlSearchOptions.Controls.Add(this.chkPropSearch);
            this.pnlSearchOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearchOptions.Location = new System.Drawing.Point(325, 80);
            this.pnlSearchOptions.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlSearchOptions.Name = "pnlSearchOptions";
            this.pnlSearchOptions.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlSearchOptions.Size = new System.Drawing.Size(318, 20);
            this.pnlSearchOptions.TabIndex = 21;
            this.pnlSearchOptions.WrapContents = false;
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.AutoSize = true;
            this.opmTableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmTableLayoutPanel1.ColumnCount = 2;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.Controls.Add(this.txtSearchPath, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.btnBrowse, 1, 0);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 56);
            this.opmTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 1;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(317, 24);
            this.opmTableLayoutPanel1.TabIndex = 23;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Location = new System.Drawing.Point(296, 1);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 1, 0, 0);
            this.btnBrowse.MaximumSize = new System.Drawing.Size(21, 21);
            this.btnBrowse.MinimumSize = new System.Drawing.Size(21, 21);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnBrowse.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnBrowse.Size = new System.Drawing.Size(21, 21);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // WizFESearchStep1Ctl
            // 
            this.Controls.Add(this.pnlLayoutSec);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "WizFESearchStep1Ctl";
            this.Size = new System.Drawing.Size(643, 550);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.pnlLayoutSec.ResumeLayout(false);
            this.pnlLayoutSec.PerformLayout();
            this.pnlPatternOptions.ResumeLayout(false);
            this.pnlPatternOptions.PerformLayout();
            this.pnlSearchOptions.ResumeLayout(false);
            this.pnlSearchOptions.PerformLayout();
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMEditableComboBox cmbSearchText;
        private OPMEditableComboBox cmbSearchPattern;
        private OPMLabel label3;
        private OPMLabel label1;
        private OPMCheckBox chkNoCase;
        private OPMCheckBox chkRecursive;
        private System.Windows.Forms.CheckedListBox lbAttributes;
        private OPMCheckBox chkAttrSearch;
        private OPMTextBox txtSearchPath;
        private OPMLabel label2;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel ssStatus;
        private ToolStripProgressBar pbProgress;
        private OPMListView lvResults;
        private OPMContextMenuStrip contextMenuStrip;
        private OPMToolStripMenuItem tsmiDelete;
        private OPMToolStripSeparator tsmiSep4;
        private OPMToolStripMenuItem tsmiID3Wizard;
        private OPMToolStripSeparator toolStripSeparator1;
        private OPMToolStripMenuItem goToItemToolStripMenuItem;
        private OPMToolStripMenuItem tsmiProTONEPlay;
        private OPMToolStripMenuItem tsmiProTONEEnqueue;
        private OPMToolStripSeparator tsmiSepProTONE;
        private OPMCheckBox chkPropSearch;
        private OPMCheckBox chkOption1;
        private OPMCheckBox chkOption2;
        private OPMFlowLayoutPanel flowLayoutPanel1;
        private OPMFlowLayoutPanel flowLayoutPanel2;
        private ColumnHeader colImage;
        private ColumnHeader colPath;
        private OPMTableLayoutPanel tableLayoutPanel2;
        private OPMTableLayoutPanel pnlLayoutSec;
        private OPMFlowLayoutPanel pnlPatternOptions;
        private OPMFlowLayoutPanel pnlSearchOptions;
        private OPMLabel kryptonLabel1;
        private StatusStripButton btnSearch;
        private OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMButton btnBrowse;

    }
}
