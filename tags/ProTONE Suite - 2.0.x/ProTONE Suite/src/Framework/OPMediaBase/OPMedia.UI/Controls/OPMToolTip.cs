﻿using System;
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
using OPMedia.Core.Logging;

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

        static Control __generic = new Control();

        private Dictionary<Control, OPMToolTipData> _data = new Dictionary<Control, OPMToolTipData>();

        Font _fVal = ThemeManager.SmallestFont;
        Font _fKey = ThemeManager.SmallFont;
        Font _fTitle = ThemeManager.LargeFont;
        static Font _def = new Font("Segoe UI", 12.0f, FontStyle.Regular, GraphicsUnit.World);

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

       

        private string AssignData(Control ctl, string title, Dictionary<string, string> values, Image titleImage, Image customImage)
        {
            titleImage = GetScaledImage(titleImage);
            customImage = GetScaledImage(customImage);

            if (ctl == null)
            {
                ctl = __generic;
            }

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
                    ControlPaint.Light(ThemeManager.GradientNormalColor1), 
                    ControlPaint.Light(ThemeManager.GradientNormalColor2), 90))
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

    public class OPMToolTipManager
    {
        private OPMToolTip _tip = null;
        private Control _ctl = null;

        public int AutomaticDelay { get; set; }
        public int AutoPopDelay { get; set; }
        public int InitialDelay { get; set; }
        public int ReshowDelay { get; set; }

        public void ShowSimpleToolTip(string text, Image img = null)
        {
            //Logger.LogTrace("ShowSimpleToolTip");

            if (ToolTipCreated())
            {
                //Logger.LogTrace("    > before SetSimpleToolTip");
                _tip.SetSimpleToolTip(_ctl, text, img);
            }
        }

        public void ShowToolTip(string title, Dictionary<string, string> values = null, Image img = null, Image customImage = null)
        {
            //Logger.LogTrace("ShowToolTip");

            if (ToolTipCreated())
            {
                //Logger.LogTrace("    > before SetToolTip");
                _tip.SetToolTip(_ctl, title, values, img, customImage);
            }
        }

        public OPMToolTipManager(Control ctl)
        {
            int autoDelay = 500;
            this.AutomaticDelay = autoDelay; 
            this.AutoPopDelay = 10 * autoDelay;
            this.InitialDelay = 2 * autoDelay;
            this.ReshowDelay = 2 * autoDelay;

            _ctl = ctl;
            _ctl.MouseMove += new MouseEventHandler(_ctl_MouseMove);
        }

        void _ctl_MouseMove(object sender, MouseEventArgs e)
        {
            //Logger.LogTrace("_ctl_MouseMove");

            Point pos = new Point(Cursor.Position.X, Cursor.Position.Y);
            if (_pos != Point.Empty)
            {
                int dx = Math.Abs(_pos.X - pos.X);
                int dy = Math.Abs(_pos.Y - pos.Y);

                if (dx > 3 || dy > 3)
                {
                    RemoveAll();
                }
            }
        }

        private bool ToolTipCreated()
        {
            //Logger.LogTrace("ToolTipCreated");

            try
            {
                RemoveAll();
                
                _tip = new OPMToolTip();
                _tip.AutomaticDelay = this.AutomaticDelay;
                _tip.AutoPopDelay = this.AutoPopDelay;
                _tip.InitialDelay = this.InitialDelay;
                _tip.ReshowDelay = this.ReshowDelay;

                _tip.Disposed += new EventHandler(_tip_Disposed);
                _tip.Popup += new PopupEventHandler(_tip_Popup);

                //Logger.LogTrace("ToolTipCreated -> return True");

                return true;
            }
            catch(Exception ex)
            {
                //Logger.LogTrace("ToolTipCreated esxception: {0}", ex.ToString());
                //Logger.LogTrace("ToolTipCreated -> return False");
                return false;
            }
        }

        Point _pos = Point.Empty;

        void _tip_Popup(object sender, PopupEventArgs e)
        {
            //Logger.LogTrace("_tip_Popup");
            _pos = new Point(Cursor.Position.X, Cursor.Position.Y);
        }

        void _tip_Disposed(object sender, EventArgs e)
        {
            if (sender == _tip)
            {
                //Logger.LogTrace("_tip_Disposed");

                _tip = null;
                _pos = Point.Empty;
            }
        }

        public void RemoveAll()
        {
            //Logger.LogTrace_WithStackDump("RemoveAll");

            if (_tip != null)
            {
                //Logger.LogTrace("RemoveAll => Hide");

                _tip.Hide(_ctl);
                _tip.Dispose();
                _tip = null;
                _pos = Point.Empty;
            }
        }
    }
}
