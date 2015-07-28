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
                sElapsed = string.Format("{0}", TimeSpan.FromSeconds((int)_elapsedSeconds));
            else
                sElapsed = "00:00:00";

            if (_totalSeconds >= 0)
            {
                if (_totalSeconds > 0)
                    sTotal = string.Format(" / {0}", TimeSpan.FromSeconds((int)_totalSeconds));
                else
                    sTotal = " / 00:00:00";
            }

            tslTime.Text = sElapsed + sTotal;
            tslTime.Font = ThemeManager.VeryLargeFont;
            tslTime.ForeColor = ThemeManager.BorderColor;
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
            tsmPlayPause.InactiveImage = Resources.btnPlay;
            tsmStop.InactiveImage = Resources.btnStop;
            tsmNext.InactiveImage = Resources.btnNext;
            tsmPrev.InactiveImage = Resources.btnPrev;
            tsmOpenDisk.InactiveImage = Resources.btnOpenDisk;
            tsmOpenURL.InactiveImage = Resources.btnOpenURL;
            tsmLoad.InactiveImage = Resources.btnLoad;
            tsmOpenSettings.InactiveImage = Resources.btnOpenSettings;
            tsmLoopPlay.InactiveImage = Resources.btnLoopPlay;
            tsmToggleShuffle.InactiveImage = Resources.btnToggleShuffle;
            tsmPlaylistEnd.InactiveImage = Resources.btnPlaylistEnd;
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
                        img = pli.GetImage(true);
                    }
                    else
                    {
                        pli = new PlaylistItem(_mediaName, false);
                        img = pli.GetImage(true);
                    }
                }
                catch
                {
                }

                if (img == null)
                    img = ImageProvider.GetIcon(_mediaName, true);
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
                    img = Resources.btnPlay;
                    break;

                case Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Running:
                    img = Resources.btnPause;
                    break;

                default:
                    img = Resources.btnPlay;
                    break;
            }


            tsmPlayPause.InactiveImage = img;
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
                    tslAudioOn.Image = Resources.AudioMediaType;
                    tslVideoOn.Image = null;
                    break;

                case MediaTypes.Video:
                    tslAudioOn.Image = null;
                    tslAudioOn.Image = Resources.VideoMediaType;
                    break;

                case MediaTypes.Both:
                    tslAudioOn.Image = Resources.AudioMediaType;
                    tslVideoOn.Image = Resources.VideoMediaType;
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
