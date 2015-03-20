using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Tasks;
using OPMedia.Addons.Builtin.Shared.EncoderOptions;
using OPMedia.Core;
using OPMedia.Runtime.ProTONE.Compression.Lame;
using OPMedia.UI;

namespace OPMedia.Addons.Builtin.Property.TaggedFileProp.TaggingWizard.Helpers
{
    public class Transcoder
    {
        static List<Transcoding> _supportedTranscodings = new List<Transcoding>();

        [Browsable(false)]
        public EncoderSettingsContainer EncoderSettings { get; set; }

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

        static Transcoder()
        {
            _supportedTranscodings.Add(new Transcoding 
                {
                    // MP3 to MP3 is supported
                    InputFormat = AudioMediaFormatType.MP3,
                    OutputFormat = AudioMediaFormatType.MP3
                });

            _supportedTranscodings.Add(new Transcoding
                {
                    // MP3 to WAV is supported
                    InputFormat = AudioMediaFormatType.MP3,
                    OutputFormat = AudioMediaFormatType.WAV
                });

            _supportedTranscodings.Add(new Transcoding
                {
                    // WAV to MP3 is supported
                    InputFormat = AudioMediaFormatType.WAV,
                    OutputFormat = AudioMediaFormatType.MP3
                });
        }

        public Transcoder()
        {
        }

        public void ChangeEncoding(string file)
        {
            string inputFileType = PathUtils.GetExtension(file).ToUpperInvariant();

            AudioMediaFormatType inputFormat = AudioMediaFormatType.WAV;
            AudioMediaFormatType outputFormat = EncoderSettings.AudioMediaFormatType;

            if (Enum.TryParse<AudioMediaFormatType>(inputFileType, out inputFormat) == false)
                throw new NotSupportedException(string.Format("TXT_UNSUPPORTED_FORMAT: {0}", inputFileType));

            InternalChangeEncoding(inputFormat, outputFormat, file);
        }

        private void InternalChangeEncoding(AudioMediaFormatType inputFormat, AudioMediaFormatType outputFormat, string file)
        {
            Transcoding requestedTranscoding = new Transcoding
            {
                InputFormat = inputFormat,
                OutputFormat = outputFormat
            };

            if (_supportedTranscodings.Contains(requestedTranscoding) == false)
                throw new NotSupportedException(string.Format("TXT_UNSUPPORTED_TRANSCODING: {0}", requestedTranscoding));

            requestedTranscoding.DoTranscoding(EncoderSettings, file);
        }
    }

    public class Transcoding
    {
        public AudioMediaFormatType InputFormat { get; set; }
        public AudioMediaFormatType OutputFormat { get; set; }

        public override bool Equals(object obj)
        {
            Transcoding t = obj as Transcoding;
            if (t != null)
            {
                return (t.InputFormat == this.InputFormat) &&
                    (t.OutputFormat == this.OutputFormat);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} => {1}", InputFormat, OutputFormat);
        }

        public void DoTranscoding(EncoderSettingsContainer encoderSettings, string inputFile)
        {
            MainThread.Post((c) => 
                MessageDisplay.Show(string.Format("Transcoding {0}: not yet implemented. Sorry !", this), "oops", 
                System.Windows.Forms.MessageBoxIcon.Exclamation));
        }
    }
}
