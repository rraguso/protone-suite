using OPMedia.UI.Controls;

namespace OPMedia.UI.Dialogs
{
    partial class InsertDriveNotifyDialog
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
            this.components = new System.ComponentModel.Container();
            this.tmrRescan = new System.Windows.Forms.Timer(this.components);
            this.lblNotifyText = new OPMedia.UI.Controls.OPMLabel();
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.pictureBox1 = new OPMedia.UI.Controls.WaitingPictureBox();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.opmTableLayoutPanel1);
            // 
            // tmrRescan
            // 
            this.tmrRescan.Enabled = true;
            this.tmrRescan.Interval = 3000;
            this.tmrRescan.Tick += new System.EventHandler(this.tmrRescan_Tick);
            // 
            // lblNotifyText
            // 
            this.lblNotifyText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNotifyText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNotifyText.Location = new System.Drawing.Point(49, 0);
            this.lblNotifyText.Name = "lblNotifyText";
            this.lblNotifyText.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblNotifyText.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblNotifyText.Size = new System.Drawing.Size(242, 61);
            this.lblNotifyText.TabIndex = 0;
            this.lblNotifyText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(211, 67);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "TXT_CANCEL";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 2;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Controls.Add(this.btnCancel, 1, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.lblNotifyText, 1, 0);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 2;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(294, 95);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // InsertDriveNotifyDialog
            // 
            this.ClientSize = new System.Drawing.Size(304, 123);
            this.Name = "InsertDriveNotifyDialog";
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrRescan;
        private OPMLabel lblNotifyText;
        private OPMButton btnCancel;
        private WaitingPictureBox pictureBox1;
        private OPMTableLayoutPanel opmTableLayoutPanel1;
    }
}