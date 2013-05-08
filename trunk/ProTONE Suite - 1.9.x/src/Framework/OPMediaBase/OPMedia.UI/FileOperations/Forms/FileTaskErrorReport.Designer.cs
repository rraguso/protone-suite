using OPMedia.UI.Controls;

namespace OPMedia.UI.FileTasks
{
    partial class FileTaskErrorReport
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
            this.btnOK = new OPMedia.UI.Controls.OPMButton();
            this.tvReports = new OPMedia.UI.Controls.OPMTreeView();
            this.lblDesc = new OPMedia.UI.Controls.OPMLabel();
            this.pbWarn = new System.Windows.Forms.PictureBox();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarn)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pbWarn);
            this.pnlContent.Controls.Add(this.lblDesc);
            this.pnlContent.Controls.Add(this.tvReports);
            this.pnlContent.Controls.Add(this.btnOK);
            this.pnlContent.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(460, 385);
            this.btnOK.Name = "btnOK";
            this.btnOK.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOK.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOK.Size = new System.Drawing.Size(72, 24);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "TXT_OK";
            // 
            // tvReports
            // 
            this.tvReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvReports.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvReports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvReports.Location = new System.Drawing.Point(10, 52);
            this.tvReports.Name = "tvReports";
            this.tvReports.Size = new System.Drawing.Size(522, 327);
            this.tvReports.TabIndex = 1;
            // 
            // lblDesc
            // 
            this.lblDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDesc.Location = new System.Drawing.Point(48, 10);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblDesc.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblDesc.Size = new System.Drawing.Size(112, 19);
            this.lblDesc.TabIndex = 0;
            this.lblDesc.Text = "TXT_ERRORSFOUND";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbWarn
            // 
            this.pbWarn.BackColor = System.Drawing.Color.Transparent;
            this.pbWarn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pbWarn.Location = new System.Drawing.Point(10, 10);
            this.pbWarn.Name = "pbWarn";
            this.pbWarn.Size = new System.Drawing.Size(32, 32);
            this.pbWarn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbWarn.TabIndex = 8;
            this.pbWarn.TabStop = false;
            // 
            // FileTaskErrorReport
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(544, 444);
            this.MaximumSize = new System.Drawing.Size(700, 800);
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "FileTaskErrorReport";
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbWarn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMButton btnOK;
        private OPMTreeView tvReports;
        private OPMLabel lblDesc;
        private System.Windows.Forms.PictureBox pbWarn;
    }
}