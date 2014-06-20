using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Core.Logging;
using System.Diagnostics;
using OPMedia.Runtime.DSP;
using OPMedia.UI.Themes;
using OPMedia.Core;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer.Screens
{
    public partial class SignalAnalysisScreen : OPMBaseControl
    {
        #region Constants and members

        const int FFT_WINDOW_SIZE = 4096;

        // VU-meter related members
        private System.Windows.Forms.Timer _tmrUpdateVUMeter = null;
        private object _vuMeterSamplesLock = new object();
        private Queue<AudioSampleData> _vuMeterSamples = new Queue<AudioSampleData>();

        // Waveform related members
        private System.Windows.Forms.Timer _tmrUpdateWaveform = null;
        private object _waveformSamplesLock = new object();
        private Queue<double> _waveformSamples = new Queue<double>();

        // Spectrogram related members
        private System.Windows.Forms.Timer _tmrUpdateSpectrogram = null;
        private object _spectrogramSamplesLock = new object();
        private Queue<double> _spectrogramSamples = new Queue<double>();

        #endregion

        #region Constructor

        public SignalAnalysisScreen()
        {
            InitializeComponent();

            MediaRenderer.DefaultInstance.AveragedAudioSampleProvided += new AudioSampleProvidedHandler(OnAveragedAudioSampleProvided);
            MediaRenderer.DefaultInstance.MomentarySampleProvided += new AudioSampleProvidedHandler(OnMomentarySampleProvided);

            _tmrUpdateVUMeter = new Timer();
            _tmrUpdateVUMeter.Interval = 100;
            _tmrUpdateVUMeter.Tick += new EventHandler(OnUpdateVUMeter);
            _tmrUpdateVUMeter.Start();

            _tmrUpdateWaveform = new Timer();
            _tmrUpdateWaveform.Interval = 100;
            _tmrUpdateWaveform.Tick += new EventHandler(OnUpdateWaveform);
            _tmrUpdateWaveform.Start();

            _tmrUpdateSpectrogram = new Timer();
            _tmrUpdateSpectrogram.Interval = 100;
            _tmrUpdateSpectrogram.Tick += new EventHandler(OnUpdateSpectrogram);
            _tmrUpdateSpectrogram.Start();
        }

        #endregion

        #region VU meter functionality

        void OnAveragedAudioSampleProvided(AudioSampleData sampleData)
        {
            MainThread.Post((c) =>
            {
                AnalyzeVUMeter(new AudioSampleData[] { sampleData });
            });
        }

        void OnUpdateVUMeter(object sender, EventArgs e)
        {
            switch(MediaRenderer.DefaultInstance.FilterState)
            {
                case FilterState.Paused:
                case FilterState.Running:
                    break;

                default:
                    AnalyzeVUMeter(null);
                    break;
            }
        }

        private void AnalyzeVUMeter(AudioSampleData[] avgSamples)
        {
            double minLogLevel = Math.Log(1);
            if (avgSamples != null && avgSamples.Length > 0)
            {
                double maxLevel = 
                    (MediaRenderer.DefaultInstance.ActualAudioFormat != null) ?
                    (1 << (MediaRenderer.DefaultInstance.ActualAudioFormat.wBitsPerSample - 1)) - 1 :
                    short.MaxValue;

                double maxLogLevel = Math.Log(maxLevel);

                double lVol = 0, rVol = 0;

                foreach (AudioSampleData sample in avgSamples)
                {
                    lVol += Math.Abs(sample.LVOL);
                    rVol += Math.Abs(sample.RVOL);
                }

                double prevL = ggLeft.Value;
                double prevR = ggLeft.Value;

                // VU meters have logarithmic scale, don't they ?
                ggLeft.Value = ggLeft.Maximum * Math.Log(lVol / avgSamples.Length) / maxLogLevel;
                ggRight.Value = ggRight.Maximum * Math.Log(rVol / avgSamples.Length) / maxLogLevel;
            }
            else
            {
                ggLeft.Value = minLogLevel;
                ggRight.Value = minLogLevel;
            }
        }

        #endregion

        #region Waveform/spectrogram functionality

        #region Common

        int _j = 0;

        void OnMomentarySampleProvided(AudioSampleData sampleData)
        {
            lock (_waveformSamplesLock)
            {
                while (_waveformSamples.Count >= FFT_WINDOW_SIZE)
                {
                    _waveformSamples.Dequeue();
                }
                _waveformSamples.Enqueue(sampleData.AvgLevel);
            }

            lock(_spectrogramSamplesLock)
            {
                while (_spectrogramSamples.Count >= FFT_WINDOW_SIZE)
                {
                    _spectrogramSamples.Dequeue();
                }
                _spectrogramSamples.Enqueue(sampleData.RmsLevel);
            }
        }

        #endregion

        #region Waveform specific

        void OnUpdateWaveform(object sender, EventArgs e)
        {
            double[] momSamplesAvgClone = null;

            try
            {
                _tmrUpdateWaveform.Stop();

                if (MediaRenderer.DefaultInstance.FilterState == Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Running)
                {
                    lock (_waveformSamplesLock)
                    {
                        momSamplesAvgClone = _waveformSamples.ToArray();
                    }
                }
            }
            catch
            {
                momSamplesAvgClone = null;
            }
            finally
            {
                AnalyzeWaveform(momSamplesAvgClone);
                _tmrUpdateWaveform.Start();
            }
        }

        private void AnalyzeWaveform(double[] data)
        {
            gpWaveform.Reset(false);
            gpSpectrogram.Reset(false);

            // For waveform we don't have a restriction on the array length
            if (data != null && data.Length > 0)
            {
                gpWaveform.AddDataRange(data, ThemeManager.ColorValidationFailed);
            }
            else
            {
                gpWaveform.Reset(true);
            }
        }

        #endregion

        #region Spectrogram specific

        void OnUpdateSpectrogram(object sender, EventArgs e)
        {
            double[] momSamplesRMSClone = null;

            try
            {
                _tmrUpdateSpectrogram.Stop();

                if (MediaRenderer.DefaultInstance.FilterState == Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Running)
                {
                    lock (_spectrogramSamplesLock)
                    {
                        if (_spectrogramSamples.Count == FFT_WINDOW_SIZE)
                        {
                            momSamplesRMSClone = _spectrogramSamples.ToArray();
                        }
                    }
                }
            }
            catch
            {
                momSamplesRMSClone = null;
            }
            finally
            {
                AnalyzeSpectrogram(momSamplesRMSClone);
                _tmrUpdateSpectrogram.Start();
            }
        }

        private void AnalyzeSpectrogram(double[] data)
        {
            gpSpectrogram.Reset(false);

            if (data != null && data.Length == FFT_WINDOW_SIZE)
            {
                double[] dataOut = new double[FFT_WINDOW_SIZE];

                Array.Clear(dataOut, 0, FFT_WINDOW_SIZE);
                FFT.Forward(data, dataOut);

                double[] dataForSpectrogram = dataOut
                    .Skip(1 /* First band represents the 'total energy' of the signal */ )
                    .Take(FFT_WINDOW_SIZE / 2 /* The spectrum is 'mirrored' across sample rate / 2 according to Nyquist theorem */ )
                    .ToArray();

                double[] dataForSpectrogram2 = new double[dataForSpectrogram.Length];

                // dataOut => data for spectrogram display
                gpSpectrogram.AddDataRange(dataForSpectrogram, ThemeManager.LinkColor);

                double max = 0;
                int idx = 0;

                for (int i = 0; i < dataForSpectrogram.Length; i++)
                {
                    if (max < dataForSpectrogram[i])
                    {
                        max = dataForSpectrogram[i];
                        idx = i;
                    }
                }

                Array.Clear(dataForSpectrogram2, 0, dataForSpectrogram2.Length);
                dataForSpectrogram2[idx] = max;

                gpSpectrogram.AddDataRange(dataForSpectrogram2, Color.Red);

                int sampleFq = MediaRenderer.DefaultInstance.ActualAudioFormat != null ?
                    MediaRenderer.DefaultInstance.ActualAudioFormat.nSamplesPerSec : 44100;

                double[] fqCenter = new double[] { ((idx + 1) * sampleFq) / FFT_WINDOW_SIZE };
            }
            else
            {
                gpSpectrogram.Reset(true);
            }
        }

        #endregion

        #endregion



    }
}
