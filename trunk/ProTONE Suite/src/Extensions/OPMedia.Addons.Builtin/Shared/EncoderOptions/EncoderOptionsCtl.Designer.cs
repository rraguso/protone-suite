namespace OPMedia.Addons.Builtin.Shared.EncoderOptions
{
    partial class EncoderOptionsCtl
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
            this.opmGroupBox1 = new OPMedia.UI.Controls.OPMGroupBox();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmLabel3 = new OPMedia.UI.Controls.OPMLabel();
            this.cmbOutputFormat = new OPMedia.UI.Controls.OPMComboBox();
            this.pnlEncoderOptions = new OPMedia.UI.Controls.OPMPanel();
            this.opmGroupBox1.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // opmGroupBox1
            // 
            this.opmGroupBox1.AutoSize = true;
            this.opmGroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmGroupBox1.Controls.Add(this.opmTableLayoutPanel1);
            this.opmGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.opmGroupBox1.Name = "opmGroupBox1";
            this.opmGroupBox1.Size = new System.Drawing.Size(455, 403);
            this.opmGroupBox1.TabIndex = 6;
            this.opmGroupBox1.TabStop = false;
            this.opmGroupBox1.Text = "TXT_ENCODEROPTIONS";
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 3;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel3, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.cmbOutputFormat, 1, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.pnlEncoderOptions, 0, 1);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 2;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(449, 384);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // opmLabel3
            // 
            this.opmLabel3.AutoSize = true;
            this.opmLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel3.Location = new System.Drawing.Point(3, 0);
            this.opmLabel3.Name = "opmLabel3";
            this.opmLabel3.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel3.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel3.Size = new System.Drawing.Size(118, 29);
            this.opmLabel3.TabIndex = 1;
            this.opmLabel3.Text = "TXT_OUTPUT_FORMAT";
            this.opmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbOutputFormat
            // 
            this.cmbOutputFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbOutputFormat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbOutputFormat.FormattingEnabled = true;
            this.cmbOutputFormat.Location = new System.Drawing.Point(127, 3);
            this.cmbOutputFormat.Name = "cmbOutputFormat";
            this.cmbOutputFormat.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbOutputFormat.Size = new System.Drawing.Size(114, 23);
            this.cmbOutputFormat.TabIndex = 0;
            this.cmbOutputFormat.SelectedIndexChanged += new System.EventHandler(this.OnSelectOutputFormat);
            // 
            // pnlEncoderOptions
            // 
            this.opmTableLayoutPanel1.SetColumnSpan(this.pnlEncoderOptions, 3);
            this.pnlEncoderOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEncoderOptions.Location = new System.Drawing.Point(3, 32);
            this.pnlEncoderOptions.Name = "pnlEncoderOptions";
            this.pnlEncoderOptions.Size = new System.Drawing.Size(443, 349);
            this.pnlEncoderOptions.TabIndex = 2;
            // 
            // EncoderOptionsCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.opmGroupBox1);
            this.Name = "EncoderOptionsCtl";
            this.Size = new System.Drawing.Size(455, 403);
            this.opmGroupBox1.ResumeLayout(false);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI.Controls.OPMGroupBox opmGroupBox1;
        private UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private UI.Controls.OPMLabel opmLabel3;
        private UI.Controls.OPMComboBox cmbOutputFormat;
        private UI.Controls.OPMPanel pnlEncoderOptions;
    }
}
