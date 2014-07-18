using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;
using OPMedia.Core.ApplicationSettings;
using OPMedia.UI.Controls;
using OPMedia.Runtime.ProTONE;
using OPMedia.Runtime.ProTONE.FfdShowApi;
using OPMedia.Runtime.ProTONE.Rendering;

namespace OPMedia.UI.ProTONE.Configuration
{
    public partial class SubtitleOsdPage : BaseCfgPanel
    {
        Font _osdFont = AppSettings.Instance.OsdFont;
        Color _osdColor = AppSettings.Instance.OsdColor;
        bool _osdEnabled = AppSettings.Instance.OsdEnabled;
        int _osdTimer = AppSettings.Instance.OsdPersistTimer;

        Font _subFont = AppSettings.Instance.SubFont;
        Color _subColor = AppSettings.Instance.SubColor;
        bool _subEnabled = AppSettings.Instance.SubEnabled;


        protected override void SaveInternal()
        {
            AppSettings.Instance.SubEnabled = _subEnabled;
            AppSettings.Instance.SubFont = _subFont;
            AppSettings.Instance.SubColor = _subColor;

            AppSettings.Instance.OsdEnabled = _osdEnabled;
            AppSettings.Instance.OsdFont = _osdFont;
            AppSettings.Instance.OsdColor = _osdColor;

            AppSettings.Instance.OsdPersistTimer = _osdTimer;

            AppSettings.Instance.MediaStateNotificationsEnabled = chkFilterStateNotificationsEnabled.Checked;

            // Tell FFDShow to reload subtitle and OSD settings
            MediaRenderer.DefaultInstance.ReloadFfdShowSettings();
        }

        public SubtitleOsdPage()
        {
            InitializeComponent();

            this.HandleCreated += new EventHandler(OnLoad);
        }

        void OnLoad(object sender, EventArgs e)
        {
            chkSubEnabled.Checked = _subEnabled;
            lblSubText1.Font = _subFont;
            lblSubText2.Font = _subFont;
            lblSubText1.ForeColor = _subColor;
            lblSubText2.ForeColor = _subColor;

            chkOsdEnabled.Checked = _osdEnabled;
            lblOsdText.Font = _osdFont;
            lblOsdText2.Font = _osdFont;
            lblOsdText.ForeColor = _osdColor;
            lblOsdText2.ForeColor = _osdColor;

            nudOsdTmr.Value = _osdTimer / 1000;

            chkOsdEnabled.CheckedChanged += new EventHandler(chkOsdEnabled_CheckedChanged);
            nudOsdTmr.ValueChanged += new EventHandler(nudOsdTmr_ValueChanged);

            chkFilterStateNotificationsEnabled.Checked = AppSettings.Instance.MediaStateNotificationsEnabled;
            chkFilterStateNotificationsEnabled.CheckedChanged += new EventHandler(chkFilterStateNotificationsEnabled_CheckedChanged);

            this.chkSubEnabled.CheckedChanged += new System.EventHandler(this.chkSubEnabled_CheckedChanged);

        }
        
        void chkFilterStateNotificationsEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void btnSubFont_Click(object sender, EventArgs e)
        {
            if (ChooseFont(ref _subFont))
            {
                lblSubText1.Font = _subFont;
                lblSubText2.Font = _subFont;
                Modified = true;
            }
        }

        private void btnOsdFont_Click(object sender, EventArgs e)
        {
            if (ChooseFont(ref _osdFont))
            {
                lblOsdText.Font = _osdFont;
                lblOsdText2.Font = _osdFont;
                Modified = true;
            }
        }

        private void btnSubColor_Click(object sender, EventArgs e)
        {
            if (ChooseColor(ref _subColor))
            {
                lblSubText1.ForeColor = _subColor;
                lblSubText2.ForeColor = _subColor;
                Modified = true;
            }
        }

        private void btnOsdColor_Click(object sender, EventArgs e)
        {
            if (ChooseColor(ref _osdColor))
            {
                lblOsdText.ForeColor = _osdColor;
                lblOsdText2.ForeColor = _osdColor;
                Modified = true;
            }
        }

        private bool ChooseFont(ref Font f)
        {
            OPMFontDialog dlg = new OPMFontDialog();
            dlg.Font = f;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                f = dlg.Font;
                return true;
            }

            return false;
        }

        private bool ChooseColor(ref Color c)
        {
            OPMColorDialog dlg = new OPMColorDialog();
            dlg.Color = c;

            if (dlg.ShowDialog(FindForm()) == DialogResult.OK)
            {
                c = dlg.Color;
                return true;
            }

            return false;
        }

        private void chkSubEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _subEnabled = chkSubEnabled.Checked;
            Modified = true;
        }

        private void chkOsdEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _osdEnabled = chkOsdEnabled.Checked;
            Modified = true;
        }

        private void nudOsdTmr_ValueChanged(object sender, EventArgs e)
        {
            _osdTimer = (int)nudOsdTmr.Value * 1000;
            Modified = true;
        }
    }
}
