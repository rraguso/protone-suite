using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace OPMedia.UI.Controls
{
    [DesignerCategory("code")]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip)]
    public class OPMStatusStripTextBox : ToolStripControlHost
    {
        public OPMStatusStripTextBox()
            : base(new OPMTextBox())
        {
        }
    }

}
