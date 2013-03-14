using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.FileInformation;

namespace OPMedia.Runtime.ProTONE.FileInformation
{
    public class VideoFileInfo : MediaFileInfo
    {
        TimeSpan duration;
        VSize videoSize = new VSize();
        FrameRate frameRate;

        [Browsable(false)]
        public override Dictionary<string, string> ExtendedInfo
        {
            get
            {
                Dictionary<string, string> info = new Dictionary<string, string>();

                info.Add("TXT_DURATION:", Duration.GetValueOrDefault().ToString());
                info.Add("TXT_VIDEO_SIZE:", videoSize.ToString());
                info.Add("TXT_FRAME_RATE:", frameRate.ToString());

                return info;
            }
        }

        [TranslatableDisplayName("TXT_DURATION")]
        [TranslatableCategory("TXT_MEDIAINFO")]
        [SingleSelectionBrowsable]
        [ReadOnly(true)]
        public override TimeSpan? Duration
        {
            get { return duration; }
            set { duration = TimeSpan.FromSeconds((int)value.GetValueOrDefault().TotalSeconds); }
        }

        [TranslatableDisplayName("TXT_VIDEO_SIZE")]
        [TranslatableCategory("TXT_MEDIAINFO")]
        [SingleSelectionBrowsable]
        [ReadOnly(true)]
        public VSize? VideoSize
        {
            get { return videoSize; }
            set { videoSize = value.GetValueOrDefault(); }
        }

        [TranslatableDisplayName("TXT_FRAME_RATE")]
        [TranslatableCategory("TXT_MEDIAINFO")]
        [SingleSelectionBrowsable]
        [ReadOnly(true)]
        public FrameRate? FrameRate
        {
            get { return frameRate; }
            set { frameRate = value.GetValueOrDefault(); }
        }


        public VideoFileInfo(string path, bool throwExceptionOnInvalid)
            : base(path, throwExceptionOnInvalid)    
        {
        }

        protected VideoFileInfo() : base()
        {
        }
    }

    public struct VSize
    {
        Size _size;

        public VSize(int w, int h)
        {
            this = new VSize();
            _size.Width = w;
            _size.Height = h;
        }

        public int Width
        { get { return _size.Width; } set { _size.Width = value; } }

        public int Height
        { get { return _size.Height; } set { _size.Height = value; } }

        public override string ToString()
        {
            return string.Format("{0} x {1}", _size.Width, _size.Height);
        }
    }

    public struct FrameRate
    {
        double _f;

        public double Value
        {
            get
            {
                return _f;
            }
        }

        public FrameRate(double f)
        {
            this = new FrameRate();
            _f = f;
        }

        public override string ToString()
        {
            return _f.ToString("##.###") + " FPS";
        }
    }

}
