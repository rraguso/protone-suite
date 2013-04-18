using System;
using System.Collections.Generic;
using System.Text;

namespace OPMedia.Runtime.ProTONE.Rendering.Base
{
    public enum MediaState
    {
        /// <summary>
        /// Media stopped before its actual end
        /// </summary>
        Stopped,
        /// <summary>
        /// Media playback paused
        /// </summary>
        Paused,
        /// <summary>
        /// Media playback in progress
        /// </summary>
        Playing,
        /// <summary>
        /// End of media reached while playing
        /// </summary>
        Ended
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
