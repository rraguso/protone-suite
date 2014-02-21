using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using System.IO.Ports;

using OPMedia.Runtime.ServiceHelpers;
using OPMedia.Core;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.Utilities;

namespace OPMedia.UI.Configuration
{
    public partial class UrlCfgDlg : ToolForm
    {
        private string _uri = "";
        public string Uri 
        {
            get { return txtUri.Text; }
            set 
            { 
                _uri = value; 
                DisplayURI();
            }
        }

        public event EventHandler OpenChooser = null;

        public bool ShowChooserButton 
        {
            get { return btnOpenChooser.Visible = true; }
            set { btnOpenChooser.Visible = value; }
        }

        public UriComponents RequiredUriParts { get; set; }

        private bool _jumpToChooser = false;

        public UrlCfgDlg(bool jumpToChooser = false)
            : base("TXT_SPECIFYURL")
        {
            InitializeComponent();

            _jumpToChooser = jumpToChooser;
            if (jumpToChooser)
            {
                this.ShowChooserButton = true;
            }
            else
            {
                this.ShowChooserButton = false;
            }

            this.RequiredUriParts = UriComponents.HostAndPort;

            this.Load += new EventHandler(TcpIpCfgDlg_Load);
        }

        void TcpIpCfgDlg_Load(object sender, EventArgs e)
        {
            DisplayURI();

            if (_jumpToChooser)
            {
                btnOpenChooser_Click(sender, e);
            }
        }

        private void DisplayURI()
        {
            if (string.IsNullOrEmpty(_uri))
            {
                if (MatchFlag(RequiredUriParts, UriComponents.Scheme))
                    _uri += "http://";
                if (MatchFlag(RequiredUriParts, UriComponents.Host))
                    _uri += "server";
                if (MatchFlag(RequiredUriParts, UriComponents.Port))
                    _uri += ":8080";
            }

            txtUri.Text = _uri;
        }

        private bool MatchFlag(UriComponents flags, UriComponents flag)
        {
            return ((flags & flag) == flag);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool valid = false;
            Uri uri = null;

            try
            {
                valid = System.Uri.IsWellFormedUriString(txtUri.Text, UriKind.Absolute);
                if (valid)
                {
                    uri = new Uri(txtUri.Text);
                }

                UriBuilder builder = new UriBuilder(txtUri.Text);
            }
            catch
            {
                valid = false;
            }
          

            if (!valid)
            {
                MessageDisplay.Show(Translator.Translate("TXT_TCPIPINVALIDFORMAT"),
                    Translator.Translate("TXT_CAUTION"), MessageBoxIcon.Warning);
            }
            else
            {
                this.Uri = txtUri.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void btnOpenChooser_Click(object sender, EventArgs e)
        {
            if (OpenChooser != null)
            {
                OpenChooser(sender, e);
            }
        }
    }
}