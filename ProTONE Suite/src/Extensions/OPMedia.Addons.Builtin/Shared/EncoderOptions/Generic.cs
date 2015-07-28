using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Runtime.ProTONE.Compression.Lame;

namespace OPMedia.Addons.Builtin.Shared.EncoderOptions
{
    public enum AudioMediaFormatType
    {
        MP3 = 0,
        WAV,
        WMA,
        OGG
    }

    public sealed class EncoderSettingsContainer
    {
        public AudioMediaFormatType AudioMediaFormatType { get; set; }

        public WavEncoderSettings WavEncoderSettings { get; set; }
        public Mp3EncoderSettings Mp3EncoderSettings { get; set; }
        public OggEncoderSettings OggEncoderSettings { get; set; }
        public WmaEncoderSettings WmaEncoderSettings { get; set; }

        public EncoderSettingsContainer()
        {
            this.AudioMediaFormatType = EncoderOptions.AudioMediaFormatType.WAV;
            this.WavEncoderSettings = new WavEncoderSettings();
            this.Mp3EncoderSettings = new Mp3EncoderSettings();
            this.OggEncoderSettings = new OggEncoderSettings();
            this.WmaEncoderSettings = new WmaEncoderSettings();
        }
    }

    public class WavEncoderSettings
    {
    }

    public class Mp3EncoderSettings
    {
        public bool GenerateTagsFromTrackMetadata { get; set; }

        public BE_CONFIG Mp3ConversionOptions { get; set; }

        public Mp3EncoderSettings()
        {
            this.GenerateTagsFromTrackMetadata = false;
            this.Mp3ConversionOptions = new BE_CONFIG();
        }
    }

    public class OggEncoderSettings
    {
    }

    public class WmaEncoderSettings
    {
    }

}
