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
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;

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
            //_renderer = MediaRenderer.NewInstance();

            _renderer = MediaRenderer.DefaultInstance;
            _renderer.MediaRendererClock += new MediaRendererEventHandler(_renderer_MediaRendererClock);
            _renderer.MediaRendererHeartbeat += new MediaRendererEventHandler(_renderer_MediaRendererHeartbeat);
            _renderer.MediaRenderingException += new MediaRenderingExceptionHandler(_renderer_MediaRenderingException);
            _renderer.FilterStateChanged += new FilterStateChangedHandler(_renderer_FilterStateChanged);
        }

        void _renderer_FilterStateChanged(OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState oldState, string oldMedia, OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState newState, string newMedia)
        {
            FireFilterStateChanged(oldState, oldMedia, newState, newMedia);
        }

        ~MediaRendererInstance()
        {
            Dispose();
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

        public event FilterStateChangedHandler FilterStateChanged = null;
        private void FireFilterStateChanged(FilterState oldState, string oldMedia, FilterState newState, string newMedia)
        {
            if (FilterStateChanged != null)
            {
                FilterStateChanged(oldState, oldMedia, newState, newMedia);
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

        public FilterState FilterState
        {
            get { return _renderer.FilterState; }
        }

        public double DurationScaleFactor
        {
            get { return _renderer.DurationScaleFactor; }
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
