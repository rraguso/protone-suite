using System.Windows.Forms;
using System;
using OPMedia.UI.Controls;

namespace OPMedia.RCCManager
{
    partial class ButtonConfigForm
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
            this.lblWndName = new OPMedia.UI.Controls.OPMLabel();
            this.txtWndname = new OPMedia.UI.Controls.OPMTextBox();
            this.btnOkAndAgain = new OPMedia.UI.Controls.OPMButton();
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.btnOk = new OPMedia.UI.Controls.OPMButton();
            this.btnDetect = new OPMedia.UI.Controls.OPMButton();
            this.lblOutputData = new OPMedia.UI.Controls.OPMLabel();
            this.txtOutputData = new OPMedia.UI.Controls.OPMTextBox();
            this.label2 = new OPMedia.UI.Controls.OPMLabel();
            this.txtInputData = new OPMedia.UI.Controls.OPMTextBox();
            this.lblBtnName = new OPMedia.UI.Controls.OPMLabel();
            this.txtButtonName = new OPMedia.UI.Controls.OPMTextBox();
            this.chkEnabled = new OPMedia.UI.Controls.OPMCheckBox();
            this.nudTimedRepeatRate = new OPMedia.UI.Controls.OPMNumericUpDown();
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.label4 = new OPMedia.UI.Controls.OPMLabel();
            this.cmbOutputData = new OPMedia.UI.Controls.OPMComboBox();
            this.lblKeyPress = new OPMedia.UI.Controls.OPMLinkLabel();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmFlowLayoutPanel2 = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.opmFlowLayoutPanel1 = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimedRepeatRate)).BeginInit();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.opmFlowLayoutPanel2.SuspendLayout();
            this.opmFlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.opmTableLayoutPanel1);
            this.pnlContent.TabIndex = 1;
            // 
            // lblWndName
            // 
            this.lblWndName.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.lblWndName, 4);
            this.lblWndName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWndName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWndName.Location = new System.Drawing.Point(0, 173);
            this.lblWndName.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblWndName.Name = "lblWndName";
            this.lblWndName.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblWndName.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblWndName.Size = new System.Drawing.Size(378, 13);
            this.lblWndName.TabIndex = 13;
            this.lblWndName.Text = "TXT_TARGETWNDNAME";
            this.lblWndName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWndName.Visible = false;
            // 
            // txtWndname
            // 
            this.txtWndname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.opmTableLayoutPanel1.SetColumnSpan(this.txtWndname, 4);
            this.txtWndname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWndname.Location = new System.Drawing.Point(0, 186);
            this.txtWndname.Margin = new System.Windows.Forms.Padding(0);
            this.txtWndname.Name = "txtWndname";
            this.txtWndname.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtWndname.Size = new System.Drawing.Size(378, 22);
            this.txtWndname.TabIndex = 14;
            this.txtWndname.Visible = false;
            // 
            // btnOkAndAgain
            // 
            this.btnOkAndAgain.AutoSize = true;
            this.btnOkAndAgain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOkAndAgain.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnOkAndAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkAndAgain.Location = new System.Drawing.Point(3, 219);
            this.btnOkAndAgain.Name = "btnOkAndAgain";
            this.btnOkAndAgain.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOkAndAgain.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOkAndAgain.Size = new System.Drawing.Size(105, 25);
            this.btnOkAndAgain.TabIndex = 15;
            this.btnOkAndAgain.Text = "TXT_ADD_REPEAT";
            this.btnOkAndAgain.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(289, 219);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(86, 25);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "TXT_CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(186, 219);
            this.btnOk.Name = "btnOk";
            this.btnOk.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOk.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOk.Size = new System.Drawing.Size(97, 25);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "TXT_ADD_ONCE";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnDetect
            // 
            this.btnDetect.AutoSize = true;
            this.btnDetect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDetect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDetect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetect.Location = new System.Drawing.Point(291, 35);
            this.btnDetect.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnDetect.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnDetect.Size = new System.Drawing.Size(87, 25);
            this.btnDetect.TabIndex = 3;
            this.btnDetect.Text = "TXT_DETECT";
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // lblOutputData
            // 
            this.lblOutputData.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.lblOutputData, 4);
            this.lblOutputData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutputData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOutputData.Location = new System.Drawing.Point(0, 65);
            this.lblOutputData.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblOutputData.Name = "lblOutputData";
            this.lblOutputData.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblOutputData.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblOutputData.Size = new System.Drawing.Size(378, 13);
            this.lblOutputData.TabIndex = 4;
            this.lblOutputData.Text = "TXT_OUTPUTDATA";
            this.lblOutputData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOutputData
            // 
            this.txtOutputData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.txtOutputData.Location = new System.Drawing.Point(250, 0);
            this.txtOutputData.Margin = new System.Windows.Forms.Padding(0);
            this.txtOutputData.Name = "txtOutputData";
            this.txtOutputData.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtOutputData.Size = new System.Drawing.Size(250, 22);
            this.txtOutputData.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.label2, 4);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(0, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Name = "label2";
            this.label2.OverrideBackColor = System.Drawing.Color.Empty;
            this.label2.OverrideForeColor = System.Drawing.Color.Empty;
            this.label2.Size = new System.Drawing.Size(378, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "TXT_INPUTDATA";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInputData
            // 
            this.txtInputData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.opmTableLayoutPanel1.SetColumnSpan(this.txtInputData, 3);
            this.txtInputData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInputData.Location = new System.Drawing.Point(0, 35);
            this.txtInputData.Margin = new System.Windows.Forms.Padding(0);
            this.txtInputData.Name = "txtInputData";
            this.txtInputData.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtInputData.Size = new System.Drawing.Size(286, 22);
            this.txtInputData.TabIndex = 2;
            // 
            // lblBtnName
            // 
            this.lblBtnName.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.lblBtnName, 4);
            this.lblBtnName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBtnName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBtnName.Location = new System.Drawing.Point(0, 106);
            this.lblBtnName.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblBtnName.Name = "lblBtnName";
            this.lblBtnName.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblBtnName.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblBtnName.Size = new System.Drawing.Size(378, 13);
            this.lblBtnName.TabIndex = 8;
            this.lblBtnName.Text = "TXT_BUTTONNAME";
            this.lblBtnName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtButtonName
            // 
            this.txtButtonName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.opmTableLayoutPanel1.SetColumnSpan(this.txtButtonName, 4);
            this.txtButtonName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtButtonName.Location = new System.Drawing.Point(0, 119);
            this.txtButtonName.Margin = new System.Windows.Forms.Padding(0);
            this.txtButtonName.Name = "txtButtonName";
            this.txtButtonName.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtButtonName.Size = new System.Drawing.Size(378, 22);
            this.txtButtonName.TabIndex = 9;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.chkEnabled, 4);
            this.chkEnabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEnabled.Location = new System.Drawing.Point(0, 0);
            this.chkEnabled.Margin = new System.Windows.Forms.Padding(0);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkEnabled.Size = new System.Drawing.Size(378, 17);
            this.chkEnabled.TabIndex = 0;
            this.chkEnabled.Text = "TXT_ENABLED";
            // 
            // nudTimedRepeatRate
            // 
            this.nudTimedRepeatRate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.nudTimedRepeatRate.Location = new System.Drawing.Point(122, 0);
            this.nudTimedRepeatRate.Margin = new System.Windows.Forms.Padding(0);
            this.nudTimedRepeatRate.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudTimedRepeatRate.Name = "nudTimedRepeatRate";
            this.nudTimedRepeatRate.ReadOnly = true;
            this.nudTimedRepeatRate.Size = new System.Drawing.Size(48, 22);
            this.nudTimedRepeatRate.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(170, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "TXT_SECONDS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.OverrideBackColor = System.Drawing.Color.Empty;
            this.label4.OverrideForeColor = System.Drawing.Color.Empty;
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "TXT_TIMEDREPEATRATE";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbOutputData
            // 
            this.cmbOutputData.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbOutputData.FormattingEnabled = true;
            this.cmbOutputData.Location = new System.Drawing.Point(0, 0);
            this.cmbOutputData.Margin = new System.Windows.Forms.Padding(0);
            this.cmbOutputData.Name = "cmbOutputData";
            this.cmbOutputData.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbOutputData.Size = new System.Drawing.Size(250, 23);
            this.cmbOutputData.TabIndex = 5;
            // 
            // lblKeyPress
            // 
            this.lblKeyPress.AutoSize = true;
            this.lblKeyPress.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblKeyPress.Location = new System.Drawing.Point(500, 0);
            this.lblKeyPress.Margin = new System.Windows.Forms.Padding(0);
            this.lblKeyPress.Name = "lblKeyPress";
            this.lblKeyPress.Size = new System.Drawing.Size(49, 23);
            this.lblKeyPress.TabIndex = 7;
            this.lblKeyPress.TabStop = true;
            this.lblKeyPress.Text = "TXT_NA";
            this.lblKeyPress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKeyPress.Visible = false;
            this.lblKeyPress.Click += new System.EventHandler(this.lblKeyPress_LinkClicked);
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 4;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.Controls.Add(this.opmFlowLayoutPanel2, 0, 7);
            this.opmTableLayoutPanel1.Controls.Add(this.btnOkAndAgain, 0, 11);
            this.opmTableLayoutPanel1.Controls.Add(this.txtWndname, 0, 9);
            this.opmTableLayoutPanel1.Controls.Add(this.btnOk, 2, 11);
            this.opmTableLayoutPanel1.Controls.Add(this.btnCancel, 3, 11);
            this.opmTableLayoutPanel1.Controls.Add(this.lblWndName, 0, 8);
            this.opmTableLayoutPanel1.Controls.Add(this.opmFlowLayoutPanel1, 0, 4);
            this.opmTableLayoutPanel1.Controls.Add(this.chkEnabled, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.txtInputData, 0, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.btnDetect, 3, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.txtButtonName, 0, 6);
            this.opmTableLayoutPanel1.Controls.Add(this.lblOutputData, 0, 3);
            this.opmTableLayoutPanel1.Controls.Add(this.lblBtnName, 0, 5);
            this.opmTableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 12;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(378, 247);
            this.opmTableLayoutPanel1.TabIndex = 18;
            // 
            // opmFlowLayoutPanel2
            // 
            this.opmFlowLayoutPanel2.AutoSize = true;
            this.opmFlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmTableLayoutPanel1.SetColumnSpan(this.opmFlowLayoutPanel2, 4);
            this.opmFlowLayoutPanel2.Controls.Add(this.label4);
            this.opmFlowLayoutPanel2.Controls.Add(this.nudTimedRepeatRate);
            this.opmFlowLayoutPanel2.Controls.Add(this.label1);
            this.opmFlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmFlowLayoutPanel2.Location = new System.Drawing.Point(0, 146);
            this.opmFlowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.opmFlowLayoutPanel2.Name = "opmFlowLayoutPanel2";
            this.opmFlowLayoutPanel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmFlowLayoutPanel2.Size = new System.Drawing.Size(378, 22);
            this.opmFlowLayoutPanel2.TabIndex = 19;
            this.opmFlowLayoutPanel2.WrapContents = false;
            // 
            // opmFlowLayoutPanel1
            // 
            this.opmFlowLayoutPanel1.AutoSize = true;
            this.opmFlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmTableLayoutPanel1.SetColumnSpan(this.opmFlowLayoutPanel1, 4);
            this.opmFlowLayoutPanel1.Controls.Add(this.cmbOutputData);
            this.opmFlowLayoutPanel1.Controls.Add(this.txtOutputData);
            this.opmFlowLayoutPanel1.Controls.Add(this.lblKeyPress);
            this.opmFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmFlowLayoutPanel1.Location = new System.Drawing.Point(0, 78);
            this.opmFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.opmFlowLayoutPanel1.Name = "opmFlowLayoutPanel1";
            this.opmFlowLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmFlowLayoutPanel1.Size = new System.Drawing.Size(378, 23);
            this.opmFlowLayoutPanel1.TabIndex = 19;
            this.opmFlowLayoutPanel1.WrapContents = false;
            // 
            // ButtonConfigForm
            // 
            this.ClientSize = new System.Drawing.Size(388, 275);
            this.Name = "ButtonConfigForm";
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTimedRepeatRate)).EndInit();
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.opmFlowLayoutPanel2.ResumeLayout(false);
            this.opmFlowLayoutPanel2.PerformLayout();
            this.opmFlowLayoutPanel1.ResumeLayout(false);
            this.opmFlowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMLabel lblWndName;
        private OPMTextBox txtWndname;
        private OPMButton btnOkAndAgain;
        private OPMButton btnCancel;
        private OPMButton btnOk;
        private OPMButton btnDetect;
        private OPMLabel lblOutputData;
        private OPMTextBox txtOutputData;
        private OPMLabel label2;
        private OPMTextBox txtInputData;
        private OPMLabel lblBtnName;
        private OPMTextBox txtButtonName;
        private OPMCheckBox chkEnabled;
        private OPMNumericUpDown nudTimedRepeatRate;
        private OPMLabel label1;
        private OPMLabel label4;
        private OPMLinkLabel lblKeyPress;
        private OPMComboBox cmbOutputData;
        private OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMFlowLayoutPanel opmFlowLayoutPanel2;
        private OPMFlowLayoutPanel opmFlowLayoutPanel1;

    }
}
