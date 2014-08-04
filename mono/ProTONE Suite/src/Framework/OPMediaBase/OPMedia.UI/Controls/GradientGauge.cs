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
using System.Drawing.Drawing2D;
using OPMedia.UI.Themes;
#endregion

namespace OPMedia.UI.Controls
{
    public partial class GradientGauge : ControlGauge
    {
        #region Implementation
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                ThemeManager.PrepareGraphics(g);

                Point ptMin, ptCur, ptMax;
                Point[] ptBegin = null;
                Point[] ptEnd = null;

                Color clStart1 = ThemeManager.GradientGaugeColor1;
                Color clEnd1 = ThemeManager.GradientGaugeColor2;

                Color clStart2 = ThemeManager.GradientNormalColor1;
                Color clEnd2 = ThemeManager.GradientNormalColor1;

                Brush b1H = new LinearGradientBrush(new Rectangle(0, 0, Width, Height),
                    clStart1, clEnd1, 0f);
                Brush b2H = new LinearGradientBrush(new Rectangle(0, 0, Width, Height),
                    clStart2, clEnd2, 0f);
                Brush b1V = new LinearGradientBrush(new Rectangle(0, 0, Width, Height),
                    clStart1, clEnd1, -90f);
                Brush b2V = new LinearGradientBrush(new Rectangle(0, 0, Width, Height),
                    clStart2, clEnd2, -90f);

                Pen p1, p2;

                if (_vert)
                {
                    p1 = new Pen(b1V, this.Width);
                    p2 = new Pen(b2V, this.Width);

                    ptMax = new Point(this.Width / 2, 0);
                    ptCur = new Point(this.Width / 2, (int)(this.Height * (1 - _pos / _max)));
                    ptMin = new Point(this.Width / 2, this.Height);

                    if (_showTicks)
                    {
                        ptBegin = new Point[_nrTicks];
                        ptEnd = new Point[_nrTicks];

                        for (int i = 0; i < _nrTicks; i++)
                        {
                            int offset = i * this.Height / _nrTicks;
                            ptBegin[i] = new Point(2, offset);
                            ptEnd[i] = new Point(this.Width - 3, offset);
                        }
                    }
                }
                else
                {
                    p1 = new Pen(b1H, this.Height);
                    p2 = new Pen(b2H, this.Height);
                    ptMin = new Point(0, this.Height / 2);
                    ptCur = new Point((int)(this.Width * _pos / _max), this.Height / 2);
                    ptMax = new Point(this.Width, this.Height / 2);

                    if (_showTicks)
                    {
                        ptBegin = new Point[_nrTicks];
                        ptEnd = new Point[_nrTicks];

                        for (int i = 0; i < _nrTicks; i++)
                        {
                            int offset = i * this.Width / _nrTicks;
                            ptBegin[i] = new Point(offset, 2);
                            ptEnd[i] = new Point(offset, this.Height - 3);
                        }
                    }
                }

                g.DrawLine(p1, ptMin, ptCur);
                g.DrawLine(p2, ptCur, ptMax);

                if (_showTicks && _nrTicks > 1)
                {
                    for (int i = 1; i < _nrTicks; i++)
                    {
                        Pen p3 = new Pen(Color.Black, 1);
                        g.DrawLine(p3, ptBegin[i], ptEnd[i]);
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
        #endregion
    }
}

#region ChangeLog
#region Date: 27.02.2008			Author: Octavian Paraschiv
// File created.
#endregion
#endregion