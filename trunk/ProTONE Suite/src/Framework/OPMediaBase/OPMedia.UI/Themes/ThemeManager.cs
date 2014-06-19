#region Using directives
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using System.Collections.Specialized;
using System.Configuration;
using OPMedia.UI.Controls;
using System.Reflection;
using OPMedia.Core.Logging;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.ApplicationSettings;
using System.Collections.Generic;
using OPMedia.UI.Generic;
using System.IO;

using OPMedia.Core;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Microsoft.Win32;
using System.ComponentModel;
using OPMedia.UI.Properties;

#endregion

namespace OPMedia.UI.Themes
{
    public enum FontSizes
    {
        Smallest = 0,
        Small,
        Normal,
        NormalBold,
        Large,
        VeryLarge,
    }

    public enum ColorMapElement
    {
        BorderColor = 0,
        
        GradientLTColor,
        GradientRBColor,
        GradientMColor,
        BackColor,
        ColorValidationFailed,
        WndValidColor,
        ForeColor,
        SelectedColor,
        
        TransparentColor,

        HighlightColor,

        WndTextColor,

        LinkColor,
        CheckedMenuColor,

        SpecialListColor,

        NofElements,
    }

    public static class ResourceManagerExtension
    {
        public static Bitmap GetImage(this ResourceManager resManager, string name)
        {
            Bitmap bmp = resManager.GetObject(name) as Bitmap;
            if (bmp != null)
            {
                bmp.MakeTransparent(ThemeManager.TransparentColor);
            }
            else
            {
                bmp = Resources.ImageNotFound;
            }

            return bmp;
        }
    }

    /// <summary>
    /// Class that deals with skin selection. It provides the colors and
    /// fonts that are to be used in the applications for a specified skin. 
    /// </summary>

    public static class ThemeManager
    {
        static Color[,] __colorMap = new Color[(int)ColorMapElement.NofElements, (int)ThemeEnum.NofThemes];

        #region Members
        private static Font _smallestFont = null;
        private static Font _smallFont = null;
        private static Font _normalFont = null;
        private static Font _normalBoldFont = null;
        private static Font _largeFont = null;
        private static Font _veryLargeFont = null;

        #endregion

        #region Properties

        public static Color BackColor
        { get { return ColorMap(ColorMapElement.BackColor); } }

        public static Color ForeColor
        { get { return ColorMap(ColorMapElement.ForeColor); } }

        public static Color HighlightColor
        { get { return ColorMap(ColorMapElement.HighlightColor); } }

        public static Color SelectedColor
        { get { return ColorMap(ColorMapElement.SelectedColor); } }

        public static Color BorderColor
        { get { return ColorMap(ColorMapElement.BorderColor); } }

        public static Color GradientLTColor
        { get { return ColorMap(ColorMapElement.GradientLTColor); } }

        public static Color GradientRBColor
        { get { return ColorMap(ColorMapElement.GradientRBColor); } }

        public static Color GradientMColor
        { get { return ColorMap(ColorMapElement.GradientMColor); } }

        public static Color WndValidColor
        { get { return ColorMap(ColorMapElement.WndValidColor); } }

        public static Color ColorValidationFailed
        { get { return Color.MistyRose; } }

        public static Color TransparentColor
        { get { return Color.White; } }

        public static Color WndTextColor
        { get { return ColorMap(ColorMapElement.WndTextColor); } }

        public static Color LinkColor
        { get { return ColorMap(ColorMapElement.LinkColor); } }

        public static Color CheckedMenuColor
        { get { return ColorMap(ColorMapElement.CheckedMenuColor); } }

        public static Color SpecialListColor
        { get { return ColorMap(ColorMapElement.SpecialListColor); } }


        public static Font SmallFont
        { get { return _smallFont; } }

        public static Font SmallestFont
        { get { return _smallestFont; } }

        public static Font NormalFont
        { get { return _normalFont; } }

        public static Font NormalBoldFont
        { get { return _normalBoldFont; } }

        public static Font LargeFont
        { get { return _largeFont; } }

        public static Font VeryLargeFont
        { get { return _veryLargeFont; } }

        #endregion

        #region Methods
        
