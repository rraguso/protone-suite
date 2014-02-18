using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Runtime;

using LocalEventNames = OPMedia.UI.ProTONE.GlobalEvents.EventNames;
using OPMedia.Core;
using OPMedia.Core.Utilities;
using OPMedia.UI.Controls;
using OPMedia.Core.TranslationSupport;

namespace OPMedia.UI.ProTONE.Configuration.MiscConfig
{
    public partial class DisksOptionsPage : BaseCfgPanel
    {
        public DisksOptionsPage()
        {
            InitializeComponent();

            this.Load += new EventHandler(OnLoad);

            foreach (var x in Enum.GetValues(typeof(OPMedia.Core.ApplicationSettings.AppSettings.CddaInfoSource)))
            {
                string raw = string.Format("TXT_OPT_{0}", x).ToUpperInvariant();
                cmbAudioCdInfoSource.Items.Add(Translator.Translate(raw));
            }

            cmbAudioCdInfoSource.SelectedIndex = (int)AppSettings.AudioCdInfoSource;
            cbDisableDVDMenu.Checked = AppSettings.DisableDVDMenu;
            txtCddbServerName.Text = AppSettings.CddbServerName;
            txtCddbServerPort.Text = AppSettings.CddbServerPort.ToString();

            txtCddbServerName.Visible = txtCddbServerPort.Visible = lblCddbServerName.Visible = lblCddbServerPort.Visible =
                (AppSettings.AudioCdInfoSource >= AppSettings.CddaInfoSource.Cddb);
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
            AppSettings.DisableDVDMenu = cbDisableDVDMenu.Checked;
            AppSettings.AudioCdInfoSource = (AppSettings.CddaInfoSource)cmbAudioCdInfoSource.SelectedIndex;
            AppSettings.CddbServerName = txtCddbServerName.Text;

            int val = 8880;
            int.TryParse(txtCddbServerPort.Text, out val);
            AppSettings.CddbServerPort = val;
        }

        private void OnSettingsChanged(object sender, EventArgs e)
        {
            Modified = true;

            if (sender == cmbAudioCdInfoSource)
            {
                txtCddbServerName.Visible = txtCddbServerPort.Visible = lblCddbServerName.Visible = lblCddbServerPort.Visible =
                    (cmbAudioCdInfoSource.SelectedIndex >= (int)AppSettings.CddaInfoSource.Cddb);
            }
        }

        
    }


}
