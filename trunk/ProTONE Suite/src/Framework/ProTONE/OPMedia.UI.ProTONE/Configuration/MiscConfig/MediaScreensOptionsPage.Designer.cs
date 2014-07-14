using OPMedia.UI.Controls;

namespace OPMedia.UI.ProTONE.Configuration.MiscConfig
{
    partial class MediaScreensOptionsPage
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
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.chkShowPlaylist = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkShowTrackInfo = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkShowSignalAnalisys = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkShowBookmarkInfo = new OPMedia.UI.Controls.OPMCheckBox();
            this.opmLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.opmLabel2 = new OPMedia.UI.Controls.OPMLabel();
            this.opmLabel3 = new OPMedia.UI.Controls.OPMLabel();
            this.opmLabel4 = new OPMedia.UI.Controls.OPMLabel();
            this.pnlSignalAnalisysOptions = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.chkVuMeter = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkWaveform = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkSpectrogram = new OPMedia.UI.Controls.OPMCheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlSignalAnalisysOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.chkShowPlaylist, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkShowTrackInfo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkShowSignalAnalisys, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkShowBookmarkInfo, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.opmLabel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.opmLabel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.opmLabel3, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.opmLabel4, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.pnlSignalAnalisysOptions, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(480, 234);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // chkShowPlaylist
            // 
            this.chkShowPlaylist.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkShowPlaylist, 2);
            this.chkShowPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkShowPlaylist.Location = new System.Drawing.Point(3, 3);
            this.chkShowPlaylist.Name = "chkShowPlaylist";
            this.chkShowPlaylist.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkShowPlaylist.Size = new System.Drawing.Size(474, 17);
            this.chkShowPlaylist.TabIndex = 0;
            this.chkShowPlaylist.Text = "TXT_SHOW_PLAYLIST";
            // 
            // chkShowTrackInfo
            // 
            this.chkShowTrackInfo.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkShowTrackInfo, 2);
            this.chkShowTrackInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowTrackInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkShowTrackInfo.Location = new System.Drawing.Point(3, 46);
            this.chkShowTrackInfo.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.chkShowTrackInfo.Name = "chkShowTrackInfo";
            this.chkShowTrackInfo.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkShowTrackInfo.Size = new System.Drawing.Size(474, 17);
            this.chkShowTrackInfo.TabIndex = 1;
            this.chkShowTrackInfo.Text = "TXT_SHOW_TRACKINFO";
            // 
            // chkShowSignalAnalisys
            // 
            this.chkShowSignalAnalisys.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkShowSignalAnalisys, 2);
            this.chkShowSignalAnalisys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowSignalAnalisys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkShowSignalAnalisys.Location = new System.Drawing.Point(3, 89);
            this.chkShowSignalAnalisys.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.chkShowSignalAnalisys.Name = "chkShowSignalAnalisys";
            this.chkShowSignalAnalisys.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkShowSignalAnalisys.Size = new System.Drawing.Size(474, 17);
            this.chkShowSignalAnalisys.TabIndex = 2;
            this.chkShowSignalAnalisys.Text = "TXT_SHOW_SIGNALANALISYS";
            // 
            // chkShowBookmarkInfo
            // 
            this.chkShowBookmarkInfo.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkShowBookmarkInfo, 2);
            this.chkShowBookmarkInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowBookmarkInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkShowBookmarkInfo.Location = new System.Drawing.Point(3, 160);
            this.chkShowBookmarkInfo.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.chkShowBookmarkInfo.Name = "chkShowBookmarkInfo";
            this.chkShowBookmarkInfo.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkShowBookmarkInfo.Size = new System.Drawing.Size(474, 17);
            this.chkShowBookmarkInfo.TabIndex = 3;
            this.chkShowBookmarkInfo.Text = "TXT_SHOW_BOOKMARKINFO";
            // 
            // opmLabel1
            // 
            this.opmLabel1.AutoSize = true;
            this.opmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel1.Location = new System.Drawing.Point(23, 23);
            this.opmLabel1.Name = "opmLabel1";
            this.opmLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel1.Size = new System.Drawing.Size(454, 13);
            this.opmLabel1.TabIndex = 4;
            this.opmLabel1.Text = "TXT_HINT_PLAYLISTTAB";
            this.opmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opmLabel2
            // 
            this.opmLabel2.AutoSize = true;
            this.opmLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel2.Location = new System.Drawing.Point(23, 66);
            this.opmLabel2.Name = "opmLabel2";
            this.opmLabel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel2.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel2.Size = new System.Drawing.Size(454, 13);
            this.opmLabel2.TabIndex = 5;
            this.opmLabel2.Text = "TXT_HINT_TRACKINFOTAB";
            this.opmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opmLabel3
            // 
            this.opmLabel3.AutoSize = true;
            this.opmLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel3.Location = new System.Drawing.Point(23, 109);
            this.opmLabel3.Name = "opmLabel3";
            this.opmLabel3.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel3.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel3.Size = new System.Drawing.Size(454, 13);
            this.opmLabel3.TabIndex = 6;
            this.opmLabel3.Text = "TXT_HINT_SIGNALANALISYSTAB";
            this.opmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opmLabel4
            // 
            this.opmLabel4.AutoSize = true;
            this.opmLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel4.Location = new System.Drawing.Point(23, 180);
            this.opmLabel4.Name = "opmLabel4";
            this.opmLabel4.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel4.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel4.Size = new System.Drawing.Size(454, 13);
            this.opmLabel4.TabIndex = 7;
            this.opmLabel4.Text = "TXT_HINT_BOOKMARKINFOTAB";
            this.opmLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSignalAnalisysOptions
            // 
            this.pnlSignalAnalisysOptions.AutoSize = true;
            this.pnlSignalAnalisysOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSignalAnalisysOptions.Controls.Add(this.chkVuMeter);
            this.pnlSignalAnalisysOptions.Controls.Add(this.chkWaveform);
            this.pnlSignalAnalisysOptions.Controls.Add(this.chkSpectrogram);
            this.pnlSignalAnalisysOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSignalAnalisysOptions.Location = new System.Drawing.Point(20, 127);
            this.pnlSignalAnalisysOptions.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlSignalAnalisysOptions.Name = "pnlSignalAnalisysOptions";
            this.pnlSignalAnalisysOptions.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlSignalAnalisysOptions.Size = new System.Drawing.Size(460, 23);
            this.pnlSignalAnalisysOptions.TabIndex = 8;
            // 
            // chkVuMeter
            // 
            this.chkVuMeter.AutoSize = true;
            this.chkVuMeter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVuMeter.Location = new System.Drawing.Point(3, 3);
            this.chkVuMeter.Name = "chkVuMeter";
            this.chkVuMeter.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkVuMeter.Size = new System.Drawing.Size(132, 17);
            this.chkVuMeter.TabIndex = 0;
            this.chkVuMeter.Text = "TXT_SHOW_VUMETER";
            this.chkVuMeter.UseVisualStyleBackColor = true;
            // 
            // chkWaveform
            // 
            this.chkWaveform.AutoSize = true;
            this.chkWaveform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkWaveform.Location = new System.Drawing.Point(141, 3);
            this.chkWaveform.Name = "chkWaveform";
            this.chkWaveform.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkWaveform.Size = new System.Drawing.Size(146, 17);
            this.chkWaveform.TabIndex = 1;
            this.chkWaveform.Text = "TXT_SHOW_WAVEFORM";
            this.chkWaveform.UseVisualStyleBackColor = true;
            // 
            // chkSpectrogram
            // 
            this.chkSpectrogram.AutoSize = true;
            this.chkSpectrogram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSpectrogram.Location = new System.Drawing.Point(293, 3);
            this.chkSpectrogram.Name = "chkSpectrogram";
            this.chkSpectrogram.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkSpectrogram.Size = new System.Drawing.Size(161, 17);
            this.chkSpectrogram.TabIndex = 2;
            this.chkSpectrogram.Text = "TXT_SHOW_SPECTROGRAM";
            this.chkSpectrogram.UseVisualStyleBackColor = true;
            // 
            // MediaScreensOptionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MediaScreensOptionsPage";
            this.Size = new System.Drawing.Size(480, 234);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlSignalAnalisysOptions.ResumeLayout(false);
            this.pnlSignalAnalisysOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMTableLayoutPanel tableLayoutPanel1;
        private OPMCheckBox chkShowPlaylist;
        private OPMCheckBox chkShowTrackInfo;
        private OPMCheckBox chkShowSignalAnalisys;
        private OPMCheckBox chkShowBookmarkInfo;
        private OPMLabel opmLabel1;
        private OPMLabel opmLabel2;
        private OPMLabel opmLabel3;
        private OPMLabel opmLabel4;
        private OPMFlowLayoutPanel pnlSignalAnalisysOptions;
        private OPMCheckBox chkVuMeter;
        private OPMCheckBox chkWaveform;
        private OPMCheckBox chkSpectrogram;
    }
}
