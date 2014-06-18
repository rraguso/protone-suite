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
    public partial class VisualEffectsScreen : OPMBaseControl
    {
        private System.Windows.Forms.Timer _tmrUpdate = null;

        private object _avgSamplesLock = new object();
        private List<AudioSampleData> _avgSamples = new List<AudioSampleData>();

        const int FFT_WINDOW_SIZE = 2048;
        private object _momSamplesLock = new object();
        private Queue<double> _momSamples = new Queue<double>();

        public VisualEffectsScreen()
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
            double avg = (sampleData.LVOL + sampleData.RVOL) / 2;
            lock (_momSamplesLock)
            {
                if (_momSamples.Count < FFT_WINDOW_SIZE)
                {
                    _momSamples.Enqueue(avg);
                }
                else
                {
                    double x = _momSamples.Dequeue();
                    _momSamples.Enqueue(avg);
                }
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
            try
            {
                _tmrUpdate.Stop();

                List<AudioSampleData> samplesClone = null;
                List<double> fftSamplesClone = null;

                if (MediaRenderer.DefaultInstance.FilterState == Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Running)
                {
                    lock (_avgSamplesLock)
                    {
                        samplesClone = new List<AudioSampleData>(_avgSamples);
                        _avgSamples.Clear();
                    }

                    lock (_momSamplesLock)
                    {
                        if (_momSamples.Count == FFT_WINDOW_SIZE)
                        {
                            fftSamplesClone = new List<double>(_momSamples);
                        }
                    }
                }

                AnalyzeAveragedSamples(samplesClone);
                AnalyzeMomentarySamples(fftSamplesClone);
            }
            catch
            {
                AnalyzeAveragedSamples(null);
                AnalyzeMomentarySamples(null);
            }
            finally
            {
                _avgSamples.Clear();
                _tmrUpdate.Start();
            }
        }

        private void AnalyzeMomentarySamples(List<double> momSamples )
        {
            if (momSamples != null && momSamples.Count == FFT_WINDOW_SIZE)
            {
                double[] dataIn = momSamples.ToArray();
                double[] dataOut = new double[FFT_WINDOW_SIZE];
                Array.Clear(dataOut, 0, FFT_WINDOW_SIZE);
                FFT.Forward(dataIn, dataOut);

                // dataIn => data for waveform display
                gpWaveform.Reset();
                gpWaveform.AddDataRange(dataIn, ThemeManager.HighlightColor);

                // dataOut => data for spectrogram display
                gpSpectrogram.Reset();
                gpSpectrogram.AddDataRange(dataOut.Skip(1).Take(FFT_WINDOW_SIZE / 2).ToArray(), ThemeManager.HighlightColor);
            }
            else
            {
                gpWaveform.Reset();
                gpSpectrogram.Reset();
            }
        }

        private void AnalyzeAveragedSamples(List<AudioSampleData> avgSamples)
        {
            if (avgSamples != null && avgSamples.Count > 0)
            {
                double lVol = 0, rVol = 0;

                foreach (AudioSampleData sample in avgSamples)
                {
                    lVol += sample.LVOL;
                    rVol += sample.RVOL;
                }

                ggLeft.Value = lVol / avgSamples.Count;
                ggRight.Value = rVol / avgSamples.Count;
            }
            else
            {
                ggLeft.Value = 0;
                ggRight.Value = 0;
            }
        }

        

    }
}
