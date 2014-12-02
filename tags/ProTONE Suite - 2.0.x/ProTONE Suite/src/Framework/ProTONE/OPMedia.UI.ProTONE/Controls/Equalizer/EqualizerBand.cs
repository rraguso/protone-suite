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
    public partial class EqualizerBand : OPMBaseControl
    {
        public event ValueChangedEventHandler LevelChanged = null;
        public event ValueChangedEventHandler FrequencyChanged = null;

        public double Level
        {
            get { return cgLevel.Value; }
            set { cgLevel.Value = value; }
        }

        public int Frequency
        {
            get { return int.Parse(txtFrequency.Text); }
            set { txtFrequency.Text = value.ToString(); }
        }

        public int BandNo
        {
            get
            {
                try
                {
                    return int.Parse(this.Tag as string);
                }
                catch { }

                return 0;
            }
        }

        public EqualizerBand()
        {
            InitializeComponent();

            txtFrequency.TextChanged += (s, e) =>
            {
                if (FrequencyChanged != null)
                {
                    FrequencyChanged(this.Frequency);
                }
            };

            cgLevel.PositionChanged += (v) =>
            {
                if (LevelChanged != null)
                {
                    LevelChanged(this.Level);
                }
            };
        }

        
    }
}
