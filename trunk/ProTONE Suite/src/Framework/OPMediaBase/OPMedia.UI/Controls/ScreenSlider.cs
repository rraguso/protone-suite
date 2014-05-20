using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime;
using System.Threading;
using OPMedia.UI.Themes;

namespace OPMedia.UI.Controls
{
    public delegate void ScreenChangedHandler(Control currentScreen);

    public enum SlideEffect
    {
        None = 0,
        SlideLeft,
        SlideRight,
    }

    public partial class ScreenSlider : OPMBaseControl
    {
        byte _currentScreen = 0;

        public ListWithEvents<Control> _screens = new ListWithEvents<Control>();

        public event ScreenChangedHandler ScreenChanged = null;

        System.Windows.Forms.Timer _tmrSlide = null;

        protected string Description
        {
            get { return lblDesc.Text; }
            set { lblDesc.Text = value; }
        }

        protected ListWithEvents<Control> Screens
        {
            get
            {
                return _screens;
            }
        }

        public void AddScreen(Control c)
        {
            _screens.Add(c);
            ShowCurrentScreen(SlideEffect.None);
        }

        public void RemoveScreen(Control c)
        {
            _screens.Remove(c);
            ShowCurrentScreen(SlideEffect.None);
        }

        private int _animStep = 0;
        const int _animMaxStep = 3;
        private SlideEffect _slideEffect = SlideEffect.None;

        public ScreenSlider()
        {
            InitializeComponent();
            ShowCurrentScreen(SlideEffect.None);

            _tmrSlide = new System.Windows.Forms.Timer();
            _tmrSlide.Interval = 20;
            _tmrSlide.Tick += new EventHandler(_tmrSlide_Tick);
            _tmrSlide.Enabled = false;

            ThemeManager.SetDoubleBuffer(pnlScreen);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_screens.Count > 1)
            {
                _currentScreen--;
                _currentScreen %= (byte)_screens.Count;
            }

            ShowCurrentScreen(SlideEffect.SlideRight);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_screens.Count > 1)
            {
                _currentScreen++;
                _currentScreen %= (byte)_screens.Count;
            }

            ShowCurrentScreen(SlideEffect.SlideRight);
        }

        private void ShowCurrentScreen(SlideEffect slideEffect)
        {
            Control oldControl = null;
            Control newControl = null;

            try
            {
                btnNext.Enabled = btnPrev.Enabled = _screens.Count > 1;
                if (_currentScreen >= 0 && _currentScreen < _screens.Count)
                {
                    newControl = _screens[_currentScreen];
                    if (newControl != null)
                    {
                        newControl.Dock = DockStyle.Fill;

                        if (slideEffect == SlideEffect.None)
                        {
                            AddNewControl(newControl);
                        }
                        else
                        {
                            if (slideEffect == SlideEffect.SlideLeft)
                            {
                                pnlScreen.ColumnStyles[0].SizeType = SizeType.Percent;
                                pnlScreen.ColumnStyles[0].Width = 100f;
                                pnlScreen.ColumnStyles[1].SizeType = SizeType.Percent;
                                pnlScreen.ColumnStyles[1].Width = 0f;

                                pnlScreen.Controls.Add(newControl, 1, 0);
                            }
                            else
                            {
                                pnlScreen.ColumnStyles[0].SizeType = SizeType.Percent;
                                pnlScreen.ColumnStyles[0].Width = 0f;
                                pnlScreen.ColumnStyles[1].SizeType = SizeType.Percent;
                                pnlScreen.ColumnStyles[1].Width = 100f;

                                if (oldControl != null)
                                    pnlScreen.SetColumn(oldControl, 1);

                                pnlScreen.Controls.Add(newControl, 0, 0);
                            }

                            // Start sliding
                            _slideEffect = slideEffect;
                            _animStep = 0;
                            _tmrSlide_Tick(this, EventArgs.Empty);
                        }
                    }
                }
            }
            finally
            {
            }
        }

        void _tmrSlide_Tick(object sender, EventArgs e)
        {
            Control newControl = null;

            try
            {
                this.SuspendLayout();
                pnlScreen.SuspendLayout();
                if (_currentScreen >= 0 && _currentScreen < _screens.Count)
                {
                    newControl = _screens[_currentScreen];
                    if (_slideEffect == SlideEffect.SlideLeft)
                    {
                        pnlScreen.ColumnStyles[0].Width = 100f * (_animMaxStep - _animStep) / _animMaxStep;
                        pnlScreen.ColumnStyles[1].Width = 100f * _animStep / _animMaxStep;
                    }
                    else
                    {
                        pnlScreen.ColumnStyles[0].Width = 100f * _animStep / _animMaxStep;
                        pnlScreen.ColumnStyles[1].Width = 100f * (_animMaxStep - _animStep) / _animMaxStep;
                    }
                }
            }
            finally
            {
                _animStep++;
                pnlScreen.ResumeLayout();
                this.ResumeLayout();
            }

            if (_animStep >= _animMaxStep)
            {
                _tmrSlide.Stop();
                AddNewControl(newControl);
            }
            else
            {
                _tmrSlide.Start();
            }
        }


        private void AddNewControl(Control newControl)
        {
            if (newControl != null)
            {
                pnlScreen.SuspendLayout();

                newControl.Dock = DockStyle.Fill;
                pnlScreen.ColumnStyles[0].SizeType = SizeType.Percent;
                pnlScreen.ColumnStyles[0].Width = 100f;
                pnlScreen.ColumnStyles[1].SizeType = SizeType.AutoSize;
                pnlScreen.ColumnStyles[1].Width = 100f;
                pnlScreen.Controls.Clear();
                pnlScreen.Controls.Add(newControl, 0, 0);

                pnlScreen.ResumeLayout();

                if (ScreenChanged != null)
                {
                    ScreenChanged(newControl);
                }
            }
        }
    }
}
