using OPMedia.UI.Controls;

using System;
namespace OPMedia.Runtime.Addons.Configuration
{
    partial class AddonCfgPanel
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
            this.lblAddonDesc = new OPMedia.UI.Controls.OPMLabel();
            this.lbl_InstallAddons = new OPMedia.UI.Controls.OPMLinkLabel();
            this.lbl_UninstallAddons = new OPMedia.UI.Controls.OPMLinkLabel();
            this.lblSelectAll = new OPMedia.UI.Controls.OPMLinkLabel();
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.addonList = new OPMedia.Runtime.Addons.Configuration.AddonListCtl();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAddonDesc
            // 
            this.lblAddonDesc.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblAddonDesc, 4);
            this.lblAddonDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddonDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAddonDesc.Location = new System.Drawing.Point(3, 0);
            this.lblAddonDesc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 7);
            this.lblAddonDesc.Name = "lblAddonDesc";
            this.lblAddonDesc.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblAddonDesc.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblAddonDesc.Size = new System.Drawing.Size(340, 39);
            this.lblAddonDesc.TabIndex = 0;
            this.lblAddonDesc.Text = "Available addons.\r\nAvailable addons.\r\nAvailable addons.\r";
            this.lblAddonDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_InstallAddons
            // 
            this.lbl_InstallAddons.AutoSize = true;
            this.lbl_InstallAddons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_InstallAddons.Location = new System.Drawing.Point(196, 300);
            this.lbl_InstallAddons.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lbl_InstallAddons.Name = "lbl_InstallAddons";
            this.lbl_InstallAddons.Size = new System.Drawing.Size(67, 13);
            this.lbl_InstallAddons.TabIndex = 3;
            this.lbl_InstallAddons.TabStop = true;
            this.lbl_InstallAddons.Text = "TXT_INSTALL_ADDONLIB";
            this.lbl_InstallAddons.Click += new System.EventHandler(this.OnInstallAddons);
            // 
            // lbl_UninstallAddons
            // 
            this.lbl_UninstallAddons.AutoSize = true;
            this.lbl_UninstallAddons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_UninstallAddons.Location = new System.Drawing.Point(263, 300);
            this.lbl_UninstallAddons.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lbl_UninstallAddons.Name = "lbl_UninstallAddons";
            this.lbl_UninstallAddons.Size = new System.Drawing.Size(83, 13);
            this.lbl_UninstallAddons.TabIndex = 4;
            this.lbl_UninstallAddons.TabStop = true;
            this.lbl_UninstallAddons.Text = "TXT_UNINSTALL_ADDONLIB";
            this.lbl_UninstallAddons.Click += new System.EventHandler(this.OnUninstallAddons);
            // 
            // lblSelectAll
            // 
            this.lblSelectAll.AutoSize = true;
            this.lblSelectAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectAll.Location = new System.Drawing.Point(0, 300);
            this.lblSelectAll.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblSelectAll.Name = "lblSelectAll";
            this.lblSelectAll.Size = new System.Drawing.Size(80, 13);
            this.lblSelectAll.TabIndex = 2;
            this.lblSelectAll.TabStop = true;
            this.lblSelectAll.Text = "TXT_SELECTALLADDONS";
            this.lblSelectAll.Click += new System.EventHandler(this.OnSelectAll);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lbl_UninstallAddons, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAddonDesc, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.addonList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSelectAll, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_InstallAddons, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(346, 313);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // addonList
            // 
            this.addonList.AutoScroll = true;
            this.addonList.AutoSize = true;
            this.addonList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.addonList, 4);
            this.addonList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addonList.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.addonList.Location = new System.Drawing.Point(0, 46);
            this.addonList.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.addonList.Name = "addonList";
            this.addonList.OverrideBackColor = System.Drawing.Color.Empty;
            this.addonList.Size = new System.Drawing.Size(346, 248);
            this.addonList.TabIndex = 1;
            // 
            // AddonCfgPanel
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AddonCfgPanel";
            this.Size = new System.Drawing.Size(346, 313);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMLabel lblAddonDesc;
        private OPMLinkLabel lbl_InstallAddons;
        private OPMLinkLabel lbl_UninstallAddons;
        private OPMLinkLabel lblSelectAll;
        private OPMTableLayoutPanel tableLayoutPanel1;
        private AddonListCtl addonList;
    }
}
