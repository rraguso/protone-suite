using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Tasks;

namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Forms
{
    public partial class Mp3EncoderOptionsCtl : EncoderConfiguratorCtl
    {
        public override CdRipperOutputFormatType OutputFormat
        {
            get
            {
                return CdRipperOutputFormatType.MP3;
            }
        }

        public Mp3EncoderOptionsCtl()
        {
            InitializeComponent();
        }
    }
}
