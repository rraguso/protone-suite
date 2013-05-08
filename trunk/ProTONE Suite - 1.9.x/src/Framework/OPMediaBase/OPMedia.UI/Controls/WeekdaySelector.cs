using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime;
using OPMedia.UI.Controls;

using OPMedia.UI.Themes;
using OPMedia.Core.TranslationSupport;

namespace OPMedia.UI.Controls
{
    public partial class WeekdaySelector : OPMBaseControl
    {
        public event EventHandler InfoChanged = null;

        [DefaultValue(typeof(Weekday), "None")]
        public Weekday Weekdays
        {
            get { return CalculateWeekdays(); }
            set { SetWeekdays(value); }
        }

        public WeekdaySelector()
        {
            InitializeComponent();
        }

       

        private void SetWeekdays(Weekday value)
        {
            foreach (Control ctl in pnlCheckboxes.Controls)
            {
                OPMCheckBox chk = ctl as OPMCheckBox;
                if (chk != null)
                {
                    string tag = chk.Tag as string;
                    if (!string.IsNullOrEmpty(tag))
                    {
                        Weekday wdCtl = (Weekday)Enum.Parse(typeof(Weekday), tag);
                        chk.Checked = ((value & wdCtl) == wdCtl);
                    }
                }
            }

            chkAll.Checked = (value == Weekday.Everyday);
        }

        private Weekday CalculateWeekdays()
        {
            Weekday wd = Weekday.None;
            foreach (Control ctl in pnlCheckboxes.Controls)
            {
                OPMCheckBox chk = ctl as OPMCheckBox;
                if (chk != null && chk.Checked)
                {
                    string tag = chk.Tag as string;
                    if (!string.IsNullOrEmpty(tag) )
                    {
                        wd |= (Weekday)Enum.Parse(typeof(Weekday), tag);
                    }
                }
            }

            return wd;
        }

        private void OnDayChecked(object sender, EventArgs e)
        {
            try
            {
                UnsubscribeAll();

                if (sender != chkAll)
                {
                    Weekday wd = CalculateWeekdays();
                    SetWeekdays(wd);
                }
                else
                {
                    SetWeekdays(Weekday.Everyday);
                }
            }
            finally
            {
                if (InfoChanged != null)
                {
                    InfoChanged(this, null);
                }

                SubscribeAll();
            }
        }

        private void SubscribeAll()
        {
            UnsubscribeAll();

            chkMon.CheckedChanged += new System.EventHandler(this.OnDayChecked);
            chkWed.CheckedChanged += new System.EventHandler(this.OnDayChecked);
            chkFri.CheckedChanged += new System.EventHandler(this.OnDayChecked);
            chkSun.CheckedChanged += new System.EventHandler(this.OnDayChecked);
            chkTue.CheckedChanged += new System.EventHandler(this.OnDayChecked);
            chkThu.CheckedChanged += new System.EventHandler(this.OnDayChecked);
            chkSat.CheckedChanged += new System.EventHandler(this.OnDayChecked);
            chkAll.CheckedChanged += new System.EventHandler(this.OnDayChecked);
        }

        private void UnsubscribeAll()
        {
            chkMon.CheckedChanged -= new System.EventHandler(this.OnDayChecked);
            chkWed.CheckedChanged -= new System.EventHandler(this.OnDayChecked);
            chkFri.CheckedChanged -= new System.EventHandler(this.OnDayChecked);
            chkSun.CheckedChanged -= new System.EventHandler(this.OnDayChecked);
            chkTue.CheckedChanged -= new System.EventHandler(this.OnDayChecked);
            chkThu.CheckedChanged -= new System.EventHandler(this.OnDayChecked);
            chkSat.CheckedChanged -= new System.EventHandler(this.OnDayChecked);
            chkAll.CheckedChanged -= new System.EventHandler(this.OnDayChecked);
        }
    }
}
