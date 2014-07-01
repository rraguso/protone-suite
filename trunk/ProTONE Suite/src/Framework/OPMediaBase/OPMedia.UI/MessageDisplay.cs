using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Themes;
using OPMedia.Core;
using System.Media;
using OPMedia.Runtime.AssemblyInfo;
using System.Reflection;
using System.Diagnostics;

namespace OPMedia.UI
{
    public partial class MessageDisplay : ToolForm
    {
        string message = string.Empty;
        string title = string.Empty;
        MessageBoxIcon icon = MessageBoxIcon.Information;
        bool _query = false;
        bool _cancel = false;
        bool _abort = false;
        bool _forAll = false;
        bool _isAboutBox = false;

        public static void ShowAboutBox()
        {
            string msgFmt = "{0}\n{1}\n{2}\n";
            string caption = Translator.Translate("TXT_ABOUT", Translator.Translate("TXT_APP_NAME"));
            string message = string.Format(msgFmt,
                Translator.Translate("TXT_APP_NAME"),
                Translator.Translate("TXT_VERSION", AssemblyInfo.GetVersionNumber(Assembly.GetEntryAssembly())),
                AssemblyInfo.GetCopyright(Assembly.GetEntryAssembly()));

            MessageDisplay dlg = new MessageDisplay(message, caption, MessageBoxIcon.None);
            dlg._isAboutBox = true;
            dlg.ShowDialog();
        }

        public static DialogResult QueryWithCancelAndAbort(string message, string title, bool showForAll = false, MessageBoxIcon icon = MessageBoxIcon.Question)
        {
            MessageDisplay dlg = new MessageDisplay(message, title, icon);
            dlg._query = true;
            dlg._cancel = true;
            dlg._abort = true;
            dlg._forAll = showForAll;
            return dlg.ShowDialog();
        }

        public static DialogResult QueryWithCancel(string message, string title, MessageBoxIcon icon = MessageBoxIcon.Question)
        {
            MessageDisplay dlg = new MessageDisplay(message, title, icon);
            dlg._query = true;
            dlg._cancel = true;
            return dlg.ShowDialog();
        }

        public static DialogResult Query(string message, string title, MessageBoxIcon icon = MessageBoxIcon.Question)
        {
            MessageDisplay dlg = new MessageDisplay(message, title, icon);
            dlg._query = true;
            return dlg.ShowDialog();
        }

        public static DialogResult QueryEx(string message, string title, string additional, ref bool addCheck, MessageBoxIcon icon = MessageBoxIcon.Question)
        {
            MessageDisplay dlg = new MessageDisplay(message, title, icon);
            dlg._query = true;
            dlg.chkAdditionalCheck.Visible = true;
            dlg.chkAdditionalCheck.Text = additional;

            try
            {
                return dlg.ShowDialog();
            }
            finally
            {
                addCheck = (dlg.chkAdditionalCheck.Checked);
            }
        }

        public static void Show(string message, string title, MessageBoxIcon icon)
        {
            new MessageDisplay(message, title, icon).ShowDialog();
        }

        public MessageDisplay(string message, string title, MessageBoxIcon icon)
        {
            InitializeComponent();
            this.Load += new EventHandler(OnLoad);
            this.Shown += new EventHandler(MessageDisplay_Shown);

            this.TopMost = true;
            this.message = Translator.Translate(message);
            this.title = Translator.Translate(title);
            this.icon = icon;

            this.Icon = null;

            pbImage.Size = new Size(1, 1);
            pbImage.Image = null;
            pbImage.Visible = false;

            this.KeyDown += new KeyEventHandler(OnKeyDown);
            btn1.KeyDown += new KeyEventHandler(OnKeyDown);
            btn2.KeyDown += new KeyEventHandler(OnKeyDown);
            btn3.KeyDown += new KeyEventHandler(OnKeyDown);

            this.ControlBox = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.IsToolWindow = true;

            chkAdditionalCheck.Visible = false;

            lblThirdPartyNotice.BackColor = ThemeManager.BackColor;
            lblThirdPartyNotice.ForeColor = ThemeManager.ForeColor;

            Application.DoEvents();
        }

        void MessageDisplay_Shown(object sender, EventArgs e)
        {
            //this.TopMost = true;
            User32.BringWindowToTop(this.Handle);
        }

