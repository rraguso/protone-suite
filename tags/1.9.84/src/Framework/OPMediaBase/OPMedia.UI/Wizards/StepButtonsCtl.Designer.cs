using OPMedia.UI.Controls;

namespace OPMedia.UI.Wizards
{
    partial class StepButtonsCtl
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
            this.btnPrevious = new OPMedia.UI.Controls.OPMButton();
            this.btnNext = new OPMedia.UI.Controls.OPMButton();
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.btnFinish = new OPMedia.UI.Controls.OPMButton();
            this.pnlMovementButtons = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.btnOK = new OPMedia.UI.Controls.OPMButton();
            this.panel = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.chkRepeatWizard = new OPMedia.UI.Controls.OPMCheckBox();
            this.pnlMovementButtons.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.AutoSize = true;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Location = new System.Drawing.Point(3, 3);
            this.btnPrevious.MaximumSize = new System.Drawing.Size(75, 25);
            this.btnPrevious.MinimumSize = new System.Drawing.Size(70, 24);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnPrevious.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnPrevious.Size = new System.Drawing.Size(75, 25);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "TXT_WIZARDBACK";
            this.btnPrevious.Click += new System.EventHandler(this.OnBtnBack);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.AutoSize = true;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(84, 3);
            this.btnNext.MaximumSize = new System.Drawing.Size(75, 25);
            this.btnNext.MinimumSize = new System.Drawing.Size(70, 24);
            this.btnNext.Name = "btnNext";
            this.btnNext.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnNext.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnNext.Size = new System.Drawing.Size(75, 25);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "TXT_WIZARDNEXT";
            this.btnNext.Click += new System.EventHandler(this.OnBtnNext);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(246, 3);
            this.btnCancel.MaximumSize = new System.Drawing.Size(75, 25);
            this.btnCancel.MinimumSize = new System.Drawing.Size(70, 24);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "TXT_WIZARDCANCEL";
            this.btnCancel.Click += new System.EventHandler(this.OnBtnCancel);
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.AutoSize = true;
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.Location = new System.Drawing.Point(165, 3);
            this.btnFinish.MaximumSize = new System.Drawing.Size(75, 25);
            this.btnFinish.MinimumSize = new System.Drawing.Size(70, 24);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnFinish.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnFinish.Size = new System.Drawing.Size(75, 25);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "TXT_WIZARDFINISH";
            this.btnFinish.Click += new System.EventHandler(this.OnBtnFinish);
            // 
            // pnlMovementButtons
            // 
            this.pnlMovementButtons.AutoSize = true;
            this.pnlMovementButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMovementButtons.Controls.Add(this.btnCancel);
            this.pnlMovementButtons.Controls.Add(this.btnFinish);
            this.pnlMovementButtons.Controls.Add(this.btnNext);
            this.pnlMovementButtons.Controls.Add(this.btnPrevious);
            this.pnlMovementButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMovementButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlMovementButtons.Location = new System.Drawing.Point(269, 0);
            this.pnlMovementButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMovementButtons.Name = "pnlMovementButtons";
            this.pnlMovementButtons.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlMovementButtons.Size = new System.Drawing.Size(324, 31);
            this.pnlMovementButtons.TabIndex = 2;
            this.pnlMovementButtons.WrapContents = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoSize = true;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(169, 3);
            this.btnOK.MinimumSize = new System.Drawing.Size(70, 24);
            this.btnOK.Name = "btnOK";
            this.btnOK.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOK.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOK.Size = new System.Drawing.Size(97, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "TXT_WIZARDOK";
            this.btnOK.Click += new System.EventHandler(this.OnBtnOK);
            // 
            // panel
            // 
            this.panel.AutoSize = true;
            this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel.ColumnCount = 4;
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panel.Controls.Add(this.chkRepeatWizard, 0, 0);
            this.panel.Controls.Add(this.pnlMovementButtons, 3, 0);
            this.panel.Controls.Add(this.btnOK, 2, 0);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.OverrideBackColor = System.Drawing.Color.Empty;
            this.panel.RowCount = 1;
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panel.Size = new System.Drawing.Size(593, 31);
            this.panel.TabIndex = 0;
            // 
            // chkRepeatWizard
            // 
            this.chkRepeatWizard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRepeatWizard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRepeatWizard.Location = new System.Drawing.Point(3, 9);
            this.chkRepeatWizard.Name = "chkRepeatWizard";
            this.chkRepeatWizard.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkRepeatWizard.Size = new System.Drawing.Size(126, 19);
            this.chkRepeatWizard.TabIndex = 0;
            this.chkRepeatWizard.Text = "TXT_WIZARDREPEAT";
            // 
            // StepButtonsCtl
            // 
            this.Controls.Add(this.panel);
            this.Name = "StepButtonsCtl";
            this.Size = new System.Drawing.Size(593, 31);
            this.pnlMovementButtons.ResumeLayout(false);
            this.pnlMovementButtons.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMButton btnPrevious;
        private OPMButton btnNext;
        private OPMButton btnCancel;
        private OPMButton btnFinish;
        private OPMFlowLayoutPanel pnlMovementButtons;
        private OPMTableLayoutPanel panel;
        private OPMButton btnOK;
        private OPMCheckBox chkRepeatWizard;
    }
}
