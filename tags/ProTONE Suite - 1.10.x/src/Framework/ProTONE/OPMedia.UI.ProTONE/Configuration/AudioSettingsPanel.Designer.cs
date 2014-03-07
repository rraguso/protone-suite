namespace OPMedia.UI.ProTONE.Configuration
{
    partial class AudioSettingsPanel
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
            this.lblCautionRealtime = new OPMedia.UI.Controls.OPMLabel();
            this.opmLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.opmLabel2 = new OPMedia.UI.Controls.OPMLabel();
            this.cgVolume = new OPMedia.UI.Controls.ControlGauge();
            this.cgBalance = new OPMedia.UI.Controls.ControlGauge();
            this.opmCheckBox1 = new OPMedia.UI.Controls.OPMCheckBox();
            this.tenBandEqualizer1 = new OPMedia.UI.ProTONE.Controls.Equalizer.TenBandEqualizer();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 2;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.opmTableLayoutPanel1.Controls.Add(this.lblCautionRealtime, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel1, 0, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel2, 1, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.cgVolume, 0, 3);
            this.opmTableLayoutPanel1.Controls.Add(this.cgBalance, 1, 3);
            this.opmTableLayoutPanel1.Controls.Add(this.opmCheckBox1, 0, 4);
            this.opmTableLayoutPanel1.Controls.Add(this.tenBandEqualizer1, 0, 5);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 10;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(356, 386);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // lblCautionRealtime
            // 
            this.lblCautionRealtime.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.lblCautionRealtime, 2);
            this.lblCautionRealtime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCautionRealtime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCautionRealtime.FontSize = OPMedia.UI.Themes.FontSizes.Large;
            this.lblCautionRealtime.Location = new System.Drawing.Point(3, 0);
            this.lblCautionRealtime.Name = "lblCautionRealtime";
            this.lblCautionRealtime.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblCautionRealtime.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblCautionRealtime.Size = new System.Drawing.Size(350, 15);
            this.lblCautionRealtime.TabIndex = 7;
            this.lblCautionRealtime.Text = "TXT_CAUTION_REALTIME";
            this.lblCautionRealtime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opmLabel1
            // 
            this.opmLabel1.AutoSize = true;
            this.opmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel1.Location = new System.Drawing.Point(3, 35);
            this.opmLabel1.Name = "opmLabel1";
            this.opmLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel1.Size = new System.Drawing.Size(172, 18);
            this.opmLabel1.TabIndex = 0;
            this.opmLabel1.Text = "TXT_AUDIOVOLUME";
            this.opmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opmLabel2
            // 
            this.opmLabel2.AutoSize = true;
            this.opmLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel2.Location = new System.Drawing.Point(181, 40);
            this.opmLabel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.opmLabel2.Name = "opmLabel2";
            this.opmLabel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel2.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel2.Size = new System.Drawing.Size(172, 13);
            this.opmLabel2.TabIndex = 2;
            this.opmLabel2.Text = "TXT_BALANCE";
            this.opmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cgVolume
            // 
            this.cgVolume.AllowDragging = true;
            this.cgVolume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cgVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgVolume.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.cgVolume.Location = new System.Drawing.Point(3, 56);
            this.cgVolume.Maximum = 10000D;
            this.cgVolume.MaximumSize = new System.Drawing.Size(0, 15);
            this.cgVolume.MinimumSize = new System.Drawing.Size(0, 15);
            this.cgVolume.Name = "cgVolume";
            this.cgVolume.NrTicks = 10;
            this.cgVolume.OverrideBackColor = System.Drawing.Color.Empty;
            this.cgVolume.ShowTicks = true;
            this.cgVolume.Size = new System.Drawing.Size(172, 15);
            this.cgVolume.TabIndex = 3;
            this.cgVolume.Value = 0D;
            this.cgVolume.Vertical = false;
            // 
            // cgBalance
            // 
            this.cgBalance.AllowDragging = true;
            this.cgBalance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cgBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgBalance.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.cgBalance.GaugeMode = OPMedia.UI.Controls.GaugeMode.Point;
            this.cgBalance.Location = new System.Drawing.Point(181, 56);
            this.cgBalance.Maximum = 4000D;
            this.cgBalance.MaximumSize = new System.Drawing.Size(0, 15);
            this.cgBalance.MinimumSize = new System.Drawing.Size(0, 15);
            this.cgBalance.Name = "cgBalance";
            this.cgBalance.NrTicks = 10;
            this.cgBalance.OverrideBackColor = System.Drawing.Color.Empty;
            this.cgBalance.ShowTicks = true;
            this.cgBalance.Size = new System.Drawing.Size(172, 15);
            this.cgBalance.TabIndex = 4;
            this.cgBalance.Value = 0D;
            this.cgBalance.Vertical = false;
            // 
            // opmCheckBox1
            // 
            this.opmCheckBox1.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.opmCheckBox1, 2);
            this.opmCheckBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmCheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmCheckBox1.Location = new System.Drawing.Point(3, 79);
            this.opmCheckBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.opmCheckBox1.Name = "opmCheckBox1";
            this.opmCheckBox1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmCheckBox1.Size = new System.Drawing.Size(350, 17);
            this.opmCheckBox1.TabIndex = 5;
            this.opmCheckBox1.Text = "TXT_ENABLE_EQUALIZER";
            this.opmCheckBox1.UseVisualStyleBackColor = true;
            // 
            // tenBandEqualizer1
            // 
            this.opmTableLayoutPanel1.SetColumnSpan(this.tenBandEqualizer1, 2);
            this.tenBandEqualizer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tenBandEqualizer1.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.tenBandEqualizer1.Frequencies = new int[] {
        25,
        50,
        100,
        200,
        400,
        800,
        1600,
        3200,
        6400,
        12800};
            this.tenBandEqualizer1.Levels = new double[] {
        5000D,
        5000D,
        5000D,
        5000D,
        5000D,
        5000D,
        5000D,
        5000D,
        5000D,
        5000D};
            this.tenBandEqualizer1.Location = new System.Drawing.Point(3, 102);
            this.tenBandEqualizer1.MaximumSize = new System.Drawing.Size(3500, 300);
            this.tenBandEqualizer1.MinimumSize = new System.Drawing.Size(350, 205);
            this.tenBandEqualizer1.Name = "tenBandEqualizer1";
            this.tenBandEqualizer1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tenBandEqualizer1.Size = new System.Drawing.Size(350, 244);
            this.tenBandEqualizer1.TabIndex = 6;
            // 
            // AudioSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(356, 314);
            this.Name = "AudioSettingsPanel";
            this.Size = new System.Drawing.Size(356, 386);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private UI.Controls.OPMLabel opmLabel1;
        private UI.Controls.OPMLabel opmLabel2;
        private UI.Controls.ControlGauge cgVolume;
        private UI.Controls.ControlGauge cgBalance;
        private Controls.Equalizer.TenBandEqualizer tenBandEqualizer1;
        private UI.Controls.OPMCheckBox opmCheckBox1;
        private UI.Controls.OPMLabel lblCautionRealtime;
    }
}
