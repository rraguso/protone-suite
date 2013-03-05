using OPMedia.UI.Controls;
using System.Windows.Forms;

namespace OPMedia.UI.Configuration
{
    partial class SerialPortCfgPanel
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
            this.pgComSettings = new OPMedia.UI.Controls.OPMPropertyGrid();
            this.cmbSerialPort = new OPMedia.UI.Controls.OPMComboBox();
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.layoutPanel = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.layoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgComSettings
            // 
            this.pgComSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutPanel.SetColumnSpan(this.pgComSettings, 2);
            this.pgComSettings.HelpVisible = false;
            this.pgComSettings.Location = new System.Drawing.Point(3, 31);
            this.pgComSettings.Name = "pgComSettings";
            this.pgComSettings.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.pgComSettings.Size = new System.Drawing.Size(280, 143);
            this.pgComSettings.TabIndex = 2;
            this.pgComSettings.ToolbarVisible = false;
            this.pgComSettings.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgComSettings_PropertyValueChanged);
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSerialPort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(205, 3);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbSerialPort.Size = new System.Drawing.Size(78, 23);
            this.cmbSerialPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(196, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_SERIAL_PORT_NAME";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // layoutPanel
            // 
            this.layoutPanel.ColumnCount = 2;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.layoutPanel.Controls.Add(this.label1, 0, 0);
            this.layoutPanel.Controls.Add(this.pgComSettings, 0, 1);
            this.layoutPanel.Controls.Add(this.cmbSerialPort, 1, 0);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.OverrideBackColor = System.Drawing.Color.Empty;
            this.layoutPanel.RowCount = 2;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.Size = new System.Drawing.Size(286, 177);
            this.layoutPanel.TabIndex = 0;
            // 
            // SerialPortCfgPanel
            // 
            this.Controls.Add(this.layoutPanel);
            this.Name = "SerialPortCfgPanel";
            this.Size = new System.Drawing.Size(286, 177);
            this.layoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected OPMPropertyGrid pgComSettings;
        protected OPMLabel label1;
        protected OPMTableLayoutPanel layoutPanel;
        protected OPMComboBox cmbSerialPort;

    }
}
