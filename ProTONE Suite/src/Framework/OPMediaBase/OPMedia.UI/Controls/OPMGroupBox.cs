using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.Core;
using OPMedia.Core.GlobalEvents;
using System.ComponentModel;

namespace OPMedia.UI.Controls
{
    public class OPMGroupBox : GroupBox
    {
        #region Members
        /// <summary>
        /// The actual border color
        /// </summary>
        private Color borderColor = ThemeManager.BorderColor;
        #endregion

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color ForeColor { get { return base.ForeColor; } }

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color BackColor { get { return base.BackColor; } }

        #region Construction
        /// <summary>
        /// Standard contructor.
        /// Calls also the base class constructor.
        /// </summary>
        public OPMGroupBox()
            : base()
        {
            base.BackColor = ThemeManager.BackColor;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            
            EventDispatch.RegisterHandler(this);
            base.HandleDestroyed += new EventHandler(OPMTableLayoutPanel_HandleDestroyed);
        }

        void OPMTableLayoutPanel_HandleDestroyed(object sender, EventArgs e)
        {
            EventDispatch.UnregisterHandler(this);
        }

        [EventSink(EventNames.ThemeUpdated)]
        public void OnThemeUpdated()
        {
            base.BackColor = ThemeManager.BackColor;
            Invalidate(true);
        }
        #endregion

        #region Implementation
       

        /// <summary>
        /// Override for the Paint procedure.
        /// This is done in order to draw our customized border.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Let the control draw itself first.
            // (otherwise the control will overwrite our border !)
            //base.OnPaint(e);

            StringFormat format = new StringFormat();

            // When && character pair is in the string, this leads to a wrong text 
            // size calculation in MeasureString.
            // But on UI:
            // - a single & stands for underline, so must be replaced with nothing;
            // - a double && stands in fact for &, so must be replaced with &.
            string realText = this.Text;
            if (realText.IndexOf("&&") >= 0)
            {
                // We have at least a && in the string.
                realText = realText.Replace("&&", "&");
            }

            Size textSize = Size.Ceiling(e.Graphics.MeasureString(realText, this.Font,
                ClientRectangle.Width, format));

            // How far from the margins is the text drawn.
            int offsetX = 8;
            int offsetY = 1 + textSize.Height / 2;

            Color cb = Enabled ? ThemeManager.BorderColor : ThemeManager.GradientNormalColor2;
            Color cText = Enabled ? ThemeManager.ForeColor : Color.FromKnownColor(KnownColor.ControlDark);

            // Careful not to give a "strikethrough" effect on the text.
            using (Pen pen = new Pen(cb))
            {
                e.Graphics.DrawLine(pen, 0, offsetY, 0, base.Height - 2);
                e.Graphics.DrawLine(pen, 0, base.Height - 2, base.Width - 2, base.Height - 2);
                e.Graphics.DrawLine(pen, 0, offsetY - 1, offsetX, offsetY - 1);
                e.Graphics.DrawLine(pen, offsetX + textSize.Width, offsetY - 1, base.Width - 2, offsetY - 1);
                e.Graphics.DrawLine(pen, base.Width - 2, offsetY, base.Width - 2, base.Height - 2);
            }

            // Draw the text
            using (Brush b = new SolidBrush(cText))
            {
                e.Graphics.DrawString(realText, Font, b, offsetX + 4, 0);
            }
        }
        #endregion
    }
}

