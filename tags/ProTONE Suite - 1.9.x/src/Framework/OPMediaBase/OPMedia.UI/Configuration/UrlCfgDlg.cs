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
        public string Uri { get; set; }

        public UriComponents RequiredUriParts { get; set; }

        public UrlCfgDlg()
            : base("TXT_SPECIFYURL")
        {
            InitializeComponent();

            this.RequiredUriParts = UriComponents.HostAndPort;

            this.Load += new EventHandler(TcpIpCfgDlg_Load);
        }

        void TcpIpCfgDlg_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Uri))
            {
                if (MatchFlag(RequiredUriParts, UriComponents.Scheme))
                    this.Uri += "http://";
                if (MatchFlag(RequiredUriParts, UriComponents.Host))
                    this.Uri += "server";
                if (MatchFlag(RequiredUriParts, UriComponents.Port))
                    this.Uri += ":8080";
            }

            txtUri.Text = this.Uri;
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

                UriBuilder builder = 
                    new UriBuilder(txtUri.Text);
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
    }
}