using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;
using OPMedia.Core.TranslationSupport;

using OPMedia.Core;
using Microsoft.Win32;
using OPMedia.UI.Properties;
using OPMedia.Runtime.ProTONE.Haali;
using OPMedia.Runtime.ProTONE.FfdShowApi;
using OPMedia.Core.ApplicationSettings;

namespace OPMedia.UI.ProTONE.Configuration.MiscConfig
{
    public partial class FavoriteFoldersPage : SettingsTabPage
    {
        public FavoriteFoldersPage()
        {
            InitializeComponent();

            favoriteFoldersControl.FavoriteFoldersHiveName = "FavoriteFolders";

            this.HandleCreated += new EventHandler(FavoriteFoldersPage_Load);
        }

        void FavoriteFoldersPage_Load(object sender, EventArgs e)
        {
        }
    }
}
