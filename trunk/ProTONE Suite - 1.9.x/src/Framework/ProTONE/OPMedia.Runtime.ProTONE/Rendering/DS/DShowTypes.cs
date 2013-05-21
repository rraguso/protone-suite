#if HAVE_DSHOW
using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
using System.Runtime.CompilerServices;
using System.Security;
using System.Runtime.InteropServices.ComTypes;
using OPMedia.Core;
using OPMedia.Core.Logging;
using QuartzTypeLib;
using System.Drawing;
using OPMedia.Runtime.ProTONE.Rendering.Base;
using DexterLib;

namespace OPMedia.Runtime.ProTONE.Rendering.DS
{
    public class DsError
    {
        public static void ThrowExceptionForHR(int hr)
        {
                if (hr < 0)
                    throw new COMException("Error: ", hr);
        }

        //public static void CheckHResult(string prefixMsg, int hr)
        //{
        //    if (hr < 0)
        //        throw new COMException(prefixMsg, hr);
        //}

        public static string GetErrorMessageForHr(int hr)
        {
            return ErrorDispatcher.GetErrorMessageForException(new COMException("Error: ", hr), true);
        }
    }

    public static class PropSetID
    {
        // Fields
        public static readonly Guid CODECAPI_AllSettings = new Guid(0x6a577e92, 0x83e1, 0x4113, 0xad, 0xc2, 0x4f, 0xce, 0xc3, 0x2f, 0x83, 0xa1);
        public static readonly Guid CODECAPI_AudioEncoder = new Guid(0xb9d19a3e, 0xf897, 0x429c, 0xbc, 70, 0x81, 0x38, 0xb7, 0x27, 0x2b, 0x2d);
        public static readonly Guid CODECAPI_AVDecMmcssClass = new Guid(0xe0ad4828, 0xdf66, 0x4893, 0x9f, 0x33, 120, 0x8a, 0xa4, 0xec, 0x40, 130);
        public static readonly Guid CODECAPI_ChangeLists = new Guid(0x62b12acf, 0xf6b0, 0x47d9, 0x94, 0x56, 150, 0xf2, 0x2c, 0x4e, 11, 0x9d);
        public static readonly Guid CODECAPI_CurrentChangeList = new Guid(0x1cb14e83, 0x7d72, 0x4657, 0x83, 0xfd, 0x47, 0xa2, 0xc5, 0xb9, 0xd1, 0x3d);
        public static readonly Guid CODECAPI_SetAllDefaults = new Guid(0x6c5e6a7c, 0xacf8, 0x4f55, 0xa9, 0x99, 0x1a, 0x62, 0x81, 9, 5, 0x1b);
        public static readonly Guid CODECAPI_SupportsEvents = new Guid(0x581af97, 0x7693, 0x4dbd, 0x9d, 0xca, 0x3f, 0x9e, 0xbd, 0x65, 0x85, 0xa1);
        public static readonly Guid CODECAPI_VideoEncoder = new Guid(0x7112e8e1, 0x3d03, 0x47ef, 0x8e, 0x60, 3, 0xf1, 0xcf, 0x53, 0x73, 1);
        public static readonly Guid DroppedFrames = new Guid(0xc6e13344, 0x30ac, 0x11d0, 0xa1, 140, 0, 160, 0xc9, 0x11, 0x89, 0x56);
        public static readonly Guid ENCAPIPARAM_BitRate = new Guid(0x49cc4c43, 0xca83, 0x4ad4, 0xa9, 0xaf, 0xf3, 0x69, 0x6a, 0xf6, 0x66, 0xdf);
        public static readonly Guid ENCAPIPARAM_BitRateMode = new Guid(0xee5fb25c, 0xc713, 0x40d1, 0x9d, 0x58, 0xc0, 0xd7, 0x24, 30, 0x25, 15);
        public static readonly Guid ENCAPIPARAM_PeakBitRate = new Guid(0x703f16a9, 0x3d48, 0x44a1, 0xb0, 0x77, 1, 0x8d, 0xff, 0x91, 0x5d, 0x19);
        public static readonly Guid ENCAPIPARAM_SAP_MODE = new Guid(0xc0171db, 0xfefc, 0x4af7, 0x99, 0x91, 0xa5, 0x65, 0x7c, 0x19, 0x1c, 0xd1);
        public static readonly Guid Pin = new Guid(0x9b00f101, 0x1567, 0x11d1, 0xb3, 0xf1, 0, 170, 0, 0x37, 0x61, 0xc5);
    }

    public static class Filters		// uuids.h  :  CLSID_*
    {
        public static readonly Guid FileSource = new Guid("e436ebb5-524f-11ce-9f53-0020af0ba770");

        /// <summary> CLSID_SystemDeviceEnum for ICreateDevEnum </summary>
        public static readonly Guid SystemDeviceEnum = new Guid(0x62BE5D10, 0x60EB, 0x11d0, 0xBD, 0x3B, 0x00, 0xA0, 0xC9, 0x11, 0xCE, 0x86);

        /// <summary> CLSID_FilterGraph, filter Graph </summary>
        public static readonly Guid FilterGraph = new Guid(0xe436ebb3, 0x524f, 0x11ce, 0x9f, 0x53, 0x00, 0x20, 0xaf, 0x0b, 0xa7, 0x70);

