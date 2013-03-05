using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.Addons.Properties;
using OPMedia.UI.Controls;


namespace OPMedia.Runtime.Addons.Configuration
{
    public delegate SettingsTabPage InitAddonCfgHandler();

    public partial class AddonSettingsPanel : BaseCfgPanel                     
    {
        internal static event InitAddonCfgHandler InitAddonCfg = null;

        public override Image Image
        {
            get
            {
                return Resources.AddonsSettings;
            }
        }

        public override string GetHelpTopic()
        {
            if (tabAddons.SelectedTab != null)
            {
                string title = tabAddons.SelectedTab.Tag as string;
                if (!string.IsNullOrEmpty(title))
                {
                    title = title.Replace("TXT_", "").ToLowerInvariant();
                    return string.Format("{0}/{1}", this.Name, title);
                }
            }

            return base.GetHelpTopic();
        }

        public AddonSettingsPanel() : base()
        {
            this.Title = "TXT_ADDON_SETTINGS";

            InitializeComponent();

            Translator.TranslateControl(this, DesignMode);

            this.HandleCreated += new EventHandler(AddonSettingsPanel_HandleCreated);
        }

         void AddonSettingsPanel_HandleCreated(object sender, EventArgs e)
         {
             tabAddons.TabPages.Clear();
             tabAddons.ImageList.Images.Clear();

             if (InitAddonCfg != null)
             {
                 foreach (Delegate dlg in InitAddonCfg.GetInvocationList())
                 {
                     InitAddonCfgHandler callDlg = dlg as InitAddonCfgHandler;
                     if (callDlg != null)
                     {
                         SettingsTabPage pageContents = callDlg();
                         if (pageContents != null)
                         {
                             string title = Translator.Translate(pageContents.Title);

                             pageContents.Dock = DockStyle.Fill;

                             OPMTabPage tp = new OPMTabPage(title, pageContents);
                             tp.Dock = DockStyle.Fill;
                             tp.ImageIndex = tabAddons.ImageList.Images.Count;
                             tp.Tag = pageContents.Title;

                             tabAddons.ImageList.Images.Add(pageContents.Image);
                             tabAddons.TabPages.Add(tp);

                             pageContents.ModifiedActive -= new EventHandler(OnModifiedActive);
                             pageContents.ModifiedActive += new EventHandler(OnModifiedActive);
                         }
                     }
                 }

                 if (tabAddons.TabPages.Count > 1)
                 {
                     tabAddons.SelectedIndex = 0;
                 }
             }
         }

         void OnModifiedActive(object sender, EventArgs e)
         {
             Modified = true;
         }

         protected override void SaveInternal()
         {
             foreach (OPMTabPage tp in tabAddons.TabPages)
             {
                 SettingsTabPage page = tp.Control as SettingsTabPage;
                 if (page != null)
                 {
                     page.Save();
                 }
             }

             Modified = false;
         }

         protected override void DiscardInternal()
         {
             foreach (OPMTabPage tp in tabAddons.TabPages)
             {
                 SettingsTabPage page = tp.Control as SettingsTabPage;
                 if (page != null)
                 {
                     page.Discard();
                 }
             }

             Modified = false;
         }
    }
}
