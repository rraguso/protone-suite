using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using OPMedia.UI.Controls.PropertyEditor.Choosers;
using OPMedia.Core.TranslationSupport;

namespace OPMedia.UI.Controls.PropertyEditor
{
    public partial class OPMPropertyEditor : OPMBaseControl
    {
        public void DisplayProperties(List<object> objects)
        {
            pnlPropertyChoosers.Controls.Clear();
            pnlPropertyChoosers.RowStyles.Clear();

            if (objects == null || objects.Count < 1)
            {
                DisplayNothing();
                return;
            }

            // Determine the browsable properties
            foreach (object obj in objects)
            {
                List<PropertyInfo> browsableProperties = new List<PropertyInfo>();

                BindingFlags bf = BindingFlags.Instance | BindingFlags.Public;
                PropertyInfo[] piList = obj.GetType().GetProperties(bf);
                if (piList != null)
                {
                    foreach (PropertyInfo pi in piList)
                    {
                        bool isBrowsable = true;
                        object[] attributes = pi.GetCustomAttributes(true);
                        if (attributes != null)
                        {
                            foreach (var x in attributes)
                            {
                                BrowsableAttribute ba = x as BrowsableAttribute;
                                if (ba != null)
                                {
                                    isBrowsable = ba.Browsable;
                                    break;
                                }
                            }
                        }

                        if (isBrowsable)
                        {
                            browsableProperties.Add(pi);
                        }
                    }
                }

                foreach (PropertyInfo pi in browsableProperties)
                {
                    IPropertyChooser chooser = CreateChooserForProperty(pi, obj);
                    Control c = chooser as Control;
                    if (c != null)
                    {
                        RowStyle rs = new RowStyle(SizeType.AutoSize, 30);
                        int row = pnlPropertyChoosers.RowStyles.Add(rs);

                        c.Enabled = pi.CanWrite;
                        c.Dock = DockStyle.Fill;
                        pnlPropertyChoosers.Controls.Add(c, 0, row);
                    }
                }
            }

            Translator.TranslateControl(this, DesignMode);
        }

        private void DisplayNothing()
        {
        }

        public OPMPropertyEditor()
        {
            InitializeComponent();
        }

        private IPropertyChooser CreateChooserForProperty(PropertyInfo pi, object target)
        {
            IPropertyChooser chooser = null;

            if (pi.PropertyType == typeof(string))
                chooser = new StringChooser();

            else if (pi.PropertyType.IsEnumType())
                chooser = new EnumeratedTypeChooser(pi.PropertyType);

            else if (pi.PropertyType.IsIntegerType())
                chooser = new IntegerChooser(pi.PropertyType);
            
            else if (pi.PropertyType == typeof(bool))
                chooser = new BooleanChooser();
            
            else
                chooser = new StringChooser();

            if (chooser != null)
            {
                object val = pi.GetValue(target, null);

                TypeConverter tc = new TypeConverter();

                chooser.PropertyName = pi.Name;
                chooser.PropertyValue = val == null ?
                    Translator.Translate("TXT_NA") : tc.ConvertToInvariantString(val);
            }

            return chooser;
        }
    }
}
