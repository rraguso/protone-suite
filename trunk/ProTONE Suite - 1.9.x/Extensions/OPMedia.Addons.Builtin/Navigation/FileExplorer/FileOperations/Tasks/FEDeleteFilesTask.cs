using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.UI.FileTasks;
using System.IO;

namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.FileOperations.Tasks
{
    public class FEDeleteFilesTask : DeleteFilesTask
    {
        public FEDeleteFilesTask(List<string> srcFiles)
            : base(srcFiles)
        {
        }

        protected override UI.FileOperations.Tasks.FileTaskSupport InitSupport()
        {
            return new FEFileTaskSupport(this);
        }

        protected override void DeleteLinkedFiles(System.IO.FileInfo fi)
        {
            List<string> linkedFiles = _support.GetLinkedFiles(fi);
            if (linkedFiles != null && linkedFiles.Count > 0)
            {
                foreach (string linkedFile in linkedFiles)
                {
                    _support.CheckIfCanContinue(linkedFile);

                    try
                    {
                        string destinationPath = this.GetDestinationPath(linkedFile);

                        FileInfo lfi = new FileInfo(linkedFile);
                        _support.DeleteFile(lfi, true);
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}
