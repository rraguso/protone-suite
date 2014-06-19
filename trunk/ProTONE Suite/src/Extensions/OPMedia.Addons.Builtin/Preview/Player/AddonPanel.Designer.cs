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
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.signalAnalyzer = new OPMedia.UI.ProTONE.Controls.MediaPlayer.Screens.SignalAnalysisScreen();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.CompactView = true;
            this.mediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaPlayer.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.mediaPlayer.Location = new System.Drawing.Point(0, 256);
            this.mediaPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.mediaPlayer.MinimumSize = new System.Drawing.Size(0, 0);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OverrideBackColor = System.Drawing.Color.Empty;
            this.mediaPlayer.Size = new System.Drawing.Size(401, 255);
            this.mediaPlayer.TabIndex = 0;
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 1;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Controls.Add(this.mediaPlayer, 0, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.signalAnalyzer, 0, 0);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 2;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(401, 347);
            this.opmTableLayoutPanel1.TabIndex = 1;
            // 
            // signalAnalyzer
            // 
            this.signalAnalyzer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalAnalyzer.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.signalAnalyzer.Location = new System.Drawing.Point(3, 3);
            this.signalAnalyzer.Name = "signalAnalyzer";
            this.signalAnalyzer.OverrideBackColor = System.Drawing.Color.Empty;
            this.signalAnalyzer.Size = new System.Drawing.Size(395, 250);
            this.signalAnalyzer.TabIndex = 1;
            // 
            // AddonPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(250, 200);
            this.Name = "AddonPanel";
            this.Size = new System.Drawing.Size(401, 347);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MediaPlayer mediaPlayer;
        private UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private UI.ProTONE.Controls.MediaPlayer.Screens.SignalAnalysisScreen signalAnalyzer;
    }
}
