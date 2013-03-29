
using OPMedia.UI.Controls;
namespace OPMedia.UI
{
    partial class MessageDisplay
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
            this.btn2 = new OPMedia.UI.Controls.OPMButton();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.lblText = new OPMedia.UI.Controls.OPMLabel();
            this.btn1 = new OPMedia.UI.Controls.OPMButton();
            this.btn3 = new OPMedia.UI.Controls.OPMButton();
            this.pnlContentAll = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlButtons = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.btn4 = new OPMedia.UI.Controls.OPMButton();
            this.btn5 = new OPMedia.UI.Controls.OPMButton();
            this.pnlContentMessage = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.chkAdditionalCheck = new OPMedia.UI.Controls.OPMCheckBox();
            this.lblThirdPartyNotice = new OPMedia.UI.Controls.TransparentRichTextBox();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.pnlContentAll.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlContentMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlContentAll);
            this.pnlContent.TabIndex = 1;
            // 
            // btn2
            // 
            this.btn2.AutoSize = true;
            this.btn2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn2.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.Location = new System.Drawing.Point(135, 3);
            this.btn2.MinimumSize = new System.Drawing.Size(60, 25);
            this.btn2.Name = "btn2";
            this.btn2.OverrideBackColor = System.Drawing.Color.Empty;
            this.btn2.OverrideForeColor = System.Drawing.Color.Empty;
            this.btn2.Size = new System.Drawing.Size(60, 25);
            this.btn2.TabIndex = 2;
            this.btn2.Text = "[2]";
            this.btn2.Visible = false;
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.Transparent;
            this.pbImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pbImage.Location = new System.Drawing.Point(3, 3);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(40, 40);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbImage.TabIndex = 5;
            this.pbImage.TabStop = false;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblText.Location = new System.Drawing.Point(49, 3);
            this.lblText.Margin = new System.Windows.Forms.Padding(3);
            this.lblText.Name = "lblText";
            this.lblText.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblText.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblText.Size = new System.Drawing.Size(143, 40);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "label1 gv gdsrg fstg ret tre";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn1
            // 
            this.btn1.AutoSize = true;
            this.btn1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Location = new System.Drawing.Point(69, 3);
            this.btn1.MinimumSize = new System.Drawing.Size(60, 25);
            this.btn1.Name = "btn1";
            this.btn1.OverrideBackColor = System.Drawing.Color.Empty;
            this.btn1.OverrideForeColor = System.Drawing.Color.Empty;
            this.btn1.Size = new System.Drawing.Size(60, 25);
            this.btn1.TabIndex = 1;
            this.btn1.Text = "[1]";
            // 
            // btn3
            // 
            this.btn3.AutoSize = true;
            this.btn3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.Location = new System.Drawing.Point(201, 3);
            this.btn3.MinimumSize = new System.Drawing.Size(60, 25);
            this.btn3.Name = "btn3";
            this.btn3.OverrideBackColor = System.Drawing.Color.Empty;
            this.btn3.OverrideForeColor = System.Drawing.Color.Empty;
            this.btn3.Size = new System.Drawing.Size(60, 25);
            this.btn3.TabIndex = 3;
            this.btn3.Text = "[3]";
            this.btn3.Visible = false;
            // 
            // pnlContentAll
            // 
            this.pnlContentAll.AutoSize = true;
            this.pnlContentAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContentAll.ColumnCount = 1;
            this.pnlContentAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlContentAll.Controls.Add(this.pnlButtons, 0, 2);
            this.pnlContentAll.Controls.Add(this.pnlContentMessage, 0, 0);
            this.pnlContentAll.Controls.Add(this.chkAdditionalCheck, 0, 3);
            this.pnlContentAll.Controls.Add(this.lblThirdPartyNotice, 0, 1);
            this.pnlContentAll.Location = new System.Drawing.Point(0, 0);
            this.pnlContentAll.Name = "pnlContentAll";
            this.pnlContentAll.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlContentAll.RowCount = 4;
            this.pnlContentAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlContentAll.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlContentAll.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlContentAll.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlContentAll.Size = new System.Drawing.Size(352, 113);
            this.pnlContentAll.TabIndex = 6;
            // 
            // pnlButtons
            // 
            this.pnlButtons.AutoSize = true;
            this.pnlButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlButtons.ColumnCount = 7;
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlButtons.Controls.Add(this.btn4, 5, 0);
            this.pnlButtons.Controls.Add(this.btn3, 4, 0);
            this.pnlButtons.Controls.Add(this.btn2, 3, 0);
            this.pnlButtons.Controls.Add(this.btn1, 2, 0);
            this.pnlButtons.Controls.Add(this.btn5, 1, 0);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(0, 59);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlButtons.RowCount = 1;
            this.pnlButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlButtons.Size = new System.Drawing.Size(352, 31);
            this.pnlButtons.TabIndex = 2;
            // 
            // btn4
            // 
            this.btn4.AutoSize = true;
            this.btn4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.Location = new System.Drawing.Point(289, 3);
            this.btn4.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.btn4.MinimumSize = new System.Drawing.Size(60, 25);
            this.btn4.Name = "btn4";
            this.btn4.OverrideBackColor = System.Drawing.Color.Empty;
            this.btn4.OverrideForeColor = System.Drawing.Color.Empty;
            this.btn4.Size = new System.Drawing.Size(60, 25);
            this.btn4.TabIndex = 4;
            this.btn4.Text = "[4]";
            this.btn4.Visible = false;
            // 
            // btn5
            // 
            this.btn5.AutoSize = true;
            this.btn5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.Location = new System.Drawing.Point(3, 3);
            this.btn5.MinimumSize = new System.Drawing.Size(60, 25);
            this.btn5.Name = "btn5";
            this.btn5.OverrideBackColor = System.Drawing.Color.Empty;
            this.btn5.OverrideForeColor = System.Drawing.Color.Empty;
            this.btn5.Size = new System.Drawing.Size(60, 25);
            this.btn5.TabIndex = 0;
            this.btn5.Text = "[5]";
            this.btn5.Visible = false;
            // 
            // pnlContentMessage
            // 
            this.pnlContentMessage.AutoSize = true;
            this.pnlContentMessage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContentMessage.ColumnCount = 2;
            this.pnlContentMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlContentMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlContentMessage.Controls.Add(this.lblText, 1, 0);
            this.pnlContentMessage.Controls.Add(this.pbImage, 0, 0);
            this.pnlContentMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentMessage.Location = new System.Drawing.Point(3, 3);
            this.pnlContentMessage.Name = "pnlContentMessage";
            this.pnlContentMessage.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlContentMessage.RowCount = 1;
            this.pnlContentMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlContentMessage.Size = new System.Drawing.Size(346, 46);
            this.pnlContentMessage.TabIndex = 1;
            // 
            // chkAdditionalCheck
            // 
            this.chkAdditionalCheck.AutoSize = true;
            this.chkAdditionalCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkAdditionalCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAdditionalCheck.Location = new System.Drawing.Point(3, 93);
            this.chkAdditionalCheck.Name = "chkAdditionalCheck";
            this.chkAdditionalCheck.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkAdditionalCheck.Size = new System.Drawing.Size(346, 17);
            this.chkAdditionalCheck.TabIndex = 3;
            this.chkAdditionalCheck.Text = "TXT_XYZ";
            // 
            // lblThirdPartyNotice
            // 
            this.lblThirdPartyNotice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(216)))), ((int)(((byte)(235)))));
            this.lblThirdPartyNotice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblThirdPartyNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThirdPartyNotice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lblThirdPartyNotice.Location = new System.Drawing.Point(3, 55);
            this.lblThirdPartyNotice.Name = "lblThirdPartyNotice";
            this.lblThirdPartyNotice.ReadOnly = true;
            this.lblThirdPartyNotice.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.lblThirdPartyNotice.ShortcutsEnabled = false;
            this.lblThirdPartyNotice.Size = new System.Drawing.Size(346, 1);
            this.lblThirdPartyNotice.TabIndex = 8;
            this.lblThirdPartyNotice.Text = "";
            this.lblThirdPartyNotice.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.lblThirdPartyNotice_LinkClicked);
            // 
            // MessageDisplay
            // 
            this.AcceptButton = this.btn1;
            this.CancelButton = this.btn2;
            this.ClientSize = new System.Drawing.Size(378, 188);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MessageDisplay";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.pnlContentAll.ResumeLayout(false);
            this.pnlContentAll.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.pnlContentMessage.ResumeLayout(false);
            this.pnlContentMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMButton btn2;
        private System.Windows.Forms.PictureBox pbImage;
        private OPMLabel lblText;
        private OPMButton btn1;
        private OPMButton btn3;
        private OPMTableLayoutPanel pnlContentAll;
        private OPMTableLayoutPanel pnlContentMessage;
        private OPMButton btn4;
        private OPMCheckBox chkAdditionalCheck;
        private OPMButton btn5;
        private OPMTableLayoutPanel pnlButtons;
        private TransparentRichTextBox lblThirdPartyNotice;
    }
}