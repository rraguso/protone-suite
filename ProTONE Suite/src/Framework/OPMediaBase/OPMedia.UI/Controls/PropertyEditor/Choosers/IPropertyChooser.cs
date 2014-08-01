using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPMedia.UI.Controls.PropertyEditor.Choosers
{
    public interface IPropertyChooser
    {
        string PropertyName { get; set; }
        string PropertyValue { get; set; }
        event EventHandler PropertyChanged;
    }

    public static class ExtendedMethods
    {
        public static bool IsIntegerType(this Type t)
        {
            return (t == typeof(byte) ||
            t == typeof(Int16) ||
            t == typeof(UInt16) ||
            t == typeof(Int32) ||
            t == typeof(UInt32) ||
            t == typeof(Int64) ||
            t == typeof(UInt64) ||

            t == typeof(byte?) ||
            t == typeof(Int16?) ||
            t == typeof(UInt16?) ||
            t == typeof(Int32?) ||
            t == typeof(UInt32?) ||
            t == typeof(Int64?) ||
            t == typeof(UInt64?));
        }

        public static bool IsEnumType(this Type t)
        {
            return (t is Enum);
        }
    }
}
