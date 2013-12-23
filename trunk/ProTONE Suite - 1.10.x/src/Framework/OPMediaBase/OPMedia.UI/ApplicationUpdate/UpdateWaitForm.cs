using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.UI.Dialogs;
using OPMedia.Core.NetworkAccess;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Core;
using System.IO;
using System.Diagnostics;
using OPMedia.Core.Logging;

namespace OPMedia.UI.ApplicationUpdate
{
    public partial class UpdateWaitForm : GenericWaitDialog
    {
        WebFileRetriever _wfr = null;
        string _version = string.Empty;

        public UpdateWaitForm(string version) : base()
        {
            _version = version;

            InitializeComponent();

            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

            StartDownload();

            this.FormClosing += new FormClosingEventHandler(UpdateWaitForm_FormClosing);
        }

        void UpdateWaitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_wfr != null)
            {
                AbortDownload();
            }
        }

        private void StartDownload()
        {
            string file = string.Format("{0} {1}.exe", Constants.SuiteName, _version);
            string fileUri = SuiteConfiguration.DownloadUriBase + "/" + file;
            string tempFile = Path.Combine(Path.GetTempPath(), file);

            Logger.LogInfo("Downloading update file from {0} ...", fileUri);

            _wfr = new WebFileRetriever(AppSettings.ProxySettings, fileUri, tempFile, true);
            _wfr.NewFileRetrieved += new NewFileRetrievedEventHandler(OnDownloadComplete);
        }

        void OnDownloadComplete(string path, bool success, string errorDetails)
        {
            if (success)
            {
                Logger.LogInfo("Update file downloaded succesfully and saved as {0}", path);

                AbortDownload();
                if (LaunchSetup(path))
                {
                    Process.GetCurrentProcess().Kill();
                    Application.Restart();
                }
            }
            else
            {
                Logger.LogInfo("Failed to download update file. Details: ", errorDetails);
                MessageDisplay.Show(errorDetails, "TXT_APP_NAME", MessageBoxIcon.Question);
            }
        }

        private bool LaunchSetup(string path)
        {
            ProcessStartInfo psi = new ProcessStartInfo(path);
            
            psi.Arguments = string.Format("/SILENT /SUPRESSMSGBOXES /APPRESTART \"{0}\"",
                ApplicationInfo.ApplicationLaunchPath);
                
            psi.ErrorDialog = false;
            psi.UseShellExecute = true;
            psi.WorkingDirectory = Path.GetTempPath();

            try
            {
                Process.Start(psi);
                return true;
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
                return false;
            }
        }

        private void AbortDownload()
        {
            if (_wfr != null)
            {
                _wfr.Dispose();
                _wfr = null;
            }
        }
      
    }
}
