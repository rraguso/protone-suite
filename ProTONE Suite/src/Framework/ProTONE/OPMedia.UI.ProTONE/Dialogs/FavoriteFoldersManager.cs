using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Core.Configuration;
using OPMedia.UI.Themes;
using System.Windows.Forms;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core;
using System.Drawing;
using OPMedia.UI.Controls;
using OPMedia.UI.Dialogs;
using OPMedia.UI.Properties;
using OPMedia.Runtime.ProTONE.Configuration;

namespace OPMedia.Addons.Builtin.FileExplorer
{
    public class FavoriteFoldersManager : ThemeForm
    {
        private FavoriteFoldersControl favoriteFoldersControl;
        private OPMButton btnOK;

        public FavoriteFoldersManager(string favFoldersHiveName)
            : base("TXT_MANAGE_FAVORITES")
        {
            InitializeComponent();

            favoriteFoldersControl.FavoriteFoldersHiveName = favFoldersHiveName;

            this.Load += new EventHandler(FavoriteFoldersManager_Load);
        }

        void FavoriteFoldersManager_Load(object sender, EventArgs e)
        {
            this.InheritAppIcon = false;
            this.Icon = Resources.Favorites16.ToIcon();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ProTONEConfig.SetFavoriteFolders(favoriteFoldersControl.FavoriteFolders, 
                favoriteFoldersControl.FavoriteFoldersHiveName);
        }

        private void InitializeComponent()
        {
            this.favoriteFoldersControl = new OPMedia.UI.Dialogs.FavoriteFoldersControl();
            this.btnOK = new OPMedia.UI.Controls.OPMButton();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.btnOK);
            this.pnlContent.Controls.Add(this.favoriteFoldersControl);
            // 
            // favoriteFoldersControl
            // 
            this.favoriteFoldersControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.favoriteFoldersControl.FavoriteFoldersHiveName = null;
            this.favoriteFoldersControl.Location = new System.Drawing.Point(0, 0);
            this.favoriteFoldersControl.Name = "favoriteFoldersControl";
            this.favoriteFoldersControl.Size = new System.Drawing.Size(390, 172);
            this.favoriteFoldersControl.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoSize = true;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(332, 145);
            this.btnOK.Name = "btnOK";
            this.btnOK.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOK.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOK.Size = new System.Drawing.Size(55, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "TXT_OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FavoriteFoldersManager
            // 
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Name = "FavoriteFoldersManager";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
