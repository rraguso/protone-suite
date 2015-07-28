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

using System.Linq;
using OPMedia.Runtime.DSP;
using System.Collections.Concurrent;
using OPMedia.Runtime.ProTONE.Configuration;


namespace OPMedia.Runtime.ProTONE.Rendering.DS
{
    public abstract class DsRendererBase : StreamRenderer
#if HAVE_SAMPLES
        , ISampleGrabberCB
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

        protected DsROTEntry rotEntry = null;

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
                    int hr = mediaEvent.FreeEventParams(code, p1, p2);
                    DsError.ThrowExceptionForHR(hr);

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
            {
                int hr = mediaControl.Pause();
                DsError.ThrowExceptionForHR(hr);
            }
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

                if (rotEntry != null)
                {
                    rotEntry.Dispose();
                    rotEntry = null;
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
            int hr = videoWindow.put_Owner(renderRegion.Handle);
            DsError.ThrowExceptionForHR(hr);

            hr = videoWindow.put_MessageDrain(renderRegion.Handle);
            DsError.ThrowExceptionForHR(hr);

            hr = videoWindow.put_WindowStyle((int)(WindowStyle.Child |
                WindowStyle.ClipSiblings |
                WindowStyle.ClipChildren));
            DsError.ThrowExceptionForHR(hr);

            hr = mediaEvent.SetNotifyWindow(GraphNotifyWnd.Instance.Handle, (int)Messages.WM_GRAPH_EVENT, IntPtr.Zero);
            DsError.ThrowExceptionForHR(hr);
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
            
            int hr = videoWindow.SetWindowPosition(left, top, width, height);
            DsError.ThrowExceptionForHR(hr);

            renderRegion.ResumeLayout();
        }

        protected override void DoResumeRenderer(double fromPosition)
        {
            if (fromPosition > 0)
                SetMediaPosition(fromPosition);

            if (mediaControl != null)
            {
                int hr = mediaControl.Run();
                DsError.ThrowExceptionForHR(hr);
            }
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
                int hr = mediaPosition.get_CurrentPosition(out val);
                DsError.ThrowExceptionForHR(hr);
            }

