using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.ServiceHelper.RCCService;
using OPMedia.Core.TranslationSupport;
using OPMedia.RCCManager.InputData;
using OPMRemoteControl = OPMedia.Runtime.ProTONE.RemoteControl;
using OPMedia.Runtime.Shortcuts;
using OPMedia.ServiceHelper.RCCService.OutputPins;
using OPMedia.UI.Themes;

namespace OPMedia.RCCManager
{
    public partial class ButtonConfigForm : ToolForm
    {
        static string _defTargetWndname = Translator.Translate("TXT_DEFAULTWINDOWNAME");
        bool _createNewButton = false;
        
        private RCCServiceConfig.RemoteButtonsRow _button = null;
        private RCCServiceConfig _config = null;
        private RCCServiceConfig.RemoteControlRow _remoteControl = null;

        public RCCServiceConfig.RemoteControlRow RemoteControl
        {
            get { return _remoteControl; }
            set { _remoteControl = value; }
        }

        public RCCServiceConfig Config
        {
            get { return _config; }
            set { _config = value; }
        }

        public RCCServiceConfig.RemoteButtonsRow Button
        {
            get { return _button; }
            set { _button = value; }
        }

        public ButtonConfigForm()
            : base("TXT_ADDBUTTON")
        {
            InitializeComponent();

            this.IsToolWindow = true;

            this.Shown += new EventHandler(ButtonConfigForm_Load);
        }

        void ButtonConfigForm_Load(object sender, EventArgs e)
        {
            lblWndName.Visible = txtWndname.Visible = (_remoteControl.OutputPinName == typeof(HotkeyOutputPin).Name);
            txtWndname.Text = _defTargetWndname;

            if (_button != null)
            {
                SetTitle(Translator.Translate("TXT_CHANGEBUTTON",  _remoteControl.RemoteName));
                btnOk.Text = Translator.Translate("TXT_MODIFY");
                btnOkAndAgain.Visible = false;
            }
            else
            {
                SetTitle(Translator.Translate("TXT_ADDBUTTON", _remoteControl.RemoteName));

                _button = _config.RemoteButtons.NewRemoteButtonsRow();
                _button.RemoteName = _remoteControl.RemoteName;
                _createNewButton = true;
            }

            cmbOutputData.SelectedIndexChanged -= new System.EventHandler(this.OnNewCommand);
            cmbOutputData.TextChanged -= new System.EventHandler(this.OnNewCommandText);

            txtButtonName.Text = _button.ButtonName;
            txtInputData.Text = _button.InputData;
            txtOutputData.Text = _button.OutputData;
            chkEnabled.Checked = _button.Enabled;
            nudTimedRepeatRate.Value = _button.TimedRepeatRate;

            if (_remoteControl.OutputPinName == typeof(ProTONEOutputPin).Name)
            {
                lblOutputData.Text = Translator.Translate("TXT_PROTONE_REMOTE_COMMAND");
                txtOutputData.Visible = false;
                cmbOutputData.Visible = true;

                cmbOutputData.DisplayMember = "Description";
                cmbOutputData.ValueMember = "CommandString";
                cmbOutputData.DataSource = GetRemoteCommandsData();
                cmbOutputData.SelectedIndex = -1;

                SelectOutputData(true); 
            }
            else
            {
                txtOutputData.Visible = true;
                cmbOutputData.Visible = false;
            }

            cmbOutputData.SelectedIndexChanged += new System.EventHandler(this.OnNewCommand);
            cmbOutputData.TextChanged += new System.EventHandler(this.OnNewCommandText);

            if (_createNewButton)
            {
                btnDetect_Click(null, null);
            }
        }

