using OPMedia.Runtime.Addons.AddonsBase.Navigation;
using System.Collections.Generic;
using OPMedia.UI.Configuration;

namespace SampleAddon.Builtin.Navigation
{
    public partial class AddonPanel : NavBaseCtl
    {
        // Indicate that this navigation addon is REQUIRED (that is - can't be disabled)
        public static bool IsRequired { get { return true; } }

        public AddonPanel()
        {
            InitializeComponent();

            this.Load += new System.EventHandler(AddonPanel_Load);
        }

        void AddonPanel_Load(object sender, System.EventArgs e)
        {
            List<string> paths = new List<string>();
            paths.Add("dummy"); // Does not matter the value, ve just need one item there

            // Dummy event just for loading property panel
            RaiseNavigationAction(OPMedia.Runtime.Addons.NavActionType.ActionSelectFile, 
                paths, new object());

            // Dummy event just for loading preview panel
            RaiseNavigationAction(OPMedia.Runtime.Addons.NavActionType.ActionDoubleClickFile,
                paths, new object());
        }

        protected override BaseCfgPanel GetBaseCfgPanel()
        {
            // Create the settings panel for this addon
            return new SampleCfgPanel();
        }
    }
}
