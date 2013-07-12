#if HAVE_DSHOW
using System;
using System.Collections.Generic;
using OPMedia.Runtime.ProTONE.Rendering.Base;
using OPMedia.Runtime.ProTONE.FileInformation;
using System.Drawing;

using OPMedia.Core.Logging;

using OPMedia.Core;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;


namespace OPMedia.Runtime.ProTONE.Rendering.DS
{
    internal class DSTechnology : Technology
    {
        private string streamName = string.Empty;
        private string streamType = string.Empty;

        #region Construction

        ~DSTechnology()
        {
            streamRenderer = null;
        }

        static DSTechnology()
        {
            supportedAudioMediaTypes = new List<string>(new string[] 
            { 
                // 15 supported audio file types
                "au",   "aif", "aiff", 
                
                "cda", // Audio CD track

                "flac", "mid", 
                "midi", "mp1", "mp2",  "mp3", "mpa",  
                "raw", "rmi",  "snd",  "wav",  "wma",
                
            });

            supportedVideoMediaTypes = new List<string>(new string[] 
            {
                // 14 supported video file types

                "avi", "divx", "qt",  "m1v", "m2v", 
                "mod", "mov",  "mpg", "mpeg", "vob", 
                "wm", "wmv", 
                
                "mkv", "mp4", 
            });

            supportedHDVideoMediaTypes = new List<string>(new string[] 
            {
                "mkv", "mp4", 
            });
        }
        #endregion

        protected override MediaTypes GetRenderedMediaType()
        {
            MediaTypes mediaType = MediaTypes.None;

            if (streamRenderer != null)
            {
                if (streamRenderer.AudioMediaAvailable)
                {
                    mediaType = (streamRenderer.VideoMediaAvailable) ?
                        MediaTypes.Both : MediaTypes.Audio;
                }
                else if (streamRenderer.VideoMediaAvailable)
                {
                    mediaType = MediaTypes.Video;
                }
            }

            return mediaType;
        }

        protected override void DoSetRenderMedia(string streamName)
        {
            this.streamName = streamName;

            // Select the proper renderer for the specified media
            Uri uri = null;
            try
            {
                uri = new Uri(streamName, UriKind.Absolute);
            }
            catch
            {
                uri = null;
            }

            if (uri != null && !uri.IsFile)
            {
                this.streamType = "URL";
                //if (streamRenderer as DSShoutcastRenderer == null)
                //{
                //    streamRenderer = new DSShoutcastRenderer();
                //}

                if (streamRenderer as DSFileRenderer == null)
                {
                    streamRenderer = new DSFileRenderer();
                }
            }
            else
            {
                if (DvdMedia.FromPath(streamName) != null)
                {
                    this.streamType = "DVD";

                    if (streamRenderer as DSDvdRenderer == null)
                    {
                        streamRenderer = new DSDvdRenderer();
                    }
                }
                else
                {
                    this.streamType = PathUtils.GetExtension(streamName).ToLowerInvariant();
                    if (streamType == "cda")
                    {
                        if (streamRenderer as DSAudioCDRenderer == null)
                        {
                            streamRenderer = new DSAudioCDRenderer();
                        }
                    }
                    else if (streamRenderer as DSFileRenderer == null)
                    {
                        streamRenderer = new DSFileRenderer();
                    }
                }
            }

            Logger.LogTrace("Now playing media: {0}", streamName);
        }

        protected override string DoGetRenderMedia()
        {
            if (streamRenderer == null)
                return string.Empty;

            return streamRenderer.RenderMediaName;
        }

        protected override MediaFileInfo DoGetRenderMediaInfo()
        {
            if (streamRenderer == null)
                return null;

            return streamRenderer.RenderMediaInfo;
        }

        protected override void DoStartRendererWithHint(RenderingStartHint startHint)
        {
            streamRenderer.RenderMediaName = streamName;
            streamRenderer.RenderRegion = renderRegion;
            streamRenderer.StartRendererWithHint(startHint);
        }

        protected override void DoStartRenderer()
        {
            streamRenderer.RenderMediaName = streamName;
            streamRenderer.RenderRegion = renderRegion;
            streamRenderer.StartRenderer();
        }

        protected override void DoPauseRenderer()
        {
            Logger.LogTrace("Media renderer is paused now");
            streamRenderer.PauseRenderer();
        }

        protected override void DoStopRenderer()
        {
            Logger.LogTrace("Media renderer is stopped now");
            streamRenderer.StopRenderer();
        }

        protected override void DoResumeRenderer(double fromPosition)
        {
            Logger.LogTrace("Media renderer resumed now from position {0}", fromPosition);
            streamRenderer.ResumeRenderer(fromPosition);
        }

        protected override VideoFileInfo DoQueryVideoMediaInfo(string path)
        {
            VideoFileInfo vfi = null;

            DvdMedia dvdDrive = DvdMedia.FromPath(path);
            if (dvdDrive != null)
            {
                vfi = dvdDrive.VideoDvdInformation;
            }
            else
            {
                vfi = new VideoFileInfo(path, false);

                try
                {
                    if (vfi != null && vfi.IsValid)
                    {
                        IMediaControl mediaControl =
                            Activator.CreateInstance(Type.GetTypeFromCLSID(Filters.FilterGraph, true))
                            as IMediaControl;
                        IBasicAudio basicAudio = mediaControl as IBasicAudio;
                        IBasicVideo basicVideo = mediaControl as IBasicVideo;
                        IMediaPosition mediaPosition = mediaControl as IMediaPosition;

                        mediaControl.RenderFile(path);

                        double val = 0;
                        DsError.ThrowExceptionForHR(mediaPosition.get_Duration(out val));
                        vfi.Duration = TimeSpan.FromSeconds(val);

                        DsError.ThrowExceptionForHR(basicVideo.get_AvgTimePerFrame(out val));
                        vfi.FrameRate = new FrameRate(1f / val);

                        int h = 0, w = 0;
                        DsError.ThrowExceptionForHR(basicVideo.get_VideoHeight(out h));
                        DsError.ThrowExceptionForHR(basicVideo.get_VideoWidth(out w));
                        vfi.VideoSize = new VSize(w, h);

                        mediaControl.Stop();
                        mediaControl = null;
                        mediaPosition = null;
                        basicVideo = null;
                        basicAudio = null;

                        GC.Collect();
                    }
                }
                catch
                {
                }
            }

            return vfi;
        }

        protected override bool IsEndOfMedia
        {
            get 
            {
                if (streamRenderer == null)
                    return false;

                return streamRenderer.EndOfMedia; 
            }
        }
    }
}
#endif