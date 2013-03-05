using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.UI.Configuration;
using System.Drawing;
using OPMedia.UI.Themes;
using OPMedia.Core.TranslationSupport;

namespace SubtitleEditor.extension.Configuration
{
    public class SubtitleEditorCfgPanel : SettingsTabPage
    {
        private OPMedia.UI.Controls.OPMLabel opmLabel1;
    
        public override Image Image
        {
            get
            {
                return OPMedia.UI.ProTONE.Properties.Resources.ResourceManager.GetImage("subtitles16");
            }
        }

        public SubtitleEditorCfgPanel()
        {
            InitializeComponent();
            this.Title = "TXT_SUBTITLE_EDITOR_SETTINGS";

            this.HandleCreated += new EventHandler(SubtitleEditorCfgPanel_HandleCreated);
        }

        void SubtitleEditorCfgPanel_HandleCreated(object sender, EventArgs e)
        {
            Translator.TranslateControl(this, DesignMode);
        }

        private void InitializeComponent()
        {
            this.opmLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.SuspendLayout();
            // 
            // opmLabel1
            // 
            this.opmLabel1.AutoSize = true;
            this.opmLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel1.Location = new System.Drawing.Point(28, 37);
            this.opmLabel1.Name = "opmLabel1";
            this.opmLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel1.Size = new System.Drawing.Size(184, 13);
            this.opmLabel1.TabIndex = 0;
            this.opmLabel1.Text = "SUBTITLE EDITOR CONFIGURATION";
            this.opmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SubtitleEditorCfgPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.opmLabel1);
            this.Name = "SubtitleEditorCfgPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
