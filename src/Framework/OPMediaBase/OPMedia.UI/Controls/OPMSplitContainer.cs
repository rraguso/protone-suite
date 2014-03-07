﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using OPMedia.UI.Themes;
using System.Drawing;
using OPMedia.Core;
using OPMedia.Core.GlobalEvents;

namespace OPMedia.UI.Controls
{
    public class OPMSplitContainer : SplitContainer
    {
        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color BackColor { get { return base.BackColor; } }

        public OPMSplitContainer()
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
            base.BackColor = ThemeManager.SelectedColor;
        }

    }
}
