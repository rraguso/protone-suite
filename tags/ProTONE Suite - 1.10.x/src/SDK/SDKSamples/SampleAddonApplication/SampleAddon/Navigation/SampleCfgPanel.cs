using OPMedia.UI.Configuration;
using System.Drawing;

namespace SampleAddon.Builtin.Navigation
{
    public partial class SampleCfgPanel : BaseCfgPanel
    {
        public override System.Drawing.Image Image
        {
            get
            {
                return SystemIcons.Shield.ToBitmap();
            }
        }

        public SampleCfgPanel()
        {
            InitializeComponent();
            this.Title = "TXT_SAMPLE_ADDON_SETTINGS";
        }
    }
}
