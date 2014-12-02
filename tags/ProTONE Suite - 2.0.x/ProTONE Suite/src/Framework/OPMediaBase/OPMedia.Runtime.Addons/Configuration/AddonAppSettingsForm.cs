using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.UI.Configuration;
using OPMedia.Core;
using System.Windows.Forms;
using OPMedia.UI;
using OPMedia.Runtime.Addons.AddonsBase;
using OPMedia.Core.TranslationSupport;

namespace OPMedia.Runtime.Addons.Configuration
{
    public class AddonAppSettingsForm : SettingsForm
    {
        public new static DialogResult Show()
        {
            AddonAppSettingsForm _instance = new AddonAppSettingsForm();
            return _instance.ShowDialog();
        }

        public static DialogResult Show(string titleToOpen, string subTitleToOpen = "")
        {
            AddonAppSettingsForm _instance = new AddonAppSettingsForm(titleToOpen, subTitleToOpen);
            return _instance.ShowDialog();
        }

        protected AddonAppSettingsForm(string titleToOpen, string subTitleToOpen) 
            : base(titleToOpen, subTitleToOpen)
        {
        }

        public AddonAppSettingsForm() : base()
        {
        }

        protected virtual bool DissalowAddonConfigPages()
        {
            return false;
        }

        public override void AddAditionalPanels()
        {
            Translator.RegisterTranslationAssembly(GetType().Assembly);

            bool dissalowAddonsConfig = DissalowAddonConfigPages();
            AddPanel(typeof(AddonCfgPanel), !dissalowAddonsConfig);
            AddPanel(typeof(AddonSettingsPanel), !AddonsConfig.IsInitialConfig);
        }

        public override void RemoveUnneededPanels()
        {
            if (AddonsConfig.IsInitialConfig)
            {
                Type typeConfigurator = typeof(AddonCfgPanel);
                KeepPanels(new List<Type>(new Type[] { typeConfigurator }));

                btnCancel.Visible = false;
                btnOk.Location = btnCancel.Location; 
            }
        }

    }
}
