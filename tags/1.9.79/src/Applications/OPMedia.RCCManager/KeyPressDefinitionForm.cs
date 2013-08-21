using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.Runtime.Shortcuts;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Themes;

namespace OPMedia.RCCManager
{
    public partial class KeyPressDefinitionForm : ToolForm
    {
        KeyEventArgs _args = null;

        public KeyEventArgs KeyEventArgs
        { get { return _args; } }

        public KeyPressDefinitionForm()
        {
            InitializeComponent();
            this.KeyUp += new KeyEventHandler(KeyCommandEditor_KeyUp);
        }

        void KeyCommandEditor_KeyUp(object sender, KeyEventArgs e)
        {
            KeyEventArgs args = GetKeyArgs(e);
            if (args != null &&
                args.KeyData != Keys.Enter &&
                args.KeyData != Keys.Escape &&
                args.KeyData != Keys.Tab)
            {
                _args = args;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private KeyEventArgs GetKeyArgs(KeyEventArgs e)
        {
            KeyEventArgs retVal = null;
            if (e.Modifiers == Keys.None)
            {
                if (e.KeyData != Keys.Menu &&
                e.KeyData != Keys.ControlKey &&
                e.KeyData != Keys.ShiftKey)
                {
                    retVal = new KeyEventArgs(e.KeyData);
                }
            }
            else
            {
                if (e.KeyData != e.Modifiers)
                    retVal = new KeyEventArgs(e.KeyData);
            }

            return retVal;
        }

       
    }
}