
using OPMedia.UI.Controls;
using System.Windows.Forms;
namespace OPMedia.UI.ProTONE.SubtitleDownload
{
    partial class SubtitleDownloadNotifyForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvSubtitles = new OPMedia.UI.Controls.OPMListView();
            this.colFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLanguage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDownload = new OPMedia.UI.Controls.OPMButton();
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.opmLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlContent.SuspendLayout();
            this.opmLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.opmLayoutPanel1);
            // 
            // lvSubtitles
            // 
            this.lvSubtitles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFileName,
            this.colServer,
            this.colPrio,
            this.colLanguage,
            this.colSize});
            this.opmLayoutPanel1.SetColumnSpan(this.lvSubtitles, 2);
            this.lvSubtitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSubtitles.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.lvSubtitles.Location = new System.Drawing.Point(3, 3);
            this.lvSubtitles.MultiSelect = false;
            this.lvSubtitles.Name = "lvSubtitles";
            this.lvSubtitles.OverrideBackColor = System.Drawing.Color.Empty;
            this.lvSubtitles.Size = new System.Drawing.Size(804, 304);
            this.lvSubtitles.TabIndex = 0;
            this.lvSubtitles.UseCompatibleStateImageBehavior = false;
            this.lvSubtitles.View = System.Windows.Forms.View.Details;
            this.lvSubtitles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvSubtitles_ColumnClick);
            // 
            // colFileName
            // 
            this.colFileName.Name = "colFileName";
            this.colFileName.Text = "TXT_FILENAME";
            // 
            // colServer
            // 
            this.colServer.Name = "colServer";
            this.colServer.Text = "TXT_SERVER";
            this.colServer.Width = 84;
            // 
            // colPrio
            // 
            this.colPrio.Name = "colPrio";
            this.colPrio.Text = "TXT_PRIO";
            this.colPrio.Width = 72;
            // 
            // colLanguage
            // 
            this.colLanguage.Name = "colLanguage";
            this.colLanguage.Text = "TXT_LANGUAGE";
            this.colLanguage.Width = 99;
            // 
            // colSize
            // 
            this.colSize.Name = "colSize";
            this.colSize.Text = "TXT_SIZE";
            this.colSize.Width = 70;
            // 
            // btnDownload
            // 
            this.btnDownload.AutoSize = true;
            this.btnDownload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Location = new System.Drawing.Point(712, 313);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnDownload.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnDownload.Size = new System.Drawing.Size(95, 25);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "TXT_SUB_LOAD";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.label1.Location = new System.Drawing.Point(3, 310);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(703, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "TXT_SUB_HINTS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opmLayoutPanel1
            // 
            this.opmLayoutPanel1.ColumnCount = 2;
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmLayoutPanel1.Controls.Add(this.btnDownload, 1, 1);
            this.opmLayoutPanel1.Controls.Add(this.lvSubtitles, 0, 0);
            this.opmLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.opmLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmLayoutPanel1.Name = "opmLayoutPanel1";
            this.opmLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLayoutPanel1.RowCount = 2;
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.Size = new System.Drawing.Size(810, 341);
            this.opmLayoutPanel1.TabIndex = 0;
            // 
            // SubtitleDownloadNotifyForm
            // 
            this.ClientSize = new System.Drawing.Size(820, 369);
            this.Name = "SubtitleDownloadNotifyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlContent.ResumeLayout(false);
            this.opmLayoutPanel1.ResumeLayout(false);
            this.opmLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMListView lvSubtitles;
        private OPMButton btnDownload;
        private OPMLabel label1;
        private System.Windows.Forms.ColumnHeader colFileName;
        private System.Windows.Forms.ColumnHeader colServer;
        private System.Windows.Forms.ColumnHeader colPrio;
        private System.Windows.Forms.ColumnHeader colLanguage;
        private System.Windows.Forms.ColumnHeader colSize;
        private UI.Controls.OPMTableLayoutPanel opmLayoutPanel1;
    }
}