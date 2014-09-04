namespace OPMedia.UI.ProTONE.Controls.MediaPlayer.Screens
{
    partial class SignalAnalysisScreen
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
            this.vuLeft = new VuMeterGauge();
            this.vuRight = new VuMeterGauge();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.gpWaveform = new OPMedia.UI.Controls.GraphPlotter();
            this.spSpectrogram = new SpectrogramPlotter();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ggLeft
            // 
            this.vuLeft.AllowDragging = false;
            this.vuLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vuLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vuLeft.Enabled = false;
            this.vuLeft.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.vuLeft.Location = new System.Drawing.Point(3, 3);
            this.vuLeft.Maximum = 10000;
            this.vuLeft.Name = "ggLeft";
            this.vuLeft.NrTicks = 20;
            this.vuLeft.OverrideElapsedBackColor = System.Drawing.Color.Empty;
            this.vuLeft.ShowTicks = true;
            this.vuLeft.Size = new System.Drawing.Size(303, 14);
            this.vuLeft.TabIndex = 0;
            this.vuLeft.Value = 0D;
            this.vuLeft.Vertical = false;
            // 
            // ggRight
            // 
            this.vuRight.AllowDragging = false;
            this.vuRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vuRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vuRight.Enabled = false;
            this.vuRight.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.vuRight.Location = new System.Drawing.Point(3, 23);
            this.vuRight.Maximum = 10000;
            this.vuRight.Name = "ggRight";
            this.vuRight.NrTicks = 20;
            this.vuRight.OverrideElapsedBackColor = System.Drawing.Color.Empty;
            this.vuRight.ShowTicks = true;
            this.vuRight.Size = new System.Drawing.Size(303, 14);
            this.vuRight.TabIndex = 1;
            this.vuRight.Value = 0D;
            this.vuRight.Vertical = false;
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 1;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Controls.Add(this.vuLeft, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.vuRight, 0, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.gpWaveform, 0, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.spSpectrogram, 0, 3);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 4;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(309, 187);
            this.opmTableLayoutPanel1.TabIndex = 2;
            // 
            // gpWaveform
            // 
            this.gpWaveform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpWaveform.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.gpWaveform.Location = new System.Drawing.Point(3, 43);
            this.gpWaveform.Name = "gpWaveform";
            this.gpWaveform.OverrideBackColor = System.Drawing.Color.Empty;
            this.gpWaveform.ShowXAxis = true;
            this.gpWaveform.ShowYAxis = false;
            this.gpWaveform.LogarithmicXAxis = false;
            this.gpWaveform.LogarithmicYAxis = false;
            this.gpWaveform.IsHistogram = false;
            this.gpWaveform.Size = new System.Drawing.Size(303, 67);
            this.gpWaveform.TabIndex = 2;
            // 
            // gpSpectrogram
            // 
            this.spSpectrogram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spSpectrogram.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.spSpectrogram.Location = new System.Drawing.Point(3, 116);
            this.spSpectrogram.Name = "gpSpectrogram";
            this.spSpectrogram.OverrideBackColor = System.Drawing.Color.Empty;
            this.spSpectrogram.ShowXAxis = false;
            this.spSpectrogram.ShowYAxis = false;
            this.spSpectrogram.LogarithmicXAxis = false;
            this.spSpectrogram.LogarithmicYAxis = false;
            this.spSpectrogram.IsHistogram = true;
            this.spSpectrogram.Size = new System.Drawing.Size(303, 68);
            this.spSpectrogram.TabIndex = 3;
            // 
            // VisualEffectsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.Name = "VisualEffectsScreen";
            this.Size = new System.Drawing.Size(309, 187);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private VuMeterGauge vuLeft;
        private VuMeterGauge vuRight;
        private UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private UI.Controls.GraphPlotter gpWaveform;
        private SpectrogramPlotter spSpectrogram;


    }
}
