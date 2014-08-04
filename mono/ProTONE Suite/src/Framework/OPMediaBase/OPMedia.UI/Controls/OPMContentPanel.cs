using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using OPMedia.Core;
using OPMedia.Core.GlobalEvents;


namespace OPMedia.UI.Themes
{
    public class ContentPanel : Panel
    {
        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new AnchorStyles Anchor
        { get { return base.Anchor; } }

        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Point Location
        { get { return base.Location; } }

        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Size Size
        { get { return base.Size; } }


        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Font Font
        { get { return base.Font; } }


        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color BackColor { get { return base.BackColor; } }

        internal void SetLocation(Point newLocation)
        {
            base.Location = newLocation;
        }

        internal void SetSize(Size newSize)
        {
            base.Size = newSize;
        }

        public ContentPanel()
            : base()
        {
            base.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeManager.PrepareGraphics(e.Graphics);
            using (Brush b = new SolidBrush(ThemeManager.BackColor))
            {
                e.Graphics.FillRectangle(b, ClientRectangle);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            
        }
    }
}
