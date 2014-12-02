using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.ServiceHelper.RCCService;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.Logging;
using OPMedia.UI;
using OPMedia.ServiceHelper.RCCService.InputPins;
using OPMedia.ServiceHelper.RCCService.OutputPins;
using OPMedia.UI.Controls;

namespace OPMedia.RCCManager
{
    public partial class RemoteControlConfigForm : ToolForm
    {
        bool _createNewRemote = false;

        private RCCServiceConfig.RemoteControlRow _remoteControl = null;
        private RCCServiceConfig _config = null;

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
        
        public RemoteControlConfigForm() 
            : base("TXT_ADDREMOTECONFIG")
        {
            InitializeComponent();

            this.IsToolWindow = true;

            Translator.TranslateToolStrip(cmsList, DesignMode);
            ThemeManager.SetFont(lvButtons, FontSizes.Small);

            this.Load += new EventHandler(RemoteControlConfigForm_Load);
            lvButtons.DoubleClick += new EventHandler(RemoteControlConfigForm_DoubleClick);

            lvButtons.Resize += new EventHandler(lvButtons_Resize);
        }

        void lvButtons_Resize(object sender, EventArgs e)
        {
            colActionName.Width = 110;
            colEnabled.Width = 50;

            int w = (int)((lvButtons.Width - SystemInformation.VerticalScrollBarWidth - 163) / 3);
            colInputData.Width = w;
            colOutputData.Width = 2 * w;
                
        }

        void RemoteControlConfigForm_DoubleClick(object sender, EventArgs e)
        {
            btnChange_Click(sender, e);
        }

        private void RemoteControlConfigForm_Load(object sender, EventArgs e)
        {
            lvButtons.Font = new Font(ThemeManager.NormalFont.FontFamily,
                ThemeManager.NormalFont.SizeInPoints - 1, GraphicsUnit.Point);

            if (_remoteControl != null)
            {
                SetTitle("TXT_CHANGEEMOTECONFIG");
            }
            else
            {
                _remoteControl = _config.RemoteControl.NewRemoteControlRow();
                _createNewRemote = true;
            }

            txtRemoteName.Text = _remoteControl.RemoteName;
            chkEnabled.Checked = _remoteControl.Enabled;
            
            BuildButtonListFields();
            PopulatePinTypes();
            DisplayPinsData();
            DisplayButtonsData();

            txtRemoteName.TextChanged += new EventHandler(txtRemoteName_TextChanged);
            chkEnabled.CheckedChanged += new EventHandler(chkEnabled_CheckedChanged);
        }

        void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _remoteControl.Enabled = chkEnabled.Checked;
            BuildButtonListFields();
        }

