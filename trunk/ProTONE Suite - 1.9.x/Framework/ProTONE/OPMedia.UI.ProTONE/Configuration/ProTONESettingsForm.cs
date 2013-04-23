using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.UI.Configuration;
using OPMedia.Core;

using System.Windows.Forms;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.Addons.Configuration;

namespace OPMedia.UI.ProTONE.Configuration
{
    public class ProTONESettingsForm : SettingsForm
    {


        public new static DialogResult Show()
        {
            ProTONESettingsForm _instance = new ProTONESettingsForm();
            return _instance.ShowDialog();
        }

        public static DialogResult Show(string titleToOpen)
        {
            ProTONESettingsForm _instance = new ProTONESettingsForm(titleToOpen);
            return _instance.ShowDialog();
        }

        protected ProTONESettingsForm(string titleToOpen) : base(titleToOpen)
        {
        }

        public ProTONESettingsForm() : base()
        {
        }
        
        public override void AddAditionalPanels()
        {
            if (ApplicationInfo.IsMediaLibrary)
            {
                AddPanel(typeof(AddonCfgPanel));
                AddPanel(typeof(AddonSettingsPanel));
            }
            else if (ApplicationInfo.IsPlayer)
            {
                AddPanel(typeof(FileTypesPanel), SuiteConfiguration.CurrentUserIsAdministrator);
                AddPanel(typeof(MiscellaneousSettingsPanel));
                AddPanel(typeof(SchedulerSettingsPanel));

                if (!SuiteConfiguration.CurrentUserIsAdministrator)
                {
                    MessageDisplay.Show(Translator.Translate("TXT_PANELSHIDDEN_NOADMIN"),
                        Translator.Translate("TXT_CAUTION"), MessageBoxIcon.Exclamation);
                }
            }

            AddPanel(typeof(SubtitleSettingsPanel));
            AddPanel(typeof(KeyMapCfgPanel));
        }

        public override bool RequiresNetworkConfig()
        {
            return true;
        }
    }
}
