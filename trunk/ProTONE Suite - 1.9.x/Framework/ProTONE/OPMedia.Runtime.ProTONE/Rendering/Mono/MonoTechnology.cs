using OPMedia.Runtime.ProTONE.FileInformation;
#if HAVE_MONO
using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.ProTONE.Rendering.Base;
using OPMedia.Runtime.ProTONE.FileInformation;

namespace OPMedia.Runtime.ProTONE.Rendering.Mono
{
    internal class MonoTechnology : Technology
    {
        private string streamName = string.Empty;
        private string streamType = string.Empty;

        #region Construction
        public MonoTechnology()
        {
            supportedAudioMediaTypes = new List<string>(new string[] 
            { 
                // 14 supported audio file types

                "au",   "aif", "aiff", "mid", 
                "midi", "mp1", "mp2",  "mp3",
                "mpa",  "raw", "rmi",  "snd",
                "wav",  "wma" 
            });

            supportedVideoMediaTypes = new List<string>(new string[] 
            {
                // 12 supported video file types

                "avi", "divx", "qt",  "m1v", 
                "m2v", "mov",  "mpg", "mp4",
                "mpeg", "vob", "wm",   "wmv"
            });

            streamRenderer = new MonoRenderer();
        }
        #endregion

        protected override MediaTypes GetRenderedMediaType()
        {
            MediaTypes mediaType = MediaTypes.None;
            if (streamRenderer.AudioMediaAvailable)
            {
                mediaType = (streamRenderer.VideoMediaAvailable) ? 
                    MediaTypes.Both : MediaTypes.Audio;
            }
            else if (streamRenderer.VideoMediaAvailable)
            {
                mediaType = MediaTypes.Video;
            }
            return mediaType;
        }

        protected override void DoSetRenderMedia(string streamName)
        {
            this.streamName = streamName;
            System.IO.FileInfo fi = new System.IO.FileInfo(streamName);
            this.streamType = fi.Extension.Trim(new char[] { '.' }).ToLowerInvariant();
        }

        protected override string DoGetRenderMedia()
        {
            return streamRenderer.RenderMediaName;
        }

        protected override void DoStartRenderer()
        {
            streamRenderer.RenderMediaName = streamName;
            streamRenderer.RenderRegion = renderRegion;
            streamRenderer.StartRenderer();
        }

        protected override void DoPauseRenderer()
        {
            streamRenderer.PauseRenderer();
        }

        protected override void DoStopRenderer()
        {
            streamRenderer.StopRenderer();
        }

        protected override void DoResumeRenderer(double fromPosition)
        {
            streamRenderer.ResumeRenderer(fromPosition);
        }

        protected override VideoFileInfo DoQueryVideoMediaInfo(string path)
        {
            VideoFileInfo vfi = new VideoFileInfo(path, false);

            return vfi;
        }

        protected override void DoStartRendererWithHint(RenderingStartHint startHint)
        {
        }

        protected override MediaFileInfo DoGetRenderMediaInfo()
        {
            return MediaFileInfo.Empty;
        }

        protected override bool IsEndOfMedia
        {
            get { return true; }
        }
    }
}
#endif