using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace SkinBuilder.Themes
{
    public class ThemeFile
    {
        public Dictionary<string, Theme> Themes { get; private set; }

        public string FileName { get; private set; }

        public bool IsSaved 
        {
            get
            {
                return (string.IsNullOrEmpty(FileName) == false && File.Exists(FileName));
            }
        }

        public void AddNewTheme(string themeName, string templateThemeName, bool isDefault)
        {
            if (Themes.ContainsKey(themeName) == false)
                Themes.Add(themeName, new Theme(themeName, templateThemeName, isDefault));
        }

        public void DeleteTheme(string themeName)
        {
            if (Themes.ContainsKey(themeName))
                Themes.Remove(themeName);
        }

        public ThemeFile()
        {
            Themes = new Dictionary<string, Theme>();
            Themes.Add("New Theme", new Theme("ThemeName", "Metro", true));
        }

        public ThemeFile(string themeFile)
        {
            this.FileName = themeFile;
            Themes = new Dictionary<string, Theme>();

            XDocument doc = XDocument.Load(themeFile);
            if (doc != null)
            {
                var allThemes = (from theme in doc.Descendants("Theme")
                                 select new
                                 {
                                     Name = theme.Attribute("Name").Value.Trim(),
                                     IsDefault = theme.Attribute("IsDefault").Value.ToLowerInvariant() == "true"
                                 }).ToList();

                if (allThemes != null)
                {
                    foreach (var theme in allThemes)
                    {
                        Themes.Add(theme.Name,
                            new Theme(doc, theme.Name, theme.IsDefault));
                    }
                }
            }
            else
                throw new Exception("Invalid theme file: " + themeFile);
        }

        public void SaveToFile(string themeFile)
        {
            XDocument doc = new XDocument();
            XElement themes = new XElement("Themes");
            doc.Add(themes);

            foreach (KeyValuePair<string, Theme> kvp in Themes)
            {
                XElement theme = new XElement("Theme", new XAttribute("Name", kvp.Key), new XAttribute("IsDefault", kvp.Value.IsDefault));
                themes.Add(theme);

                foreach (KeyValuePair<string, string> kvp2 in kvp.Value.ThemeElements)
                {
                    XElement themeElement = new XElement("ThemeElement", new XAttribute("Name", kvp2.Key), new XAttribute("Value", kvp2.Value));
                    theme.Add(themeElement);
                }
            }

            doc.Save(themeFile);
        }
    }
}
