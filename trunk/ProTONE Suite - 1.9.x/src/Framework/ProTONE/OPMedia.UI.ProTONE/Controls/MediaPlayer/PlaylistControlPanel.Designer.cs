using System.Drawing;
using System.Windows.Forms;
using OPMedia.UI.Themes;

using OPMedia.UI.Controls;

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    partial class PlaylistControlPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSavePlaylist = new OPMedia.UI.Controls.OPMButton();
            this.btnLoadPlaylist = new OPMedia.UI.Controls.OPMButton();
            this.btnClear = new OPMedia.UI.Controls.OPMButton();
            this.btnDelete = new OPMedia.UI.Controls.OPMButton();
            this.btnMoveDown = new OPMedia.UI.Controls.OPMButton();
            this.btnMoveUp = new OPMedia.UI.Controls.OPMButton();
            this.pnlButtons = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.pnlButtons.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSavePlaylist
            // 
            this.btnSavePlaylist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSavePlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePlaylist.Location = new System.Drawing.Point(0, 115);
            this.btnSavePlaylist.Margin = new System.Windows.Forms.Padding(0);
            this.btnSavePlaylist.MinimumSize = new System.Drawing.Size(23, 23);
            this.btnSavePlaylist.Name = "btnSavePlaylist";
            this.btnSavePlaylist.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnSavePlaylist.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnSavePlaylist.Size = new System.Drawing.Size(23, 23);
            this.btnSavePlaylist.TabIndex = 6;
            this.btnSavePlaylist.TabStop = false;
            this.btnSavePlaylist.Tag = "btnSavePlaylist";
            this.btnSavePlaylist.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnSavePlaylist.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // btnLoadPlaylist
            // 
            this.btnLoadPlaylist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLoadPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadPlaylist.Location = new System.Drawing.Point(0, 92);
            this.btnLoadPlaylist.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoadPlaylist.MinimumSize = new System.Drawing.Size(23, 23);
            this.btnLoadPlaylist.Name = "btnLoadPlaylist";
            this.btnLoadPlaylist.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnLoadPlaylist.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnLoadPlaylist.Size = new System.Drawing.Size(23, 23);
            this.btnLoadPlaylist.TabIndex = 5;
            this.btnLoadPlaylist.TabStop = false;
            this.btnLoadPlaylist.Tag = "btnLoadPlaylist";
            this.btnLoadPlaylist.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnLoadPlaylist.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(0, 69);
            this.btnClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnClear.MinimumSize = new System.Drawing.Size(23, 23);
            this.btnClear.Name = "btnClear";
            this.btnClear.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnClear.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnClear.Size = new System.Drawing.Size(23, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.TabStop = false;
            this.btnClear.Tag = "btnClear";
            this.btnClear.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnClear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(0, 46);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.MinimumSize = new System.Drawing.Size(23, 23);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnDelete.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.TabStop = false;
            this.btnDelete.Tag = "btnDelete";
            this.btnDelete.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnDelete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveDown.Image = global::OPMedia.UI.ProTONE.Properties.Resources.MoveDown;
            this.btnMoveDown.Location = new System.Drawing.Point(0, 0);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnMoveDown.MinimumSize = new System.Drawing.Size(23, 23);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnMoveDown.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnMoveDown.Size = new System.Drawing.Size(23, 23);
            this.btnMoveDown.TabIndex = 2;
            this.btnMoveDown.TabStop = false;
            this.btnMoveDown.Tag = "btnMoveDown";
            this.btnMoveDown.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnMoveDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveUp.Location = new System.Drawing.Point(0, 23);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(0);
            this.btnMoveUp.MinimumSize = new System.Drawing.Size(23, 23);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnMoveUp.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnMoveUp.Size = new System.Drawing.Size(23, 23);
            this.btnMoveUp.TabIndex = 1;
            this.btnMoveUp.TabStop = false;
            this.btnMoveUp.Tag = "btnMoveUp";
            this.btnMoveUp.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnMoveUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // pnlButtons
            // 
            this.pnlButtons.AutoSize = true;
            this.pnlButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlButtons.Controls.Add(this.btnMoveDown);
            this.pnlButtons.Controls.Add(this.btnMoveUp);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnClear);
            this.pnlButtons.Controls.Add(this.btnLoadPlaylist);
            this.pnlButtons.Controls.Add(this.btnSavePlaylist);
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlButtons.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlButtons.Size = new System.Drawing.Size(23, 138);
            this.pnlButtons.TabIndex = 0;
            this.pnlButtons.WrapContents = false;
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.AutoSize = true;
            this.opmTableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmTableLayoutPanel1.ColumnCount = 2;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.Controls.Add(this.pnlButtons, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel1, 1, 0);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 1;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(29, 138);
            this.opmTableLayoutPanel1.TabIndex = 13;
            // 
            // opmLabel1
            // 
            this.opmLabel1.AutoSize = true;
            this.opmLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.opmLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel1.Location = new System.Drawing.Point(27, 0);
            this.opmLabel1.Name = "opmLabel1";
            this.opmLabel1.OverrideBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.opmLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel1.Size = new System.Drawing.Size(0, 138);
            this.opmLabel1.TabIndex = 1;
            this.opmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlaylistControlPanel
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PlaylistControlPanel";
            this.Size = new System.Drawing.Size(29, 138);
            this.pnlButtons.ResumeLayout(false);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMButton btnMoveUp;
        private OPMButton btnMoveDown;
        private OPMButton btnDelete;
        private OPMButton btnClear;
        private OPMButton btnLoadPlaylist;
        private OPMButton btnSavePlaylist;
        private OPMFlowLayoutPanel pnlButtons;
        private OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMLabel opmLabel1;
    }
}
