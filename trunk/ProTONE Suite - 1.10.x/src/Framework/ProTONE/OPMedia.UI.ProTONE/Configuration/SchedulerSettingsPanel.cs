using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;
using OPMedia.Runtime.ProTONE;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime;
using OPMedia.UI.Controls;
using System.Threading;
using OPMedia.Runtime.Shortcuts;
using OPMedia.UI.ProTONE.Properties;
using OPMedia.UI.Themes;
using OPMedia.Core.GlobalEvents;
using OPMedia.UI.ProTONE.GlobalEvents;

namespace OPMedia.UI.ProTONE.Configuration
{
    public partial class SchedulerSettingsPanel : BaseCfgPanel
    {
        public override Image Image
        {
            get
            {
                return Resources.Scheduler;
            }
        }

        public SchedulerSettingsPanel(): base()
        {
            this.Title = "TXT_S_SCHEDULERSETTINGS";
            InitializeComponent();

            ApplyColors();

            this.HandleCreated += new EventHandler(SchedulerSettingsPanel_Load);
        }

        protected override void OnThemeUpdatedInternal()
        {
            base.OnThemeUpdatedInternal();
            ApplyColors();
        }


        public void ApplyColors()
        {
            lblSep1.OverrideBackColor =
            lblSep2.OverrideBackColor = 
            lblSep3.OverrideBackColor = ThemeManager.ForeColor;
        }

        void SchedulerSettingsPanel_Load(object sender, EventArgs e)
        {
            dtpScheduledEvtTime.CustomFormat =
                Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortTimePattern;

            cmbPlaylistEvtHandler.Items.Clear();
            cmbScheduledEvtHandler.Items.Clear();
            foreach (ScheduledActionType act in Enum.GetValues(typeof(ScheduledActionType)))
            {
                string str = string.Format("TXT_ACT_{0}", act.ToString().ToUpperInvariant());
                cmbPlaylistEvtHandler.Items.Add(Translator.Translate(str));
                cmbScheduledEvtHandler.Items.Add(Translator.Translate(str));
            }

            chkEnablePlaylistEvt.Checked = SystemScheduler.PlaylistEventEnabled;

            cmbPlaylistEvtHandler.SelectedIndex = AppSettings.PlaylistEventHandler;
            psiPlaylistEvtData.ProgramStartupInfo = 
                ProgramStartupInfo.FromString(AppSettings.PlaylistEventData);

            chkEnableScheduledEvt.Checked = AppSettings.EnableScheduledEvent;

            cmbScheduledEvtHandler.SelectedIndex = AppSettings.ScheduledEventHandler;
            psiScheduledEvtData.ProgramStartupInfo =
                ProgramStartupInfo.FromString(AppSettings.ScheduledEventData);
            wsScheduledEvtDays.Weekdays = (Weekday)AppSettings.ScheduledEventDays;
            
            dtpScheduledEvtTime.Value = new DateTime(1900, 1, 1,
                AppSettings.ScheduledEventTime.Hours, AppSettings.ScheduledEventTime.Minutes,
                AppSettings.ScheduledEventTime.Seconds);

            nudSchedulerWaitTimerProceed.Value = AppSettings.SchedulerWaitTimerProceed;

            ManageVisibility();
            SubscribeAll();
        }

        protected override void SaveInternal()
        {
            SystemScheduler.PlaylistEventEnabled = chkEnablePlaylistEvt.Checked;
            
            AppSettings.PlaylistEventHandler =  cmbPlaylistEvtHandler.SelectedIndex;
            AppSettings.PlaylistEventData =     psiPlaylistEvtData.GetProgramStartupInfo();

            AppSettings.EnableScheduledEvent =  chkEnableScheduledEvt.Checked;
            AppSettings.ScheduledEventHandler = cmbScheduledEvtHandler.SelectedIndex;
            AppSettings.ScheduledEventData =    psiScheduledEvtData.GetProgramStartupInfo();
            AppSettings.ScheduledEventDays =    (int)wsScheduledEvtDays.Weekdays;
            AppSettings.ScheduledEventTime =    dtpScheduledEvtTime.Value.TimeOfDay;

            AppSettings.SchedulerWaitTimerProceed = (int)nudSchedulerWaitTimerProceed.Value;

            AppSettings.Save();
        }

        private void OnSettingsChanged(object sender, EventArgs e)
        {
            try
            {
                Modified = true;

                if (sender == chkEnablePlaylistEvt)
                {
                    ShortcutMapper.DispatchCommand(OPMShortcut.CmdPlaylistEnd);
                }

                UnsubscribeAll();

                SystemScheduler.PlaylistEventEnabled = chkEnablePlaylistEvt.Checked;
                ManageVisibility();

            }
            finally
            {
                SubscribeAll();
            }
        }

        private void ManageVisibility()
        {
            grpPlaylistEvt.Enabled = chkEnablePlaylistEvt.Checked;
            psiPlaylistEvtData.Visible =
               (cmbPlaylistEvtHandler.SelectedIndex == (int)ScheduledActionType.LaunchProgram);

            grpScheduledEvt.Enabled = chkEnableScheduledEvt.Checked;
            psiScheduledEvtData.Visible =
               (cmbScheduledEvtHandler.SelectedIndex == (int)ScheduledActionType.LaunchProgram);
        }

        private void SubscribeAll()
        {
            UnsubscribeAll();

            wsScheduledEvtDays.InfoChanged += new System.EventHandler(this.OnSettingsChanged);
            psiPlaylistEvtData.InfoChanged += new System.EventHandler(this.OnSettingsChanged);
            cmbPlaylistEvtHandler.SelectedIndexChanged += new System.EventHandler(this.OnSettingsChanged);
            chkEnablePlaylistEvt.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            dtpScheduledEvtTime.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
            psiScheduledEvtData.InfoChanged += new System.EventHandler(this.OnSettingsChanged);
            chkEnableScheduledEvt.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            cmbScheduledEvtHandler.SelectedIndexChanged += new System.EventHandler(this.OnSettingsChanged);
        }

        private void UnsubscribeAll()
        {
            wsScheduledEvtDays.InfoChanged -= new System.EventHandler(this.OnSettingsChanged);
            psiPlaylistEvtData.InfoChanged -= new System.EventHandler(this.OnSettingsChanged);
            cmbPlaylistEvtHandler.SelectedIndexChanged -= new System.EventHandler(this.OnSettingsChanged);
            chkEnablePlaylistEvt.CheckedChanged -= new System.EventHandler(this.OnSettingsChanged);
            dtpScheduledEvtTime.ValueChanged -= new System.EventHandler(this.OnSettingsChanged);
            psiScheduledEvtData.InfoChanged -= new System.EventHandler(this.OnSettingsChanged);
            chkEnableScheduledEvt.CheckedChanged -= new System.EventHandler(this.OnSettingsChanged);
            cmbScheduledEvtHandler.SelectedIndexChanged -= new System.EventHandler(this.OnSettingsChanged);
        }
    }
}
