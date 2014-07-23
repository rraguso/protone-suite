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
        public event PropertyChangedHandler PropertyChanged = null;

        public string PropertyName
        {
            get { return opmLabel1.Text; }
            set { opmLabel1.Text = value; }
        }

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
                PropertyChanged(this, PropertyName, PropertyName);
            }
        }
    }
}
