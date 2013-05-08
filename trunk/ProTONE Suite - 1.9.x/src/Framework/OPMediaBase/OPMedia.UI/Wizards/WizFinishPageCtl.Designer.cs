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
            this.SuspendLayout();
            // 
            // lblWizardResults
            // 
            this.lblWizardResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWizardResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWizardResults.Location = new System.Drawing.Point(0, 3);
            this.lblWizardResults.Name = "lblWizardResults";
            this.lblWizardResults.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblWizardResults.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblWizardResults.Size = new System.Drawing.Size(133, 19);
            this.lblWizardResults.TabIndex = 0;
            this.lblWizardResults.Text = "TXT_WIZTASKSFINISHED";
            this.lblWizardResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbProgress
            // 
            this.pbProgress.AllowDragging = false;
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgress.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbProgress.Enabled = false;
            this.pbProgress.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.pbProgress.Location = new System.Drawing.Point(3, 44);
            this.pbProgress.Maximum = 10000D;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.NrTicks = 20;
            this.pbProgress.OverrideBackColor = System.Drawing.Color.Empty;
            this.pbProgress.ShowTicks = false;
            this.pbProgress.Size = new System.Drawing.Size(303, 14);
            this.pbProgress.TabIndex = 1;
            this.pbProgress.Value = 0D;
            this.pbProgress.Vertical = false;
            // 
            // tvResults
            // 
            this.tvResults.AccessibleName = "tvResults";
            this.tvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvResults.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvResults.FullRowSelect = true;
            this.tvResults.HideSelection = false;
            this.tvResults.Location = new System.Drawing.Point(3, 64);
            this.tvResults.Name = "tvResults";
            this.tvResults.ShowNodeToolTips = true;
            this.tvResults.Size = new System.Drawing.Size(303, 145);
            this.tvResults.TabIndex = 2;
            // 
            // WizFinishPageCtl
            // 
            this.Controls.Add(this.tvResults);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.lblWizardResults);
            this.Name = "WizFinishPageCtl";
            this.Size = new System.Drawing.Size(309, 212);
            this.HandleCreated += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private OPMLabel lblWizardResults;
        private OPMProgressBar pbProgress;
        private OPMTreeView tvResults;
    }
}
