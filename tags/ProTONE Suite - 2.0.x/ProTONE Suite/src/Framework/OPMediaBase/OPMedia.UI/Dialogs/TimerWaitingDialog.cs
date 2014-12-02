using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.Core.TranslationSupport;
using System.IO;
using OPMedia.Core;
using OPMedia.UI.Themes;
using System.Diagnostics;

namespace OPMedia.UI.Dialogs
{
    public partial class TimerWaitingDialog : ToolForm
    {
        Timer _tmrWait = null;
        TimeSpan initialTime = new TimeSpan();
        int _timeToWait = 0;

        public TimerWaitingDialog(string title, string message, int timeToWait)
            : base(title)
        {
            InitializeComponent();

            this.AllowResize = true;

            StartPosition = FormStartPosition.CenterScreen;

            lblNotifyText.Text = message;
            _timeToWait = timeToWait;

            if (_timeToWait <= 0)
                _timeToWait = 1;

            initialTime = DateTime.Now.TimeOfDay;

            _tmrWait = new Timer();
            _tmrWait.Interval = 100;
            _tmrWait.Tick += new EventHandler(_tmrWait_Tick);
            _tmrWait.Start();

            lblTimer.Visible = false;

            this.FormClosing += new FormClosingEventHandler(TimerWaitingDialog_FormClosing);
        }

        void TimerWaitingDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_tmrWait != null)
            {
                try
                {
                    _tmrWait.Stop();
                }
                catch
                {
                }
                finally
                {
                    _tmrWait = null;
                }
            }
        }

        void _tmrWait_Tick(object sender, EventArgs e)
        {
            TimeSpan diff = DateTime.Now.TimeOfDay.Subtract(initialTime);
            if (diff.TotalSeconds >= _timeToWait)
            {
                _tmrWait.Stop();
                _tmrWait = null;

                DialogResult = DialogResult.Yes;
                Close();
                return;
            }

            int percWait = (int)((100 * diff.TotalSeconds) / _timeToWait);
            if (percWait > 100)
                percWait = 100;

            pbWaiting.Value = percWait;

            int remaining = (int)_timeToWait - (int)diff.TotalSeconds;

            if (remaining <= 0)
            {
                lblTimer.Visible = false;
            }
            else
            {
                lblTimer.Visible = true;
                lblTimer.Text = TimeSpan.FromSeconds((int)remaining).ToString();
            }

           
            int x = (SystemInformation.WorkingArea.Width - Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - Height) / 2;

            BringToFront();
            Activate();

            User32.SetWindowPos(this.Handle, User32.GetTopWindow(IntPtr.Zero),
              x, y, Width, Height, SetWindowPosFlags.SWP_NONE);
        }
    }
}