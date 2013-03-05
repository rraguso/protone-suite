using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.UI.Configuration;
using OPMedia.Core.TranslationSupport;

namespace OPMedia.ServiceHelper.RCCService.Configuration
{
    public class LircCfgDlg : UrlCfgDlg
    {
        public LircCfgDlg()
            : base()
        {
            SetTitle("TXT_DEFINE_LIRC_SERVER");
            label1.Text = Translator.Translate("TXT_LIRC_SERVER_ADDRESS");

            this.Uri = "localhost:8765";
        }

        private void InitializeComponent()
        {
            
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.TabIndex = 1;
            // 
            // LircCfgDlg
            // 
            this.Name = "LircCfgDlg";
            
            this.ResumeLayout(false);

        }

    }
}
