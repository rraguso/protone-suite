using OPMedia.UI.Controls;

using System.Windows.Forms;

namespace OPMedia.UI.Wizards
{
    partial class WizFinishPageCtl
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
            this.lblWizardResults = new OPMedia.UI.Controls.OPMLabel();
            this.pbProgress = new OPMedia.UI.Controls.OPMProgressBar();
            this.tvResults = new OPMedia.UI.Controls.OPMTreeView();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWizardResults
            // 
            this.lblWizardResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWizardResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWizardResults.Location = new System.Drawing.Point(3, 0);
            this.lblWizardResults.Name = "lblWizardResults";
            this.lblWizardResults.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblWizardResults.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblWizardResults.Size = new System.Drawing.Size(212, 19);
            this.lblWizardResults.TabIndex = 0;
            this.lblWizardResults.Text = "TXT_WIZTASKSFINISHED";
            this.lblWizardResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbProgress
            // 
            this.pbProgress.AllowDragging = false;
            this.pbProgress.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbProgress.Enabled = false;
            this.pbProgress.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.pbProgress.Location = new System.Drawing.Point(3, 22);
            this.pbProgress.Maximum = 10000D;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.NrTicks = 20;
            this.pbProgress.OverrideBackColor = System.Drawing.Color.Empty;
            this.pbProgress.ShowTicks = false;
            this.pbProgress.Size = new System.Drawing.Size(212, 10);
            this.pbProgress.TabIndex = 1;
            this.pbProgress.Value = 0D;
            this.pbProgress.Vertical = false;
            // 
            // tvResults
            // 
            this.tvResults.AccessibleName = "tvResults";
            this.tvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvResults.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvResults.FullRowSelect = true;
            this.tvResults.HideSelection = false;
            this.tvResults.Location = new System.Drawing.Point(3, 38);
            this.tvResults.Name = "tvResults";
            this.tvResults.ShowNodeToolTips = true;
            this.tvResults.Size = new System.Drawing.Size(212, 171);
            this.tvResults.TabIndex = 2;
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 1;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Controls.Add(this.lblWizardResults, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.tvResults, 0, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.pbProgress, 0, 1);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 3;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(218, 212);
            this.opmTableLayoutPanel1.TabIndex = 3;
            // 
            // WizFinishPageCtl
            // 
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.Name = "WizFinishPageCtl";
            this.Size = new System.Drawing.Size(218, 212);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OPMLabel lblWizardResults;
        private OPMProgressBar pbProgress;
        private OPMTreeView tvResults;
        private OPMTableLayoutPanel opmTableLayoutPanel1;
    }
}
