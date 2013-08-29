using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using RC = OPMedia.Runtime.ProTONE.RemoteControl;
using OPMedia.Runtime.ProTONE.RemoteControl;
using OPMedia.Runtime.Shortcuts;
using OPMedia.Runtime.ProTONE;
using OPMedia.Core.Logging;
using OPMedia.UI.Controls;
using OPMedia.Runtime.InterProcessCommunication;

namespace OPMedia.RemoteControlEmulator
{
    public partial class MainForm : ToolForm
    {
        public MainForm() : base("Remote Control Emulator")
        {
            InitializeComponent();

            this.ShowInTaskbar = true;

            ThemeManager.SetFont(opmGroupBox1, FontSizes.NormalBold);

            this.Load += new EventHandler(MainForm_Load);
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            #region API tester tab

            cmbCommandType.Items.Clear();
            foreach (var item in Enum.GetValues(typeof(RC.CommandType)))
            {
                cmbCommandType.Items.Add(item);
            }

            OPMShortcut[] cmds = new OPMShortcut[]
            {
                OPMShortcut.CmdPlay,
                OPMShortcut.CmdPause,
                OPMShortcut.CmdStop,
                OPMShortcut.CmdPrev,
                OPMShortcut.CmdNext,
        
                // Full Screen
                OPMShortcut.CmdFullScreen,
        
                // Media seek control
                OPMShortcut.CmdFwd,
                OPMShortcut.CmdRew,
        
                // Volume control
                OPMShortcut.CmdVolUp,
                OPMShortcut.CmdVolDn,
            };

            cmbPlaybackCmd.Items.Clear();
            foreach (var item in cmds)
            {
                cmbPlaybackCmd.Items.Add(item);
            }

            cmbCommandType.SelectedIndex = 0;
            cmbDestination.SelectedIndex = 1;

            txtDestinationName.Text = Environment.MachineName;

            #endregion API tester tab

            #region Simulator tab
            int i = 1000;
            foreach (Control ctl in pnlSimulator.Controls)
            {
                OPMButton btn = (ctl as OPMButton);
                if (btn != null)
                {
                    btn.Click += new EventHandler(OnSimulatorClick);
                    btn.Tag = (i++).ToString();
                }

            }
            #endregion
        }

        #region API tester tab

        private void cmbCommandType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPlaybackCmd.Visible = false;
            cmbPlaybackCmd.Visible = false;
            lblSelectFiles.Visible = false;
            pnlSelectFiles.Visible = false;

            RC.CommandType cmdType = (RC.CommandType)cmbCommandType.SelectedIndex;
            if (BasicCommand.RequiresArguments(cmdType))
            {
                switch (cmdType)
                {
                    case RC.CommandType.Playback:
                        lblPlaybackCmd.Visible = true;
                        cmbPlaybackCmd.Visible = true;
                        break;
                }
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            try
            {
                RC.CommandType cmdType = (RC.CommandType)cmbCommandType.SelectedIndex;
                string[] args = null;

                if (BasicCommand.RequiresArguments(cmdType))
                {
                    switch (cmdType)
                    {
                        case RC.CommandType.Playback:
                            args = new string[] { cmbPlaybackCmd.Text };
                            break;
                    }
                }

                string restlt = string.Empty;

                switch (cmbDestination.SelectedIndex)
                {
                    case 0:
                        RemoteControlHelper.SendPlayerCommand(cmdType, args);
                        txtResult.Text = "[ Player commands do not return results. ]";
                        break;

                    case 1:
                        string dest = txtDestinationName.Text;
                        txtResult.Text = RemoteControlHelper.SendServiceCommand(dest, cmdType, args);
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                txtResult.Text = ex.Message;
            }
        }

        #endregion

        #region Simulator tab 
        void OnSimulatorClick(object sender, EventArgs e)
        {
            OPMButton btn = (sender as OPMButton);
            if (btn != null)
            {
                //WmCopyDataSender.SendData("EmulatorInputPin", btn.Tag as string);
                IPCRemoteControlProxy.PostRequest("EmulatorInputPin", btn.Tag as string);
            }

            pnlContent.Select();
            pnlContent.Focus();
        }
        #endregion
    }
}
