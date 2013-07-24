using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.Addons.AddonsBase.Prop;
using OPMedia.Runtime.ProTONE.ExtendedInfo;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Controls;

namespace OPMedia.Addons.Builtin.Bookmarks
{
    public partial class AddonPanel : PropBaseCtl
    {
        List<string> strItems = null;
        List<object> lbfi = null;

        public override string GetHelpTopic()
        {
            return "BookmarksPropertyPanel";
        }

        public override bool CanHandleFolders
        {
            get
            {
                return false;
            }
        }

        public override List<string> HandledFileTypes
        {
            get
            {
                return new List<string>(new string[] { "bmk" });
            }
        }

        public override int MaximumHandledItems
        {
            get
            {
                return 1;
            }
        }

        public AddonPanel()
        {
            InitializeComponent();
        }

        void AddonPanel_HandleCreated(object sender, EventArgs e)
        {
            Translator.TranslateControl(this, DesignMode);
        }

        public override void ShowProperties(List<string> strItems, object additionalData)
        {
            this.strItems = strItems;
            DoShowProperties();
        }

        private void DoShowProperties()
        {
            lbfi = new List<object>();
            foreach (string item in strItems)
            {
                BookmarkFileInfo bfi = new BookmarkFileInfo(item, false);
                if (bfi.IsValid)
                {
                    lbfi.Add(bfi);
                }
            }

            FileAttributesBrowser.SuppressNonBrowsableAttributes(lbfi);

            pgProperties.SelectedObjects = lbfi.ToArray();
            base.Modified = false;
        }

    }
}
