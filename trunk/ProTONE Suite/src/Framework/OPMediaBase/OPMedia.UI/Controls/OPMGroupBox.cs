using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.Core;
using OPMedia.Core.GlobalEvents;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using OPMedia.UI.Generic;

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

            this.HandleCreated += (s, e) => EventDispatch.RegisterHandler(this);
            this.HandleDestroyed += (s, e) => EventDispatch.UnregisterHandler(this);
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
            ThemeManager.PrepareGraphics(e.Graphics);

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
            int offsetX = 16;
            int offsetY = 1 + textSize.Height / 2;

            Color cb = Enabled ? ThemeManager.BorderColor : ThemeManager.GradientNormalColor2;
            Color cText = Enabled ? ThemeManager.ForeColor : Color.FromKnownColor(KnownColor.ControlDark);

            Rectangle rcBorder = new Rectangle
            (
                ClientRectangle.Left,
                ClientRectangle.Top + offsetY,
                ClientRectangle.Width - 1,
                ClientRectangle.Height - offsetY - 1
            );

            using (Pen pen = new Pen(cb))
            using (Pen penEraser = new Pen(ThemeManager.BackColor))
            using (GraphicsPath path = ImageProcessing.GenerateRoundCornersBorder(rcBorder, ThemeManager.CornerSize))
            {
                e.Graphics.DrawPath(pen, path);

                // Careful not to give a "strikethrough" effect on the text.
                e.Graphics.DrawLine(penEraser, offsetX, offsetY, offsetX + textSize.Width, offsetY);
            }

            // Draw the text
            using (Brush b = new SolidBrush(cText))
            {
                e.Graphics.DrawString(realText, Font, b, offsetX, 0);
            }
        }
        #endregion
    }
}