            return val * durationScaleFactor;
        }

        protected override void SetMediaPosition(double pos)
        {
            if (mediaPosition != null)
            {
                int hr = mediaPosition.put_CurrentPosition(pos / durationScaleFactor);
                DsError.ThrowExceptionForHR(hr);
            }
        }

        protected override int GetAudioVolume()
        {
            int val = -1;
            if (isAudioAvailable)
            {
                int hr = basicAudio.get_Volume(out val);
                DsError.ThrowExceptionForHR(hr);
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

                int hr = basicAudio.put_Volume(vol);
                DsError.ThrowExceptionForHR(hr);
            }
        }

        protected override int GetAudioBalance()
        {
            int val = 0;
            if (isAudioAvailable)
            {
                int hr = basicAudio.get_Balance(out val);
                DsError.ThrowExceptionForHR(hr);
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

                int hr = basicAudio.put_Balance(b);
                DsError.ThrowExceptionForHR(hr);
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
                int hr = mediaPosition.CanSeekForward(out seekFwd);
                DsError.ThrowExceptionForHR(hr);
                
                hr = mediaPosition.CanSeekBackward(out seekBwd);
                DsError.ThrowExceptionForHR(hr);
            }

            return (seekFwd != OABool.False && seekBwd != OABool.False);
        }

        protected override BaseClasses.FilterState GetFilterState()
        {
            BaseClasses.FilterState fs = BaseClasses.FilterState.Stopped;
            if (mediaControl != null)
            {
                int hr = mediaControl.GetState(0, out fs);
                DsError.ThrowExceptionForHR(hr);
            }

            return fs;
        }

        protected override bool IsCursorVisible()
        {
            bool retVal = false;
            if (isVideoAvailable && videoWindow != null)
            {
                int hidden = (int)OABool.False;
                
                int hr = videoWindow.IsCursorHidden(out hidden);
                DsError.ThrowExceptionForHR(hr);

                retVal = (hidden == (int)OABool.False);
            }

            return retVal;
        }

        protected override void DoShowCursor(bool show)
        {
            if (isVideoAvailable && videoWindow != null)
            {
                int hidden = (show) ? (int)OABool.False : (int)OABool.True;
                int hr = videoWindow.HideCursor(hidden);
                DsError.ThrowExceptionForHR(hr);
            }
        }
        protected override void DoAdjustVideoSize(VideoSizeAdjustmentDirection direction, VideoSizeAdjustmentAction action)
        {
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

        protected ISampleGrabber sampleGrabber = null;
        protected WaveFormatEx _actualAudioFormat = null;
        protected Thread sampleAnalyzerThread = null;

        ConcurrentQueue<AudioSample> samples = new ConcurrentQueue<AudioSample>();
        ConcurrentQueue<AudioSample> samples2 = new ConcurrentQueue<AudioSample>();
        
        protected ManualResetEvent sampleAnalyzerMustStop = new ManualResetEvent(false);
        protected ManualResetEvent sampleGrabberConfigured = new ManualResetEvent(false);

        /*
        protected void InitAudioSampleGrabber()
        {
            // Get the graph builder
            IGraphBuilder graphBuilder = (mediaControl as IGraphBuilder);
            if (graphBuilder == null)
                return; 
            
            try
            {
                // Build the sample grabber
                sampleGrabber = Activator.CreateInstance(Type.GetTypeFromCLSID(Filters.SampleGrabber, true))
                    as ISampleGrabber;

                if (sampleGrabber == null)
                    return;

                // Add it to the filter graph
                int hr = graphBuilder.AddFilter(sampleGrabber as IBaseFilter, "ProTONE_SampleGrabber");
                DsError.ThrowExceptionForHR(hr);

                AMMediaType mtAudio = new AMMediaType();
                mtAudio.majorType = MediaType.Audio;
                mtAudio.subType = MediaSubType.PCM;
                mtAudio.formatPtr = IntPtr.Zero;

                _actualAudioFormat = null;

                hr = sampleGrabber.SetMediaType(mtAudio);
                DsError.ThrowExceptionForHR(hr);

                hr = sampleGrabber.SetBufferSamples(true);
                DsError.ThrowExceptionForHR(hr);

                hr = sampleGrabber.SetOneShot(false);
                DsError.ThrowExceptionForHR(hr);

                hr = sampleGrabber.SetCallback(this, 1);
                DsError.ThrowExceptionForHR(hr);

                sampleAnalyzerMustStop.Reset();
                sampleAnalyzerThread = new Thread(new ThreadStart(SampleAnalyzerLoop));
                sampleAnalyzerThread.Priority = ThreadPriority.Highest;
                sampleAnalyzerThread.Start();
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }

            rotEntry = new DsROTEntry(graphBuilder as IFilterGraph);
        }*/

        protected void InitAudioSampleGrabber_v2()
        {
            // Get the graph builder
            IGraphBuilder graphBuilder = (mediaControl as IGraphBuilder);
            if (graphBuilder == null)
                return;

            try
            {
                // Build the sample grabber
                sampleGrabber = Activator.CreateInstance(Type.GetTypeFromCLSID(Filters.SampleGrabber, true))
                    as ISampleGrabber;

                if (sampleGrabber == null)
                    return;

                // Add it to the filter graph
                int hr = graphBuilder.AddFilter(sampleGrabber as IBaseFilter, "ProTONE_SampleGrabber_v2");
                DsError.ThrowExceptionForHR(hr);

                IBaseFilter ffdAudioDecoder = null;

                IPin ffdAudioDecoderOutput = null;
                IPin soundDeviceInput = null;
                IPin sampleGrabberInput = null;
                IPin sampleGrabberOutput = null;
                IntPtr pSoundDeviceInput = IntPtr.Zero;

                // When using FFDShow, typically we'll find
                // a ffdshow Audio Decoder connected to the sound device filter
                // 
                // i.e. [ffdshow Audio Decoder] --> [DirectSound Device]
                //
                // Our audio sample grabber supports only PCM sample input and output.
                // Its entire processing is based on this assumption.
                // 
                // Thus need to insert the audio sample grabber between the ffdshow Audio Decoder and the sound device
                // because this is the only place where we can find PCM samples. The sound device only accepts PCM.
                //
                // So we need to turn this graph:
                //
                // .. -->[ffdshow Audio Decoder]-->[DirectSound Device] 
                //
                // into this:
                //
                // .. -->[ffdshow Audio Decoder]-->[Sample grabber]-->[DirectSound Device] 
                //
                // Actions to do to achieve the graph change:
                //
                // 1. Locate the ffdshow Audio Decoder in the graph
                // 2. Find its output pin and the pin that it's connected to
                // 3. Locate the input and output pins of sample grabber
                // 4. Disconnect the ffdshow Audio Decoder and its correspondent (sound device input pin)
                // 5. Connect the ffdshow Audio Decoder to sample grabber input
                // 6. Connect the sample grabber output to sound device input
                // that's all.

                // --------------
                // 1. Locate the ffdshow Audio Decoder in the graph
                hr = graphBuilder.FindFilterByName("ffdshow Audio Decoder", out ffdAudioDecoder);
                DsError.ThrowExceptionForHR(hr);

                // 2. Find its output pin and the pin that it's connected to
                hr = ffdAudioDecoder.FindPin("Out", out ffdAudioDecoderOutput);
                DsError.ThrowExceptionForHR(hr);

                hr = ffdAudioDecoderOutput.ConnectedTo(out pSoundDeviceInput);
                DsError.ThrowExceptionForHR(hr);

                soundDeviceInput = new DSPin(pSoundDeviceInput).Value;

                // 3. Locate the input and output pins of sample grabber
                hr = (sampleGrabber as IBaseFilter).FindPin("In", out sampleGrabberInput);
                DsError.ThrowExceptionForHR(hr);

                hr = (sampleGrabber as IBaseFilter).FindPin("Out", out sampleGrabberOutput);
                DsError.ThrowExceptionForHR(hr);

                // 4. Disconnect the ffdshow Audio Decoder and its correspondent (sound device input pin)
                hr = ffdAudioDecoderOutput.Disconnect();
                DsError.ThrowExceptionForHR(hr);

                hr = soundDeviceInput.Disconnect();
                DsError.ThrowExceptionForHR(hr);

                // 5. Connect the ffdshow Audio Decoder to sample grabber input
                hr = graphBuilder.Connect(ffdAudioDecoderOutput, sampleGrabberInput);
                DsError.ThrowExceptionForHR(hr);

                // 6. Connect the sample grabber output to sound device input
                hr = graphBuilder.Connect(sampleGrabberOutput, soundDeviceInput);
                DsError.ThrowExceptionForHR(hr);


                AMMediaType mtAudio = new AMMediaType();
                mtAudio.majorType = MediaType.Audio;
                mtAudio.subType = MediaSubType.PCM;
                mtAudio.formatPtr = IntPtr.Zero;

                _actualAudioFormat = null;

                sampleGrabber.SetMediaType(mtAudio);
                sampleGrabber.SetBufferSamples(true);
                sampleGrabber.SetOneShot(false);
                sampleGrabber.SetCallback(this, 1);

                sampleAnalyzerMustStop.Reset();
                sampleAnalyzerThread = new Thread(new ThreadStart(SampleAnalyzerLoop));
                sampleAnalyzerThread.Priority = ThreadPriority.Highest;
                sampleAnalyzerThread.Start();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            rotEntry = new DsROTEntry(graphBuilder as IFilterGraph);
        }

        protected void CompleteAudioSampleGrabberIntialization()
        {
            _actualAudioFormat = null;
            if (sampleGrabber != null)
            {
                AMMediaType mtAudio = new AMMediaType();
                if (HRESULT.SUCCEEDED(sampleGrabber.GetConnectedMediaType(mtAudio)))
                {
                    _actualAudioFormat = (WaveFormatEx)Marshal.PtrToStructure(mtAudio.formatPtr, typeof(WaveFormatEx));

                    const int WAVEFORM_WNDSIZEFACTOR = 128;
                    const int VU_WNDSIZEFACTOR = 4096;
                    const int FFT_WNDSIZEFACTOR = 16;

                    int freq =
                        (MediaRenderer.DefaultInstance.ActualAudioFormat == null) ? 44100 :
                        MediaRenderer.DefaultInstance.ActualAudioFormat.nSamplesPerSec;

                    try
                    {
                        int k1 = 0, k2 = 0, k3 = 0;

                        while (freq / (1 << k1) > WAVEFORM_WNDSIZEFACTOR)
                            k1++;
                        while (freq / (1 << k2) > FFT_WNDSIZEFACTOR)
                            k2++;
                        while (freq / (1 << k3) > VU_WNDSIZEFACTOR)
                            k3++;

                        _waveformWindowSize = (1 << k1);
                        _fftWindowSize = (1 << k2);
                        _vuMeterWindowSize = (1 << k3);

                        _maxLevel =
                            (MediaRenderer.DefaultInstance.ActualAudioFormat != null) ?
                            (1 << (MediaRenderer.DefaultInstance.ActualAudioFormat.wBitsPerSample - 1)) - 1 :
                            short.MaxValue;
                    }
                    catch
                    {
                        _vuMeterWindowSize = 64;
                        _waveformWindowSize = 512;
                        _fftWindowSize = 4096;
                        _maxLevel = short.MaxValue;
                    }
                    finally
                    {
                        _maxLogLevel = Math.Log(_maxLevel);
                    }

                    sampleGrabberConfigured.Set();
                    return;
                }
            }
        }

        protected override WaveFormatEx DoGetActualAudioFormat()
        {
            return _actualAudioFormat;
        }

        protected void ReleaseAudioSampleGrabber()
        {
            try
            {
                if (sampleAnalyzerMustStop != null)
                    sampleAnalyzerMustStop.Set(); // This will cause the thread to stop

                if (sampleAnalyzerThread != null)
                    sampleAnalyzerThread.Join(200);

                if (sampleGrabber != null)
                {
                    int hr = (mediaControl as IGraphBuilder).RemoveFilter(sampleGrabber as IBaseFilter);
                    DsError.ThrowExceptionForHR(hr);

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

            lock (_vuLock)
            {
                _vuMeterData = null;
            }
            lock (_waveformLock)
            {
                _waveformData = null;
            }
            lock (_spectrogramLock)
            {
                _spectrogramData = null;
            }

            _actualAudioFormat = null;
            sampleGrabberConfigured.Reset();
        }

        // ISampleGrabberCB Members

        public int BufferCB(double sampleTime, IntPtr pBuffer, int bufferLen)
        {
            if (ProTONEConfig.IsSignalAnalisysActive())
            {
                try
                {
                    if (sampleGrabberConfigured.WaitOne(0) && _actualAudioFormat != null)
                    {
                        const int fraction = 128;

                        byte[] allBytes = new byte[bufferLen];
                        Marshal.Copy(pBuffer, allBytes, 0, bufferLen);

                        int pos = 0;

                        double chunkTimeLen = (double)fraction / (double)_actualAudioFormat.nSamplesPerSec;
                        int chunkSize = fraction * _actualAudioFormat.nBlockAlign;
                        int i = 0;

                        do
                        {
                            int size = Math.Min(chunkSize, bufferLen - pos);

                            AudioSample smp = new AudioSample();
                            smp.RawSamples = new byte[size];
                            smp.SampleTime = sampleTime + i * chunkTimeLen;

                            Array.Copy(allBytes, pos, smp.RawSamples, 0, size);

                            samples.Enqueue(smp);

                            pos += size;
                            i++;
                        }
                        while (pos < bufferLen);
                    }
                }
                catch { }
            }

            return 0;
        }

        public int SampleCB(double SampleTime, IntPtr pSample)
        {
            return 0; 
        }

        protected void SampleAnalyzerLoop()
        {
            while (sampleAnalyzerMustStop.WaitOne(0) == false)
            {
                if (ProTONEConfig.IsSignalAnalisysActive())
                {
                    AudioSample smp = null;
                    if (samples.TryDequeue(out smp) && smp != null)
                        ExtractSamples(smp);

                    Thread.Yield();
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
        }

        private ConcurrentQueue<AudioSampleData> _sampleData = new ConcurrentQueue<AudioSampleData>();
        private int _gatheredSamples = 0;

        private void ExtractSamples(AudioSample smp)
        {
            if (smp == null || _actualAudioFormat == null || mediaPosition == null)
                return;

            double mediaTime = 0;
            mediaPosition.get_CurrentPosition(out mediaTime);

            double delay = smp.SampleTime - mediaTime;

            // Sync the sample. 
            // Use extended sleep since Thread.Sleep is too low-resolution.
            //ThreadScheduler.SleepEx(delay);

            if (delay > 0 && delay < 1)
                Thread.Sleep(TimeSpan.FromSeconds(delay));

            FilterState ms = GetFilterState();

            if (smp.RawSamples.Length <= 0 || ms != FilterState.Running || _actualAudioFormat == null)
                return;

            int bytesPerChannel = _actualAudioFormat.wBitsPerSample / 8;
            int totalChannels = _actualAudioFormat.nChannels;
            int totalChannelsInArray = Math.Min(2, totalChannels);

            int i = 0;
            while (i < smp.RawSamples.Length)
            {
                double[] channels = new double[totalChannelsInArray];
                Array.Clear(channels, 0, totalChannelsInArray);

                int j = 0;
                while (j < totalChannelsInArray)
                {
                    int k = 0;
                    while (k < bytesPerChannel)
                    {
                        if (bytesPerChannel <= 2)
                            channels[j] += (short)(smp.RawSamples[i] << (8 * k));
                        else
                            channels[j] += (int)(smp.RawSamples[i] << (8 * k));

                        i++;
                        k++;
                    }

                    j++;
                }

                if (channels.Length >= 2)
                _sampleData.Enqueue(new AudioSampleData((double)channels[0], (double)channels[1]));
                else
                    _sampleData.Enqueue(new AudioSampleData((double)channels[0], 0));
                
                _gatheredSamples++;
                if (_gatheredSamples % _waveformWindowSize == 0)
                {
                    if (ProTONEConfig.SignalAnalisysFunctionActive(SignalAnalisysFunction.VUMeter) ||
                        ProTONEConfig.SignalAnalisysFunctionActive(SignalAnalisysFunction.Waveform))
                    {
                        AnalyzeWaveform(_sampleData.Skip(_sampleData.Count - _waveformWindowSize).Take(_waveformWindowSize).ToArray(),
                            smp.SampleTime);
                    }
                }

                Thread.Yield();
            }

            AudioSampleData lostSample = null;
            while (_sampleData.Count > _fftWindowSize)
                _sampleData.TryDequeue(out lostSample);

            if (ProTONEConfig.SignalAnalisysFunctionActive(SignalAnalisysFunction.Spectrogram))
            {
                AnalyzeFFT(_sampleData.ToArray());
            }

            Thread.Yield();
        }

        private void AnalyzeWaveform(AudioSampleData[] data, double sampleTime)
        {
            double lVal = 0, rVal = 0;
            double[] dataWaveform = new double[data.Length];

            int i = 0;
            for (i = 0; i < data.Length; i++)
            {
                double absL = Math.Abs(data[i].LVOL);
                double absR = Math.Abs(data[i].RVOL);

                if (lVal < absL)
                    lVal = absL;
                if (rVal < absR)
                    rVal = absR;

                dataWaveform[i] = data[i].AvgLevel;

                if (i % 32 == 0)
                {
                    lock (_vuLock)
                    {
                        //_vuMeterData = new AudioSampleData(
                          //  Math.Log(0.707 * lVal) / _maxLogLevel,
                            //Math.Log(0.707 * rVal) / _maxLogLevel);
                        
                        _vuMeterData = new AudioSampleData(
                            0.707 * lVal / _maxLevel,
                            0.707 * rVal / _maxLevel);

                        //_vuMeterData = new AudioSampleData(
                          //  Math.Sqrt(lVal / data.Length) / _maxLevel,
                            //Math.Sqrt(rVal / data.Length) / _maxLevel);
                    }

                    lVal = rVal = 0;
                }
            }

            lock (_waveformLock)
            {
                _waveformData = dataWaveform;
            }
        }

        private void AnalyzeFFT(AudioSampleData[] data)
        {
            if (data.Length == _fftWindowSize)
            {
                double[] dataIn = new double[data.Length];
                double[] dataOut = new double[data.Length];
                
                for (int i = 0; i < data.Length; i++)
                    dataIn[i] = data[i].RmsLevel;

                NAudioFFT.Forward(dataIn, dataOut);

                lock (_spectrogramLock)
                {
                    _spectrogramData = dataOut
                        .Skip(1 /* First band represents the 'total energy' of the signal */ )
                        .Take(_fftWindowSize / 2 /* The spectrum is 'mirrored' horizontally around the sample rate / 2 according to Nyquist theorem */ )
                        .ToArray();
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

    public class DsCustomRenderer : DsRendererBase
    {
        protected override void DoStartRenderer()
        {
            DoStartRendererWithHint(DvdRenderingStartHint.Beginning);
        }

        protected override void DoStopInternal(object state)
        {
            IFilterGraph graph = mediaControl as IFilterGraph;
            if (graph != null)
            {
                int hr = mediaControl.Stop();
                DsError.ThrowExceptionForHR(hr);

                IEnumFilters pEnum = null;
                if (COMHelper.SUCCEEDED(graph.EnumFilters(out pEnum)) && pEnum != null)
                {
                    List<IBaseFilter> allFilters = new List<IBaseFilter>();

                    IBaseFilter[] aFilters = new IBaseFilter[1];
                    while (COMHelper.S_OK == pEnum.Next(1, aFilters, IntPtr.Zero))
                    {
                        allFilters.Add(aFilters[0]);
                    }
                    Marshal.ReleaseComObject(pEnum);

                    foreach (var f in allFilters)
                    {
                        if (f != null)
                        {
                            graph.RemoveFilter(f);
                        }
                    }
                }
            }

            base.DoStopInternal(state);
        }

        protected override void HandleGraphEvent(EventCode code, int p1, int p2)
        {
            Logger.LogHeavyTrace("GraphEvent: {0} : {1} : {2}", code, p1, p2);
        }

        protected override double GetDurationScaleFactor()
        {
            return 1;
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
    }

    [StructLayout(LayoutKind.Sequential)]
    internal class AudioSample
    {
        public double SampleTime;
        public byte[] RawSamples;
    }
}

#endif