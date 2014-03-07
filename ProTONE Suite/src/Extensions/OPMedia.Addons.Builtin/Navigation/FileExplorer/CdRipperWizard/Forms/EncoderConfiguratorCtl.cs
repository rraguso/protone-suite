using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Tasks;

namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Forms
{
    public partial class EncoderConfiguratorCtl : OPMBaseControl
    {
        public virtual CdRipperOutputFormatType OutputFormat
        {
            get
            {
                return CdRipperOutputFormatType.WAV;
            }
        }

        public EncoderConfiguratorCtl()
        {
            InitializeComponent();
        }
    }
}
