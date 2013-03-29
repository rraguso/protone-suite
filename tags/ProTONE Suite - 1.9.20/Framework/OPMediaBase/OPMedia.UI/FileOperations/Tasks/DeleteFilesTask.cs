using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OPMedia.Core;

namespace OPMedia.UI.FileTasks
{
    public class DeleteFilesTask : BaseFileTask
    {
        public DeleteFilesTask(List<string> srcFiles) :
            base(FileTaskType.Delete, srcFiles, string.Empty)
        {
        }

        protected override bool DeleteObject(string path)
        {
            _support.CheckIfCanContinue(path);

            try
            {
                if (Directory.Exists(path))
                {
                    DirectoryInfo di = new DirectoryInfo(path);
                    _support.DeleteFolder(di);
                }
                else
                {
                    FileInfo fi = new FileInfo(path);
                    DeleteLinkedFiles(fi);
                    _support.DeleteFile(fi, false);
                }
            }
            finally
            {
                ProcessedObjects++;
            }

            return true;
        }

        protected virtual void DeleteLinkedFiles(FileInfo fi) { }
    }
}
