using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using OPMedia.Core;
using System.Reflection;
using System.Windows.Forms;
using OPMedia.Core.GlobalEvents;

namespace OPMedia.Core.TranslationSupport
{
    public interface ITranslatableAttribute
    {
        string Tag { get; }
        void PerformTranslation(PropertyDescriptor pd);
    }

    public class TranslatableCategoryAttribute : CategoryAttribute, ITranslatableAttribute
    {
        public string Tag { get; private set; }

        public TranslatableCategoryAttribute(string tag) : 
            base(TranslateCategoryName(tag))
        {
            this.Tag = tag;
        }

        public void PerformTranslation(PropertyDescriptor pd)
        {
            BindingFlags hidden = BindingFlags.NonPublic | BindingFlags.Instance;
            string res = TranslateCategoryName(this.Tag);
            typeof(MemberDescriptor).GetField("category", hidden).SetValue(pd, res);
        }

        private static string TranslateCategoryName(string tag)
        {
            char sep = '\t';

            string prefix = string.Empty;
            switch (tag)
            {
                case "TXT_FILESYSTEMINFO":
                case "TXT_CATALOGITEMINFO_RO":
                    prefix = new string(sep, 4);
                    //prefix = "[1] ";
                    break;

                case "TXT_CATALOGINFO":
                case "TXT_CATALOGITEMINFO":
                case "TXT_CDTRACKINFO":
                case "TXT_EXTRAINFO":
                    prefix = new string(sep, 3);
                    //prefix = "[2] ";
                    break;

                case "TXT_MEDIAINFO":
                    prefix = new string(sep, 2);
                    //prefix = "[3] ";
                    break;

                case "TXT_TAGINFO":
                    prefix = new string(sep, 1);
                    //prefix = "[4] ";
                    break;
            }

            return string.Format("{0}{1}", prefix, Translator.Translate(tag));
        }
    }

    public class TranslatableDisplayNameAttribute : DisplayNameAttribute, ITranslatableAttribute
    {
        public string Tag { get; private set; }

        public TranslatableDisplayNameAttribute(string tag)
        {
            Tag = tag;
            base.DisplayNameValue = Translator.Translate(Tag) + ":";
        }

        public void PerformTranslation(PropertyDescriptor pd)
        {
            base.DisplayNameValue = Translator.Translate(Tag) + ":";
        }
    }
}
