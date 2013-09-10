using System;
using System.Collections.Generic;
using System.Text;

namespace OPMedia.Runtime.ProTONE.Rendering.Base
{
    public enum BalanceRange
    {
        Minimum = -10000,
        Maximum = 10000
    }

    public enum VolumeRange
    {
        Minimum = -10000,
        Maximum = 0
    }

    public enum MediaTypes
    {
        None,
        Audio,
        Video,
        Both
    }
}
