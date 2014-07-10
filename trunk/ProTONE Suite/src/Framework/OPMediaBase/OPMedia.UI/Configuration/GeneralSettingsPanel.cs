using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Globalization;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Core;
using OPMedia.Runtime;
using OPMedia.UI.Themes;
using OPMedia.Runtime.AssemblyInfo;
using System.Reflection;
using OPMedia.Core.Logging;
using System.Diagnostics;

using OPMedia.Core.GlobalEvents;
using OPMedia.Core.Utilities;


namespace OPMedia.UI.Configuration
{
    public partial class GeneralSettingsPanel : BaseCfgPanel
    {
        string curLangID = string.Empty;
        string _initialSkinType;

        public override Image Image
        {
            get
            {
                Icon appIcon = ImageProvider.GetAppIcon(true);
                return (appIcon != null) ? appIcon.ToBitmap() : null;
            }
        }

      
        public GeneralSettingsPanel() : base()
        {
            this.Title= "TXT_S_GENERALSETTINGS";
            InitializeComponent();

            #region Languages

            foreach (CultureInfo ci in SuiteConfiguration.SupportedCultures)
            {
                cmbLanguages.Items.Add(new Language(ci.Name));
            }

            curLangID = Translator.GetInterfaceLanguage();
            for (int i = 0; i < cmbLanguages.Items.Count; i++)
            {
                if ((cmbLanguages.Items[i] as Language).ID == curLangID)
                {
                    cmbLanguages.SelectedIndex = i;
                    break;
                }
            }
            this.cmbLanguages.SelectedIndexChanged += new System.EventHandler(this.OnSettingsChanged);
            #endregion

            #region Themes

            cmbThemes.DataSource = ThemeManager.Themes;
            cmbThemes.SelectedItem = SuiteConfiguration.SkinType;
            _initialSkinType = SuiteConfiguration.SkinType;

            this.cmbThemes.SelectedIndexChanged += new System.EventHandler(this.OnThemeChanged);
            #endregion

            labelProductName.Text = String.Format("{0} - {1}", 
                Constants.SuiteName, Translator.Translate("TXT_APP_NAME"));

            labelVersion.Text = Translator.Translate("TXT_VERSION",
                AssemblyInfo.GetVersionNumber(Assembly.GetEntryAssembly()));

            labelCopyright.Text = AssemblyInfo.GetCopyright(Assembly.GetEntryAssembly());

            chkAllowAutoUpdates.Checked = SuiteConfiguration.AllowAutomaticUpdates;
            this.chkAllowAutoUpdates.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
        }

        [EventSink(EventNames.PerformTranslation)]
        public void OnPerformTranslation()
        {
            this.cmbLanguages.SelectedIndexChanged -= new System.EventHandler(this.OnSettingsChanged);
            string curLangID = Translator.GetInterfaceLanguage();
            for (int i = 0; i < cmbLanguages.Items.Count; i++)
            {
                if ((cmbLanguages.Items[i] as Language).ID == curLangID)
                {
                    cmbLanguages.SelectedIndex = i;
                    break;
                }
            }
            this.cmbLanguages.SelectedIndexChanged += new System.EventHandler(this.OnSettingsChanged);
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            string newTheme = cmbThemes.SelectedItem as string;
            if (newTheme != null)
            {
                SuiteConfiguration.SkinType = newTheme;
            	Modified = true;
        	}
        }

        private void OnSettingsChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        protected override void DiscardInternal()
        {
            SuiteConfiguration.SkinType = _initialSkinType;
        }

        protected override void SaveInternal()
        {
            string newID = (cmbLanguages.SelectedItem as Language).ID;
            if (newID != curLangID)
            {
                SuiteConfiguration.LanguageID = newID;
            }

            SuiteConfiguration.AllowAutomaticUpdates = chkAllowAutoUpdates.Checked;

            Modified = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            OnSettingsChanged(sender, e);
            cmbLanguages.Focus();
        }

    
        private void btnCheckUpdates_Click(object sender, EventArgs e)
        {
            EventDispatch.DispatchEvent(EventNames.CheckForUpdates);
        }

       
    }

    
}
