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

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer.Screens
{
    public partial class SignalAnalysisScreen : OPMBaseControl
    {
        private System.Windows.Forms.Timer _tmrUpdate = new System.Windows.Forms.Timer();

        #region Constructor

        public SignalAnalysisScreen()
        {
            InitializeComponent();

            _tmrUpdate.Interval = 10;
            _tmrUpdate.Tick += new EventHandler(_tmrUpdate_Tick);
            _tmrUpdate.Start();
        }

        void _tmrUpdate_Tick(object sender, EventArgs e)
        {
            try
            {
                _tmrUpdate.Stop();

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

                    gpSpectrogram.AddDataRange(spectrogramData, Color.Transparent);
                    gpSpectrogram.AddDataRange(spectrogramData2, ThemeManager.LinkColor);
                }
                else
                {
                    gpSpectrogram.Reset(true);
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
