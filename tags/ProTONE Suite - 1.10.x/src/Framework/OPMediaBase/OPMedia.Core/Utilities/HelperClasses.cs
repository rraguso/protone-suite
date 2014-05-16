using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using OPMedia.Core.Utilities;
using OPMedia.Core.Logging;
using System.Diagnostics;

namespace OPMedia.Core
{
    public class Language
    {
        static Language[] __allLanguages;

        public string ID = "en";

        static Language()
        {
            List<Language> langs = new List<Language>();
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (CultureInfo ci in cultures)
            {
                langs.Add(new Language(ci));
            }

            __allLanguages = langs.ToArray();
        }

        CultureInfo _ci = null;

        public Language(CultureInfo ci)
        {
            _ci = ci;
            this.ID = _ci.TwoLetterISOLanguageName;
        }

        public Language(string ID)
        {
            _ci = new CultureInfo(ID);
            this.ID = ID;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", 
                StringUtils.Capitalize(_ci.NativeName, WordCasing.CapitalizeWords), 
                _ci.TwoLetterISOLanguageName.ToUpperInvariant());
        }

        public string EnglishName
        {
            get
            {
                return _ci.EnglishName;
            }
        }

        public string ThreeLetterISOLanguageName
        {
            get
            {
                return _ci.ThreeLetterISOLanguageName;
            }
        }

        public static Language[] AllLanguages
        {
            get
            {
                return __allLanguages;
            }
        }

        public static Language GetByThreeLetterISOLanguageName(string name)
        {
            foreach (Language lang in __allLanguages)
            {
                if (string.Compare(lang.ThreeLetterISOLanguageName, name, true) == 0)
                    return lang;
            }

            try
            {
                switch (name.ToLowerInvariant())
                {
                    case "cze/ces":
                        return new Language("cs");
                    case "dut/nld":
                        return new Language("nl");
                    case "fre/fra":
                        return new Language("fr");
                    case "gre":
                        return new Language("el");
                    case "rum/ron":
                        return new Language("ro");

                    case "alb/sqi":
                        return new Language("sq");
                    case "arm/hye":
                        return new Language("hy");
                    case "baq/eus":
                        return new Language("eu");
                    case "bur/mya":
                        return new Language("my");
                    case "chi/zho":
                        return new Language("zh");
                    case "geo/kat":
                        return new Language("ka");
                    case "ger/deu":
                        return new Language("de");
                    case "gre/ell":
                        return new Language("el");
                    case "ice/isl":
                        return new Language("is");
                    case "mac/mkd":
                        return new Language("mk");
                    case "may/msa":
                        return new Language("ms");
                    case "mao/mri":
                        return new Language("mi");
                    case "per/fas":
                        return new Language("fa");
                    case "pob/pb":
                        return new Language("pt-BR");
                    case "qaa-qtz":
                        return new Language("ro");
                    case "slk/slo":
                        return new Language("sk");
                    case "tib/bod":
                        return new Language("bo");
                    case "wel/cym":
                        return new Language("cy");

                }
            }
            catch (Exception ex) 
            {
                Logger.LogException(ex);
            }

            return null;
        }

        public static string ThreeLetterISOLanguageNameToEnglishName(string name)
        {
            Language l = GetByThreeLetterISOLanguageName(name);
            if (l != null)
            {
                return l.EnglishName;
            }
            else
            {
                Debug.WriteLine("LANG UNKNOWN: " + name);
            }

            return name;
        }
    }

    public class Theme
    {
        public string Name { get; private set; }
        public bool IsDefault { get; private set; }
        public ThemeEnum Value { get; private set; }

        public static bool IsAllowedValue(int val)
        {
            return IsAllowedValue((ThemeEnum)val);
        }

        public static bool IsAllowedValue(ThemeEnum val)
        {
            foreach(Theme t in AllThemes)
            {
                if (t.Value == val)
                    return true;
            }

            return false;
        }

        static Theme _default = new Theme(ThemeEnum.Black);
        public static Theme Default
        {
            get
            {
                return _default;
            }
        }

        static Theme[] _allThemes;
        public static Theme[] AllThemes
        {
            get
            {
                return _allThemes;
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            Theme t = obj as Theme;
            return (t != null && t.Value == this.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        static Theme()
        {
            List<Theme> themes = new List<Theme>(new Theme[]
                {
                    new Theme(ThemeEnum.Silver),
                    new Theme(ThemeEnum.Blue),
                    new Theme(ThemeEnum.Black),
                });

            try
            {
                themes.Sort(delegate(Theme t1, Theme t2)
                {
                    if (t1 == null && t2 == null)
                        return 0;
                    if (t1 == null)
                        return -1;
                    if (t2 == null)
                        return 1;

                    if (t1.IsDefault != t2.IsDefault)
                    {
                        if (t1.IsDefault)
                            return -1;
                        if (t2.IsDefault)
                            return 1;
                    }

                    return t1.Value.CompareTo(t2.Value);

                });
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchException(ex);
            }

            _allThemes = themes.ToArray();
        }

        public Theme(ThemeEnum value)
        {
            this.Value = value;
            this.IsDefault = false;

            switch (value)
            {
                case ThemeEnum.Silver:
                    this.Name = "Silver theme";
                    break;
                case ThemeEnum.Blue:
                    this.Name = "Blue theme";
                    break;
                case ThemeEnum.Black:
                    this.Name = "Black theme (Default)";
                    this.IsDefault = true;
                    break;

                default:
                    throw new NotSupportedException(string.Format("Value {0} is not supported.", value));
            }
        }
    }

    public enum ThemeEnum
    {
        Silver = 0,
        Blue,
        Black,

        NofThemes
    }
}
