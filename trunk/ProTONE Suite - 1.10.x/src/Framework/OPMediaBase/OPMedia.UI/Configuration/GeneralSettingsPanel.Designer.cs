using OPMedia.UI.Controls;

namespace OPMedia.UI.Configuration
{
    partial class GeneralSettingsPanel
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
            this.cmbLanguages = new OPMedia.UI.Controls.OPMComboBox();
            this.labelProductName = new OPMedia.UI.Controls.OPMLabel();
            this.layoutPanel = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.labelVersion = new OPMedia.UI.Controls.OPMLabel();
            this.labelCopyright = new OPMedia.UI.Controls.OPMLabel();
            this.lblSetLanguage = new OPMedia.UI.Controls.OPMLabel();
            this.cmbThemes = new OPMedia.UI.Controls.OPMComboBox();
            this.kryptonLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.btnCheckUpdates = new OPMedia.UI.Controls.OPMButton();
            this.chkAllowAutoUpdates = new OPMedia.UI.Controls.OPMCheckBox();
            this.layoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbLanguages
            // 
            this.layoutPanel.SetColumnSpan(this.cmbLanguages, 3);
            this.cmbLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbLanguages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbLanguages.FormattingEnabled = true;
            this.cmbLanguages.Location = new System.Drawing.Point(3, 99);
            this.cmbLanguages.Name = "cmbLanguages";
            this.cmbLanguages.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbLanguages.Size = new System.Drawing.Size(407, 23);
            this.cmbLanguages.TabIndex = 4;
            this.cmbLanguages.SelectedIndexChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // labelProductName
            // 
            this.layoutPanel.SetColumnSpan(this.labelProductName, 3);
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProductName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelProductName.FontSize = OPMedia.UI.Themes.FontSizes.Large;
            this.labelProductName.Location = new System.Drawing.Point(0, 0);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(0);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.OverrideBackColor = System.Drawing.Color.Empty;
            this.labelProductName.OverrideForeColor = System.Drawing.Color.Empty;
            this.labelProductName.Size = new System.Drawing.Size(413, 23);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.Text = "[ Product Name ]";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // layoutPanel
            // 
            this.layoutPanel.ColumnCount = 3;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPanel.Controls.Add(this.chkAllowAutoUpdates, 0, 12);
            this.layoutPanel.Controls.Add(this.labelVersion, 0, 1);
            this.layoutPanel.Controls.Add(this.labelCopyright, 0, 2);
            this.layoutPanel.Controls.Add(this.labelProductName, 0, 0);
            this.layoutPanel.Controls.Add(this.cmbLanguages, 0, 5);
            this.layoutPanel.Controls.Add(this.lblSetLanguage, 0, 4);
            this.layoutPanel.Controls.Add(this.cmbThemes, 0, 8);
            this.layoutPanel.Controls.Add(this.kryptonLabel1, 0, 7);
            this.layoutPanel.Controls.Add(this.btnCheckUpdates, 2, 12);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(3, 3);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.OverrideBackColor = System.Drawing.Color.Empty;
            this.layoutPanel.RowCount = 14;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanel.Size = new System.Drawing.Size(413, 372);
            this.layoutPanel.TabIndex = 7;
            // 
            // labelVersion
            // 
            this.layoutPanel.SetColumnSpan(this.labelVersion, 3);
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelVersion.FontSize = OPMedia.UI.Themes.FontSizes.Large;
            this.labelVersion.Location = new System.Drawing.Point(0, 23);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.OverrideBackColor = System.Drawing.Color.Empty;
            this.labelVersion.OverrideForeColor = System.Drawing.Color.Empty;
            this.labelVersion.Size = new System.Drawing.Size(413, 23);
            this.labelVersion.TabIndex = 1;
            this.labelVersion.Text = "[ Product Version ]";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            this.layoutPanel.SetColumnSpan(this.labelCopyright, 3);
            this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCopyright.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelCopyright.FontSize = OPMedia.UI.Themes.FontSizes.Large;
            this.labelCopyright.Location = new System.Drawing.Point(0, 46);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(0);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.OverrideBackColor = System.Drawing.Color.Empty;
            this.labelCopyright.OverrideForeColor = System.Drawing.Color.Empty;
            this.labelCopyright.Size = new System.Drawing.Size(413, 23);
            this.labelCopyright.TabIndex = 2;
            this.labelCopyright.Text = "[ Copyright Notice ]";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSetLanguage
            // 
            this.layoutPanel.SetColumnSpan(this.lblSetLanguage, 3);
            this.lblSetLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSetLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSetLanguage.Location = new System.Drawing.Point(3, 77);
            this.lblSetLanguage.Name = "lblSetLanguage";
            this.lblSetLanguage.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblSetLanguage.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblSetLanguage.Size = new System.Drawing.Size(407, 19);
            this.lblSetLanguage.TabIndex = 3;
            this.lblSetLanguage.Text = "TXT_SETUILANGUAGE";
            this.lblSetLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbThemes
            // 
            this.layoutPanel.SetColumnSpan(this.cmbThemes, 3);
            this.cmbThemes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbThemes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbThemes.Location = new System.Drawing.Point(3, 147);
            this.cmbThemes.Name = "cmbThemes";
            this.cmbThemes.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbThemes.Size = new System.Drawing.Size(407, 23);
            this.cmbThemes.TabIndex = 6;
            // 
            // kryptonLabel1
            // 
            this.layoutPanel.SetColumnSpan(this.kryptonLabel1, 3);
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 125);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.kryptonLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.kryptonLabel1.Size = new System.Drawing.Size(407, 19);
            this.kryptonLabel1.TabIndex = 5;
            this.kryptonLabel1.Text = "TXT_SETSKIN";
            this.kryptonLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCheckUpdates
            // 
            this.btnCheckUpdates.AutoSize = true;
            this.btnCheckUpdates.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCheckUpdates.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCheckUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckUpdates.Location = new System.Drawing.Point(296, 181);
            this.btnCheckUpdates.Name = "btnCheckUpdates";
            this.btnCheckUpdates.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCheckUpdates.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCheckUpdates.Size = new System.Drawing.Size(114, 25);
            this.btnCheckUpdates.TabIndex = 9;
            this.btnCheckUpdates.Text = "TXT_CHECKUPDATE";
            this.btnCheckUpdates.Click += new System.EventHandler(this.btnCheckUpdates_Click);
            // 
            // chkAllowAutoUpdates
            // 
            this.layoutPanel.SetColumnSpan(this.chkAllowAutoUpdates, 2);
            this.chkAllowAutoUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkAllowAutoUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAllowAutoUpdates.Location = new System.Drawing.Point(3, 181);
            this.chkAllowAutoUpdates.Name = "chkAllowAutoUpdates";
            this.chkAllowAutoUpdates.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkAllowAutoUpdates.Size = new System.Drawing.Size(287, 25);
            this.chkAllowAutoUpdates.TabIndex = 8;
            this.chkAllowAutoUpdates.Text = "TXT_ALLOWAUTOUPDATES";
            this.chkAllowAutoUpdates.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // GeneralSettingsPanel
            // 
            this.Controls.Add(this.layoutPanel);
            this.Name = "GeneralSettingsPanel";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(419, 378);
            this.layoutPanel.ResumeLayout(false);
            this.layoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMComboBox cmbLanguages;
        private OPMLabel labelProductName;
        private OPMTableLayoutPanel layoutPanel;
        private OPMLabel labelVersion;
        private OPMLabel labelCopyright;
        private OPMLabel lblSetLanguage;
        private OPMComboBox cmbThemes;
        private OPMLabel kryptonLabel1;
        private OPMCheckBox chkAllowAutoUpdates;
        private OPMButton btnCheckUpdates;
    }
}
