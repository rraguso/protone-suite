using OPMedia.UI.Controls;
using OPMedia.UI.Themes;
using System.Windows.Forms;


namespace OPMedia.UI
{
    partial class SettingsForm
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
            this.layoutPanel = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.tsOptionList = new OPMedia.UI.Controls.OPMToolStrip();
            this.pnlButtons = new OPMedia.UI.Controls.OPMPanel();
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.btnOk = new OPMedia.UI.Controls.OPMButton();
            this.pnlOptions = new OPMedia.UI.Controls.OPMPanel();
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pbPanelImage = new System.Windows.Forms.PictureBox();
            this.lblPanelTitle = new OPMedia.UI.Controls.OPMLabel();
            this.pnlContent.SuspendLayout();
            this.layoutPanel.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPanelImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.layoutPanel);
            // 
            // layoutPanel
            // 
            this.layoutPanel.ColumnCount = 2;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.Controls.Add(this.tsOptionList, 0, 0);
            this.layoutPanel.Controls.Add(this.pnlButtons, 1, 2);
            this.layoutPanel.Controls.Add(this.pnlOptions, 1, 1);
            this.layoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.OverrideBackColor = System.Drawing.Color.Empty;
            this.layoutPanel.RowCount = 3;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.layoutPanel.Size = new System.Drawing.Size(540, 442);
            this.layoutPanel.TabIndex = 4;
            this.layoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.layoutPanel_Paint);
            // 
            // tsOptionList
            // 
            this.tsOptionList.AllowMerge = false;
            this.tsOptionList.AutoSize = false;
            this.tsOptionList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.tsOptionList.CanOverflow = false;
            this.tsOptionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsOptionList.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsOptionList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsOptionList.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsOptionList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsOptionList.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.tsOptionList.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsOptionList.Location = new System.Drawing.Point(0, 0);
            this.tsOptionList.Name = "tsOptionList";
            this.tsOptionList.Padding = new System.Windows.Forms.Padding(0);
            this.layoutPanel.SetRowSpan(this.tsOptionList, 3);
            this.tsOptionList.ShowBorder = true;
            this.tsOptionList.Size = new System.Drawing.Size(100, 442);
            this.tsOptionList.Stretch = true;
            this.tsOptionList.TabIndex = 0;
            this.tsOptionList.TabStop = true;
            this.tsOptionList.VerticalGradient = false;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnOk);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pnlButtons.Location = new System.Drawing.Point(100, 418);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(440, 24);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(367, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(72, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "TXT_CANCEL";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(289, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOk.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOk.Size = new System.Drawing.Size(72, 24);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "TXT_OK";
            // 
            // pnlOptions
            // 
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOptions.Location = new System.Drawing.Point(105, 45);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(435, 368);
            this.pnlOptions.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pbPanelImage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPanelTitle, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(100, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(440, 37);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pbPanelImage
            // 
            this.pbPanelImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPanelImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pbPanelImage.Location = new System.Drawing.Point(5, 5);
            this.pbPanelImage.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.pbPanelImage.MaximumSize = new System.Drawing.Size(32, 32);
            this.pbPanelImage.MinimumSize = new System.Drawing.Size(32, 32);
            this.pbPanelImage.Name = "pbPanelImage";
            this.pbPanelImage.Size = new System.Drawing.Size(32, 32);
            this.pbPanelImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPanelImage.TabIndex = 0;
            this.pbPanelImage.TabStop = false;
            // 
            // lblPanelTitle
            // 
            this.lblPanelTitle.AutoSize = true;
            this.lblPanelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPanelTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPanelTitle.FontSize = OPMedia.UI.Themes.FontSizes.VeryLarge;
            this.lblPanelTitle.Location = new System.Drawing.Point(42, 5);
            this.lblPanelTitle.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lblPanelTitle.Name = "lblPanelTitle";
            this.lblPanelTitle.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblPanelTitle.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblPanelTitle.Size = new System.Drawing.Size(398, 32);
            this.lblPanelTitle.TabIndex = 0;
            this.lblPanelTitle.Text = "kryptonLabel1";
            this.lblPanelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(550, 470);
            this.Name = "SettingsForm";
            this.pnlContent.ResumeLayout(false);
            this.layoutPanel.ResumeLayout(false);
            this.layoutPanel.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPanelImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMTableLayoutPanel layoutPanel;
        private OPMPanel pnlButtons;
        private OPMPanel pnlOptions;
        private OPMTableLayoutPanel tableLayoutPanel1;
        private PictureBox pbPanelImage;
        private OPMLabel lblPanelTitle;
        private OPMToolStrip tsOptionList;
        protected OPMButton btnCancel;
        protected OPMButton btnOk;



    }
}