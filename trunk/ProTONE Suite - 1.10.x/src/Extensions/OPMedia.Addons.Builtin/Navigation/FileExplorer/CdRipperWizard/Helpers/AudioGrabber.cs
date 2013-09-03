using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Tasks;
using OPMedia.Runtime.ProTONE.Rendering.Cdda;
using OPMedia.Runtime.ProTONE.Rendering.Cdda.Freedb;
using OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Forms;

namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Helpers
{
    public abstract class CdRipper
    {
        public static CdRipper CreateGrabber(CdRipperOutputFormatType outputType)
        {
            switch (outputType)
            {
                case CdRipperOutputFormatType.WAV:
                    return new GrabberToWave();
                
                case CdRipperOutputFormatType.MP3:
                    return new GrabberToMP3();
                
                case CdRipperOutputFormatType.WMA:
                    return new GrabberToWMA();
                
                case CdRipperOutputFormatType.OGG:
                    return new GrabberToOGG();
            }

            return null;
        }

        public virtual string Grab(CDDrive cd, Track track)
        {
            throw new NotImplementedException(string.Format("{0} cannot be used to grab an audio CD.", this.GetType()));
        }

        protected byte[] GetTrackData(CDDrive cd, Track track)
        {
            uint size = cd.TrackSize(track.Index);
            byte[] buff = new byte[size];
            int x = cd.ReadTrack(track.Index, buff, ref size, null);
            return buff;
        }
    }
}
