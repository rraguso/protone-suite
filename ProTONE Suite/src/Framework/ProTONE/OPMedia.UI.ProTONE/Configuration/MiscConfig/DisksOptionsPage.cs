using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;
using OPMedia.Core.Configuration;
using OPMedia.Runtime;

using LocalEventNames = OPMedia.UI.ProTONE.GlobalEvents.EventNames;
using OPMedia.Core;
using OPMedia.Core.Utilities;
using OPMedia.UI.Controls;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.ProTONE.Configuration;

namespace OPMedia.UI.ProTONE.Configuration.MiscConfig
{
    public partial class DisksOptionsPage : BaseCfgPanel
    {
        public DisksOptionsPage()
        {
            InitializeComponent();

            this.Load += new EventHandler(OnLoad);

            foreach (var x in Enum.GetValues(typeof(CddaInfoSource)))
            {
                string raw = string.Format("TXT_OPT_{0}", x).ToUpperInvariant();
                cmbAudioCdInfoSource.Items.Add(Translator.Translate(raw));
            }

            cmbAudioCdInfoSource.SelectedIndex = (int)ProTONEConfig.AudioCdInfoSource;
            cbDisableDVDMenu.Checked = ProTONEConfig.DisableDVDMenu;
            txtCddbServerName.Text = ProTONEConfig.CddbServerName;
            txtCddbServerPort.Text = ProTONEConfig.CddbServerPort.ToString();

            txtCddbServerName.Visible = txtCddbServerPort.Visible = lblCddbServerName.Visible = lblCddbServerPort.Visible =
                (ProTONEConfig.AudioCdInfoSource >= CddaInfoSource.Cddb);
        }

        void OnLoad(object sender, EventArgs e)
        {
            cmbAudioCdInfoSource.SelectedIndexChanged += new EventHandler(OnSettingsChanged);
            cbDisableDVDMenu.CheckedChanged += new EventHandler(OnSettingsChanged);
            txtCddbServerName.TextChanged += new EventHandler(OnSettingsChanged);
            txtCddbServerPort.TextChanged += new EventHandler(OnSettingsChanged);
       }

        protected override void SaveInternal()
        {
            ProTONEConfig.DisableDVDMenu = cbDisableDVDMenu.Checked;
            ProTONEConfig.AudioCdInfoSource = (CddaInfoSource)cmbAudioCdInfoSource.SelectedIndex;
            ProTONEConfig.CddbServerName = txtCddbServerName.Text;

            int val = 8880;
            int.TryParse(txtCddbServerPort.Text, out val);
            ProTONEConfig.CddbServerPort = val;
        }

        private void OnSettingsChanged(object sender, EventArgs e)
        {
            Modified = true;

            if (sender == cmbAudioCdInfoSource)
            {
                txtCddbServerName.Visible = txtCddbServerPort.Visible = lblCddbServerName.Visible = lblCddbServerPort.Visible =
                    (cmbAudioCdInfoSource.SelectedIndex >= (int)CddaInfoSource.Cddb);
            }
        }

        
    }


}
