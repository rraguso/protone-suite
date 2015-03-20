using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Controls;
using OPMedia.Core.Logging;
using System.Resources;

using OPMedia.UI.Themes;
using OPMedia.Core;

using OPMedia.Runtime.Shortcuts;

using OPMedia.UI.Generic;
using OPMedia.Core.GlobalEvents;
using OPMedia.Core.Configuration;
using OPMedia.Runtime.ProTONE;

using LocalEventNames = OPMedia.UI.ProTONE.GlobalEvents.EventNames;
using OPMedia.UI.ProTONE.Properties;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;
using OPMedia.Runtime.ProTONE.Rendering.Base;
using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Core.Utilities;
using OPMedia.Runtime.ProTONE.Configuration;


namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    public partial class PlaybackControlPanel : OPMBaseControl
    {
        OPMToolTipManager _tip = null;
        ToolStripItem _hoveredItem = null;

        private string _mediaName = string.Empty;
        private FilterState _FilterState = FilterState.Stopped;
        private MediaTypes _mediaType = MediaTypes.None;

        private bool _compactView = false;
        public bool CompactView
        {
            get
            {
                return _compactView;
            }

            set
            {
                _compactView = value;
                foreach (ToolStripItem tsi in opmToolStrip1.Items)
                {
                    if (tsi is ToolStripSeparator)
                        tsi.Visible = !_compactView;
                    else if (tsi is ToolStripButton)
                    {
                        ToolStripButton btn = tsi as ToolStripButton;
                        if (btn != null)
                        {
                            OPMShortcut cmd = (OPMShortcut)btn.Tag;
                            btn.Visible = (!_compactView || cmd <= OPMShortcut.CmdStop);
                        }
                    }
                }
            }
        }

        #region Properties
        public string MediaName
        { get { return _mediaName; } set { _mediaName = value; UpdateFileType(); } }

        public FilterState FilterState
        { get { return _FilterState; } set { _FilterState = value; UpdateFilterState(); } }

        public MediaTypes MediaType
        { get { return _mediaType; } set { _mediaType = value; UpdateMediaType(); } }

        double _elapsedSeconds = 0, _totalSeconds = 0;

        public double ElapsedSeconds
        {
            get
            {
                return _elapsedSeconds;
            }

            set
            {
                _elapsedSeconds = value;
                UpdateDisplayedTime();
            }
        }

        private void UpdateDisplayedTime()
        {
            string sElapsed = "", sTotal = "";

            if (_elapsedSeconds > 0)
            {
                sElapsed = string.Format("{0}", TimeSpan.FromSeconds((int)_elapsedSeconds));
            
                if (_totalSeconds > 0)
                    sTotal = string.Format(" ({0})", TimeSpan.FromSeconds((int)_totalSeconds));

                tslTime.Text = sElapsed + sTotal;
            }
            else
            {
                tslTime.Text = string.Empty;
            }
        }

        public double TotalSeconds
        {
            get
            {
                return _totalSeconds;
            }

            set
            {
                _totalSeconds = value;
                UpdateDisplayedTime();
            }
        }
        #endregion

        public PlaybackControlPanel()
            : base()
        {
            InitializeComponent();

            //List<OPMTriStateToolStripButton> toggleButtons = new List<OPMTriStateToolStripButton>
            //{
            //    tsmLoopPlay,
            //    tsmPlaylistEnd,
            //    tsmToggleShuffle
            //};

            this.DoubleBuffered = true;
            
            _tip = new OPMToolTipManager(opmToolStrip1);
            
            this.HandleCreated += new EventHandler(PlaybackControlPanel_HandleCreated);
        }

        void PlaybackControlPanel_HandleCreated(object sender, EventArgs e)
        {
            UpdateStateButtons();
        }

        [EventSink(EventNames.ThemeUpdated)]
        [EventSink(LocalEventNames.UpdateStateButtons)]
        public void UpdateStateButtons()
        {
            tsmLoopPlay.Checked = ProTONEConfig.LoopPlay;
            tsmPlaylistEnd.Checked = SystemScheduler.PlaylistEventEnabled;
            tsmToggleShuffle.Checked = ProTONEConfig.ShufflePlaylist;

            foreach (var x in opmToolStrip1.Items)
            {
                if (x is OPMToolStripSeparator)
                    continue;

                Padding origM = (x as ToolStripItem).Margin;
                origM.Top = 2 + ThemeManager.FormBorderWidth;
                origM.Bottom = 0;

                (x as ToolStripItem).Margin = origM;
            }

            tsmPlayPause.InactiveImage = SkinResources.btnPlay;
            tsmPlayPause.ActiveImage = SkinResources.btnPlay2;
            tsmStop.InactiveImage = SkinResources.btnStop;
            tsmStop.ActiveImage = SkinResources.btnStop2;
            tsmNext.InactiveImage = SkinResources.btnNext;
            tsmNext.ActiveImage = SkinResources.btnNext2;
            tsmPrev.InactiveImage = SkinResources.btnPrev;
            tsmPrev.ActiveImage = SkinResources.btnPrev2;
            tsmOpenDisk.InactiveImage = SkinResources.btnOpenDisk;
            tsmOpenDisk.ActiveImage = SkinResources.btnOpenDisk2;
            tsmOpenURL.InactiveImage = SkinResources.btnOpenURL;
            tsmOpenURL.ActiveImage = SkinResources.btnOpenURL2;
            tsmLoad.InactiveImage = SkinResources.btnLoad;
            tsmLoad.ActiveImage = SkinResources.btnLoad2;
            tsmOpenSettings.InactiveImage = SkinResources.btnOpenSettings;
            tsmOpenSettings.ActiveImage = SkinResources.btnOpenSettings2;

        }

        private void OnButtonPressed(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if (btn != null)
            {
                try
                {
                    OPMShortcut cmd = (OPMShortcut)btn.Tag;
                    ShortcutMapper.DispatchCommand(cmd);
                }
                catch (Exception ex)
                {
                    ErrorDispatcher.DispatchError(ex);
                }
                finally
                {
                    UpdateStateButtons();
                }
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            pnlButtons.Focus();
        }

        private void OnMouseHover(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if (btn != null)
            {
                _hoveredItem = btn;

                OPMShortcut cmd = (OPMShortcut)btn.Tag;
                string resourceTag = string.Format("TXT_{0}", cmd.ToString().ToUpperInvariant()).Replace("CMD", "BTN");
                string tipText = Translator.Translate(resourceTag, ShortcutMapper.GetShortcutString(cmd));
                _tip.ShowSimpleToolTip(tipText, btn.Image);
            }
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            //if (sender == _hoveredItem)
            //{
            //    _hoveredItem = null;
            //    _tip.RemoveAll();
            //}
        }

        private void UpdateFileType()
        {
            PlaylistItem pli = null;

            Image img = null;
            if (!string.IsNullOrEmpty(_mediaName))
            {
                try
                {
                    if (DvdMedia.FromPath(_mediaName) != null)
                    {
                        pli = new DvdPlaylistItem(_mediaName);
                        img = pli.GetImage(false);
                    }
                    else
                    {
                        pli = new PlaylistItem(_mediaName, false);
                        img = pli.GetImage(false);
                    }
                }
                catch
                {
                }

                if (img == null)
                    img = ImageProvider.GetIcon(_mediaName, false);
            }

            tslFileType.Image = img;
            tslFileType.Tag = pli;
        }

        private void UpdateFilterState()
        {
            Image img = null;
            if (!string.IsNullOrEmpty(_mediaName))
            {
                img = Resources.ResourceManager.GetImage(_FilterState.ToString().ToLowerInvariant());
            }

            tslFilterState.Image = img;
            tslFilterState.Tag = Translator.Translate("TXT_MEDIA_STATE", MediaRenderer.DefaultInstance.TranslatedFilterState);

            UpdatePlayPauseButton();
        }

        private void UpdatePlayPauseButton()
        {
            Image img = null, img2 = null;

            switch(_FilterState)
            {
                case Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Paused:
                    img = SkinResources.btnPlay;
                    img2 = SkinResources.btnPlay2;
                    break;

                case Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Running:
                    img = SkinResources.btnPause;
                    img2 = SkinResources.btnPause2;
                    break;

                default:
                    img = SkinResources.btnPlay;
                    img2 = SkinResources.btnPlay2;
                    break;
            }


            tsmPlayPause.InactiveImage = img;
            tsmPlayPause.ActiveImage = img2;
        }

        private void UpdateMediaType()
        {
            string tipAudio = Translator.Translate("TXT_AUDIO_AVAILABLE");
            string tipVideo = Translator.Translate("TXT_VIDEO_AVAILABLE");

            if (string.IsNullOrEmpty(_mediaName))
            {
                _mediaType = MediaTypes.None;
            }

            switch (_mediaType)
            {
                case MediaTypes.None:
                    tslAudioOn.Image = null;
                    tslVideoOn.Image = null;
                    break;

                case MediaTypes.Audio:
                    tslAudioOn.Image = Resources.btnCfgAudio;
                    tslVideoOn.Image = null;
                    break;

                case MediaTypes.Video:
                    tslAudioOn.Image = null;
                    tslAudioOn.Image = Resources.btnCfgVideo;
                    break;

                case MediaTypes.Both:
                    tslAudioOn.Image = Resources.btnCfgAudio;
                    tslVideoOn.Image = Resources.btnCfgVideo;
                    break;
            }

            tslAudioOn.Tag = tipAudio;
            tslVideoOn.Tag = tipVideo;
        }

        private void OnLabelMouseHover(object sender, EventArgs args)
        {
            ToolStripLabel lbl = sender as ToolStripLabel;
            if (lbl != null)
            {
                _hoveredItem = lbl;

                if (lbl == tslAudioOn || lbl == tslVideoOn || lbl == tslFilterState)
                {
                    _tip.ShowSimpleToolTip(lbl.Tag as string, lbl.Image);
                }
                else if (lbl == tslFileType)
                {
                    PlaylistItem pli = lbl.Tag as PlaylistItem;
                    if (pli != null)
                    {
                        _tip.ShowToolTip(StringUtils.Limit(pli.DisplayName, 60), pli.MediaInfo, pli.GetImage(true), 
                            pli.MediaFileInfo.CustomImage);
                    }
                    else
                    {
                        Image img = ImageProvider.GetIcon(_mediaName, true); 
                        _tip.ShowSimpleToolTip(_mediaName, img);
                    } 
                }
            }
        }
    }
}
