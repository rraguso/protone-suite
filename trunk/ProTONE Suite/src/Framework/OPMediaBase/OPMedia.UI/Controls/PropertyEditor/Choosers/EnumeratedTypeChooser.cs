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
    public partial class EnumeratedTypeChooser : OPMBaseControl, IPropertyChooser
    {
        public event EventHandler PropertyChanged = null;

        EnumConverter ec = null;

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
            get 
            { 
                return ec.ConvertToInvariantString(cmbValue.Text);
            }

            set
            {
                cmbValue.SelectedItem = ec.ConvertFromInvariantString(value);
            }
        }

        public EnumeratedTypeChooser(Type enumType)
        {
            if (enumType.IsEnumType() == false)
                throw new ArgumentException("The parameter enumType must be an Enum type. Nullable Enum types are also accepted. Other types are not allowed.");

            ec = new EnumConverter(enumType);

            InitializeComponent();

            foreach (var val in Enum.GetValues(enumType))
            {
                cmbValue.Items.Add(val);
            }
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
