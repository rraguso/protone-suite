using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Wizards;
using OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Tasks;
using OPMedia.UI.Dialogs;
using System.IO;
using OPMedia.Core.TranslationSupport;

namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Forms
{
    public partial class WizCdRipperStep2 : WizardBaseCtl
    {
        private int selectedPanel = -1;

        List<EncoderConfiguratorCtl> panels = new List<EncoderConfiguratorCtl>();

        public override Size DesiredSize
        {
            get
            {
                return new Size(660, 455);
            }
        }

        public WizCdRipperStep2()
        {
            InitializeComponent();
        }

        protected override void OnPageEnter_MovingNext()
        {
            cmbOutputFormat.Items.Clear();

            AddPanel(new WavEncoderOptionsCtl());

            Mp3EncoderOptionsCtl ctl = new Mp3EncoderOptionsCtl 
            { 
                Task = (BkgTask as Task)
            };

            AddPanel(ctl);

            cmbOutputFormat.SelectedIndex = 0;

            cmbFilePattern.SelectedIndex = 0;

            Wizard.CanFinish = false;

            if (string.IsNullOrEmpty((BkgTask as Task).OutputFolder))
            {
                (BkgTask as Task).OutputFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.MyMusic);
            }

            txtDestFolder.Text = (BkgTask as Task).OutputFolder;

        }

        private void opmButton1_Click(object sender, EventArgs e)
        {
            OPMFolderBrowserDialog dlg = new OPMFolderBrowserDialog();
            dlg.SelectedPath = txtDestFolder.Text;
            dlg.ShowNewFolderButton = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtDestFolder.Text = dlg.SelectedPath;
            }
        }

        private void OnOutputFolderChanged(object sender, EventArgs e)
        {
            (BkgTask as Task).OutputFolder = txtDestFolder.Text;
            CheckFinishButton();
        }

        private void OnFilePatternChanged(object sender, EventArgs e)
        {
            (BkgTask as Task).OutputFilePattern = cmbFilePattern.Text;
            CheckFinishButton();
        }

        private void CheckFinishButton()
        {
            Wizard.CanFinish = Directory.Exists((BkgTask as Task).OutputFolder) &&
                !string.IsNullOrEmpty((BkgTask as Task).OutputFilePattern);
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
            (BkgTask as Task).OutputFormatType = (CdRipperOutputFormatType)cmbOutputFormat.SelectedIndex;
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
                //panel.SetTask(BkgTask as Task);
            }

            selectedPanel = index;
        }
    }
}