        /// <summary> filter Graph no thread </summary>
        public static readonly Guid FilterGraphNoThread = new Guid("E436EBB8-524F-11CE-9F53-0020AF0BA770");

        /// <summary> CLSID_CaptureGraphBuilder2, new Capture graph building </summary>
        public static readonly Guid CaptureGraphBuilder2 = new Guid(0xBF87B6E1, 0x8C27, 0x11d0, 0xB3, 0xF0, 0x0, 0xAA, 0x00, 0x37, 0x61, 0xC5);

        /// <summary> CLSID_SampleGrabber, Sample Grabber filter </summary>
        public static readonly Guid SampleGrabber = new Guid(0xC1F400A0, 0x3F08, 0x11D3, 0x9F, 0x0B, 0x00, 0x60, 0x08, 0x03, 0x9E, 0x37);

        /// <summary> CLSID_DvdGraphBuilder, DVD graph builder </summary>
        public static readonly Guid DvdGraphBuilder = new Guid(0xFCC152B7, 0xF372, 0x11d0, 0x8E, 0x00, 0x00, 0xC0, 0x4F, 0xD7, 0xC0, 0x8B);

        /// <summary> CLSID_StreamBufferSink, stream buffer sink </summary>
        public static readonly Guid StreamBufferSink = new Guid("2db47ae5-cf39-43c2-b4d6-0cd8d90946f4");

        /// <summary> CLSID_StreamBufferSource, stream buffer sink </summary>
        public static readonly Guid StreamBufferSource = new Guid("c9f5fe02-f851-4eb5-99ee-ad602af1e619");

        /// <summary> CLSID_VideoMixingRenderer, video mixing renderer 7 </summary>
        public static readonly Guid VideoMixingRenderer = new Guid(0xB87BEB7B, 0x8D29, 0x423f, 0xAE, 0x4D, 0x65, 0x82, 0xC1, 0x01, 0x75, 0xAC);

        /// <summary> CLSID_VideoMixingRenderer9, video mixing renderer 9 </summary>
        public static readonly Guid VideoMixingRenderer9 = new Guid(0x51b4abf3, 0x748f, 0x4e3b, 0xa2, 0x76, 0xc8, 0x28, 0x33, 0x0e, 0x92, 0x6a);

        /// <summary> CLSID_VideoRendererDefault, default vmr renderer </summary>
        public static readonly Guid VideoRendererDefault = new Guid(0x6BC1CFFA, 0x8FC1, 0x4261, 0xAC, 0x22, 0xCF, 0xB4, 0xCC, 0x38, 0xDB, 0x50);

        /// <summary> CLSID_AviSplitter, split an AVI stream into separate video and audio streams </summary>
        public static readonly Guid AviSplitter = new Guid(0x1b544c20, 0xfd0b, 0x11ce, 0x8c, 0x63, 0x0, 0xaa, 0x00, 0x44, 0xb5, 0x1e);

        /// <summary> CLSID_SmartTee, create a preview stream when device only provides a capture stream. </summary>
        public static readonly Guid SmartTee = new Guid(0xcc58e280, 0x8aa1, 0x11d1, 0xb3, 0xf1, 0x0, 0xaa, 0x0, 0x37, 0x61, 0xc5);
    }

    public static class DsConstants
    {
        public const int DsFalse = 0;
        public const int DsTrue = -1;
    }

    [StructLayout(LayoutKind.Explicit)]
    public class DsGuid
    {
        // Fields
        public static readonly DsGuid Empty = Guid.Empty;
        [FieldOffset(0)]
        private Guid guid;

        // Methods
        public DsGuid()
        {
            this.guid = Guid.Empty;
        }

        public DsGuid(Guid g)
        {
            this.guid = g;
        }

        public DsGuid(string g)
        {
            this.guid = new Guid(g);
        }

        public static DsGuid FromGuid(Guid g)
        {
            return new DsGuid(g);
        }

        public override int GetHashCode()
        {
            return this.guid.GetHashCode();
        }

        public static implicit operator Guid(DsGuid g)
        {
            return g.guid;
        }

        public static implicit operator DsGuid(Guid g)
        {
            return new DsGuid(g);
        }

        public Guid ToGuid()
        {
            return this.guid;
        }

        public override string ToString()
        {
            return this.guid.ToString();
        }

