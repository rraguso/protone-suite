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
    public class OPMDoubleBufferedControl : OPMBaseControl
    {
        const BufferedGraphics NO_MANAGED_BACK_BUFFER = null;

        BufferedGraphicsContext GraphicManager;
        BufferedGraphics ManagedBackBuffer;

        public OPMDoubleBufferedControl()
            : base()
        {
            this.HandleDestroyed += new EventHandler(OnHandleDestroyed);
            this.Resize += new EventHandler(OnResize);

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            GraphicManager = BufferedGraphicsManager.Current;
            GraphicManager.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
            ManagedBackBuffer = GraphicManager.Allocate(this.CreateGraphics(), ClientRectangle);
        }

        void OnResize(object sender, EventArgs e)
        {
            if (ManagedBackBuffer != NO_MANAGED_BACK_BUFFER)
                ManagedBackBuffer.Dispose();

            GraphicManager.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);

            ManagedBackBuffer = GraphicManager.Allocate(this.CreateGraphics(), ClientRectangle);

            this.Invalidate();
        }

        void OnHandleDestroyed(object sender, EventArgs e)
        {
            // clean up the memory
            if (ManagedBackBuffer != NO_MANAGED_BACK_BUFFER)
                ManagedBackBuffer.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // we draw the progressbar into the image in 
            // the memory
            PaintEventArgs e1 = new PaintEventArgs(ManagedBackBuffer.Graphics, e.ClipRectangle);

            using (Brush b = new SolidBrush(this.BackColor))
            {
                e1.Graphics.FillRectangle(b, ClientRectangle);
            }

            OnRenderGraphics(e1);

            // now we draw the image into the screen
            ManagedBackBuffer.Render(e.Graphics);
        }

        protected virtual void OnRenderGraphics(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }

}
