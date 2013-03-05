using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using OPMedia.UI.Themes;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Text;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core;
using System.Reflection;
using System.Diagnostics;

using OPMedia.UI.Generic;

namespace OPMedia.UI.Controls
{
    internal sealed class OPMToolTipData
    {
        public Dictionary<string, string> Values { get; set; }
        public Image TitleImage { get; set; }
        public Image CustomImage { get; set; }
        public string Title { get; set; }
        public Size Size { get; set; }
    }

    public class OPMToolTip : ToolTip
    {
        const int ImageMaxHeight = 80;

        private Dictionary<Control, OPMToolTipData> _data = new Dictionary<Control, OPMToolTipData>();

        Font _fVal = ThemeManager.SmallestFont;
        Font _fKey = ThemeManager.SmallFont;
        Font _fTitle = ThemeManager.LargeFont;
        static Font _def = new Font("Segoe UI", 12.0f, FontStyle.Regular, GraphicsUnit.World);

        public void ShowSimpleToolTip(Control ctl, string text, Image img = null)
        {
            Dictionary<string, string> d = null;
            if (text != null)
            {
                d = new Dictionary<string, string>();
                d.Add(text, string.Empty);
            }

            ShowToolTip(ctl, Translator.Translate("TXT_APP_NAME"), d,
                img ?? ImageProvider.ApplicationIconLarge);
        }

        public void ShowToolTip(Control ctl, string title, Dictionary<string, string> values = null, Image img = null, Image customImage = null)
        {
            string fake = AssignData(ctl, title, values, img, customImage);
            base.Show(fake, ctl);
        }

        public void SetSimpleToolTip(Control ctl, string text, Image img = null)
        {
            Dictionary<string, string> d = null;
            if (text != null)
            {
                d = new Dictionary<string, string>();
                d.Add(text, string.Empty);
            }

            SetToolTip(ctl, Translator.Translate("TXT_APP_NAME"), d, 
                img ?? ImageProvider.ApplicationIconLarge);
        }

        public void SetToolTip(Control ctl, string title, Dictionary<string, string> values = null, Image img = null, Image customImage = null)
        {
            string fake = AssignData(ctl, title, values, img, customImage);
            base.SetToolTip(ctl, fake);
        }

        void ctl_MouseHover(object sender, EventArgs e)
        {
            ShowInternal(sender as Control);
        }

        void ShowInternal(Control ctl)
        {
            if (ctl != null && _data.ContainsKey(ctl))
            {
                OPMToolTipData data = _data[ctl];
                if (data != null)
                {
                    Size s = CalculateSize(ctl, data);
                    this.ShowToolTip(ctl, data.Title, data.Values, data.TitleImage);
                }
            }
        }

        private string AssignData(Control ctl, string title, Dictionary<string, string> values, Image titleImage, Image customImage)
        {
            titleImage = GetScaledImage(titleImage);
            customImage = GetScaledImage(customImage);

            if (_data.ContainsKey(ctl))
            {
                if (string.IsNullOrEmpty(title))
                {
                    _data.Remove(ctl);
                }
                else
                {
                    _data[ctl] = new OPMToolTipData { Values = values, Title = title, TitleImage = titleImage, CustomImage = customImage};
                }
            }
            else if (!string.IsNullOrEmpty(title))
            {
                _data.Add(ctl, new OPMToolTipData { Values = values, Title = title, TitleImage = titleImage, CustomImage = customImage });
            }

            if (_data.ContainsKey(ctl) && _def != null)
            {
                _data[ctl].Size = CalculateSize(ctl, _data[ctl]);

                string fake = string.Empty;
                string row = string.Empty;
                SizeF size = SizeF.Empty;

                // Calculate a string that would generate an equivalent tooltip size
                using (Graphics g = ctl.CreateGraphics())
                {
                    do
                    {
                        row += "Ig";
                        size = g.MeasureString(row, _def);
                    }
                    while (size.Width < _data[ctl].Size.Width);

                    fake = row;

                    size = SizeF.Empty;
                    do
                    {
                        fake += "Ig\n";
                        size = g.MeasureString(fake, _def);
                    }
                    while (size.Height < _data[ctl].Size.Height);
                }

                return fake;
            }
            
            return title;
        }

        public OPMToolTip(IContainer c)
            : base(c)
        {
            Init();
        }

        public OPMToolTip()
            : base()
        {
            Init();
        }

        private void Init()
        {
            base.OwnerDraw = true;
            this.Draw += new DrawToolTipEventHandler(OPMToolTip_Draw);
            this.Popup += new PopupEventHandler(OPMToolTip_Popup);
        }

        void OPMToolTip_Popup(object sender, PopupEventArgs e)
        {
            if (OwnerDraw)
            {
                if (e.AssociatedControl != null && _data.ContainsKey(e.AssociatedControl))
                {
                    e.ToolTipSize = CalculateSize(e.AssociatedControl, _data[e.AssociatedControl]);
                }
            }
        }

