using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.UI.Controls;
using System.IO;
using OPMedia.UI.Properties;
using OPMedia.Core.Logging;
using OPMedia.Core.Configuration;
using OPMedia.Core;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.GlobalEvents;
using OPMedia.UI.Controls.Dialogs;

namespace OPMedia.UI.Dialogs
{
    public enum DisplaySeverityLevels
    {
        Trace = 0,
        Info,
        Warning,
        Error,
        Automatic,
    }

    public partial class LogFileConsoleDialog : ThemeForm
    {
        private static LogFileConsoleDialog __instance = null;

        string _logFileName = string.Empty;
        bool _allowChooseLog = false;

        FileSystemWatcher _fsw = null;
        object _fswLock = new object();

        public static Form ShowLogConsole(bool allowChooseLog)
        {
            if (__instance == null)
            {
                __instance = new LogFileConsoleDialog(allowChooseLog);
                __instance.Show();
                __instance.CenterToScreen();
            }

            __instance.BringToFront();

            return __instance;
        }

        public static Form ShowLogConsole()
        {
            if (__instance == null)
            {
                __instance = new LogFileConsoleDialog();
                __instance.Show();
                __instance.CenterToScreen();
            }

            __instance.BringToFront();

            return __instance;
        }

        private LogFileConsoleDialog(bool allowChooseLog)
            : this()
        {
            _allowChooseLog = allowChooseLog;
            this.ShowInTaskbar = _allowChooseLog;
        }

        private LogFileConsoleDialog() : base("TXT_LOGLINECONSOLE")
        {
            _allowChooseLog = false;

            InitializeComponent();

            lvLogLines.GridLines = true;
            cmbLogLineCount.SelectedIndex = 0;

            this.Load += new EventHandler(LogFileConsoleDialog_Load);
            this.HandleDestroyed += new EventHandler(LogLineConsoleDialog_HandleDestroyed);

            Translator.TranslateControl(lvLogLines, DesignMode);
            Translator.TranslateToolStrip(toolStripMain, DesignMode);

            tsbErrors.Image = ImageProvider.GetUser32Icon(User32Icon.Error, false);
            tsbInfo.Image = ImageProvider.GetUser32Icon(User32Icon.Information, false);
            tsbTraces.Image = ImageProvider.GetUser32Icon(User32Icon.Application, false);
            tsbWarnings.Image = ImageProvider.GetUser32Icon(User32Icon.Warning, false);

            tsbErrors.Text = tsbInfo.Text = tsbTraces.Text = tsbWarnings.Text = 
                tsbClearLog.Text = tsbFreezeWindow.Text = tsmiSaveLogFile.ToolTipText  = 
                tsmiSaveWindow.ToolTipText  = string.Empty;

            tsbSave.Text = string.Empty;

            tsbFreezeWindow.Image = Resources.Stop.ToBitmap();
            tsbClearLog.Image = Resources.Delete.Resize(false);

            lblLogFileName.ForeColor = ThemeManager.ForeColor;
            lblLogLineCount.ForeColor = ThemeManager.ForeColor;


            OnLanguageUpdated();
        }


        protected override void OnThemeUpdatedInternal()
        {
            lblLogFileName.ForeColor = ThemeManager.ForeColor;
            lblLogLineCount.ForeColor = ThemeManager.ForeColor;
        }

        [EventSink(EventNames.PerformTranslation)]
        public void OnLanguageUpdated()
        {
            tsbErrors.ToolTipText = Translator.Translate("TXT_FLAG_ERRORS");
            tsbInfo.ToolTipText = Translator.Translate("TXT_FLAG_INFOS");
            tsbTraces.ToolTipText = Translator.Translate("TXT_FLAG_TRACES");
            tsbWarnings.ToolTipText = Translator.Translate("TXT_FLAG_WARNINGS");
            tsbClearLog.ToolTipText = Translator.Translate("TXT_CLEARLOG");
            tsbFreezeWindow.ToolTipText = Translator.Translate("TXT_FREEZEWINDOW");
            tsbSave.ToolTipText = Translator.Translate("TXT_SAVELOGORWINDOW");
            tsmiSaveLogFile.Text = Translator.Translate("TXT_SAVELOGFILE");
            tsmiSaveWindow.Text = Translator.Translate("TXT_SAVEWINDOW");
        }

