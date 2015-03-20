using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Core.TranslationSupport;

namespace OPMedia.Addons.Builtin.Shared.EncoderOptions
{
    public partial class EncoderOptionsCtl : UserControl
    {
        private int selectedPanel = -1;

        public EncoderSettingsContainer EncoderSettings { get; set; }

        List<EncoderConfiguratorCtl> panels = new List<EncoderConfiguratorCtl>();

        public void DisplaySettings()
        {
            InternalDisplaySettings();
        }

        public EncoderOptionsCtl()
        {
            this.EncoderSettings = new EncoderSettingsContainer();
            InitializeComponent();
        }

        private void InternalDisplaySettings()
        {
            cmbOutputFormat.Items.Clear();

            AddPanel(new WavEncoderOptionsCtl());

            Mp3EncoderOptionsCtl ctl = new Mp3EncoderOptionsCtl();
            ctl.Mp3EncoderSettings = EncoderSettings.Mp3EncoderSettings;

            AddPanel(ctl);

            cmbOutputFormat.SelectedIndex = 0;
        }

        private void AddPanel(EncoderConfiguratorCtl panel)
        {
            cmbOutputFormat.Items.Add(panel.OutputFormat);
            panels.Add(panel);
            panel.Visible = false;
            panel.Dock = DockStyle.Fill;
            pnlEncoderOptions.Controls.Add(panel);
        }

        private void OnSelectOutputFormat(object sender, EventArgs e)
        {
            ShowPanel(cmbOutputFormat.SelectedIndex);
            EncoderSettings.AudioMediaFormatType = (AudioMediaFormatType)cmbOutputFormat.SelectedIndex;
        }

        private void ShowPanel(int index)
        {
            foreach (Control ctl in pnlEncoderOptions.Controls)
            {
                ctl.Visible = false;
            }

            EncoderConfiguratorCtl panel = panels[index];
            if (panel != null)
            {
                Translator.TranslateControl(panel, false);
                panel.Visible = true;
            }

            selectedPanel = index;
        }
    }
}
