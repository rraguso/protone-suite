using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Runtime.ProTONE.Rendering.Cdda;
using OPMedia.Runtime.ProTONE.Rendering.Cdda.Freedb;
using System.IO;
using OPMedia.Runtime.ProTONE.Compression.Lame;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Core.Utilities;

namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Helpers
{
    class GrabberToMP3 : CdRipper
    {
        public BE_CONFIG Mp3ConversionOptions;

        private uint m_hLameStream = 0;
        private uint m_InputSamples = 0;
        private uint m_OutBufferSize = 0;
        private byte[] m_OutBuffer = null;

        public override void Grab(CDDrive cd, Track track, string destFile, bool generateTags)
        {
            if (MustCancel())
                return;

            byte[] buff = base.GetTrackData(cd, track);

            if (MustCancel())
                return;

            using (FileStream fs = new FileStream(destFile, FileMode.Create, FileAccess.Write, FileShare.None))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                uint LameResult = Lame_encDll.beInitStream(Mp3ConversionOptions, ref m_InputSamples, ref m_OutBufferSize, ref m_hLameStream);
                if (LameResult != Lame_encDll.BE_ERR_SUCCESSFUL)
                {
                    throw new ApplicationException(string.Format("Lame_encDll.beInitStream failed with the error code {0}", LameResult));
                }

                uint EncodedSize = 0;
                m_OutBuffer = new byte[m_OutBufferSize];

                if (MustCancel())
                    return;

                try
                {
                    int buffPos = 0;
                    while (buffPos < buff.Length)
                    {
                        if (MustCancel())
                            return;

                        m_OutBuffer = new byte[m_OutBufferSize];

                        uint bytesToCopy = Math.Min(2 * m_InputSamples, (uint)buff.Length - (uint)buffPos);

                        if ((LameResult = Lame_encDll.EncodeChunk(m_hLameStream, buff, buffPos, (uint)bytesToCopy, m_OutBuffer, ref EncodedSize)) == Lame_encDll.BE_ERR_SUCCESSFUL)
                        {
                            if (EncodedSize > 0)
                            {
                                bw.Write(m_OutBuffer, 0, (int)EncodedSize);
                            }
                        }
                        else
                        {
                            throw new ApplicationException(string.Format("Lame_encDll.EncodeChunk failed with the error code {0}", LameResult));
                        }

                        buffPos += (int)bytesToCopy;
                    }
                }
                finally
                {
                    EncodedSize = 0;
                    if (Lame_encDll.beDeinitStream(m_hLameStream, m_OutBuffer, ref EncodedSize) == Lame_encDll.BE_ERR_SUCCESSFUL)
                    {
                        if (EncodedSize > 0)
                        {
                            bw.Write(m_OutBuffer, 0, (int)EncodedSize);
                        }
                    }

                    Lame_encDll.beCloseStream(m_hLameStream);
                }
            }

            if (!MustCancel() && generateTags)
            {
                ID3FileInfo ifi = new ID3FileInfo(destFile, false);
                ifi.Album = StringUtils.Capitalize(track.Album, WordCasing.CapitalizeWords);
                ifi.Artist = StringUtils.Capitalize(track.Artist, WordCasing.CapitalizeWords);
                ifi.Genre = StringUtils.Capitalize(track.Genre, WordCasing.CapitalizeWords);
                ifi.Title = StringUtils.Capitalize(track.Title, WordCasing.CapitalizeWords);
                ifi.Track = (short)track.Index;
                
                short year = 1900;
                short.TryParse(track.Year, out year);
                ifi.Year = year;

                ifi.Save();
            }
        }
    }
}
