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
        BackColor,
        ForeColor,
        GradientNormalColor1,
        GradientNormalColor2,
        GradientHoverColor1,
        GradientHoverColor2,
        GradientFocusColor1,
        GradientFocusColor2,
        GradientFocusHoverColor1,
        GradientFocusHoverColor2,
        FocusBorderColor,
        SelectedTextColor,

        CaptionBarColor1,
        CaptionBarColor2,

        CaptionButtonColor1,
        CaptionButtonColor2,
        CaptionButtonRedColor1,
        CaptionButtonRedColor2,

        ColorValidationFailed,
        WndValidColor,
        SelectedColor,
        
        TransparentColor,

        HighlightColor,

        WndTextColor,

        LinkColor,
        CheckedMenuColor,

        CornerSize,
        FormBorderWidth,

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
       
          
        public static Color GradientNormalColor1
        { get { return ColorMap(ColorMapElement.GradientNormalColor1); } }
       
        public static Color GradientNormalColor2
        { get { return ColorMap(ColorMapElement.GradientNormalColor2); } }
       
        public static Color GradientHoverColor1
        { get { return ColorMap(ColorMapElement.GradientHoverColor1); } }
       
        public static Color GradientHoverColor2
        { get { return ColorMap(ColorMapElement.GradientHoverColor2); } }
       
        public static Color GradientFocusColor1
        { get { return ColorMap(ColorMapElement.GradientFocusColor1); } }
       
        public static Color GradientFocusColor2
        { get { return ColorMap(ColorMapElement.GradientFocusColor2); } }

        public static Color GradientFocusHoverColor1
        { get { return ColorMap(ColorMapElement.GradientFocusHoverColor1); } }

        public static Color GradientFocusHoverColor2
        { get { return ColorMap(ColorMapElement.GradientFocusHoverColor2); } }

        public static Color FocusBorderColor
        { get { return ColorMap(ColorMapElement.FocusBorderColor); } }
       

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

        public static int CornerSize
        { get { return ColorMap(ColorMapElement.CornerSize).R & 0x0F; } }

        public static int FormCornerSize
        { 
            get 
            {
                if (CornerSize > 0)
                    return CornerSize + FormBorderWidth;

                return 0;
            } 
        }

        public static int FormBorderWidth
        { get { return ColorMap(ColorMapElement.FormBorderWidth).R & 0x0F; } }
        
        public static Color CaptionBarColor1
        { get { return ColorMap(ColorMapElement.CaptionBarColor1); } }

        public static Color CaptionBarColor2
        { get { return ColorMap(ColorMapElement.CaptionBarColor2); } }

        public static Color CaptionButtonColor1
        { get { return ColorMap(ColorMapElement.CaptionButtonColor1); } }

        public static Color CaptionButtonColor2
        { get { return ColorMap(ColorMapElement.CaptionButtonColor2); } }


        public static Color CaptionButtonRedColor1
        { get { return ColorMap(ColorMapElement.CaptionButtonRedColor1); } }

        public static Color CaptionButtonRedColor2
        { get { return ColorMap(ColorMapElement.CaptionButtonRedColor2); } }

        public static Color SelectedTextColor
        { get { return ColorMap(ColorMapElement.SelectedTextColor); } }


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
            ThemeEnum te = ThemeEnum.Metro;
            ColorMap(te, 000, 000, 000, ColorMapElement.CornerSize);
            ColorMap(te, 002, 000, 000, ColorMapElement.FormBorderWidth);

            ColorMap(te, 150, 150, 150, ColorMapElement.BorderColor);
            ColorMap(te, 000, 000, 000, ColorMapElement.ForeColor);
            ColorMap(te, 252, 252, 252, ColorMapElement.BackColor);
            
            ColorMap(te, 224, 227, 206, ColorMapElement.GradientNormalColor1);
            ColorMap(te, 224, 227, 206, ColorMapElement.GradientNormalColor2);
           
            ColorMap(te, 159, 207, 255, ColorMapElement.GradientHoverColor1);
            ColorMap(te, 159, 207, 255, ColorMapElement.GradientHoverColor2);
            
            ColorMap(te, 224, 227, 206, ColorMapElement.GradientFocusColor1);
            ColorMap(te, 224, 227, 206, ColorMapElement.GradientFocusColor2);

            ColorMap(te, 170, 220, 255, ColorMapElement.GradientFocusHoverColor1);
            ColorMap(te, 170, 220, 255, ColorMapElement.GradientFocusHoverColor2);

            ColorMap(te, 051, 153, 255, ColorMapElement.FocusBorderColor);
            ColorMap(te, 000, 000, 000, ColorMapElement.SelectedTextColor);

            ColorMap(te, 200, 200, 200, ColorMapElement.CaptionBarColor1);
            ColorMap(te, 200, 200, 200, ColorMapElement.CaptionBarColor2);
            ColorMap(te, 224, 227, 206, ColorMapElement.CaptionButtonColor1);
            ColorMap(te, 224, 227, 206, ColorMapElement.CaptionButtonColor2);
            ColorMap(te, 225, 100, 100, ColorMapElement.CaptionButtonRedColor1);
            ColorMap(te, 225, 100, 100, ColorMapElement.CaptionButtonRedColor2);

            // Not yet validated
            ColorMap(te, 159, 207, 255, ColorMapElement.SelectedColor);
            ColorMap(te, 255, 255, 255, ColorMapElement.WndValidColor);
            ColorMap(te, 010, 110, 080, ColorMapElement.HighlightColor);
            ColorMap(te, 000, 000, 000, ColorMapElement.WndTextColor);
            ColorMap(te, 084, 186, 201, ColorMapElement.LinkColor);
            ColorMap(te, 255, 209, 024, ColorMapElement.CheckedMenuColor);
            //---------------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------------
            te = ThemeEnum.Blue;
            ColorMap(te, 003, 000, 000, ColorMapElement.CornerSize);
            ColorMap(te, 002, 000, 000, ColorMapElement.FormBorderWidth);
            ColorMap(te, 070, 085, 110, ColorMapElement.BorderColor);
            ColorMap(te, 030, 055, 090, ColorMapElement.ForeColor);
            ColorMap(te, 205, 220, 240, ColorMapElement.BackColor);
            ColorMap(te, 185, 205, 230, ColorMapElement.GradientNormalColor1);
            ColorMap(te, 165, 185, 210, ColorMapElement.GradientNormalColor2);
            ColorMap(te, 200, 220, 245, ColorMapElement.GradientHoverColor1);
            ColorMap(te, 180, 200, 230, ColorMapElement.GradientHoverColor2);
            ColorMap(te, 200, 220, 245, ColorMapElement.GradientFocusColor1);
            ColorMap(te, 180, 200, 230, ColorMapElement.GradientFocusColor2);
            ColorMap(te, 205, 225, 250, ColorMapElement.GradientFocusHoverColor1);
            ColorMap(te, 185, 205, 235, ColorMapElement.GradientFocusHoverColor2);
            ColorMap(te, 040, 055, 080, ColorMapElement.FocusBorderColor);
            ColorMap(te, 030, 055, 090, ColorMapElement.SelectedTextColor);

            ColorMap(te, 185, 205, 230, ColorMapElement.CaptionBarColor1);
            ColorMap(te, 165, 185, 210, ColorMapElement.CaptionBarColor2);
            ColorMap(te, 205, 220, 240, ColorMapElement.CaptionButtonColor1);
            ColorMap(te, 140, 170, 215, ColorMapElement.CaptionButtonColor2);
            ColorMap(te, 220, 160, 160, ColorMapElement.CaptionButtonRedColor1);
            ColorMap(te, 230, 050, 020, ColorMapElement.CaptionButtonRedColor2);

            // Not yet validated
            ColorMap(te, 169, 193, 222, ColorMapElement.SelectedColor);
            ColorMap(te, 240, 250, 255, ColorMapElement.WndValidColor);
            ColorMap(te, 010, 110, 080, ColorMapElement.HighlightColor);
            ColorMap(te, 030, 057, 091, ColorMapElement.WndTextColor);
            ColorMap(te, 018, 097, 226, ColorMapElement.LinkColor);
            ColorMap(te, 255, 209, 024, ColorMapElement.CheckedMenuColor);
            //---------------------------------------------------------------------------------------
            
            //---------------------------------------------------------------------------------------
            te = ThemeEnum.Silver;
            ColorMap(te, 003, 000, 000, ColorMapElement.CornerSize);
            ColorMap(te, 002, 000, 000, ColorMapElement.FormBorderWidth);
            ColorMap(te, 075, 075, 075, ColorMapElement.BorderColor);
            ColorMap(te, 090, 090, 090, ColorMapElement.ForeColor);
            ColorMap(te, 235, 235, 235, ColorMapElement.BackColor);
            ColorMap(te, 220, 220, 220, ColorMapElement.GradientNormalColor1);
            ColorMap(te, 190, 190, 190, ColorMapElement.GradientNormalColor2);
            ColorMap(te, 235, 235, 235, ColorMapElement.GradientHoverColor1);
            ColorMap(te, 215, 215, 215, ColorMapElement.GradientHoverColor2);
            ColorMap(te, 235, 235, 235, ColorMapElement.GradientFocusColor1);
            ColorMap(te, 215, 215, 215, ColorMapElement.GradientFocusColor2);
            ColorMap(te, 240, 240, 240, ColorMapElement.GradientFocusHoverColor1);
            ColorMap(te, 220, 220, 220, ColorMapElement.GradientFocusHoverColor2);
            ColorMap(te, 045, 045, 045, ColorMapElement.FocusBorderColor);
            ColorMap(te, 090, 090, 090, ColorMapElement.SelectedTextColor);

            ColorMap(te, 220, 220, 220, ColorMapElement.CaptionBarColor1);
            ColorMap(te, 190, 190, 190, ColorMapElement.CaptionBarColor2);
            ColorMap(te, 235, 235, 235, ColorMapElement.CaptionButtonColor1);
            ColorMap(te, 150, 150, 150, ColorMapElement.CaptionButtonColor2);
            ColorMap(te, 220, 160, 160, ColorMapElement.CaptionButtonRedColor1);
            ColorMap(te, 230, 050, 020, ColorMapElement.CaptionButtonRedColor2);


            // Not yet validated
            ColorMap(te, 197, 197, 197, ColorMapElement.SelectedColor);
            ColorMap(te, 250, 250, 250, ColorMapElement.WndValidColor);
            ColorMap(te, 175, 150, 120, ColorMapElement.HighlightColor);
            ColorMap(te, 091, 091, 091, ColorMapElement.WndTextColor);
            ColorMap(te, 018, 097, 225, ColorMapElement.LinkColor);
            ColorMap(te, 255, 209, 024, ColorMapElement.CheckedMenuColor);
            //---------------------------------------------------------------------------------------
            
            //---------------------------------------------------------------------------------------
            te = ThemeEnum.Black;
            ColorMap(te, 003, 000, 000, ColorMapElement.CornerSize);
            ColorMap(te, 002, 000, 000, ColorMapElement.FormBorderWidth);
            ColorMap(te, 035, 035, 035, ColorMapElement.BorderColor);
            ColorMap(te, 240, 240, 240, ColorMapElement.ForeColor);
            ColorMap(te, 120, 120, 120, ColorMapElement.BackColor);
            ColorMap(te, 100, 100, 100, ColorMapElement.GradientNormalColor1);
            ColorMap(te, 080, 080, 080, ColorMapElement.GradientNormalColor2);
            ColorMap(te, 115, 115, 115, ColorMapElement.GradientHoverColor1);
            ColorMap(te, 092, 092, 095, ColorMapElement.GradientHoverColor2);
            ColorMap(te, 115, 115, 115, ColorMapElement.GradientFocusColor1);
            ColorMap(te, 092, 092, 095, ColorMapElement.GradientFocusColor2);
            ColorMap(te, 120, 120, 120, ColorMapElement.GradientFocusHoverColor1);
            ColorMap(te, 100, 100, 100, ColorMapElement.GradientFocusHoverColor2);
            ColorMap(te, 065, 065, 065, ColorMapElement.FocusBorderColor);
            ColorMap(te, 240, 240, 240, ColorMapElement.SelectedTextColor);

            ColorMap(te, 100, 100, 100, ColorMapElement.CaptionBarColor1);
            ColorMap(te, 035, 035, 035, ColorMapElement.CaptionBarColor2);
            ColorMap(te, 120, 120, 120, ColorMapElement.CaptionButtonColor1);
            ColorMap(te, 080, 080, 080, ColorMapElement.CaptionButtonColor2);
            ColorMap(te, 220, 160, 160, ColorMapElement.CaptionButtonRedColor1);
            ColorMap(te, 230, 050, 020, ColorMapElement.CaptionButtonRedColor2);

            // Not yet validated
            ColorMap(te, 059, 059, 059, ColorMapElement.SelectedColor);
            ColorMap(te, 200, 200, 200, ColorMapElement.WndValidColor);
            ColorMap(te, 200, 170, 150, ColorMapElement.HighlightColor);
            ColorMap(te, 036, 036, 036, ColorMapElement.WndTextColor);
            ColorMap(te, 114, 211, 255, ColorMapElement.LinkColor);
            ColorMap(te, 255, 209, 024, ColorMapElement.CheckedMenuColor);
            //---------------------------------------------------------------------------------------
        }

        private static void ColorMap(ThemeEnum te, int r, int g, int b, ColorMapElement cme)
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
