namespace OPMedia.UI.ProTONE.Controls.MediaPlayer.Screens
{
    partial class TrackInfoScreen
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
            this.pgProperties = new OPMedia.UI.Controls.OPMPropertyGrid();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.lblItem = new OPMedia.UI.Controls.OPMLabel();
            this.playlistScreen = new OPMedia.UI.ProTONE.Controls.MediaPlayer.PlaylistScreen();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgProperties
            // 
            this.pgProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgProperties.HelpVisible = false;
            this.pgProperties.Location = new System.Drawing.Point(163, 24);
            this.pgProperties.Margin = new System.Windows.Forms.Padding(5);
            this.pgProperties.Name = "pgProperties";
            this.pgProperties.Size = new System.Drawing.Size(148, 264);
            this.pgProperties.TabIndex = 1;
            this.pgProperties.ToolbarVisible = false;
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 2;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.opmTableLayoutPanel1.Controls.Add(this.lblItem, 1, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.pgProperties, 1, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.playlistScreen, 0, 0);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 2;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(316, 293);
            this.opmTableLayoutPanel1.TabIndex = 2;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblItem.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.lblItem.Location = new System.Drawing.Point(158, 3);
            this.lblItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblItem.Name = "lblItem";
            this.lblItem.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblItem.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblItem.Size = new System.Drawing.Size(158, 13);
            this.lblItem.TabIndex = 1;
            this.lblItem.Text = "[ item ]";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // playlistScreen
            // 
            this.playlistScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playlistScreen.CompactMode = true;
            this.playlistScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlistScreen.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.playlistScreen.Location = new System.Drawing.Point(0, 0);
            this.playlistScreen.Margin = new System.Windows.Forms.Padding(0);
            this.playlistScreen.Name = "playlistScreen";
            this.playlistScreen.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.SetRowSpan(this.playlistScreen, 2);
            this.playlistScreen.Size = new System.Drawing.Size(158, 293);
            this.playlistScreen.TabIndex = 5;
            // 
            // TrackInfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.Name = "TrackInfoScreen";
            this.Size = new System.Drawing.Size(316, 293);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.OPMPropertyGrid pgProperties;
        private UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private UI.Controls.OPMLabel lblItem;
        private PlaylistScreen playlistScreen;
    }
}
