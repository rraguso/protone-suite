using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.Addons.AddonsBase.Preview;
using OPMedia.UI.ProTONE.SubtitleDownload;
using OPMedia.UI.Controls;
using OPMedia.Runtime.ProTONE.SubtitleDownload;

namespace SubtitleEditor.Preview
{
    public partial class AddonPanel : PreviewBaseCtl
    {
        private OPMLabel opmLabel1;
    
        public AddonPanel()
        {
            InitializeComponent();
        }

        public override List<string> HandledFileTypes
        {
            get
            {
                return SubtitleDownloader.AllowedSubtitleExtensions;
            }
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
            this.opmLabel1.Location = new System.Drawing.Point(44, 70);
            this.opmLabel1.Name = "opmLabel1";
            this.opmLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel1.Size = new System.Drawing.Size(142, 13);
            this.opmLabel1.TabIndex = 1;
            this.opmLabel1.Text = "SUBTITLE EDITOR PREVIEW";
            this.opmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddonPanel
            // 
            this.Controls.Add(this.opmLabel1);
            this.Name = "AddonPanel";
            this.Size = new System.Drawing.Size(433, 437);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
    }
}
