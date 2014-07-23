#region Copyright © 2008 OPMedia Research
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	ColorHelper.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
#endregion

namespace OPMedia.UI.Generic
{
    public class ColorHelper
    {
        public static string GetColorCode(Color color)
        {
            return string.Format("#{0}{1}{2}", color.R.ToString("x2"),
                color.G.ToString("x2"), color.B.ToString("x2"));
        }

        public static Int32 BGR(Color c)
        {
            Int32 v = c.R;
            v |= c.G << 8;
            v |= c.B << 16;
            return v;
        }

        public static Color CreateColorFromRGB(int red, int green, int blue)
        {
            int r = red;
            if (r > 0xff)
            {
                r = 0xff;
            }
            if (r < 0)
            {
                r = 0;
            }
            int g = green;
            if (g > 0xff)
            {
                g = 0xff;
            }
            if (g < 0)
            {
                g = 0;
            }
            int b = blue;
            if (b > 0xff)
            {
                b = 0xff;
            }
            if (b < 0)
            {
                b = 0;
            }
            return Color.FromArgb(r, g, b);
        }

        public static Color OpacityMix(Color blendColor, Color baseColor, int opacity)
        {
            int r1 = blendColor.R;
            int g1 = blendColor.G;
            int b1 = blendColor.B;
            int r2 = baseColor.R;
            int g2 = baseColor.G;
            int b2 = baseColor.B;
            int r3 = (int)((r1 * (((float)opacity) / 100f)) + (r2 * (1f - (((float)opacity) / 100f))));
            int g3 = (int)((g1 * (((float)opacity) / 100f)) + (g2 * (1f - (((float)opacity) / 100f))));
            int b3 = (int)((b1 * (((float)opacity) / 100f)) + (b2 * (1f - (((float)opacity) / 100f))));
            return CreateColorFromRGB(r3, g3, b3);
        }

        public static int OverlayMath(int ibase, int blend)
        {
            double dbase = ((double)ibase) / 255.0;
            double dblend = ((double)blend) / 255.0;
            if (dbase < 0.5)
            {
                return (int)(((2.0 * dbase) * dblend) * 255.0);
            }
            return (int)((1.0 - ((2.0 * (1.0 - dbase)) * (1.0 - dblend))) * 255.0);
        }

        public static Color OverlayMix(Color baseColor, Color blendColor, int opacity)
        {
            int r1 = baseColor.R;
            int g1 = baseColor.G;
            int b1 = baseColor.B;
            int r2 = blendColor.R;
            int g2 = blendColor.G;
            int b2 = blendColor.B;
            int r3 = OverlayMath(baseColor.R, blendColor.R);
            int g3 = OverlayMath(baseColor.G, blendColor.G);
            int b3 = OverlayMath(baseColor.B, blendColor.B);
            return OpacityMix(CreateColorFromRGB(r3, g3, b3), baseColor, opacity);
        }

        private static int SoftLightMath(int ibase, int blend)
        {
            float dbase = ((float)ibase) / 255f;
            float dblend = ((float)blend) / 255f;
            if (dblend < 0.5)
            {
                return (int)((((2f * dbase) * dblend) + (Math.Pow((double)dbase, 2.0) * (1f - (2f * dblend)))) * 255.0);
            }
            return (int)(((Math.Sqrt((double)dbase) * ((2f * dblend) - 1f)) + ((2f * dbase) * (1f - dblend))) * 255.0);
        }

        public static Color SoftLightMix(Color baseColor, Color blendColor, int opacity)
        {
            int r1 = baseColor.R;
            int g1 = baseColor.G;
            int b1 = baseColor.B;
            int r2 = blendColor.R;
            int g2 = blendColor.G;
            int b2 = blendColor.B;
            int r3 = SoftLightMath(r1, r2);
            int g3 = SoftLightMath(g1, g2);
            int b3 = SoftLightMath(b1, b2);
            return OpacityMix(CreateColorFromRGB(r3, g3, b3), baseColor, opacity);
        }

        public static Color GetContrastingColor(Color c)
        {
            var yiq = ((c.R * 299) + (c.G * 587) + (c.B * 114)) / 1000;
            return (yiq >= 128) ? Color.Black : Color.White;
        }
    }
}

#region ChangeLog
#region Date: 22.01.2008			Author: Octavian Paraschiv
// File created.
#endregion
#endregion