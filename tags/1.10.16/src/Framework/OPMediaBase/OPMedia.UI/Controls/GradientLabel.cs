using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using System.Drawing.Drawing2D;
using OPMedia.UI.Themes;

namespace OPMedia.UI.Controls
{
    public partial class GradientLabel : OPMBaseControl
    {
        public GradientLabel() : base()
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ThemeManager.PrepareGraphics(g);

            Color cl1 = ThemeManager.GradientLTColor;
            Color cl2 = ThemeManager.GradientRBColor;

            using (Brush b1 = new LinearGradientBrush(ClientRectangle, cl1, cl2, -90f))
            {
                using (Brush b2 = new LinearGradientBrush(ClientRectangle, cl1, cl2, 90f))
                {
                    g.FillRectangle(b1, ClientRectangle);
                    g.DrawString(Text, Font, b2, ClientRectangle);
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GradientLabel
            // 
            this.Name = "GradientLabel";
            this.ResumeLayout(false);

        }
    }
}
