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

namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.FileOperations.Tasks
{
    public class FEFileTaskSupport : FileTaskSupport
    {
        public FEFileTaskSupport(BaseFileTask task)
            : base(task)
        {
        }

        public override List<string> GetLinkedFiles(FileInfo fi)
        {
            List<string> list = new List<string>();

            if (AppSettings.GroupBookmarkWithMedia)
            {
                // Is it a media file ?
                MediaFileInfo mfi = null;

                try
                {
                    mfi = MediaFileInfo.FromPath(fi.FullName);
                }
                catch
                {
                    mfi = null;
                }

                if (mfi != null && mfi.IsValid)
                {
                    // Yes it is. See if it has bookmark file and this is added to the list.
                    if (mfi.Bookmarks != null && mfi.Bookmarks.Count > 0 && mfi.BookmarkFileInfo != null)
                    {
                        list.Add(mfi.BookmarkFileInfo.Path);
                    }
                }
                else
                {
                    // Not a media file. Maybe a bookmark file ?
                    BookmarkFileInfo bfi = null;
                    try
                    {
                        bfi = new BookmarkFileInfo(fi.FullName, true);
                    }
                    catch
                    {
                        bfi = null;
                    }

                    if (bfi != null && bfi.IsValid && bfi.Bookmarks != null)
                    {
                        // Indeed a bookmark file. Is it orphan ?
                        if (!bfi.IsOrphan)
                        {
                            list.Add(bfi.ParentMediaFile);
                        }
                    }
                }
            }

            return list;
        }
    }
}
