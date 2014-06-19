using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.Core;
using OPMedia.UI.Themes;
using OPMedia.Runtime.Shortcuts;

using OPMedia.Runtime;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.GlobalEvents;



namespace OPMedia.UI.Controls
{
    
    public class OPMBaseControl : UserControl
    {
        protected FontSizes _fontSize = FontSizes.Normal;

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color BackColor { get { return base.BackColor; } }

        protected Color _overrideBackColor = Color.Empty;
        public Color OverrideBackColor 
        {
            get { return _overrideBackColor; }
            set
            {
                _overrideBackColor = value;
                ApplyBackColor();
            }
        }

        [EventSink(EventNames.ThemeUpdated)]
        public void OnThemeUpdated()
        {
            OnThemeUpdatedInternal();
        }

        protected virtual void OnThemeUpdatedInternal()
        {
            ApplyBackColor();
        }

        private void ApplyBackColor()
        {
            if (_overrideBackColor == Color.Empty)
            {
                base.BackColor = ThemeManager.BackColor;
            }
            else
            {
                base.BackColor = _overrideBackColor;
            }

            Invalidate(true);
        }
        
        public FontSizes FontSize
        {
            get
            {
                return _fontSize;
            }

            set
            {
                _fontSize = value;

                base.Font = this.Font;

                foreach (Control ctl in this.Controls)
                {
                    if (ctl is OPMBaseControl)
                    {
                        (ctl as OPMBaseControl).FontSize = value;
                    }
                    else
                    {
                        ctl.Font = this.Font;
                    }
                }
            }
        }

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Font Font
        {
            get
            {
                return ThemeManager.GetFontBySize(_fontSize);
            }
        }

        public OPMBaseControl() : base()
        {
            InitializeComponent();

            ApplyBackColor();
            
            this.FontSize = FontSizes.Normal;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.DoubleBuffered = true;

            EventDispatch.RegisterHandler(this);
            this.HandleDestroyed += new EventHandler(OPMBaseControl_HandleDestroyed);
        }

        void OPMBaseControl_HandleDestroyed(object sender, EventArgs e)
        {
            EventDispatch.UnregisterHandler(this);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // OPMUserControl
            // 
            this.Name = "OPMUserControl";
            this.ResumeLayout(false);
        }
    }

}
