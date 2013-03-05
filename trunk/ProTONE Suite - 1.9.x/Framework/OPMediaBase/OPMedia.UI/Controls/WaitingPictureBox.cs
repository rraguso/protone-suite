using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using System.Drawing;
using OPMedia.UI.Properties;
using System.ComponentModel;

namespace OPMedia.UI.Controls
{
    public class WaitingPictureBox : PictureBox
    {
        private int _i = 1;
        private Timer _timer = null;

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image Image
        {
            get
            {
                return base.Image;
            }
        }

        int _period = 150;
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

        public WaitingPictureBox()
            : base()
        {
            this.HandleCreated += new EventHandler(WaitingPictureBox_HandleCreated);
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
                _timer = new Timer();
                _timer.Interval = _period;
                _timer.Tick += new EventHandler(_timer_Tick);
                _timer.Enabled = true;
            }
            else
            {
                _timer.Enabled = false;
                _timer.Interval = _period;
                _timer.Enabled = true;
            }
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            try
            {
                _timer.Enabled = false;
                _i %= 8;

                string picName = string.Format("waitframe{0}", _i);

                Bitmap image = Resources.ResourceManager.GetImage(picName);
                if (image != null)
                {
                    image.MakeTransparent(Color.Magenta);
                }
                base.Image = image;
            }
            catch { }
            finally 
            {
                _i++;
                _timer.Enabled = true;
            }
        }
    }
}
