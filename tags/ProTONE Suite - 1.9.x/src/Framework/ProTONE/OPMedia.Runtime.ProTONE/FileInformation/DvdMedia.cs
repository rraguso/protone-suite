using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using OPMedia.Core.Logging;
using OPMedia.Core;

namespace OPMedia.Runtime.ProTONE.FileInformation
{
    public class DvdMedia
    {
        string _dvdPath = string.Empty;
        VideoDvdInformation _info = null;

        public VideoDvdInformation VideoDvdInformation { get { return _info; } }

        public string DvdPath { get { return _dvdPath; } }
        public string Label { get { return _info.Label; } }

        public override int GetHashCode()
        {
            return _dvdPath.GetHashCode() + Label.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            DvdMedia drv = obj as DvdMedia;
            if (drv == null) return false;

            return (_dvdPath == drv._dvdPath && Label == drv.Label);
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}]", _dvdPath, Label);
        }

        public static DvdMedia FromPath(string path)
        {
            try
            {
                // If this path is not related with a DVD media
                // the constructor will throw an exception
                return new DvdMedia(path);
            }
            catch
            {
                return null;
            }
        }

        public static List<DvdMedia> GetAllDvdMedias()
        {
            List<DvdMedia> drives = new List<DvdMedia>();

            try
            {
                foreach (DriveInfo drvInfo in DriveInfo.GetDrives())
                {
                    string drivePath = drvInfo.RootDirectory.FullName;

                    DvdMedia dvdDrive = DvdMedia.FromPath(drivePath);
                    if (dvdDrive != null)
                    {
                        drives.Add(dvdDrive);
                    }
                }
            }
            catch
            {
            }

            return drives;
        }

        private DvdMedia(string path)
        {
            if (Directory.Exists(path))
            {
                string root = Path.GetPathRoot(path);
                DriveInfo drv = new DriveInfo(root);

                if (path.ToUpperInvariant().EndsWith("VIDEO_TS") ||      // this is the case of a DVD folder somewhere in the system
                    PathUtils.PathHasChildFolder(path, "VIDEO_TS") ||
                    (drv.DriveType == DriveType.CDRom && drv.IsReady)) // this covers the disks in the DVD-ROM units
                    
                {
                    _dvdPath = path;

                    // Should this sequence throw an exception -- invalid DVD media
                    _info = new VideoDvdInformation(_dvdPath);
                }
            }

            if (string.IsNullOrEmpty(_dvdPath))
                throw new ArgumentException("An invalid DVD volume was specified.");
        }

    }
}
