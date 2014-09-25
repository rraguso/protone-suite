using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.Core.TranslationSupport;
using System.Threading;
using System.IO;
using OPMedia.Core.Logging;
using OPMedia.Core;
using System.Collections;
using System.Management;
using OPMedia.UI;

namespace OPMedia.Utility
{
    public partial class MainForm : Form
    {
        bool _launchFromUninstaller = false;
        bool _clearLogFiles = false;
        bool _clearUserSettings = false;
        
        public MainForm(bool launchFromUninstaller)
        {
            _launchFromUninstaller = launchFromUninstaller;

            InitializeComponent();
            Translator.TranslateControl(this, DesignMode);

            this.Text = Translator.Translate(launchFromUninstaller ? "TXT_APP_NAME" : "TXT_APP_NAME2");

            btnCancel.Visible = !_launchFromUninstaller;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string msg = Translator.Translate(_launchFromUninstaller ? "TXT_CANCELPROMPT" : "TXT_CANCELPROMPT2");
            DialogResult res = MessageBox.Show(msg, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            DialogResult = (res == DialogResult.Yes) ? DialogResult.Cancel : DialogResult.None;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _clearLogFiles = chkClearLogFiles.Checked;
            _clearUserSettings = chkClearUserSettings.Checked;

            if (_clearLogFiles || _clearUserSettings)
            {
                pnlInput.Visible = false;
                pnlProcess.Visible = true;

                btnNext.Visible = false;
                btnCancel.Enabled = false;

                UpdateProgress(0, "TXT_PREPARING_CLEANUP");
                PerformCleanup();
            }
        }

        private void UpdateProgress(int step, string text)
        {
            lblCurrentOperation.Text = Translator.Translate(text);
            pbProgress.Value = step;
            Application.DoEvents();
        }

        private void PerformCleanup()
        {
            UpdateProgress(1, "TXT_CLEARING_LOG_FILES");

            if (_clearLogFiles)
            {
                ClearLogFiles();
            }

            UpdateProgress(50, "TXT_CLEARING_USER_SETTINGS");

            if (_clearUserSettings)
            {
                ClearUserSettings();
            }

            UpdateProgress(100, "TXT_COMPLETE");
        }

        private void ClearLogFiles()
        {
            try
            {
                if (Directory.Exists(LoggingConfiguration.LogFilePath))
                {
                    List<string> logFiles = new List<string>(Directory.EnumerateFiles(LoggingConfiguration.LogFilePath, "*.log"));
                    if (logFiles.Count > 0)
                    {
                        int stepLen = (int)(50 / logFiles.Count);

                        int val = pbProgress.Value;
                        foreach (string logFile in logFiles)
                        {
                            try
                            {
                                if (File.Exists(logFile))
                                {
                                    val += stepLen;

                                    UpdateProgress(val, Translator.Translate("TXT_DELETE") + ": " + logFile);

                                    FileAttributes attr = File.GetAttributes(logFile);
                                    attr ^= attr;
                                    File.SetAttributes(logFile, attr);
                                    File.Delete(logFile);
                                }
                            }
                            catch
                            {
                            }
                        }
                    }

                    Directory.Delete(LoggingConfiguration.LogFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    Translator.Translate(_launchFromUninstaller ? "TXT_APP_NAME" : "TXT_APP_NAME2"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearUserSettings()
        {
            try
            {
                string userAppDataTemplate = @"{0}\AppData\Local";
                SelectQuery query = new SelectQuery("Select Special, SID, LocalPath from Win32_UserProfile");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                foreach (ManagementObject mo in searcher.Get())
                {
                    try
                    {
                        string special = mo["Special"] as string;
                        if (special != null && special.ToLowerInvariant() == "true")
                            // special account, skip
                            continue;

                        string sid = mo["SID"] as string;
                        if (sid == null || sid.ToLowerInvariant().StartsWith("s-1-5-21") == false)
                            // not an user account, skip
                            continue;

                        string path = mo["LocalPath"] as string;
                        if (path == null)
                            // path to local profile missing, skip
                            continue;

                        string userAppDatapath = string.Format(userAppDataTemplate, path);
                        if (Directory.Exists(userAppDatapath))
                        {
                            ProcessUserAppDataPath(userAppDatapath);
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    Translator.Translate(_launchFromUninstaller ? "TXT_APP_NAME" : "TXT_APP_NAME2"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessUserAppDataPath(string userAppDatapath)
        {
            string[] appSettingsFolders = Directory.GetDirectories(userAppDatapath, "OPMedia*", SearchOption.TopDirectoryOnly);
            foreach (string appSettingsFolder in appSettingsFolders)
            {
                if (Directory.Exists(appSettingsFolder))
                {
                    PathUtils.DeleteFolderTree(appSettingsFolder);
                }
            }
        }
    }
}
