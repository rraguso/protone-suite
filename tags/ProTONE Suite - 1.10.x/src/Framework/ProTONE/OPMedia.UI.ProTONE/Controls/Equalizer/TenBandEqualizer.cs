using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;

namespace OPMedia.UI.ProTONE.Controls.Equalizer
{
    public delegate void EqBandFreqChangedEventHandler(EqualizerBand band);
    public delegate void EqBandLevelChangedEventHandler(EqualizerBand band);

    public partial class TenBandEqualizer : OPMBaseControl
    {
        public event EqBandFreqChangedEventHandler EqBandFreqChanged = null;
        public event EqBandLevelChangedEventHandler EqBandLevelChanged = null;

        public double[] Levels
        {
            get
            {
                double[] levels = new double[10];
                Array.Copy(defaultLevels, levels, 10);

                foreach (Control ctl in pnlBands.Controls)
                {
                    EqualizerBand band = ctl as EqualizerBand;
                    if (band != null)
                    {
                        levels[band.BandNo] = band.Level;
                    }
                }

                return levels;
            }

            set
            {
                double[] levels = new double[10];
                Array.Copy(value, levels, 10);

                foreach (Control ctl in pnlBands.Controls)
                {
                    EqualizerBand band = ctl as EqualizerBand;
                    if (band != null)
                    {
                        band.Level = levels[band.BandNo];
                    }
                }
            }
        }

        public int[] Frequencies
        {
            get
            {
                int[] freqs = new int[10];
                Array.Copy(defaultFrequencies, freqs, 10);

                foreach (Control ctl in pnlBands.Controls)
                {
                    EqualizerBand band = ctl as EqualizerBand;
                    if (band != null)
                    {
                        freqs[band.BandNo] = band.Frequency;
                    }
                }

                return freqs;
            }

            set
            {
                int[] freqs = new int[10];
                Array.Copy(value, freqs, 10);

                foreach (Control ctl in pnlBands.Controls)
                {
                    EqualizerBand band = ctl as EqualizerBand;
                    if (band != null)
                    {
                        band.Frequency = freqs[band.BandNo];
                    }
                }
            }
        }

        static readonly int[] defaultFrequencies = 
            new int[] { 25, 50, 100, 200, 400, 800, 1600, 3200, 6400, 12800};
        
        static readonly double[] defaultLevels =
            new double[] { 5000, 5000, 5000, 5000, 5000, 5000, 5000, 5000, 5000, 5000 };

        public TenBandEqualizer()
        {
            InitializeComponent();

            foreach (Control ctl in pnlBands.Controls)
            {
                EqualizerBand band = ctl as EqualizerBand;
                if (band != null)
                {
                    band.Level = defaultLevels[band.BandNo];
                    band.Frequency = defaultFrequencies[band.BandNo];

                    band.LevelChanged += (l) =>
                    {
                        if (EqBandLevelChanged != null)
                        {
                            EqBandLevelChanged(band);
                        }
                    };

                    band.FrequencyChanged += (f) =>
                    {
                        if (EqBandFreqChanged != null)
                        {
                            EqBandFreqChanged(band);
                        }
                    };
                }
            }
        }
    }
}
