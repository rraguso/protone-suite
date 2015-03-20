namespace OPMedia.Addons.Builtin.TaggedFileProp.TaggingWizard
{
    partial class ChangeEncodingPanel
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
            OPMedia.Addons.Builtin.Shared.EncoderOptions.EncoderSettingsContainer encoderSettingsContainer1 = new OPMedia.Addons.Builtin.Shared.EncoderOptions.EncoderSettingsContainer();
            OPMedia.Addons.Builtin.Shared.EncoderOptions.Mp3EncoderSettings mp3EncoderSettings1 = new OPMedia.Addons.Builtin.Shared.EncoderOptions.Mp3EncoderSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeEncodingPanel));
            OPMedia.Addons.Builtin.Shared.EncoderOptions.OggEncoderSettings oggEncoderSettings1 = new OPMedia.Addons.Builtin.Shared.EncoderOptions.OggEncoderSettings();
            OPMedia.Addons.Builtin.Shared.EncoderOptions.WavEncoderSettings wavEncoderSettings1 = new OPMedia.Addons.Builtin.Shared.EncoderOptions.WavEncoderSettings();
            OPMedia.Addons.Builtin.Shared.EncoderOptions.WmaEncoderSettings wmaEncoderSettings1 = new OPMedia.Addons.Builtin.Shared.EncoderOptions.WmaEncoderSettings();
            this.encoderOptionsCtl = new OPMedia.Addons.Builtin.Shared.EncoderOptions.EncoderOptionsCtl();
            this.SuspendLayout();
            // 
            // encoderOptionsCtl1
            // 
            this.encoderOptionsCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            encoderSettingsContainer1.AudioMediaFormatType = OPMedia.Addons.Builtin.Shared.EncoderOptions.AudioMediaFormatType.WAV;
            mp3EncoderSettings1.GenerateTagsFromTrackMetadata = false;
            mp3EncoderSettings1.Mp3ConversionOptions = ((OPMedia.Runtime.ProTONE.Compression.Lame.BE_CONFIG)(resources.GetObject("mp3EncoderSettings1.Mp3ConversionOptions")));
            encoderSettingsContainer1.Mp3EncoderSettings = mp3EncoderSettings1;
            encoderSettingsContainer1.OggEncoderSettings = oggEncoderSettings1;
            encoderSettingsContainer1.WavEncoderSettings = wavEncoderSettings1;
            encoderSettingsContainer1.WmaEncoderSettings = wmaEncoderSettings1;
            this.encoderOptionsCtl.EncoderSettings = encoderSettingsContainer1;
            this.encoderOptionsCtl.Location = new System.Drawing.Point(0, 0);
            this.encoderOptionsCtl.Name = "encoderOptionsCtl1";
            this.encoderOptionsCtl.Size = new System.Drawing.Size(350, 280);
            this.encoderOptionsCtl.TabIndex = 0;
            // 
            // ChangeEncodingPanel
            // 
            this.Controls.Add(this.encoderOptionsCtl);
            this.Name = "ChangeEncodingPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private Shared.EncoderOptions.EncoderOptionsCtl encoderOptionsCtl;
    }
}
