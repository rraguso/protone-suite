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
    public class TranslatableCategoryAttribute : CategoryAttribute
    {
        string _tag = string.Empty;

        public TranslatableCategoryAttribute(string tag)
        {
            _tag = tag;
            EventDispatch.RegisterHandler(this);
            UpdateLanguage();
        }

        [EventSink(EventNames.PerformTranslation)]
        public void UpdateLanguage()
        {
            BindingFlags hidden = BindingFlags.NonPublic | BindingFlags.Instance;
            typeof(CategoryAttribute).GetField("categoryValue", hidden).SetValue(this, Translator.Translate(_tag));
        }

        //protected override string GetLocalizedString(string value)
        //{
        //    return Translator.Translate(_tag);
            //return base.GetLocalizedString(value);
        //}

        ~TranslatableCategoryAttribute()
        {
            EventDispatch.UnregisterHandler(this);
        }
    }

    public class TranslatableDisplayNameAttribute : DisplayNameAttribute
    {
        string _tag = string.Empty;

        public TranslatableDisplayNameAttribute(string tag)
        {
            _tag = tag;
            EventDispatch.RegisterHandler(this);
            UpdateLanguage();
        }

        [EventSink(EventNames.PerformTranslation)]
        public void UpdateLanguage()
        {
            base.DisplayNameValue = Translator.Translate(_tag) + ":";
        }

        ~TranslatableDisplayNameAttribute()
        {
            EventDispatch.UnregisterHandler(this);
        }
    }
}
