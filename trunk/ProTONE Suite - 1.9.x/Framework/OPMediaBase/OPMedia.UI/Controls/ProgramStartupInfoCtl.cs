using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Controls;
using OPMedia.UI.Dialogs;

namespace OPMedia.UI.Controls
{
    public partial class ProgramStartupInfoCtl : OPMBaseControl
    {
        public event EventHandler InfoChanged = null;
        ProgramStartupInfo _psi = null;

        [DefaultValue(null)]
        public ProgramStartupInfo ProgramStartupInfo
        {
            get { return _psi; }
            set { _psi = value; PopulateFields(); }
        }

        public string GetProgramStartupInfo()
        {
            if (_psi != null)
                return _psi.Serialize();
            else
                return string.Empty;
        }

        private void PopulateFields()
        {
            if (_psi != null)
            {
                lblInfo.Text = _psi.GetDescString();
            }
            else
            {
                lblInfo.Text = Translator.Translate("TXT_DEFINE_PROGRAM");
            }
        }

        public ProgramStartupInfoCtl()
        {
            InitializeComponent();
        }

        private void lblInfo_LinkClicked(object sender, EventArgs e)
        {
            ProgramStartupInfoForm psif = new ProgramStartupInfoForm(_psi);
            if (psif.ShowDialog() == DialogResult.OK)
            {
                this.ProgramStartupInfo = psif.ProgramStartupInfo;
                if (InfoChanged != null)
                {
                    InfoChanged(this, null);
                }
            }
        }
    }
}
