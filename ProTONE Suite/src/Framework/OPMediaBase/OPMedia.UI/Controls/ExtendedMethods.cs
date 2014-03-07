using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using OPMedia.Core;
using System.Runtime.InteropServices;
using OPMedia.UI.Themes;
using System.ComponentModel;

using System.Reflection;

namespace OPMedia.UI.Controls
{
    public static class ExtendedMethods
    {
        public static bool IsOfType(this Control c, Type t)
        {
            return c.GetType() == t || c.GetType().IsSubclassOf(t);
        }

        public static void AddUniqueItem(this ComboBox comboBox, object item)
        {
            if (!comboBox.Items.Contains(item))
            {
                comboBox.Items.Add(item);
            }
        }

        public static string GetText(this DataGridViewCell cell)
        {
            if (cell.Value != null)
                return cell.Value.ToString();

            return string.Empty;
        }

        public static string GetFieldValueAsText(this object target, string fieldName)
        {
            string ret = string.Empty;
            if (target != null)
            {
                if (!string.IsNullOrEmpty(fieldName))
                {
                    PropertyInfo pi = target.GetType().GetProperty(fieldName);
                    if (pi != null)
                    {
                        ret = pi.GetValue(target, null) as string;
                    }
                    else
                    {
                        FieldInfo fi = target.GetType().GetField(fieldName);
                        if (fi != null)
                        {
                            ret = fi.GetValue(target) as string;
                        }
                    }
                }
                else
                {
                    ret = target.ToString();
                }
            }

            if (ret == null)
                ret = string.Empty;

            return ret;
        }
    }
}
