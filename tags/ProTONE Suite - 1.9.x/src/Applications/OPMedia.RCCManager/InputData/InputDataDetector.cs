using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.ServiceHelper.RCCService;

using OPMedia.UI.Themes;
using OPMedia.UI.Dialogs;

namespace OPMedia.RCCManager.InputData
{
    public partial class InputDataDetector : GenericWaitDialog
    {
        InputPinProbe _inputPinWatcher = null;

        public string DetectedData { get; private set; }
        
        public InputDataDetector(string inputPinName, string inputPinCfgData) : base()
        {
            InitializeComponent();

            _inputPinWatcher = new InputPinProbe(inputPinName, inputPinCfgData);
            _inputPinWatcher.InputPinData += new InputPinProbeHandler(_inputPinWatcher_InputPinData);

            this.FormClosing += new FormClosingEventHandler(InputDataDetector_FormClosing);
        }

        protected override bool AllowCloseOnEnterOrEscape()
        {
            return true;
        }

        void InputDataDetector_FormClosing(object sender, FormClosingEventArgs e)
        {
            _inputPinWatcher.Stop();
            _inputPinWatcher = null;
        }

        void _inputPinWatcher_InputPinData(InputPin origin, string request)
        {
            if (request != null)
            {
                this.DetectedData = request;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}

