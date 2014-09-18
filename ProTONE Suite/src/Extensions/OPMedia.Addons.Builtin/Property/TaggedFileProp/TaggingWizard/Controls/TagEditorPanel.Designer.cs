using OPMedia.UI.Controls;
using System.Windows.Forms;

namespace OPMedia.Addons.Builtin.TaggedFileProp.TaggingWizard
{
    partial class TagEditorPanel
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
            this.txtHints = new OPMedia.UI.Controls.OPMTextBox();
            this.pgPatterns = new OPMedia.UI.Controls.OPMPropertyGrid();
            this.SuspendLayout();
            // 
            // txtHints
            // 
            this.txtHints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtHints.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.txtHints.Location = new System.Drawing.Point(159, 3);
            this.txtHints.Multiline = true;
            this.txtHints.Name = "txtHints";
            this.txtHints.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtHints.ReadOnly = true;
            this.txtHints.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHints.Size = new System.Drawing.Size(191, 274);
            this.txtHints.TabIndex = 1;
            this.txtHints.Text = "TXT_TAGGINGPATTERNS";
            // 
            // pgPatterns
            // 
            this.pgPatterns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgPatterns.HelpVisible = false;
            this.pgPatterns.Location = new System.Drawing.Point(0, 3);
            this.pgPatterns.Name = "pgPatterns";
            this.pgPatterns.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgPatterns.Size = new System.Drawing.Size(160, 274);
            this.pgPatterns.TabIndex = 0;
            this.pgPatterns.ToolbarVisible = false;
            // 
            // TagEditorPanel
            // 
            this.Controls.Add(this.pgPatterns);
            this.Controls.Add(this.txtHints);
            this.Name = "TagEditorPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMTextBox txtHints;
        private OPMPropertyGrid pgPatterns;
    }
}
