using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace OPMedia.UI
{
    public static class UIExtensions
    {
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