        void LogLineConsoleDialog_HandleDestroyed(object sender, EventArgs e)
        {
            if (_fsw != null)
            {
                _fsw.Dispose();
                _fsw = null;
            }

            __instance = null;
        }

        void LogFileConsoleDialog_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            ThemeManager.SetFont(lvLogLines, FontSizes.Small);

            tsbWarnings.CheckedChanged -= new System.EventHandler(this.OnSettingsChanged);
            tsbTraces.CheckedChanged -= new System.EventHandler(this.OnSettingsChanged);
            tsbInfo.CheckedChanged -= new System.EventHandler(this.OnSettingsChanged);
            tsbErrors.CheckedChanged -= new System.EventHandler(this.OnSettingsChanged);
            cmbLogLineCount.SelectedIndexChanged -= new System.EventHandler(this.OnSettingsChanged);

            tsbErrors.Checked = AppConfig.FilterErrorLevelEnabled;
            tsbInfo.Checked = AppConfig.FilterInfoLevelEnabled;
            tsbTraces.Checked = AppConfig.FilterTraceLevelEnabled;
            tsbWarnings.Checked = AppConfig.FilterWarningLevelEnabled;

            string text = string.Empty;
            int logLinesCount = AppConfig.FilterLogLinesCount;
            if (logLinesCount > 0 && logLinesCount <= 200)
            {
                text = logLinesCount.ToString();
                _logLineCount = logLinesCount;
            }
            else
            {
                text = "> 200";
                _logLineCount = 0;
            }

            cmbLogLineCount.SelectedIndex = cmbLogLineCount.FindStringExact(text);

            tsbWarnings.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            tsbTraces.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            tsbInfo.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            tsbErrors.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            cmbLogLineCount.SelectedIndexChanged += new System.EventHandler(this.OnSettingsChanged);

            try
            {
                PopulateControls();
                ReadLogFile();
            }
            catch { }

            cmbLogFileNames.Enabled = _allowChooseLog;

            this.Cursor = Cursors.Default;

            lvLogLines_Resize(null, null);
            
        }

        private void lvLogLines_Resize(object sender, EventArgs e)
        {
            hdrText.Width = lvLogLines.Width - SystemInformation.VerticalScrollBarWidth -
                (hdrEntryType.Width + hdrModule.Width + hdrPID.Width + hdrTID.Width + hdrTimeStamp.Width);
        }

        int _logLineCount = 0;

        private void ReadLogFile()
        {
            if (tsbFreezeWindow.Checked)
                return;

            SeverityLevels levels = SeverityLevels.Automatic;
            if (tsbTraces.Checked)
            {
                levels |= (SeverityLevels.Trace | SeverityLevels.HeavyTrace);
            }
            if (tsbInfo.Checked)
            {
                levels |= (SeverityLevels.Info);
            }
            if (tsbWarnings.Checked)
            {
                levels |= (SeverityLevels.Warning);
            }
            if (tsbErrors.Checked)
            {
                levels |= (SeverityLevels.Error | SeverityLevels.Exception);
            }


            List<string> logLines = new List<string>();
            string path = Path.Combine(Logger.GetCurrentLogFolder(), _logFileName);
            logLines = Logger.GetLogFileLines(levels, path, _logLineCount, true);

            try
            {
                MainThread.Post(c => UpdateLogLines(logLines) );
            }
            catch{}
            finally
            {
                lock (_fswLock)
                {
                    if (_fsw != null)
                        _fsw.EnableRaisingEvents = true;
                }
            }
        }

