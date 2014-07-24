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
    public partial class StringChooser : OPMBaseControl, IPropertyChooser
    {
        public event EventHandler PropertyChanged = null;

        public string PropertyValue
        {
            get { return txtValue.Text; }
            set { txtValue.Text = value;}
        }

        public StringChooser()
        {
            InitializeComponent();
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
