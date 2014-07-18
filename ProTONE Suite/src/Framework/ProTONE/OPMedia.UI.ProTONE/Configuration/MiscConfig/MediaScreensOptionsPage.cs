using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;
using OPMedia.Core.Configuration;
using OPMedia.Runtime;

using LocalEventNames = OPMedia.UI.ProTONE.GlobalEvents.EventNames;
using OPMedia.Core;
using OPMedia.Core.Utilities;
using OPMedia.UI.Controls;
using OPMedia.Runtime.ProTONE.Configuration;

namespace OPMedia.UI.ProTONE.Configuration.MiscConfig
{
    public partial class MediaScreensOptionsPage : BaseCfgPanel
    {
        public MediaScreensOptionsPage()
        {
            InitializeComponent();

            MediaScreen mediaScreen = MediaScreen.Playlist;
            chkShowPlaylist.Checked = ((ProTONEConfig.ShowMediaScreens & mediaScreen) == mediaScreen);

            mediaScreen = MediaScreen.TrackInfo;
            chkShowTrackInfo.Checked = ((ProTONEConfig.ShowMediaScreens & mediaScreen) == mediaScreen);

            mediaScreen = MediaScreen.SignalAnalisys;
            chkShowSignalAnalisys.Checked = ((ProTONEConfig.ShowMediaScreens & mediaScreen) == mediaScreen);

            mediaScreen = MediaScreen.BookmarkInfo;
            chkShowBookmarkInfo.Checked = ((ProTONEConfig.ShowMediaScreens & mediaScreen) == mediaScreen);


            SignalAnalisysFunction function = SignalAnalisysFunction.VUMeter;
            chkVuMeter.Checked = ((ProTONEConfig.SignalAnalisysFunctions & function) == function);

            function = SignalAnalisysFunction.Waveform;
            chkWaveform.Checked = ((ProTONEConfig.SignalAnalisysFunctions & function) == function);

            function = SignalAnalisysFunction.Spectrogram;
            chkSpectrogram.Checked = ((ProTONEConfig.SignalAnalisysFunctions & function) == function);

            this.chkShowPlaylist.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            this.chkShowTrackInfo.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            this.chkShowSignalAnalisys.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            this.chkShowBookmarkInfo.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            this.chkVuMeter.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            this.chkWaveform.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            this.chkSpectrogram.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);

        }

        protected override void SaveInternal()
        {
            MediaScreen mediaScreen = MediaScreen.None;
            SignalAnalisysFunction functions = SignalAnalisysFunction.None;

            if (chkShowPlaylist.Checked) 
                mediaScreen |= MediaScreen.Playlist;
            if (chkShowTrackInfo.Checked)
                mediaScreen |= MediaScreen.TrackInfo;
            if (chkShowSignalAnalisys.Checked)
                mediaScreen |= MediaScreen.SignalAnalisys;
            if (chkShowBookmarkInfo.Checked)
                mediaScreen |= MediaScreen.BookmarkInfo;

            if (chkVuMeter.Checked)
                functions |= SignalAnalisysFunction.VUMeter;
            if (chkWaveform.Checked)
                functions |= SignalAnalisysFunction.Waveform;
            if (chkSpectrogram.Checked)
                functions |= SignalAnalisysFunction.Spectrogram;

            ProTONEConfig.ShowMediaScreens = mediaScreen;
            ProTONEConfig.SignalAnalisysFunctions = functions;
            AppConfig.Save();

            EventDispatch.DispatchEvent(LocalEventNames.UpdateMediaScreens);
        }

        private void OnSettingsChanged(object sender, EventArgs e)
        {
            pnlSignalAnalisysOptions.Enabled = chkShowSignalAnalisys.Checked;
            base.Modified = true;
        }

    }
}
