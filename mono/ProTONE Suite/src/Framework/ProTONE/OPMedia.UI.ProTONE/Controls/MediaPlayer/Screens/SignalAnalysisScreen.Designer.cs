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
            this.ggLeft = new OPMedia.UI.Controls.GradientGauge();
            this.ggRight = new OPMedia.UI.Controls.GradientGauge();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.gpWaveform = new OPMedia.UI.Controls.GraphPlotter();
            this.gpSpectrogram = new OPMedia.UI.Controls.GraphPlotter();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ggLeft
            // 
            this.ggLeft.AllowDragging = false;
            this.ggLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ggLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggLeft.Enabled = false;
            this.ggLeft.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.ggLeft.Location = new System.Drawing.Point(3, 3);
            this.ggLeft.Maximum = 10000;
            this.ggLeft.Name = "ggLeft";
            this.ggLeft.NrTicks = 20;
            this.ggLeft.OverrideElapsedBackColor = System.Drawing.Color.Empty;
            this.ggLeft.ShowTicks = true;
            this.ggLeft.Size = new System.Drawing.Size(303, 14);
            this.ggLeft.TabIndex = 0;
            this.ggLeft.Value = 0D;
            this.ggLeft.Vertical = false;
            // 
            // ggRight
            // 
            this.ggRight.AllowDragging = false;
            this.ggRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ggRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggRight.Enabled = false;
            this.ggRight.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.ggRight.Location = new System.Drawing.Point(3, 23);
            this.ggRight.Maximum = 10000;
            this.ggRight.Name = "ggRight";
            this.ggRight.NrTicks = 20;
            this.ggRight.OverrideElapsedBackColor = System.Drawing.Color.Empty;
            this.ggRight.ShowTicks = true;
            this.ggRight.Size = new System.Drawing.Size(303, 14);
            this.ggRight.TabIndex = 1;
            this.ggRight.Value = 0D;
            this.ggRight.Vertical = false;
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 1;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Controls.Add(this.ggLeft, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.ggRight, 0, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.gpWaveform, 0, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.gpSpectrogram, 0, 3);
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
            this.gpSpectrogram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpSpectrogram.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.gpSpectrogram.Location = new System.Drawing.Point(3, 116);
            this.gpSpectrogram.Name = "gpSpectrogram";
            this.gpSpectrogram.OverrideBackColor = System.Drawing.Color.Empty;
            this.gpSpectrogram.ShowXAxis = false;
            this.gpSpectrogram.ShowYAxis = false;
            this.gpSpectrogram.LogarithmicXAxis = true;
            this.gpSpectrogram.LogarithmicYAxis = false;
            this.gpSpectrogram.IsHistogram = true;
            this.gpSpectrogram.Size = new System.Drawing.Size(303, 68);
            this.gpSpectrogram.TabIndex = 3;
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

        private UI.Controls.GradientGauge ggLeft;
        private UI.Controls.GradientGauge ggRight;
        private UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private UI.Controls.GraphPlotter gpWaveform;
        private UI.Controls.GraphPlotter gpSpectrogram;


    }
}
