using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.Core.Configuration;
using OPMedia.Core.Logging;
using OPMedia.UI;
using System.Diagnostics;
using OPMedia.Core.TranslationSupport;
using System.IO;
using System.Reflection;

using OPMedia.Core;
using OPMedia.Core.InstanceManagement;
using System.Security.AccessControl;
using System.Threading;
using OPMedia.Runtime.Addons.AddonsBase;
using OPMedia.UI.Themes;
using OPMedia.UI.Configuration;
using OPMedia.Runtime.Addons.Properties;
using OPMedia.UI.Controls;
using OPMedia.UI.Controls.Dialogs;

namespace OPMedia.Runtime.Addons.Configuration
{
    public partial class AddonCfgPanel : BaseCfgPanel
    {
        Dictionary<string, bool> _addonConfigurationTable = new Dictionary<string, bool>();

        public override Image Image
        {
            get
            {
                return Resources.Addons;
            }
        }

        public AddonCfgPanel() : base()
        {
            this.Title = "TXT_S_ADDONSETTINGS";
            InitializeComponent();

            lbl_UninstallAddons.Enabled = false;
            addonList.SelectedAddonLibraryChanged += new SelectedAddonLibraryChangedHandler(addonList_SelectedAddonLibraryChanged);

            if (AddonsConfig.IsInitialConfig)
            {
                lblAddonDesc.Text = Translator.Translate("TXT_ADDONSLIST_NORESTART");
                lblAddonDesc.OverrideForeColor = Color.LightCoral;
            }
            else
            {
                lblAddonDesc.Text = Translator.Translate("TXT_ADDONSLIST");
                lblAddonDesc.OverrideForeColor = Color.Empty;
            }

            this.HandleCreated += new EventHandler(AddonCfgPanel_HandleCreated);
        }

        void addonList_SelectedAddonLibraryChanged(AddonLibraryInfo selectedAddonLibrary)
        {
            lbl_UninstallAddons.Enabled = (selectedAddonLibrary != null && !selectedAddonLibrary.IsNative);
        }

        void AddonCfgPanel_HandleCreated(object sender, EventArgs e)
        {
            Translator.TranslateControl(this, DesignMode);
            Application.DoEvents();
            
            ReloadConfig();
            Modified = true;
        }

        void ReloadConfig()
        {
            AddonDetector.Scan();
            LoadAvailableAddons();
        }

        private AddonInfo ConstructAddonInfo(string addon)
        {
            string detectedCodebase = AddonDetector.GetAssemblyInfo(addon);
            string configuredCodebase = AddonsConfig.GetAssemblyInfo(addon);
            bool selected = (detectedCodebase == configuredCodebase);
            bool isRequired = AddonDetector.IsRequiredAddon(addon);

            return new AddonInfo(addon, detectedCodebase, selected, isRequired);
        }

        private List<AddonInfo> BuildAddonList(string[] addons)
        {
            List<AddonInfo> addonList = new List<AddonInfo>();
            foreach (string addon in addons)
            {
                AddonInfo ai = ConstructAddonInfo(addon);
                addonList.Add(ai);

                _addonConfigurationTable.Add(ai.Name, ai.Selected);
            }

            return addonList;
        }

        private void LoadAvailableAddons()
        {
            _addonConfigurationTable.Clear();

            addonList.NavigationAddons = BuildAddonList(AddonDetector.NavigationAddons);
            addonList.PropertyAddons = BuildAddonList(AddonDetector.PropertyAddons);
            addonList.PreviewAddons = BuildAddonList(AddonDetector.PreviewAddons);
        }

        private bool IsConfigurationChanged()
        {
            if (_uninstallScheduled)
                return true;

            foreach (AddonInfo ai in addonList.AllAddons)
            {
                if (_addonConfigurationTable.ContainsKey(ai.Name))
                {
                    bool addedToSaveList = _addonConfigurationTable[ai.Name];
                    bool requiresSave = ai.Selected || ai.IsRequired;

                    if (addedToSaveList != requiresSave)
                    {
                        // At least one addon chaged.
                        return true;
                    }
                }
            }

            return false;
        }