        public string ToString(string format)
        {
            return this.guid.ToString(format);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public class DsLong
    {
        private long Value;
        public DsLong(long Value)
        {
            this.Value = Value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public static implicit operator long(DsLong l)
        {
            return l.Value;
        }

        public static implicit operator DsLong(long l)
        {
            return new DsLong(l);
        }

        public long ToInt64()
        {
            return this.Value;
        }

        public static DsLong FromInt64(long l)
        {
            return new DsLong(l);
        }
    }

    public static class MediaType
    {
        // Fields
        public static readonly Guid AnalogAudio = new Guid(0x482dee1, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid AnalogVideo = new Guid(0x482dde1, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid Audio = new Guid(0x73647561, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid AuxLine21Data = new Guid(0x670aea80, 0x3a82, 0x11d0, 0xb7, 0x9b, 0, 170, 0, 0x37, 0x67, 0xa7);
        public static readonly Guid DTVCCData = new Guid(0xfb77e152, 0x53b2, 0x499c, 180, 0x6b, 80, 0x9f, 0xc3, 0x3e, 0xdf, 0xd7);
        public static readonly Guid File = new Guid(0x656c6966, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid Interleaved = new Guid(0x73766169, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid LMRT = new Guid(0x74726c6d, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid Midi = new Guid(0x7364696d, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid Mpeg2Sections = new Guid(0x455f176c, 0x4b06, 0x47ce, 0x9a, 0xef, 140, 0xae, 0xf7, 0x3d, 0xf7, 0xb5);
        public static readonly Guid MSTVCaption = new Guid(0xb88b8a89, 0xb049, 0x4c80, 0xad, 0xcf, 0x58, 0x98, 0x98, 0x5e, 0x22, 0xc1);
        public static readonly Guid Null = Guid.Empty;
        public static readonly Guid ScriptCommand = new Guid(0x73636d64, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid Stream = new Guid(0xe436eb83, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid Text = new Guid(0x73747874, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid Timecode = new Guid(0x482dee3, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid URLStream = new Guid(0x736c7275, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid VBI = new Guid(0xf72a76e1, 0xeb0a, 0x11d0, 0xac, 0xe4, 0, 0, 0xc0, 0xcc, 0x16, 0xba);
        public static readonly Guid Video = new Guid(0x73646976, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
    }

    public static class MediaSubType
    {
        // Fields
        public static readonly Guid A2B10G10R10 = new Guid(0x576f7893, 0xbdf6, 0x48c4, 0x87, 0x5f, 0xae, 0x7b, 0x81, 0x83, 0x45, 0x67);
        public static readonly Guid A2R10G10B10 = new Guid(0x2f8bb76d, 0xb644, 0x4550, 0xac, 0xf3, 0xd3, 12, 170, 0x65, 0xd5, 0xc5);
        public static readonly Guid AI44 = new Guid(0x34344941, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid AIFF = new Guid(0xe436eb8d, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid AnalogVideo_NTSC_M = new Guid(0x482dde2, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid AnalogVideo_PAL_B = new Guid(0x482dde5, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid AnalogVideo_PAL_D = new Guid(0x482dde6, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid AnalogVideo_PAL_G = new Guid(0x482dde7, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid AnalogVideo_PAL_H = new Guid(0x482dde8, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid AnalogVideo_PAL_I = new Guid(0x482dde9, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid AnalogVideo_PAL_M = new Guid(0x482ddea, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid AnalogVideo_PAL_N = new Guid(0x482ddeb, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid AnalogVideo_PAL_N_COMBO = new Guid(0x482ddec, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid AnalogVideo_SECAM_B = new Guid(0x482ddf0, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid AnalogVideo_SECAM_D = new Guid(0x482ddf1, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid AnalogVideo_SECAM_G = new Guid(0x482ddf2, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid AnalogVideo_SECAM_H = new Guid(0x482ddf3, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid AnalogVideo_SECAM_K = new Guid(0x482ddf4, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid AnalogVideo_SECAM_K1 = new Guid(0x482ddf5, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid AnalogVideo_SECAM_L = new Guid(0x482ddf6, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid ARGB1555 = new Guid(0x297c55af, 0xe209, 0x4cb3, 0xb7, 0x57, 0xc7, 0x6d, 0x6b, 0x9c, 0x88, 0xa8);
        public static readonly Guid ARGB1555_D3D_DX7_RT = new Guid(0x35314137, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid ARGB1555_D3D_DX9_RT = new Guid(0x35314139, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid ARGB32 = new Guid(0x773c9ac0, 0x3274, 0x11d0, 0xb7, 0x24, 0, 170, 0, 0x6c, 0x1a, 1);
        public static readonly Guid ARGB32_D3D_DX7_RT = new Guid(0x38384137, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid ARGB32_D3D_DX9_RT = new Guid(0x38384139, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid ARGB4444 = new Guid(0x6e6415e6, 0x5c24, 0x425f, 0x93, 0xcd, 0x80, 0x10, 0x2b, 0x3d, 0x1c, 0xca);
        public static readonly Guid ARGB4444_D3D_DX7_RT = new Guid(0x34344137, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid ARGB4444_D3D_DX9_RT = new Guid(0x34344139, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid Asf = new Guid(0x3db80f90, 0x9412, 0x11d1, 0xad, 0xed, 0, 0, 0xf8, 0x75, 0x4b, 0x99);
        public static readonly Guid AtscSI = new Guid(0xb3c7397c, 0xd303, 0x414d, 0xb3, 60, 0x4e, 210, 0xc9, 210, 0x97, 0x33);
        public static readonly Guid AU = new Guid(0xe436eb8c, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid Avi = new Guid(0xe436eb88, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid AYUV = new Guid(0x56555941, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid CFCC = new Guid(0x43434643, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid CLJR = new Guid(0x524a4c43, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid CLPL = new Guid(0x4c504c43, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid CPLA = new Guid(0x414c5043, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid Data708_608 = new Guid(0xaf414bc, 0x4ed2, 0x445e, 0x98, 0x39, 0x8f, 9, 0x55, 0x68, 0xab, 60);
        public static readonly Guid DOLBY_AC3_SPDIF = new Guid(0x92, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid DolbyAC3 = new Guid(0xe06d802c, 0xdb46, 0x11cf, 180, 0xd1, 0, 0x80, 0x5f, 0x6c, 0xbb, 0xea);
        public static readonly Guid DRM_Audio = new Guid(9, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid DssAudio = new Guid(0xa0af4f82, 0xe163, 0x11d0, 0xba, 0xd9, 0, 0x60, 0x97, 0x44, 0x11, 0x1a);
        public static readonly Guid DssVideo = new Guid(0xa0af4f81, 0xe163, 0x11d0, 0xba, 0xd9, 0, 0x60, 0x97, 0x44, 0x11, 0x1a);
        public static readonly Guid DtvCcData = new Guid(0xf52addaa, 0x36f0, 0x43f5, 0x95, 0xea, 0x6d, 0x86, 100, 0x84, 0x26, 0x2a);
        public static readonly Guid dv25 = new Guid(0x35327664, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid dv50 = new Guid(0x30357664, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid DvbSI = new Guid(0xe9dd31a3, 0x221d, 0x4adb, 0x85, 50, 0x9a, 0xf3, 9, 0xc1, 0xa4, 8);
        public static readonly Guid DVCS = new Guid(0x53435644, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid dvh1 = new Guid(0x31687664, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid dvhd = new Guid(0x64687664, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid DVSD = new Guid(0x44535644, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid dvsl = new Guid(0x6c737664, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid H264 = new Guid(0x34363248, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid I420 = new Guid(0x30323449, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid IA44 = new Guid(0x34344149, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid IEEE_FLOAT = new Guid(3, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid IF09 = new Guid(0x39304649, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid IJPG = new Guid(0x47504a49, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid IMC1 = new Guid(0x31434d49, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid IMC2 = new Guid(0x32434d49, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid IMC3 = new Guid(0x33434d49, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid IMC4 = new Guid(0x34434d49, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid IYUV = new Guid(0x56555949, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid Line21_BytePair = new Guid(0x6e8d4a22, 0x310c, 0x11d0, 0xb7, 0x9a, 0, 170, 0, 0x37, 0x67, 0xa7);
        public static readonly Guid Line21_GOPPacket = new Guid(0x6e8d4a23, 0x310c, 0x11d0, 0xb7, 0x9a, 0, 170, 0, 0x37, 0x67, 0xa7);
        public static readonly Guid Line21_VBIRawData = new Guid(0x6e8d4a24, 0x310c, 0x11d0, 0xb7, 0x9a, 0, 170, 0, 0x37, 0x67, 0xa7);
        public static readonly Guid MDVF = new Guid(0x4656444d, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid MJPG = new Guid(0x47504a4d, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid MPEG1Audio = new Guid(0xe436eb87, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid MPEG1AudioPayload = new Guid(80, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid MPEG1Packet = new Guid(0xe436eb80, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid MPEG1Payload = new Guid(0xe436eb81, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid MPEG1System = new Guid(0xe436eb84, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid MPEG1SystemStream = new Guid(0xe436eb82, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid MPEG1Video = new Guid(0xe436eb86, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid MPEG1VideoCD = new Guid(0xe436eb85, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid Mpeg2Audio = new Guid(0xe06d802b, 0xdb46, 0x11cf, 180, 0xd1, 0, 0x80, 0x5f, 0x6c, 0xbb, 0xea);
        public static readonly Guid Mpeg2Data = new Guid(0xc892e55b, 0x252d, 0x42b5, 0xa3, 0x16, 0xd9, 0x97, 0xe7, 0xa5, 0xd9, 0x95);
        public static readonly Guid Mpeg2Program = new Guid(0xe06d8022, 0xdb46, 0x11cf, 180, 0xd1, 0, 0x80, 0x5f, 0x6c, 0xbb, 0xea);
        public static readonly Guid Mpeg2Transport = new Guid(0xe06d8023, 0xdb46, 0x11cf, 180, 0xd1, 0, 0x80, 0x5f, 0x6c, 0xbb, 0xea);
        public static readonly Guid Mpeg2TransportStride = new Guid(0x138aa9a4, 0x1ee2, 0x4c5b, 0x98, 0x8e, 0x19, 0xab, 0xfd, 0xbc, 0x8a, 0x11);
        public static readonly Guid Mpeg2Video = new Guid(0xe06d8026, 0xdb46, 0x11cf, 180, 0xd1, 0, 0x80, 0x5f, 0x6c, 0xbb, 0xea);
        public static readonly Guid None = new Guid(0xe436eb8e, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid Null = Guid.Empty;
        public static readonly Guid NV12 = new Guid(0x3231564e, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid NV24 = new Guid(0x3432564e, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid Overlay = new Guid(0xe436eb7f, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid PCM = new Guid(1, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid PCMAudio_Obsolete = new Guid(0xe436eb8a, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid PLUM = new Guid(0x6d756c50, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid QTJpeg = new Guid(0x6765706a, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid QTMovie = new Guid(0xe436eb89, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid QTRle = new Guid(0x20656c72, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid QTRpza = new Guid(0x617a7072, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid QTSmc = new Guid(0x20636d73, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid RAW_SPORT = new Guid(0x240, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid RGB1 = new Guid(0xe436eb78, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid RGB16_D3D_DX7_RT = new Guid(0x36315237, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid RGB16_D3D_DX9_RT = new Guid(0x36315239, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid RGB24 = new Guid(0xe436eb7d, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid RGB32 = new Guid(0xe436eb7e, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid RGB32_D3D_DX7_RT = new Guid(0x32335237, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid RGB32_D3D_DX9_RT = new Guid(0x32335239, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid RGB4 = new Guid(0xe436eb79, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid RGB555 = new Guid(0xe436eb7c, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid RGB565 = new Guid(0xe436eb7b, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid RGB8 = new Guid(0xe436eb7a, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid S340 = new Guid(0x30343353, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid S342 = new Guid(0x32343353, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid SPDIF_TAG_241h = new Guid(0x241, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid TELETEXT = new Guid(0xf72a76e3, 0xeb0a, 0x11d0, 0xac, 0xe4, 0, 0, 0xc0, 0xcc, 0x16, 0xba);
        public static readonly Guid TVMJ = new Guid(0x4a4d5654, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid UYVY = new Guid(0x59565955, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid VideoImage = new Guid(0x1d4a45f2, 0xe5f6, 0x4b44, 0x83, 0x88, 240, 0xae, 0x5c, 14, 12, 0x37);
        public static readonly Guid VPS = new Guid(0xa1b3f620, 0x9792, 0x4d8d, 0x81, 0xa4, 0x86, 0xaf, 0x25, 0x77, 0x20, 0x90);
        public static readonly Guid VPVBI = new Guid(0x5a9b6a41, 0x1a22, 0x11d1, 0xba, 0xd9, 0, 0x60, 0x97, 0x44, 0x11, 0x1a);
        public static readonly Guid VPVideo = new Guid(0x5a9b6a40, 0x1a22, 0x11d1, 0xba, 0xd9, 0, 0x60, 0x97, 0x44, 0x11, 0x1a);
        public static readonly Guid WAKE = new Guid(0x454b4157, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid WAVE = new Guid(0xe436eb8b, 0x524f, 0x11ce, 0x9f, 0x53, 0, 0x20, 0xaf, 11, 0xa7, 0x70);
        public static readonly Guid WebStream = new Guid(0x776257d4, 0xc627, 0x41cb, 0x8f, 0x81, 0x7a, 0xc7, 0xff, 0x1c, 0x40, 0xcc);
        public static readonly Guid WSS = new Guid(0x2791d576, 0x8e7a, 0x466f, 0x9e, 0x90, 0x5d, 0x3f, 0x30, 0x83, 0x73, 0x8b);
        public static readonly Guid Y211 = new Guid(0x31313259, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid Y411 = new Guid(0x31313459, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid Y41P = new Guid(0x50313459, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid YUY2 = new Guid(0x32595559, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid YUYV = new Guid(0x56595559, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid YV12 = new Guid(0x32315659, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid YVU9 = new Guid(0x39555659, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
        public static readonly Guid YVYU = new Guid(0x55595659, 0, 0x10, 0x80, 0, 0, 170, 0, 0x38, 0x9b, 0x71);
    }

    public static class FormatType
    {
        // Fields
        public static readonly Guid AnalogVideo = new Guid(0x482dde0, 0x7817, 0x11cf, 0x8a, 3, 0, 170, 0, 110, 0xcb, 0x65);
        public static readonly Guid DolbyAC3 = new Guid(0xe06d80e4, 0xdb46, 0x11cf, 180, 0xd1, 0, 0x80, 0x5f, 0x6c, 0xbb, 0xea);
        public static readonly Guid DvInfo = new Guid(0x5589f84, 0xc356, 0x11ce, 0xbf, 1, 0, 170, 0, 0x55, 0x59, 90);
        public static readonly Guid Mpeg2Audio = new Guid(0xe06d80e5, 0xdb46, 0x11cf, 180, 0xd1, 0, 0x80, 0x5f, 0x6c, 0xbb, 0xea);
        public static readonly Guid Mpeg2Video = new Guid(0xe06d80e3, 0xdb46, 0x11cf, 180, 0xd1, 0, 0x80, 0x5f, 0x6c, 0xbb, 0xea);
        public static readonly Guid MpegStreams = new Guid(0x5589f83, 0xc356, 0x11ce, 0xbf, 1, 0, 170, 0, 0x55, 0x59, 90);
        public static readonly Guid MpegVideo = new Guid(0x5589f82, 0xc356, 0x11ce, 0xbf, 1, 0, 170, 0, 0x55, 0x59, 90);
        public static readonly Guid None = new Guid(0xf6417d6, 0xc318, 0x11d0, 0xa4, 0x3f, 0, 160, 0xc9, 0x22, 0x31, 150);
        public static readonly Guid Null = Guid.Empty;
        public static readonly Guid VideoInfo = new Guid(0x5589f80, 0xc356, 0x11ce, 0xbf, 1, 0, 170, 0, 0x55, 0x59, 90);
        public static readonly Guid VideoInfo2 = new Guid(0xf72a76a0, 0xeb0a, 0x11d0, 0xac, 0xe4, 0, 0, 0xc0, 0xcc, 0x16, 0xba);
        public static readonly Guid WaveEx = new Guid(0x5589f81, 0xc356, 0x11ce, 0xbf, 1, 0, 170, 0, 0x55, 0x59, 90);
        public static readonly Guid WSS525 = new Guid(0xc7ecf04d, 0x4582, 0x4869, 0x9a, 0xbb, 0xbf, 0xb5, 0x23, 0xb6, 0x2e, 0xdf);
    }

    // ---------------------------------------------------------------------------------------
    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public struct DsPOINT		// POINT
    {
        public int X;
        public int Y;
    }


    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5a4a97e4-94ee-4a55-9751-74b5643aa27d")]
    public interface IDvdCmd
    {
        [PreserveSig]
        void WaitForStart();
        [PreserveSig]
        void WaitForEnd();
    }

    [ComImport, Guid("A70EFE61-E2A3-11d0-A9BE-00AA0061BE93"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdControl
    {
        [PreserveSig]
        int TitlePlay([In] int ulTitle);

        [PreserveSig]
        int ChapterPlay(
            [In] int ulTitle,
            [In] int ulChapter
            );

        [PreserveSig]
        int TimePlay(
            [In] int ulTitle,
            [In] int bcdTime
            );

        [PreserveSig]
        int StopForResume();

        [PreserveSig]
        int GoUp();

        [PreserveSig]
        int TimeSearch([In] int bcdTime);

        [PreserveSig]
        int ChapterSearch([In] int ulChapter);

        [PreserveSig]
        int PrevPGSearch();

        [PreserveSig]
        int TopPGSearch();

        [PreserveSig]
        int NextPGSearch();

        [PreserveSig]
        int ForwardScan([In] double dwSpeed);

        [PreserveSig]
        int BackwardScan([In] double dwSpeed);

        [PreserveSig]
        int MenuCall([In] DvdMenuId MenuID);

        [PreserveSig]
        int Resume();

        [PreserveSig]
        int UpperButtonSelect();

        [PreserveSig]
        int LowerButtonSelect();

        [PreserveSig]
        int LeftButtonSelect();

        [PreserveSig]
        int RightButtonSelect();

        [PreserveSig]
        int ButtonActivate();

        [PreserveSig]
        int ButtonSelectAndActivate([In] int ulButton);

        [PreserveSig]
        int StillOff();

        [PreserveSig]
        int PauseOn();

        [PreserveSig]
        int PauseOff();

        [PreserveSig]
        int MenuLanguageSelect([In] int Language);

        [PreserveSig]
        int AudioStreamChange([In] int ulAudio);

        [PreserveSig]
        int SubpictureStreamChange(
            [In] int ulSubPicture,
            [In, MarshalAs(UnmanagedType.Bool)] bool bDisplay
            );

        [PreserveSig]
        int AngleChange([In] int ulAngle);

        [PreserveSig]
        int ParentalLevelSelect([In] int ulParentalLevel);

        [PreserveSig]
        int ParentalCountrySelect([In] short wCountry);

        [PreserveSig]
        int KaraokeAudioPresentationModeChange([In] int ulMode);

        [PreserveSig]
        int VideoModePreferrence([In] int ulPreferredDisplayMode);

        [PreserveSig]
        int SetRoot([In, MarshalAs(UnmanagedType.LPWStr)] string pszPath);

        [PreserveSig]
        int MouseActivate([In] Point point);

        [PreserveSig]
        int MouseSelect([In] Point point);

        [PreserveSig]
        int ChapterPlayAutoStop(
            [In] int ulTitle,
            [In] int ulChapter,
            [In] int ulChaptersToPlay
            );
    }

    [ComImport, Guid("33BC7430-EEC0-11D2-8201-00A0C9D74842"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdControl2
    {
        [PreserveSig]
        void PlayTitle([In] int ulTitle, [In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void PlayChapterInTitle([In] int ulTitle, [In] int ulChapter, [In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void PlayAtTimeInTitle([In] int ulTitle, [In] DvdHMSFTimeCode pStartTime, [In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void Stop();
        [PreserveSig]
        void ReturnFromSubmenu([In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void PlayAtTime([In] DvdHMSFTimeCode pTime, [In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void PlayChapter([In] int ulChapter, [In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void PlayPrevChapter([In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void ReplayChapter([In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void PlayNextChapter([In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void PlayForwards([In] double dSpeed, [In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void PlayBackwards([In] double dSpeed, [In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void ShowMenu([In] DvdMenuId MenuID, [In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void Resume([In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void SelectRelativeButton(DvdRelativeButton buttonDir);
        [PreserveSig]
        void ActivateButton();
        [PreserveSig]
        void SelectButton([In] int ulButton);
        [PreserveSig]
        void SelectAndActivateButton([In] int ulButton);
        [PreserveSig]
        void StillOff();
        [PreserveSig]
        void Pause([In, MarshalAs(UnmanagedType.Bool)] bool bState);
        [PreserveSig]
        void SelectAudioStream([In] int ulAudio, [In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void SelectSubpictureStream([In] int ulSubPicture, [In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void SetSubpictureState([In, MarshalAs(UnmanagedType.Bool)] bool bState, [In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void SelectAngle([In] int ulAngle, [In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void SelectParentalLevel([In] int ulParentalLevel);
        [PreserveSig]
        void SelectParentalCountry([In, MarshalAs(UnmanagedType.LPArray)] byte[] bCountry);
        [PreserveSig]
        void SelectKaraokeAudioPresentationMode([In] DvdKaraokeDownMix ulMode);
        [PreserveSig]
        void SelectVideoModePreference([In] DvdPreferredDisplayMode ulPreferredDisplayMode);
        [PreserveSig]
        void SetDVDDirectory([In, MarshalAs(UnmanagedType.LPWStr)] string pszwPath);
        [PreserveSig]
        void ActivateAtPosition([In] Point point);
        [PreserveSig]
        void SelectAtPosition([In] Point point);
        [PreserveSig]
        void PlayChaptersAutoStop([In] int ulTitle, [In] int ulChapter, [In] int ulChaptersToPlay, [In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void AcceptParentalLevelChange([In, MarshalAs(UnmanagedType.Bool)] bool bAccept);
        [PreserveSig]
        void SetOption([In] DvdOptionFlag flag, [In, MarshalAs(UnmanagedType.Bool)] bool fState);
        [PreserveSig]
        void SetState([In] IDvdState pState, [In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void PlayPeriodInTitleAutoStop([In] int ulTitle, [In, MarshalAs(UnmanagedType.LPStruct)] DvdHMSFTimeCode pStartTime, [In, MarshalAs(UnmanagedType.LPStruct)] DvdHMSFTimeCode pEndTime, [In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void SetGPRM([In] int ulIndex, [In] short wValue, [In] DvdCmdFlags dwFlags, out IDvdCmd ppCmd);
        [PreserveSig]
        void SelectDefaultMenuLanguage([In] int Language);
        [PreserveSig]
        void SelectDefaultAudioLanguage([In] int Language, [In] DvdAudioLangExt audioExtension);
        [PreserveSig]
        void SelectDefaultSubpictureLanguage([In] int Language, [In] DvdSubPictureLangExt subpictureExtension);
    }

    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("FCC152B6-F372-11d0-8E00-00C04FD7C08B")]
    public interface IDvdGraphBuilder
    {
        [PreserveSig]
        void GetFiltergraph(out IMediaControl pMC);
        [PreserveSig]
        void GetDvdInterface([In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppvIF);
        [PreserveSig]
        void RenderDvdVideoVolume([In, MarshalAs(UnmanagedType.LPWStr)] string lpcwszPathName, [In] AMDvdGraphFlags dwFlags, out AMDvdRenderStatus pStatus);
    }

    [ComImport, Guid("34151510-EEC0-11D2-8201-00A0C9D74842"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdInfo2
    {
        [PreserveSig]
        void GetCurrentDomain(out DvdDomain pDomain);
        [PreserveSig]
        void GetCurrentLocation(out DvdPlaybackLocation2 pLocation);
        [PreserveSig]
        void GetTotalTitleTime(out DvdHMSFTimeCode pTotalTime, out DvdTimeCodeFlags ulTimeCodeFlags);
        [PreserveSig]
        void GetCurrentButton(out int pulButtonsAvailable, out int pulCurrentButton);
        [PreserveSig]
        void GetCurrentAngle(out int pulAnglesAvailable, out int pulCurrentAngle);
        [PreserveSig]
        void GetCurrentAudio(out int pulStreamsAvailable, out int pulCurrentStream);
        [PreserveSig]
        void GetCurrentSubpicture(out int pulStreamsAvailable, out int pulCurrentStream, [MarshalAs(UnmanagedType.Bool)] out bool pbIsDisabled);
        [PreserveSig]
        void GetCurrentUOPS(out ValidUOPFlag pulUOPs);
        [PreserveSig]
        void GetAllSPRMs(out SPRMArray pRegisterArray);
        [PreserveSig]
        void GetAllGPRMs(out GPRMArray pRegisterArray);
        [PreserveSig]
        void GetAudioLanguage([In] int ulStream, out int pLanguage);
        [PreserveSig]
        void GetSubpictureLanguage([In] int ulStream, out int pLanguage);
        [PreserveSig]
        void GetTitleAttributes([In] int ulTitle, out DvdMenuAttributes pMenu, [In, Out] DvdTitleAttributes pTitle);
        [PreserveSig]
        void GetVMGAttributes(out DvdMenuAttributes pATR);
        [PreserveSig]
        void GetCurrentVideoAttributes(out DvdVideoAttributes pATR);
        [PreserveSig]
        void GetAudioAttributes([In] int ulStream, out DvdAudioAttributes pATR);
        [PreserveSig]
        void GetKaraokeAttributes([In] int ulStream, [In, Out] DvdKaraokeAttributes pAttributes);
        [PreserveSig]
        void GetSubpictureAttributes([In] int ulStream, out DvdSubpictureAttributes pATR);
        [PreserveSig]
        void GetDVDVolumeInfo(out int pulNumOfVolumes, out int pulVolume, out DvdDiscSide pSide, out int pulNumOfTitles);
        [PreserveSig]
        void GetDVDTextNumberOfLanguages(out int pulNumOfLangs);
        [PreserveSig]
        void GetDVDTextLanguageInfo([In] int ulLangIndex, out int pulNumOfStrings, out int pLangCode, out DvdTextCharSet pbCharacterSet);
        [PreserveSig]
        void GetDVDTextStringAsNative([In] int ulLangIndex, [In] int ulStringIndex, [MarshalAs(UnmanagedType.LPStr)] StringBuilder pbBuffer, [In] int ulMaxBufferSize, out int pulActualSize, out DvdTextStringType pType);
        [PreserveSig]
        void GetDVDTextStringAsUnicode([In] int ulLangIndex, [In] int ulStringIndex, StringBuilder pchwBuffer, [In] int ulMaxBufferSize, out int pulActualSize, out DvdTextStringType pType);
        [PreserveSig]
        void GetPlayerParentalLevel(out int pulParentalLevel, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0, SizeConst = 2)] byte[] pbCountryCode);
        [PreserveSig]
        void GetNumberOfChapters([In] int ulTitle, out int pulNumOfChapters);
        [PreserveSig]
        void GetTitleParentalLevels([In] int ulTitle, out DvdParentalLevel pulParentalLevels);
        [PreserveSig]
        void GetDVDDirectory(StringBuilder pszwPath, [In] int ulMaxSize, out int pulActualSize);
        [PreserveSig]
        void IsAudioStreamEnabled([In] int ulStreamNum, [MarshalAs(UnmanagedType.Bool)] out bool pbEnabled);
        [PreserveSig]
        void GetDiscID([In, MarshalAs(UnmanagedType.LPWStr)] string pszwPath, out long pullDiscID);
        [PreserveSig]
        void GetState(out IDvdState pStateData);
        [PreserveSig]
        void GetMenuLanguages([MarshalAs(UnmanagedType.LPArray)] int[] pLanguages, [In] int ulMaxLanguages, out int pulActualLanguages);
        [PreserveSig]
        void GetButtonAtPosition([In] Point point, out int pulButtonIndex);
        [PreserveSig]
        void GetCmdFromEvent([In] int lParam1, out IDvdCmd pCmdObj);
        [PreserveSig]
        void GetDefaultMenuLanguage(out int pLanguage);
        [PreserveSig]
        int GetDefaultAudioLanguage(out int pLanguage, out DvdAudioLangExt pAudioExtension);
        [PreserveSig]
        void GetDefaultSubpictureLanguage(out int pLanguage, out DvdSubPictureLangExt pSubpictureExtension);
        [PreserveSig]
        void GetDecoderCaps(ref DvdDecoderCaps pCaps);
        [PreserveSig]
        void GetButtonRect([In] int ulButton, [Out] RECT pRect);
        [PreserveSig]
        void IsSubpictureStreamEnabled([In] int ulStreamNum, [MarshalAs(UnmanagedType.Bool)] out bool pbEnabled);
    }

    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("86303d6d-1c4a-4087-ab42-f711167048ef")]
    public interface IDvdState
    {
        [PreserveSig]
        void GetDiscID(out long pullUniqueID);
        [PreserveSig]
        void GetParentalLevel(out int pulParentalLevel);
    }

    [ComImport, SuppressUnmanagedCodeSecurity,
     Guid("c1960960-17f5-11d1-abe1-00a0c905f375"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMStreamSelect
    {
        [PreserveSig]
        int Count([Out] out int pcStreams);

        [PreserveSig]
        int Info(
          [In] int lIndex,
          [Out] out AMMediaType ppmt,
          [Out] out AMStreamSelectInfoFlags pdwFlags,
          [Out] out int plcid,
          [Out] out int pdwGroup,
          [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszName,
          [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppObject,
          [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppUnk
          );

        [PreserveSig]
        int Enable(
          [In] int lIndex,
          [In] AMStreamSelectEnableFlags dwFlags
          );
    }

    /// <summary>
    /// From _AMSTREAMSELECTINFOFLAGS
    /// </summary>
    [Flags]
    public enum AMStreamSelectInfoFlags
    {
        Disabled = 0x0,
        Enabled = 0x01,
        Exclusive = 0x02
    }

    /// <summary>
    /// From _AMSTREAMSELECTENABLEFLAGS
    /// </summary>
    [Flags]
    public enum AMStreamSelectEnableFlags
    {
        DisableAll = 0x0,
        Enable = 0x01,
        EnableAll = 0x02
    }

    /// <summary>
    /// From AM_MEDIA_TYPE - When you are done with an instance of this class,
    /// it should be released with FreeAMMediaType() to avoid leaking
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class AMMediaType
    {
        public Guid majorType;
        public Guid subType;
        [MarshalAs(UnmanagedType.Bool)]
        public bool fixedSizeSamples;
        [MarshalAs(UnmanagedType.Bool)]
        public bool temporalCompression;
        public int sampleSize;
        public Guid formatType;
        public IntPtr unkPtr; // IUnknown Pointer
        public int formatSize;
        public IntPtr formatPtr; // Pointer to a buff determined by formatType
    }



    [ComImport, System.Security.SuppressUnmanagedCodeSecurity,
    Guid("0579154A-2B53-4994-B0D0-E773148EFF85"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISampleGrabberCB
    {
        /// <summary>
        /// When called, callee must release pSample
        /// </summary>
        [PreserveSig]
        int SampleCB(double SampleTime, IMediaSample pSample);

        [PreserveSig]
        int BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen);
    }

    [ComImport, System.Security.SuppressUnmanagedCodeSecurity,
    Guid("6B652FFF-11FE-4fce-92AD-0266B5D7C78F"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISampleGrabber
    {
        [PreserveSig]
        int SetOneShot(
            [In, MarshalAs(UnmanagedType.Bool)] bool OneShot);

        [PreserveSig]
        int SetMediaType(
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        [PreserveSig]
        int GetConnectedMediaType(
            [Out, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        [PreserveSig]
        int SetBufferSamples(
            [In, MarshalAs(UnmanagedType.Bool)] bool BufferThem);

        [PreserveSig]
        int GetCurrentBuffer(ref int pBufferSize, IntPtr pBuffer);

        [PreserveSig]
        int GetCurrentSample(out IMediaSample ppSample);

        [PreserveSig]
        int SetCallback(ISampleGrabberCB pCallback, int WhichMethodToCallback);
    }
}

 
#endif