using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.Addons.AddonsBase.Prop;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.Logging;
using OPMedia.UI.Controls;
using OPMedia.Addons.Builtin.Navigation.CatalogExplorer.DataLayer;

namespace OPMedia.Addons.Builtin.CatalogExplorer.CatalogItemPropFE
{
    public partial class AddonPanel : PropBaseCtl
    {
        public override string GetHelpTopic()
        {
            return "CatalogItemPropFE";
        }

        public AddonPanel()
        {
            InitializeComponent();
            this.HandleCreated += new EventHandler(AddonPanel_HandleCreated);
        }

        void AddonPanel_HandleCreated(object sender, EventArgs e)
        {
            Translator.TranslateControl(this, DesignMode);
        }

        public override int MaximumHandledItems
        {
            get
            {
                return 1;
            }
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
                return new List<string>(new string[] { "ctx" });
            }
        }

        public override void ShowProperties(List<string> strItems, object additionalData)
        {
            List<object> lcat = new List<object>();
            foreach (string item in strItems)
            {
                ReadOnlyCatalog cat = new ReadOnlyCatalog(item);
                if (cat.IsValid)
                {
                    lcat.Add(cat);
                }
            }

            FileAttributesBrowser.SuppressSingleSelectionBrowsableAttributes(lcat);

            pgProperties.SelectedObjects = lcat.ToArray();
        }

    }


    public class ReadOnlyCatalog : Catalog
    {
        public ReadOnlyCatalog(string fileName)
            : base(fileName)
        {
        }

        [ReadOnly(true)]
        public new string CatalogDescription
        { get { return Translator.TranslateTaggedString(base.CatalogDescription); } }

        [ReadOnly(true)]
        public new string CatalogSchemaVersion
        { get { return Translator.TranslateTaggedString(base.CatalogSchemaVersion); } }

    }
}
