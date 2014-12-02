using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Core;
using System.IO;
using OPMedia.Runtime;
using OPMedia.Core.Utilities;

namespace OPMedia.Addons.Builtin.TaggedFileProp.TaggingWizard
{
    public class TaggedMediaFileRenamer
    {
        ITaggedMediaFileInfo _taggedFileInfo = null;
        string renamePattern;

        internal ITaggedMediaFileInfo TaggedFileInfo { get { return _taggedFileInfo; } }

        public TaggedMediaFileRenamer(string path, string renamePattern)
        {
            this._taggedFileInfo = TaggedMediaFileInfoFactory.GetTaggedMediaFileInfo(path, false);
            this.renamePattern = renamePattern;
        }

        public string GetNewPath(WordCasing wordCasing)
        {
            string retVal = _taggedFileInfo.Path;
            if (_taggedFileInfo.IsValid)
            {
                string newName = renamePattern;
                bool doRename = false;

                FileInfo fi = _taggedFileInfo.FileSystemInfo as FileInfo;
                if (fi != null)
                {
                    StringUtils.ReplaceToken(ref newName, "<N", fi.Name.Replace(fi.Extension, string.Empty));
                    StringUtils.ReplaceToken(ref newName, "<F", fi.Directory.Name);

                    doRename = true;
                }

                if (_taggedFileInfo.HasTag)
                {
                    StringUtils.ReplaceToken(ref newName, "<A", _taggedFileInfo.Artist);
                    StringUtils.ReplaceToken(ref newName, "<B", _taggedFileInfo.Album);
                    StringUtils.ReplaceToken(ref newName, "<T", _taggedFileInfo.Title);
                    StringUtils.ReplaceToken(ref newName, "<G", _taggedFileInfo.Genre);
                    StringUtils.ReplaceToken(ref newName, "<C", _taggedFileInfo.Comments);
                    StringUtils.ReplaceToken(ref newName, "<#", _taggedFileInfo.Track.GetValueOrDefault().ToString("d2"));
                    StringUtils.ReplaceToken(ref newName, "<Y", _taggedFileInfo.Year.GetValueOrDefault().ToString("d4"));
                }

                if (doRename)
                {
                    newName = StringUtils.StripInvalidPathChars(newName);
                    retVal = Path.Combine(fi.DirectoryName, StringUtils.Capitalize(newName, wordCasing) + fi.Extension);
                }
                
            }
            
            return retVal;
        }

        
    }
}
