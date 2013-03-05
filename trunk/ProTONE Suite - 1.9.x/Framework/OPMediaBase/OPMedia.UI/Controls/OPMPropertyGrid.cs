using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OPMedia.UI.Themes;
using OPMedia.Core.GlobalEvents;
using OPMedia.Core;
using System.ComponentModel;
using System.Drawing;

namespace OPMedia.UI.Controls
{
    public class OPMPropertyGrid : PropertyGrid
    {
        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color ViewForeColor { get { return base.ForeColor; } }

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color ViewBackColor { get { return base.ForeColor; } }

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color CategoryForeColor { get { return base.ForeColor; } }

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color LineColor { get { return base.ForeColor; } }


        public OPMPropertyGrid()
            : base()
        {
            ApplyTheme(); 
            
            EventDispatch.RegisterHandler(this);
            this.HandleDestroyed += new EventHandler(OPMPropertyGrid_HandleDestroyed);
        }

        void OPMPropertyGrid_HandleDestroyed(object sender, EventArgs e)
        {
            EventDispatch.UnregisterHandler(this);
        }

        [EventSink(EventNames.ThemeUpdated)]
        public void ApplyTheme()
        {
            base.ViewForeColor = ThemeManager.WndTextColor;
            base.ViewBackColor = ThemeManager.WndValidColor;
            base.CategoryForeColor = ThemeManager.ForeColor;
            base.LineColor = ThemeManager.BackColor;
        }
    }
}
