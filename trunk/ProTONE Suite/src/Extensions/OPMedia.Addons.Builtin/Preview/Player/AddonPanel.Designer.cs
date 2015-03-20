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
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.mediaPlayer = new OPMedia.UI.ProTONE.Controls.MediaPlayer.MediaPlayer();
            this.signalAnalysisScreen1 = new OPMedia.UI.ProTONE.Controls.MediaPlayer.Screens.SignalAnalysisScreen();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 1;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Controls.Add(this.mediaPlayer, 0, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.signalAnalysisScreen1, 0, 0);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 2;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(523, 347);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.CompactView = true;
            this.mediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaPlayer.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.mediaPlayer.Location = new System.Drawing.Point(0, 262);
            this.mediaPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.mediaPlayer.MinimumSize = new System.Drawing.Size(481, 68);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OverrideBackColor = System.Drawing.Color.Empty;
            this.mediaPlayer.Size = new System.Drawing.Size(523, 85);
            this.mediaPlayer.TabIndex = 0;
            // 
            // signalAnalysisScreen1
            // 
            this.signalAnalysisScreen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalAnalysisScreen1.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.signalAnalysisScreen1.Location = new System.Drawing.Point(0, 0);
            this.signalAnalysisScreen1.Margin = new System.Windows.Forms.Padding(0);
            this.signalAnalysisScreen1.Name = "signalAnalysisScreen1";
            this.signalAnalysisScreen1.OverrideBackColor = System.Drawing.Color.Empty;
            this.signalAnalysisScreen1.Size = new System.Drawing.Size(523, 262);
            this.signalAnalysisScreen1.TabIndex = 1;
            // 
            // AddonPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.Name = "AddonPanel";
            this.Size = new System.Drawing.Size(523, 347);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private MediaPlayer mediaPlayer;
        private UI.ProTONE.Controls.MediaPlayer.Screens.SignalAnalysisScreen signalAnalysisScreen1;

    }
}
