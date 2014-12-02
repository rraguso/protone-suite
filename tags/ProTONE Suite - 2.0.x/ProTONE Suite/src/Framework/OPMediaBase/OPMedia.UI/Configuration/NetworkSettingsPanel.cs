using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using OPMedia.UI.Themes;
using OPMedia.Core.Configuration;
using OPMedia.UI.Properties;

namespace OPMedia.UI.Configuration
{
    public partial class NetworkSettingsPanel : BaseCfgPanel
    {
        public override Image Image
        {
            get
            {
                return Resources.Network.ToBitmap();
            }
        }

        public NetworkSettingsPanel() : base()
        {
            this.Title = "TXT_S_NETWORK_SETTINGS";
            InitializeComponent();

            ctlProxy.ProxySettings = ProxySettings.Empty;

            this.HandleCreated += new EventHandler(NetworkSettingsPanel_Load);
            ctlProxy.OnDataChanged += new EventHandler(ctlProxy_OnDataChanged);
        }

        void ctlProxy_OnDataChanged(object sender, EventArgs e)
        {
            this.Modified = true;
        }

        private void NetworkSettingsPanel_Load(object sender, EventArgs e)
        {
            ctlProxy.ProxySettings = AppConfig.ProxySettings;
        }

        protected override void SaveInternal()
        {
            AppConfig.ProxySettings = ctlProxy.ProxySettings;
            AppConfig.Save();
        }

        
    }
}