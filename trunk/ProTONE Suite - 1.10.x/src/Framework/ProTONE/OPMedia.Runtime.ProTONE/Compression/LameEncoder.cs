using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;

namespace OPMedia.Runtime.ProTONE.Compression.Lame
{
    public enum VBRMETHOD : int
    {
        VBR_METHOD_NONE = -1,
        VBR_METHOD_DEFAULT = 0,
        VBR_METHOD_OLD = 1,
        VBR_METHOD_NEW = 2,
        VBR_METHOD_MTRH = 3,
        VBR_METHOD_ABR = 4
    }

    /* MPEG modes */
    public enum MpegMode : uint
    {
        STEREO = 0,
        JOINT_STEREO,
        DUAL_CHANNEL,   /* LAME doesn't supports this! */
        MONO,
        NOT_SET,
        MAX_INDICATOR   /* Don't use this! It's used for sanity checks. */
    }

    public enum LAME_QUALITY_PRESET : int
    {
        LQP_NOPRESET = -1,
        // QUALITY PRESETS
        LQP_NORMAL_QUALITY = 0,
        LQP_LOW_QUALITY = 1,
        LQP_HIGH_QUALITY = 2,
        LQP_VOICE_QUALITY = 3,
        LQP_R3MIX = 4,
        LQP_VERYHIGH_QUALITY = 5,
        LQP_STANDARD = 6,
        LQP_FAST_STANDARD = 7,
        LQP_EXTREME = 8,
        LQP_FAST_EXTREME = 9,
        LQP_INSANE = 10,
        LQP_ABR = 11,
        LQP_CBR = 12,
        LQP_MEDIUM = 13,
        LQP_FAST_MEDIUM = 14,
        // NEW PRESET VALUES
        LQP_PHONE = 1000,
        LQP_SW = 2000,
        LQP_AM = 3000,
        LQP_FM = 4000,
        LQP_VOICE = 5000,
        LQP_RADIO = 6000,
        LQP_TAPE = 7000,
        LQP_HIFI = 8000,
        LQP_CD = 9000,
        LQP_STUDIO = 10000
    }

