using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;

namespace SkinBuilder.Property
{
    public partial class IntegerChooser : OPMBaseControl, IPropertyChooser
    {
        public event EventHandler PropertyChanged = null;

        public string PropertyValue
        {
            get { return ((int)opmNumericUpDown1.Value).ToString(); }
            set
            {
                int val = 0;
                if (int.TryParse(value, out val) == false)
                    val = 0;

                opmNumericUpDown1.Value = val;
            }
        }

        public IntegerChooser()
        {
            InitializeComponent();
        }

        private void opmNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
