using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.Addons.AddonsBase.Preview;
using OPMedia.UI.Themes;
using OPMedia.Runtime.ProTONE.Rendering;

namespace OPMedia.Addons.Builtin.Player
{
    public partial class AddonPanel : PreviewBaseCtl
    {
        public override string GetHelpTopic()
        {
            return "PlayerPreviewPanel";
        }

        public AddonPanel()
            : base()
        {
            InitializeComponent();

            //mediaPlayer.CompactView = true;
        }

        public override List<string> HandledFileTypes
        {
            get
            {
                List<String> fileTypes = new List<string>();
                fileTypes.AddRange(MediaRenderer.SupportedAudioTypes);
                fileTypes.AddRange(MediaRenderer.SupportedVideoTypes);
                return fileTypes;
            }
        }

        protected override void DoBeginPreview(string item, object additionalData)
        {
            mediaPlayer.PlayFiles(new string[] { item });

            if (additionalData != null)
            {
                mediaPlayer.StopPlayback();
            }
        }

        protected override void DoEndPreview()
        {
            mediaPlayer.StopPlayback();
        }
    }
}
