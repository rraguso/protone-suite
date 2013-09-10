#if HAVE_DSHOW

using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.ProTONE.Rendering.Base;

using OPMedia.Core.Logging;
using System.Runtime.InteropServices;
using OPMedia.Core;
using System.Windows.Forms;


using System.Diagnostics;

using DS = OPMedia.Runtime.ProTONE.Rendering.DS;
using System.Threading;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;


namespace OPMedia.Runtime.ProTONE.Rendering.DS
{
    public abstract class DsRendererBase : StreamRenderer
#if HAVE_SAMPLES
        , DS.ISampleGrabberCB
#endif
    {
        protected IMediaControl mediaControl = null;
        protected IVideoWindow videoWindow = null;
        protected IBasicAudio basicAudio = null;
        protected IBasicVideo basicVideo = null;
        protected IMediaPosition mediaPosition = null;
        protected IMediaEventEx mediaEvent = null;

        protected bool isVideoAvailable = false;
        protected bool isAudioAvailable = false;

        protected double durationScaleFactor = 1;

        internal int VideoWidth
        {
            get
            {
                int w = 0;
                int hr = basicVideo.get_VideoWidth(out w);
                if (hr >= 0)
                    return w;

                return 0;
            }
        }

        internal int VideoHeight
        {
            get
            {
                int h = 0;
                int hr = basicVideo.get_VideoHeight(out h);
                if (hr >= 0)
                    return h;

                return 0;
            }
        }


        public DsRendererBase()
        {
            GraphNotifyWnd.Instance.FilterGraphMessage += 
                new System.Windows.Forms.MethodInvoker(OnFilterGraphMessage);

            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
#if HAVE_SAMPLES
            ReleaseAudioSampleGrabber();
#endif
        }

        private void OnFilterGraphMessage()
        {
            int p1, p2;
            EventCode code = EventCode.None;

            if (mediaEvent == null) 
                return;

            while (mediaEvent.GetEvent(out code, out p1, out p2, 0) == 0)
            {
                try
                {
                    mediaEvent.FreeEventParams(code, p1, p2);

                    Logger.LogHeavyTrace("HandleGraphEvent: code={0} p1={1} p2={2}", code, p1, p2);
                    HandleGraphEvent(code, p1, p2);
                }
                catch (COMException ex)
                {
                    Logger.LogHeavyTrace("Filter graph message loop broken because: {0}",
                        ErrorDispatcher.GetErrorMessageForException(ex, false));
                    break;
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                    break;
                }
            }
        }

        protected abstract void HandleGraphEvent(EventCode code, int p1, int p2);

        protected override void DoStartRenderer()
        {
            // Leave empty; every particular renderer will do its own startup.
        }

        protected override void DoStartRendererWithHint(RenderingStartHint startHint)
        {
            // Leave empty; every particular renderer will do its own startup.
        }

        protected override void DoPauseRenderer()
        {
            if (mediaControl != null)
                mediaControl.Pause();
        }

        protected override void DoStopRenderer()
        {
            GC.Collect();

            if (isVideoAvailable)
            {
                renderRegion.Resize -= new EventHandler(renderPanel_Resize);
                DoStopInternal(null);

                // Not nice, but this avoids player freezing
                // sometimes when stopping video media. 
                //ThreadPool.QueueUserWorkItem(AsyncStop);
                //Thread.Sleep(1000);
            }
            else
            {
                DoStopInternal(null);
            }
        }

        protected virtual void DoStopInternal(object state)
        {
            try
            {
                //ResetVolumeLevels();
#if HAVE_SAMPLES
                ReleaseAudioSampleGrabber();
#endif

                if (mediaControl != null)
                {
                    mediaControl.Stop();

                    mediaControl = null;
                    mediaPosition = null;
                    videoWindow = null;
                    basicVideo = null;
                    basicAudio = null;
                    mediaEvent = null;
                }

                GC.Collect();
            }
            catch (Exception ex)
            {
                // This is running on other thread than the DSRenderer,
                // so its exceptions are not caught in MediaRenderer
                ErrorDispatcher.DispatchError(ex);
            }
        }

        protected void InitAudioAndVideo()
        {
            try
            {
                //ResetVolumeLevels();

                //int val = 0;

                int w = 0;
                int hr = basicVideo.get_VideoWidth(out w);
                isVideoAvailable = (hr >=0 && w > 0);

                // Setup the video window
                SetupVideoWindow();

                FitVideoInPanel();

                renderRegion.Visible = true;
                
                renderRegion.Resize -= new EventHandler(renderPanel_Resize);
                renderRegion.Resize += new EventHandler(renderPanel_Resize);
            }
            catch
            {
                isVideoAvailable = false;               
            }

            try
            {
                int hr = basicAudio.put_Volume((int)VolumeRange.Minimum);
                isAudioAvailable = (hr >= 0);
            }
            catch
            {
                isAudioAvailable = false;
            }
        }

        private void SetupVideoWindow()
        {
            videoWindow.put_Owner(renderRegion.Handle);
            videoWindow.put_MessageDrain(renderRegion.Handle);
            videoWindow.put_WindowStyle((int)(WindowStyle.Child |
                WindowStyle.ClipSiblings |
                WindowStyle.ClipChildren));

            mediaEvent.SetNotifyWindow(GraphNotifyWnd.Instance.Handle, (int)Messages.WM_GRAPH_EVENT, IntPtr.Zero);
        }


        protected void renderPanel_Resize(object sender, EventArgs e)
        {
            if (videoWindow != null)
            {
                FitVideoInPanel();
            }
        }

        protected void FitVideoInPanel()
        {
            int width, height;
            int left = 0, top = 0;

            double videoAspectRatio =
                (double)(VideoWidth) / (double)(VideoHeight);
            double panelAspectRatio = (double)renderRegion.Width / (double)renderRegion.Height;

            if (videoAspectRatio >= panelAspectRatio)
            {
                // "wide" video, use width as basis
                width = renderRegion.Width;
                height = (int)(width / videoAspectRatio);
                left = 0;
                top = (renderRegion.Height - height) / 2;
            }
            else
            {
                // "tall" video, use height as basis
                height = renderRegion.Height;
                width = (int)(videoAspectRatio * height);
                left = (renderRegion.Width - width) / 2;
                top = 0;
            }

            renderRegion.SuspendLayout();
            videoWindow.SetWindowPosition(left, top, width, height);
            renderRegion.ResumeLayout();
        }

        protected override void DoResumeRenderer(double fromPosition)
        {
            if (fromPosition > 0)
                SetMediaPosition(fromPosition);

            if (mediaControl != null)
                mediaControl.Run();
        }

        protected override double GetMediaLength()
        {
            double val = 0;

            if (mediaPosition != null)
            {
                int hr = mediaPosition.get_Duration(out val);
                if (hr >= 0)
                    return (val + double.Epsilon);
            }

            return double.Epsilon;
        }

        protected override double GetMediaPosition()
        {
            double val = 0;

            if (mediaPosition != null)
            {
                mediaPosition.get_CurrentPosition(out val);
            }

            return val * durationScaleFactor;
        }

        protected override void SetMediaPosition(double pos)
        {
            if (mediaPosition != null)
            {
                mediaPosition.put_CurrentPosition(pos / durationScaleFactor);
            }
        }

        protected override int GetAudioVolume()
        {
            int val = -1;
            if (isAudioAvailable)
            {
                basicAudio.get_Volume(out val);
            }

            return val;
        }

        protected override void SetAudioVolume(int vol)
        {
            if (isAudioAvailable)
            {
                if (vol < -10000)
                    vol = -10000;
                else if (vol > 0)
                    vol = 0;

                basicAudio.put_Volume(vol);
            }
        }

        protected override int GetAudioBalance()
        {
            int val = 0;
            if (isAudioAvailable)
            {
                basicAudio.get_Balance(out val);
            }

            return val;
        }

        protected override void SetAudioBalance(int b)
        {
            if (isAudioAvailable)
            {
                if (b < -10000)
                    b = -10000;
                else if (b > 10000)
                    b = 10000;

                basicAudio.put_Balance(b);
            }
        }
        
        protected override bool IsVideoMediaAvailable()
        {
            return isVideoAvailable;
        }

        protected override bool IsAudioMediaAvailable()
        {
            return isAudioAvailable;
        }

        protected override bool IsMediaSeekable()
        {
            OABool seekFwd = OABool.False, seekBwd = OABool.False;
            if (mediaPosition != null)
            {
                mediaPosition.CanSeekForward(out seekFwd);
                mediaPosition.CanSeekBackward(out seekBwd);
            }

            return (seekFwd != OABool.False && seekBwd != OABool.False);
        }

        protected override BaseClasses.FilterState GetFilterState()
        {
            BaseClasses.FilterState fs = BaseClasses.FilterState.Stopped;
            if (mediaControl != null)
            {
                mediaControl.GetState(0, out fs);
            }

            return fs;
        }

        protected override bool IsCursorVisible()
        {
            bool retVal = false;
            if (isVideoAvailable && videoWindow != null)
            {
                int hidden = (int)OABool.False;
                videoWindow.IsCursorHidden(out hidden);
                retVal = (hidden == (int)OABool.False);
            }

            return retVal;
        }

        protected override void DoShowCursor(bool show)
        {
            if (isVideoAvailable && videoWindow != null)
            {
                int hidden = (show) ? (int)OABool.False : (int)OABool.True;
                videoWindow.HideCursor(hidden);
            }
        }
        protected override void DoAdjustVideoSize(VideoSizeAdjustmentDirection direction, VideoSizeAdjustmentAction action)
        {
            // TODO: nothing at this time. implement later on.
        }

        protected override bool IsEndOfMedia()
        {
            return (GetMediaPosition() >= GetMediaLength());
        }

        protected override bool IsFullScreen()
        {
            //if (videoWindow != null)
            //{
            //    return videoWindow.FullScreenMode == DsConstants.DsTrue;
            //}

            return false;
        }

        protected override void DoSetFullScreen(bool fullScreen)
        {
            //if (videoWindow != null)
            //{
            //    if (fullScreen)
            //    {
            //        _bakMessageDrain = videoWindow.MessageDrain;
            //        videoWindow.MessageDrain = (int)(MainThread.MainWindow.Handle);
            //        videoWindow.FullScreenMode = DsConstants.DsTrue;
            //    }
            //    else
            //    {
            //        videoWindow.FullScreenMode = OABool.False;
            //        videoWindow.MessageDrain = (int)(_bakMessageDrain);
            //        videoWindow.SetWindowForeground(DsConstants.DsTrue);

            //    }
            //}
        }

        protected override object DoGetGraphFilter()
        {
            return mediaControl;
        }

        #region Sample analisys
#if HAVE_SAMPLES

        protected DS.ISampleGrabber sampleGrabber = null;
        DsROTEntry rotEntry = null;
        Thread sampleAnalyzerThread = null;
        Queue<AudioSample> samples = new Queue<AudioSample>();
        ManualResetEvent sampleAnalyzerMustStop = new ManualResetEvent(false);

        protected void SetupAudioSampleGrabber()
        {
            // Get the graph builder
            IGraphBuilder graphBuilder = (mediaControl as IGraphBuilder);
            if (graphBuilder == null)
                return; 
            
            try
            {
                droppedSamples = 0;
                totalSamples = 1;

                // Build the sample grabber
                sampleGrabber = Activator.CreateInstance(Type.GetTypeFromCLSID(Filters.SampleGrabber, true))
                            as ISampleGrabber;
                if (sampleGrabber == null)
                    return;

                // Add it to the filter graph
                graphBuilder.AddFilter(sampleGrabber as IBaseFilter, "ProTONE_SampleGrabber");

                AMMediaType mtAudio = new AMMediaType();
                mtAudio.majorType = MediaType.Audio;
                mtAudio.subType = MediaSubType.PCM;
                mtAudio.formatPtr = IntPtr.Zero;
                
                sampleGrabber.SetMediaType(mtAudio);
                sampleGrabber.SetBufferSamples(true);
                sampleGrabber.SetOneShot(false);
                sampleGrabber.SetCallback(this, 1);

                sampleAnalyzerMustStop.Reset();

                sampleAnalyzerThread = new Thread(new ThreadStart(SampleAnalyzerLoop));
                sampleAnalyzerThread.Priority = ThreadPriority.Normal;
                sampleAnalyzerThread.Start();
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }

            rotEntry = new DsROTEntry(graphBuilder as IFilterGraph);
        }

        protected void ReleaseAudioSampleGrabber()
        {
            try
            {
                droppedSamples = 0;
                totalSamples = 1;

                sampleAnalyzerMustStop.Set(); // This will cause the thread to stop
                sampleAnalyzerThread.Join(200);

                if (sampleGrabber != null)
                {
                    (mediaControl as IGraphBuilder).RemoveFilter(sampleGrabber as IBaseFilter);

                    Marshal.ReleaseComObject(sampleGrabber);
                    sampleGrabber = null;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            if (rotEntry != null)
            {
                rotEntry.Dispose();
                rotEntry = null;
            }
        }

        // ISampleGrabberCB Members

        public int BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen)
        {
            AudioSample smp = new AudioSample();
            smp.SampleTime = SampleTime;
            smp.samples = new short[BufferLen];

            //Marshal.Copy(pBuffer, smp.samples, 0, BufferLen);

            // This is a callback from the DirectShow rendering thread.
            // We process on other thread, to make sure we don't block the rendering thread.
            //lock (_sync)
            {
                samples.Enqueue(smp);
            }

            return 0;
        }

        public int SampleCB(double SampleTime, IMediaSample pSample)
        {
            return 0; 
        }
      
        private void SampleAnalyzerLoop()
        {
            while (!sampleAnalyzerMustStop.WaitOne(1))
            {
                AudioSample smp = null;

                //Logger.LogHeavyTrace("AnalyzeSamples: loop");

                //lock (_sync)
                {
                    if (samples.Count > 0)
                    {
                        smp = samples.Dequeue();
                    }
                }

                if (smp != null)
                {
                    AnalyzeSamples(smp);
                }
                else
                {
                    Thread.Sleep(10);
                    //Logger.LogHeavyTrace("AnalyzeSamples:no samples to analyze");
                }
            }

            ResetVolumeLevels();
        }

        const int MAXSAMPLES = 250; // Number of samples to be checked

        int droppedSamples = 0;
        int totalSamples = 1;

        private void AnalyzeSamples(AudioSample smp)
        {
            if (smp == null) return;

            short[] samples = smp.samples;
            double sampleTime = smp.SampleTime;

            totalSamples++;

            double diff = sampleTime - this.MediaPosition;
            if (diff > 0 && diff < 2)
            {
                Thread.Sleep((int)(1000 * diff));
            }
            else if (Math.Abs(diff) > 0.5)
            {
                droppedSamples++;
                return; // The sample is too delayed or too early
            }

            if (totalSamples % 100 == 0)
            {
                //Logger.LogToConsole("AnalyzeSamples: dropped samples:{0} out of {1} ({2}%)",
                    //droppedSamples, totalSamples, (100 * droppedSamples) / totalSamples);
            }

            diff = sampleTime - this.MediaPosition;
            //Logger.LogToConsole("AnalyzeSamples: SampleTime:{0} adjusted diff:{1}", sampleTime, diff);

            if (samples != null)
            {
                FilterState ms = GetFilterState();

                if (samples.Length <= 0 || 
                    ms != FilterState.Running)
                    return;

                try
                {
                    double leftS = 0;
                    double rightS = 0;
                    double avgR = 0;
                    double avgL = 0;
                    double peakR = 0;
                    double peakL = 0;

                    int size = samples.GetLength(0) / 2; // Assume this is 2 channel audio
                    if (size > (samples.Length / 2))
                    {
                        size = samples.Length / 2;
                    }

                    if (size < 2)
                    {
                        return;
                    }

                    int step = (int)((double)samples.Length / (double)MAXSAMPLES);
                    double countedSamples = (int)((double)samples.Length / (double)step);

                    // Check array contents
                    for (int i = 0; i < size; i += step)
                    {
                        leftS = Math.Abs((int)samples[i]);
                        avgL += (leftS * leftS / countedSamples);

                        if (leftS > peakL)
                        {
                            peakL = leftS;
                        }
                        rightS = Math.Abs((int)samples[i + 1]);
                        avgR += (rightS * rightS / countedSamples);

                        if (rightS > peakR)
                        {
                            peakR = rightS;
                        }

                    } // for

                    VolumeAvgR = (VolumeAvgR + (int)Math.Sqrt(avgR)) / 2;
                    VolumeAvgL = (VolumeAvgL + (int)Math.Sqrt(avgL)) / 2;

                    VolumePeakR = (int)peakR;
                    VolumePeakL = (int)peakL;

                    //Logger.LogToConsole("AnalyzeSamples: L:{0} R:{0}", VolumeAvgL, VolumeAvgR);
                }
                catch(Exception ex)
                {
                    Logger.LogException(ex);
                }
            }
        }
#endif // HAVE_SAMPLES
        #endregion Sample analisys
    }

    internal class GraphNotifyWnd : NativeWindow
    {
        public event MethodInvoker FilterGraphMessage;

        private static GraphNotifyWnd _instance = new GraphNotifyWnd();

        public static GraphNotifyWnd Instance
        {
            get
            {
                return _instance;
            }
        }

        private GraphNotifyWnd()
        {
            CreateParams cp = new CreateParams();
            cp.Style = (int)WindowStyle.Disabled;
            cp.ExStyle = (int)WindowExtendedStyles.WS_EX_TRANSPARENT;
            CreateHandle(cp);
        }

        protected override void WndProc(ref Message m)
        {
            Logger.LogHeavyTrace("GraphNotifyWnd: " + m);

            if (m.Msg == (int)Messages.WM_GRAPH_EVENT &&
                FilterGraphMessage != null)
            {
                FilterGraphMessage();
                return;
            }

            base.WndProc(ref m);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal class AudioSample
    {
        public double SampleTime;
        public short[] samples;
    }
}

#endif