        private Size CalculateSize(Control c, OPMToolTipData data)
        {
            int x = 0, y = 0;

            if (data != null)
            {
                int titleOffsetX = 5;
                int titleOffsetY = 5;

                using (Graphics g = c.CreateGraphics())
                {
                    SizeF sizeTitle = g.MeasureString(data.Title, _fTitle);

                    if (data.TitleImage != null)
                    {
                        x += 5 + data.TitleImage.Width;
                        y += 5 + data.TitleImage.Height;

                        titleOffsetX += 5 + data.TitleImage.Width;
                        titleOffsetY = (int)(data.TitleImage.Height / 2 - sizeTitle.Height / 2);

                        y += 5;
                    }
                    else
                    {
                        y += (int)sizeTitle.Height + 10;
                    }

                    if (data.Values != null)
                    {
                        foreach (KeyValuePair<string, string> val in data.Values)
                        {
                            string key = Translator.Translate(val.Key.Trim());
                            string keyMeasure = string.IsNullOrEmpty(key) ? " " : key;
                            string valMeasure = string.IsNullOrEmpty(val.Value) ? " " : val.Value;

                            SizeF szKey = g.MeasureString(keyMeasure, _fKey);
                            SizeF szVal = g.MeasureString(valMeasure, _fVal);

                            y += (int)szKey.Height + 2;
                            x = (int)Math.Max(x, szKey.Width + szVal.Width + 10);
                        }
                    }

                    x = (int)Math.Max(x, titleOffsetX + sizeTitle.Width);

                    if (data.CustomImage != null)
                    {
                        y += 5;
                        y += data.CustomImage.Height;
                    }
                }
            }

            x += 10;
            y += 10;

            return new Size(x, y);
        }

        void OPMToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            if (e.AssociatedControl != null && _data.ContainsKey(e.AssociatedControl))
            {
                e.Graphics.CompositingMode = CompositingMode.SourceOver;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                e.Graphics.TextContrast = 5;

                //e.DrawBackground();
                //e.DrawBorder(); 
                
                using (LinearGradientBrush b = new LinearGradientBrush(e.Bounds,
                    ThemeManager.GradientLTColor, ThemeManager.GradientMColor, 90))
                {
                    e.Graphics.FillRectangle(b, e.Bounds);
                }

                using (Pen p = new Pen(ThemeManager.BorderColor))
                {
                    Rectangle rc = new Rectangle(e.Bounds.Location,
                        new Size(e.Bounds.Width - 1, e.Bounds.Height - 1));

                    e.Graphics.DrawRectangle(p, rc);
                }

                DrawContents(e.Graphics, _data[e.AssociatedControl]);
            }
            else
            {
                // Fallback to regular tooltip
                e.DrawBorder();
                e.DrawBackground();
                e.DrawText();
            }
        }

        private void DrawContents(Graphics g, OPMToolTipData data)
        {
            if (data != null)
            {
                int titleOffsetX = 5;
                int titleOffsetY = 5;
                int textOffsetY = 5;

                SizeF sizeTitle = g.MeasureString(data.Title, _fTitle);

                if (data.TitleImage != null)
                {
                    g.DrawImage(data.TitleImage, 5, 5);

                    titleOffsetX += 5 + data.TitleImage.Width;
                    titleOffsetY = (int)(data.TitleImage.Height / 2 - sizeTitle.Height / 4);

                    textOffsetY += data.TitleImage.Height + 5;
                }
                else
                {
                    textOffsetY += (int)sizeTitle.Height + 5;
                }

                int y = textOffsetY;

                using (Brush b = new SolidBrush(ThemeManager.ForeColor))
                {
                    g.DrawString(data.Title, _fTitle, b, titleOffsetX, titleOffsetY);

                    int x = 5;

                    if (data.Values != null)
                    {
                        foreach (KeyValuePair<string, string> val in data.Values)
                        {
                            string key = Translator.Translate(val.Key.Trim());
                            string keyMeasure = string.IsNullOrEmpty(key) ? " " : key;
                            string valMeasure = string.IsNullOrEmpty(val.Value) ? " " : val.Value;

                            SizeF szKey = g.MeasureString(keyMeasure, _fKey);
                            SizeF szVal = g.MeasureString(valMeasure, _fVal);

                            if (!string.IsNullOrEmpty(val.Key))
                            {
                                g.DrawString(key, _fKey, b, x, y);
                            }

                            if (!string.IsNullOrEmpty(val.Value))
                            {
                                g.DrawString(val.Value, _fVal, b, x + szKey.Width, y);
                            }

                            y += (int)Math.Max(szKey.Height, szVal.Height) + 2;
                        }
                    }
                }
                
                if (data.CustomImage != null)
                {
                    y += 5;
                    int x = (data.Size.Width - data.CustomImage.Width) / 2;

                    g.DrawImage(data.CustomImage, x, y);
                }
            }
        }

        private Image GetScaledImage(Image img)
        {
            try
            {
                if (img != null)
                {
                    int sizeY = Math.Min(ImageMaxHeight, img.Height);
                    double factor = (double)sizeY / (double)img.Height;
                    int sizeX = (int)(factor * img.Width);

                    return ImageProvider.ScaleImage(img, new Size(sizeX, sizeY), true);
                }
            }
            catch 
            {
            }

            return null;
        }
    }
}
