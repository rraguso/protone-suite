#region Copyright © 2008 OPMedia Research
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	TimeScale.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Controls;
using System.Windows.Forms.Design;
using OPMedia.Runtime.ProTONE.Rendering;

using OPMedia.Runtime.ProTONE.ExtendedInfo;
using OPMedia.Core.GlobalEvents;
using LocalEventNames = OPMedia.UI.ProTONE.GlobalEvents.EventNames;
using OPMedia.Core;

using OPMedia.UI.Themes;
#endregion

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    public partial class TimeScale : OPMBaseControl
    {
        #region Controls
        OPMToolTip _tip = new UI.Controls.OPMToolTip();
        #endregion

        #region Members
        public event ValueChangedEventHandler PositionChanged = null;
        #endregion

        public bool IsOnMenuBar { get; set; }

        public Control ControlArea
        {
            get
            {
                return timeProgress;
            }
        }

        double _elapsed = 0f;
        public double ElapsedSeconds
        {
            get
            {
                return _elapsed;
            }

            set
            {
                _elapsed = value;
                UpdateTime();
            }
        }

        double _total = 0f;
        public double TotalSeconds
        {
            get
            {
                return _total;
            }

            set
            {
                _total = value;
                UpdateTime();
            }
        }

        void UpdateTime()
        {
            string sElapsed = "", sTotal = "";

            if (_elapsed >= 0)
            {
                sElapsed = string.Format("{0}", TimeSpan.FromSeconds((int)_elapsed));
            }

            if (_total > 0)
            {
                sTotal = string.Format(" ({0})", TimeSpan.FromSeconds((int)_total));
            }

            lblTime.Text = sElapsed + sTotal;

            timeProgress.Value = (timeProgress.Maximum * _elapsed) / _total;
        }

        #region Construction
        public TimeScale()
        {
            InitializeComponent();
            
            timeProgress.PositionChanged += 
                new ValueChangedEventHandler(timeProgress_PositionChanged);
            timeProgress.HoveredPositionChanged += 
                new ValueChangedEventHandler(timeProgress_HoveredPositionChanged);
        }

        public void ApplyMenuBarColors()
        {
            layoutPanel.OverrideBackColor = Color.FromKnownColor(KnownColor.Window);
            timeProgress.OverrideBackColor = Color.FromKnownColor(KnownColor.Window);
            lblTime.OverrideBackColor = Color.FromKnownColor(KnownColor.Window);
            lblTime.OverrideForeColor = ThemeManager.SelectedColor;
        }
        #endregion

        #region Event Handlers
        void timeProgress_PositionChanged(double newVal)
        {
            if (PositionChanged != null)
            {
                double seconds = _total * newVal / timeProgress.Maximum;

                int range = (int)(MediaRenderer.DefaultInstance.MediaLength / 40);
                Bookmark bmk =
                    MediaRenderer.DefaultInstance.RenderedMediaInfo.GetNearestBookmarkInRange((int)seconds, range);

                if (bmk != null)
                {
                    PositionChanged(bmk.PlaybackTime.TotalSeconds);
                }
                else
                {
                    PositionChanged(seconds);
                }
            }
        }

        void timeProgress_HoveredPositionChanged(double val)
        {
            double hoverSeconds = _total * val / timeProgress.Maximum;
            TimeSpan hoverTime = TimeSpan.FromSeconds((int)hoverSeconds);

            int range = (int)(MediaRenderer.DefaultInstance.MediaLength / 40);
            Bookmark bmk =
                MediaRenderer.DefaultInstance.RenderedMediaInfo.GetNearestBookmarkInRange((int)hoverSeconds, range);

            string tip = string.Empty;

            if (bmk != null)
            {
                tip = Translator.Translate("TXT_TIMESCALE_BOOKMARK", bmk.PlaybackTime, bmk.Title);
            }
            else
            {
                tip = Translator.Translate("TXT_TIMESCALE", hoverTime);
            }

            _tip.SetSimpleToolTip(timeProgress, tip);
        }
        #endregion

        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }

            set
            {
                base.Enabled = value;
                timeProgress.Enabled = value;
            }
        }
    }

    [DesignerCategory("code")]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class ToolStripTimeScale : ToolStripControlHost
    {
        public event ValueChangedEventHandler PositionChanged = null;

        public TimeScale TimeScale
        {
            get
            {
                return this.Control as TimeScale;
            }
        }

        public ToolStripTimeScale()
            : base(new TimeScale())
        {
            TimeScale.Height = 20;
            TimeScale.PositionChanged += new ValueChangedEventHandler(TimeScale_PositionChanged);
            TimeScale.Visible = true;
            TimeScale.IsOnMenuBar = true;

            this.BackColor = Color.FromKnownColor(KnownColor.Window);
            TimeScale.OverrideBackColor = Color.FromKnownColor(KnownColor.Window);

            TimeScale.ApplyMenuBarColors();

            TimeScale.HandleCreated += new EventHandler(HandleCreated);
            TimeScale.HandleDestroyed += new EventHandler(HandleDestroyed);
        }

        void HandleDestroyed(object sender, EventArgs e)
        {
            EventDispatch.UnregisterHandler(this);
        }

        void HandleCreated(object sender, EventArgs e)
        {
            EventDispatch.RegisterHandler(this);
        }

        [EventSink(LocalEventNames.MediaRendererClock)]
        public void OnClock()
        {
            if (!DesignMode)
            {
                TimeScale.Enabled = MediaRenderer.DefaultInstance.CanSeekMedia;
                TimeScale.ElapsedSeconds = (int)(MediaRenderer.DefaultInstance.MediaPosition);
                TimeScale.TotalSeconds = (int)(MediaRenderer.DefaultInstance.MediaLength);
            }             
        }

        void TimeScale_PositionChanged(double newVal)
        {
            if (PositionChanged != null)
            {
                PositionChanged(newVal);
            }
        }
    }
}

#region ChangeLog
#region Date: 27.02.2008			Author: Octavian Paraschiv
// File created.
#endregion
#endregion