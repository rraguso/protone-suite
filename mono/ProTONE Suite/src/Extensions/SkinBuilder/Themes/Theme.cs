using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.UI.Themes;
using System.IO;
using System.Xml.Linq;

namespace SkinBuilder.Themes
{
    public class Theme
    {
        public Dictionary<string, string> ThemeElements { get; private set; }
        public string ThemeName { get; set; }
        public bool IsDefault { get; set; }

        public Theme(XDocument doc, string themeName, bool isDefault) : this()
        {
            this.ThemeName = themeName;
            this.IsDefault = isDefault;

            var themeElements = (from themeElement in doc.Descendants("ThemeElement")
                                                where themeElement.Parent.Attribute("Name").Value == themeName
                                                select new
                                                {
                                                    Name = themeElement.Attribute("Name").Value.Trim(),
                                                    Value = themeElement.Attribute("Value").Value
                                                }).ToList();

            if (themeElements != null)
            {
                foreach (var themeElement in themeElements)
                    ThemeElements.Add(themeElement.Name, themeElement.Value);
            }
        }

        public Theme(string themeName, string templateThemeName, bool isDefault) : this()
        {
            this.ThemeName = themeName;
            this.IsDefault = isDefault;

            Dictionary<string, string> template = ThemeManager.GetAllThemeElements(templateThemeName);
            if (template != null)
            {
                ThemeElements = new Dictionary<string, string>(template);
            }
            else
            {
                ThemeElements.Add("BorderColor", "150, 150, 150");
                ThemeElements.Add("ForeColor", "000, 000, 000");
                ThemeElements.Add("BackColor", "252, 252, 252");
                ThemeElements.Add("GradientNormalColor1", "224, 227, 206");
                ThemeElements.Add("GradientNormalColor2", "224, 227, 206");
                ThemeElements.Add("GradientHoverColor1", "159, 207, 255");
                ThemeElements.Add("GradientHoverColor2", "159, 207, 255");
                ThemeElements.Add("GradientFocusColor1", "224, 227, 206");
                ThemeElements.Add("GradientFocusColor2", "224, 227, 206");
                ThemeElements.Add("GradientFocusHoverColor1", "170, 220, 255");
                ThemeElements.Add("GradientFocusHoverColor2", "170, 220, 255");
                ThemeElements.Add("FocusBorderColor", "051, 153, 255");
                ThemeElements.Add("SelectedTextColor", "000, 000, 000");
                ThemeElements.Add("CaptionBarColor1", "200, 200, 200");
                ThemeElements.Add("CaptionBarColor2", "200, 200, 200");
                ThemeElements.Add("CaptionButtonColor1", "224, 227, 206");
                ThemeElements.Add("CaptionButtonColor2", "224, 227, 206");
                ThemeElements.Add("CaptionButtonRedColor1", "225, 100, 100");
                ThemeElements.Add("CaptionButtonRedColor2", "225, 100, 100");
                ThemeElements.Add("SelectedColor", "159, 207, 255");
                ThemeElements.Add("WndValidColor", "255, 255, 255");
                ThemeElements.Add("HighlightColor", "010, 110, 080");
                ThemeElements.Add("WndTextColor", "000, 000, 000");
                ThemeElements.Add("LinkColor", "018, 097, 225");
                ThemeElements.Add("CheckedMenuColor", "255, 209, 024");
                ThemeElements.Add("SeparatorColor", "150, 150, 150");
                ThemeElements.Add("MenuTextColor", "000, 000, 000");
                ThemeElements.Add("HeaderMenuTextColor", "000, 000, 000");
                ThemeElements.Add("HighlightMenuTextColor", "000, 000, 000");
                ThemeElements.Add("HighlightHeaderMenuTextColor", "000, 000, 000");
                ThemeElements.Add("CheckedMenuTextColor", "000, 000, 000");
                ThemeElements.Add("GradientGaugeColor1", "000, 255, 000");
                ThemeElements.Add("GradientGaugeColor2", "255, 000, 000");
                ThemeElements.Add("ListHotItemColor", "255, 000, 000");
                ThemeElements.Add("CornerSize", "0");
                ThemeElements.Add("FormBorderWidth", "2");
            }
        }

        private Theme()
        {
            ThemeElements = new Dictionary<string, string>();
        }

    }
}
