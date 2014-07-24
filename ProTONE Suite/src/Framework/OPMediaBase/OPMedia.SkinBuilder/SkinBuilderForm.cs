using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.Addons;
using OPMedia.Runtime.Shortcuts;

namespace OPMedia.SkinBuilder
{
    public partial class SkinBuilderForm : AddonHostForm
    {
        public SkinBuilderForm()
            : base(Program.LaunchPath)
        {
        }

        public override void OnExecuteShortcut(OPMShortcutEventArgs args)
        {
            if (!this.DesignMode)
            {
                if (args.Handled)
                    return;

                switch (args.cmd)
                {
                    case OPMShortcut.CmdOpenSettings:
                        SkinBuilderSettingsForm.Show();
                        args.Handled = true;
                        break;
                }
            }
        }

    }
}
