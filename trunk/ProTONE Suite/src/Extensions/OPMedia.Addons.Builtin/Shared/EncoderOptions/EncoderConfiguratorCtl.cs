using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;

namespace OPMedia.Addons.Builtin.Shared.EncoderOptions
{
    public partial class EncoderConfiguratorCtl : OPMBaseControl
    {
        public virtual AudioMediaFormatType OutputFormat
        {
            get
            {
                return AudioMediaFormatType.WAV;
            }
        }

        public EncoderConfiguratorCtl()
        {
            InitializeComponent();
        }
    }
}
