using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OPMedia.Runtime.ProTONE.FileInformation
{
    public interface ITaggedMediaFileInfo
    {
        string Path { get; }
        FileSystemInfo FileSystemInfo { get; }
        bool IsValid { get; }

        bool HasTag { get; }
        string Artist { get; set; }
        string Album { get; set; }
        string Title { get; set; }
        string Comments { get; set; }
        string Genre { get; set; }
        short? Track { get; set; }
        short? Year { get; set; }

        void Save();
    }

    public static class TaggedMediaFileInfoFactory
    {
        public static ITaggedMediaFileInfo GetTaggedMediaFileInfo(string path, bool deepLoad)
        {
            MediaFileInfo mfi = MediaFileInfo.FromPath(path, deepLoad);
            return mfi as ITaggedMediaFileInfo;
        }

        public static List<String> TaggedFileTypes
        {
            get
            {
                return new List<string>(new string[] { "mp1", "mp2", "mp3" });
            }
        }
    }
}
