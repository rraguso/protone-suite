using OPMedia.UI.Controls;
using System.Windows.Forms;
using OPMedia.Core.Configuration;
namespace OPMedia.UI.Configuration
{
    partial class NetworkSettingsPanel
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
            this.ctlProxy = new OPMedia.UI.Configuration.ProxySettingsDefinitionCtl();
            this.networkStatus = new OPMedia.UI.Controls.NetworkStatusIndicator();
            this.SuspendLayout();
            // 
            // ctlProxy
            // 
            this.ctlProxy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlProxy.Location = new System.Drawing.Point(3, 3);
            this.ctlProxy.Modified = false;
            this.ctlProxy.Name = "ctlProxy";
            this.ctlProxy.Size = new System.Drawing.Size(371, 226);
            this.ctlProxy.TabIndex = 1;
            // 
            // networkStatus
            // 
            this.networkStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.networkStatus.Location = new System.Drawing.Point(5, 233);
            this.networkStatus.Margin = new System.Windows.Forms.Padding(0);
            this.networkStatus.Name = "networkStatus";
            this.networkStatus.Size = new System.Drawing.Size(369, 58);
            this.networkStatus.TabIndex = 1;
            // 
            // NetworkSettingsPanel
            // 
            this.Controls.Add(this.networkStatus);
            this.Controls.Add(this.ctlProxy);
            this.Name = "NetworkSettingsPanel";
            this.Size = new System.Drawing.Size(377, 305);
            this.ResumeLayout(false);

        }

        #endregion

        private ProxySettingsDefinitionCtl ctlProxy;
        private NetworkStatusIndicator networkStatus;
    }
}