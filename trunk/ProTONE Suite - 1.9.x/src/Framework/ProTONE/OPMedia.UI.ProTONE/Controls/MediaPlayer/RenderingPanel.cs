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

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    public partial class RenderingPanel : OPMCustomPanel
    {
        OPMToolTip _tip = new OPMToolTip();

        public event ValueChangedEventHandler PositionChanged = null;
        public event ValueChangedEventHandler VolumeChanged = null;

        private bool compactView = false;

        public double ElapsedSeconds
        {
            get
            {
                return timeScale.ElapsedSeconds;
            }

            set
            {
                timeScale.ElapsedSeconds = value;
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
                return compactView;
            }

            set
            {
                compactView = value; 
                UpdateButtons();
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
            mediaInfo.MediaName = mediaName;
            mediaInfo.FilterState = filterState;
            mediaInfo.MediaType = mediaType;
        }

        private void UpdateButtons()
        {
            if (compactView)
            {
                PlaybackButtonData[] buttonsData = new PlaybackButtonData[9];

                buttonsData[0].buttonType = PlaybackButtonType.FullScreen;
                buttonsData[1].buttonType = PlaybackButtonType.Load;
                buttonsData[2].buttonType = PlaybackButtonType.Next;
                buttonsData[3].buttonType = PlaybackButtonType.Prev;
                buttonsData[4].buttonType = PlaybackButtonType.OpenDisk;
                buttonsData[5].buttonType = PlaybackButtonType.OpenSettings;
                buttonsData[6].buttonType = PlaybackButtonType.LoopPlay;
                buttonsData[7].buttonType = PlaybackButtonType.PlaylistEnd;
                buttonsData[8].buttonType = PlaybackButtonType.ToggleShuffle;

                buttonsData[0].buttonState = PlaybackButtonState.Hidden;
                buttonsData[1].buttonState = PlaybackButtonState.Hidden;
                buttonsData[2].buttonState = PlaybackButtonState.Hidden;
                buttonsData[3].buttonState = PlaybackButtonState.Hidden;
                buttonsData[4].buttonState = PlaybackButtonState.Hidden;
                buttonsData[5].buttonState = PlaybackButtonState.Hidden;
                buttonsData[6].buttonState = PlaybackButtonState.Hidden;
                buttonsData[7].buttonState = PlaybackButtonState.Hidden;
                buttonsData[8].buttonState = PlaybackButtonState.Hidden;

                playbackPanel.SetButtonsData(buttonsData, true);
            }
            else
            {
                playbackPanel.SetDefaultButtonsData();
            }
        }
    }
}
