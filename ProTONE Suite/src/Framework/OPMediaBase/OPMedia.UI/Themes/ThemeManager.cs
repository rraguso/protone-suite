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
using OPMedia.Core.Configuration;
using System.Collections.Generic;
using OPMedia.UI.Generic;
using System.IO;

using OPMedia.Core;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Microsoft.Win32;
using System.ComponentModel;
using OPMedia.UI.Properties;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using OPMedia.UI.Controls.ThemedScrollBars;
using System.Threading;

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
        ExtremeLarge,
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
        static Dictionary<string, Dictionary<string, string>> _allThemesElements = null;

        static FileSystemWatcher _fsw = null;

        #region Members
        private static Font _smallestFont = null;
        private static Font _smallFont = null;
        private static Font _normalFont = null;
        private static Font _normalBoldFont = null;
        private static Font _largeFont = null;
        private static Font _veryLargeFont = null;

        private static Font _extremeLargeFont = null;

        private static ColorConverter cc = new ColorConverter();

        #endregion

        #region Properties

        static string _defaultTheme = "";
        public static string DefaultTheme
        {
            get
            {
                return _defaultTheme;
            }
        }

        public static List<string> Themes
        {
            get
            {
                if (_allThemesElements != null &&
                    _allThemesElements.Count > 0)
                {
                    return new List<String>(_allThemesElements.Keys);
                }

                return new List<string> { string.Empty };
            }
        }

        public static Color ListActiveItemColor
        { 
            get 
            {

                return ThemeElement("ListActiveItemColor", SafeColorFromString("255, 000, 000")); 
            } 
        }

        public static Color ListHotItemColor
        { get { return ThemeElement("ListHotItemColor", SafeColorFromString("255, 000, 000")); } }

        public static Color BackColor
        { get { return ThemeElement("BackColor", SafeColorFromString("252, 252, 252")); } }

        public static Color ForeColor
        { get { return ThemeElement("ForeColor", SafeColorFromString("000, 000, 000")); } }

        public static Color HighlightColor
        { get { return ThemeElement("HighlightColor", SafeColorFromString("010, 110, 080")); } }

        public static Color SelectedColor
        { get { return ThemeElement("SelectedColor", SafeColorFromString("159, 207, 255")); } }

        public static Color BorderColor
        { get { return ThemeElement("BorderColor", SafeColorFromString("150, 150, 150")); } }
          
        public static Color GradientNormalColor1
        { get { return ThemeElement("GradientNormalColor1", SafeColorFromString("224, 227, 206")); } }

        public static Color GradientNormalColor2
        { get { return ThemeElement("GradientNormalColor2", SafeColorFromString("224, 227, 206")); } }

        public static Color GradientHoverColor1
        { get { return ThemeElement("GradientHoverColor1", SafeColorFromString("159, 207, 255")); } }

        public static Color GradientHoverColor2
        { get { return ThemeElement("GradientHoverColor2", SafeColorFromString("159, 207, 255")); } }

        public static Color GradientFocusColor1
        { get { return ThemeElement("GradientFocusColor1", SafeColorFromString("224, 227, 206")); } }

        public static Color GradientFocusColor2
        { get { return ThemeElement("GradientFocusColor2", SafeColorFromString("224, 227, 206")); } }

        public static Color GradientFocusHoverColor1
        { get { return ThemeElement("GradientFocusHoverColor1", SafeColorFromString("170, 220, 255")); } }

        public static Color GradientFocusHoverColor2
        { get { return ThemeElement("GradientFocusHoverColor2", SafeColorFromString("170, 220, 255")); } }

        public static Color FocusBorderColor
        { get { return ThemeElement("FocusBorderColor", SafeColorFromString("051, 153, 255")); } }

        public static Color WndValidColor
        { get { return ThemeElement("WndValidColor", SafeColorFromString("255, 255, 255")); } }

        public static Color WndTextColor
        { get { return ThemeElement("WndTextColor", SafeColorFromString("000, 000, 000")); } }

        public static Color LinkColor
        { get { return ThemeElement("LinkColor", SafeColorFromString("018, 097, 225")); } }

        public static Color CheckedMenuColor
        { get { return ThemeElement("CheckedMenuColor", SafeColorFromString("255, 209, 024")); } }

        public static Color CaptionBarColor1
        { get { return ThemeElement("CaptionBarColor1", SafeColorFromString("200, 200, 200")); } }

        public static Color CaptionBarColor2
        { get { return ThemeElement("CaptionBarColor2", SafeColorFromString("200, 200, 200")); } }

        public static Color CaptionButtonColor1
        { get { return ThemeElement("CaptionButtonColor1", SafeColorFromString("224, 227, 206")); } }

        public static Color CaptionButtonColor2
        { get { return ThemeElement("CaptionButtonColor2", SafeColorFromString("224, 227, 206")); } }

        public static Color CaptionButtonRedColor1
        { get { return ThemeElement("CaptionButtonRedColor1", SafeColorFromString("225, 100, 100")); } }

        public static Color CaptionButtonRedColor2
        { get { return ThemeElement("CaptionButtonRedColor2", SafeColorFromString("225, 100, 100")); } }

        public static Color SelectedTextColor
        { get { return ThemeElement("SelectedTextColor", SafeColorFromString("000, 000, 000")); } }

        public static Color SeparatorColor
        { get { return ThemeElement("SeparatorColor", SafeColorFromString("150, 150, 150")); } }

        public static Color MenuTextColor
        { get { return ThemeElement("MenuTextColor", SafeColorFromString("000, 000, 000")); } }

        public static Color CheckedMenuTextColor
        { get { return ThemeElement("CheckedMenuTextColor", SafeColorFromString("000, 000, 000")); } }

        public static Color HeaderMenuTextColor
        { get { return ThemeElement("HeaderMenuTextColor", SafeColorFromString("000, 000, 000")); } }

        public static Color HighlightMenuTextColor
        { get { return ThemeElement("HighlightMenuTextColor", SafeColorFromString("000, 000, 000")); } }

        public static Color HighlightHeaderMenuTextColor
        { get { return ThemeElement("HighlightHeaderMenuTextColor", SafeColorFromString("000, 000, 000")); } }

        public static Color GradientGaugeColor1
        { get { return ThemeElement("GradientGaugeColor1", SafeColorFromString("000, 255, 000")); } }

        public static Color GradientGaugeColor2
        { get { return ThemeElement("GradientGaugeColor2", SafeColorFromString("255, 000, 000")); } }

        public static Color GradientGaugeColor1a
        { get { return ThemeElement("GradientGaugeColor1a", SafeColorFromString("255, 242, 000")); } }

        public static int CornerSize
        { get { return ThemeElement("CornerSize", 0); } }

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
        { get { return ThemeElement("FormBorderWidth", 1); } }

        public static string ResourcesFolder
        { 
            get 
            {
                string currentTheme = AppConfig.AllowRealtimeGUISetup ? AppConfig.SkinType : "Black";
                return ThemeElement("ResourcesFolder", currentTheme); 
            } 
        }

        public static Color ColorValidationFailed
        { get { return Color.MistyRose; } }

        public static Color TransparentColor
        { get { return Color.White; } }


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

        public static Font ExtremeLargeFont
        { get { return _extremeLargeFont; } }

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
                case FontSizes.ExtremeLarge:
                    return ThemeManager.ExtremeLargeFont;
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

        private static List<Control> _skinnedControls = new List<Control>();

        public static void SetDoubleBuffer(Control c)
        {
            if (c != null && _skinnedControls.Contains(c) == false)
            {
                if (c.Controls != null && c.Controls.Count > 0)
                {
                    foreach (Control child in c.Controls)
                    {
                        SetDoubleBuffer(child);
                    }
                }

                _skinnedControls.Add(c);
                c.HandleDestroyed += new EventHandler(c_HandleDestroyed);

                SetDoubleBufferControl(c);

                // TODO: make scroll bar skinning more reliable
                //ScrollBarSkinner.SkinWindow(c);
            }
        }

        static void c_HandleDestroyed(object sender, EventArgs e)
        {
            Control c = sender as Control;
            if (c != null && _skinnedControls.Contains(c))
            {
                c.HandleDestroyed -= new EventHandler(c_HandleDestroyed);
                _skinnedControls.Remove(c);
            }
        }

        private readonly static string ThemeFontFamily = 
            AppConfig.OSVersion < AppConfig.VerWinVista ?
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

                    _extremeLargeFont =
                        new Font(ThemeFontFamily, 35 * step, FontStyle.Bold, GraphicsUnit.Point);
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
            InitThemeElements();

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

        //static void OnThemeChanged(object sender, EventArgs e)
        //{
        //    RecreateFonts();
        //}

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

        private static object _loadThemeLock = new object();

        private static void InitThemeElements()
        {
            lock (_loadThemeLock)
            {
                try
                {
                    string themeFolder = Path.Combine(AppConfig.InstallationPath, "Themes");
                    string themeFile = Path.Combine(AppConfig.InstallationPath, "Themes\\Themes.thm");
                    XDocument doc = XDocument.Load(themeFile);

                    if (_fsw == null)
                    {
                        _fsw = new FileSystemWatcher(themeFolder, "Themes.thm");
                        _fsw.Changed += new FileSystemEventHandler(OnFileChanged);
                        _fsw.EnableRaisingEvents = true;
                    }

                    if (doc != null)
                    {
                        var allThemes = (from theme in doc.Descendants("Theme")
                                         select new
                                         {
                                             Name = theme.Attribute("Name").Value.Trim(),
                                             IsDefault = theme.Attribute("IsDefault").Value.ToLowerInvariant() == "true"
                                         }).ToList();

                        string lastThemeName = string.Empty;
                        foreach (var theme in allThemes)
                        {
                            lastThemeName = theme.Name;
                            if (theme.IsDefault)
                            {
                                _defaultTheme = theme.Name;
                            }

                            var themeElements = (from themeElement in doc.Descendants("ThemeElement")
                                                 where themeElement.Parent.Attribute("Name").Value == theme.Name
                                                 select new
                                                 {
                                                     Name = themeElement.Attribute("Name").Value.Trim(),
                                                     Value = themeElement.Attribute("Value").Value
                                                 }).ToList();

                            foreach (var themeElement in themeElements)
                                ThemeElement(theme.Name, themeElement.Name, themeElement.Value);
                        }

                        if (string.IsNullOrEmpty(_defaultTheme))
                            _defaultTheme = lastThemeName;
                    }

                    // This is just to enforce reading theme settings from Registry
                    int sz = ThemeElement("CornerSize", 1);
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);

                    if (_allThemesElements != null)
                        _allThemesElements.Clear();
                }
            }
        }

        static void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            if (AppConfig.AllowRealtimeGUISetup)
            {
                string themeFile = Path.Combine(AppConfig.InstallationPath, "Themes\\Themes.thm");
                if (e.ChangeType == WatcherChangeTypes.Changed && e.FullPath == themeFile)
                {
                    Logger.LogInfo("Theme file changed. Reloading themes ...");

                    lock (_loadThemeLock)
                    {
                        string themeBefore = AppConfig.SkinType;
                        Thread.Sleep(200);
                        InitThemeElements();
                        AppConfig.SkinType = _defaultTheme;
                        AppConfig.SkinType = themeBefore;
                    }

                    Logger.LogInfo("Themes reloaded succesfully.");
                }
            }
        }

        #region assignment
        private static void ThemeElement(string themeName, string elementName, string value)
        {
            try
            {
                if (_allThemesElements == null)
                    _allThemesElements = new Dictionary<string,Dictionary<string,string>>();

                if (_allThemesElements.ContainsKey(themeName) == false)
                    _allThemesElements.Add(themeName, new Dictionary<string, string>());

                if (_allThemesElements[themeName].ContainsKey(elementName))
                    _allThemesElements[themeName][elementName] = value;
                else
                    _allThemesElements[themeName].Add(elementName, value);
            }
            catch { }
        }
        #endregion

        #region backwards conversion
        private static int ThemeElement(string elementName, int defaultValue = -1)
        {
            int retVal = defaultValue;
            try
            {
                string val = ThemeElement(elementName, defaultValue.ToString());
                if (int.TryParse(val, out retVal) == false)
                {
                    retVal = defaultValue;
                }
            }
            catch
            {
                retVal = defaultValue;
            }

            return retVal;
        }

        private static Color ThemeElement(string elementName, Color defaultValue = default(Color))
        {
            Color retVal = defaultValue;
            try
            {
                string val = ThemeElement(elementName, cc.ConvertToString(defaultValue));
                retVal = SafeColorFromString(val);
            }
            catch
            {
                retVal = defaultValue;
            }

            return retVal;
        }

        private static Color SafeColorFromString(string value)
        {
            try
            {
                return (Color)cc.ConvertFromInvariantString(value);
            }
            catch
            {
                return Color.Empty;
            }
        }

        private static string ThemeElement(string elementName, string defaultValue = null)
        {
            lock (_loadThemeLock)
            {
                string currentTheme = AppConfig.AllowRealtimeGUISetup ? AppConfig.SkinType : "Black";
                string elementValue = defaultValue;

                if (_allThemesElements == null)
                    _allThemesElements = new Dictionary<string, Dictionary<string, string>>();

                if (string.IsNullOrEmpty(currentTheme) || _allThemesElements.ContainsKey(currentTheme) == false)
                {
                    currentTheme = _defaultTheme;
                    AppConfig.SkinType = _defaultTheme;
                }

                try
                {
                    elementValue = _allThemesElements[currentTheme][elementName];
                }
                catch
                {
                    elementValue = defaultValue;
                }

                return elementValue;
            }
        }

        public static Dictionary<string, string> GetAllThemeElements(string themeName)
        {
            lock (_loadThemeLock)
            {
                if (_allThemesElements != null)
                {
                    return _allThemesElements[themeName];
                }

                return null;
            }
        }

        #endregion
    }
}