        private void SelectOutputData(bool initialLoad)
        {
            for (int i = 0; i < cmbOutputData.Items.Count; i++)
            {
                ComboBoxData data = cmbOutputData.Items[i] as ComboBoxData;
                if (data != null && txtOutputData.Text.StartsWith(data.CommandString))
                {
                    cmbOutputData.SelectedIndex = i;

                    if (data.CommandType == OPMRemoteControl.CommandType.KeyPress)
                    {
                        lblKeyPress.Text = _button.OutputData.Replace(data.CommandString + "?", string.Empty);
                        lblKeyPress.Visible = true;
                    }
                    else
                    {
                        lblKeyPress.Visible = false;
                    }

                    return;
                }
            }

            if (initialLoad)
            {
                cmbOutputData.Text = _button.OutputData;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _button.ButtonName = txtButtonName.Text;
            _button.InputData = txtInputData.Text;
            _button.OutputData = txtOutputData.Text;
            _button.Enabled = chkEnabled.Checked;
            _button.TimedRepeatRate = (int)nudTimedRepeatRate.Value;

            if (_remoteControl.OutputPinName == typeof(HotkeyOutputPin).Name)
            {
                _defTargetWndname = _button.TargetWndName = txtWndname.Text;
            }

            if (_createNewButton)
            {
                _config.RemoteButtons.AcceptChanges();
            }
            else if (_remoteControl.RowState != DataRowState.Unchanged)
            {
                _button.AcceptChanges();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_createNewButton)
            {
                _config.RemoteButtons.RejectChanges();
            }
            else if (_remoteControl.RowState != DataRowState.Unchanged)
            {
                _button.RejectChanges();
            }
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            InputDataDetector dlg = 
                new InputDataDetector(_remoteControl.InputPinName, _remoteControl.InputPinCfgData);

            if (dlg.ShowDialog("TXT_PRESSBUTTON") == DialogResult.OK &&
                dlg.DetectedData != null)
            {
                txtInputData.Text = dlg.DetectedData.ToString();
            }

            txtInputData.Focus();
        }

        private List<ComboBoxData> GetRemoteCommandsData()
        {
            List<ComboBoxData> retVal = new List<ComboBoxData>();

            foreach (OPMRemoteControl.CommandType type in Enum.GetValues(typeof(OPMRemoteControl.CommandType)))
            {
                switch (type)
                {
                    case OPMRemoteControl.CommandType.Activate:
                    case OPMRemoteControl.CommandType.Terminate:
                    case OPMRemoteControl.CommandType.KeyPress:
                        retVal.Add(new ComboBoxData(type.ToString(), type.ToString(), type));
                        break;

                    case OPMRemoteControl.CommandType.Playback:
                        {
                            for (OPMShortcut cmd = OPMShortcut.CmdPlay; cmd < OPMShortcut.CmdGenericOpen; cmd++)
                            {
                                string cmdString = string.Format("{0}?{1}", type, cmd);
                                string desc = Translator.Translate("TXT_" + cmd.ToString().ToUpperInvariant());

                                retVal.Add(new ComboBoxData(desc, cmdString, type));
                            }
                        }
                        break;

                    default:
                        continue;
                }
            }

            return retVal;
        }

        private void OnNewCommand(object sender, EventArgs e)
        {
            ComboBoxData data = cmbOutputData.SelectedItem as ComboBoxData;
            if (data != null)
            {
                if (data.CommandType == OPMRemoteControl.CommandType.KeyPress)
                {
                    lblKeyPress.Visible = true;
                    txtOutputData.Text = 
                        "KeyPress?{" + lblKeyPress.Text + "}";
                }
                else
                {
                    lblKeyPress.Visible = false;
                    txtOutputData.Text = data.CommandString;
                }
            }
        }

        private void OnNewCommandText(object sender, EventArgs e)
        {
            ComboBoxData data = cmbOutputData.SelectedItem as ComboBoxData;
            if (data != null)
            {
                return;
            }

            txtOutputData.Text = cmbOutputData.Text;
            SelectOutputData(false);
        }

        private void lblKeyPress_LinkClicked(object sender, EventArgs e)
        {
            KeyPressDefinitionForm frm = new KeyPressDefinitionForm();
            if (frm.ShowDialog(this) == DialogResult.OK && 
                frm.KeyEventArgs != null)
            {
                lblKeyPress.Text =
                    new KeysConverter().ConvertToInvariantString(frm.KeyEventArgs.KeyData);

                txtOutputData.Text = "KeyPress?{" + lblKeyPress.Text + "}";
            }
        }
    }

    public class ComboBoxData
    {
        private string _description;
        public string Description
        { get { return _description; } set { _description = value; } }

        private string _commandString;
        public string CommandString
        { get { return _commandString; } set { _commandString = value; } }

        private OPMRemoteControl.CommandType _cmdType;
        public OPMRemoteControl.CommandType CommandType
        { get { return _cmdType; } set { _cmdType = value; } }

        public ComboBoxData(string description, string commandString, OPMRemoteControl.CommandType cmdType)
        {
            _description = description;
            _commandString = commandString;
            _cmdType = cmdType;
        }
    }
}

