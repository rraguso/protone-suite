using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.UI.Configuration;
using OPMedia.Core;

using System.Windows.Forms;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.Addons.Configuration;
using OPMedia.UI.ProTONE.Configuration.MiscConfig;

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
            if (ApplicationInfo.IsPlayer)
            {
                AddPanel(typeof(FileTypesPanel), SuiteConfiguration.CurrentUserIsAdministrator);
            }
            else if (ApplicationInfo.IsMediaLibrary)
            {
                AddPanel(typeof(AddonCfgPanel));
                AddPanel(typeof(AddonSettingsPanel));
            }

            //AddPanel(typeof(AudioSettingsPanel));
            //AddPanel(typeof(VideoSettingsPanel));
            AddPanel(typeof(SubtitleSettingsPanel));

            if (ApplicationInfo.IsPlayer)
            {
                //AddPanel(typeof(SchedulerSettingsPanel));

                if (!SuiteConfiguration.CurrentUserIsAdministrator)
                {
                    MessageDisplay.Show(Translator.Translate("TXT_PANELSHIDDEN_NOADMIN"),
                        Translator.Translate("TXT_CAUTION"), MessageBoxIcon.Exclamation);
                }

                AddPanel(typeof(MiscellaneousSettingsPanel));
            }

            AddPanel(typeof(ControlAppPanel));
        }

        public override bool RequiresNetworkConfig()
        {
            return true;
        }

        public override List<BaseCfgPanel> GetControlSubPages()
        {
            if (!SuiteConfiguration.CurrentUserIsAdministrator ||
                !SuiteConfiguration.IsRCCServiceInstalled)
                return null;

            return new List<BaseCfgPanel> 
            { 
                new RemoteControlPage() 
            };
        }

        public override List<BaseCfgPanel> GetTroubleshootingSubPages()
        {
            return new List<BaseCfgPanel> 
            { 
                new DiagnosticsPage() 
            };
        }
    }
}