        protected override void SaveInternal()
        {
            if (GetEnabledAddonCount(addonList.NavigationAddons) > 0)
            {
                if (!IsConfigurationChanged())
                {
                    //Nothing changed, therefore nothing is to be saved.
                    return;
                }

                if (AddonsConfig.IsInitialConfig || MessageDisplay.Query(Translator.Translate("TXT_ADDONS_CHANGED_RESTART"),
                    Translator.Translate("TXT_APP_RESTART"),
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ConfigFileManager cfgFile = new ConfigFileManager(AddonsConfig.AddonsConfigFile);

                    SaveGroup(cfgFile, addonList.NavigationAddons, "NavigationAddons");
                    SaveGroup(cfgFile, addonList.PropertyAddons, "PropertyAddons");
                    SaveGroup(cfgFile, addonList.PreviewAddons, "PreviewAddons");

                    cfgFile.Save();

                    if (!AddonsConfig.IsInitialConfig)
                    {
                        Logger.LogInfo("Updated addons configuration was saved. Requesting to reload.");
                        SettingsForm.RequestRestart();

                        //AddonDetector.FireReloadAddons();
                    }
                }
                else if (!AddonsConfig.IsInitialConfig)
                {
                    MessageDisplay.Show(Translator.Translate("TXT_ADDONS_NOT_CHANGED"), 
                        "Info", MessageBoxIcon.Information);
                }
            }
            else
            {
                throw new SettingsSaveException("You must enable at least one navigation addon !");
            }
        }

        private void SaveGroup(ConfigFileManager cfgFile, List<AddonInfo> addonList, string groupName)
        {
            string addons = string.Empty;
            foreach (AddonInfo ai in addonList)
            {
                if (ai.Selected || ai.IsRequired)
                {
                    addons += ai.Name;
                    addons += "|";

                    cfgFile.SetValue(ai.Name, ai.CodeBase);
                }
            }

            if (addons.Length > 0)
            {
                cfgFile.SetValue(groupName, addons.TrimEnd(new char[] { '|' }));
            }
            else
            {
                cfgFile.SetValue(groupName, string.Empty);
            }
        }

        public int GetEnabledAddonCount(List<AddonInfo> addonList)
        {
            int retval = 0;
            foreach (AddonInfo ai in addonList)
            {
                if (ai.Selected || ai.IsRequired)
                {
                    retval++;
                }
            }

            return retval;
        }

        private void OnInstallAddons(object sender, EventArgs e)
        {
            OPMOpenFileDialog dlg = new OPMOpenFileDialog();
            dlg.Filter = Translator.Translate("TXT_INSTALLADDONFILTER");
            dlg.Title = Translator.Translate("TXT_INSTALLADDONS");

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (dlg.FileName.ToLowerInvariant().Contains("builtin"))
                    {
                        ErrorDispatcher.DispatchError(Translator.Translate("TXT_CANT_INSTALL_BUILTIN"),
                            Translator.Translate("TXT_CAUTION"));
                    }
                    else if (!dlg.FileName.ToLowerInvariant().EndsWith("extension.dll"))
                    {
                        ErrorDispatcher.DispatchError(Translator.Translate("TXT_INVALID_NAME"),
                            Translator.Translate("TXT_CAUTION"));
                    }
                    else if (TestAssembly(dlg.FileName))
                    {
                        AddonsConfig.InstallAddonLibrary(dlg.FileName);
                        ReloadConfig();
                    }
                    else
                    {
                        ErrorDispatcher.DispatchError(Translator.Translate("TXT_INVALID_ADDON"),
                            Translator.Translate("TXT_CAUTION"));
                    }
                }
                catch (Exception ex)
                {
                    ErrorDispatcher.DispatchError(ex);
                }
            }
        }

        private bool TestAssembly(string path)
        {
            try
            {
                Assembly asm = Assembly.LoadFrom(path);
                AssemblyName asmName = null;

                try
                {
                    Translator.RegisterTranslationAssembly(asm);
                }
                catch
                {
                }

                Type[] types = null;

                if (asm != null)
                {
                    asmName = asm.GetName();
                    types = asm.GetExportedTypes();
                }

                if (types != null)
                {
                    foreach (Type type in types)
                    {
                        if (type.IsSubclassOf(typeof(BaseAddonCtl)))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }

            return false;
        }

        private void OnUninstallAddons(object sender, EventArgs e)
        {
            AddonLibraryInfo ali = addonList.SelectedAddonLibrary;
            if (ali != null)
            {
                AttemptUninstallAddon(ali);
            }
        }

        private void AttemptUninstallAddon(AddonLibraryInfo ali)
        {
            try
            {
                if (ali.IsNative)
                {
                    ErrorDispatcher.DispatchError(
                        Translator.Translate("TXT_CANT_UNINSTALL_BUILTIN"),
                        Translator.Translate("TXT_CAUTION"));

                    return;
                }

                string[] codebaseParts = ali.CodeBase.Split(new char[] { '|' });
                if (codebaseParts.Length > 0)
                {
                    ScheduleForUninstall(codebaseParts[0]);

                    if (_uninstallScheduled)
                    {
                        FindForm().DialogResult = DialogResult.OK;
                        FindForm().Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        bool _uninstallScheduled = false;
        private void ScheduleForUninstall(string assembly)
        {
            string addons = string.Empty;

            List<AddonInfo> itemsToDisable = new List<AddonInfo>();

            foreach (AddonInfo ai in addonList.AllAddons)
            {
                string[] codebaseParts = ai.CodeBase.Split(new char[]{'|'});
                if (codebaseParts.Length > 0 && 
                    codebaseParts[0].ToLowerInvariant() == assembly.ToLowerInvariant())
                {
                    addons += ai.TranslatedName;
                    addons += "\n";
                    itemsToDisable.Add(ai);
                }
            }

            if (itemsToDisable.Count < 1)
                return;

            if (itemsToDisable.Count == 1 ||
                (MessageDisplay.Query(Translator.Translate("TXT_SHAREDADDONS", addons),
                    Translator.Translate("TXT_CAUTION"), MessageBoxIcon.Question) == DialogResult.Yes))
            {
                // Clear for uninstalling.

                ConfigFileManager cfgFile = new ConfigFileManager(AddonsConfig.AddonsConfigFile);

                foreach (AddonInfo ai in itemsToDisable)
                {
                    cfgFile.DeleteValue(ai.Name);
                    addonList.RemoveAddon(ai);
                }

                cfgFile.Save();

                AddonsConfig.MarkForUninstall(assembly);
                _uninstallScheduled = true;
            }

            
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {

        }

        private void OnSelectAll(object sender, EventArgs e)
        {
            addonList.SelectAll();
        }


    }
}

