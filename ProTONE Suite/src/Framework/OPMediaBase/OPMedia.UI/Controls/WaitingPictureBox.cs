using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using System.Drawing;
using OPMedia.UI.Properties;
using System.ComponentModel;
using OPMedia.Core;

namespace OPMedia.UI.Controls
{
    public class WaitingPictureBox : PictureBox
    {
        private int _i = 1;
        private System.Timers.Timer _timer = null;

        Bitmap _startImage = null;

        private readonly List<int[]> _fillerPatterns = new List<int[]>()
        {
            new int[] { 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 1 },
            new int[] { 0, 0, 1, 1 },
            new int[] { 0, 1, 1, 1 },
            new int[] { 1, 1, 1, 1 },
            new int[] { 1, 1, 1, 2 },
            new int[] { 1, 1, 2, 2 },
            new int[] { 1, 2, 2, 2 },
            new int[] { 2, 2, 2, 2 },
            new int[] { 2, 2, 2, 1 },
            new int[] { 2, 2, 1, 1 },
            new int[] { 2, 1, 1, 1 },
            new int[] { 1, 1, 1, 1 },
            new int[] { 1, 1, 1, 0 },
            new int[] { 1, 1, 0, 0 },
            new int[] { 1, 0, 0, 0 },
            new int[] { 0, 0, 0, 0 },
        };

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image Image
        {
            get
            {
                return base.Image;
            }
        }

        int _period = 200;
        //public int AnimationTimer
        //{
        //    get
        //    {
        //        return _period;
        //    }

        //    set
        //    {
        //        _period = value; UpdateTimer();
        //    }
        //}

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size MinimumSize
        {
            get { return base.MinimumSize; }
        }

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size MaximumSize
        {
            get { return base.MaximumSize; }
        }
        
        public WaitingPictureBox()
            : base()
        {
            _startImage = Resources.waitframe;
            this.HandleCreated += new EventHandler(WaitingPictureBox_HandleCreated);

            base.MinimumSize = new Size(36, 8);
            base.MaximumSize = new Size(36, 8);
        }

        void WaitingPictureBox_HandleCreated(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                UpdateTimer();
            }
        }

        private void UpdateTimer()
        {
            if (_timer == null)
            {
                _timer = new System.Timers.Timer();
                _timer.Interval = _period;
                _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
                _timer.Enabled = true;
            }
            else
            {
                _timer.Enabled = false;
                _timer.Interval = _period;
                _timer.Enabled = true;
            }
        }

        //void _timer_Tick(object sender, EventArgs e)
        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                _timer.Enabled = false;
                _i %= _fillerPatterns.Count;

                Bitmap image = GetImageForCurrentStep();
                if (image != null)
                {
                    image.MakeTransparent(Color.Magenta);
                }

                MainThread.Post((d) => { base.Image = image; Application.DoEvents(); });
            }
            catch{}
            finally 
            {
                _i++;
                _timer.Enabled = true;
            }
        }

        private Bitmap GetImageForCurrentStep()
        {
            Color c1 = ThemeManager.GradientHoverColor1;
            Color c2 = ThemeManager.GradientHoverColor2;
            Color c3 = ThemeManager.GradientNormalColor2;

            int[] fillerPattern = _fillerPatterns[_i];
            Color[] filler = new Color[fillerPattern.Length];

            for (int i = 0; i < fillerPattern.Length; i++)
            {
                int f = fillerPattern[i];
                switch (f)
                {
                    case 0:
                        filler[i] = c1;
                        break;
                    case 1:
                        filler[i] = c2;
                        break;
                    case 2:
                        filler[i] = c3;
                        break;
                }
            }
           
            return GenerateImage(filler);
        }

        private Bitmap GenerateImage(Color[] filler)
        {
            Bitmap bmp = _startImage.Clone() as Bitmap;

            for (int i = 1; i < bmp.Width - 1; i++)
            for (int j = 1; j < bmp.Height - 1; j++)
            {
                if (i % 9 == 0 || i % 9 == 7 || i % 9 == 8)
                    continue;

                int idx = i / 9;
                try
                {
                    if (filler[idx] != Color.Empty)
                    {
                        bmp.SetPixel(i, j, filler[idx]);
                    }
                }
                catch { }
            }

            return bmp;
        }
    }
}
