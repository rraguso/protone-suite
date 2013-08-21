using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.OSDependentLayer;
using System.Windows.Forms;

namespace OPMedia.Runtime.TranslationSupport
{
    public class TranslationNotifyTarget : MethodEventTarget
    {
        public TranslationNotifyTarget(MethodInvoker callback)
            : base(EventNames.PerformTranslation, callback)
        {
        }
    }
}
