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

        public static void SuppressNonBrowsableAttributes(List<object> lObjects)
        {
            if (lObjects.Count > 0)
            {
                bool singleSelection = (lObjects.Count == 1);

                foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(lObjects[0].GetType()))
                {
                    foreach (Attribute attr in pd.Attributes)
                    {
                        if (typeof(SingleSelectionBrowsableAttribute) == attr.GetType())
                        {
                            UIExtensions.SetAttribute(pd.Name, "browsable", typeof(NativeFileInfo), singleSelection);
                        }
                       

                    }
                }
            }
        }
    }

}
