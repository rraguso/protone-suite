#region Copyright © 2008 OPMedia Research
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	ControlGauge.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Generic;
using OPMedia.UI.Controls;
using OPMedia.UI.Themes;
using System.Windows.Forms.Design;
using System.Drawing.Drawing2D;
#endregion

namespace OPMedia.UI.Controls
{
    #region Delegates
    public delegate void ValueChangedEventHandler(double val);
    #endregion

    public enum GaugeMode
    {
        Point,
        BandToStart,
        BandToEnd
    }

    public class ControlGauge : OPMDoubleBufferedControl
    {
        #region Controls
        public event ValueChangedEventHandler PositionChanged = null;
        public event ValueChangedEventHandler HoveredPositionChanged = null;
        #endregion

        #region Members

        protected GaugeMode _gaugeMode = GaugeMode.BandToStart;

        protected double _max = 10000;
        protected double _pos = 0;
        protected int _nrTicks = 20;
        protected bool _vert = false;
        protected bool _drag = false;
        protected bool _showTicks = true;

        protected double _hoverPos = 0;

        Point _lastPos = new Point();
        #endregion

        #region Properties

        [DefaultValue(GaugeMode.BandToStart)]
        public GaugeMode GaugeMode
        { get { return _gaugeMode; } set { _gaugeMode = value; Invalidate(true); } }

        public double Maximum
        { get { return _max; } set { _max = value; Invalidate(true); } }

        public double Value
        { get { return _pos; } set { UpdateValue(ref _pos, value); } }

        public bool Vertical
        {
            get { return _vert; }
            set { _vert = value; Invalidate(true); }
        }

        public new bool Enabled
        {
            get { return base.Enabled; }
            set 
            { 
                base.Enabled = value;
                if (value)
                    this.Cursor = Cursors.Hand;
                else
                    this.Cursor = Cursors.Default;
            }
        }

        public bool AllowDragging
        {
            get { return _drag; }
            set { _drag = value; Invalidate(true); }
        }

        public int NrTicks
        {
            get { return _nrTicks; }
            set { _nrTicks = value; Invalidate(true); }
        }

        public bool ShowTicks
        {
            get { return _showTicks; }
            set { _showTicks = value; Invalidate(true); }
        }

        #endregion

        #region Construction
        public ControlGauge()
        {
            this.Enabled = true;
            this.MouseUp += new MouseEventHandler(ControlGauge_MouseUp);
            this.MouseMove += new MouseEventHandler(ControlGauge_MouseMove);
            this.MouseHover += new EventHandler(ControlGauge_MouseHover);
        }
        #endregion

        #region Event Handlers
        void ControlGauge_MouseMove(object sender, MouseEventArgs e)
        {
            if (!base.Enabled)
            {
                return;
            }

            _lastPos = e.Location;

            if (_drag & e.Button == MouseButtons.Left)
            {
                ControlGauge_MouseUp(sender, e);
                return;
            }
        }

        void ControlGauge_MouseUp(object sender, MouseEventArgs e)
        {
            if (!base.Enabled)
            {
                return;
            }

            if (_vert)
            {
                _pos = _max * (1 - (float)(e.Y / (float)this.Height));
            }
            else
            {
                _pos = _max * (float)e.X / (float)this.Width;
            }

            if (_pos < 0)
                _pos = 0;
            if (_pos > _max)
                _pos = _max;

            if (PositionChanged != null)
            {
                PositionChanged(_pos);
            }

            Invalidate(true);
        }

        void ControlGauge_MouseHover(object sender, EventArgs args)
        {
            if (!base.Enabled)
            {
                return;
            }

            Point e = _lastPos;

            if (_vert)
            {
                if (e.Y < this.Location.Y ||
                    e.Y > this.Location.Y + this.Height)
                {
                    return;
                }

                _hoverPos = _max * (1 - (float)(e.Y / (float)this.Height));
            }
            else
            {
                if (e.X < this.Location.X ||
                    e.X > this.Location.X + this.Width)
                {
                    return;
                }

                _hoverPos = _max * (float)e.X / (float)this.Width;
            }

            if (HoveredPositionChanged != null)
            {
                HoveredPositionChanged(_hoverPos);
            }
        }

