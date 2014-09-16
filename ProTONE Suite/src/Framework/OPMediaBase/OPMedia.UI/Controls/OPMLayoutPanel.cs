using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OPMedia.Core;
using System.ComponentModel;
using System.Drawing;

using OPMedia.UI.Themes;
using OPMedia.Core.GlobalEvents;

namespace OPMedia.UI.Controls
{
    public class OPMTableLayoutPanel : TableLayoutPanel
    {
        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color BackColor
        { get { return base.BackColor; } }

        Color _overrideBackColor = Color.Empty;
        public Color OverrideBackColor
        {
            get { return _overrideBackColor; }
            set
            {
                _overrideBackColor = value;
                ApplyBackColor();
            }
        }

        [EventSink(EventNames.ThemeUpdated)]
        public void ApplyBackColor()
        {
            if (_overrideBackColor == Color.Empty)
            {
                base.BackColor = ThemeManager.BackColor;
            }
            else
            {
                base.BackColor = _overrideBackColor;
            }

            Invalidate(true);
        }

        public OPMTableLayoutPanel()
            : base()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            ApplyBackColor();

            this.HandleCreated += (s, e) => EventDispatch.RegisterHandler(this);
            this.HandleDestroyed += (s, e) => EventDispatch.UnregisterHandler(this);
        }
    }

    public class OPMFlowLayoutPanel : FlowLayoutPanel
    {
        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color BackColor
        { get { return base.BackColor; } }

        Color _overrideBackColor = Color.Empty;
        public Color OverrideBackColor
        {
            get { return _overrideBackColor; }
            set
            {
                _overrideBackColor = value;
                ApplyBackColor();
            }
        }

        [EventSink(EventNames.ThemeUpdated)]
        public void ApplyBackColor()
        {
            if (_overrideBackColor == Color.Empty)
            {
                base.BackColor = ThemeManager.BackColor;
            }
            else
            {
                base.BackColor = _overrideBackColor;
            }

            Invalidate(true);
        }

        public OPMFlowLayoutPanel()
            : base()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            ApplyBackColor();

            this.HandleCreated += (s, e) => EventDispatch.RegisterHandler(this);
            this.HandleDestroyed += (s, e) => EventDispatch.UnregisterHandler(this);
        }
    }
}
