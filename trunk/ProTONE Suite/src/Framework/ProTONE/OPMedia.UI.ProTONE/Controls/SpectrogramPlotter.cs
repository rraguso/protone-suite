using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.UI.ProTONE.Controls.MediaPlayer.Screens;

namespace OPMedia.UI.ProTONE.Controls
{
    public partial class SpectrogramPlotter : GraphPlotter
    {
        Brush _b;

        public SpectrogramPlotter() : base()
        {
            RecreateBrush();
            this.Resize += new EventHandler(SpectrogramPlotter_Resize);
        }

        void SpectrogramPlotter_Resize(object sender, EventArgs e)
        {
            RecreateBrush();
        }

        private void RecreateBrush()
        {
            if (_b != null)
                _b.Dispose();

            _b = BrushHelper.GenerateVuMeterBrush(this.Width / SignalAnalysisScreen.BandCount, this.Height, false);
        }

        protected override void DrawCustomHistoBar(Graphics g, Rectangle rc, int w, Point pt)
        {
            Rectangle rcBar = new Rectangle(pt.X - w, pt.Y, w, rc.Bottom - pt.Y);
            g.FillRectangle(_b, rcBar);
        }
    }
}
