using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;
using OPMedia.Runtime.ProTONE.Rendering.Cdda;
using OPMedia.Core;
using System.IO;
using System.Runtime.InteropServices;

namespace OPMedia.Runtime.ProTONE.Rendering.DS.DsFilters
{
    public class AudioCdFileParser : FileParser
    {
        [StructLayout(LayoutKind.Sequential)]
        private class OUTPUT_DATA_HEADER
        {
            public uint dwData = 0;
            public uint dwDataLength = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        private class OUTPUT_FILE_HEADER
        {
            public uint dwRiff = 0;
            public uint dwFileSize = 0;
            public uint dwWave = 0;
            public uint dwFormat = 0;
            public uint dwFormatLength = 0;
        }

        public const uint RIFF_TAG = 0x46464952;
        public const uint CDDA_TAG = 0x41444443;
        public const uint WAVE_TAG = 0x45564157;
        public const uint FMT__TAG = 0x20746D66;
        public const uint DATA_TAG = 0x61746164;
        public const uint WAVE_FORMAT_PCM = 0x01;

        CDDrive _cdrom = new CDDrive();

        int _track = -1;

        public CDDrive CDDrive { get { return _cdrom; } }

        public int Track { get { return _track; } }

        public AudioCdFileParser()
            : base(false)
        {
        }

        protected long m_llDataOffset = 0;
        public long DataOffset
        {
            get { return m_llDataOffset; }
        }

        protected override HRESULT CheckFile()
        {
            try
            {
                string rootPath = Path.GetPathRoot(m_sFileName);
                if (!string.IsNullOrEmpty(rootPath))
                {
                    if (_cdrom.Open(rootPath.ToUpperInvariant()[0]))
                    {
                        if (_cdrom.Refresh()) /* verifies if CD is ready and also reads TOC */
                        {
                            string trackStr = m_sFileName.Replace(rootPath, "").ToLowerInvariant().Replace("track", "").Replace(".cda", "");
                            _track = -1;
                            if (int.TryParse(trackStr, out _track) && _track > 0)
                            {
                                if (_cdrom.IsAudioTrack(_track))
                                {
                                    return S_OK;
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            return S_FALSE;
        }

        byte[] _buffer = null;

        protected override HRESULT LoadTracks()
        {
            uint size = 0;
            int trackSize = _cdrom.ReadTrack(_track, null, ref size, null);
            if (size > 0)
            {
                WaveFormatEx wfex = WaveFormatEx.Cdda;
                AMMediaType mt = new AMMediaType();

                mt.majorType = MediaType.Audio;
                mt.subType = MediaSubType.PCM;
                mt.sampleSize = wfex.nBlockAlign;
                mt.fixedSizeSamples = true;
                mt.SetFormat(wfex);
                m_Tracks.Add(new CdTrack(this, mt));

                m_llDataOffset = 0;
                m_rtDuration = (UNITS * (size - m_llDataOffset)) / wfex.nAvgBytesPerSec;

                return S_OK;
            }

            _buffer = new byte[size];

            return S_FALSE;
        }
    }

    public class CdTrack : DemuxTrack
    {
        #region Variables

        protected AMMediaType m_mt = null;
        //protected long m_ullReadPosition = 0;
        protected int m_lSampleSize = 0;
        protected long m_rtMediaPosition = 0;

        #endregion

        #region Constructor

        public CdTrack(AudioCdFileParser _parser, AMMediaType mt)
            : base(_parser, TrackType.Audio)
        {
            m_mt = mt;
            WaveFormatEx _wfx = m_mt;
            m_lSampleSize = _wfx.nAvgBytesPerSec / 2;
        }

        #endregion

        #region Overridden Methods

        public override HRESULT SetMediaType(AMMediaType pmt)
        {
            if (pmt.majorType != m_mt.majorType) 
                return VFW_E_TYPE_NOT_ACCEPTED;
            
            if (pmt.formatPtr == IntPtr.Zero) 
                return VFW_E_INVALIDMEDIATYPE;
            
            if (pmt.subType != m_mt.subType)
                return VFW_E_TYPE_NOT_ACCEPTED;
            
            if (pmt.formatType != m_mt.formatType) 
                return VFW_E_TYPE_NOT_ACCEPTED;

            return NOERROR;
        }

        public override HRESULT GetMediaType(int iPosition, ref AMMediaType pmt)
        {
            if (iPosition < 0) return E_INVALIDARG;
            if (iPosition > 0) return VFW_S_NO_MORE_ITEMS;
            pmt.Set(m_mt);
            return NOERROR;
        }

        public override HRESULT SeekTrack(long _time)
        {
            m_rtMediaPosition = _time;
            return base.SeekTrack(_time);
        }

        public override PacketData GetNextPacket()
        {
            CDDrive cdrom = (m_pParser as AudioCdFileParser).CDDrive;
            int track = (m_pParser as AudioCdFileParser).Track;

            PacketData _data = new PacketData();
            _data.Buffer = new byte[m_lSampleSize * 2];
            uint size = (uint)_data.Buffer.Length;

            int bytesRead = cdrom.ReadTrack(track, _data.Buffer, ref size, (uint)(m_rtMediaPosition / UNITS), 
                1, 
                null);

            if (size > 0)
            {
                _data.Position = 0;
                _data.Size = (int)size;
                _data.SyncPoint = true;
                _data.Start = m_rtMediaPosition;
                _data.Stop = _data.Start + UNITS;
                m_rtMediaPosition = _data.Stop;

                return _data;
            }

            return null;
        }

        #endregion
    }

    public class AudioCdSourceFilter : BaseSourceFilterTemplate<AudioCdFileParser>
    {
        public AudioCdSourceFilter()
            : base("OPM Audio CD Source Filter")
        {
        }
    }
}
