using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.IO;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.FileInformation;
using System.Reflection;

namespace OPMedia.UI.Controls
{
    public partial class FileAttributesBrowserCtl : UserControl
    {
        IWindowsFormsEditorService _wfes = null;
        public FileAttributes Attributes { get; private set; }

        public FileAttributesBrowserCtl(IWindowsFormsEditorService wfes, FileAttributes attr)
        {
            _wfes = wfes;
            Attributes = attr;

            InitializeComponent();

            Translator.TranslateControl(this, DesignMode);

            chkA.Checked = ((attr & FileAttributes.Archive) == FileAttributes.Archive);
            chkH.Checked = ((attr & FileAttributes.Hidden) == FileAttributes.Hidden);
            chkR.Checked = ((attr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly);
            chkS.Checked = ((attr & FileAttributes.System) == FileAttributes.System);

            chkS.CheckedChanged += new System.EventHandler(this.OnAttrChanged);
            chkR.CheckedChanged += new System.EventHandler(this.OnAttrChanged);
            chkA.CheckedChanged += new System.EventHandler(this.OnAttrChanged);
            chkH.CheckedChanged += new System.EventHandler(this.OnAttrChanged);
        }

        private void OnAttrChanged(object sender, EventArgs e)
        {
            if (chkA.Checked) 
                Attributes |= FileAttributes.Archive;
            else
                Attributes ^= (Attributes & FileAttributes.Archive);

            if (chkH.Checked)
                Attributes |= FileAttributes.Hidden;
            else
                Attributes ^= (Attributes & FileAttributes.Hidden);

            if (chkR.Checked)
                Attributes |= FileAttributes.ReadOnly;
            else
                Attributes ^= (Attributes & FileAttributes.ReadOnly);

            if (chkS.Checked)
                Attributes |= FileAttributes.System;
            else
                Attributes ^= (Attributes & FileAttributes.System);
        }
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
    [PermissionSetAttribute(SecurityAction.InheritanceDemand, Name = "FullTrust")]
    public class FileAttributesBrowser : UITypeEditor
    {
        public FileAttributesBrowser()
            : base()
        {
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null)
            {
                if (context.Instance != null &&
                    context.Instance is NativeFileInfo)
                {
                    return UITypeEditorEditStyle.DropDown;
                }
            }

            return base.GetEditStyle(context);
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                FileAttributesBrowserCtl frm = new FileAttributesBrowserCtl(edSvc, (FileAttributes)value);
                edSvc.DropDownControl(frm);

                return frm.Attributes;
            }

            return value;
        }

        // -----------------
        public static void ProcessObjectAttributes(List<object> lObjects, 
            List<Type> attributeTypesToIgnore = null,
            List<string> categoriesToIgnore = null)
        {
            bool complexFiltering = (categoriesToIgnore != null || attributeTypesToIgnore != null);
            
            if (categoriesToIgnore != null)
            {
                for (int i = 0; i < categoriesToIgnore.Count; i++)
                {
                    categoriesToIgnore[i] = Translator.Translate(categoriesToIgnore[i]);
                }
            }

            if (lObjects.Count > 0)
            {
                bool singleSelection = (lObjects.Count == 1);

                Type targetType = lObjects[0].GetType();

                foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(targetType))
                {
                    if (pd.IsBrowsable == false && complexFiltering)
                        continue;

                    bool shouldPropertyBeSeen = pd.IsBrowsable;

                    // identify attributes that would indicate that the property should be hidden
                    foreach (Attribute attr in pd.Attributes)
                    {
                        if (attr is SingleSelectionBrowsableAttribute)
                        {
                            shouldPropertyBeSeen = singleSelection;
                            shouldPropertyBeSeen &= (attributeTypesToIgnore == null || !attributeTypesToIgnore.Contains(attr.GetType()));
                            break;
                        }

                        bool isOnIgnoreList = false;
                        if (categoriesToIgnore != null)
                        {
                            foreach (string s in categoriesToIgnore)
                            {
                                string s1 = s.ToLowerInvariant();
                                string s2 = Translator.Translate(pd.Category).ToLowerInvariant();

                                if (s1 != null && s2 != null)
                                {
                                    if (s1.Contains(s2) || s2.Contains(s1))
                                    {
                                        isOnIgnoreList = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (isOnIgnoreList)
                        {
                            shouldPropertyBeSeen = false;
                            break;
                        }
                    }

                    UIExtensions.SetAttribute(pd.Name, "browsable", targetType, shouldPropertyBeSeen);

                    if (shouldPropertyBeSeen)
                    {
                        // translation
                        foreach (Attribute attr in pd.Attributes)
                        {
                            if (attr is ITranslatableAttribute)
                            {
                                (attr as ITranslatableAttribute).PerformTranslation(pd);
                            }
                        }
                    }
                }
            }
        }
        // -----------------
    }
}
