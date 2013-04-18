using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OPMedia.Core.InstanceManagement;
using OPMedia.Core.Logging;
using OPMedia.Core.TranslationSupport;
using System.Configuration;
using OPMedia.Runtime.Addons;
using OPMedia.Core.ApplicationSettings;
using OPMedia.UI;
using System.Diagnostics;
using OPMedia.UI.ProTONE;
using OPMedia.UI.ProTONE.Controls.MediaPlayer;
using OPMedia.UI.Themes;
using OPMedia.UI.ProTONE.Configuration;
using OPMedia.Runtime;
using OPMedia.Core;
using OPMedia.Runtime.Shortcuts;
using OPMedia.Core.Utilities;
using OPMedia.UI.HelpSupport;

namespace OPMedia.MediaLibrary
{
    public class MediaLibraryForm : AddonHostForm
    {
        public MediaLibraryForm() 
            : base(Program.LaunchPath)
        {
        }

        public override void OnExecuteShortcut(OPMShortcutEventArgs args)
        {
            if (args.Handled)
                return;

            switch (args.cmd)
            {
                case OPMShortcut.CmdOpenSettings:
                    ProTONESettingsForm.Show();
                    args.Handled = true;
                    break;
            }

        }
    }
}