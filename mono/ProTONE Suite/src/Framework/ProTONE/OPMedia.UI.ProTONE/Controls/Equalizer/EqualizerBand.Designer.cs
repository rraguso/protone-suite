namespace OPMedia.UI.ProTONE.Controls.Equalizer
{
    partial class EqualizerBand
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
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.txtFrequency = new OPMedia.UI.Controls.OPMNumericTextBox();
            this.cgLevel = new OPMedia.UI.Controls.GradientGauge();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 2;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Controls.Add(this.txtFrequency, 0, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.cgLevel, 0, 0);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 2;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(39, 300);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // txtFrequency
            // 
            this.txtFrequency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtFrequency.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFrequency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFrequency.Location = new System.Drawing.Point(0, 278);
            this.txtFrequency.Margin = new System.Windows.Forms.Padding(0);
            this.txtFrequency.MaxLength = 5;
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.NumBase = OPMedia.UI.Controls.NumberingBase.Base10;
            this.txtFrequency.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtFrequency.Size = new System.Drawing.Size(33, 22);
            this.txtFrequency.TabIndex = 1;
            this.txtFrequency.Text = "99999";
            this.txtFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cgLevel
            // 
            this.cgLevel.AllowDragging = true;
            this.cgLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cgLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgLevel.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.cgLevel.GaugeMode = OPMedia.UI.Controls.GaugeMode.Point;
            this.cgLevel.Location = new System.Drawing.Point(10, 3);
            this.cgLevel.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.cgLevel.Maximum = 10000D;
            this.cgLevel.Name = "cgLevel";
            this.cgLevel.NrTicks = 4;
            this.cgLevel.OverrideElapsedBackColor = System.Drawing.Color.Empty;
            this.cgLevel.ShowTicks = true;
            this.cgLevel.Size = new System.Drawing.Size(13, 272);
            this.cgLevel.TabIndex = 2;
            this.cgLevel.Value = 0D;
            this.cgLevel.Vertical = true;
            // 
            // EqualizerBand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(33, 200);
            this.Name = "EqualizerBand";
            this.Size = new System.Drawing.Size(39, 300);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private UI.Controls.OPMNumericTextBox txtFrequency;
        private UI.Controls.GradientGauge cgLevel;
    }
}