        private void BuildButtonListFields()
        {
            if (_remoteControl.OutputPinName == typeof(HotkeyOutputPin).Name)
            {
                if (!lvButtons.Columns.Contains(colTargetWnd))
                {
                    lvButtons.Columns.Add(colTargetWnd);
                }
            }
            else
            {
                if (lvButtons.Columns.Contains(colTargetWnd))
                {
                    lvButtons.Columns.Remove(colTargetWnd);
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_createNewRemote)
            {
                _config.RemoteControl.AcceptChanges();
            }
            else if (_remoteControl.RowState != DataRowState.Unchanged)
            {
                _remoteControl.AcceptChanges();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_createNewRemote)
            {
                _config.RemoteControl.RejectChanges();
            }
            else if (_remoteControl.RowState != DataRowState.Unchanged)
            {
                _remoteControl.RejectChanges();
            }
        }

        private void PopulatePinTypes()
        {
            cmbInputPins.Items.Clear();
            cmbOutputPins.Items.Clear();

            foreach (KeyValuePair<string, Type> pinData in Pin.AvailableInputPins)
            {
                cmbInputPins.Items.Add(pinData.Key);
            }

            foreach (KeyValuePair<string, Type> pinData in Pin.AvailableOutputPins)
            {
                cmbOutputPins.Items.Add(pinData.Key);
            }
        }

        private void DisplayPinsData()
        {
            if (_remoteControl != null && !_createNewRemote)
            {
                cmbInputPins.SelectedIndex = cmbInputPins.FindStringExact(_remoteControl.InputPinName);
                cmbOutputPins.SelectedIndex = cmbOutputPins.FindStringExact(_remoteControl.OutputPinName);
            }
            else
            {
                cmbInputPins.SelectedIndex = -1;
                cmbOutputPins.SelectedIndex = -1;

                DisplayConfigData(llInputCfgData, string.Empty, string.Empty);
                DisplayConfigData(llOutputCfgData, string.Empty, string.Empty);
            }

            CheckIfButtonsAreConfigurable();
        }

        private void CheckIfButtonsAreConfigurable()
        {
            if (_remoteControl.InputPinName == typeof(RemotingInputPin).Name &&
                _remoteControl.OutputPinName == typeof(ProTONEOutputPin).Name)
            {
                label4.Text = Translator.Translate("TXT_NOBUTTONSREQUIRED");
                lvButtons.Visible = false;
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnChange.Visible = false;
            }
            else
            {
                label4.Text = Translator.Translate("TXT_BUTTONS");
                lvButtons.Visible = true;
                btnAdd.Visible = true;
                btnDelete.Visible = true;
                btnChange.Visible = true;
            }

        }

        private void DisplayConfigData(OPMLinkLabel llCfgData, string pinName, string cfgData)
        {
            bool isConfigurable = Pin.IsPinConfigurable(pinName);
            bool isEmulator = Pin.IsEmulator(pinName);

            llCfgData.Text = 
                (isConfigurable && !isEmulator) ?
                string.IsNullOrEmpty(cfgData) ? Translator.Translate("TXT_NODATA") : cfgData : 
                Translator.Translate("TXT_NOTCFG");
            llCfgData.Tag = isConfigurable ? pinName : string.Empty;

            if (isConfigurable && !isEmulator)
            {
                llCfgData.Links[0].Enabled = true;
                llCfgData.LinkBehavior = LinkBehavior.AlwaysUnderline;
            }
            else
            {
                llCfgData.Links[0].Enabled = false;
                llCfgData.LinkBehavior = LinkBehavior.NeverUnderline;
            }
            
        }

        private void OnInputPinChanged(object sender, EventArgs e)
        {
            _remoteControl.InputPinName = cmbInputPins.Text;
            
            Pin pin = Pin.FindPinByName(_remoteControl.InputPinName);
            if (pin != null && !pin.IsConfigurable && string.IsNullOrEmpty(_remoteControl.InputPinCfgData))
            {
                if (pin is SerialDeviceInputPin)
                {
                    _remoteControl.InputPinCfgData = "COM1;10000;8;10;20";
                }
            }

            DisplayConfigData(llInputCfgData, _remoteControl.InputPinName, _remoteControl.InputPinCfgData);
            CheckIfButtonsAreConfigurable();
        }

        private void OnOutputPinChanged(object sender, EventArgs e)
        {
            _remoteControl.OutputPinName = cmbOutputPins.Text;
            Pin pin = Pin.FindPinByName(_remoteControl.OutputPinName);
            if (pin != null && !pin.IsConfigurable && string.IsNullOrEmpty(_remoteControl.OutputPinCfgData))
            {
                if (pin is LircOutputPin)
                {
                    _remoteControl.OutputPinCfgData = "localhost:8765";
                }
            }

            DisplayConfigData(llOutputCfgData, _remoteControl.OutputPinName, _remoteControl.OutputPinCfgData);
            CheckIfButtonsAreConfigurable();
        }

        private void OnDefineCfgData(object sender, EventArgs e)
        {
            OPMLinkLabel ll = sender as OPMLinkLabel;
            if (ll != null)
            {
                string pinName = ll.Tag as string;
                Pin p = Pin.FindPinByName(pinName);
                if (p != null)
                {
                    if (_remoteControl.InputPinName == pinName)
                    {
                        string newCfgData = p.GetConfigData(_remoteControl.InputPinCfgData);
                        if (newCfgData != null) // null means: config aborted
                        {
                            _remoteControl.InputPinCfgData = newCfgData;
                            OnInputPinChanged(null, null);
                        }
                    }
                    else if (_remoteControl.OutputPinName == pinName)
                    {
                        string newCfgData = p.GetConfigData(_remoteControl.OutputPinCfgData);
                        if (newCfgData != null) // null means: config aborted
                        {
                            _remoteControl.OutputPinCfgData = newCfgData;
                            OnOutputPinChanged(null, null);
                        }
                    }
                }
            }
        }

        private void txtRemoteName_TextChanged(object sender, EventArgs e)
        {
            _remoteControl.RemoteName = txtRemoteName.Text;
        }

        private void DisplayButtonsData()
        {
            lvButtons.Items.Clear();

            var buttonRows = from btn in _config.RemoteButtons
                             where (btn.RemoteName == _remoteControl.RemoteName)
                             select btn;

            if (buttonRows != null)
            {
                foreach (RCCServiceConfig.RemoteButtonsRow buttonRow in buttonRows)
                {
                    string[] data = new string[]
                {
                    buttonRow.ButtonName,
                    Translator.Translate(buttonRow.Enabled ? "TXT_YES" : "TXT_NO"),
                    buttonRow.InputData, 
                    _remoteControl.OutputPinName == (typeof(ProTONEOutputPin)).Name ?
                            CommandMapper.GetCommandDescription(buttonRow.OutputData) :
                            buttonRow.OutputData
                };

                    ListViewItem item = new ListViewItem(data);
                    item.Tag = buttonRow;

                    lvButtons.Items.Add(item);
                }
            }
        }

        private void btnLearn_Click(object sender, EventArgs e)
        {
            
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = lvButtons.SelectedItems.Count > 0 ?
                    lvButtons.SelectedItems[0] : null;

                if (item != null && item.Tag is RCCServiceConfig.RemoteButtonsRow)
                {
                    ButtonConfigForm dlg = new ButtonConfigForm();
                    dlg.Config = _config;
                    dlg.RemoteControl = _remoteControl;
                    dlg.Button = item.Tag as RCCServiceConfig.RemoteButtonsRow;

                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        dlg.Button.AcceptChanges();
                        DisplayButtonsData();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = lvButtons.SelectedItems.Count > 0 ?
                    lvButtons.SelectedItems[0] : null;

                if (item != null && item.Tag is RCCServiceConfig.RemoteButtonsRow &&
                    MessageDisplay.Query(Translator.Translate("TXT_CONFIRMDELETEBUTTON"),
                        Translator.Translate("TXT_CONFIRM"), MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _config.RemoteButtons.RemoveRemoteButtonsRow(item.Tag as RCCServiceConfig.RemoteButtonsRow);
                    _config.RemoteButtons.AcceptChanges();
                    DisplayButtonsData();
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                UseWaitCursor = true;

                while (true)
                {
                    ButtonConfigForm dlg = new ButtonConfigForm();
                    dlg.Config = _config;
                    dlg.RemoteControl = _remoteControl;

                    DialogResult res = dlg.ShowDialog(this);
                    if (res == DialogResult.OK || res == DialogResult.Retry)
                    {
                        _config.RemoteButtons.AddRemoteButtonsRow(dlg.Button);
                        _config.RemoteButtons.AcceptChanges();
                        DisplayButtonsData();
                    }

                    if (res != DialogResult.Retry)
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }

            UseWaitCursor = false;
        }

        private void OnMenuChange(object sender, EventArgs e)
        {
            btnChange_Click(sender, e);
        }

        private void OnMenuDelete(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        }

        private void OnMenuEnable(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = lvButtons.SelectedItems.Count > 0 ?
                    lvButtons.SelectedItems[0] : null;

                if (item != null && item.Tag is RCCServiceConfig.RemoteButtonsRow)
                {
                    bool enabled = (item.Tag as RCCServiceConfig.RemoteButtonsRow).Enabled;
                    (item.Tag as RCCServiceConfig.RemoteButtonsRow).Enabled = !enabled;
                    (item.Tag as RCCServiceConfig.RemoteButtonsRow).AcceptChanges();

                    DisplayButtonsData();
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        private void cmsTree_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                ListViewItem item = lvButtons.SelectedItems.Count > 0 ?
                    lvButtons.SelectedItems[0] : null;

                if (item != null && item.Tag is RCCServiceConfig.RemoteButtonsRow)
                {
                    bool enabled = (item.Tag as RCCServiceConfig.RemoteButtonsRow).Enabled;
                    tsmiEnable.Text = Translator.Translate(enabled ? "TXT_DISABLE" : "TXT_ENABLE");
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }
    }
}