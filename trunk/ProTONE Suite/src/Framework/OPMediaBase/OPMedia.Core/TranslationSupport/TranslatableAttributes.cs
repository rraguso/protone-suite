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

        public TranslatableCategoryAttribute(string tag) : base(tag)
        {
            this.Tag = tag;
        }

        public void PerformTranslation(PropertyDescriptor pd)
        {
            BindingFlags hidden = BindingFlags.NonPublic | BindingFlags.Instance;

            char sep = '\t';

            string prefix = string.Empty;
            switch (Tag)
            {
                case "TXT_FILESYSTEMINFO":
                case "TXT_CATALOGITEMINFO_RO":
                    prefix = new string(sep, 4);
                    break;

                case "TXT_CATALOGINFO":
                case "TXT_CATALOGITEMINFO":
                case "TXT_CDTRACKINFO":
                case "TXT_EXTRAINFO":
                    prefix = new string(sep, 3);
                    break;

                case "TXT_MEDIAINFO":
                    prefix = new string(sep, 2);
                    break;

                case "TXT_TAGINFO":
                    prefix = new string(sep, 1);
                    break;
            }

            string res = string.Format("{0}{1}", prefix, Translator.Translate(Tag));

            typeof(MemberDescriptor).GetField("category", hidden).SetValue(pd, res);
        }
    }

    public class TranslatableDisplayNameAttribute : DisplayNameAttribute, ITranslatableAttribute
    {
        public string Tag { get; private set; }

        public TranslatableDisplayNameAttribute(string tag)
        {
            Tag = tag;
        }

        public void PerformTranslation(PropertyDescriptor pd)
        {
            base.DisplayNameValue = Translator.Translate(Tag) + ":";
        }
    }
}
