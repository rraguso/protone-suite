using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using OPMedia.UI.Themes;
using OPMedia.Core.ApplicationSettings;
using OPMedia.UI.Properties;
using OPMedia.UI.Controls;
using OPMedia.Core;
using OPMedia.Core.TranslationSupport;

namespace OPMedia.UI.Configuration
{
    public partial class MultiPageCfgPanel : BaseCfgPanel
    {
        public MultiPageCfgPanel()
            : base()
        {
            InitializeComponent();
        }

        public void AddSubPage(BaseCfgPanel page)
        {
            string title = Translator.Translate(page.Title);

            page.Dock = DockStyle.Fill;

            OPMTabPage tp = new OPMTabPage(title, page);
            tp.Dock = DockStyle.Fill;
            tp.ImageIndex = tabSubPages.ImageList.Images.Count;
            tp.Tag = page.Title;

            tabSubPages.ImageList.Images.Add(page.Image);
            tabSubPages.TabPages.Add(tp);

            page.ModifiedActive -= new EventHandler(OnModifiedActive);
            page.ModifiedActive += new EventHandler(OnModifiedActive);
        }

        void OnModifiedActive(object sender, EventArgs e)
        {
            Modified = true;
        }

        protected override void SaveInternal()
        {
            foreach (OPMTabPage tp in tabSubPages.TabPages)
            {
                BaseCfgPanel page = tp.Control as BaseCfgPanel;
                if (page != null)
                {
                    page.Save();
                }
            }

            Modified = false;
        }

        protected override void DiscardInternal()
        {
            foreach (OPMTabPage tp in tabSubPages.TabPages)
            {
                BaseCfgPanel page = tp.Control as BaseCfgPanel;
                if (page != null)
                {
                    page.Discard();
                }
            }

            Modified = false;
        }
    }
}