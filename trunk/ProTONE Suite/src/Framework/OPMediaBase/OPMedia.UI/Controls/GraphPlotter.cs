using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using OPMedia.UI.Themes;

namespace OPMedia.UI.Controls
{
    public class GraphPlotter : OPMDoubleBufferedControl
    {
        private List<double[]> _dataSets = new List<double[]>();
        private List<Color> _dataSetsColors = new List<Color>();

        public bool ShowXAxis { get; set; }
        public bool ShowYAxis { get; set; }

        public bool LogarithmicXAxis { get; set; }
        public bool LogarithmicYAxis { get; set; }

        public bool IsHistogram { get; set; }

        public double? MinVal { get; set; }
        public double? MaxVal { get; set; }

        public void Reset(bool redraw)
        {
            bool wasEmpty = (_dataSets.Count < 1);

            _dataSets.Clear();
            _dataSetsColors.Clear();

            if (redraw)
            {
                Invalidate();
            }
        }

        public void AddDataRange(double[] data, Color color)
        {
            _dataSets.Add(data);
            _dataSetsColors.Add(color);
            Invalidate();
        }

        public GraphPlotter()
        {
        }

        protected override void OnRenderGraphics(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ThemeManager.PrepareGraphics(g);

            Rectangle rc = this.ClientRectangle;
            rc.Inflate(-1, -10);

            using (Pen p = new Pen(ThemeManager.BorderColor))
            {
                for (int i = 0; i < _dataSets.Count; i++)
                {
                    DrawDataSet(g, rc, _dataSets[i], _dataSetsColors[i]);
                }

                g.DrawRectangle(p, rc);

                if (ShowXAxis)
                {
                    g.DrawLine(p,
                        rc.Left, rc.Top + rc.Height / 2,
                        rc.Right, rc.Top + rc.Height / 2);
                }

                if (ShowYAxis)
                {
                    g.DrawLine(p,
                        rc.Left + rc.Width / 2, rc.Top,
                        rc.Left + rc.Width / 2, rc.Bottom);
                }
            }
        }

        private void DrawDataSet(Graphics g, Rectangle rc, double[] data, Color color)
        {
            double min = MinVal.GetValueOrDefault();
            double max = MaxVal.GetValueOrDefault();

            foreach (double d in data)
            {
                if (min > d)
                    min = d;
                if (max < d)
                    max = d;
            }

            Point last = new Point(rc.Left, 
                (max == min) ? rc.Bottom - rc.Height / 2 :
                rc.Bottom - (int)((data[0] - min) * rc.Height / (max - min)));

            for (double i = 1; i < data.Length; i++)
            {
                try
                {
                    Point pt = Point.Empty;

                    int y =
                        (max == min) ? rc.Bottom - rc.Height / 2 :
                        rc.Bottom - (int)((data[(int)i] - min) * rc.Height / (max - min));


                    if (LogarithmicXAxis)
                    {
                        double logXDomain = Math.Abs(Math.Log10((double)1 / data.Length));
                        int x = rc.Left + (int)((logXDomain + Math.Log10(i / data.Length)) * rc.Width / logXDomain);

                        pt = new Point(x, y);
                    }
                    else
                    {
                        pt = new Point(rc.Left + (int)(i * rc.Width / data.Length), y);
                    }

                    if (IsHistogram)
                    {
                        using (Brush b = new SolidBrush(color))
                        {
                            int w = 3;
                            Rectangle rcBar = new Rectangle(pt.X, pt.Y, w, rc.Bottom - pt.Y);
                            g.FillRectangle(b, rcBar);
                        }
                    }
                    else
                    {
                        using (Pen pen = new Pen(color))
                        {
                            g.DrawLine(pen, last, pt);
                        }

                        last = pt;
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }

            }
        }
    }
}
