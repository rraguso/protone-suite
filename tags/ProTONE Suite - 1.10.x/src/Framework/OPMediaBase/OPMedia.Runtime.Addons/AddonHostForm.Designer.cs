
using OPMedia.UI.Controls;

using System.Windows.Forms;
namespace OPMedia.Runtime.Addons
{
    partial class AddonHostForm
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
            this.msMain = new OPMedia.UI.Controls.OPMMenuStrip();
            this.tsmiFile = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiSettings = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.toolStripSeparator1 = new OPMedia.UI.Controls.OPMMenuStripSeparator();
            this.tsmiExit = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tXTHELPToolStripMenuItem = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tXTAPPHELPToolStripMenuItem = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiAbout = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.toolStripSeparator2 = new OPMedia.UI.Controls.OPMMenuStripSeparator();
            this.tXTSHOWLOGToolStripMenuItem = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlOpMedia = new OPMedia.UI.Controls.OPMSplitContainer();
            this.pnlNavContainer = new OPMedia.UI.Controls.OPMPanel();
            this.lblNoItems = new OPMedia.UI.Controls.OPMLabel();
            this.pnlLocalContent = new OPMedia.UI.Controls.OPMSplitContainer();
            this.pnlProperties = new OPMedia.UI.Controls.OPMPanel();
            this.lblNoProperties = new OPMedia.UI.Controls.OPMLabel();
            this.pnlPreview = new OPMedia.UI.Controls.OPMPanel();
            this.lblNoPreview = new OPMedia.UI.Controls.OPMLabel();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblStatusMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusBarSep = new OPMedia.UI.Controls.OPMLabel();
            this.msMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOpMedia)).BeginInit();
            this.pnlOpMedia.Panel1.SuspendLayout();
            this.pnlOpMedia.Panel2.SuspendLayout();
            this.pnlOpMedia.SuspendLayout();
            this.pnlNavContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLocalContent)).BeginInit();
            this.pnlLocalContent.Panel1.SuspendLayout();
            this.pnlLocalContent.Panel2.SuspendLayout();
            this.pnlLocalContent.SuspendLayout();
            this.pnlProperties.SuspendLayout();
            this.pnlPreview.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.msMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msMain.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.msMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tXTHELPToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(0);
            this.msMain.Size = new System.Drawing.Size(822, 24);
            this.msMain.TabIndex = 0;
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettings,
            this.toolStripSeparator1,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(67, 24);
            this.tsmiFile.Text = "TXT_FILE";
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(163, 22);
            this.tsmiSettings.Text = "TXT_SETTINGS";
            this.tsmiSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.ShortcutKeyDisplayString = "Alt+F4";
            this.tsmiExit.Size = new System.Drawing.Size(163, 22);
            this.tsmiExit.Text = "TXT_EXIT";
            this.tsmiExit.Click += new System.EventHandler(this.OnExit);
            // 
            // tXTHELPToolStripMenuItem
            // 
            this.tXTHELPToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tXTHELPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tXTAPPHELPToolStripMenuItem,
            this.tsmiAbout,
            this.toolStripSeparator2,
            this.tXTSHOWLOGToolStripMenuItem});
            this.tXTHELPToolStripMenuItem.Name = "tXTHELPToolStripMenuItem";
            this.tXTHELPToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.tXTHELPToolStripMenuItem.Text = "TXT_HELP";
            // 
            // tXTAPPHELPToolStripMenuItem
            // 
            this.tXTAPPHELPToolStripMenuItem.Name = "tXTAPPHELPToolStripMenuItem";
            this.tXTAPPHELPToolStripMenuItem.ShortcutKeyDisplayString = "F1";
            this.tXTAPPHELPToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.tXTAPPHELPToolStripMenuItem.Text = "TXT_APPHELP";
            this.tXTAPPHELPToolStripMenuItem.Click += new System.EventHandler(this.tXTAPPHELPToolStripMenuItem_Click);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(178, 22);
            this.tsmiAbout.Text = "TXT_ABOUT";
            this.tsmiAbout.Click += new System.EventHandler(this.tXTABOUTToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // tXTSHOWLOGToolStripMenuItem
            // 
            this.tXTSHOWLOGToolStripMenuItem.Name = "tXTSHOWLOGToolStripMenuItem";
            this.tXTSHOWLOGToolStripMenuItem.ShortcutKeyDisplayString = "F12";
            this.tXTSHOWLOGToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.tXTSHOWLOGToolStripMenuItem.Text = "TXT_SHOWLOG";
            this.tXTSHOWLOGToolStripMenuItem.Click += new System.EventHandler(this.tXTSHOWLOGToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.msMain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlOpMedia, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.statusBar, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblStatusBarSep, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(822, 541);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // pnlOpMedia
            // 
            this.pnlOpMedia.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlOpMedia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOpMedia.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.pnlOpMedia.Location = new System.Drawing.Point(0, 24);
            this.pnlOpMedia.Margin = new System.Windows.Forms.Padding(0);
            this.pnlOpMedia.Name = "pnlOpMedia";
            // 
            // pnlOpMedia.Panel1
            // 
            this.pnlOpMedia.Panel1.Controls.Add(this.pnlNavContainer);
            // 
            // pnlOpMedia.Panel2
            // 
            this.pnlOpMedia.Panel2.Controls.Add(this.pnlLocalContent);
            this.pnlOpMedia.Size = new System.Drawing.Size(822, 496);
            this.pnlOpMedia.SplitterDistance = 576;
            this.pnlOpMedia.SplitterWidth = 3;
            this.pnlOpMedia.TabIndex = 6;
            // 
            // pnlNavContainer
            // 
            this.pnlNavContainer.Controls.Add(this.lblNoItems);
            this.pnlNavContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNavContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlNavContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNavContainer.Name = "pnlNavContainer";
            this.pnlNavContainer.Size = new System.Drawing.Size(576, 496);
            this.pnlNavContainer.TabIndex = 0;
            // 
            // lblNoItems
            // 
            this.lblNoItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNoItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNoItems.Location = new System.Drawing.Point(0, 0);
            this.lblNoItems.Margin = new System.Windows.Forms.Padding(0);
            this.lblNoItems.Name = "lblNoItems";
            this.lblNoItems.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblNoItems.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblNoItems.Padding = new System.Windows.Forms.Padding(5);
            this.lblNoItems.Size = new System.Drawing.Size(576, 60);
            this.lblNoItems.TabIndex = 0;
            this.lblNoItems.Text = "aaaa";
            this.lblNoItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLocalContent
            // 
            this.pnlLocalContent.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlLocalContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLocalContent.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.pnlLocalContent.Location = new System.Drawing.Point(0, 0);
            this.pnlLocalContent.Name = "pnlLocalContent";
            this.pnlLocalContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // pnlLocalContent.Panel1
            // 
            this.pnlLocalContent.Panel1.Controls.Add(this.pnlProperties);
            // 
            // pnlLocalContent.Panel2
            // 
            this.pnlLocalContent.Panel2.Controls.Add(this.pnlPreview);
            this.pnlLocalContent.Size = new System.Drawing.Size(243, 496);
            this.pnlLocalContent.SplitterDistance = 325;
            this.pnlLocalContent.SplitterWidth = 3;
            this.pnlLocalContent.TabIndex = 3;
            // 
            // pnlProperties
            // 
            this.pnlProperties.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlProperties.Controls.Add(this.lblNoProperties);
            this.pnlProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProperties.Location = new System.Drawing.Point(0, 0);
            this.pnlProperties.Margin = new System.Windows.Forms.Padding(0);
            this.pnlProperties.Name = "pnlProperties";
            this.pnlProperties.Size = new System.Drawing.Size(243, 325);
            this.pnlProperties.TabIndex = 0;
            // 
            // lblNoProperties
            // 
            this.lblNoProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNoProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNoProperties.Location = new System.Drawing.Point(0, 0);
            this.lblNoProperties.Margin = new System.Windows.Forms.Padding(0);
            this.lblNoProperties.Name = "lblNoProperties";
            this.lblNoProperties.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblNoProperties.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblNoProperties.Padding = new System.Windows.Forms.Padding(5);
            this.lblNoProperties.Size = new System.Drawing.Size(243, 60);
            this.lblNoProperties.TabIndex = 0;
            this.lblNoProperties.Text = "aaaa";
            this.lblNoProperties.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPreview
            // 
            this.pnlPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlPreview.Controls.Add(this.lblNoPreview);
            this.pnlPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPreview.Location = new System.Drawing.Point(0, 0);
            this.pnlPreview.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(243, 168);
            this.pnlPreview.TabIndex = 0;
            // 
            // lblNoPreview
            // 
            this.lblNoPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNoPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNoPreview.Location = new System.Drawing.Point(0, 0);
            this.lblNoPreview.Margin = new System.Windows.Forms.Padding(0);
            this.lblNoPreview.Name = "lblNoPreview";
            this.lblNoPreview.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblNoPreview.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblNoPreview.Padding = new System.Windows.Forms.Padding(5);
            this.lblNoPreview.Size = new System.Drawing.Size(243, 60);
            this.lblNoPreview.TabIndex = 0;
            this.lblNoPreview.Text = "abcdef";
            this.lblNoPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusBar
            // 
            this.statusBar.AllowMerge = false;
            this.statusBar.AutoSize = false;
            this.statusBar.BackColor = System.Drawing.Color.Transparent;
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusBar.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.statusBar.GripMargin = new System.Windows.Forms.Padding(0);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusMain});
            this.statusBar.Location = new System.Drawing.Point(0, 526);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(822, 15);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 0;
            // 
            // lblStatusMain
            // 
            this.lblStatusMain.AutoToolTip = true;
            this.lblStatusMain.Image = global::OPMedia.Runtime.Addons.Properties.Resources.Addons;
            this.lblStatusMain.Margin = new System.Windows.Forms.Padding(0);
            this.lblStatusMain.Name = "lblStatusMain";
            this.lblStatusMain.Size = new System.Drawing.Size(88, 15);
            this.lblStatusMain.Text = "this is a text";
            // 
            // lblStatusBarSep
            // 
            this.lblStatusBarSep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusBarSep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStatusBarSep.Location = new System.Drawing.Point(0, 520);
            this.lblStatusBarSep.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.lblStatusBarSep.Name = "lblStatusBarSep";
            this.lblStatusBarSep.OverrideBackColor = System.Drawing.Color.Red;
            this.lblStatusBarSep.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblStatusBarSep.Size = new System.Drawing.Size(822, 3);
            this.lblStatusBarSep.TabIndex = 7;
            this.lblStatusBarSep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddonHostForm
            // 
            this.ClientSize = new System.Drawing.Size(828, 571);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(700, 450);
            this.Name = "AddonHostForm";
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlOpMedia.Panel1.ResumeLayout(false);
            this.pnlOpMedia.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlOpMedia)).EndInit();
            this.pnlOpMedia.ResumeLayout(false);
            this.pnlNavContainer.ResumeLayout(false);
            this.pnlLocalContent.Panel1.ResumeLayout(false);
            this.pnlLocalContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlLocalContent)).EndInit();
            this.pnlLocalContent.ResumeLayout(false);
            this.pnlProperties.ResumeLayout(false);
            this.pnlPreview.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMMenuStrip msMain;
        private OPMToolStripMenuItem tsmiFile;
        private OPMToolStripMenuItem tsmiSettings;
        private OPMMenuStripSeparator toolStripSeparator1;
        private OPMToolStripMenuItem tsmiExit;
        private OPMToolStripMenuItem tXTHELPToolStripMenuItem;
        private OPMToolStripMenuItem tsmiAbout;
        private OPMToolStripMenuItem tXTAPPHELPToolStripMenuItem;
        private OPMMenuStripSeparator toolStripSeparator2;
        private OPMToolStripMenuItem tXTSHOWLOGToolStripMenuItem;
        private OPMTableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusMain;
        private OPMPanel pnlNavContainer;
        private OPMLabel lblNoItems;
        private OPMPanel pnlProperties;
        private OPMLabel lblNoProperties;
        private OPMPanel pnlPreview;
        private OPMLabel lblNoPreview;
        private OPMSplitContainer pnlLocalContent;
        private OPMSplitContainer pnlOpMedia;
        private OPMLabel lblStatusBarSep;
    }
}

