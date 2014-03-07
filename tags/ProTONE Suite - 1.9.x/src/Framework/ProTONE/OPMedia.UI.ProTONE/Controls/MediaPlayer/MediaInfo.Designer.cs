using System.Drawing;
using System.Windows.Forms;
using OPMedia.UI.Controls;
namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    partial class MediaInfo
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
            this.pnlImages = new OPMTableLayoutPanel();
            this.pbFileType = new System.Windows.Forms.PictureBox();
            this.pbFilterState = new System.Windows.Forms.PictureBox();
            this.pbAudioOn = new System.Windows.Forms.PictureBox();
            this.pbVideoOn = new System.Windows.Forms.PictureBox();
            this.pnlImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFileType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFilterState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAudioOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoOn)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlImages
            // 
            this.pnlImages.AutoSize = true;
            this.pnlImages.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlImages.ColumnCount = 6;
            this.pnlImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlImages.Controls.Add(this.pbFileType, 1, 1);
            this.pnlImages.Controls.Add(this.pbFilterState, 2, 1);
            this.pnlImages.Controls.Add(this.pbAudioOn, 3, 1);
            this.pnlImages.Controls.Add(this.pbVideoOn, 4, 1);
            this.pnlImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImages.Location = new System.Drawing.Point(0, 0);
            this.pnlImages.Margin = new System.Windows.Forms.Padding(0);
            this.pnlImages.Name = "pnlImages";
            this.pnlImages.RowCount = 3;
            this.pnlImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlImages.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlImages.Size = new System.Drawing.Size(80, 20);
            this.pnlImages.TabIndex = 0;
            // 
            // pbFileType
            // 
            this.pbFileType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFileType.Location = new System.Drawing.Point(0, 0);
            this.pbFileType.Margin = new System.Windows.Forms.Padding(0);
            this.pbFileType.Name = "pbFileType";
            this.pbFileType.Size = new System.Drawing.Size(20, 20);
            this.pbFileType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbFileType.TabIndex = 0;
            this.pbFileType.TabStop = false;
            // 
            // pbFilterState
            // 
            this.pbFilterState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFilterState.Location = new System.Drawing.Point(20, 0);
            this.pbFilterState.Margin = new System.Windows.Forms.Padding(0);
            this.pbFilterState.Name = "pbFilterState";
            this.pbFilterState.Size = new System.Drawing.Size(20, 20);
            this.pbFilterState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbFilterState.TabIndex = 1;
            this.pbFilterState.TabStop = false;
            // 
            // pbAudioOn
            // 
            this.pbAudioOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbAudioOn.Location = new System.Drawing.Point(40, 0);
            this.pbAudioOn.Margin = new System.Windows.Forms.Padding(0);
            this.pbAudioOn.Name = "pbAudioOn";
            this.pbAudioOn.Size = new System.Drawing.Size(20, 20);
            this.pbAudioOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbAudioOn.TabIndex = 2;
            this.pbAudioOn.TabStop = false;
            // 
            // pbVideoOn
            // 
            this.pbVideoOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbVideoOn.Location = new System.Drawing.Point(60, 0);
            this.pbVideoOn.Margin = new System.Windows.Forms.Padding(0);
            this.pbVideoOn.Name = "pbVideoOn";
            this.pbVideoOn.Size = new System.Drawing.Size(20, 20);
            this.pbVideoOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbVideoOn.TabIndex = 3;
            this.pbVideoOn.TabStop = false;
            // 
            // MediaInfo
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pnlImages);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MediaInfo";
            this.Size = new System.Drawing.Size(80, 20);
            this.pnlImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFileType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFilterState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAudioOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoOn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pbFileType;
        private PictureBox pbFilterState;
        private PictureBox pbAudioOn;
        private PictureBox pbVideoOn;
        private OPMTableLayoutPanel pnlImages;
    }
}
