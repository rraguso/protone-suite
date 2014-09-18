using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;

namespace OPMedia.UI.Dialogs
{
    public partial class OPMFontChooserDialog : ToolForm
    {
        public string Description
        {
            get { return ctlFontChooser.Description; }
            set { ctlFontChooser.Description = value; }
        }

        public Font Font
        {
            get { return ctlFontChooser.Font; }
            set { ctlFontChooser.Font = value; }
        }

        public OPMFontChooserDialog()
        {
            InitializeComponent();
        }
    }
}
