using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using OPMedia.UI.Themes;
using OPMedia.Core.ApplicationSettings;
using OPMedia.UI.Properties;
using OPMedia.Core.TranslationSupport;

namespace OPMedia.UI.Configuration
{
    public partial class ProxySettingsDefinitionCtl : UserControl
    {
        public ProxySettings ProxySettings { get; set; }
        public bool Modified { get; set; }

        public event EventHandler OnDataChanged = null;

        public ProxySettingsDefinitionCtl()
        {
            InitializeComponent();
            this.Load += new EventHandler(OnLoad);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            this.Modified = false;

            if (this.ProxySettings == null)
            {
                this.ProxySettings = ProxySettings.Empty;
            }

            UnsubscribeAll();

            if (AppSettings.ProxySettings.ProxyType > ProxyType.NotDefined)
            {
                this.ProxySettings.ProxyType = AppSettings.ProxySettings.ProxyType;
                this.ProxySettings.ProxyAddress = AppSettings.ProxySettings.ProxyAddress;
                this.ProxySettings.ProxyPassword = AppSettings.ProxySettings.ProxyPassword;
                this.ProxySettings.ProxyPort = AppSettings.ProxySettings.ProxyPort;
                this.ProxySettings.ProxyUser = AppSettings.ProxySettings.ProxyUser;
            }

            LoadProxySettings();
            SubscribeAll();
        }

        private void LoadProxySettings()
        {
            this.cmbProxyType.Items.Add(Translator.Translate("TXT_NOPROXY"));
            this.cmbProxyType.Items.Add(Translator.Translate("TXT_HTTPPROXY"));
            this.cmbProxyType.Items.Add(Translator.Translate("TXT_SOCKS4PROXY"));
            this.cmbProxyType.Items.Add(Translator.Translate("TXT_SOCKS5PROXY"));
            this.cmbProxyType.Items.Add(Translator.Translate("TXT_IEPROXY"));

            cmbProxyType.SelectedIndex = (int)this.ProxySettings.ProxyType;
            txtProxyServer.Text = this.ProxySettings.ProxyAddress;
            txtProxyPort.Text = this.ProxySettings.ProxyPort.ToString();
            txtProxyUser.Text = this.ProxySettings.ProxyUser;
            txtProxyPassword.Text = this.ProxySettings.ProxyPassword;
        }

        private void ApplyProxySettings()
        {
            this.ProxySettings.ProxyType = (ProxyType)cmbProxyType.SelectedIndex;
            this.ProxySettings.ProxyAddress = txtProxyServer.Text;
            int.TryParse(txtProxyPort.Text, out this.ProxySettings.ProxyPort);
            this.ProxySettings.ProxyUser = txtProxyUser.Text;
            this.ProxySettings.ProxyPassword = txtProxyPassword.Text;
        }


        private void OnSettingsChanged(object sender, EventArgs e)
        {
            try
            {
                UnsubscribeAll();
                ApplyProxySettings();
                this.Modified = true;

                if (OnDataChanged != null)
                {
                    OnDataChanged(sender, e);
                }
            }
            finally
            {
                SubscribeAll();
            }
        }

        private void SubscribeAll()
        {
            UnsubscribeAll();

            cmbProxyType.SelectedIndexChanged += new EventHandler(OnSettingsChanged);
            txtProxyServer.TextChanged += new EventHandler(OnSettingsChanged);
            txtProxyPort.TextChanged += new EventHandler(OnSettingsChanged);
            txtProxyUser.TextChanged += new EventHandler(OnSettingsChanged);
            txtProxyPassword.TextChanged += new EventHandler(OnSettingsChanged);
        }

        private void UnsubscribeAll()
        {
            cmbProxyType.SelectedIndexChanged -= new EventHandler(OnSettingsChanged);
            txtProxyServer.TextChanged -= new EventHandler(OnSettingsChanged);
            txtProxyPort.TextChanged -= new EventHandler(OnSettingsChanged);
            txtProxyUser.TextChanged -= new EventHandler(OnSettingsChanged);
            txtProxyPassword.TextChanged -= new EventHandler(OnSettingsChanged);

            bool customSettings = false;
            switch (this.ProxySettings.ProxyType)
            {
                case ProxyType.HttpProxy:
                    customSettings = true;
                    break;
                case ProxyType.Socks4Proxy:
                    customSettings = true;
                    break;
                case ProxyType.Socks5Proxy:
                    customSettings = true;
                    break;
            }

            txtProxyServer.Enabled = customSettings;
            txtProxyPort.Enabled = customSettings;
            txtProxyUser.Enabled = customSettings;
            txtProxyPassword.Enabled = customSettings;

        }
    }
}