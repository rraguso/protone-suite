using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using OPMedia.Runtime.ProTONE.RemoteControl;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Runtime.Remoting;
using System.Windows.Forms;
using OPMedia.Core;
using OPMedia.Core.Logging;

namespace OPMedia.Runtime.ProTONE.RemoteControl
{
    [Serializable]
    public class BrowseRemoteFilesCommand : BasicCommand
    {
        public string DirectoryPath
        { get { return (args.Length >= 1) ? args[0] : string.Empty; } }

        public string Filter
        { get { return (args.Length >= 2) ? args[1] : "*.*"; } }

        public BrowseRemoteFilesCommand(string[] args)
            : base(CommandType.BrowseRemoteFiles, args)
        {
            this.requiresAnswer = true;
        }

        public SerializableObject Execute()
        {
            StringBuilder ans = new StringBuilder();
            ans.AppendLine("ACK");
            foreach (string dir in Directory.EnumerateDirectories(DirectoryPath))
            {
                ans.AppendLine(string.Format("[DIR] {0}", dir));
            }
            foreach (string file in Directory.EnumerateFiles(DirectoryPath, Filter))
            {
                ans.AppendLine(string.Format("[FIL] {0}", file));
            }
            return new RemoteString(ans.ToString());
        }
    }

    [Serializable]
    public class GetDriveListCommand : BasicCommand
    {
        public GetDriveListCommand(string[] args)
            : base(CommandType.GetDriveList, args)
        {
            this.requiresAnswer = true;
        }

        public SerializableObject Execute()
        {
            StringBuilder ans = new StringBuilder();
            ans.AppendLine("ACK");
            foreach (string drive in Environment.GetLogicalDrives())
            {
                ans.AppendLine(string.Format("[DRV] {0}", drive));
            }
            return new RemoteString(ans.ToString());
        }
    }

    [Serializable]
    public class QueryMediaRendererCommand : BasicCommand
    {
        public QueryMediaRendererCommand(string[] args)
            : base(CommandType.QueryMediaRenderer, args)
        {
            this.requiresAnswer = true;
        }

        public SerializableObject Execute()
        {
            return new RemoteString("ACK\r\n" + MediaRenderer.DefaultInstance.GetStateDescription());
        }
    }

    [Serializable]
    public class KeyPressCommand : BasicCommand
    {
        string key = string.Empty;

        public KeyPressCommand(string[] args)
            : base(CommandType.KeyPress, args)
        {
            if (args != null && args.Length > 0)
            {
                key = args[0];
            }
        }

        public SerializableObject Execute()
        {
            try
            {
                SendKeys.SendWait(key);
            return new RemoteString("ACK\r\n");
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return new RemoteString("NAK\r\n");
            }
        }
    }
}
