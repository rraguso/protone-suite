using OPMedia.UI.Controls;
namespace OPMedia.UI.Wizards
{
    partial class WizardHostForm
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
            this.pnlWizardLayout = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.pbWizImage = new System.Windows.Forms.PictureBox();
            this.pnlWizardStep = new System.Windows.Forms.Panel();
            this.stepButtons = new OPMedia.UI.Wizards.StepButtonsCtl();
            this.pnlContent.SuspendLayout();
            this.pnlWizardLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWizImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlWizardLayout);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlWizardLayout
            // 
            this.pnlWizardLayout.ColumnCount = 2;
            this.pnlWizardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlWizardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlWizardLayout.Controls.Add(this.lblSeparator, 0, 1);
            this.pnlWizardLayout.Controls.Add(this.pbWizImage, 0, 0);
            this.pnlWizardLayout.Controls.Add(this.pnlWizardStep, 1, 0);
            this.pnlWizardLayout.Controls.Add(this.stepButtons, 0, 2);
            this.pnlWizardLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWizardLayout.Location = new System.Drawing.Point(0, 0);
            this.pnlWizardLayout.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWizardLayout.Name = "pnlWizardLayout";
            this.pnlWizardLayout.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlWizardLayout.RowCount = 3;
            this.pnlWizardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlWizardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlWizardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlWizardLayout.Size = new System.Drawing.Size(540, 372);
            this.pnlWizardLayout.TabIndex = 0;
            // 
            // lblSeparator
            // 
            this.lblSeparator.BackColor = System.Drawing.Color.Maroon;
            this.pnlWizardLayout.SetColumnSpan(this.lblSeparator, 2);
            this.lblSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSeparator.Location = new System.Drawing.Point(0, 332);
            this.lblSeparator.Margin = new System.Windows.Forms.Padding(0);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(540, 3);
            this.lblSeparator.TabIndex = 1;
            // 
            // pbWizImage
            // 
            this.pbWizImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbWizImage.Location = new System.Drawing.Point(0, 0);
            this.pbWizImage.Margin = new System.Windows.Forms.Padding(0);
            this.pbWizImage.Name = "pbWizImage";
            this.pbWizImage.Size = new System.Drawing.Size(63, 332);
            this.pbWizImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbWizImage.TabIndex = 3;
            this.pbWizImage.TabStop = false;
            // 
            // pnlWizardStep
            // 
            this.pnlWizardStep.BackColor = System.Drawing.Color.Transparent;
            this.pnlWizardStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWizardStep.Location = new System.Drawing.Point(66, 3);
            this.pnlWizardStep.Name = "pnlWizardStep";
            this.pnlWizardStep.Size = new System.Drawing.Size(471, 326);
            this.pnlWizardStep.TabIndex = 0;
            // 
            // stepButtons
            // 
            this.stepButtons.AutoSize = true;
            this.stepButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stepButtons.CanCancel = true;
            this.stepButtons.CanFinish = true;
            this.stepButtons.CanMoveBack = true;
            this.stepButtons.CanMoveNext = true;
            this.pnlWizardLayout.SetColumnSpan(this.stepButtons, 2);
            this.stepButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stepButtons.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.stepButtons.Location = new System.Drawing.Point(3, 338);
            this.stepButtons.Name = "stepButtons";
            this.stepButtons.OKButtonText = "TXT_WIZARDOK";
            this.stepButtons.OverrideBackColor = System.Drawing.Color.Empty;
            this.stepButtons.RepeatWizard = false;
            this.stepButtons.ShowMovementButtons = true;
            this.stepButtons.ShowOKButton = false;
            this.stepButtons.ShowRepeatWizard = false;
            this.stepButtons.Size = new System.Drawing.Size(534, 31);
            this.stepButtons.TabIndex = 2;
            // 
            // WizardHostForm
            // 
            this.ClientSize = new System.Drawing.Size(550, 400);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WizardHostForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.OnShown);
            this.pnlContent.ResumeLayout(false);
            this.pnlWizardLayout.ResumeLayout(false);
            this.pnlWizardLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWizImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMTableLayoutPanel pnlWizardLayout;
        private StepButtonsCtl stepButtons;
        private System.Windows.Forms.PictureBox pbWizImage;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.Panel pnlWizardStep;



    }
}


