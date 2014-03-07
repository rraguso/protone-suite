using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using OPMedia.OSDependentLayer;
using System.Reflection;
using System.Windows.Forms;

namespace OPMedia.Runtime.TranslationSupport
{
    public class TranslatableCategoryAttribute : CategoryAttribute
    {
        string _tag = string.Empty;
        TranslationNotifyTarget _target = null;

        public TranslatableCategoryAttribute(string tag)
        {
            _tag = tag;
            _target = new TranslationNotifyTarget(new MethodInvoker(UpdateLanguage));
            UpdateLanguage();
        }

        void UpdateLanguage()
        {
            BindingFlags hidden = BindingFlags.NonPublic | BindingFlags.Instance;
            typeof(CategoryAttribute).GetField("categoryValue", hidden).SetValue(this, Translator.Translate(_tag));
        }
    }

    public class TranslatableDisplayNameAttribute : DisplayNameAttribute
    {
        string _tag = string.Empty;
        TranslationNotifyTarget _target = null;

        public TranslatableDisplayNameAttribute(string tag)
        {
            _tag = tag;
            _target = new TranslationNotifyTarget(new MethodInvoker(UpdateLanguage)); 
            UpdateLanguage();
        }

        void UpdateLanguage()
        {
            base.DisplayNameValue = Translator.Translate(_tag);
        }
    }
}
