using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;

namespace OPMedia.UI.Controls.PropertyEditor.Choosers
{
    public partial class BooleanChooser : OPMBaseControl, IPropertyChooser
    {
        public event EventHandler PropertyChanged = null;

        public string PropertyName
        {
            get { return lblValueName.Text; }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                {
                    lblValueName.Text = value;
                }
            }
        }

        public string PropertyValue
        {
            get { return (chkValue.Checked).ToString(); }
            set
            {
                bool val = false;
                if (bool.TryParse(value, out val) == false)
                    val = false;

                chkValue.Checked = val;
            }
        }

        public BooleanChooser()
        {
            InitializeComponent();
        }

        private void chkValue_CheckedChanged(object sender, EventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
