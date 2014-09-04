using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.UI.Controls;
using System.Drawing;
using System.Drawing.Drawing2D;
using OPMedia.UI.Themes;

namespace OPMedia.UI.ProTONE.Controls
{
    public class VuMeterGauge : GradientGauge
    {
        Brush _b1H, _b1V, _b2H, _b2V;

        protected override void CustomizeBrushes(ref Brush b1H, ref Brush b2H, ref Brush b1V, ref Brush b2V)
        {
            try
            {
                InternalCustomizeBrushes(ref b1H, ref b2H, ref b1V, ref b2V);
            }
            catch
            {
                base.CustomizeBrushes(ref b1H, ref b2H, ref b1V, ref b2V);
            }
        }

        public VuMeterGauge() : base()
        {
            RecreateBrushes();
            this.Resize += new EventHandler(VuMeterGauge_Resize);
        }

        void VuMeterGauge_Resize(object sender, EventArgs e)
        {
            RecreateBrushes();
        }

        private void RecreateBrushes()
        {
            if (_b1H != null)
                _b1H.Dispose();
            if (_b1V != null)
                _b1V.Dispose();
            if (_b2H != null)
                _b2H.Dispose();
            if (_b2V != null)
                _b2V.Dispose();

            _b1H = BrushHelper.GenerateVuMeterBrush(Width, Height, true);
            _b1V = BrushHelper.GenerateVuMeterBrush(Width, Height, false);
            _b2H = new SolidBrush(ThemeManager.GradientNormalColor1);
            _b2V = new SolidBrush(ThemeManager.GradientNormalColor1);
        }

        private void InternalCustomizeBrushes(ref Brush b1H, ref Brush b2H, ref Brush b1V, ref Brush b2V)
        {
            //b1H = _b1H.Clone() as Brush;
            //b1V = _b1V.Clone() as Brush;
            //b2H = _b2H.Clone() as Brush;
            //b2V = _b2V.Clone() as Brush;

            b1H = _b1H;
            b1V = _b1V;
            b2H = _b2H;
            b2V = _b2V;
        }
    }

    internal static class BrushHelper
    {
        public static Brush GenerateVuMeterBrush(int w, int h, bool horizontal)
        {
            Bitmap bmp = new Bitmap(w, h);

            if (horizontal)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    Color c = Color.Empty;
                    if (i > (int)(0.8 * w))
                        c = ThemeManager.GradientGaugeColor2;
                    else if (i > (int)(0.5 * w))
                        c = Color.Yellow;
                    else
                        c = ThemeManager.GradientGaugeColor1;

                    for (int j = 0; j < bmp.Height; j++)
                        bmp.SetPixel(i, j, c);
                }
            }
            else
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color c = Color.Empty;
                    if (j < (int)(0.2 * h))
                        c = ThemeManager.GradientGaugeColor2;
                    else if (j < (int)(0.5 * h))
                        c = Color.Yellow;
                    else
                        c = ThemeManager.GradientGaugeColor1;

                    for (int i = 0; i < bmp.Width; i++)
                        bmp.SetPixel(i, j, c);
                }
            }

            return new TextureBrush(bmp);
        }
    }
}