        public static Font GetFontBySize(FontSizes fnSize)
        {
            switch (fnSize)
            {
                case FontSizes.Smallest:
                    return ThemeManager.SmallestFont;
                case FontSizes.Small:
                    return ThemeManager.SmallFont;
                case FontSizes.Large:
                    return ThemeManager.LargeFont;
                case FontSizes.VeryLarge:
                    return ThemeManager.VeryLargeFont;
                case FontSizes.NormalBold:
                    return ThemeManager.NormalBoldFont;
            }

            return ThemeManager.NormalFont;
        }

        public static void PrepareGraphics(Graphics g)
        {
            if (g != null)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.CompositingMode = CompositingMode.SourceOver;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            }
        }

        public static void SetDoubleBuffer(Control c)
        {
            if (c != null)
            {
                if (c.Controls != null && c.Controls.Count > 0)
                {
                    SetDoubleBufferControl(c);
                    foreach (Control child in c.Controls)
                    {
                        SetDoubleBuffer(child);
                    }
                }
                else
                {
                    SetDoubleBufferControl(c);
                }
            }
        }

        private readonly static string ThemeFontFamily = 
            SuiteConfiguration.OSVersion < SuiteConfiguration.VerWinVista ?
            "Trebuchet MS" : "Segoe UI";


        public static void RecreateFonts()
        {
            using (Label l = new Label())
            {
                l.CreateControl();
                using (Graphics g = Graphics.FromHwnd(l.Handle))
                {
                    float step = 72f / g.DpiX;
                    _smallestFont =
                        new Font(ThemeFontFamily, 9 * step, FontStyle.Regular, GraphicsUnit.Point);
                    _smallFont =
                        new Font(ThemeFontFamily, 9 * step, FontStyle.Bold, GraphicsUnit.Point);
                    _normalFont =
                        new Font(ThemeFontFamily, 11 * step, FontStyle.Regular, GraphicsUnit.Point);
                    _normalBoldFont =
                        new Font(ThemeFontFamily, 11 * step, FontStyle.Bold, GraphicsUnit.Point);
                    _largeFont =
                        new Font(ThemeFontFamily, 12 * step, FontStyle.Bold, GraphicsUnit.Point);
                    _veryLargeFont =
                        new Font(ThemeFontFamily, 15 * step, FontStyle.Bold, GraphicsUnit.Point);
                }
            }
        }

