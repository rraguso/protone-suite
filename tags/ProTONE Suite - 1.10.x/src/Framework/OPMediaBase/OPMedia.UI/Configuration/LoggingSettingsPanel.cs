using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Globalization;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Core;
using OPMedia.Core.Logging;
using OPMedia.UI.Themes;
using OPMedia.UI.Properties;
using OPMedia.UI.Dialogs;
using OPMedia.UI.Controls;


namespace OPMedia.UI.Configuration
{
    public partial class LoggingSettingsPanel : BaseCfgPanel
    {
        public override Image Image
        {
            get
            {
                return Resources.Logging.ToBitmap();
            }
        }

        public LoggingSettingsPanel()
            : base()
        {
            this.Title = "TXT_S_LOGGINGSETTINGS";
            InitializeComponent();
            this.HandleCreated += new EventHandler(LoggingSettingsPanel_Load);
        }

        void LoggingSettingsPanel_Load(object sender, EventArgs e)
        {
            chkLogEnabled.Checked = LoggingConfiguration.LoggingEnabled;
            chkTrace.Checked = LoggingConfiguration.TraceLevelEnabled;
            chkInfo.Checked = LoggingConfiguration.InfoLevelEnabled;
            chkWarning.Checked = LoggingConfiguration.WarningLevelEnabled;
            chkError.Checked = LoggingConfiguration.ErrorLevelEnabled;
            
#if HAVE_HEAVY_TRACE
            chkHeavyTrace.Checked = LoggingConfiguration.HeavyTraceLevelEnabled;
            chkHeavyTrace.Visible = true;
            chkHeavyTrace.Enabled = true;
#else
            chkHeavyTrace.Checked = false;
            chkHeavyTrace.Visible = false;
            chkHeavyTrace.Enabled = false;
#endif

            txtLogPath.Text = LoggingConfiguration.LogFilePath;

            nudDaysToKeepLogs.Value = LoggingConfiguration.DaysToKeepLogs;
        }

        protected override void SaveInternal()
        {
            LoggingConfiguration.LoggingEnabled = chkLogEnabled.Checked;
            LoggingConfiguration.HeavyTraceLevelEnabled = chkHeavyTrace.Checked;
            LoggingConfiguration.TraceLevelEnabled = chkTrace.Checked;
            LoggingConfiguration.InfoLevelEnabled = chkInfo.Checked;
            LoggingConfiguration.WarningLevelEnabled = chkWarning.Checked;
            LoggingConfiguration.ErrorLevelEnabled = chkError.Checked;
            LoggingConfiguration.LogFilePath = txtLogPath.Text;
            LoggingConfiguration.DaysToKeepLogs = (int)nudDaysToKeepLogs.Value;

            LoggingConfiguration.SaveConfiguration();

            Modified = false;
        }

        private void chkLogEnabled_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = chkLogEnabled.Checked;
            Modified = true;
        }

        private void OnSettingsChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            OPMFolderBrowserDialog fld = CommonDialogHelper.NewOPMFolderBrowserDialog();
            fld.SelectedPath = txtLogPath.Text;
            fld.Description = Translator.Translate("TXT_CHOOSELOGPATH");

            if (fld.ShowDialog() == DialogResult.OK)
            {
                txtLogPath.Text = fld.SelectedPath;
                Modified = true;
            }
        }

        private void lblViewLog_LinkClicked(object sender, EventArgs e)
        {
            LogFileConsoleDialog.ShowLogConsole();
        }
    }
}
