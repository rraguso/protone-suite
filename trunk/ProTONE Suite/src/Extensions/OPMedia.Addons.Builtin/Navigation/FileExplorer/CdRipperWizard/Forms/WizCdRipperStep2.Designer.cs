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
            OPMedia.Addons.Builtin.Shared.EncoderOptions.EncoderSettingsContainer encoderSettingsContainer1 = new OPMedia.Addons.Builtin.Shared.EncoderOptions.EncoderSettingsContainer();
            OPMedia.Addons.Builtin.Shared.EncoderOptions.Mp3EncoderSettings mp3EncoderSettings1 = new OPMedia.Addons.Builtin.Shared.EncoderOptions.Mp3EncoderSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizCdRipperStep2));
            OPMedia.Addons.Builtin.Shared.EncoderOptions.OggEncoderSettings oggEncoderSettings1 = new OPMedia.Addons.Builtin.Shared.EncoderOptions.OggEncoderSettings();
            OPMedia.Addons.Builtin.Shared.EncoderOptions.WavEncoderSettings wavEncoderSettings1 = new OPMedia.Addons.Builtin.Shared.EncoderOptions.WavEncoderSettings();
            OPMedia.Addons.Builtin.Shared.EncoderOptions.WmaEncoderSettings wmaEncoderSettings1 = new OPMedia.Addons.Builtin.Shared.EncoderOptions.WmaEncoderSettings();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.opmLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.opmLabel2 = new OPMedia.UI.Controls.OPMLabel();
            this.txtDestFolder = new OPMedia.UI.Controls.OPMTextBox();
            this.opmButton1 = new OPMedia.UI.Controls.OPMButton();
            this.cmbFilePattern = new OPMedia.UI.Controls.OPMEditableComboBox();
            this.encoderOptionsCtl = new OPMedia.Addons.Builtin.Shared.EncoderOptions.EncoderOptionsCtl();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.encoderOptionsCtl, 0, 5);
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
            this.txtDestFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtDestFolder.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDestFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDestFolder.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.txtDestFolder.Location = new System.Drawing.Point(3, 16);
            this.txtDestFolder.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.txtDestFolder.MaximumSize = new System.Drawing.Size(2000, 20);
            this.txtDestFolder.MaxLength = 32767;
            this.txtDestFolder.MinimumSize = new System.Drawing.Size(20, 20);
            this.txtDestFolder.Multiline = false;
            this.txtDestFolder.Name = "txtDestFolder";
            this.txtDestFolder.OverrideBackColor = System.Drawing.Color.Empty;
            this.txtDestFolder.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtDestFolder.Padding = new System.Windows.Forms.Padding(3);
            this.txtDestFolder.PasswordChar = '\0';
            this.txtDestFolder.ReadOnly = true;
            this.txtDestFolder.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDestFolder.ShortcutsEnabled = true;
            this.txtDestFolder.Size = new System.Drawing.Size(402, 20);
            this.txtDestFolder.TabIndex = 2;
            this.txtDestFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDestFolder.UseSystemPasswordChar = false;
            this.txtDestFolder.WordWrap = true;
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
            this.opmButton1.ShowDropDown = false;
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
            // encoderOptionsCtl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.encoderOptionsCtl, 2);
            this.encoderOptionsCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            encoderSettingsContainer1.AudioMediaFormatType = OPMedia.Addons.Builtin.Shared.EncoderOptions.AudioMediaFormatType.WAV;
            mp3EncoderSettings1.GenerateTagsFromTrackMetadata = false;
            mp3EncoderSettings1.Mp3ConversionOptions = ((OPMedia.Runtime.ProTONE.Compression.Lame.BE_CONFIG)(resources.GetObject("mp3EncoderSettings1.Mp3ConversionOptions")));
            encoderSettingsContainer1.Mp3EncoderSettings = mp3EncoderSettings1;
            encoderSettingsContainer1.OggEncoderSettings = oggEncoderSettings1;
            encoderSettingsContainer1.WavEncoderSettings = wavEncoderSettings1;
            encoderSettingsContainer1.WmaEncoderSettings = wmaEncoderSettings1;
            this.encoderOptionsCtl.EncoderSettings = encoderSettingsContainer1;
            this.encoderOptionsCtl.Location = new System.Drawing.Point(3, 90);
            this.encoderOptionsCtl.Name = "encoderOptionsCtl";
            this.encoderOptionsCtl.Size = new System.Drawing.Size(425, 307);
            this.encoderOptionsCtl.TabIndex = 5;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UI.Controls.OPMLabel opmLabel1;
        private UI.Controls.OPMLabel opmLabel2;
        private UI.Controls.OPMTextBox txtDestFolder;
        private UI.Controls.OPMButton opmButton1;
        private UI.Controls.OPMEditableComboBox cmbFilePattern;
        private Shared.EncoderOptions.EncoderOptionsCtl encoderOptionsCtl;
    }
}
