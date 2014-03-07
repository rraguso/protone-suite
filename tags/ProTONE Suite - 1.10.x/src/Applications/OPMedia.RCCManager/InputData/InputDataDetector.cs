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
using OPMedia.Core;
using System.Threading;

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

        void InputDataDetector_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThreadPool.QueueUserWorkItem((c) =>
                {
                    _inputPinWatcher.Stop();
                    _inputPinWatcher = null;
                });
        }

        void _inputPinWatcher_InputPinData(InputPin origin, string request)
        {
            this.DetectedData = request;
            DialogResult = DialogResult.OK;
            Close();
        }

        protected override bool AllowCloseOnKeyDown(Keys key)
        {
            return (key == Keys.Escape || key == Keys.Enter);
        }
    }
}

