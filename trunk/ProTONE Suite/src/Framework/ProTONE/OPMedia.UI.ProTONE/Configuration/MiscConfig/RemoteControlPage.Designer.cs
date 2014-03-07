using OPMedia.UI.Controls;
namespace OPMedia.UI.ProTONE.Configuration.MiscConfig
{
    partial class RemoteControlPage
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
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.btnLaunch = new OPMedia.UI.Controls.OPMButton();
            this.chkEnableRemoting = new OPMedia.UI.Controls.OPMCheckBox();
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.btnLaunch, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkEnableRemoting, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(296, 255);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnLaunch
            // 
            this.btnLaunch.AutoSize = true;
            this.btnLaunch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaunch.Location = new System.Drawing.Point(13, 69);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnLaunch.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnLaunch.Size = new System.Drawing.Size(270, 25);
            this.btnLaunch.TabIndex = 2;
            this.btnLaunch.Text = "TXT_LAUNCH_RCCMANAGER";
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // chkEnableRemoting
            // 
            this.chkEnableRemoting.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkEnableRemoting, 3);
            this.chkEnableRemoting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEnableRemoting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEnableRemoting.Location = new System.Drawing.Point(3, 3);
            this.chkEnableRemoting.Name = "chkEnableRemoting";
            this.chkEnableRemoting.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkEnableRemoting.Size = new System.Drawing.Size(290, 17);
            this.chkEnableRemoting.TabIndex = 0;
            this.chkEnableRemoting.Text = "TXT_ENABLEREMOTECONTROL";
            this.chkEnableRemoting.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(0, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(296, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TXT_REMOTECONTROLDEFINITION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RemoteControlPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RemoteControlPage";
            this.Size = new System.Drawing.Size(296, 255);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMTableLayoutPanel tableLayoutPanel1;
        private OPMCheckBox chkEnableRemoting;
        private OPMLabel label1;
        private OPMButton btnLaunch;
    }
}
