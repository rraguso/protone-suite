using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;
using OPMedia.Runtime.ProTONE.Rendering.Cdda;
using OPMedia.Core;
using System.IO;
using System.Runtime.InteropServices;
using OPMedia.Runtime.ProTONE.Rendering.SHOUTCast;

namespace OPMedia.Runtime.ProTONE.Rendering.DS.DsFilters
{
    public class ShoutcastStreamParser : FileParser
    {
        ShoutcastStream _stream = null;

        public ShoutcastStream ShoutcastStream { get { return _stream; } }

        public ShoutcastStreamParser()
            : base(false)
        {
        }

        protected override HRESULT CheckFile()
        {
            _stream = new ShoutcastStream(m_sFileName);
            if (_stream != null && _stream.Connected)
                return S_OK;

            return S_FALSE;
        }

        protected override HRESULT LoadTracks()
        {
            Mp3WaveFormat _wfex = new Mp3WaveFormat();
            _wfex.cbSize = 12; // MPEGLAYER3_WFX_EXTRA_BYTES
            _wfex.fdwFlags = 0; // MPEGLAYER3_FLAG_PADDING_ISO
            _wfex.nAvgBytesPerSec = (_stream.Bitrate * 1024 / 8);
            _wfex.nBlockAlign = 1; // must be 1 for streamed MP3
            _wfex.nBlockSize = 522; // MP3_BLOCK_SIZE magic number
            _wfex.nChannels = 2; // Stereo
            _wfex.nCodecDelay = 0; // must be 0
            _wfex.nFramesPerBlock = 1; // must be 1
            _wfex.nSamplesPerSec = 44100; // 44.1 kHz
            _wfex.wBitsPerSample = 0; // must be 0
            _wfex.wFormatTag = 0x0055; // WAVE_FORMAT_MPEGLAYER3
            _wfex.wID = 1; // MPEGLAYER3_ID_MPEG

            AMMediaType mt = new AMMediaType();
            mt.majorType = MediaType.Audio;
            mt.subType = MediaSubType.MPEG1Audio;
            mt.sampleSize = 0;
            mt.fixedSizeSamples = false;
            mt.SetFormat(_wfex);
            m_Tracks.Add(new ShoutcastStreamTrack(this, mt));

            return S_OK;
        }
    }

    public class ShoutcastStreamTrack : DemuxTrack
    {
        #region Variables

        protected AMMediaType m_mt = null;
        protected long m_rtMediaPosition = 0;

        #endregion

        #region Constructor

        public ShoutcastStreamTrack(ShoutcastStreamParser _parser, AMMediaType mt)
            : base(_parser, TrackType.Audio)
        {
            m_mt = mt;
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
            ShoutcastStream ss = (m_pParser as ShoutcastStreamParser).ShoutcastStream;

            int slice = ss.Bitrate * 1024 / 8 ;

            PacketData _data = new PacketData();
            _data.Buffer = new byte[slice];

            int bytesRead = ss.Read(_data.Buffer, 0, slice);
            if (bytesRead > 0)
            {
                _data.Position = 0;
                _data.Size = (int)bytesRead;
                _data.SyncPoint = true;
                _data.Start = m_rtMediaPosition;
                _data.Stop = _data.Start + UNITS / 2;
                m_rtMediaPosition = _data.Stop;

                return _data;
            }

            return null;
        }

        #endregion
    }

    public class ShoutcastStreamSourceFilter : BaseSourceFilterTemplate<ShoutcastStreamParser>
    {
        public ShoutcastStreamSourceFilter()
            : base("OPM Shoutcast Stream Source Filter")
        {
        }
    }
}