        void OnLoad(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnLoad), new object[] { sender, e });
                return;
            }

            Application.DoEvents();

            SetTitle(title);
            lblText.Text = message;

            UpdateButtons();
            UpdateIcon();
            UpdateThirdPartyNotice();

            if (chkAdditionalCheck.Visible)
            {
                chkAdditionalCheck.Margin = new Padding(pbImage.Right + 15, 8, 3, 3);
            }

            this.Height = pnlContentAll.Height + CaptionButtonSize.Height + pnlContentAll.Margin.Vertical;
            this.Width = pnlContentAll.Width + pnlContentAll.Margin.Horizontal;
        }

        private void UpdateThirdPartyNotice()
        {
            if (_isAboutBox)
            {
                string thirdPartyNotice = Translator.Translate("TXT_3RDPARTY_COPYRIGHT_NOTICE");
                if (thirdPartyNotice == "TXT_3RDPARTY_COPYRIGHT_NOTICE" /* translated notice not found */)
                {
                    lblThirdPartyNotice.Size = new Size(1, 1);
                }
                else
                {
                    lblThirdPartyNotice.Rtf = thirdPartyNotice;
                    using (Graphics g = Graphics.FromHwnd(lblThirdPartyNotice.Handle))
                    {
                        SizeF sz = g.MeasureString(lblThirdPartyNotice.Text, ThemeManager.NormalBoldFont);
                        lblThirdPartyNotice.Size = sz.ToSize();
                    }
                }
            }
            else
            {
                lblThirdPartyNotice.Size = new Size(1, 1);
            }
        }

        private void UpdateIcon()
        {
            if (_isAboutBox)
            {
                pbImage.Image = ImageProvider.GetAppIcon(true).ToBitmap();
                pbImage.Size = pbImage.Image.Size;
                pbImage.Visible = true;
                SystemSounds.Asterisk.Play();
            }
            else
            {
                switch (icon)
                {
                    case MessageBoxIcon.Warning:
                        pbImage.Image = ImageProvider.GetUser32Icon(User32Icon.Warning, true);
                        pbImage.Size = pbImage.Image.Size;
                        pbImage.Visible = true;
                        SystemSounds.Exclamation.Play();
                        break;
                    case MessageBoxIcon.Error:
                        pbImage.Image = ImageProvider.GetUser32Icon(User32Icon.Error, true);
                        pbImage.Size = pbImage.Image.Size;
                        pbImage.Visible = true;
                        SystemSounds.Hand.Play();
                        break;
                    case MessageBoxIcon.Question:
                        pbImage.Image = ImageProvider.GetUser32Icon(User32Icon.Question, true);
                        pbImage.Size = pbImage.Image.Size;
                        pbImage.Visible = true;
                        SystemSounds.Question.Play();
                        break;
                    case MessageBoxIcon.Information:
                        pbImage.Image = ImageProvider.GetUser32Icon(User32Icon.Information, true);
                        pbImage.Size = pbImage.Image.Size;
                        pbImage.Visible = true;
                        SystemSounds.Asterisk.Play();
                        break;
                    default:
                        pbImage.Image = null;
                        pbImage.Size = new Size(1, 1);
                        pbImage.Image = null;
                        pbImage.Visible = false;
                        SystemSounds.Beep.Play();
                        break;
                }
            }
        }

        private void UpdateButtons()
        {
            btn1.Visible = true;
            AcceptButton = btn1;

            if (_query)
            {
                btn1.Text = "&" + Translator.Translate("TXT_YES");
                btn1.DialogResult = DialogResult.Yes;
                
                btn2.Visible = true;
                btn2.Text = "&" + Translator.Translate("TXT_NO");
                btn2.DialogResult = DialogResult.No;
                
                CancelButton = btn2;

                if (_cancel)
                {
                    btn3.Visible = true;
                    btn3.Text = "&" + Translator.Translate("TXT_CANCEL");
                    btn3.DialogResult = DialogResult.Cancel;
                    CancelButton = btn3;
                }

                if (_abort)
                {
                    btn4.Visible = true;
                    btn4.Text = "&" + Translator.Translate("TXT_ABORT");
                    btn4.DialogResult = DialogResult.Abort;
                }

                if (_cancel && _abort && _forAll)
                {
                    btn5.Visible = true;
                    btn5.Text = "&" + Translator.Translate("TXT_YESALL");
                    btn5.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                btn1.Text = "&" + Translator.Translate("TXT_OK");
                btn1.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Key down event handler
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // Escape key press handler
                if (CancelButton != null)
                {
                    DialogResult = CancelButton.DialogResult;
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                }

                Close();
                return;
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                // Ctrl+C key press handler
                string text = string.Empty;
                text += "---------------------------\r\n";
                text += this.Text;
                text += "\r\n---------------------------\r\n";
                text += lblText.Text;
                text += "\r\n---------------------------\r\n";
                text += "[ " + btn1.Text + " ]";

                if (btn2.Visible)
                {
                    text += "  [ " + btn2.Text + " ]";
                }
                if (btn3.Visible)
                {
                    text += "  [ " + btn3.Text + " ]";
                }

                text += "\r\n---------------------------\r\n";
                Clipboard.SetText(text, TextDataFormat.Text);
                return;
            }
        }

        private void lblThirdPartyNotice_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}