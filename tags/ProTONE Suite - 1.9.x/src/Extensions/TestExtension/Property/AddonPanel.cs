using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.Addons.AddonsBase.Prop;

namespace TestExtension.Property
{
    public partial class AddonPanel : PropBaseCtl
    {
        public AddonPanel()
        {
            InitializeComponent();
        }

        public override List<string> HandledFileTypes
        {
            get
            {
                return new List<string>(new string[]{ "abcd", "abc" });
            }
        }
    }
}
