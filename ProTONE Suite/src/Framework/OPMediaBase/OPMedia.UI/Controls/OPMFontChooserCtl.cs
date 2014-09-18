using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OPMedia.UI.Controls
{
    public partial class OPMFontChooserCtl : OPMBaseControl
    {
        public event EventHandler FontChanged = null;

        public string Description { get; set; }

        public Font Font { get; set; }

        public OPMFontChooserCtl()
        {
            InitializeComponent();
            SubscribeEvents();

            // font chooser dialog
            // what to choose ?
            // - font family
            // - font size
            // charset: Eastern Europe, Western, ... etc
            // bold / italic / underline flags
        }

        public void SubscribeEvents()
        {
        }

        public void UnsubscribeEvents()
        {
        }

    }
}
