using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OPMedia.UI.Generic
{
    public class GuiHelper
    {
    }

    public class StringAlignments
    {
        public StringAlignment Alignment { get; private set; }
        public StringAlignment LineAlignment { get; private set; }

        private StringAlignments() { }

        public static StringAlignments FromContentAlignment(ContentAlignment ca)
        {
            Int32 lNum = (Int32)Math.Log((Double)ca, 2);
            StringAlignments sa = new StringAlignments();
            sa.LineAlignment = (StringAlignment)(lNum / 4);
            sa.Alignment = (StringAlignment)(lNum % 4);
            return sa;
        }

        public static StringAlignments FromHorizontalAlignment(HorizontalAlignment ha)
        {
            StringAlignments sa = new StringAlignments();
            sa.LineAlignment = StringAlignment.Center;
            switch(ha)
            {
                case HorizontalAlignment.Center:
                    sa.Alignment = StringAlignment.Center;
                    break;
                case HorizontalAlignment.Left:
                    sa.Alignment = StringAlignment.Near;
                    break;
                case HorizontalAlignment.Right:
                    sa.Alignment = StringAlignment.Far;
                    break;
            }

            return sa;
        }
    }
}
