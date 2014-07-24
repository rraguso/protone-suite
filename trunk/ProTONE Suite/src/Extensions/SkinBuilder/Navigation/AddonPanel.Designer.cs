namespace SkinBuilder.Navigation
{
    partial class AddonPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddonPanel));
            this.toolStripMain = new OPMedia.UI.Controls.OPMToolStrip();
            this.tsbNew = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbOpen = new OPMedia.UI.Controls.OPMToolStripSplitButton();
            this.tsbSave = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbSaveAs = new OPMedia.UI.Controls.OPMToolStripButton();
            this.opmToolStripSeparator1 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsbNewTheme = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbDeleteTheme = new OPMedia.UI.Controls.OPMToolStripButton();
            this.opmToolStripSeparator2 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.opmToolStripButton1 = new OPMedia.UI.Controls.OPMToolStripButton();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.tvThemes = new OPMedia.UI.Controls.OPMTreeView();
            this.toolStripMain.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.AllowMerge = false;
            this.toolStripMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.toolStripMain.CanOverflow = false;
            this.toolStripMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbOpen,
            this.tsbSave,
            this.tsbSaveAs,
            this.opmToolStripSeparator1,
            this.tsbNewTheme,
            this.tsbDeleteTheme,
            this.opmToolStripSeparator2,
            this.opmToolStripButton1});
            this.toolStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Padding = new System.Windows.Forms.Padding(0);
            this.toolStripMain.ShowBorder = true;
            this.toolStripMain.Size = new System.Drawing.Size(563, 47);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.VerticalGradient = true;
            // 
            // tsbNew
            // 
            this.tsbNew.Image = global::SkinBuilder.Properties.Resources.New;
            this.tsbNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(63, 44);
            this.tsbNew.Tag = "ToolActionNew";
            this.tsbNew.Text = "TXT_NEW";
            this.tsbNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNew.ToolTipText = "Create new catalog";
            this.tsbNew.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = global::SkinBuilder.Properties.Resources.Open;
            this.tsbOpen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsbOpen.Size = new System.Drawing.Size(80, 44);
            this.tsbOpen.Tag = "ToolActionOpen";
            this.tsbOpen.Text = "TXT_OPEN";
            this.tsbOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbOpen.ToolTipText = "Open catalog";
            this.tsbOpen.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbSave
            // 
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = global::SkinBuilder.Properties.Resources.Save;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(64, 44);
            this.tsbSave.Tag = "ToolActionSave";
            this.tsbSave.Text = "TXT_SAVE";
            this.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSave.Click += new System.EventHandler(this.OnToolAction);
            // 
            // tsbSaveAs
            // 
            this.tsbSaveAs.Enabled = false;
            this.tsbSaveAs.Image = global::SkinBuilder.Properties.Resources.SaveAs;
            this.tsbSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAs.Name = "tsbSaveAs";
            this.tsbSaveAs.Size = new System.Drawing.Size(83, 44);
            this.tsbSaveAs.Tag = "ToolActionSaveAs";
            this.tsbSaveAs.Text = "TXT_SAVE_AS";
            this.tsbSaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSaveAs.Click += new System.EventHandler(this.OnToolAction);
            // 
            // opmToolStripSeparator1
            // 
            this.opmToolStripSeparator1.Name = "opmToolStripSeparator1";
            this.opmToolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // tsbNewTheme
            // 
            this.tsbNewTheme.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewTheme.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewTheme.Image")));
            this.tsbNewTheme.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewTheme.Name = "tsbNewTheme";
            this.tsbNewTheme.Size = new System.Drawing.Size(29, 44);
            this.tsbNewTheme.Text = "TXT_NEW_THEME";
            // 
            // tsbDeleteTheme
            // 
            this.tsbDeleteTheme.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteTheme.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteTheme.Image")));
            this.tsbDeleteTheme.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteTheme.Name = "tsbDeleteTheme";
            this.tsbDeleteTheme.Size = new System.Drawing.Size(29, 44);
            this.tsbDeleteTheme.Text = "TXT_DELETE_THEME";
            // 
            // opmToolStripSeparator2
            // 
            this.opmToolStripSeparator2.Name = "opmToolStripSeparator2";
            this.opmToolStripSeparator2.Size = new System.Drawing.Size(6, 47);
            // 
            // opmToolStripButton1
            // 
            this.opmToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.opmToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("opmToolStripButton1.Image")));
            this.opmToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.opmToolStripButton1.Name = "opmToolStripButton1";
            this.opmToolStripButton1.Size = new System.Drawing.Size(29, 44);
            this.opmToolStripButton1.Text = "opmToolStripButton1";
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 1;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Controls.Add(this.toolStripMain, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.tvThemes, 0, 1);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 2;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(563, 484);
            this.opmTableLayoutPanel1.TabIndex = 2;
            // 
            // tvThemes
            // 
            this.tvThemes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvThemes.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvThemes.Location = new System.Drawing.Point(3, 50);
            this.tvThemes.Name = "tvThemes";
            this.tvThemes.Size = new System.Drawing.Size(557, 431);
            this.tvThemes.TabIndex = 2;
            // 
            // AddonPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.Name = "AddonPanel";
            this.Size = new System.Drawing.Size(563, 484);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private OPMedia.UI.Controls.OPMToolStrip toolStripMain;
        private OPMedia.UI.Controls.OPMToolStripButton tsbNew;
        private OPMedia.UI.Controls.OPMToolStripSplitButton tsbOpen;
        private OPMedia.UI.Controls.OPMToolStripButton tsbSave;
        private OPMedia.UI.Controls.OPMToolStripButton tsbSaveAs;
        private OPMedia.UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMedia.UI.Controls.OPMToolStripButton tsbNewTheme;
        private OPMedia.UI.Controls.OPMToolStripButton tsbDeleteTheme;
        private OPMedia.UI.Controls.OPMToolStripSeparator opmToolStripSeparator1;
        private OPMedia.UI.Controls.OPMToolStripSeparator opmToolStripSeparator2;
        private OPMedia.UI.Controls.OPMToolStripButton opmToolStripButton1;
        private OPMedia.UI.Controls.OPMTreeView tvThemes;
    }
}
