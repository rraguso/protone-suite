using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Tasks;
using OPMedia.Runtime.ProTONE.Rendering.Cdda;
using OPMedia.Runtime.ProTONE.Rendering.Cdda.Freedb;
using OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Forms;
using System.IO;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Addons.Builtin.TaggedFileProp.TaggingWizard;
using OPMedia.Core.Utilities;
using System.Threading;

namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Helpers
{
    public abstract class CdRipper
    {
        protected const uint RIFF_TAG = 0x46464952;
        protected const uint CDDA_TAG = 0x41444443;
        protected const uint WAVE_TAG = 0x45564157;
        protected const uint FMT__TAG = 0x20746D66;
        protected const uint DATA_TAG = 0x61746164;
        public const uint WAVE_FORMAT_PCM = 0x01;

        public const uint WaveHeaderSize = 38;
        public const uint WaveFormatSize = 18;

        private bool _cancel = false;
        private object _cancelLock = new object();

        public void RequestCancel()
        {
            lock (_cancelLock)
            {
                _cancel = true;
            }
        }

        public bool MustCancel()
        {
            lock (_cancelLock)
            {
                return _cancel;
            }
        }

        public static CdRipper CreateGrabber(CdRipperOutputFormatType outputType)
        {
            switch (outputType)
            {
                case CdRipperOutputFormatType.WAV:
                    return new GrabberToWave();
                
                case CdRipperOutputFormatType.MP3:
                    return new GrabberToMP3();
                
                //case CdRipperOutputFormatType.WMA:
                //    return new GrabberToWMA();
                
                //case CdRipperOutputFormatType.OGG:
                //    return new GrabberToOGG();
            }

            return null;
        }

        public virtual void Grab(CDDrive cd, Track track, string destFile, bool generateTags)
        {
            throw new NotImplementedException(string.Format("{0} cannot be used to grab an audio CD.", this.GetType()));
        }

        protected byte[] GetTrackData(CDDrive cd, Track track)
        {
            uint size = cd.TrackSize(track.Index);
            byte[] buff = new byte[size];
            int x = cd.ReadTrack(track.Index, buff, ref size, null);

            if (buff == null || buff.Length < 1)
                throw new InvalidDataException("TXT_INVALID_TRACK_DATA");

            return buff;
        }

        public static string GetFileName(WordCasing wordCasing, Track track, string renamePattern)
        {
            string newName = renamePattern;
            
            StringUtils.ReplaceToken(ref newName, "<A", track.Artist);
            StringUtils.ReplaceToken(ref newName, "<B", track.Album);
            StringUtils.ReplaceToken(ref newName, "<T", track.Title);
            StringUtils.ReplaceToken(ref newName, "<G", track.Genre);
            StringUtils.ReplaceToken(ref newName, "<#", track.Index.ToString("d2"));
            StringUtils.ReplaceToken(ref newName, "<Y", track.Year);

            newName = StringUtils.StripInvalidPathChars(newName);
            if (!string.IsNullOrEmpty(newName))
            {
                return newName;
            }

            return string.Format("track{0:d2}", track.Index);;
        }
    }
}
