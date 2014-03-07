using OPMedia.Runtime.Addons.AddonsBase.Prop;
using System.Collections.Generic;

namespace SampleAddon.Builtin.Property
{
    public partial class AddonPanel : PropBaseCtl
    {
        // Indicate that this property addon is REQUIRED (that is - can't be disabled)
        public static bool IsRequired { get { return true; } }

        public override bool CanHandleFolders
        { get { return true; } } // self-explanatory

        public override List<string> HandledFileTypes
        { get { return null; } } // can handle any file type

        public override int MaximumHandledItems
        { get { return -1; } } // can handle any number of files

        public AddonPanel()
        {
            InitializeComponent();
        }
    }
}
