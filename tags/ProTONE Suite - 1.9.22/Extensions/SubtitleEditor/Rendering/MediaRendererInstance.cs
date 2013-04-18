using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Runtime.ProTONE.Rendering.Base;
using OPMedia.UI.ProTONE.Controls.MediaPlayer;
using System.Windows.Forms;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Runtime.ProTONE.FfdShowApi;
using OPMedia.Core.Utilities;

namespace SubtitleEditor.Rendering
{
    public class MediaRendererInstance : IDisposable
    {
        static MediaRendererInstance __instance = new MediaRendererInstance();

        public static MediaRendererInstance Instance
        {
            get
            {
                return __instance;
            }
        }

        MediaRenderer _renderer = null;

        public MediaRenderer Renderer
        {
            get
            {
                return _renderer;
            }
        }

        private MediaRendererInstance()
        {
            _renderer = MediaRenderer.NewInstance();
            _renderer.MediaRendererClock += new MediaRendererEventHandler(_renderer_MediaRendererClock);
            _renderer.MediaRendererHeartbeat += new MediaRendererEventHandler(_renderer_MediaRendererHeartbeat);
            _renderer.MediaRenderingException += new MediaRenderingExceptionHandler(_renderer_MediaRenderingException);
            _renderer.MediaStateChanged += new MediaStateChangedHandler(_renderer_MediaStateChanged);
        }

        ~MediaRendererInstance()
        {
            Dispose();
        }

        void _renderer_MediaStateChanged(OPMedia.Runtime.ProTONE.Rendering.Base.MediaState oldState, string oldMedia, OPMedia.Runtime.ProTONE.Rendering.Base.MediaState newState, string newMedia)
        {
            FireMediaStateChanged(oldState, oldMedia, newState, newMedia);
        }

        void _renderer_MediaRenderingException(OPMedia.Runtime.ProTONE.Rendering.Base.RenderingExceptionEventArgs args)
        {
            FireMediaRenderingException(args);
        }

        void _renderer_MediaRendererHeartbeat()
        {
            FireMediaRendererHeartbeat();
        }

        void _renderer_MediaRendererClock()
        {
            FireMediaRendererClock();
        }

        #region Published events
        public event MediaRendererEventHandler MediaRendererClock = null;
        private void FireMediaRendererClock()
        {
            if (MediaRendererClock != null)
            {
                MediaRendererClock();
            }
        }

        public event MediaRendererEventHandler MediaRendererHeartbeat = null;
        private void FireMediaRendererHeartbeat()
        {
            if (MediaRendererHeartbeat != null)
            {
                MediaRendererHeartbeat();
            }
        }

        public event MediaStateChangedHandler MediaStateChanged = null;
        private void FireMediaStateChanged(MediaState oldState, string oldMedia, MediaState newState, string newMedia)
        {
            if (MediaStateChanged != null)
            {
                MediaStateChanged(oldState, oldMedia, newState, newMedia);
            }
        }

        public event MediaRenderingExceptionHandler MediaRenderingException = null;
        private void FireMediaRenderingException(RenderingExceptionEventArgs args)
        {
            if (MediaRenderingException != null)
            {
                MediaRenderingException(args);
            }
        }

        #endregion

        public void Dispose()
        {
            _renderer.Dispose();
            _renderer = null;
        }

        internal void SetRenderFile(string p)
        {
            _renderer.SetRenderFile(p);
        }

        internal void StartRenderer()
        {
            _renderer.StartRenderer();
        }

        internal void PauseRenderer()
        {
            _renderer.PauseRenderer();
        }

        internal void StopRenderer()
        {
            _renderer.StopRenderer();
        }

        internal void ResumeRenderer(double p)
        {
            _renderer.ResumeRenderer(p);
        }

        public Control RenderPanel 
        { 
            get { return _renderer.RenderPanel; }
            set { _renderer.RenderPanel = value; } 
        }

        public double MediaLength
        {
            get { return _renderer.MediaLength; }
        }

        public double MediaPosition
        {
            get { return _renderer.MediaPosition; }
        }

        public int AudioVolume
        {
            get { return _renderer.AudioVolume; }
            set { _renderer.AudioVolume = value; }
        }

        public MediaState MediaState
        {
            get { return _renderer.MediaState; }
        }

        internal VideoFileInfo QueryVideoMediaInfo(string p)
        {
            return _renderer.QueryVideoMediaInfo(p);
        }

        internal void DisplayOsdMessage(string p)
        {
            _renderer.DisplayOsdMessage(StringUtils.FixDiacriticals(p));
        }
    }
}
