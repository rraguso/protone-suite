using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.UI.Configuration;
using OPMedia.Core;
using System.Windows.Forms;
using OPMedia.UI;
using OPMedia.Runtime.Addons.AddonsBase;

namespace OPMedia.Runtime.Addons.Configuration
{
    public class AddonAppSettingsForm : SettingsForm
    {
        public new static DialogResult Show()
        {
            AddonAppSettingsForm _instance = new AddonAppSettingsForm();
            return _instance.ShowDialog();
        }

        public static DialogResult Show(string titleToOpen)
        {
            AddonAppSettingsForm _instance = new AddonAppSettingsForm(titleToOpen);
            return _instance.ShowDialog();
        }

        protected AddonAppSettingsForm(string titleToOpen) 
            : base(titleToOpen)
        {
        }

        public AddonAppSettingsForm() : base()
        {
        }

        public override void AddAditionalPanels()
        {
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
