using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.UI.Controls;
using System.Drawing;

namespace SkinBuilder.Property
{
    public class SBColorChooser : OPMColorChooserCtl, IPropertyChooser
    {
        ColorConverter cc = new ColorConverter();

        public event EventHandler PropertyChanged;

        public string PropertyValue
        {
            get 
            {
                return cc.ConvertToInvariantString(base.Color); 
            }
            
            set 
            {
                base.Color = (Color)cc.ConvertFromInvariantString(value);
            }
        }

        public SBColorChooser()
            : base()
        {
            base.Description = string.Empty;
            base.ColorChanged += new EventHandler(SBColorChooser_ColorChanged);
        }

        void SBColorChooser_ColorChanged(object sender, EventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
