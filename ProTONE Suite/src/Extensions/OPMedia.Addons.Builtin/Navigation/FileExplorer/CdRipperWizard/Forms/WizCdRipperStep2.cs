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
using OPMedia.Addons.Builtin.Shared.EncoderOptions;

namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Forms
{
    public partial class WizCdRipperStep2 : WizardBaseCtl
    {
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

        protected override void OnPageLeave_Finishing()
        {
            (BkgTask as Task).EncoderSettings = encoderOptionsCtl.EncoderSettings;
        }

        protected override void OnPageEnter_MovingNext()
        {
            cmbFilePattern.SelectedIndex = 0;

            Wizard.CanFinish = false;

            if (string.IsNullOrEmpty((BkgTask as Task).OutputFolder))
            {
                (BkgTask as Task).OutputFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.MyMusic);
            }

            txtDestFolder.Text = (BkgTask as Task).OutputFolder;

            encoderOptionsCtl.EncoderSettings = (BkgTask as Task).EncoderSettings;
            encoderOptionsCtl.DisplaySettings(true);
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


    }
}
