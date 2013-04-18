using System;
using System.Collections.Generic;
using System.Text;

namespace OPMedia.Runtime.ProTONE.RemoteControl
{
    [Serializable]
    public class TerminateCommand : BasicCommand
    {
        internal TerminateCommand() 
            : base(CommandType.Terminate, null)
        {
        }
    }
}
