using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Runtime.ProTONE.Rendering.Cdda.Freedb;
using OPMedia.Runtime.ProTONE.Rendering.Cdda;
using System.IO;

namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Helpers
{
    class GrabberToWave : CdRipper
    {
        public override string Grab(CDDrive cd, Track track)
        {
            byte[] buff = base.GetTrackData(cd, track);
            if (buff == null || buff.Length < 1)
                throw new InvalidDataException("TXT_INVALID_TRACK_DATA");

            string file = Path.GetTempFileName();
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.Write(buff);
            }

            return file;
        }
    }
}