        public static void SetFont(Control ctl, FontSizes size, bool recursive = false)
        {
            try
            {
                if (ctl != null)
                {
                    if (recursive && ctl.Controls != null)
                    {
                        foreach (Control child in ctl.Controls)
                        {
                            SetFont(child, size);
                        }
                    }

                    Font f = ThemeManager.GetFontBySize(size);
                    Font newFont = new Font(f, f.Style);

                    if (newFont != null)
                    {
                        ctl.Font = newFont;
                        if (ctl is DataGridView)
                        {
                            (ctl as DataGridView).ColumnHeadersDefaultCellStyle.Font = newFont;
                            (ctl as DataGridView).RowTemplate.DefaultCellStyle.Font = newFont;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        #endregion

        #region Construction
        /// <summary>
        /// Private constructor. The class does not need to be
        /// instantiated, since all of its member are static.
        /// </summary>
        static ThemeManager()
        {
            InitColorMap();

            try
            {
                // Register assembly as translations assembly
                Translator.RegisterTranslationAssembly(typeof(ThemeManager).Assembly);

                RecreateFonts();
                SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);
            }
            catch
            {
            }
        }

        static void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            RecreateFonts();
        }

        static void OnThemeChanged(object sender, EventArgs e)
        {
            RecreateFonts();
        }

        #endregion

        #region Helper methods
        private static void SetDoubleBufferControl(Control c)
        {
            Type t = typeof(Control);
            BindingFlags all = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            
            PropertyInfo pi = t.GetProperty("DoubleBuffered", all);
            if (pi != null)
            {
                pi.SetValue(c, true, null);
            }

            ControlStyles doubleBufferStyles = ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer;

            FieldInfo fi = t.GetField("controlStyle", all);
            if (fi != null)
            {
                ControlStyles cs = (ControlStyles)fi.GetValue(c);
                if ((cs & doubleBufferStyles) != doubleBufferStyles)
                {
                    cs |= doubleBufferStyles;
                    fi.SetValue(c, cs);
                }
            }
        }
        #endregion

        private static void InitColorMap()
        {
            //---------------------------------------------------------------------------------------
            ThemeEnum te = ThemeEnum.Blue;
            ColorMap(ColorMapElement.ForeColor,         te, 030, 057, 091);
            ColorMap(ColorMapElement.BackColor,         te, 200, 216, 235);
            ColorMap(ColorMapElement.SelectedColor,     te, 169, 193, 222);
            ColorMap(ColorMapElement.WndValidColor,     te, 240, 250, 255);
            ColorMap(ColorMapElement.GradientLTColor,   te, 185, 206, 230);
            ColorMap(ColorMapElement.GradientRBColor,   te, 145, 171, 201);
            ColorMap(ColorMapElement.GradientMColor,    te, 179, 196, 216);
            ColorMap(ColorMapElement.BorderColor,       te, 092, 119, 150);
            ColorMap(ColorMapElement.HighlightColor,    te, 135, 110, 080);
            ColorMap(ColorMapElement.WndTextColor,      te, 030, 057, 091);

            ColorMap(ColorMapElement.LinkColor,         te, 018, 097, 226);
            ColorMap(ColorMapElement.CheckedMenuColor,  te, 255, 209, 024);

            ColorMap(ColorMapElement.SpecialListColor,  te, 205, 221, 240);            
            //---------------------------------------------------------------------------------------
            
            //---------------------------------------------------------------------------------------
            te = ThemeEnum.Silver;
            ColorMap(ColorMapElement.ForeColor,         te, 091, 091, 091);
            ColorMap(ColorMapElement.BackColor,         te, 235, 235, 235);
            ColorMap(ColorMapElement.SelectedColor,     te, 197, 197, 197);
            ColorMap(ColorMapElement.WndValidColor,     te, 250, 250, 250);
            ColorMap(ColorMapElement.GradientLTColor,   te, 220, 220, 220);
            ColorMap(ColorMapElement.GradientRBColor,   te, 191, 191, 191);
            ColorMap(ColorMapElement.GradientMColor,    te, 206, 206, 206);
            ColorMap(ColorMapElement.BorderColor,       te, 150, 150, 150);
            ColorMap(ColorMapElement.HighlightColor,    te, 175, 150, 120);
            ColorMap(ColorMapElement.WndTextColor,      te, 091, 091, 091);

            ColorMap(ColorMapElement.LinkColor,         te, 018, 097, 225);
            ColorMap(ColorMapElement.CheckedMenuColor,  te, 255, 209, 024);

            ColorMap(ColorMapElement.SpecialListColor,  te, 240, 240, 240);
            //---------------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------------
            te = ThemeEnum.Black;
            ColorMap(ColorMapElement.ForeColor,         te, 240, 240, 240);
            ColorMap(ColorMapElement.BackColor,         te, 120, 120, 120);
            ColorMap(ColorMapElement.SelectedColor,     te, 059, 059, 059);
            ColorMap(ColorMapElement.WndValidColor,     te, 200, 200, 200);
            ColorMap(ColorMapElement.GradientLTColor,   te, 106, 106, 106);
            ColorMap(ColorMapElement.GradientRBColor,   te, 075, 075, 075);
            ColorMap(ColorMapElement.GradientMColor,    te, 092, 092, 092);
            ColorMap(ColorMapElement.BorderColor,       te, 036, 036, 036);
            ColorMap(ColorMapElement.HighlightColor,    te, 200, 170, 150);
            ColorMap(ColorMapElement.WndTextColor,      te, 036, 036, 036);

            ColorMap(ColorMapElement.LinkColor,         te, 114, 211, 255);
            ColorMap(ColorMapElement.CheckedMenuColor,  te, 255, 209, 024);

            ColorMap(ColorMapElement.SpecialListColor,  te, 125, 125, 125);
            //---------------------------------------------------------------------------------------
        }

        private static void ColorMap(ColorMapElement cme, ThemeEnum te, int r, int g, int b)
        {
            try
            {
                __colorMap[(int)cme, (int)te] = Color.FromArgb(r, g, b);
            }
            catch { }
        }
        private static Color ColorMap(ColorMapElement cme)
        {
            try
            {
                return __colorMap[(int)cme, (int)SuiteConfiguration.SkinType];
            }
            catch 
            { 
            }

            return Color.Empty;
        }
    }
}
