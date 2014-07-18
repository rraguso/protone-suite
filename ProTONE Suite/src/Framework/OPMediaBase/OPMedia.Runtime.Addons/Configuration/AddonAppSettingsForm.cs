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
    public class BuiltinAddonAppSettingsForm : SettingsForm
    {
        public new static DialogResult Show()
        {
            BuiltinAddonAppSettingsForm _instance = new BuiltinAddonAppSettingsForm();
            return _instance.ShowDialog();
        }

        public static DialogResult Show(string titleToOpen)
        {
            BuiltinAddonAppSettingsForm _instance = new BuiltinAddonAppSettingsForm(titleToOpen);
            return _instance.ShowDialog();
        }

        protected BuiltinAddonAppSettingsForm(string titleToOpen) 
            : base(titleToOpen)
        {
        }

        public BuiltinAddonAppSettingsForm() : base()
        {
        }

        public override void AddAditionalPanels()
        {
            Translator.RegisterTranslationAssembly(GetType().Assembly);

            AddPanel(typeof(AddonCfgPanel));
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
