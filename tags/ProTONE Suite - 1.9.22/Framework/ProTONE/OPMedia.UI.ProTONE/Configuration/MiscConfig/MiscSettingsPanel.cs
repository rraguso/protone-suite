using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.ProTONE.Properties;
using OPMedia.UI.Configuration;
using OPMedia.Core.TranslationSupport;

using OPMedia.Runtime.ProTONE.ServiceHelpers;
using OPMedia.Core;
using OPMedia.UI.Controls;
using OPMedia.UI.Themes;

namespace OPMedia.UI.ProTONE.Configuration
{
    public partial class MiscellaneousSettingsPanel : BaseCfgPanel
    {
        public override Image Image
        {
            get
            {
                return Resources.Miscellaneous;
            }
        }

        public override string GetHelpTopic()
        {
            if (tabMisc.SelectedTab != null)
                return string.Format("{0}/{1}", this.Name, tabMisc.SelectedTab.Name);

            return base.GetHelpTopic();
        }

        public MiscellaneousSettingsPanel()
            : base()
        {
            this.Title = "TXT_MISC_SETTINGS";

            InitializeComponent();

            Translator.TranslateControl(this, DesignMode);

            Bitmap bmp = Resources.Playlist;
            bmp.MakeTransparent();
            tabMisc.ImageList.Images.Add(bmp);
            //tabMisc.ImageList.Images.Add(Resources.Monitor);
            tabMisc.ImageList.Images.Add(OPMedia.Core.Properties.Resources.ir_remote);
            tabMisc.ImageList.Images.Add(Resources.Diagnostics);

            int i = 0;
            foreach (OPMTabPage tp in tabMisc.TabPages)
            {
                tp.ImageIndex = i++;
            }

            if (!SuiteConfiguration.CanModifyRegistry ||
                !SuiteConfiguration.IsRCCServiceInstalled)
            {
                tabMisc.TabPages.Remove(tpRemote);
            }

            pagePlaylist.ModifiedActive += new EventHandler(OnModifiedActive);
            pageRemote.ModifiedActive += new EventHandler(OnModifiedActive);
            pageDiagnostics.ModifiedActive += new EventHandler(OnModifiedActive);

            this.HandleCreated += new EventHandler(MiscellaneousSettingsPanel_HandleCreated);
        }

        void MiscellaneousSettingsPanel_HandleCreated(object sender, EventArgs e)
        {
            tabMisc.SelectedIndex = 0;
        }

        void OnModifiedActive(object sender, EventArgs e)
        {
            Modified = true;
        }

        protected override void SaveInternal()
        {
            pagePlaylist.Save();

            if (SuiteConfiguration.CanModifyRegistry &&
                SuiteConfiguration.IsRCCServiceInstalled)
            {
                pageRemote.Save();
            }

            // Diagnostics page does not interact with app settings.
            // No need to call Save for it.
            //pageDiagnostics.Save();

            Modified = false;
        }
    }
}
