using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using System.IO.Ports;
using OPMedia.Runtime.ServiceHelpers;
using OPMedia.Core;

namespace OPMedia.UI.Configuration
{
    public partial class SerialPortCfgDlg : ToolForm
    {
        public string PortName
        {
            get { return cfgPanel.PortName; }
            set { cfgPanel.PortName = value; }
        }

        public SerialPortCfgDlg() : base("TXT_SERIALPORTLCFG")
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            cfgPanel.SaveSettings();
        }
    }
}