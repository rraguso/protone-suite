using OPMedia.UI.Controls;
namespace OPMedia.Addons.Builtin.FileExplorer
{
    partial class FileExplorerCfgPanel
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
            this.label5 = new OPMedia.UI.Controls.OPMLabel();
            this.nudPreviewTimer = new OPMedia.UI.Controls.OPMNumericUpDown();
            this.chkGroupBookmarkWithMedia = new OPMedia.UI.Controls.OPMCheckBox();
            this.kryptonLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.nudMaxProcessedFiles = new OPMedia.UI.Controls.OPMNumericUpDown();
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreviewTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxProcessedFiles)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Location = new System.Drawing.Point(3, 32);
            this.label5.Name = "label5";
            this.label5.OverrideBackColor = System.Drawing.Color.Empty;
            this.label5.OverrideForeColor = System.Drawing.Color.Empty;
            this.label5.Size = new System.Drawing.Size(138, 22);
            this.label5.TabIndex = 6;
            this.label5.Text = "TXT_PREVIEW_TIMER";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudPreviewTimer
            // 
            this.nudPreviewTimer.DecimalPlaces = 1;
            this.nudPreviewTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudPreviewTimer.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudPreviewTimer.Location = new System.Drawing.Point(144, 32);
            this.nudPreviewTimer.Margin = new System.Windows.Forms.Padding(0);
            this.nudPreviewTimer.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudPreviewTimer.Name = "nudPreviewTimer";
            this.nudPreviewTimer.ReadOnly = true;
            this.nudPreviewTimer.Size = new System.Drawing.Size(53, 22);
            this.nudPreviewTimer.TabIndex = 7;
            this.nudPreviewTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPreviewTimer.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPreviewTimer.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // chkGroupBookmarkWithMedia
            // 
            this.chkGroupBookmarkWithMedia.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkGroupBookmarkWithMedia, 3);
            this.chkGroupBookmarkWithMedia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkGroupBookmarkWithMedia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkGroupBookmarkWithMedia.Location = new System.Drawing.Point(3, 67);
            this.chkGroupBookmarkWithMedia.Name = "chkGroupBookmarkWithMedia";
            this.chkGroupBookmarkWithMedia.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkGroupBookmarkWithMedia.Size = new System.Drawing.Size(344, 17);
            this.chkGroupBookmarkWithMedia.TabIndex = 8;
            this.chkGroupBookmarkWithMedia.Text = "TXT_GROUP_BMKWITHMEDIA";
            this.chkGroupBookmarkWithMedia.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.AutoSize = true;
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.kryptonLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.kryptonLabel1.Size = new System.Drawing.Size(138, 22);
            this.kryptonLabel1.TabIndex = 6;
            this.kryptonLabel1.Text = "TXT_MAXPROCESSEDFILES";
            this.kryptonLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudMaxProcessedFiles
            // 
            this.nudMaxProcessedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudMaxProcessedFiles.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMaxProcessedFiles.Location = new System.Drawing.Point(144, 0);
            this.nudMaxProcessedFiles.Margin = new System.Windows.Forms.Padding(0);
            this.nudMaxProcessedFiles.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.nudMaxProcessedFiles.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMaxProcessedFiles.Name = "nudMaxProcessedFiles";
            this.nudMaxProcessedFiles.Size = new System.Drawing.Size(53, 22);
            this.nudMaxProcessedFiles.TabIndex = 7;
            this.nudMaxProcessedFiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMaxProcessedFiles.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMaxProcessedFiles.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.nudPreviewTimer, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudMaxProcessedFiles, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkGroupBookmarkWithMedia, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 231);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // FileExplorerCfgPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FileExplorerCfgPanel";
            this.Size = new System.Drawing.Size(350, 231);
            ((System.ComponentModel.ISupportInitialize)(this.nudPreviewTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxProcessedFiles)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMLabel label5;
        private OPMNumericUpDown nudPreviewTimer;
        private OPMCheckBox chkGroupBookmarkWithMedia;
        private OPMLabel kryptonLabel1;
        private OPMNumericUpDown nudMaxProcessedFiles;
        private OPMTableLayoutPanel tableLayoutPanel1;
    }
}
