using System;
using System.Collections.Generic;
using System.Text;

namespace OPMedia.Runtime.ProTONE.RemoteControl
{
    [Serializable]
    public class ClearPlaylistCommand : BasicCommand
    {
        internal ClearPlaylistCommand()
            : base(CommandType.ClearPlaylist, null)
        {
        }
    }

    [Serializable]
    public class PlayFilesCommand : BasicCommand
    {
        internal PlayFilesCommand(string[] args)
            : base(CommandType.PlayFiles, args)
        {
        }
    }

    [Serializable]
    public class EnqueueFilesCommand : BasicCommand
    {
        internal EnqueueFilesCommand(string[] args)
            : base(CommandType.EnqueueFiles, args)
        {
        }
    }

    [Serializable]
    public class PlaybackCommand : BasicCommand
    {
        internal PlaybackCommand(string[] args)
            : base(CommandType.Playback, args)
        {
        }
    }
}
