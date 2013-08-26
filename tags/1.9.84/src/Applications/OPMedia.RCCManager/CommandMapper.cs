using System;
using System.Collections.Generic;
using System.Text;
using OPMRemoteControl = OPMedia.Runtime.ProTONE.RemoteControl;
using OPMedia.Runtime.Shortcuts;
using OPMedia.Core.TranslationSupport;

namespace OPMedia.RCCManager
{
    internal class CommandMapper
    {
        public static string GetCommandDescription(string commandString)
        {
            string[] fields = commandString.Split("?".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (fields.Length != 2)
            {
                return commandString;
            }

            switch (fields[0].ToLowerInvariant())
            {
                case "playback":
                    for (OPMShortcut cmd = OPMShortcut.CmdPlay; cmd < OPMShortcut.CmdGenericOpen; cmd++)
                            {
                                if (fields[1].ToLowerInvariant() == cmd.ToString().ToLowerInvariant())
                                {
                                    return Translator.Translate("TXT_" + cmd.ToString().ToUpperInvariant());
                                }
                            }
                    break;

                case "keypress":
                    return string.Format("KeyPress : {0}", fields[1]);
            }

            return commandString;
        }
    }
}
