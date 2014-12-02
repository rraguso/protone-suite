using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.ProTONE.FileInformation;
using System.IO;
using OPMedia.Core;
using OPMedia.Runtime;
using OPMedia.Core.Utilities;

namespace OPMedia.Addons.Builtin.TaggedFileProp.TaggingWizard
{
    public class MediaFileTagger
    {
        ITaggedMediaFileInfo _taggedFileInfo = null;
        Task task = null;
        
        string _name = string.Empty;
        string _folder = string.Empty;
        string _artist = string.Empty;
        string _album = string.Empty;
        string _title = string.Empty;
        string _genre = string.Empty;
        string _comments = string.Empty;
        string _track = string.Empty;
        string _year = string.Empty;

        public MediaFileTagger(string path, Task task)
        {
            this._taggedFileInfo = TaggedMediaFileInfoFactory.GetTaggedMediaFileInfo(path, false);
            this.task = task;

            if (_taggedFileInfo.IsValid)
            {
                FileInfo fi = _taggedFileInfo.FileSystemInfo as FileInfo;
                if (fi != null)
                {
                    _name = fi.Name.Replace(fi.Extension, string.Empty);
                    _folder = fi.Directory.Name;
                }

                if (_taggedFileInfo.HasTag)
                {
                    _artist = _taggedFileInfo.Artist;
                    _album = _taggedFileInfo.Album;
                    _title = _taggedFileInfo.Title;
                    _genre = _taggedFileInfo.Genre;
                    _comments = _taggedFileInfo.Comments;
                    _track = _taggedFileInfo.Track.GetValueOrDefault().ToString("d2");
                    _year = _taggedFileInfo.Year.GetValueOrDefault().ToString("d4");
                }
            }
        }

        public void UpdateTag(WordCasing wordCasing)
        {
            PreviewUpdateTag(wordCasing).Save();
        }

        public ITaggedMediaFileInfo PreviewUpdateTag(WordCasing wordCasing)
        {
            _taggedFileInfo.Artist = StringUtils.Capitalize(GetTagValue(task.Artist), wordCasing);
            _taggedFileInfo.Album = StringUtils.Capitalize(GetTagValue(task.Album), wordCasing);
            _taggedFileInfo.Title = StringUtils.Capitalize(GetTagValue(task.Title), wordCasing);
            _taggedFileInfo.Genre = StringUtils.Capitalize(GetTagValue(task.Genre), wordCasing);
            _taggedFileInfo.Comments = StringUtils.Capitalize(GetTagValue(task.Comments), wordCasing);

            short tmp;

            short.TryParse(GetTagValue(task.Track), out tmp);
            _taggedFileInfo.Track = tmp;

            short.TryParse(GetTagValue(task.Year), out tmp);
            _taggedFileInfo.Year = tmp;

            return _taggedFileInfo;
        }

        public void FillTagFromFileFolderName(WordCasing wordCasing)
        {
            PreviewTagFromFileFolderName(wordCasing).Save();
        }

        public ITaggedMediaFileInfo PreviewTagFromFileFolderName(WordCasing wordCasing)
        {
            Dictionary<string, string> fileTokens = StringUtils.Tokenize(_name, task.TagFilePattern);
            Dictionary<string, string> folderTokens = StringUtils.Tokenize(_folder, task.TagFolderPattern);

            string artist = GetTokenValue(fileTokens, folderTokens, "<A>");
            string album = GetTokenValue(fileTokens, folderTokens, "<B>");
            string title = GetTokenValue(fileTokens, folderTokens, "<T>");
            string genre = GetTokenValue(fileTokens, folderTokens, "<G>");
            string comments = GetTokenValue(fileTokens, folderTokens, "<C>");
            string track = GetTokenValue(fileTokens, folderTokens, "<#>");
            string year = GetTokenValue(fileTokens, folderTokens, "<Y>");

            if (artist.Length > 0) _taggedFileInfo.Artist = StringUtils.Capitalize(artist, wordCasing);
            if (album.Length > 0) _taggedFileInfo.Album = StringUtils.Capitalize(album, wordCasing);
            if (title.Length > 0) _taggedFileInfo.Title = StringUtils.Capitalize(title, wordCasing);
            if (genre.Length > 0) _taggedFileInfo.Genre = StringUtils.Capitalize(genre, wordCasing);
            if (comments.Length > 0) _taggedFileInfo.Comments = StringUtils.Capitalize(comments, wordCasing);

            short tmp;

            if (track.Length > 0)
            {
                short.TryParse(track, out tmp);
                _taggedFileInfo.Track = tmp;
            }

            if (year.Length > 0)
            {
                short.TryParse(year, out tmp);
                _taggedFileInfo.Year = tmp;
            }

            return _taggedFileInfo;
        }

        private string GetTagValue(string initial)
        {
            string final = initial;
            StringUtils.ReplaceToken(ref final, "<N", _name);
            StringUtils.ReplaceToken(ref final, "<F", _folder);
            StringUtils.ReplaceToken(ref final, "<A", _artist);
            StringUtils.ReplaceToken(ref final, "<B", _album);
            StringUtils.ReplaceToken(ref final, "<T", _title);
            StringUtils.ReplaceToken(ref final, "<G", _genre);
            StringUtils.ReplaceToken(ref final, "<C", _comments);
            StringUtils.ReplaceToken(ref final, "<#", _track);
            StringUtils.ReplaceToken(ref final, "<Y", _year);
            return final;//.Replace(initial, string.Empty);
        }

        private string GetTokenValue(Dictionary<string, string> tokens1,
            Dictionary<string, string> tokens2, string token)
        {
            if (tokens1 != null && tokens1.Count > 0 && tokens1.ContainsKey(token))
                return tokens1[token];

            if (tokens2 != null && tokens2.Count > 0 && tokens2.ContainsKey(token))
                return tokens2[token];

            return string.Empty;
        }
    }
}
