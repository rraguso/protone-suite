using OPMedia.UI.Controls;
namespace OPMedia.UI.FileTasks
{
    partial class FileTaskForm
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
            this.pnlLayout = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pbCurrent = new OPMedia.UI.Controls.OPMProgressBar();
            this.lblCurrentProgress = new OPMedia.UI.Controls.OPMLabel();
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.pbOperation = new OPMedia.UI.Controls.OPMProgressBar();
            this.txtCurFile = new OPMedia.UI.Controls.OPMLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnlContent.SuspendLayout();
            this.pnlLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlLayout);
            // 
            // pnlLayout
            // 
            this.pnlLayout.AutoSize = true;
            this.pnlLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlLayout.ColumnCount = 1;
            this.pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLayout.Controls.Add(this.pbCurrent, 0, 3);
            this.pnlLayout.Controls.Add(this.lblCurrentProgress, 0, 0);
            this.pnlLayout.Controls.Add(this.btnCancel, 0, 3);
            this.pnlLayout.Controls.Add(this.pbOperation, 0, 1);
            this.pnlLayout.Controls.Add(this.txtCurFile, 0, 2);
            this.pnlLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLayout.Location = new System.Drawing.Point(0, 0);
            this.pnlLayout.Name = "pnlLayout";
            this.pnlLayout.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlLayout.RowCount = 4;
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLayout.Size = new System.Drawing.Size(509, 121);
            this.pnlLayout.TabIndex = 0;
            // 
            // pbCurrent
            // 
            this.pbCurrent.AllowDragging = false;
            this.pbCurrent.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCurrent.Enabled = false;
            this.pbCurrent.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.pbCurrent.Location = new System.Drawing.Point(5, 70);
            this.pbCurrent.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pbCurrent.Maximum = 10000D;
            this.pbCurrent.Name = "pbCurrent";
            this.pbCurrent.NrTicks = 20;
            this.pbCurrent.OverrideBackColor = System.Drawing.Color.Empty;
            this.pbCurrent.ShowTicks = false;
            this.pbCurrent.Size = new System.Drawing.Size(499, 14);
            this.pbCurrent.TabIndex = 3;
            this.pbCurrent.Value = 0D;
            this.pbCurrent.Vertical = false;
            // 
            // lblCurrentProgress
            // 
            this.lblCurrentProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCurrentProgress.Location = new System.Drawing.Point(5, 10);
            this.lblCurrentProgress.Margin = new System.Windows.Forms.Padding(5, 10, 0, 5);
            this.lblCurrentProgress.Name = "lblCurrentProgress";
            this.lblCurrentProgress.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblCurrentProgress.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblCurrentProgress.Size = new System.Drawing.Size(504, 13);
            this.lblCurrentProgress.TabIndex = 0;
            this.lblCurrentProgress.Text = "TXT_CUR_PROGRESS";
            this.lblCurrentProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(429, 94);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 10, 5, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "TXT_ABORT";
            this.btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // pbOperation
            // 
            this.pbOperation.AllowDragging = false;
            this.pbOperation.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbOperation.Enabled = false;
            this.pbOperation.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.pbOperation.Location = new System.Drawing.Point(5, 28);
            this.pbOperation.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pbOperation.Maximum = 10000D;
            this.pbOperation.Name = "pbOperation";
            this.pbOperation.NrTicks = 20;
            this.pbOperation.OverrideBackColor = System.Drawing.Color.Empty;
            this.pbOperation.ShowTicks = false;
            this.pbOperation.Size = new System.Drawing.Size(499, 14);
            this.pbOperation.TabIndex = 1;
            this.pbOperation.Value = 0D;
            this.pbOperation.Vertical = false;
            // 
            // txtCurFile
            // 
            this.txtCurFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCurFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtCurFile.Location = new System.Drawing.Point(5, 52);
            this.txtCurFile.Margin = new System.Windows.Forms.Padding(5, 10, 0, 5);
            this.txtCurFile.Name = "txtCurFile";
            this.txtCurFile.OverrideBackColor = System.Drawing.Color.Empty;
            this.txtCurFile.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtCurFile.Size = new System.Drawing.Size(504, 13);
            this.txtCurFile.TabIndex = 2;
            this.txtCurFile.Text = "TXT_WAIT_COPY";
            this.txtCurFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 200;
            this.timer.Tick += new System.EventHandler(this.OnVerifyTimer);
            // 
            // FileTaskForm
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(519, 149);
            this.Name = "FileTaskForm";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlLayout.ResumeLayout(false);
            this.pnlLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMTableLayoutPanel pnlLayout;
        protected OPMLabel lblCurrentProgress;
        protected OPMButton btnCancel;
        protected Controls.OPMProgressBar pbOperation;
        protected OPMLabel txtCurFile;
        protected Controls.OPMProgressBar pbCurrent;
        private System.Windows.Forms.Timer timer;
    }
}