using OPMedia.UI.Themes;
using OPMedia.UI.ProTONE.Controls.MediaPlayer;
namespace OPMedia.Addons.Builtin.Player
{
    partial class AddonPanel
    {
        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mediaPlayer = new OPMedia.UI.ProTONE.Controls.MediaPlayer.MediaPlayer();
            this.SuspendLayout();
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaPlayer.CompactView = true;
            this.mediaPlayer.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.mediaPlayer.Location = new System.Drawing.Point(5, 5);
            this.mediaPlayer.Margin = new System.Windows.Forms.Padding(5);
            this.mediaPlayer.MinimumSize = new System.Drawing.Size(0, 0);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.Size = new System.Drawing.Size(304, 190);
            this.mediaPlayer.TabIndex = 0;
            // 
            // AddonPanel
            // 
            this.Controls.Add(this.mediaPlayer);
            this.MinimumSize = new System.Drawing.Size(250, 200);
            this.Name = "AddonPanel";
            this.Size = new System.Drawing.Size(314, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private MediaPlayer mediaPlayer;
    }
}