        private void UpdateLogLines(List<string> logLines)
        {
            List<ListViewItem> items = new List<ListViewItem>();

            bool lastItemSelected = (lvLogLines.SelectedItems.Count == 1 &&
                lvLogLines.SelectedItems[0].Index == lvLogLines.Items.Count - 1);

            List<String> extraLines = new List<string>();
            foreach (string line in logLines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                if (line.StartsWith("~~"))
                {
                    string[] fields = line.Split(new char[] { '|', '~' }, StringSplitOptions.RemoveEmptyEntries);
                    if (fields.Length >= (int)LogLineFields.FieldCount)
                    {
                        SeverityLevels entryType = (SeverityLevels)Enum.Parse(typeof(SeverityLevels), fields[(int)LogLineFields.EntryType]);

                        ListViewItem item = new ListViewItem(new string[] { "", "", "", "", "", "" });
                        item.Text = entryType.ToString();
                        item.SubItems[hdrEntryType.Index].Tag = new ExtendedSubItemDetail(GetImage(entryType), string.Empty);

                        item.SubItems[hdrModule.Index].Text = fields[(int)LogLineFields.ModuleName];
                        item.SubItems[hdrPID.Index].Text = fields[(int)LogLineFields.PID];
                        item.SubItems[hdrTID.Index].Text = fields[(int)LogLineFields.TID];
                        item.SubItems[hdrTimeStamp.Index].Text = fields[(int)LogLineFields.Timestamp];
                        item.SubItems[hdrText.Index].Text = fields[(int)LogLineFields.LogText];
                        item.Tag = line;

                        if (extraLines.Count > 0)
                        {
                            int oldItemIndex = items.Count - 1;
                            if (0 <= oldItemIndex && oldItemIndex < items.Count)
                            {
                                string oldTag = items[oldItemIndex].Tag as string;
                                if (!string.IsNullOrEmpty(oldTag))
                                {
                                    extraLines.Insert(0, oldTag);
                                }
                            }

                            items[oldItemIndex].Tag = new List<string>(extraLines);
                            extraLines.Clear();
                        }

                        items.Add(item);
                    }
                }
                else if (items.Count > 0)
                {
                    extraLines.Add(line);
                }
            }

            lvLogLines.Items.Clear();
            lvLogLines.Items.AddRange(items.ToArray());

            if (lastItemSelected && lvLogLines.Items.Count > 1)
            {
                lvLogLines.Items[lvLogLines.Items.Count - 1].Selected = true;
                lvLogLines.Items[lvLogLines.Items.Count - 1].EnsureVisible();
            }
        }

        private void PopulateControls()
        {
            if (_allowChooseLog)
            {
                cmbLogFileNames.Items.Clear();

                IEnumerable<string> logFiles = Directory.EnumerateFiles(Logger.GetCurrentLogFolder(), "*.log", SearchOption.TopDirectoryOnly);
                if (logFiles != null)
                {
                    foreach (string logFile in logFiles)
                    {
                        cmbLogFileNames.Items.Add(Path.GetFileName(logFile));
                    }
                }
            }
            else
            {
                _logFileName = Path.GetFileName(Logger.GetCurrentLogFileName());
                cmbLogFileNames.Items.Add(_logFileName);
            }

           
            cmbLogFileNames.SelectedIndex =
                cmbLogFileNames.FindStringExact(Path.GetFileName(_logFileName));

            this.TopMost = chkKeepOnTop.Checked;
        }

        private void OnSettingsChanged(object sender, EventArgs e)
        {
            AppConfig.FilterErrorLevelEnabled = tsbErrors.Checked;
            AppConfig.FilterInfoLevelEnabled = tsbInfo.Checked;
            AppConfig.FilterTraceLevelEnabled = tsbTraces.Checked;
            AppConfig.FilterWarningLevelEnabled = tsbWarnings.Checked;

            _logLineCount = 0;
            if (int.TryParse(cmbLogLineCount.Text, out _logLineCount))
            {
                AppConfig.FilterLogLinesCount = _logLineCount;
            }
            else
            {
                AppConfig.FilterLogLinesCount = 500;
            }

            AppConfig.Save();

            ReadLogFile();
        }

