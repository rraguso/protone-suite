namespace TranslationEditor
{
    partial class ResourceValidationDialog
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
            this.tvResults = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvResults
            // 
            this.tvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvResults.Location = new System.Drawing.Point(12, 12);
            this.tvResults.Name = "tvResults";
            this.tvResults.Size = new System.Drawing.Size(692, 471);
            this.tvResults.TabIndex = 0;
            // 
            // ResourceValidationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 495);
            this.Controls.Add(this.tvResults);
            this.Name = "ResourceValidationDialog";
            this.Text = "ResourceValidationDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvResults;
    }
}