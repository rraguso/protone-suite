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
}
