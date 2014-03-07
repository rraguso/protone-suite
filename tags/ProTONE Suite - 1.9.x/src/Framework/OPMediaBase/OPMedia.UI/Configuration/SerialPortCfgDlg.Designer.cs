
using OPMedia.UI.Controls;
namespace OPMedia.UI.Configuration
{
    partial class SerialPortCfgDlg
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.btnOk = new OPMedia.UI.Controls.OPMButton();
            this.cfgPanel = new OPMedia.UI.Configuration.SerialPortCfgPanel();
            this.pnlPortSettings = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlExtension = new OPMedia.UI.Controls.OPMPanel();
            this.pnlContent.SuspendLayout();
            this.pnlPortSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlPortSettings);
            this.pnlContent.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(170, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "TXT_CANCEL";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.AutoSize = true;
            this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(104, 242);
            this.btnOk.MinimumSize = new System.Drawing.Size(60, 25);
            this.btnOk.Name = "btnOk";
            this.btnOk.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOk.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOk.Size = new System.Drawing.Size(60, 25);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "TXT_OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cfgPanel
            // 
            this.pnlPortSettings.SetColumnSpan(this.cfgPanel, 3);
            this.cfgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cfgPanel.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.cfgPanel.Location = new System.Drawing.Point(0, 0);
            this.cfgPanel.Margin = new System.Windows.Forms.Padding(0);
            this.cfgPanel.Name = "cfgPanel";
            this.cfgPanel.OverrideBackColor = System.Drawing.Color.Empty;
            this.cfgPanel.PortName = "COM1";
            this.cfgPanel.Size = new System.Drawing.Size(253, 209);
            this.cfgPanel.TabIndex = 0;
            // 
            // pnlPortSettings
            // 
            this.pnlPortSettings.ColumnCount = 3;
            this.pnlPortSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlPortSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlPortSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlPortSettings.Controls.Add(this.btnOk, 1, 2);
            this.pnlPortSettings.Controls.Add(this.btnCancel, 2, 2);
            this.pnlPortSettings.Controls.Add(this.cfgPanel, 0, 0);
            this.pnlPortSettings.Controls.Add(this.pnlExtension, 0, 1);
            this.pnlPortSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPortSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlPortSettings.Name = "pnlPortSettings";
            this.pnlPortSettings.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlPortSettings.RowCount = 3;
            this.pnlPortSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlPortSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlPortSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlPortSettings.Size = new System.Drawing.Size(253, 270);
            this.pnlPortSettings.TabIndex = 3;
            // 
            // pnlExtension
            // 
            this.pnlExtension.AutoSize = true;
            this.pnlExtension.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlPortSettings.SetColumnSpan(this.pnlExtension, 3);
            this.pnlExtension.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExtension.Location = new System.Drawing.Point(0, 209);
            this.pnlExtension.Margin = new System.Windows.Forms.Padding(0);
            this.pnlExtension.MinimumSize = new System.Drawing.Size(10, 30);
            this.pnlExtension.Name = "pnlExtension";
            this.pnlExtension.Size = new System.Drawing.Size(253, 30);
            this.pnlExtension.TabIndex = 1;
            // 
            // SerialPortCfgDlg
            // 
            this.ClientSize = new System.Drawing.Size(263, 298);
            this.Name = "SerialPortCfgDlg";
            this.pnlContent.ResumeLayout(false);
            this.pnlPortSettings.ResumeLayout(false);
            this.pnlPortSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected OPMButton btnCancel;
        protected OPMButton btnOk;
        protected SerialPortCfgPanel cfgPanel;
        private OPMTableLayoutPanel pnlPortSettings;
        protected OPMPanel pnlExtension;



    }
}