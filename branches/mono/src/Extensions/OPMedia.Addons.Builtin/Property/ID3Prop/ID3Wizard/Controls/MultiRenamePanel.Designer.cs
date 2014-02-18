using OPMedia.UI.Controls;
using System.Windows.Forms;

namespace OPMedia.Addons.Builtin.ID3Prop.ID3Wizard
{
    partial class MultiRenamePanel
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
            this.txtRenamePattern = new OPMedia.UI.Controls.OPMTextBox();
            this.txtHints = new OPMedia.UI.Controls.OPMTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_RENAMEPATTERN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRenamePattern
            // 
            this.txtRenamePattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRenamePattern.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtRenamePattern.Location = new System.Drawing.Point(0, 17);
            this.txtRenamePattern.Name = "txtRenamePattern";
            this.txtRenamePattern.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtRenamePattern.Size = new System.Drawing.Size(350, 22);
            this.txtRenamePattern.TabIndex = 1;
            this.txtRenamePattern.Text = "<N>";
            // 
            // txtHints
            // 
            this.txtHints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtHints.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.txtHints.Location = new System.Drawing.Point(0, 41);
            this.txtHints.Multiline = true;
            this.txtHints.Name = "txtHints";
            this.txtHints.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtHints.ReadOnly = true;
            this.txtHints.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHints.Size = new System.Drawing.Size(350, 239);
            this.txtHints.TabIndex = 2;
            this.txtHints.Text = "TXT_ID3PATTERNS";
            // 
            // MultiRenamePanel
            // 
            this.Controls.Add(this.txtHints);
            this.Controls.Add(this.txtRenamePattern);
            this.Controls.Add(this.label1);
            this.Name = "MultiRenamePanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMLabel label1;
        private OPMTextBox txtRenamePattern;
        private OPMTextBox txtHints;
    }
}
