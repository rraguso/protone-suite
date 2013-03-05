using System;
using System.Collections.Generic;
using System.Text;

namespace OPMedia.Runtime.ProTONE.RemoteControl
{
    [Serializable]
    public class ActivateCommand : BasicCommand
    {
        internal ActivateCommand() 
            : base(CommandType.Activate, null)
        {
        }
    }
}
