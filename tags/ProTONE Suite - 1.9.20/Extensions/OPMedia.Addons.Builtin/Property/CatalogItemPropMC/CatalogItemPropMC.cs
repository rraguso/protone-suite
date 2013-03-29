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
using OPMedia.Runtime.Addons.AddonsBase;
using OPMedia.Runtime.Addons;

namespace OPMedia.Addons.Builtin.CatalogExplorer.CatalogItemPropMC
{
    public partial class AddonPanel : PropBaseCtl
    {
        Catalog cat = null;

        List<object> lci = null;
        List<string> strItems = null;

        public override string GetHelpTopic()
        {
            return "CatalogItemPropMC";
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
                return new List<string>(new string[] { ":" });
            }
        }

        public override int MaximumHandledItems
        {
            get
            {
                return 1;
            }
        }

        public override void ShowProperties(List<string> strItems, object additionalData)
        {
            this.cat = additionalData as Catalog;
            this.strItems = strItems;

            pgProperties.SelectedObjects = null;

            if (cat != null)
            {
                lci = new List<object>();

                // The objects in strItems are vpaths.
                foreach (string vpath in strItems)
                {
                    if (vpath == Catalog.CatalogVPath)
                    {
                        cat.CatalogSchemaVersion = Translator.TranslateTaggedString(cat.CatalogSchemaVersion);
                        pgProperties.SelectedObjects = new object[] { cat };

                        break;
                    }
                    else
                    {
                        CatalogItem ci = cat.GetByVPath(vpath);
                        if (ci != null)
                        {
                            ci.Description = Translator.TranslateTaggedString(ci.Description).Replace("::", ":");
                            ci.ItemTypeDesc = Translator.TranslateTaggedString(ci.ItemTypeDesc);
                            ci.Save();

                            lci.Add(ci);
                        }
                    }
                }
            }

            if (lci != null && lci.Count > 0)
            {
                FileAttributesBrowser.SuppressSingleSelectionBrowsableAttributes(lci);

                pgProperties.SelectedObjects = lci.ToArray();
            }
        }

        private void pgProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            try
            {
                if (e.ChangedItem.Label.StartsWith(Translator.Translate("TXT_NAME")))
                {
                    AddonHostForm masterForm = FindForm() as AddonHostForm;
                    if (masterForm != null)
                    {
                        masterForm.ReloadNavigation(pgProperties.SelectedObject as CatalogItem);
                    }
                }
            }
            catch { }
        }
    }
}
