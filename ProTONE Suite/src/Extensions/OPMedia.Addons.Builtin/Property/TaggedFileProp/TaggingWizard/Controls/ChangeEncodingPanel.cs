using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;

namespace OPMedia.Addons.Builtin.TaggedFileProp.TaggingWizard
{
    public partial class ChangeEncodingPanel : EditPanelBase
    {
        public override bool ShowPreview
        {
            get
            {
                return false;
            }
        }

        public override bool ShowWordCasing
        {
            get
            {
                return false;
            }
        }

        public ChangeEncodingPanel()
        {
            this.title = "TXT_CHANGEENCODINGPANEL";
            InitializeComponent();
        }

        protected override void DisplayTask()
        {
            encoderOptionsCtl.EncoderSettings = (_task as Task).EncoderSettings;
            encoderOptionsCtl.DisplaySettings();
        }
    }
}
