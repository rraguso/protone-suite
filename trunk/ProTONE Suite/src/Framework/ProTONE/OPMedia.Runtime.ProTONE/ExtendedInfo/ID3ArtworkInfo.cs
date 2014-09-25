using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using OPMedia.Core.TranslationSupport;
using System.ComponentModel;
using TagLib;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using OPMedia.Core.Logging;
using System.Runtime.Serialization.Formatters.Binary;
using OPMedia.Runtime.FileInformation;
using OPMedia.Core;

namespace OPMedia.Runtime.ProTONE.ExtendedInfo
{
    public class ID3ArtworkInfo
    {
        public List<PictureInfo> ArtworkImages = new List<PictureInfo>();
        private TagLib.Mpeg.AudioFile _af;

        [Browsable(false)]
        public string FileName
        { get { return (_af != null) ? _af.Name : null; } }

        public ID3ArtworkInfo Clone()
        {
            if (_af != null)
            {
                return new ID3ArtworkInfo(_af);
            }

            return null;
        }

        public override string ToString()
        {
            return Translator.Translate("TXT_ARTWORK_COUNT", ArtworkImages.Count);
        }

        internal void Load()
        {
            ArtworkImages.Clear();
            ReadPictures();
        }

        internal void Save()
        {
            // Remove All Old Artwork - not needed, this is done inside by _af.Tag.Pictures property

            List<Picture> pics = new List<Picture>();
            foreach (PictureInfo pi in ArtworkImages)
            {
                MemoryStream ms = new MemoryStream();
                
                Bitmap bmp = pi.Picture;

                const int MaxAPICFrameSize = 64 * 1024; // 64 kB
                
                bmp.Save(ms, ImageFormat.Png);
                while (ms.Length >= MaxAPICFrameSize)
                {
                    Size sz = bmp.Size;
                    sz.Width = (int)(sz.Width * 0.9);
                    sz.Height = (int)(sz.Height * 0.9);

                    bmp = new Bitmap(ImageProvider.ScaleImage(bmp, sz, false));
                    bmp.Save(ms, ImageFormat.Png);
                }
                
                Picture pic = new Picture();
                pic.Data = new ByteVector(ms.GetBuffer());
                pic.Description = pi.Description;
                pic.Type = pi.PictureType;
                pic.MimeType = "image/png";

                pics.Add(pic);
            }

            if (pics.Count > 0)
                _af.Tag.Pictures = pics.ToArray();
            else
                _af.Tag.Pictures = null;
        }

        public ID3ArtworkInfo(TagLib.Mpeg.AudioFile af)
        {
            _af = af;
            ReadPictures();
        }

        private void ReadPictures()
        {
            if (_af != null && _af.Tag != null)
            {
                foreach (IPicture picture in _af.Tag.Pictures)
                {
                    if (picture != null)
                    {
                        try
                        {
                            MemoryStream ms = new MemoryStream(picture.Data.Data);
                            Bitmap bmp = new Bitmap(ms);

                            PictureInfo pi = new PictureInfo(bmp.Clone() as Bitmap, picture.Type, picture.Description, picture.MimeType);
                            ArtworkImages.Add(pi);
                        }
                        catch (Exception ex)
                        {
                            Logger.LogException(ex);
                        }
                    }
                }
            }
        }

    }

    public class PictureInfo
    {
        public Bitmap Picture = null;
        public PictureType PictureType = PictureType.Other;
        public string Description = null;
        public string MimeType = null;

        public PictureInfo()
        {
        }

        public PictureInfo(Bitmap picture, PictureType pictureType, string desc, string mimeType)
        {
            this.Picture = picture;
            this.PictureType = pictureType;
            this.Description = desc;
            this.MimeType = mimeType;
        }
    }
}
