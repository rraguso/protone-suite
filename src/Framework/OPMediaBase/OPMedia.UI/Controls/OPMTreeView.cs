﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;

using System.Drawing;
using System.ComponentModel;
using OPMedia.Core;
using OPMedia.Core.GlobalEvents;

namespace OPMedia.UI.Controls
{

    public class OPMTreeView : TreeView
    {
        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color BackColor { get { return base.BackColor; } }

        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color ForeColor { get { return base.ForeColor; } }

        public OPMTreeView()
            : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.ResizeRedraw = true;
            this.DoubleBuffered = true;
            this.DrawMode = TreeViewDrawMode.OwnerDrawText;

            OnThemeUpdated();

            this.DrawNode += new DrawTreeNodeEventHandler(OPMTreeView_DrawNode);

            EventDispatch.RegisterHandler(this);
            this.HandleDestroyed += new EventHandler(OPMTreeView_HandleDestroyed);
        }

        void OPMTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.State != TreeNodeStates.Selected || !e.Node.IsSelected)
            {
                e.DrawDefault = true;
                return;
            }

            ThemeManager.PrepareGraphics(e.Graphics);

            Font f = e.Node.NodeFont;
            if (f == null)
            {
                f = this.Font;
            }
            if (f == null)
            {
                f = ThemeManager.NormalFont;
            }

            SizeF sz = e.Graphics.MeasureString(e.Node.Text, f);
            RectangleF rc = new RectangleF(e.Bounds.Left, e.Bounds.Top, sz.Width, sz.Height);

            Rectangle rcx = e.Bounds;
            rcx.Inflate(2, 2);

            using (Brush b = new SolidBrush(ThemeManager.BackColor))
            using (Brush bBack = new SolidBrush(ThemeManager.SelectedColor))
            using (Brush bFore = new SolidBrush(ThemeManager.ForeColor))
            {
                e.Graphics.FillRectangle(b, rcx);
                e.Graphics.FillRectangle(bBack, rc);

                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;
                sf.FormatFlags = StringFormatFlags.NoWrap;
                sf.Trimming = StringTrimming.EllipsisWord;

                e.Graphics.DrawString(e.Node.Text, f, bFore, rc, sf);
            }
        }

        void OPMTreeView_HandleDestroyed(object sender, EventArgs e)
        {
            EventDispatch.UnregisterHandler(this);
        }

        [EventSink(EventNames.ThemeUpdated)]
        public void OnThemeUpdated()
        {
            base.BackColor = ThemeManager.BackColor;
            base.ForeColor = ThemeManager.ForeColor;
        }

        public TreeNode FindNode(string nodeText, bool compareNoCase)
        {
            foreach (TreeNode node in Nodes)
            {
                TreeNode childNode = FindNode(node, nodeText, compareNoCase);
                if (childNode != null)
                {
                    return childNode;
                }
            }

            return null;
        }

        TreeNode FindNode(TreeNode startNode, string nodeText, bool compareNoCase)
        {
            if (string.Compare(startNode.Text, nodeText, compareNoCase) == 0)
            {
                return startNode;
            }

            foreach (TreeNode node in startNode.Nodes)
            {
                TreeNode childNode = FindNode(node, nodeText, compareNoCase);
                if (childNode != null)
                {
                    return childNode;
                }
            }

            return null;
        }

        
    }

}
