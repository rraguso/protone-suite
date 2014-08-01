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
    public partial class IntegerChooser : OPMBaseControl, IPropertyChooser
    {
        public event EventHandler PropertyChanged = null;
        Type baseNumericType = typeof(int);

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
            get { return ((int)opmNumericUpDown1.Value).ToString(); }
            set
            {
                int val = 0;
                if (int.TryParse(value, out val) == false)
                    val = 0;

                opmNumericUpDown1.Value = val;
            }
        }

        public IntegerChooser() : this(typeof(Int32))
        {
        }

        public IntegerChooser(Type integerType)
        {
            if (integerType.IsIntegerType() == false)
                throw new ArgumentException("The parameter integerType must an integer type: byte, short, int, long - signed or unsigned. Nullable integer typpes are also accepted. Other types are not allowed.");

            baseNumericType = integerType;

            InitializeComponent();

            decimal min = int.MinValue, max = int.MaxValue;

            if (integerType == typeof(byte) || integerType == typeof(byte?))
            { min = byte.MinValue; max = byte.MaxValue; }

            else if (integerType == typeof(Int16) || integerType == typeof(Int16?))
            { min = Int16.MinValue; max = Int16.MaxValue; }

            else if (integerType == typeof(UInt16) || integerType == typeof(UInt16?))
            { min = UInt16.MinValue; max = Int16.MaxValue; }

            else if (integerType == typeof(Int32) || integerType == typeof(Int32?))
            { min = Int32.MinValue; max = Int32.MaxValue; }

            else if (integerType == typeof(UInt32) || integerType == typeof(UInt32?))
            { min = UInt32.MinValue; max = UInt32.MaxValue; }

            else if (integerType == typeof(Int64) || integerType == typeof(Int64?))
            { min = Int64.MinValue; max = Int64.MaxValue; }

            else if (integerType == typeof(UInt64) || integerType == typeof(UInt64?))
            { min = UInt64.MinValue; max = UInt64.MaxValue; }

            opmNumericUpDown1.Minimum = min;
            opmNumericUpDown1.Maximum = max;
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
