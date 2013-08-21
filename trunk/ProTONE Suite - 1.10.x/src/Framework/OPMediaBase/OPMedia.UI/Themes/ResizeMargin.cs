using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace OPMedia.UI.Themes
{
    public class ResizeMargin : UserControl
    {
        public ResizeMargin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ResizeMargin
            // 
            this.BackColor = System.Drawing.Color.Blue;
            this.Name = "ResizeMargin";
            this.Size = new System.Drawing.Size(352, 322);
            this.ResumeLayout(false);

        }
    }
}
