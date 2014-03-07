using OPMedia.UI.Controls;
namespace OPMedia.UI.ProTONE.Dialogs
{
    partial class BookmarkManager
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
            this.panel1 = new OPMedia.UI.Controls.OPMPanel();
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.btnOK = new OPMedia.UI.Controls.OPMButton();
            this.bookmarkManagerCtl = new OPMedia.UI.ProTONE.Controls.BookmarkManagement.BookmarkManagerCtl();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlContent.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.opmTableLayoutPanel1);
            // 
            // panel1
            // 
            this.opmTableLayoutPanel1.SetColumnSpan(this.panel1, 3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 2);
            this.panel1.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(247, 274);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "TXT_CANCEL";
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(186, 274);
            this.btnOK.Name = "btnOK";
            this.btnOK.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOK.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOK.Size = new System.Drawing.Size(55, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "TXT_OK";
            // 
            // bookmarkManagerCtl
            // 
            this.bookmarkManagerCtl.CanAddToCurrent = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.bookmarkManagerCtl, 3);
            this.bookmarkManagerCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookmarkManagerCtl.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.bookmarkManagerCtl.Location = new System.Drawing.Point(0, 0);
            this.bookmarkManagerCtl.Margin = new System.Windows.Forms.Padding(0);
            this.bookmarkManagerCtl.Name = "bookmarkManagerCtl";
            this.bookmarkManagerCtl.OverrideBackColor = System.Drawing.Color.Empty;
            this.bookmarkManagerCtl.PlaylistItem = null;
            this.bookmarkManagerCtl.Size = new System.Drawing.Size(330, 263);
            this.bookmarkManagerCtl.TabIndex = 0;
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 3;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.Controls.Add(this.btnCancel, 2, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.bookmarkManagerCtl, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.btnOK, 1, 2);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 3;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(330, 302);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // BookmarkManager
            // 
            this.ClientSize = new System.Drawing.Size(340, 330);
            this.MinimumSize = new System.Drawing.Size(340, 330);
            this.Name = "BookmarkManager";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlContent.ResumeLayout(false);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMedia.UI.ProTONE.Controls.BookmarkManagement.BookmarkManagerCtl bookmarkManagerCtl;
        private OPMPanel panel1;
        private OPMButton btnCancel;
        private OPMButton btnOK;
        private OPMTableLayoutPanel opmTableLayoutPanel1;

    }
}