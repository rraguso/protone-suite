using OPMedia.UI.Controls;
using System.Windows.Forms;
using OPMedia.Addons.Builtin.Properties;

namespace OPMedia.Addons.Builtin.CatalogExplorer.SearchWizard.Controls
{
    partial class WizMCSearchStep1Ctl
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
            this.cmbSearchText = new OPMedia.UI.Controls.OPMEditableComboBox();
            this.btnClearSearchValues = new System.Windows.Forms.Button();
            this.cmbSearchPattern = new OPMedia.UI.Controls.OPMEditableComboBox();
            this.btnClearSearchPatterns = new System.Windows.Forms.Button();
            this.label3 = new OPMedia.UI.Controls.OPMLabel();
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.chkRecursive = new OPMedia.UI.Controls.OPMCheckBox();
            this.txtSearchPath = new OPMedia.UI.Controls.OPMTextBox();
            this.btnClearSearchFolders = new System.Windows.Forms.Button();
            this.label2 = new OPMedia.UI.Controls.OPMLabel();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.btnSearch = new OPMedia.UI.Controls.StatusStripButton();
            this.ssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.contextMenuStrip = new OPMContextMenuStrip();
            this.tsmiDelete = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.toolStripSeparator1 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmiID3Wizard = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiSep4 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmiProTONEPlay = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiProTONEEnqueue = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiSepProTONE = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.goToItemToolStripMenuItem = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.ilImages = new System.Windows.Forms.ImageList(this.components);
            this.lvResults = new OPMedia.UI.Controls.OPMListView();
            this.colImage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInternalLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMediaLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMediaPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.kryptonLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.tableLayoutPanel2 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.btnBrowse = new OPMedia.UI.Controls.OPMButton();
            this.statusBar.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbSearchText
            // 
            this.cmbSearchText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSearchText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSearchText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSearchText.FormattingEnabled = true;
            this.cmbSearchText.Location = new System.Drawing.Point(355, 56);
            this.cmbSearchText.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cmbSearchText.Name = "cmbSearchText";
            this.cmbSearchText.Size = new System.Drawing.Size(345, 21);
            this.cmbSearchText.TabIndex = 3;
            // 
            // cmbSearchPattern
            // 
            this.cmbSearchPattern.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSearchPattern.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSearchPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSearchPattern.FormattingEnabled = true;
            this.cmbSearchPattern.Location = new System.Drawing.Point(0, 16);
            this.cmbSearchPattern.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cmbSearchPattern.Name = "cmbSearchPattern";
            this.cmbSearchPattern.Size = new System.Drawing.Size(345, 21);
            this.cmbSearchPattern.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(355, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label3.Name = "label3";
            this.label3.OverrideBackColor = System.Drawing.Color.Empty;
            this.label3.OverrideForeColor = System.Drawing.Color.Empty;
            this.label3.Size = new System.Drawing.Size(345, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "TXT_SEARCHVALUE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(700, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_SEARCHPATTERN_MC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkRecursive
            // 
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRecursive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRecursive.Location = new System.Drawing.Point(0, 82);
            this.chkRecursive.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkRecursive.Size = new System.Drawing.Size(345, 17);
            this.chkRecursive.TabIndex = 6;
            this.chkRecursive.Text = "TXT_RECURSIVESEARCH";
            // 
            // txtSearchPath
            // 
            this.txtSearchPath.Enabled = true;
            this.txtSearchPath.ReadOnly = true;
            this.txtSearchPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchPath.Location = new System.Drawing.Point(0, 0);
            this.txtSearchPath.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.txtSearchPath.Name = "txtSearchPath";
            this.txtSearchPath.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtSearchPath.Size = new System.Drawing.Size(321, 23);
            this.txtSearchPath.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Enabled = false;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(0, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label2.Name = "label2";
            this.label2.OverrideBackColor = System.Drawing.Color.Empty;
            this.label2.OverrideForeColor = System.Drawing.Color.Empty;
            this.label2.Size = new System.Drawing.Size(345, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "TXT_SEARCHFOLDER";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.Transparent;
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusBar.GripMargin = new System.Windows.Forms.Padding(0);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearch,
            this.ssStatus,
            this.pbProgress});
            this.statusBar.Location = new System.Drawing.Point(0, 0);
            this.statusBar.Name = "statusBar";
            this.statusBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusBar.Size = new System.Drawing.Size(700, 31);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 9;
            this.statusBar.Text = "statusStrip1";
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
            this.ssStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(605, 26);
            this.ssStatus.Spring = true;
            // 
            // pbProgress
            // 
            this.pbProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pbProgress.AutoSize = false;
            this.pbProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(212)))), ((int)(((byte)(221)))));
            this.pbProgress.Enabled = false;
            this.pbProgress.Maximum = 10000;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(100, 25);
            this.pbProgress.Visible = false;
            // 
            // contextMenuStrip
            // 
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
            this.tsmiID3Wizard.Visible = false;
            this.tsmiID3Wizard.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsmiSep4
            // 
            this.tsmiSep4.Name = "tsmiSep4";
            this.tsmiSep4.Size = new System.Drawing.Size(198, 6);
            this.tsmiSep4.Visible = false;
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
            // ilImages
            // 
            this.ilImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilImages.ImageSize = new System.Drawing.Size(16, 16);
            this.ilImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lvResults
            // 
            this.lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colImage,
            this.colInternalLabel,
            this.colMediaLabel,
            this.colMediaPath});
            this.tableLayoutPanel1.SetColumnSpan(this.lvResults, 3);
            this.lvResults.ContextMenuStrip = this.contextMenuStrip;
            this.lvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvResults.Location = new System.Drawing.Point(3, 121);
            this.lvResults.MultiSelect = false;
            this.lvResults.Name = "lvResults";
            this.lvResults.OverrideBackColor = System.Drawing.Color.Empty;
            this.lvResults.Size = new System.Drawing.Size(694, 395);
            this.lvResults.TabIndex = 10;
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Details;
            this.lvResults.Resize += new System.EventHandler(this.lvResults_Resize);
            // 
            // colImage
            // 
            this.colImage.Name = "colImage";
            this.colImage.Text = "-";
            this.colImage.Width = 7;
            // 
            // colInternalLabel
            // 
            this.colInternalLabel.Name = "colInternalLabel";
            this.colInternalLabel.Text = "TXT_INTERNALLABEL";
            this.colInternalLabel.Width = 125;
            // 
            // colMediaLabel
            // 
            this.colMediaLabel.Name = "colMediaLabel";
            this.colMediaLabel.Text = "TXT_MEDIALABEL";
            this.colMediaLabel.Width = 111;
            // 
            // colMediaPath
            // 
            this.colMediaPath.Name = "colMediaPath";
            this.colMediaPath.Text = "TXT_MEDIAPATH";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lvResults, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cmbSearchPattern, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkRecursive, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbSearchText, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.opmTableLayoutPanel1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 550);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.AutoSize = true;
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kryptonLabel1.Location = new System.Drawing.Point(0, 105);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.kryptonLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.kryptonLabel1.Size = new System.Drawing.Size(345, 13);
            this.kryptonLabel1.TabIndex = 23;
            this.kryptonLabel1.Text = "TXT_RESULTS";
            this.kryptonLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(700, 31);
            this.tableLayoutPanel2.TabIndex = 13;
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
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(345, 26);
            this.opmTableLayoutPanel1.TabIndex = 24;
            // 
            // btnBrowse
            // 
            this.btnBrowse.AutoSize = true;
            this.btnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Location = new System.Drawing.Point(324, 0);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnBrowse.MaximumSize = new System.Drawing.Size(21, 21);
            this.btnBrowse.MinimumSize = new System.Drawing.Size(21, 21);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnBrowse.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnBrowse.Size = new System.Drawing.Size(21, 21);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "---";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // WizMCSearchStep1Ctl
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WizMCSearchStep1Ctl";
            this.Size = new System.Drawing.Size(700, 550);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMEditableComboBox cmbSearchText;
        private OPMEditableComboBox cmbSearchPattern;
        private OPMLabel label3;
        private OPMLabel label1;
        private OPMCheckBox chkRecursive;
        private OPMTextBox txtSearchPath;
        private OPMLabel label2;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel ssStatus;
        private ToolStripProgressBar pbProgress;
        private System.Windows.Forms.ImageList ilImages;
        private OPMContextMenuStrip contextMenuStrip;
        private OPMToolStripMenuItem tsmiDelete;
        private OPMToolStripSeparator tsmiSep4;
        private OPMToolStripMenuItem tsmiID3Wizard;
        private OPMToolStripSeparator toolStripSeparator1;
        private OPMToolStripMenuItem goToItemToolStripMenuItem;
        private OPMToolStripMenuItem tsmiProTONEPlay;
        private OPMToolStripMenuItem tsmiProTONEEnqueue;
        private OPMToolStripSeparator tsmiSepProTONE;
        private OPMListView lvResults;
        private ColumnHeader colImage;
        private ColumnHeader colInternalLabel;
        private ColumnHeader colMediaLabel;
        private ColumnHeader colMediaPath;
        private OPMTableLayoutPanel tableLayoutPanel1;
        private OPMTableLayoutPanel tableLayoutPanel2;
        private OPMLabel kryptonLabel1;
        private Button btnClearSearchValues;
        private Button btnClearSearchPatterns;
        private Button btnClearSearchFolders;
        private StatusStripButton btnSearch;
        private OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMButton btnBrowse;

    }
}
