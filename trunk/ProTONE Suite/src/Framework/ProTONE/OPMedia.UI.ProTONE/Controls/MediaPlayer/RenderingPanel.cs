using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.ProTONE.Rendering.Base;

using OPMedia.Core.Logging;
using OPMedia.Runtime.Shortcuts;
using OPMedia.UI.Themes;

using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Core.GlobalEvents;
using OPMedia.UI.ProTONE.GlobalEvents;
using OPMedia.UI.Controls;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;
using OPMedia.UI.ProTONE.Properties;

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    public partial class RenderingPanel : OPMCustomPanel
    {
        OPMToolTip _tip = new OPMToolTip();

        public event ValueChangedEventHandler PositionChanged = null;
        public event ValueChangedEventHandler VolumeChanged = null;

        public double ElapsedSeconds
        {
            get
            {
                return timeScale.ElapsedSeconds;
            }

            set
            {
                timeScale.ElapsedSeconds = value;
                playbackPanel.ElapsedSeconds = value;
            }
        }

        public double TotalSeconds
        {
            get
            {
                return timeScale.TotalSeconds;
            }

            set
            {
                timeScale.TotalSeconds = value;
                playbackPanel.TotalSeconds = value;
            }
        }

        public int ProjectedVolume
        {
            get
            {
                return volumeScale.Position;
            }

            set
            {
                volumeScale.Position = value;
            }
        }

        //public int ActualVolLeft
        //{
        //    get
        //    {
        //        return vuMeter.VolLeft;
        //    }

        //    set
        //    {
        //        vuMeter.VolLeft = value;
        //    }
        //}

        //public int ActualVolRight
        //{
        //    get
        //    {
        //        return vuMeter.VolRight;
        //    }

        //    set
        //    {
        //        vuMeter.VolRight = value;
        //    }
        //}

        public bool VolumeScaleEnabled
        {
            get
            {
                return volumeScale.Enabled;
            }

            set
            {
                volumeScale.Enabled = value;
            }
        }

        public bool TimeScaleEnabled
        {
            get
            {
                return timeScale.Enabled;
            }

            set
            {
                timeScale.Enabled = value;
            }
        }


        public bool CompactView
        {
            get
            {
                return playbackPanel.CompactView;
            }

            set
            {
                playbackPanel.CompactView = value; 
            }
        }

        public RenderingPanel() : base()
        {
            InitializeComponent();
            
            timeScale.PositionChanged += new ValueChangedEventHandler(timeScale_PositionChanged);
            volumeScale.PositionChanged += new ValueChangedEventHandler(volumeScale_PositionChanged);
            
            //this.Resize += new EventHandler(RenderingPanel_Resize);
            this.HandleCreated += new EventHandler(RenderingPanel_HandleCreated);

            if (!DesignMode)
            {
                OnPerformTranslation();
            }

            this.FontSize = FontSizes.Large;

            pbVolIcon.Image = Resources.IconAudio;
            pbTimeIcon.Image = Resources.IconTime;
        }

        //[EventSink(EventNames.KeymapChanged, EventNames.PerformTranslation)]
        public void OnPerformTranslation()
        {
            this.BorderStyle = BorderStyle.None;
            this.HasBorder = true;
        }

        void RenderingPanel_HandleCreated(object sender, EventArgs e)
        {
        }

        void volumeScale_PositionChanged(double newVal)
        {
            if (VolumeChanged != null)
            {
                VolumeChanged(newVal);
            }
        }

        void timeScale_PositionChanged(double newVal)
        {
            if (PositionChanged != null)
            {
                PositionChanged(newVal);
            }
        }

        internal void FilterStateChanged(FilterState filterState, string mediaName,
            MediaTypes mediaType)
        {
            playbackPanel.MediaName = mediaName;
            playbackPanel.FilterState = filterState;
            playbackPanel.MediaType = mediaType;
        }
    }
}
