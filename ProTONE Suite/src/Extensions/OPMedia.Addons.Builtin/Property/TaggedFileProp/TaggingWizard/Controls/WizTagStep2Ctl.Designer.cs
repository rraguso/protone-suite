using OPMedia.UI.Controls;
using System.Windows.Forms;

namespace OPMedia.Addons.Builtin.TaggedFileProp.TaggingWizard
{
    partial class WizTagStep2Ctl
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
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.cmbEditType = new OPMedia.UI.Controls.OPMComboBox();
            this.pnlEdit = new System.Windows.Forms.Panel();
            this.cmbWordCasing = new OPMedia.UI.Controls.OPMComboBox();
            this.lblWordHandling = new OPMedia.UI.Controls.OPMLabel();
            this.lblPreview = new OPMedia.UI.Controls.OPMLinkLabel();
            this.opmLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(417, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_WIZTAGGINGSTEP2_DESC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbEditType
            // 
            this.cmbEditType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEditType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbEditType.FormattingEnabled = true;
            this.cmbEditType.Location = new System.Drawing.Point(3, 20);
            this.cmbEditType.Name = "cmbEditType";
            this.cmbEditType.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbEditType.Size = new System.Drawing.Size(411, 23);
            this.cmbEditType.TabIndex = 1;
            this.cmbEditType.SelectedIndexChanged += new System.EventHandler(this.cmbEditType_SelectedIndexChanged);
            // 
            // pnlEdit
            // 
            this.pnlEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEdit.Location = new System.Drawing.Point(0, 46);
            this.pnlEdit.Margin = new System.Windows.Forms.Padding(0);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(417, 183);
            this.pnlEdit.TabIndex = 2;
            // 
            // cmbWordCasing
            // 
            this.cmbWordCasing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWordCasing.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbWordCasing.FormattingEnabled = true;
            this.cmbWordCasing.Location = new System.Drawing.Point(3, 249);
            this.cmbWordCasing.Name = "cmbWordCasing";
            this.cmbWordCasing.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbWordCasing.Size = new System.Drawing.Size(411, 23);
            this.cmbWordCasing.TabIndex = 4;
            this.cmbWordCasing.SelectedIndexChanged += new System.EventHandler(this.cmbWordCasing_SelectedIndexChanged);
            // 
            // lblWordHandling
            // 
            this.lblWordHandling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWordHandling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWordHandling.Location = new System.Drawing.Point(0, 229);
            this.lblWordHandling.Margin = new System.Windows.Forms.Padding(0);
            this.lblWordHandling.Name = "lblWordHandling";
            this.lblWordHandling.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblWordHandling.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblWordHandling.Size = new System.Drawing.Size(417, 17);
            this.lblWordHandling.TabIndex = 3;
            this.lblWordHandling.Text = "TXT_WORDHANDLING";
            this.lblWordHandling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPreview
            // 
            this.lblPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPreview.Location = new System.Drawing.Point(0, 275);
            this.lblPreview.Margin = new System.Windows.Forms.Padding(0);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(417, 17);
            this.lblPreview.TabIndex = 5;
            this.lblPreview.TabStop = true;
            this.lblPreview.Text = "TXT_PREVIEW";
            this.lblPreview.Click += new System.EventHandler(this.lblPreview_LinkClicked);
            // 
            // opmLayoutPanel1
            // 
            this.opmLayoutPanel1.ColumnCount = 1;
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.Controls.Add(this.lblPreview, 0, 5);
            this.opmLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.opmLayoutPanel1.Controls.Add(this.cmbEditType, 0, 1);
            this.opmLayoutPanel1.Controls.Add(this.cmbWordCasing, 0, 4);
            this.opmLayoutPanel1.Controls.Add(this.lblWordHandling, 0, 3);
            this.opmLayoutPanel1.Controls.Add(this.pnlEdit, 0, 2);
            this.opmLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmLayoutPanel1.Name = "opmLayoutPanel1";
            this.opmLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLayoutPanel1.RowCount = 6;
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.Size = new System.Drawing.Size(417, 292);
            this.opmLayoutPanel1.TabIndex = 6;
            // 
            // WizTagStep2Ctl
            // 
            this.Controls.Add(this.opmLayoutPanel1);
            this.Name = "WizTagStep2Ctl";
            this.Size = new System.Drawing.Size(417, 292);
            this.opmLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OPMLabel label1;
        private OPMComboBox cmbEditType;
        private System.Windows.Forms.Panel pnlEdit;
        private OPMComboBox cmbWordCasing;
        private OPMLabel lblWordHandling;
        private OPMLinkLabel lblPreview;
        private OPMTableLayoutPanel opmLayoutPanel1;
    }
}
