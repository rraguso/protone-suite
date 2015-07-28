using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Runtime.ProTONE.Rendering.Cdda.Freedb;
using OPMedia.Runtime.ProTONE.Rendering.Cdda;
using System.IO;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;
using System.Runtime.InteropServices;

namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Helpers
{
    class GrabberToWave : CdRipper
    {
        public override void Grab(CDDrive cd, Track track, string destFile, bool generateTags)
        {
            byte[] buff = base.GetTrackData(cd, track);
            WriteBuffer(buff, WaveFormatEx.Cdda, destFile);
        }

        public void WriteBuffer(byte[] buff, WaveFormatEx wfex, string destFile)
        {
            using (FileStream fs = new FileStream(destFile, FileMode.Create, FileAccess.Write, FileShare.None))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(RIFF_TAG);
                bw.Write((uint)(WaveHeaderSize + buff.Length));
                bw.Write(WAVE_TAG);
                bw.Write(FMT__TAG);
                bw.Write(WaveFormatSize);

                int size = Marshal.SizeOf(wfex);
                byte[] arr = new byte[size];
                IntPtr ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(wfex, ptr, true);
                Marshal.Copy(ptr, arr, 0, size);
                Marshal.FreeHGlobal(ptr);

                bw.Write(arr);
                bw.Write(DATA_TAG);
                bw.Write(buff.Length);
                bw.Write(buff);
            }
        }
    }
}