        #endregion

        #region Implementation
        private void UpdateValue(ref double val, double newVal)
        {
            if (newVal < 0)
            {
                newVal = 0;
            }
            if (newVal > _max)
            {
                newVal = _max;
            }

            if (val != newVal)
            {
                val = newVal;
                Invalidate(true);
            } 
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                ThemeManager.PrepareGraphics(g);

                Rectangle rcMinor, rcMajor, rcDot = Rectangle.Empty;
                Color c1 = ThemeManager.GradientNormalColor1;
                Color c2 = ThemeManager.GradientNormalColor2;
                float a;

                if (_vert)
                {
                    rcMinor = new Rectangle(0, (int)(this.Height * (1 - _pos / _max)), Width, Height);
                    rcMajor = new Rectangle(0, 0, Width, (int)(this.Height * _pos / _max));

                    rcDot = new Rectangle(0, (int)(this.Height * (1 - _pos / _max)) - 14, Width, 14);

                    a = 0f;
                }
                else
                {
                    rcMinor = new Rectangle(0, 0, (int)(this.Width * _pos / _max), Height);
                    rcMajor = new Rectangle((int)(this.Width * _pos / _max), 0,
                        (int)(this.Width * (1 - _pos / _max)), Height);

                    rcDot = new Rectangle((int)(this.Width * _pos / _max) - 7, 0, 14, Height);

                    a = 90f;
                }

                AdjustRectangle(ref rcMinor);
                AdjustRectangle(ref rcMajor);

                switch (_gaugeMode)
                {
                    case UI.Controls.GaugeMode.Point:
                        using (Brush b = new LinearGradientBrush(rcDot, c2, ThemeManager.BorderColor, a))
                        {
                            g.FillRectangle(b, rcDot);
                        }
                        break;

                    default:
                        using (Brush b = new LinearGradientBrush(rcMinor, c1, c2, a))
                        {
                            g.FillRectangle(b, rcMinor);
                        }
                        break;
                }

                if (_showTicks && _nrTicks > 1)
                {
                    Point[] ptBegin = new Point[_nrTicks];
                    Point[] ptEnd = new Point[_nrTicks];

                    for (int i = 0; i < _nrTicks; i++)
                    {
                        int offset = i * (_vert ? this.Height : this.Width) / _nrTicks;
                        ptBegin[i] = _vert ?
                            new Point(3, offset) : new Point(offset, 2);
                        ptEnd[i] = _vert ?
                            new Point(this.Width - 3, offset) : new Point(offset, this.Height - 3);
                    }

                    using (Pen p = new Pen(ThemeManager.ForeColor, 1))
                    {
                        for (int i = 1; i < _nrTicks; i++)
                        {
                            g.DrawLine(p, ptBegin[i], ptEnd[i]);
                        }
                    }
                }

                ControlPaint.DrawBorder(g, new Rectangle(0, 0, Width, Height),
                   ThemeManager.BorderColor, ButtonBorderStyle.Solid);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        public void AdjustRectangle(ref Rectangle rc)
        {
            if (rc.Height <= 0)
                rc.Height = 1;
            if (rc.Width <= 0)
                rc.Width = 1;
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ControlGauge
            // 
            this.Name = "ControlGauge";
            this.ResumeLayout(false);

        }
    }

    public class OPMProgressBar : ControlGauge
    {
        public OPMProgressBar()
            : base()
        {
            this.Enabled = false;
            this.ShowTicks = false;
        }
    }

    [DesignerCategory("code")]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class OPMToolStripProgressBar : ToolStripControlHost
    {
        public OPMProgressBar OPMProgressBar
        {
            get
            {
                return this.Control as OPMProgressBar;
            }
        }

        public double Value
        {
            get { return OPMProgressBar.Value; }
            set { OPMProgressBar.Value = value; }
        }

        public double Maximum
        {
            get { return OPMProgressBar.Maximum; }
            set { OPMProgressBar.Maximum = value; }
        }

        public OPMToolStripProgressBar()
            : base(new OPMProgressBar())
        {
        }
    }
}

