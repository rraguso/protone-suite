using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.UI.FileOperations.Tasks;
using OPMedia.UI.FileTasks;
using System.IO;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Runtime.ProTONE.ExtendedInfo;
using OPMedia.Core;
using OPMedia.Runtime.ProTONE.ApplicationSettings;

namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.FileOperations.Tasks
{
    public class FEFileTaskSupport : FileTaskSupport
    {
        public FEFileTaskSupport(BaseFileTask task)
            : base(task)
        {
        }

        public override List<string> GetChildFiles(FileInfo fi, FileTaskType taskType)
        {
            List<string> list = new List<string>();

            if (ProTONEAppSettings.UseLinkedFiles)
            {
                string fileType = fi.Extension.ToUpperInvariant().Trim('.');
                string[] childFileTypes = ProTONEAppSettings.GetChildFileTypes(fileType);

                if (childFileTypes != null && childFileTypes.Length > 0)
                {
                    foreach (string childFileType in childFileTypes)
                    {
                        // This will find files like "FileName.PFT" and change them into "FileName.CFT"
                        string childFilePath = Path.ChangeExtension(fi.FullName, childFileType);
                        if (File.Exists(childFilePath) && !list.Contains(childFilePath))
                        {
                            list.Add(childFilePath);
                        }

                        // This will find files like "FileName.PFT" and change them into "FileName.PFT.CFT"
                        // (i.e. handle double type extension case like for Bookmark files)
                        string childFileType2 = string.Format("{0}.{1}", fi.Extension, childFileType);
                        string childFilePath2 = Path.ChangeExtension(fi.FullName, childFileType2);
                        if (File.Exists(childFilePath2) && !list.Contains(childFilePath2))
                        {
                            list.Add(childFilePath2);
                        }
                    }
                }
            }

            return list;
        }

        public override string GetParentFile(FileInfo fi, FileTaskType taskType)
        {
            if (ProTONEAppSettings.UseLinkedFiles)
            {
                // Check whether the child file is a double extension file
                // In this case the parent file should have same name but w/o the second extension part.
                string parentFilePath = Path.Combine(fi.DirectoryName, Path.GetFileNameWithoutExtension(fi.FullName));
                if (File.Exists(parentFilePath))
                    return parentFilePath;

                string fileType = fi.Extension.ToUpperInvariant().Trim('.');
                string[] parentFileTypes = ProTONEAppSettings.GetParentFileTypes(fileType);

                if (parentFileTypes != null && parentFileTypes.Length > 0)
                {
                    foreach (string parentFileType in parentFileTypes)
                    {
                        parentFilePath = Path.ChangeExtension(fi.FullName, parentFileType);
                        if (File.Exists(parentFilePath))
                        {
                            return parentFilePath;
                        }
                    }
                }
            }

            return null;
        }
    }
}
