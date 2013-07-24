using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Runtime.Addons.AddonsBase.Prop;
using OPMedia.Runtime.FileInformation;
using System.Reflection;
using OPMedia.UI;
using OPMedia.UI.Controls;

namespace OPMedia.Addons.Builtin.__DefaultProp
{
    public partial class AddonPanel : PropBaseCtl
    {
        public static bool IsRequired { get { return true; } }

        public override string GetHelpTopic()
        {
            return "DefaultPropertyPanel";
        }

        public AddonPanel()
            : base()
        {
            InitializeComponent();
        }

        public override bool CanHandleFolders
        {
            get
            {
                return true;
            }
        }

        public override List<string> HandledFileTypes
        {
            get
            {
                return null;
            }
        }

        public override int MaximumHandledItems
        {
            get
            {
                return -1;
            }
        }

        public override void ShowProperties(List<string> strItems, object additionalData)
        {
            List<object> lofi = new List<object>();

            foreach (string item in strItems)
            {
                NativeFileInfo ofi = new NativeFileInfo(item, false);
                if (ofi.IsValid)
                {
                    lofi.Add(ofi);
                }
            }

            FileAttributesBrowser.SuppressNonBrowsableAttributes(lofi);

            pgProperties.SelectedObjects = lofi.ToArray();
        }
    }
}
