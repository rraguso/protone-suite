namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    partial class RenderingFrame
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
            this.renderingZone = new OPMedia.UI.ProTONE.Controls.MediaPlayer.RenderingZone();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.renderingZone);
            // 
            // renderingZone
            // 
            this.renderingZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderingZone.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.renderingZone.ForeColor = System.Drawing.Color.YellowGreen;
            this.renderingZone.Location = new System.Drawing.Point(0, 0);
            this.renderingZone.Name = "renderingZone";
            this.renderingZone.OverrideBackColor = System.Drawing.Color.Empty;
            this.renderingZone.Size = new System.Drawing.Size(387, 295);
            this.renderingZone.TabIndex = 0;
            // 
            // RenderingFrame
            // 
            this.AllowDrop = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(397, 323);
            this.Name = "RenderingFrame";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RenderingZone renderingZone;



    }
}