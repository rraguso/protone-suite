using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.ProTONE.Rendering.Base;

namespace OPMedia.Runtime.ProTONE.Rendering.Mono
{
    internal class MonoRenderer : StreamRenderer
    {
        protected override void DoDispose()
        {
        }

        protected override void DoStartRenderer()
        {
        }

        protected override void DoPauseRenderer()
        {
        }

        protected override void DoStopRenderer()
        {
        }

        protected override void DoResumeRenderer(double fromPosition)
        {
        }

        protected override double GetMediaLength()
        {
            return 0f;
        }

        protected override double GetMediaPosition()
        {
            return 0f;
        }

        protected override void SetMediaPosition(double pos)
        {
        }

        protected override int GetAudioVolume()
        {
            return -5000;
        }

        protected override void SetAudioVolume(int vol)
        {
        }

        protected override bool IsAudioMediaAvailable()
        {
            return false;
        }

        protected override bool IsVideoMediaAvailable()
        {
            return false;
        }

        protected override bool IsMediaSeekable()
        {
            return false;
        }

        protected override MediaState GetMediaState()
        {
            return MediaState.Stopped;
        }

        protected override bool IsCursorVisible()
        {
            return false;
        }

        protected override void DoShowCursor(bool show)
        {
        }

        protected override void DoAdjustVideoSize(VideoSizeAdjustmentDirection direction, VideoSizeAdjustmentAction action)
        {
        }

        protected override void DoStartRendererWithHint(RenderingStartHint startHint)
        {
            throw new NotImplementedException();
        }

        protected override bool IsEndOfMedia()
        {
            return false;
        }

        protected override int DoGetSubtitleStream()
        {
            return 0;
        }

        protected override void DoSetSubtitleStream(int sid)
        {
        }

        protected override bool IsFullScreen()
        {
            return false;
        }

        protected override void DoSetFullScreen(bool fullScreen)
        {
        }

        protected override double GetDurationScaleFactor()
        {
            return 1;
        }

        protected override object DoGetGraphFilter()
        {
            return null;
        }
    }
}
