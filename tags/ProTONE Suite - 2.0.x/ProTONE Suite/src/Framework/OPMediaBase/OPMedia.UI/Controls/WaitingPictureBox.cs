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
using System.Drawing.Imaging;

namespace OPMedia.UI.Controls
{
    public class WaitingPictureBox : PictureBox
    {
        private System.Timers.Timer _timer = null;

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image Image
        {
            get
            {
                return base.Image;
            }
        }

        int _period = 300;
        private int _currentFrame = -1;

        ImageList _frames = null;

        public WaitingPictureBox()
            : base()
        {
            Bitmap gifImage = Resources.waiting;
            FrameDimension dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
            int frameCount = gifImage.GetFrameCount(dimension);

            _frames = new ImageList();
            _frames.ImageSize = gifImage.Size;
            _frames.ColorDepth = ColorDepth.Depth32Bit;
            _frames.TransparentColor = gifImage.GetPixel(0, 0);

            for (int i = 0; i < frameCount; i++)
            {
                gifImage.SelectActiveFrame(dimension, i);
                _frames.Images.Add(gifImage.Clone() as Bitmap);
            }

            this.HandleCreated += new EventHandler(WaitingPictureBox_HandleCreated);
        }

        void WaitingPictureBox_HandleCreated(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                UpdateTimer();
                DisplayNextFrame();
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
                MainThread.Post((d) => DisplayNextFrame());
            }
            catch{}
            finally 
            {
                _timer.Enabled = true;
            }
        }

        private void DisplayNextFrame()
        {
            Bitmap frame = GetNextFrame() as Bitmap;
            if (frame != null)
            {
                base.Image = frame;
            }
            Application.DoEvents();

        }

        private Image GetNextFrame()
        {
            _currentFrame += 1;
            _currentFrame %= _frames.Images.Count;
            return _frames.Images[_currentFrame];
        }
    }
}
