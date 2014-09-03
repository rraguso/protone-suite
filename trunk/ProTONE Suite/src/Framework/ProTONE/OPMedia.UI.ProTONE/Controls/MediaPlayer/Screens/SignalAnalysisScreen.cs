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
using System.Threading;
using OPMedia.Core.Configuration;
using LocalEventNames = OPMedia.UI.ProTONE.GlobalEvents.EventNames;
using OPMedia.Core.GlobalEvents;
using OPMedia.Runtime.ProTONE.Configuration;

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer.Screens
{
    public partial class SignalAnalysisScreen : OPMBaseControl
    {
        private System.Windows.Forms.Timer _tmrUpdate = new System.Windows.Forms.Timer();

        const int BandCount = 64; // always a power of 2
        private double[] _bands = new double[BandCount];

        #region Constructor

        public SignalAnalysisScreen()
        {
            InitializeComponent();
            OnUpdateMediaScreens();

            _tmrUpdate.Interval = 10;
            _tmrUpdate.Tick += new EventHandler(_tmrUpdate_Tick);
            _tmrUpdate.Start();
        }

        [EventSink(LocalEventNames.UpdateMediaScreens)]
        public void OnUpdateMediaScreens()
        {
            bool showVU = ProTONEConfig.SignalAnalisysFunctionActive(SignalAnalisysFunction.VUMeter);
            bool showWaveform = ProTONEConfig.SignalAnalisysFunctionActive(SignalAnalisysFunction.Waveform);
            bool showSpectrogram = ProTONEConfig.SignalAnalisysFunctionActive(SignalAnalisysFunction.Spectrogram);

            ggLeft.Visible = ggRight.Visible = showVU;

            opmTableLayoutPanel1.RowStyles[0] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, showVU ? 20F : 0F);
            opmTableLayoutPanel1.RowStyles[1] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, showVU ? 20F : 0F);

            gpWaveform.Visible = showWaveform;

            gpSpectrogram.Visible = showSpectrogram;

            if (showSpectrogram && showWaveform)
            {
                opmTableLayoutPanel1.RowStyles[2] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F);
                opmTableLayoutPanel1.RowStyles[3] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F);
            }
            else if (showWaveform)
            {
                opmTableLayoutPanel1.RowStyles[2] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F);
                opmTableLayoutPanel1.RowStyles[3] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F);
            }
            else if (showSpectrogram)
            {
                opmTableLayoutPanel1.RowStyles[2] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F);
                opmTableLayoutPanel1.RowStyles[3] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F);
            }
            else
            {
                opmTableLayoutPanel1.RowStyles[2] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F);
                opmTableLayoutPanel1.RowStyles[3] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F);
            }
        }

        void _tmrUpdate_Tick(object sender, EventArgs e)
        {
            try
            {
                _tmrUpdate.Stop();

                if (ProTONEConfig.SignalAnalisysFunctionActive(SignalAnalisysFunction.VUMeter))
                {
                    AudioSampleData vuData = MediaRenderer.DefaultInstance.VuMeterData;
                    if (vuData != null)
                    {
                        ggLeft.Value = 0.5 * (ggLeft.Value + ggLeft.Maximum * vuData.LVOL);
                        ggRight.Value = 0.5 * (ggRight.Value + ggRight.Maximum * vuData.RVOL);
                    }
                    else
                    {
                        ggLeft.Value = 0;
                        ggRight.Value = 0;
                    }
                }

                if (ProTONEConfig.SignalAnalisysFunctionActive(SignalAnalisysFunction.Waveform))
                {
                    gpWaveform.Reset(false);

                    double[] waveformData = MediaRenderer.DefaultInstance.WaveformData;
                    if (waveformData != null && waveformData.Length > 0)
                    {
                        gpWaveform.MinVal = -1 * MediaRenderer.DefaultInstance.MaxLevel;
                        gpWaveform.MaxVal = MediaRenderer.DefaultInstance.MaxLevel;
                        gpWaveform.AddDataRange(waveformData, ThemeManager.LinkColor);
                    }
                    else
                    {
                        gpWaveform.Reset(true);
                    }
                }

                if (ProTONEConfig.SignalAnalisysFunctionActive(SignalAnalisysFunction.Spectrogram))
                {
                    double maxFftLevel = SpectrogramTransferFunction(MediaRenderer.DefaultInstance.MaxFFTLevel);

                    gpSpectrogram.Reset(false);
                    gpSpectrogram.MinVal = maxFftLevel / 2;
                    gpSpectrogram.MaxVal = maxFftLevel;

                    double[] spectrogramData = MediaRenderer.DefaultInstance.SpectrogramData;
                    if (spectrogramData != null && spectrogramData.Length > 0)
                    {
                        double[] spectrogramData2 = new double[spectrogramData.Length];
                        Array.Clear(spectrogramData2, 0, spectrogramData.Length);

                        double[] bands = new double[BandCount];
                        Array.Clear(bands, 0, BandCount);

                        int jBand = 0;

                        int div = spectrogramData.Length / (BandCount);

                        try
                        {
                            for (int i = 0; i < spectrogramData.Length; i++)
                            {
                                int bandPos = i % div;
                                if (i > 0 && bandPos == 0)
                                    jBand++;

                                bands[jBand] = (bands[jBand] * bandPos + spectrogramData[i]) / (bandPos + 1);
                            }

                            for (int i = 0; i < BandCount; i++)
                            {
                                bands[i] = Math.Max(0, Math.Min(maxFftLevel, SpectrogramTransferFunction(bands[i])));
                                _bands[i] = 0.5 * (_bands[i] + bands[i]);
                            }

                            gpSpectrogram.AddDataRange(_bands, Color.Transparent);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message;
                            gpSpectrogram.Reset(true);
                            Array.Clear(_bands, 0, _bands.Length);
                        }
                    }
                    else
                    {
                        gpSpectrogram.Reset(true);
                        Array.Clear(_bands, 0, _bands.Length);
                    }
                }
            }
            finally
            {
                _tmrUpdate.Start();
            }
        }

        private double SpectrogramTransferFunction(double d)
        {
            return Math.Log(d);
            //return d;
        }

        #endregion

        

    }
}
