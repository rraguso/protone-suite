using OPMedia.UI.Controls;
using System.Windows.Forms;

namespace OPMedia.Addons.Builtin.TaggedFileProp.TaggingWizard
{
    partial class FSTagEditorPanel
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
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.label3 = new OPMedia.UI.Controls.OPMLabel();
            this.cmbFilePattern = new OPMedia.UI.Controls.OPMEditableComboBox();
            this.cmbFolderPattern = new OPMedia.UI.Controls.OPMEditableComboBox();
            this.SuspendLayout();
            // 
            // txtHints
            // 
            this.txtHints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtHints.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.txtHints.Location = new System.Drawing.Point(0, 89);
            this.txtHints.Multiline = true;
            this.txtHints.Name = "txtHints";
            this.txtHints.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtHints.ReadOnly = true;
            this.txtHints.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHints.ShortcutsEnabled = false;
            this.txtHints.Size = new System.Drawing.Size(354, 185);
            this.txtHints.TabIndex = 4;
            this.txtHints.Text = "TXT_TAGGINGPATTERNS";
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
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_FILENAMEPATTERN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(0, 45);
            this.label3.Name = "label3";
            this.label3.OverrideBackColor = System.Drawing.Color.Empty;
            this.label3.OverrideForeColor = System.Drawing.Color.Empty;
            this.label3.Size = new System.Drawing.Size(165, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "TXT_FOLDERNAMEPATTERN";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbFilePattern
            // 
            this.cmbFilePattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFilePattern.FormattingEnabled = true;
            this.cmbFilePattern.Items.AddRange(new object[] {
            "<A> - <T>",
            "<#> <A> - <T>",
            "<#> - <A> - <T>"});
            this.cmbFilePattern.Location = new System.Drawing.Point(0, 18);
            this.cmbFilePattern.Name = "cmbFilePattern";
            this.cmbFilePattern.Size = new System.Drawing.Size(354, 21);
            this.cmbFilePattern.TabIndex = 1;
            this.cmbFilePattern.TextChanged += new System.EventHandler(this.cmbFilePattern_TextChanged);
            // 
            // cmbFolderPattern
            // 
            this.cmbFolderPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFolderPattern.FormattingEnabled = true;
            this.cmbFolderPattern.Items.AddRange(new object[] {
            "<A> - <B>",
            "<A> - <B> - <Y>"});
            this.cmbFolderPattern.Location = new System.Drawing.Point(0, 63);
            this.cmbFolderPattern.Name = "cmbFolderPattern";
            this.cmbFolderPattern.Size = new System.Drawing.Size(354, 21);
            this.cmbFolderPattern.TabIndex = 3;
            this.cmbFolderPattern.TextChanged += new System.EventHandler(this.cmbFolderPattern_TextChanged);
            // 
            // FSTagEditorPanel
            // 
            this.Controls.Add(this.txtHints);
            this.Controls.Add(this.cmbFolderPattern);
            this.Controls.Add(this.cmbFilePattern);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FSTagEditorPanel";
            this.Size = new System.Drawing.Size(354, 276);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMTextBox txtHints;
        private OPMLabel label1;
        private OPMLabel label3;
        private OPMEditableComboBox cmbFilePattern;
        private OPMEditableComboBox cmbFolderPattern;
    }
}
