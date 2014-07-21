﻿using System;
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
            bool showVU = ((ProTONEConfig.SignalAnalisysFunctions & SignalAnalisysFunction.VUMeter) == SignalAnalisysFunction.VUMeter);
            ggLeft.Visible = ggRight.Visible = showVU;

            opmTableLayoutPanel1.RowStyles[0] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, showVU ? 20F : 0F);
            opmTableLayoutPanel1.RowStyles[1] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, showVU ? 20F : 0F);

            bool showWaveform = ((ProTONEConfig.SignalAnalisysFunctions & SignalAnalisysFunction.Waveform) == SignalAnalisysFunction.Waveform);
            gpWaveform.Visible = showWaveform;

            bool showSpectrogram = ((ProTONEConfig.SignalAnalisysFunctions & SignalAnalisysFunction.Spectrogram) == SignalAnalisysFunction.Spectrogram);
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

                if ((ProTONEConfig.SignalAnalisysFunctions & SignalAnalisysFunction.VUMeter) == SignalAnalisysFunction.VUMeter)
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

                if ((ProTONEConfig.SignalAnalisysFunctions & SignalAnalisysFunction.Waveform) == SignalAnalisysFunction.Waveform)
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

                if ((ProTONEConfig.SignalAnalisysFunctions & SignalAnalisysFunction.Spectrogram) == SignalAnalisysFunction.Spectrogram)
                {
                    gpSpectrogram.Reset(false);

                    double[] spectrogramData = MediaRenderer.DefaultInstance.SpectrogramData;
                    if (spectrogramData != null && spectrogramData.Length > 0)
                    {
                        double[] spectrogramData2 = new double[spectrogramData.Length];
                        Array.Clear(spectrogramData2, 0, spectrogramData.Length);

                        double max = 0;
                        int idx = 0;

                        for (int i = 0; i < spectrogramData.Length; i++)
                        {
                            if (max < spectrogramData[i])
                            {
                                max = spectrogramData[i];
                                idx = i;
                            }
                        }

                        spectrogramData2[idx] = max;

                        gpSpectrogram.AddDataRange(spectrogramData, ThemeManager.BorderColor);
                        gpSpectrogram.AddDataRange(spectrogramData2, ThemeManager.LinkColor);
                    }
                    else
                    {
                        gpSpectrogram.Reset(true);
                    }
                }
            }
            finally
            {
                _tmrUpdate.Start();
            }
        }

        #endregion

        

    }
}