        private Image GetImage(SeverityLevels level)
        {
            try
            {
                switch (level)
                {
                    case SeverityLevels.Automatic:
                        return ImageProvider.GetShell32Icon(Shell32Icon.AutomaticProcess, false);

                    case SeverityLevels.Error:
                    case SeverityLevels.Exception:
                        return ImageProvider.GetUser32Icon(User32Icon.Error, false);

                    case SeverityLevels.Warning:
                        return ImageProvider.GetUser32Icon(User32Icon.Warning, false);

                    case SeverityLevels.Info:
                        return ImageProvider.GetUser32Icon(User32Icon.Information, false);

                    case SeverityLevels.Trace:
                    case SeverityLevels.HeavyTrace:
                    default:
                        return ImageProvider.GetUser32Icon(User32Icon.Application, false);
                }
            }
            catch
            {
            }

            return null;
        }

        private void OnSaveWindow(object sender, EventArgs e)
        {
            OPMSaveFileDialog dlg = CommonDialogHelper.NewOPMSaveFileDialog();
            dlg.Title = Translator.Translate("TXT_SAVELOGFILE_PART");
            dlg.Filter = Translator.Translate("TXT_LOGFILE_FILTER");
            dlg.DefaultExt = "log";

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                foreach (ListViewItem item in lvLogLines.Items)
                {
                    string line = item.Tag as string;
                    if (!string.IsNullOrEmpty(line))
                    {
                        sb.AppendLine(line);
                    }
                }

                using (StreamWriter sw = new StreamWriter(dlg.FileName))
                {
                    sw.Write(sb.ToString());
                }
            }
        }

        private void OnSaveLogFile(object sender, EventArgs e)
        {
            OPMSaveFileDialog dlg = CommonDialogHelper.NewOPMSaveFileDialog();
            dlg.Title = Translator.Translate("TXT_SAVELOGFILE");
            dlg.Filter = Translator.Translate("TXT_LOGFILE_FILTER");
            dlg.DefaultExt = "log";

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Logger.CopyCurrentLogFile(dlg.FileName);
            }
        }

        private void OnDeleteLogFile(object sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(Logger.GetCurrentLogFolder(), _logFileName);
                Logger.PurgeLogFile(path);
            }
            catch { }

            ReadLogFile();
        }

        private void cmbLogFileNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            _logFileName = cmbLogFileNames.Text;

            lock (_fswLock)
            {
                _fsw = new FileSystemWatcher(Logger.GetCurrentLogFolder());
                _fsw.Filter = _logFileName;
                _fsw.NotifyFilter = NotifyFilters.Size | NotifyFilters.LastWrite;
                _fsw.Changed += new FileSystemEventHandler(OnLogFileChanged);
                _fsw.Created += new FileSystemEventHandler(OnLogFileChanged);
                _fsw.Deleted += new FileSystemEventHandler(OnLogFileChanged);
            }

            ReadLogFile();
        }

        void OnLogFileChanged(object sender, FileSystemEventArgs e)
        {
            ReadLogFile();
        }

        private void lvLogLines_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvLogLines.SelectedItems != null && lvLogLines.SelectedItems.Count > 0)
            {
                string details = null;

                ListViewItem selItem = lvLogLines.SelectedItems[0];
                List<string> extraLines = selItem.Tag as List<string>;
                if (extraLines != null && extraLines.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    extraLines.ForEach(s => sb.AppendLine(s));
                    details = sb.ToString();
                }
                else
                {
                    details = selItem.Tag as string;
                }

                if (string.IsNullOrEmpty(details) == false)
                {
                    new LogFileConsoleDetail(details).ShowDialog(this);
                }
            }
        }
    }
}
