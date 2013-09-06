namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Forms
{
    partial class WizCdRipperStep2
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.opmLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.opmLabel2 = new OPMedia.UI.Controls.OPMLabel();
            this.txtDestFolder = new OPMedia.UI.Controls.OPMTextBox();
            this.opmButton1 = new OPMedia.UI.Controls.OPMButton();
            this.cmbFilePattern = new OPMedia.UI.Controls.OPMEditableComboBox();
            this.opmGroupBox1 = new OPMedia.UI.Controls.OPMGroupBox();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmLabel3 = new OPMedia.UI.Controls.OPMLabel();
            this.cmbOutputFormat = new OPMedia.UI.Controls.OPMComboBox();
            this.pnlEncoderOptions = new OPMedia.UI.Controls.OPMPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.opmGroupBox1.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Controls.Add(this.opmLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.opmLabel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDestFolder, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.opmButton1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbFilePattern, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.opmGroupBox1, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(431, 400);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // opmLabel1
            // 
            this.opmLabel1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.opmLabel1, 2);
            this.opmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel1.Location = new System.Drawing.Point(3, 0);
            this.opmLabel1.Name = "opmLabel1";
            this.opmLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel1.Size = new System.Drawing.Size(425, 13);
            this.opmLabel1.TabIndex = 0;
            this.opmLabel1.Text = "TXT_SAVETOFOLDER";
            this.opmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opmLabel2
            // 
            this.opmLabel2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.opmLabel2, 2);
            this.opmLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel2.Location = new System.Drawing.Point(3, 44);
            this.opmLabel2.Name = "opmLabel2";
            this.opmLabel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel2.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel2.Size = new System.Drawing.Size(425, 13);
            this.opmLabel2.TabIndex = 1;
            this.opmLabel2.Text = "TXT_FILENAMEPATTERN";
            this.opmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDestFolder
            // 
            this.txtDestFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDestFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDestFolder.Location = new System.Drawing.Point(3, 16);
            this.txtDestFolder.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.txtDestFolder.Name = "txtDestFolder";
            this.txtDestFolder.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtDestFolder.ReadOnly = true;
            this.txtDestFolder.Size = new System.Drawing.Size(402, 22);
            this.txtDestFolder.TabIndex = 2;
            this.txtDestFolder.TextChanged += new System.EventHandler(this.OnOutputFolderChanged);
            // 
            // opmButton1
            // 
            this.opmButton1.AutoSize = true;
            this.opmButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmButton1.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.opmButton1.Location = new System.Drawing.Point(409, 16);
            this.opmButton1.Name = "opmButton1";
            this.opmButton1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmButton1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmButton1.Size = new System.Drawing.Size(19, 25);
            this.opmButton1.TabIndex = 3;
            this.opmButton1.Text = "...";
            this.opmButton1.UseVisualStyleBackColor = true;
            this.opmButton1.Click += new System.EventHandler(this.opmButton1_Click);
            // 
            // cmbFilePattern
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbFilePattern, 2);
            this.cmbFilePattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFilePattern.FormattingEnabled = true;
            this.cmbFilePattern.Items.AddRange(new object[] {
            "<A> - <T>",
            "<#> <A> - <T>",
            "<#> - <A> - <T>"});
            this.cmbFilePattern.Location = new System.Drawing.Point(3, 60);
            this.cmbFilePattern.Name = "cmbFilePattern";
            this.cmbFilePattern.Size = new System.Drawing.Size(425, 21);
            this.cmbFilePattern.TabIndex = 4;
            this.cmbFilePattern.SelectedIndexChanged += new System.EventHandler(this.OnFilePatternChanged);
            this.cmbFilePattern.TextChanged += new System.EventHandler(this.OnFilePatternChanged);
            // 
            // opmGroupBox1
            // 
            this.opmGroupBox1.AutoSize = true;
            this.opmGroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.opmGroupBox1, 2);
            this.opmGroupBox1.Controls.Add(this.opmTableLayoutPanel1);
            this.opmGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmGroupBox1.Location = new System.Drawing.Point(3, 90);
            this.opmGroupBox1.Name = "opmGroupBox1";
            this.opmGroupBox1.Size = new System.Drawing.Size(425, 307);
            this.opmGroupBox1.TabIndex = 5;
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
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 2;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(419, 286);
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
            this.pnlEncoderOptions.Size = new System.Drawing.Size(413, 251);
            this.pnlEncoderOptions.TabIndex = 2;
            // 
            // WizCdRipperStep2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WizCdRipperStep2";
            this.Size = new System.Drawing.Size(431, 400);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.opmGroupBox1.ResumeLayout(false);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UI.Controls.OPMLabel opmLabel1;
        private UI.Controls.OPMLabel opmLabel2;
        private UI.Controls.OPMTextBox txtDestFolder;
        private UI.Controls.OPMButton opmButton1;
        private UI.Controls.OPMEditableComboBox cmbFilePattern;
        private UI.Controls.OPMGroupBox opmGroupBox1;
        private UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private UI.Controls.OPMComboBox cmbOutputFormat;
        private UI.Controls.OPMLabel opmLabel3;
        private UI.Controls.OPMPanel pnlEncoderOptions;
    }
}
