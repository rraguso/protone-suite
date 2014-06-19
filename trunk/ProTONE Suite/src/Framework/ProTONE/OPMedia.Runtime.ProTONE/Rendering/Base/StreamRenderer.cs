#region Copyright © 2006 OPMedia Research
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	MediaRenderer.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;
#endregion

namespace OPMedia.Runtime.ProTONE.Rendering.Base
{
    public abstract class StreamRenderer : IDisposable
    {
        #region Members
        protected Control renderRegion = null;
        protected Control messageDrain = null;
        protected string renderMediaName = string.Empty;
        protected List<string> supportedMediaTypes = null;

        protected MediaFileInfo renderMediaInfo = MediaFileInfo.Empty;

        protected object _sync = new object();
        #endregion

        #region Properties

        internal Control RenderRegion
        { get { return renderRegion; } set { renderRegion = value; } }

        internal bool MediaSeekable
        { 
            get 
            {
                return IsMediaSeekable(); 
            } 
        }

        internal double DurationScaleFactor
        {
            get
            {
                return GetDurationScaleFactor();
            }
        }


        internal double MediaLength
        { 
            get 
            {
                return GetMediaLength(); 
            } 
        }

        internal double MediaPosition
        { 
            get 
            {
                return GetMediaPosition(); 
            } 
            set 
            {
                SetMediaPosition(value); 
            } 
        }

        internal bool AudioMediaAvailable
        { 
            get 
            {
                return IsAudioMediaAvailable(); 
            } 
        }

        internal bool VideoMediaAvailable
        {
            get
            {
                return IsVideoMediaAvailable();
            }
        }

        internal OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState FilterState
        { 
            get 
            {
                return GetFilterState(); 
            } 
        }

        internal int AudioVolume
        {
            get 
            {
                return GetAudioVolume(); 
            } 
            set 
            {
                SetAudioVolume(value); 
            } 
        }

        internal int AudioBalance
        {
            get
            {
                return GetAudioBalance();
            }
            set
            {
                SetAudioBalance(value);
            }
        }

        internal Control MessageDrain
        {
            get { return messageDrain; }
            set { messageDrain = value; }
        }

        internal bool ShowCursor
        {
            get { return IsCursorVisible(); }
            set { DoShowCursor(value); }
        }

        internal bool FullScreen
        {
            get { return IsFullScreen(); }
            set { DoSetFullScreen(value); }
        }

        internal object GraphFilter
        { get { return DoGetGraphFilter(); } }

        public WaveFormatEx ActualAudioFormat
        {
            get
            {
                return DoGetActualAudioFormat();
            }
        }

        #endregion

        #region Methods
        internal string RenderMediaName
        {
            get
            {
                return renderMediaName;
            }

            set
            {
                renderMediaName = value;
            }
        }


        internal MediaFileInfo RenderMediaInfo
        {
            get
            {
                return renderMediaInfo;
            }
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

        internal void AdjustVideoSize(VideoSizeAdjustmentDirection direction, VideoSizeAdjustmentAction action)
        {
            DoAdjustVideoSize(direction, action);
        }

        internal bool EndOfMedia
        {
            get
            {
                return IsEndOfMedia();
            }
        }

        internal int GetSubtitleStream()
        {
            return DoGetSubtitleStream();
        }

        internal void SetSubtitleStream(int sid)
        {
            DoSetSubtitleStream(sid);
        }

        #endregion

        #region Construction
        public StreamRenderer()
        {
            //ResetVolumeLevels();
        }
        #endregion

        #region Implementation

        //protected void ResetVolumeLevels()
        //{
        //    VolumeAvgL = 0;
        //    VolumeAvgR = 0;
        //    VolumePeakL = 0;
        //    VolumePeakR = 0;
        //}

        #region IDisposable Members
        public void Dispose()
        {
            DoDispose();
        }

        protected virtual void DoDispose()
        {
            DoStopRenderer();
        }

        #endregion

        protected abstract void DoStartRenderer();
        protected abstract void DoStartRendererWithHint(RenderingStartHint startHint);

        protected abstract void DoPauseRenderer();
        protected abstract void DoStopRenderer();
        protected abstract void DoResumeRenderer(double fromPosition);

        protected abstract double GetMediaLength();
        protected abstract double GetMediaPosition();
        protected abstract double GetDurationScaleFactor();

        protected abstract void SetMediaPosition(double pos);

        protected abstract int GetAudioVolume();
        protected abstract void SetAudioVolume(int b);

        protected abstract int GetAudioBalance();
        protected abstract void SetAudioBalance(int b);

        protected abstract bool IsAudioMediaAvailable();
        protected abstract bool IsVideoMediaAvailable();
        protected abstract bool IsMediaSeekable();

        protected abstract OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState GetFilterState();

        protected abstract bool IsCursorVisible();
        protected abstract void DoShowCursor(bool show);

        protected abstract void DoAdjustVideoSize(VideoSizeAdjustmentDirection direction, VideoSizeAdjustmentAction action);

        protected abstract bool IsEndOfMedia();

        protected abstract int DoGetSubtitleStream();
        protected abstract void DoSetSubtitleStream(int sid);

        protected abstract bool IsFullScreen();
        protected abstract void DoSetFullScreen(bool fullScreen);

        protected abstract object DoGetGraphFilter();

        protected abstract WaveFormatEx DoGetActualAudioFormat();

        #endregion
    }
}

