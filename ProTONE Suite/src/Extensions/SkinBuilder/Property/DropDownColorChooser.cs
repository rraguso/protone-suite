using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Generic;
using OPMedia.UI.Controls;

namespace SkinBuilder.Property
{
    public partial class DropDownColorChooser : OPMBaseControl, IPropertyChooser
    {
        public event PropertyChangedHandler PropertyChanged = null;

        string _colorString = "255, 255, 255";
        public string PropertyValue
        {
            get { return _colorString; }
            set 
            { 
                _colorString = value;
                ApplyColors();
            }
        }

        private void ApplyColors()
        {
            ColorConverter cc = new ColorConverter();
            Color c = (Color)cc.ConvertFromInvariantString(_colorString);

            opmLabel1.OverrideBackColor = c;
            opmLabel1.OverrideForeColor = ColorHelper.GetContrastingColor(c);
        }

        string _colorName = "[ Choose a name for the color ]";
        public string PropertyName
        {
            get { return _colorName; }
            set 
            { 
                _colorName = value;
                opmLabel1.Text = _colorName;
            }
        }

        public DropDownColorChooser()
        {
            InitializeComponent();
            colorChooser.Description = string.Empty;
            colorChooser.Visible = false;
            this.Leave += new EventHandler(DropDownColorChooser_Leave);
        }

        void DropDownColorChooser_Leave(object sender, EventArgs e)
        {
            colorChooser.Visible = false;
            GetChosenColor();
        }

        private void GetChosenColor()
        {
            ColorConverter cc = new ColorConverter();
            _colorString = cc.ConvertToInvariantString(colorChooser.Color);
            ApplyColors();

            if (PropertyChanged != null)
            {
                PropertyChanged(this, PropertyName, PropertyName);
            }
        }

        private void opmButton1_Click(object sender, EventArgs e)
        {
            colorChooser.Visible ^= true;
            if (colorChooser.Visible)
            {
                colorChooser.Color = opmLabel1.OverrideBackColor;
            }
            else
            {
                GetChosenColor();
            }
        }
    }
}
