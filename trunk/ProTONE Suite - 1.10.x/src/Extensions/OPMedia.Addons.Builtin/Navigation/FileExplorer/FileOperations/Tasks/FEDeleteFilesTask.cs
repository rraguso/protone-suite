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

        protected override void DeleteConnectedFiles(System.IO.FileInfo fi)
        {
            List<string> linkedFiles = _support.GetChildFiles(fi, this.TaskType);
            if (linkedFiles != null && linkedFiles.Count > 0)
            {
                foreach (string linkedFile in linkedFiles)
                {
                    _support.CheckIfCanContinue(linkedFile);

                    try
                    {
                        FileInfo lfi = new FileInfo(linkedFile);
                        _support.DeleteFile(lfi, true);
                    }
                    catch
                    {
                    }
                }
            }

            string parentFile = _support.GetParentFile(fi, this.TaskType);
            if (!string.IsNullOrEmpty(parentFile))
            {
                _support.CheckIfCanContinue(parentFile);

                try
                {
                    FileInfo lfi = new FileInfo(parentFile);
                    _support.DeleteFile(lfi, false);
                }
                catch
                {
                }
            }
        }
    }
}
