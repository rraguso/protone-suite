using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.Addons.AddonsBase.Preview;
using System.Diagnostics;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Controls;


namespace OPMedia.Addons.Builtin.__DefaultPreview
{
    public class AddonPanel : PreviewBaseCtl
    {
        private OPMLabel lblResult;

        public static bool IsRequired { get { return true; } }

        public override string GetHelpTopic()
        {
            return "DefaultPreviewPanel";
        }

        public AddonPanel()
            : base()
        {
            InitializeComponent();
        }
    
        private void InitializeComponent()
        {
            this.lblResult = new OPMLabel();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResult.Location = new System.Drawing.Point(0, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(218, 44);
            this.lblResult.TabIndex = 0;
            // 
            // AddonPanel
            // 
            this.Controls.Add(this.lblResult);
            this.Name = "AddonPanel";
            this.Size = new System.Drawing.Size(218, 206);
            this.ResumeLayout(false);

        }

        protected override void DoBeginPreview(string item, object additionalData)
        {
            try
            {
                Process.Start(item);
                lblResult.Text = Translator.Translate("TXT_THEREARENOITEMS");
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
        }

        protected override void DoEndPreview()
        {
        } 
    }
}
