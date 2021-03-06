using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.Core.TranslationSupport;
using System.IO;
using OPMedia.Core;
using OPMedia.UI.Themes;
using System.Diagnostics;
using System.Threading;

namespace OPMedia.UI.Dialogs
{
    public partial class GenericWaitDialog : ToolForm, IDisposable
    {
        public DialogResult ShowDialog(string message)
        {
            this.lblNotifyText.Text = Translator.Translate(message);
            return ShowDialog();
        }

        public GenericWaitDialog()
        {
            InitializeComponent();

            this.TitleBarVisible = false;
        }

        protected override bool AllowCloseOnKeyDown(Keys key)
        {
            return false;
        }
    }
}