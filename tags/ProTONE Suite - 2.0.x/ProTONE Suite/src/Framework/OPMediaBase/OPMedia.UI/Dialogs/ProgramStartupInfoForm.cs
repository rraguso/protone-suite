using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.Runtime;
using OPMedia.Core.TranslationSupport;
using System.IO;
using OPMedia.Core;
using OPMedia.UI.Controls;
using OPMedia.UI.Controls.Dialogs;

namespace OPMedia.UI.Dialogs
{
    public partial class ProgramStartupInfoForm : ToolForm
    {
        ProgramStartupInfo _psi = null;

        public ProgramStartupInfo ProgramStartupInfo
        {
            get { return _psi; }
        }

        public ProgramStartupInfoForm()
            : this(null)
        {
        }

        public ProgramStartupInfoForm(ProgramStartupInfo psi)
            : base("TXT_PROGRAMSTARTUPINFO")
        {
            InitializeComponent();

            _psi = psi;
            PopulateFields();
        }

        void ProgramStartupInfoForm_Load(object sender, EventArgs e)
        {
        }

        private void PopulateFields()
        {
            try
            {
                UnsubscribeAll();

                if (_psi != null)
                {
                    txtLaunchPath.Text = _psi.LaunchPath;
                    txtArguments.Text = _psi.Arguments;
                    txtWorkDir.Text = _psi.WorkDir;
                }
            }
            finally
            {
                SubscribeAll();
            }
        }

        private void OnInfoChanged(object sender, EventArgs e)
        {
            _psi = new ProgramStartupInfo(txtLaunchPath.Text,
                txtArguments.Text, txtWorkDir.Text);

            PopulateFields();
        }

        private void OnChoosePath(object sender, EventArgs e)
        {
            OPMOpenFileDialog dlg = new OPMOpenFileDialog();
            dlg.Filter = Translator.Translate("TXT_PROGRAMS_FILTER");
            dlg.Title = Translator.Translate("TXT_CHOOSEPROGRAM");
            dlg.InitialDirectory = 
                string.IsNullOrEmpty(txtLaunchPath.Text) ? 
                PathUtils.CurrentDir : 
                Path.GetDirectoryName(txtLaunchPath.Text);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtLaunchPath.Text = dlg.FileName;
            }
        }

        private void OnChooseWorkDir(object sender, EventArgs e)
        {
            OPMFolderBrowserDialog fld = new OPMFolderBrowserDialog();
            fld.SelectedPath = txtLaunchPath.Text;
            fld.Description = Translator.Translate("TXT_CHOOSEWORKDIR");

            if (fld.ShowDialog() == DialogResult.OK)
            {
                txtWorkDir.Text = fld.SelectedPath;
            }
        }

        private void SubscribeAll()
        {
            UnsubscribeAll();

            txtArguments.TextChanged += new EventHandler(OnInfoChanged);
            txtLaunchPath.TextChanged += new EventHandler(OnInfoChanged);
            txtWorkDir.TextChanged += new EventHandler(OnInfoChanged);
        }

        private void UnsubscribeAll()
        {
            txtArguments.TextChanged -= new EventHandler(OnInfoChanged);
            txtLaunchPath.TextChanged -= new EventHandler(OnInfoChanged);
            txtWorkDir.TextChanged -= new EventHandler(OnInfoChanged);
        }
    }
}