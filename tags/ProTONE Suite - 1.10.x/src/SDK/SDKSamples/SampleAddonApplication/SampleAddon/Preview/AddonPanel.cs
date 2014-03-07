using OPMedia.Runtime.Addons.AddonsBase.Preview;

namespace SampleAddon.Builtin.Preview
{
    public partial class AddonPanel : PreviewBaseCtl
    {
        // Indicate that this preview addon is REQUIRED (that is - can't be disabled)
        public static bool IsRequired { get { return true; } }

        public AddonPanel()
        {
            InitializeComponent();
        }


    }
}
