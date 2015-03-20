using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Tasks;
using OPMedia.Core;
using OPMedia.Runtime.ProTONE.Compression.Lame;

namespace OPMedia.Addons.Builtin.Property.TaggedFileProp.TaggingWizard.Helpers
{
    public class Transcoder
    {
        static private List<CdRipperOutputFormatType[]> _supportedTranscodings =
            new List<CdRipperOutputFormatType[]>();

        [Browsable(false)]
        public BE_CONFIG Mp3ConversionOptions { get; set; }

        [Browsable(false)]
        public CdRipperOutputFormatType OutputFormatType { get; set; }

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
            _supportedTranscodings.Add(new CdRipperOutputFormatType[] 
                {
                    // MP3 to MP3 is supported
                    CdRipperOutputFormatType.MP3,
                    CdRipperOutputFormatType.MP3
                });
            _supportedTranscodings.Add(new CdRipperOutputFormatType[] 
                {
                    // MP3 to WAV is supported
                    CdRipperOutputFormatType.MP3,
                    CdRipperOutputFormatType.WAV
                });
            _supportedTranscodings.Add(new CdRipperOutputFormatType[] 
                {
                    // WAV to MP3 is supported
                    CdRipperOutputFormatType.WAV,
                    CdRipperOutputFormatType.MP3
                });
        }

        public Transcoder()
        {
        }

        public void ChangeEncoding(string file)
        {
            string inputFileType = PathUtils.GetExtension(file).ToUpperInvariant();

            CdRipperOutputFormatType inputFormat = CdRipperOutputFormatType.WAV;
            CdRipperOutputFormatType outputFormat = this.OutputFormatType;

            if (Enum.TryParse<CdRipperOutputFormatType>(inputFileType, out inputFormat))
            {
                InternalChangeEncoding(inputFormat, outputFormat, file);
            }

            throw new NotSupportedException("Unsupported input file format: " + inputFileType);
        }

        private void InternalChangeEncoding(CdRipperOutputFormatType inputFormat, CdRipperOutputFormatType outputFormat, string file)
        {
            CdRipperOutputFormatType[] requestedTranscoding = new CdRipperOutputFormatType[]
            {
                inputFormat, outputFormat
            };

            if (_supportedTranscodings.Contains(requestedTranscoding) == false)
                throw new NotSupportedException(string.Format("Transcoding from {0} to {1} is not supported", inputFormat, outputFormat));
        }

    }
}
