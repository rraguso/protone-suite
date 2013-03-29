using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Core;
using System.IO;
using OPMedia.Runtime;
using OPMedia.Core.Utilities;

namespace OPMedia.Addons.Builtin.ID3Prop.ID3Wizard
{
    public class ID3FileRenamer
    {
        ID3FileInfo ifi = null;
        string renamePattern;

        public ID3FileRenamer(string path, string renamePattern)
        {
            this.ifi = new ID3FileInfo(path, false);
            this.renamePattern = renamePattern;
        }

        public string GetNewPath(WordCasing wordCasing)
        {
            string retVal = ifi.Path;
            if (ifi.IsValid)
            {
                string newName = renamePattern;
                bool doRename = false;

                FileInfo fi = ifi.FileSystemInfo as FileInfo;
                if (fi != null)
                {
                    StringUtils.ReplaceToken(ref newName, "<N", fi.Name.Replace(fi.Extension, string.Empty));
                    StringUtils.ReplaceToken(ref newName, "<F", fi.Directory.Name);

                    doRename = true;
                }

                if (ifi.HasID3)
                {
                    StringUtils.ReplaceToken(ref newName, "<A", ifi.Artist);
                    StringUtils.ReplaceToken(ref newName, "<B", ifi.Album);
                    StringUtils.ReplaceToken(ref newName, "<T", ifi.Title);
                    StringUtils.ReplaceToken(ref newName, "<G", ifi.Genre);
                    StringUtils.ReplaceToken(ref newName, "<C", ifi.Comments);
                    StringUtils.ReplaceToken(ref newName, "<#", ifi.Track.GetValueOrDefault().ToString("d2"));
                    StringUtils.ReplaceToken(ref newName, "<Y", ifi.Year.GetValueOrDefault().ToString("d4"));
                }

                if (doRename)
                {
                    newName = StripInvalidPathChars(newName);
                    retVal = Path.Combine(fi.DirectoryName, StringUtils.Capitalize(newName, wordCasing) + fi.Extension);
                }
                
            }
            
            return retVal;
        }

        private string StripInvalidPathChars(string newName)
        {
            string retVal = newName.Replace("<", string.Empty).Replace(">", string.Empty);

            foreach (char cInvalid in Path.GetInvalidFileNameChars())
            {
                retVal = retVal.Replace(cInvalid, '_');
            }

            return retVal;
        }
    }
}
