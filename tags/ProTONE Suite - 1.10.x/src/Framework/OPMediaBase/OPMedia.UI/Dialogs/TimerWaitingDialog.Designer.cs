using OPMedia.UI.Controls;

namespace OPMedia.UI.Dialogs
{
    partial class TimerWaitingDialog
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
            this.lblNotifyText = new OPMedia.UI.Controls.OPMLabel();
            this.pbWaiting = new OPMedia.UI.Controls.OPMProgressBar();
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.btnOK = new OPMedia.UI.Controls.OPMButton();
            this.lblTimer = new OPMedia.UI.Controls.OPMLabel();
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.tableLayoutPanel2 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.flowLayoutPanel1 = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.pnlContent.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.tableLayoutPanel1);
            // 
            // lblNotifyText
            // 
            this.lblNotifyText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNotifyText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNotifyText.Location = new System.Drawing.Point(3, 0);
            this.lblNotifyText.Name = "lblNotifyText";
            this.lblNotifyText.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblNotifyText.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblNotifyText.Size = new System.Drawing.Size(399, 126);
            this.lblNotifyText.TabIndex = 1;
            this.lblNotifyText.Text = "bla\r\nblabla\r\nblablabla\r\n\r\nblablablabla\r\nblablablablabla";
            this.lblNotifyText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbWaiting
            // 
            this.pbWaiting.AllowDragging = false;
            this.pbWaiting.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbWaiting.Enabled = false;
            this.pbWaiting.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.pbWaiting.Location = new System.Drawing.Point(3, 3);
            this.pbWaiting.Maximum = 100D;
            this.pbWaiting.Name = "pbWaiting";
            this.pbWaiting.NrTicks = 20;
            this.pbWaiting.OverrideBackColor = System.Drawing.Color.Empty;
            this.pbWaiting.ShowTicks = false;
            this.pbWaiting.Size = new System.Drawing.Size(344, 14);
            this.pbWaiting.TabIndex = 0;
            this.pbWaiting.Value = 0D;
            this.pbWaiting.Vertical = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(81, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(72, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "TXT_ABORT";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(3, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOK.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOK.Size = new System.Drawing.Size(72, 24);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "TXT_PROCEED";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTimer.Location = new System.Drawing.Point(353, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblTimer.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblTimer.Size = new System.Drawing.Size(49, 20);
            this.lblTimer.TabIndex = 1;
            this.lblTimer.Text = "00:00:00";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNotifyText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(405, 182);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.lblTimer, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pbWaiting, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 126);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(405, 20);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnOK);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(246, 149);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(156, 30);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // TimerWaitingDialog
            // 
            this.AllowResize = true;
            this.ClientSize = new System.Drawing.Size(415, 210);
            this.Name = "TimerWaitingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.pnlContent.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OPMLabel lblNotifyText;
        private OPMProgressBar pbWaiting;
        private OPMButton btnCancel;
        private OPMButton btnOK;
        private OPMLabel lblTimer;
        private OPMTableLayoutPanel tableLayoutPanel1;
        private OPMFlowLayoutPanel flowLayoutPanel1;
        private OPMTableLayoutPanel tableLayoutPanel2;
    }
}