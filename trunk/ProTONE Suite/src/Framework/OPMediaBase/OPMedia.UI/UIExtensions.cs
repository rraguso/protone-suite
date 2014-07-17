using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace OPMedia.UI
{
    public static class UIExtensions
    {
        public static void SuspendLayoutEx(this Control c)
        {
            if (c != null)
            {
                if (c.Controls != null)
                {
                    foreach (Control ctl in c.Controls)
                        SuspendLayoutEx(ctl);
                }

                c.SuspendLayout();
            }
        }

        public static void ResumeLayoutEx(this Control c)
        {
            if (c != null)
            {
                if (c.Controls != null)
                {
                    foreach (Control ctl in c.Controls)
                        ResumeLayoutEx(ctl);
                }

                c.ResumeLayout();
                c.PerformLayout();
            }
        }

        public static void SetAttribute(string propertyName, string attributeInnerName, Type targetType, object value)
        {
            try
            {
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(targetType)[propertyName];
                if (descriptor != null)
                {
                    BrowsableAttribute attribute = (BrowsableAttribute)descriptor.Attributes[typeof(BrowsableAttribute)];
                    if (attribute != null)
                    {
                        FieldInfo fieldToChange = attribute.GetType().GetField(attributeInnerName,
                                                            System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);

                        if (fieldToChange != null)
                        {
                            fieldToChange.SetValue(attribute, value);
                        }
                    }
                }
            }
            catch { }
        }
    }
}
