using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Runtime;

using LocalEventNames = OPMedia.UI.ProTONE.GlobalEvents.EventNames;
using OPMedia.Core;
using OPMedia.Core.Utilities;
using OPMedia.UI.Controls;

namespace OPMedia.UI.ProTONE.Configuration.MiscConfig
{
    public partial class MediaScreensOptionsPage : BaseCfgPanel
    {
        public MediaScreensOptionsPage()
        {
            InitializeComponent();

            AppSettings.MediaScreen mediaScreen = AppSettings.MediaScreen.Playlist;
            chkShowPlaylist.Checked = ((AppSettings.ShowMediaScreens & mediaScreen) == mediaScreen);

            mediaScreen = AppSettings.MediaScreen.TrackInfo;
            chkShowTrackInfo.Checked = ((AppSettings.ShowMediaScreens & mediaScreen) == mediaScreen);

            mediaScreen = AppSettings.MediaScreen.SignalAnalisys;
            chkShowSignalAnalisys.Checked = ((AppSettings.ShowMediaScreens & mediaScreen) == mediaScreen);

            mediaScreen = AppSettings.MediaScreen.BookmarkInfo;
            chkShowBookmarkInfo.Checked = ((AppSettings.ShowMediaScreens & mediaScreen) == mediaScreen);


            AppSettings.SignalAnalisysFunction function = AppSettings.SignalAnalisysFunction.VUMeter;
            chkVuMeter.Checked = ((AppSettings.SignalAnalisysFunctions & function) == function);

            function = AppSettings.SignalAnalisysFunction.Waveform;
            chkWaveform.Checked = ((AppSettings.SignalAnalisysFunctions & function) == function);

            function = AppSettings.SignalAnalisysFunction.Spectrogram;
            chkSpectrogram.Checked = ((AppSettings.SignalAnalisysFunctions & function) == function);

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
            AppSettings.MediaScreen mediaScreen = AppSettings.MediaScreen.None;
            AppSettings.SignalAnalisysFunction functions = AppSettings.SignalAnalisysFunction.None;

            if (chkShowPlaylist.Checked) 
                mediaScreen |= AppSettings.MediaScreen.Playlist;
            if (chkShowTrackInfo.Checked)
                mediaScreen |= AppSettings.MediaScreen.TrackInfo;
            if (chkShowSignalAnalisys.Checked)
                mediaScreen |= AppSettings.MediaScreen.SignalAnalisys;
            if (chkShowBookmarkInfo.Checked)
                mediaScreen |= AppSettings.MediaScreen.BookmarkInfo;

            if (chkVuMeter.Checked)
                functions |= AppSettings.SignalAnalisysFunction.VUMeter;
            if (chkWaveform.Checked)
                functions |= AppSettings.SignalAnalisysFunction.Waveform;
            if (chkSpectrogram.Checked)
                functions |= AppSettings.SignalAnalisysFunction.Spectrogram;
            
            AppSettings.ShowMediaScreens = mediaScreen;
            AppSettings.SignalAnalisysFunctions = functions;

            EventDispatch.DispatchEvent(LocalEventNames.UpdateMediaScreens);

            AppSettings.Save();
        }

        private void OnSettingsChanged(object sender, EventArgs e)
        {
            pnlSignalAnalisysOptions.Enabled = chkShowSignalAnalisys.Checked;
            base.Modified = true;
        }

    }
}
