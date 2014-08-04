using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OPMedia.Core;

namespace OPMedia.UI.FileTasks
{
    public class MoveFilesTask : BaseFileTask
    {
        public MoveFilesTask(List<string> srcFiles, string srcFolder) :
            base(FileTaskType.Move, srcFiles, srcFolder)
        {
        }

        protected override bool MoveObject(string path)
        {
            _support.CheckIfCanContinue(path);

            try
            {
                string destinationPath = this.GetDestinationPath(path);

                try
                {
                    if (Directory.Exists(path))
                    {
                        // Destination path is on same disk => can use MoveTo
                        DirectoryInfo di = new DirectoryInfo(path);

                        if (PathUtils.PathsAreOnSameRoot(path, destinationPath))
                        {
                            if (di.GetFileSystemInfos().Length == 0)
                            {
                                // empty folder
                                if (_support.CanMove(di))
                                {
                                    di.MoveTo(destinationPath);
                                }
                            }
                            else if (_support.CanMoveNonEmptyFolder(di))
                            {
                                di.MoveTo(destinationPath);
                            }
                        }
                        else
                        {
                            string[] subObjects = Directory.GetFileSystemEntries(path);
                            if (subObjects != null && subObjects.Length > 0)
                            {
                                foreach (string subObj in subObjects)
                                {
                                    MoveObject(subObj);
                                }
                            }

                            _support.DeleteFolder(di);
                        }
                    }
                    else
                    {
                        FileInfo fi = new FileInfo(path);
                        MoveConnectedFiles(fi, destinationPath);
                        _support.MoveFile(fi, destinationPath, false);
                    }
                }
                catch (Exception ex)
                {
                    AddToErrorMap(path, ex.Message);
                }
            }
            finally
            {
                ProcessedObjects++;
            }

            return true;
        }

        protected virtual void MoveConnectedFiles(FileInfo fi, string destPath) { }
    }
}
