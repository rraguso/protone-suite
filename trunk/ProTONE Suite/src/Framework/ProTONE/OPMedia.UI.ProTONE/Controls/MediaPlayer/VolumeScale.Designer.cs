using OPMedia.UI.Controls;

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    partial class VolumeScale
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
            this.layoutPanel1 = new OPMTableLayoutPanel();
            this.lblMax = new OPMLabel();
            this.volumeProgress = new ControlGauge();
            this.lblMin = new OPMLabel();
            this.lblCurrent = new OPMLabel();
            this.layoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutPanel1
            // 
            this.layoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutPanel1.ColumnCount = 3;
            this.layoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanel1.Controls.Add(this.lblMax, 2, 1);
            this.layoutPanel1.Controls.Add(this.volumeProgress, 0, 0);
            this.layoutPanel1.Controls.Add(this.lblMin, 0, 1);
            this.layoutPanel1.Controls.Add(this.lblCurrent, 1, 1);
            this.layoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.layoutPanel1.Name = "layoutPanel1";
            this.layoutPanel1.RowCount = 2;
            this.layoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.layoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel1.Size = new System.Drawing.Size(270, 19);
            this.layoutPanel1.TabIndex = 1;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMax.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.lblMax.Location = new System.Drawing.Point(149, 6);
            this.lblMax.Margin = new System.Windows.Forms.Padding(0);
            this.lblMax.MaximumSize = new System.Drawing.Size(0, 20);
            this.lblMax.Name = "lblMax";
            this.lblMax.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblMax.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblMax.Size = new System.Drawing.Size(121, 13);
            this.lblMax.TabIndex = 3;
            this.lblMax.Text = "100%";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // volumeProgress
            // 
            this.volumeProgress.AllowDragging = true;
            this.layoutPanel1.SetColumnSpan(this.volumeProgress, 3);
            this.volumeProgress.Cursor = System.Windows.Forms.Cursors.Default;
            this.volumeProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeProgress.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.volumeProgress.Location = new System.Drawing.Point(0, 0);
            this.volumeProgress.Margin = new System.Windows.Forms.Padding(0);
            this.volumeProgress.Maximum = 10000D;
            this.volumeProgress.Name = "volumeProgress";
            this.volumeProgress.NrTicks = 10;
            this.volumeProgress.ShowTicks = true;
            this.volumeProgress.Size = new System.Drawing.Size(270, 6);
            this.volumeProgress.TabIndex = 0;
            this.volumeProgress.Value = 5000D;
            this.volumeProgress.Vertical = false;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMin.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.lblMin.Location = new System.Drawing.Point(0, 6);
            this.lblMin.Margin = new System.Windows.Forms.Padding(0);
            this.lblMin.MaximumSize = new System.Drawing.Size(0, 20);
            this.lblMin.Name = "lblMin";
            this.lblMin.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblMin.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblMin.Size = new System.Drawing.Size(120, 13);
            this.lblMin.TabIndex = 1;
            this.lblMin.Text = "0%";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCurrent.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.lblCurrent.Location = new System.Drawing.Point(120, 6);
            this.lblCurrent.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurrent.MaximumSize = new System.Drawing.Size(0, 20);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblCurrent.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblCurrent.Size = new System.Drawing.Size(29, 13);
            this.lblCurrent.TabIndex = 2;
            this.lblCurrent.Text = "25%";
            this.lblCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VolumeScale
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.layoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "VolumeScale";
            this.Size = new System.Drawing.Size(270, 19);
            this.layoutPanel1.ResumeLayout(false);
            this.layoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMTableLayoutPanel layoutPanel1;
        private ControlGauge volumeProgress;
        private OPMLabel lblMax;
        private OPMLabel lblMin;
        private OPMLabel lblCurrent;

    }
}
