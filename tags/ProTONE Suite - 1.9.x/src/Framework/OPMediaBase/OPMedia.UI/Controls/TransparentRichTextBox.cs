using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OPMedia.Core;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime;
using System.Drawing;
using OPMedia.UI.Themes;

using OPMedia.Core.Utilities;

namespace OPMedia.UI.Controls
{
    public class TransparentRichTextBox : RichTextBox
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public TransparentRichTextBox()
            : base()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            base.ScrollBars = RichTextBoxScrollBars.None;
            this.ReadOnly = true;
            //this.StateCommon.Border.DrawBorders = PaletteDrawBorders.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;

            OnThemeChanged();
        }

        void OnThemeChanged()
        {
            base.ForeColor = ThemeManager.ForeColor;
            base.BackColor = ThemeManager.BackColor;
            Invalidate(true);
        }

        /// <summary>
        /// Override the default OnPaintBackground behavior
        /// (there is no need to paint the background but only
        /// the foreground).
        /// </summary>
        /// <param name="e">The paint event data.</param>
        override protected void OnPaintBackground(PaintEventArgs e)
        {
        }
    }

    public class InfoTextBox : TransparentRichTextBox
    {
        public InfoTextBox()
            : base()
        {
            ThemeManager.SetFont(this, FontSizes.Small);
        }

        public void SetInfo(string desc, Dictionary<string, string> info)
        {
            string text = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033";

            string fontFamily = "Segoe UI";// ThemeManager.NormalFont.FontFamily.Name;

            switch (SuiteConfiguration.LanguageID)
            {
                case "ro":
                    {
                        string format = @"{\fonttbl{\f0\fswiss\fprq2\fcharset238 #FF#;}}";
                        text += format.Replace("#FF#", fontFamily);
                        text += @"\viewkind4\uc1\pard\lang1048\f0\fs15";
                    }
                    break;
            }

            if (!string.IsNullOrEmpty(desc))
            {
                text += GenerateRtfLabel(desc.Replace("\r\n", @" \par ").Replace("\n", @" \par "));
                text += @" \par ";
                text += @" \par ";
            }

            if (info != null && info.Count > 0)
            {
                int i = info.Count;
                foreach (KeyValuePair<string, string> kvp in info)
                {
                    i--;

                    if (!string.IsNullOrEmpty(kvp.Key) ||
                            !string.IsNullOrEmpty(kvp.Value))
                    {
                        text += GenerateRtfLabel(Translator.Translate(kvp.Key).Replace("\r\n", @" \par ").Replace("\n", @" \par "));
                        text += " ";
                        text += GenerateRtfValue(kvp.Value.Replace("\r\n", @"\par").Replace("\n", @" \par "));
                    }

                    if (i > 0)
                    {
                        text += @" \par ";
                    }

                }
            }

            text += "}";
                
            this.Rtf = text;
            
            this.ForeColor = ThemeManager.ForeColor;
            //this.ForeColor = ThemeManager.BorderColor;
        }

        private string GenerateRtfLabel(string p)
        {
            return StringUtils.ConvertDiacriticalsToRtfTags(string.Format(@"\b {0} \b0", p));
        }

        private string GenerateRtfValue(string p)
        {
            return StringUtils.ConvertDiacriticalsToRtfTags(string.Format(@"{0}", p));
        }
    }
}