    [StructLayout(LayoutKind.Sequential), Serializable]
    public struct MP3 //BE_CONFIG_MP3
    {
        public uint dwSampleRate;		// 48000, 44100 and 32000 allowed
        public byte byMode;			// BE_MP3_MODE_STEREO, BE_MP3_MODE_DUALCHANNEL, BE_MP3_MODE_MONO
        public ushort wBitrate;		// 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256 and 320 allowed
        public int bPrivate;
        public int bCRC;
        public int bCopyright;
        public int bOriginal;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("    dwSampleRate={0}\r\n", dwSampleRate);
            sb.AppendFormat("    byMode={0}\r\n", byMode);
            sb.AppendFormat("    wBitrate={0}\r\n", wBitrate);
            sb.AppendFormat("    bPrivate={0}\r\n", bPrivate);
            sb.AppendFormat("    bCRC={0}\r\n", bCRC);
            sb.AppendFormat("    bCopyright={0}\r\n", bCopyright);
            sb.AppendFormat("    bOriginal={0}", bOriginal);
            return sb.ToString();
        }
    }

    [StructLayout(LayoutKind.Sequential, Size = 327), Serializable]
    public struct LHV1 // BE_CONFIG_LAME LAME header version 1
    {
        public const uint MPEG1 = 1;
        public const uint MPEG2 = 0;

        // STRUCTURE INFORMATION
        public uint dwStructVersion;
        public uint dwStructSize;
        // BASIC ENCODER SETTINGS
        public uint dwSampleRate;		// SAMPLERATE OF INPUT FILE
        public uint dwReSampleRate;		// DOWNSAMPLERATE, 0=ENCODER DECIDES  
        public MpegMode nMode;				// STEREO, MONO
        public uint dwBitrate;			// CBR bitrate, VBR min bitrate
        public uint dwMaxBitrate;		// CBR ignored, VBR Max bitrate
        public LAME_QUALITY_PRESET nPreset;			// Quality preset
        public uint dwMpegVersion;		// MPEG-1 OR MPEG-2
        public uint dwPsyModel;			// FUTURE USE, SET TO 0
        public uint dwEmphasis;			// FUTURE USE, SET TO 0
        // BIT STREAM SETTINGS
        public int bPrivate;			// Set Private Bit (TRUE/FALSE)
        public int bCRC;				// Insert CRC (TRUE/FALSE)
        public int bCopyright;			// Set Copyright Bit (TRUE/FALSE)
        public int bOriginal;			// Set Original Bit (TRUE/FALSE)
        // VBR STUFF
        public int bWriteVBRHeader;	// WRITE XING VBR HEADER (TRUE/FALSE)
        public int bEnableVBR;			// USE VBR ENCODING (TRUE/FALSE)
        public int nVBRQuality;		// VBR QUALITY 0..9
        public uint dwVbrAbr_bps;		// Use ABR in stead of nVBRQuality
        public VBRMETHOD nVbrMethod;
        public int bNoRes;				// Disable Bit resorvoir (TRUE/FALSE)
        // MISC SETTINGS
        public int bStrictIso;			// Use strict ISO encoding rules (TRUE/FALSE)
        public ushort nQuality;			// Quality Setting, HIGH BYTE should be NOT LOW byte, otherwhise quality=5
        // FUTURE USE, SET TO 0, align strucutre to 331 bytes
        //[ MarshalAs( UnmanagedType.ByValArray, SizeConst=255-4*4-2 )]
        //public byte[]   btReserved;//[255-4*sizeof(DWORD) - sizeof( WORD )];

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("    dwStructVersion={0}\r\n ", dwStructVersion);
            sb.AppendFormat("    dwStructSize={0}\r\n ", dwStructSize);
            sb.AppendFormat("    dwSampleRate={0}\r\n ", dwSampleRate);
            sb.AppendFormat("    dwReSampleRate={0}\r\n ", dwReSampleRate);
            sb.AppendFormat("    nMode={0}\r\n ", nMode);
            sb.AppendFormat("    dwBitrate={0}\r\n ", dwBitrate);
            sb.AppendFormat("    dwMaxBitrate={0}\r\n ", dwMaxBitrate);
            sb.AppendFormat("    nPreset={0}\r\n ", nPreset);
            sb.AppendFormat("    dwMpegVersion={0}\r\n ", dwMpegVersion);
            sb.AppendFormat("    dwPsyModel={0}\r\n ", dwPsyModel);
            sb.AppendFormat("    dwEmphasis={0}\r\n ", dwEmphasis);
            sb.AppendFormat("    bPrivate={0}\r\n ", bPrivate);
            sb.AppendFormat("    bCRC={0}\r\n ", bCRC);
            sb.AppendFormat("    bCopyright={0}\r\n ", bCopyright);
            sb.AppendFormat("    bOriginal={0}\r\n ", bOriginal);
            sb.AppendFormat("    bWriteVBRHeader={0}\r\n ", bWriteVBRHeader);
            sb.AppendFormat("    bEnableVBR={0}\r\n ", bEnableVBR);
            sb.AppendFormat("    nVBRQuality={0}\r\n ", nVBRQuality);
            sb.AppendFormat("    dwVbrAbr_bps={0}\r\n ", dwVbrAbr_bps);
            sb.AppendFormat("    nVbrMethod={0}\r\n ", nVbrMethod);
            sb.AppendFormat("    bNoRes={0}\r\n ", bNoRes);
            sb.AppendFormat("    bStrictIso={0}\r\n ", bStrictIso);
            sb.AppendFormat("    nQuality={0}", nQuality);
            return sb.ToString();
        }


        public LHV1(WaveFormatEx format, uint MpeBitRate)
        {
            if (format.wFormatTag != 1 /* WAVE_FORMAT_PCM */)
            {
                throw new ArgumentOutOfRangeException("format", "Only PCM format supported");
            }
            if (format.wBitsPerSample != 16)
            {
                throw new ArgumentOutOfRangeException("format", "Only 16 bits samples supported");
            }
            dwStructVersion = 1;
            dwStructSize = (uint)Marshal.SizeOf(typeof(BE_CONFIG));
            switch (format.nSamplesPerSec)
            {
                case 16000:
                case 22050:
                case 24000:
                    dwMpegVersion = MPEG2;
                    break;
                case 32000:
                case 44100:
                case 48000:
                    dwMpegVersion = MPEG1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("format", "Unsupported sample rate");
            }
            dwSampleRate = (uint)format.nSamplesPerSec;				// INPUT FREQUENCY
            dwReSampleRate = 0;					// DON'T RESAMPLE
            switch (format.nChannels)
            {
                case 1:
                    nMode = MpegMode.MONO;
                    break;
                case 2:
                    nMode = MpegMode.STEREO;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("format", "Invalid number of channels");
            }
            switch (MpeBitRate)
            {
                case 32:
                case 40:
                case 48:
                case 56:
                case 64:
                case 80:
                case 96:
                case 112:
                case 128:
                case 160: //Allowed bit rates in MPEG1 and MPEG2
                    break;
                case 192:
                case 224:
                case 256:
                case 320: //Allowed only in MPEG1
                    if (dwMpegVersion != MPEG1)
                    {
                        throw new ArgumentOutOfRangeException("MpsBitRate", "Bit rate not compatible with input format");
                    }
                    break;
                case 8:
                case 16:
                case 24:
                case 144: //Allowed only in MPEG2
                    if (dwMpegVersion != MPEG2)
                    {
                        throw new ArgumentOutOfRangeException("MpsBitRate", "Bit rate not compatible with input format");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("MpsBitRate", "Unsupported bit rate");
            }
            dwBitrate = MpeBitRate;					// MINIMUM BIT RATE
            nPreset = LAME_QUALITY_PRESET.LQP_NORMAL_QUALITY;		// QUALITY PRESET SETTING
            dwPsyModel = 0;					// USE DEFAULT PSYCHOACOUSTIC MODEL 
            dwEmphasis = 0;					// NO EMPHASIS TURNED ON
            bOriginal = 1;					// SET ORIGINAL FLAG
            bWriteVBRHeader = 0;
            bNoRes = 0;					// No Bit resorvoir
            bCopyright = 0;
            bCRC = 0;
            bEnableVBR = 0;
            bPrivate = 0;
            bStrictIso = 0;
            dwMaxBitrate = 0;
            dwVbrAbr_bps = 0;
            nQuality = 0;
            nVbrMethod = VBRMETHOD.VBR_METHOD_NONE;
            nVBRQuality = 0;
        }
    }


    [StructLayout(LayoutKind.Sequential), Serializable]
    public struct ACC
    {
        public uint dwSampleRate;
        public byte byMode;
        public ushort wBitrate;
        public byte byEncodingMethod;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("    dwSampleRate={0}\r\n ", dwSampleRate);
            sb.AppendFormat("    byMode={0}\r\n ", byMode);
            sb.AppendFormat("    wBitrate={0}\r\n ", wBitrate);
            sb.AppendFormat("    byEncodingMethod={0} ", byEncodingMethod);
            return sb.ToString();
        }
    }

    [StructLayout(LayoutKind.Explicit), Serializable]
    public class Format
    {
        [FieldOffset(0)]
        public MP3 mp3;
        [FieldOffset(0)]
        public LHV1 lhv1;
        [FieldOffset(0)]
        public ACC acc;

        public Format(WaveFormatEx format, uint MpeBitRate)
        {
            lhv1 = new LHV1(format, MpeBitRate);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("  mp3=\r\n  [\r\n{0}\r\n  ];\r\n\r\n", mp3);
            sb.AppendFormat("  lhv1=\r\n [\r\n{0}\r\n  ];\r\n\r\n", lhv1);
            sb.AppendFormat("  acc=\r\n  [\r\n{0}\r\n  ];\r\n", acc);
            return sb.ToString();
        }
    }

    [StructLayout(LayoutKind.Sequential), Serializable]
    public class BE_CONFIG
    {
        // encoding formats
        public const uint BE_CONFIG_MP3 = 0;
        public const uint BE_CONFIG_LAME = 256;

        public uint dwConfig;
        public Format format;

        public BE_CONFIG(WaveFormatEx format, uint MpeBitRate)
        {
            this.dwConfig = BE_CONFIG_LAME;
            this.format = new Format(format, MpeBitRate);
        }

        public BE_CONFIG(WaveFormatEx format)
            : this(format, 192)
        {
        }

        public BE_CONFIG() :
            this(WaveFormatEx.Cdda)
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("dwConfig={0}\r\n", dwConfig == 0 ? "BE_CONFIG_MP3" : "BE_CONFIG_LAME");
            sb.AppendFormat("format=\r\n[\r\n{0}];", format);
            return sb.ToString();
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class BE_VERSION
    {
        public const uint BE_MAX_HOMEPAGE = 256;
        public byte byDLLMajorVersion;
        public byte byDLLMinorVersion;
        public byte byMajorVersion;
        public byte byMinorVersion;
        // DLL Release date
        public byte byDay;
        public byte byMonth;
        public ushort wYear;
        //Homepage URL
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 257/*BE_MAX_HOMEPAGE+1*/)]
        public string zHomepage;
        public byte byAlphaLevel;
        public byte byBetaLevel;
        public byte byMMXEnabled;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 125)]
        public byte[] btReserved;
        public BE_VERSION()
        {
            btReserved = new byte[125];
        }
    }

    /// <summary>
    /// Lame_enc DLL functions
    /// </summary>
    public class Lame_encDll
    {
        //Error codes
        public const uint BE_ERR_SUCCESSFUL = 0;
        public const uint BE_ERR_INVALID_FORMAT = 1;
        public const uint BE_ERR_INVALID_FORMAT_PARAMETERS = 2;
        public const uint BE_ERR_NO_MORE_HANDLES = 3;
        public const uint BE_ERR_INVALID_HANDLE = 4;
        
        [DllImport("Lame_enc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint beInitStream(BE_CONFIG pbeConfig, ref uint dwSamples, ref uint dwBufferSize, ref uint phbeStream);

        [DllImport("Lame_enc.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern uint beEncodeChunk(uint hbeStream, uint nSamples, IntPtr pSamples, [In, Out] byte[] pOutput, ref uint pdwOutput);
        
        [DllImport("Lame_enc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint beDeinitStream(uint hbeStream, [In, Out] byte[] pOutput, ref uint pdwOutput);

        [DllImport("Lame_enc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint beCloseStream(uint hbeStream);
        
        public static uint EncodeChunk(uint hbeStream, byte[] buffer, int index, uint nBytes, byte[] pOutput, ref uint pdwOutput)
        {
            uint res;
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {
                IntPtr ptr = (IntPtr)(handle.AddrOfPinnedObject().ToInt32() + index);
                res = beEncodeChunk(hbeStream, nBytes / 2, ptr, pOutput, ref pdwOutput);
            }
            finally
            {
                handle.Free();
            }
            return res;
        }
    }
}
