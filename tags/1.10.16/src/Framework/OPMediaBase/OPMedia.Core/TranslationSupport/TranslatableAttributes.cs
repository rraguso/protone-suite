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

            typeof(MemberDescriptor).GetField("category", hidden).SetValue(pd,
                Translator.Translate(Tag));
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
