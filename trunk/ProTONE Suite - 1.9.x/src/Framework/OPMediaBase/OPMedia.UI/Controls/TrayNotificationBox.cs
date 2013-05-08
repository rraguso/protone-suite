using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Core;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Themes;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Timers;
using System.Diagnostics;
using OPMedia.Core.Logging;

namespace OPMedia.UI.Controls
{
    public enum TransparencyState
    {
        Increasing = 0,
        Full,
        Decreasing
    }

    public enum AnimationType
    {
        None = 0,
        Dissolve,
        Slide
    }

    public partial class TrayNotificationBox : Form
    {
        OPMToolTipData data = null;

        TransparencyState _ts = TransparencyState.Increasing;

        Font _fVal = ThemeManager.SmallFont;
        Font _fKey = new Font(ThemeManager.SmallFont, FontStyle.Bold);
        Font _fTitle = ThemeManager.LargeFont;
        static Font _def = new Font("Segoe UI", 12.0f, FontStyle.Regular, GraphicsUnit.World);

        System.Windows.Forms.Timer _tmrAnimation = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer _tmrHide = new System.Windows.Forms.Timer();

        public AnimationType AnimationType { get; set; }
        public int HideDelay { get; set; }

        public void ShowSimple(string text, Image img = null)
        {
            Dictionary<string, string> d = null;
            if (text != null)
            {
                d = new Dictionary<string, string>();
                d.Add(text, string.Empty);
            }

            this.Show(Translator.Translate("TXT_APP_NAME"), d,
                img ?? ImageProvider.ApplicationIconLarge);
        }

        public void Show(string title, Dictionary<string, string> values = null, Image img = null)
        {
            AssignData(title, values, img);
            User32.ShowWindow(Handle, ShowWindowStyles.SW_SHOWNOACTIVATE);
        }

        int showLocation = 0;

        public TrayNotificationBox()
        {
            InitializeComponent();

            this.Opacity = 1;
            this.AnimationType = UI.Controls.AnimationType.Dissolve;

            HideDelay = 6000;
            this.ShowInTaskbar = false;
            this.Paint += new PaintEventHandler(TrayNotificationBox_Paint);
            this.HandleCreated += new EventHandler(TrayNotificationBox_HandleCreated);
        }

        void TrayNotificationBox_HandleCreated(object sender, EventArgs e)
        {
            if (AnimationType != UI.Controls.AnimationType.None)
            {
                _tmrAnimation.Interval = HideDelay / 50;
                //_tmrAnimation.AutoReset = true;
                _tmrAnimation.Tick += new EventHandler(_tmrAnimation_Tick);
                _tmrAnimation.Start();
            }

            if (AnimationType == UI.Controls.AnimationType.Dissolve)
            {
                this.Opacity = 0;
            }


            _tmrHide.Interval = HideDelay;
            //_tmrHide.AutoReset = true;
            _tmrHide.Tick += new EventHandler(_tmrHide_Tick);
            _tmrHide.Start();
        }

        int _animationStep = 0;

        void _tmrAnimation_Tick(object sender, EventArgs e)
        {
            try
            {
                _tmrAnimation.Stop();

                if (AnimationType == UI.Controls.AnimationType.Dissolve)
                {
                    double opacity = this.Opacity;

                    switch (_ts)
                    {
                        case TransparencyState.Increasing:
                            opacity += 0.1f;
                            break;

                        case TransparencyState.Decreasing:
                            opacity -= 0.1f;
                            break;

                        case TransparencyState.Full:
                            // No action
                            return;
                    }

                    Opacity = opacity;
                }
                else if (AnimationType == UI.Controls.AnimationType.Slide)
                {
                    int step = this.Height / 10;

                    switch (_ts)
                    {
                        case TransparencyState.Increasing:
                            showLocation -= step;
                            break;

                        case TransparencyState.Decreasing:
                            showLocation += step;
                            break;

                        case TransparencyState.Full:
                            // No action
                            return;
                    }

                    Location = new Point(Location.X, showLocation);

                    Debug.WriteLine("(TEST) showLocation: {0}", this.Location);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            finally
            {
                _animationStep++;

                if (_animationStep >= 10 && _animationStep < 30 || _animationStep > 40)
                {
                    _ts = TransparencyState.Full;
                }
                else if (_animationStep >= 30)
                {
                    _ts = TransparencyState.Decreasing;
                }
                else
                {
                    _ts = TransparencyState.Increasing;
                }

                _tmrAnimation.Start();
            }
        }

        void _tmrHide_Tick(object sender, EventArgs e)
        {
            if (AnimationType != UI.Controls.AnimationType.None)
            {
                _tmrAnimation.Stop();
                _tmrAnimation.Tick -= new EventHandler(_tmrAnimation_Tick);
            }

            _tmrHide.Stop();
            _tmrHide.Tick -= new EventHandler(_tmrHide_Tick);

            this.Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TrayNotificationBox
            // 
            this.ClientSize = new System.Drawing.Size(172, 153);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TrayNotificationBox";
            this.ResumeLayout(false);
        }


        private void AssignData(string title, Dictionary<string, string> values, Image img)
        {
            data = new OPMToolTipData { Values = values, TitleImage = img, Title = title };
            base.Size = CalculateSize(data);
            base.Location = CalculateLocation();
        }

        private Point CalculateLocation()
        {
            int x = SystemInformation.WorkingArea.Right - base.Size.Width - 1;
            int y = SystemInformation.WorkingArea.Bottom - base.Size.Height - 1;

            if (AnimationType == UI.Controls.AnimationType.Slide)
            {
                y = SystemInformation.WorkingArea.Bottom;
                showLocation = y;
            }

            return new Point(x, y);
        }

        private Size CalculateSize(OPMToolTipData data)
        {
            int x = 0, y = 0;

            if (data != null)
            {
                int titleOffsetX = 5;
                int titleOffsetY = 5;

                using (Graphics g = CreateGraphics())
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
                }
            }

            x += 10;
            y += 10;

            return new Size(x, y);
        }

        void TrayNotificationBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.CompositingMode = CompositingMode.SourceOver;
            e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            using (LinearGradientBrush b = new LinearGradientBrush(ClientRectangle,
                ThemeManager.GradientLTColor, ThemeManager.GradientMColor, 90))
            {
                e.Graphics.FillRectangle(b, ClientRectangle);
            }

            using (Pen p = new Pen(ThemeManager.BorderColor))
            {
                Rectangle rc = new Rectangle(ClientRectangle.Location,
                    new Size(ClientRectangle.Width - 1, ClientRectangle.Height - 1));

                e.Graphics.DrawRectangle(p, rc);
            }

            DrawContents(e.Graphics);
        }

        private void DrawContents(Graphics g)
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

                using (Brush b = new SolidBrush(ThemeManager.ForeColor))
                {
                    g.DrawString(data.Title, _fTitle, b, titleOffsetX, titleOffsetY);

                    int x = 5;
                    int y = textOffsetY;

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
            }
        }
    }
}
