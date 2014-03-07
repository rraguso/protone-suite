using OPMedia.UI.Controls;
using OPMedia.UI.Themes;
namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    partial class TimeScale
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
            this.layoutPanel = new OPMTableLayoutPanel();
            this.timeProgress = new ControlGauge();
            this.lblTime = new OPMLabel();
            this.layoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutPanel
            // 
            this.layoutPanel.AutoSize = true;
            this.layoutPanel.ColumnCount = 1;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanel.Controls.Add(this.timeProgress, 0, 0);
            this.layoutPanel.Controls.Add(this.lblTime, 0, 1);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.RowCount = 2;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.Size = new System.Drawing.Size(270, 24);
            this.layoutPanel.TabIndex = 3;
            // 
            // timeProgress
            // 
            this.timeProgress.AllowDragging = false;
            this.timeProgress.Cursor = System.Windows.Forms.Cursors.Default;
            this.timeProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeProgress.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.timeProgress.Location = new System.Drawing.Point(0, 0);
            this.timeProgress.Margin = new System.Windows.Forms.Padding(0);
            this.timeProgress.Maximum = 10000D;
            this.timeProgress.Name = "timeProgress";
            this.timeProgress.NrTicks = 20;
            this.timeProgress.ShowTicks = true;
            this.timeProgress.Size = new System.Drawing.Size(270, 8);
            this.timeProgress.TabIndex = 0;
            this.timeProgress.Value = 0D;
            this.timeProgress.Vertical = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTime.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.lblTime.Location = new System.Drawing.Point(0, 8);
            this.lblTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime.Name = "lblTime";
            this.lblTime.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblTime.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblTime.Size = new System.Drawing.Size(270, 16);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "00:00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeScale
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.layoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TimeScale";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(270, 24);
            this.layoutPanel.ResumeLayout(false);
            this.layoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMTableLayoutPanel layoutPanel;
        private OPMLabel lblTime;
        private ControlGauge timeProgress;
    }
}
