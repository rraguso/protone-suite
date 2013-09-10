

#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Runtime.ProTONE.Rendering.DS;
#endregion

namespace OPMedia.Runtime.ProTONE.Rendering.Base
{
    internal abstract class Technology : IDisposable
    {
        protected static List<string> supportedHDVideoMediaTypes = null;
        protected static List<string> supportedVideoMediaTypes = null;
        protected static List<string> supportedAudioMediaTypes = null;

        #region Members
        protected Control renderRegion = null;
        protected StreamRenderer streamRenderer = null;
        #endregion

        #region Properties

        public bool IsStreamedMedia { get { return (streamRenderer is DSShoutcastRenderer); } } 

        internal object GraphFilter
        { get { return (streamRenderer == null) ? null : streamRenderer.GraphFilter; } }

        internal int VolumeAvgR { get { return streamRenderer.VolumeAvgR; } }
        internal int VolumeAvgL { get { return streamRenderer.VolumeAvgL; } }
        internal int VolumePeakR { get { return streamRenderer.VolumePeakR; } }
        internal int VolumePeakL { get { return streamRenderer.VolumePeakL; } }

        public static List<string> SupportedHDVideoMediaTypes
        { get { return supportedHDVideoMediaTypes; } }

        public static List<string> SupportedVideoMediaTypes 
        { get { return supportedVideoMediaTypes;} }

        public static List<string> SupportedAudioMediaTypes 
        { get { return supportedAudioMediaTypes;} }

        internal Control RenderRegion
        { get { return renderRegion; } set { renderRegion = value; } }

        internal bool MediaSeekable
        { get { return (streamRenderer == null) ? false : streamRenderer.MediaSeekable; } }

        internal double MediaLength
        { get { return (streamRenderer == null) ? 0 : streamRenderer.MediaLength; } }

        internal double DurationScaleFactor
        { get { return (streamRenderer == null) ? 0 : streamRenderer.DurationScaleFactor; } }

        internal double MediaPosition
        {
            get { return (streamRenderer == null) ? 0 : streamRenderer.MediaPosition; }
            set { if (streamRenderer != null) { streamRenderer.MediaPosition = value; } }
        }

        internal MediaTypes RenderedMediaType
        { get { return GetRenderedMediaType(); } }

        internal bool ShowCursor
        {
            get { return streamRenderer.ShowCursor; }
            set { streamRenderer.ShowCursor = value; } 
        }

        internal bool FullScreen
        {
            get { return streamRenderer.FullScreen; }
            set { streamRenderer.FullScreen = value; }
        }

        internal OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState FilterState
        { 
            get 
            { 
                return (streamRenderer == null) ?
                    OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Stopped : 
                    streamRenderer.FilterState; 
            } 
        }

        internal int AudioVolume
        {
            get { return (streamRenderer == null) ? (int)VolumeRange.Minimum : streamRenderer.AudioVolume; }
            set { if (streamRenderer != null) { streamRenderer.AudioVolume = value; } }
        }

        internal int AudioBalance
        {
            get { return (streamRenderer == null) ? 0 : streamRenderer.AudioBalance; }
            set { if (streamRenderer != null) { streamRenderer.AudioBalance = value; } }
        }

        internal int SubtitleStream
        {
            get 
            { 
                return (streamRenderer == null &&
                    FilterState != OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Stopped) ? 
                    -1 : streamRenderer.GetSubtitleStream(); 
            }
            
            set 
            { 
                if (streamRenderer != null &&
                    FilterState != OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Stopped) 
                { 
                    streamRenderer.SetSubtitleStream(value); 
                } 
            }
        }

        #endregion

        #region Methods
        internal void SetRenderMedia(string streamName)
        {
            DoSetRenderMedia(streamName);
        }

        internal string GetRenderMedia()
        {
            return DoGetRenderMedia();
        }

        internal MediaFileInfo GetRenderMediaInfo()
        {
            return DoGetRenderMediaInfo();
        }

        internal void StartRendererWithHint(RenderingStartHint startHint)
        {
            DoStartRendererWithHint(startHint);
        }

        internal void StartRenderer()
        {
            DoStartRenderer();
        }

        internal void PauseRenderer()
        {
            DoPauseRenderer();
        }

        internal void StopRenderer()
        {
            DoStopRenderer();
        }

        internal void ResumeRenderer(double fromPosition)
        {
            DoResumeRenderer(fromPosition);
        }

        internal VideoFileInfo QueryVideoMediaInfo(string path)
        {
            return DoQueryVideoMediaInfo(path);
        }

        internal void AdjustVideoSize(VideoSizeAdjustmentDirection direction, VideoSizeAdjustmentAction action)
        {
            streamRenderer.AdjustVideoSize(direction, action);
        }

        internal bool EndOfMedia
        {
            get
            {
                return IsEndOfMedia;
            }
        }
        #endregion

        #region Construction
        public Technology()
        {
        }
        #endregion

        #region Implementation

        protected abstract MediaTypes GetRenderedMediaType();

        protected abstract void DoStartRenderer();
        protected abstract void DoStartRendererWithHint(RenderingStartHint startHint);

        protected abstract MediaFileInfo DoGetRenderMediaInfo();
        protected abstract string DoGetRenderMedia();
        protected abstract void DoSetRenderMedia(string streamName);
        
        protected abstract void DoPauseRenderer();
        protected abstract void DoStopRenderer();
        protected abstract void DoResumeRenderer(double fromPosition);

        protected abstract VideoFileInfo DoQueryVideoMediaInfo(string path);

         protected abstract bool IsEndOfMedia { get; }

        #endregion

         public void Dispose()
         {
             if (streamRenderer != null)
             {
                 streamRenderer.Dispose();
                 streamRenderer = null;
             }
         }
    }
}
