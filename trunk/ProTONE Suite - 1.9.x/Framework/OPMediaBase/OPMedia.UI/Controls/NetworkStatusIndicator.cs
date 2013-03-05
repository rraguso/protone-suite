using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Drawing;
using OPMedia.UI.Themes;
using OPMedia.UI.Controls;
using OPMedia.UI.Properties;


namespace OPMedia.UI.Controls
{
    public class NetworkStatusIndicator : UserControl
    {
        private Timer tmrCheckNetwork;
        private OPMLabel label1;
        private PictureBox pictureBox1;
        private System.ComponentModel.IContainer components;

        public bool IsNetworkAccessible
        {
            get
            {
                return NetworkInterface.GetIsNetworkAvailable();
            }
        }

        public NetworkStatusIndicator()
            : base()
        {
            InitializeComponent();

            label1.OverrideForeColor = Color.Red;
            ThemeManager.SetFont(label1, FontSizes.Large);

            tmrCheckNetwork.Enabled = true;
        }
    
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkStatusIndicator));
            this.tmrCheckNetwork = new System.Windows.Forms.Timer(this.components);
            this.label1 = new OPMLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrCheckNetwork
            // 
            this.tmrCheckNetwork.Interval = 1000;
            this.tmrCheckNetwork.Tick += new System.EventHandler(this.tmrCheckNetwork_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.FontSize = OPMedia.UI.Themes.FontSizes.Large;
            this.label1.Location = new System.Drawing.Point(34, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.OverrideForeColor = System.Drawing.Color.Red;
            this.label1.Size = new System.Drawing.Size(245, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_NO_NETWORK";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = Resources.landisconnect;
            this.pictureBox1.InitialImage = Resources.landisconnect;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // NetworkStatusIndicator
            // 
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "NetworkStatusIndicator";
            this.Size = new System.Drawing.Size(279, 35);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void tmrCheckNetwork_Tick(object sender, EventArgs e)
        {
            bool active = IsNetworkAccessible;
            pictureBox1.Visible = !active;
            label1.Visible = !active;
        }
    }
}
