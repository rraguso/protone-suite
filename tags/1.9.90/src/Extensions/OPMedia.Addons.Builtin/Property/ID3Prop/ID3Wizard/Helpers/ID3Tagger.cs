using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.ProTONE.FileInformation;
using System.IO;
using OPMedia.Core;
using OPMedia.Runtime;
using OPMedia.Core.Utilities;

namespace OPMedia.Addons.Builtin.ID3Prop.ID3Wizard
{
    public class ID3Tagger
    {
        ID3FileInfo ifi = null;
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

        public ID3Tagger(string path, Task task)
        {
            this.ifi = new ID3FileInfo(path, false);
            this.task = task;

            if (ifi.IsValid)
            {
                FileInfo fi = ifi.FileSystemInfo as FileInfo;
                if (fi != null)
                {
                    _name = fi.Name.Replace(fi.Extension, string.Empty);
                    _folder = fi.Directory.Name;
                }

                if (ifi.HasID3)
                {
                    _artist = ifi.Artist;
                    _album = ifi.Album;
                    _title = ifi.Title;
                    _genre = ifi.Genre;
                    _comments = ifi.Comments;
                    _track = ifi.Track.GetValueOrDefault().ToString("d2");
                    _year = ifi.Year.GetValueOrDefault().ToString("d4");
                }
            }
        }

        public void UpdateTag(WordCasing wordCasing)
        {
            PreviewUpdateTag(wordCasing).Save();
        }

        public ID3FileInfo PreviewUpdateTag(WordCasing wordCasing)
        {
            ifi.Artist = StringUtils.Capitalize(GetTagValue(task.Artist), wordCasing);
            ifi.Album = StringUtils.Capitalize(GetTagValue(task.Album), wordCasing);
            ifi.Title = StringUtils.Capitalize(GetTagValue(task.Title), wordCasing);
            ifi.Genre = StringUtils.Capitalize(GetTagValue(task.Genre), wordCasing);
            ifi.Comments = StringUtils.Capitalize(GetTagValue(task.Comments), wordCasing);

            short tmp;

            short.TryParse(GetTagValue(task.Track), out tmp);
            ifi.Track = tmp;

            short.TryParse(GetTagValue(task.Year), out tmp);
            ifi.Year = tmp;

            return ifi;
        }

        public void FillTagFromFileFolderName(WordCasing wordCasing)
        {
            PreviewTagFromFileFolderName(wordCasing).Save();
        }

        public ID3FileInfo PreviewTagFromFileFolderName(WordCasing wordCasing)
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

            if (artist.Length > 0) ifi.Artist = StringUtils.Capitalize(artist, wordCasing);
            if (album.Length > 0) ifi.Album = StringUtils.Capitalize(album, wordCasing);
            if (title.Length > 0) ifi.Title = StringUtils.Capitalize(title, wordCasing);
            if (genre.Length > 0) ifi.Genre = StringUtils.Capitalize(genre, wordCasing);
            if (comments.Length > 0) ifi.Comments = StringUtils.Capitalize(comments, wordCasing);

            short tmp;

            if (track.Length > 0)
            {
                short.TryParse(track, out tmp);
                ifi.Track = tmp;
            }

            if (year.Length > 0)
            {
                short.TryParse(year, out tmp);
                ifi.Year = tmp;
            }

            return ifi;
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
