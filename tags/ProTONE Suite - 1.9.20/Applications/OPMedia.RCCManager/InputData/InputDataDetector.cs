using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.ServiceHelper.RCCService;
using OPMedia.Runtime.Remoting;
using OPMedia.UI.Themes;
using OPMedia.UI.Dialogs;

namespace OPMedia.RCCManager.InputData
{
    public partial class InputDataDetector : GenericWaitDialog
    {
        InputPinProbe _inputPinWatcher = null;
        SerializableObject _detectedData = null;

        public SerializableObject DetectedData
        { get { return _detectedData; } }
        
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

        void _inputPinWatcher_InputPinData(InputPin origin, SerializableObject request)
        {
            RemoteString str = request as RemoteString;
            if (str != null)
            {
                _detectedData = request;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}

