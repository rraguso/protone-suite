using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.Core.TranslationSupport;

namespace SkinBuilder.Navigation
{
    public partial class ThemeChooser : ToolForm
    {
        public string TemplateThemeName 
        {
            get
            {
                return lbThemes.SelectedItem as string;
            }
        }

        public string NewThemeName
        {
            get
            {
                return txtThemeName.Text;
            }
        }

        public ThemeChooser()
            : this(ThemeManager.Themes)
        {
            opmLabel1.Text = Translator.Translate("TXT_SELECT_THEME_TEMPLATE");
        }

        public ThemeChooser(List<string> themes) : 
            base("TXT_SELECT_THEME")
        {
            InitializeComponent();

            foreach (var t in themes)
            {
                lbThemes.Items.Add(t);
            }

            btnOk.Enabled = false;
        }

        private void lbThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = (txtThemeName.Text.Length > 0 && string.IsNullOrEmpty(TemplateThemeName) == false);
        }
    }
}
