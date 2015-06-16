#if HAVE_DSHOW
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using OPMedia.Runtime.ProTONE.Rendering.Base;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Core.Logging;
using OPMedia.Core;

using OPMedia.Core.Configuration;

using OPMedia.Runtime.ProTONE.ExtendedInfo;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;




namespace OPMedia.Runtime.ProTONE.Rendering.DS
{
    internal class DSFileRenderer : DsRendererBase
    {
        protected override void DoStartRendererWithHint(RenderingStartHint startHint)
        {
            if (startHint is BookmarkStartHint)
            {
                double newPos = (startHint as BookmarkStartHint).Bookmark.PlaybackTimeInSeconds;

                if (this.FilterState == OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Running)
                {
                    // Seek "on the fly" to new position.
                    SetMediaPosition(newPos);
                }
                else if (this.FilterState == OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Paused)
                {
                    // Resume renderer from the to new position.
                    ResumeRenderer(newPos);
                }
                else
                {
                    // Start rendering first then seek to new position.
                    DoStartRenderer();
                    SetMediaPosition(newPos);
                }
            }
            else
            {
                throw new InvalidOperationException("A file renderer can accept only a BookmarkStartHint.");
            }
        }

        protected override void DoStartRenderer()
        {
            if (renderMediaName == null || renderMediaName.Length <= 0)
                return;

            renderMediaInfo = MediaFileInfo.FromPath(renderMediaName, true);

            GC.Collect();

            InitMedia();
            InitAudioAndVideo();

            int hr = mediaPosition.put_Rate(1);
            DsError.ThrowExceptionForHR(hr);

            // Run the graph to play the media file
            hr = mediaControl.Run();
            DsError.ThrowExceptionForHR(hr);

            rotEntry = new DsROTEntry(mediaControl as IFilterGraph);

            // HACK: call GetMedialenght once here to ensure that durationScaleFactor is buuilt up
            double len = GetMediaLength();
        }

        protected override void DoResumeRenderer(double fromPosition)
        {
            base.DoResumeRenderer(fromPosition);
            
            // This is called to enforce re-caching the bookmarks
            renderMediaInfo.LoadBookmarks(false);
        }

        protected override double GetMediaLength()
        {
            double val = 0;
            bool gotTimeFromMediaInfo = false;
            double actualMediaLength = base.GetMediaLength();

            if (renderMediaInfo != null)
            {
                val = renderMediaInfo.Duration.GetValueOrDefault().TotalSeconds;
                gotTimeFromMediaInfo = (val > 0f);
            }


            if (!gotTimeFromMediaInfo)
                val = actualMediaLength;

            if (Math.Abs(actualMediaLength) > double.Epsilon)
            {
                durationScaleFactor = val / actualMediaLength;
            }
            else
            {
                durationScaleFactor = 0;
            }

            return val;
        }

        #region Implementation

        private void InitMedia()
        {
            mediaControl = Activator.CreateInstance(Type.GetTypeFromCLSID(Filters.FilterGraph, true))
                        as IMediaControl;

            if ((mediaControl as IGraphBuilder) == null)
                throw new RenderingException("Unable to render the file: " + renderMediaName);

#if HAVE_SAMPLES
            InitAudioSampleGrabber();
#endif
            
            int hr = (mediaControl as IGraphBuilder).RenderFile(renderMediaName, null);
            DsError.ThrowExceptionForHR(hr);

#if HAVE_SAMPLES
            CompleteAudioSampleGrabberIntialization();
#endif

            mediaPosition = mediaControl as IMediaPosition;
            videoWindow = mediaControl as IVideoWindow;
            basicVideo = mediaControl as IBasicVideo;
            basicAudio = mediaControl as IBasicAudio;
            mediaEvent = mediaControl as IMediaEventEx;
        }

        protected override void HandleGraphEvent(EventCode code, int p1, int p2)
        {
            Logger.LogHeavyTrace("GraphEvent: {0} : {1} : {2}", code, p1, p2);
        }

        protected override int DoGetSubtitleStream()
        {
            // Not required at this point for file renderers.
            return -1;
        }

        protected override void DoSetSubtitleStream(int sid)
        {
            // Not required at this point for file renderers.
        }
        #endregion


        protected override double GetDurationScaleFactor()
        {
            return durationScaleFactor;
        }
    }
}
#endif