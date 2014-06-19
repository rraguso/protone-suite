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

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer.Screens
{
    public partial class SignalAnalysisScreen : OPMBaseControl
    {
        private System.Windows.Forms.Timer _tmrUpdate = null;

        private object _avgSamplesLock = new object();
        private List<AudioSampleData> _avgSamples = new List<AudioSampleData>();

        const int FFT_WINDOW_SIZE = 4096;
        private object _momSamplesLock = new object();
        
        private Queue<double> _momSamplesAvg = new Queue<double>();
        private Queue<double> _momSamplesRMS = new Queue<double>();

        public SignalAnalysisScreen()
        {
            InitializeComponent();

            MediaRenderer.DefaultInstance.AveragedAudioSampleProvided += new AudioSampleProvidedHandler(OnAveragedAudioSampleProvided);
            MediaRenderer.DefaultInstance.MomentarySampleProvided += new AudioSampleProvidedHandler(OnMomentarySampleProvided);

            _tmrUpdate = new Timer();
            _tmrUpdate.Interval = 100;
            _tmrUpdate.Tick += new EventHandler(_tmrUpdate_Tick);
            _tmrUpdate.Start();
        }

        void OnMomentarySampleProvided(AudioSampleData sampleData)
        {
            lock (_momSamplesLock)
            {
                while (_momSamplesAvg.Count >= FFT_WINDOW_SIZE)
                {
                    _momSamplesAvg.Dequeue();
                }
                while (_momSamplesRMS.Count >= FFT_WINDOW_SIZE)
                {
                    _momSamplesRMS.Dequeue();
                }

                _momSamplesAvg.Enqueue(sampleData.AvgLevel);
                _momSamplesRMS.Enqueue(sampleData.RmsLevel);
            }
        }

        void OnAveragedAudioSampleProvided(AudioSampleData sampleData)
        {
            lock (_avgSamplesLock)
            {
                _avgSamples.Add(sampleData);
            }
        }

        void _tmrUpdate_Tick(object sender, EventArgs e)
        {
            AudioSampleData[] avgSamplesClone = null;
            double[] momSamplesAvgClone = null, momSamplesRMSClone = null;

            try
            {
                _tmrUpdate.Stop();

                if (MediaRenderer.DefaultInstance.FilterState == Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Running)
                {
                    lock (_avgSamplesLock)
                    {
                        avgSamplesClone = _avgSamples.ToArray();
                    }

                    lock (_momSamplesLock)
                    {
                        if (_momSamplesAvg.Count == FFT_WINDOW_SIZE)
                        {
                            momSamplesAvgClone = _momSamplesAvg.ToArray();
                        }
                        if (_momSamplesRMS.Count == FFT_WINDOW_SIZE)
                        {
                            momSamplesRMSClone = _momSamplesRMS.ToArray();
                        }
                    }
                }

                AnalyzeAveragedSamples(avgSamplesClone);
                AnalyzeMomentarySamples(momSamplesAvgClone, momSamplesRMSClone);
            }
            catch
            {
                avgSamplesClone = null;
                momSamplesAvgClone = null;
                momSamplesRMSClone = null;
            }
            finally
            {
                AnalyzeAveragedSamples(avgSamplesClone);
                AnalyzeMomentarySamples(momSamplesAvgClone, momSamplesRMSClone);

                _avgSamples.Clear();
                _tmrUpdate.Start();
            }
        }

        private void AnalyzeMomentarySamples(double[] momSamplesAvgClone, double[] momSamplesRMSClone)
        {
            gpWaveform.Reset(false);
            gpSpectrogram.Reset(false);

            // For waveform we don't have a restriction on the array length
            if (momSamplesAvgClone != null && momSamplesAvgClone.Length > 0)
            {
                gpWaveform.AddDataRange(momSamplesAvgClone, ThemeManager.ColorValidationFailed);
            }
            else
            {
                gpWaveform.Reset(true);
            }

            if (momSamplesRMSClone != null && momSamplesRMSClone.Length == FFT_WINDOW_SIZE)
            {
                double[] dataOut = new double[FFT_WINDOW_SIZE];

                Array.Clear(dataOut, 0, FFT_WINDOW_SIZE);
                FFT.Forward(momSamplesRMSClone, dataOut);

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

                //Array.Clear(dataForSpectrogram2, 0, dataForSpectrogram2.Length);
                //dataForSpectrogram2[idx] = max;

                ////gpSpectrogram.AddDataRange(dataForSpectrogram2, Color.Red);

                int sampleFq = MediaRenderer.DefaultInstance.ActualAudioFormat != null ?
                    MediaRenderer.DefaultInstance.ActualAudioFormat.nSamplesPerSec : 44100;

                double[] fqCenter = new double[] { ((idx + 1) * sampleFq) / FFT_WINDOW_SIZE };
            }
            else
            {
                gpSpectrogram.Reset(true);
            }
        }

        private void AnalyzeAveragedSamples(AudioSampleData[] avgSamples)
        {
            if (avgSamples != null && avgSamples.Length > 0)
            {
                double lVol = 0, rVol = 0;

                foreach (AudioSampleData sample in avgSamples)
                {
                    lVol += sample.LVOL;
                    rVol += sample.RVOL;
                }

                ggLeft.Value = lVol / avgSamples.Length;
                ggRight.Value = rVol / avgSamples.Length;

                ggLeft.Maximum = ggRight.Maximum =
                    (MediaRenderer.DefaultInstance.ActualAudioFormat != null) ?
                    (1 << (MediaRenderer.DefaultInstance.ActualAudioFormat.wBitsPerSample - 1)) - 1 :
                    short.MaxValue;
            }
            else
            {
                ggLeft.Value = 0;
                ggRight.Value = 0;
            }
        }

        

    }
}
