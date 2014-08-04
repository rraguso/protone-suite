using OPMedia.UI.Controls;

namespace SkinBuilder.Configuration
{
    partial class SkinBuilderCfgPanel
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
            this.chkReopenLastCatalog = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkRememberRecentFiles = new OPMedia.UI.Controls.OPMCheckBox();
            this.nudRecentFilesCount = new OPMedia.UI.Controls.OPMNumericUpDown();
            this.kryptonLabel2 = new OPMedia.UI.Controls.OPMLabel();
            this.flowLayoutPanel1 = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecentFilesCount)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkReopenLastCatalog
            // 
            this.chkReopenLastCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkReopenLastCatalog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkReopenLastCatalog.Location = new System.Drawing.Point(0, 38);
            this.chkReopenLastCatalog.Margin = new System.Windows.Forms.Padding(0);
            this.chkReopenLastCatalog.Name = "chkReopenLastCatalog";
            this.chkReopenLastCatalog.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkReopenLastCatalog.Size = new System.Drawing.Size(350, 19);
            this.chkReopenLastCatalog.TabIndex = 1;
            this.chkReopenLastCatalog.Text = "TXT_REOPEN_LAST_FILE";
            this.chkReopenLastCatalog.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // chkRememberRecentFiles
            // 
            this.chkRememberRecentFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRememberRecentFiles.AutoSize = true;
            this.chkRememberRecentFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRememberRecentFiles.Location = new System.Drawing.Point(0, 3);
            this.chkRememberRecentFiles.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.chkRememberRecentFiles.Name = "chkRememberRecentFiles";
            this.chkRememberRecentFiles.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkRememberRecentFiles.Size = new System.Drawing.Size(108, 17);
            this.chkRememberRecentFiles.TabIndex = 2;
            this.chkRememberRecentFiles.Text = "TXT_RETAIN_LAST";
            this.chkRememberRecentFiles.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // nudRecentFilesCount
            // 
            this.nudRecentFilesCount.Location = new System.Drawing.Point(114, 3);
            this.nudRecentFilesCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRecentFilesCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRecentFilesCount.Name = "nudRecentFilesCount";
            this.nudRecentFilesCount.Size = new System.Drawing.Size(40, 22);
            this.nudRecentFilesCount.TabIndex = 4;
            this.nudRecentFilesCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudRecentFilesCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRecentFilesCount.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.AutoSize = true;
            this.kryptonLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kryptonLabel2.Location = new System.Drawing.Point(157, 6);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.kryptonLabel2.OverrideForeColor = System.Drawing.Color.Empty;
            this.kryptonLabel2.Size = new System.Drawing.Size(83, 13);
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Text = "TXT_OPENFILES";
            this.kryptonLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.chkRememberRecentFiles);
            this.flowLayoutPanel1.Controls.Add(this.nudRecentFilesCount);
            this.flowLayoutPanel1.Controls.Add(this.kryptonLabel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(350, 28);
            this.flowLayoutPanel1.TabIndex = 6;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkReopenLastCatalog, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 230);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // SkinBuilderCfgPanel
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SkinBuilderCfgPanel";
            this.Size = new System.Drawing.Size(350, 230);
            ((System.ComponentModel.ISupportInitialize)(this.nudRecentFilesCount)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMCheckBox chkReopenLastCatalog;
        private OPMCheckBox chkRememberRecentFiles;
        private OPMNumericUpDown nudRecentFilesCount;
        private OPMLabel kryptonLabel2;
        private OPMFlowLayoutPanel flowLayoutPanel1;
        private OPMTableLayoutPanel tableLayoutPanel1;
    }
}
