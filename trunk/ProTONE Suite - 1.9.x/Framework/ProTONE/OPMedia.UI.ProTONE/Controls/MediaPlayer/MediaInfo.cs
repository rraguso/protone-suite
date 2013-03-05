#region Copyright © 2008 OPMedia Research
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	MediaState.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Generic;
using OPMedia.Core;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Controls;
using OPMedia.Runtime;
using OPMedia.Runtime.ProTONE.Rendering.Base;

using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Runtime.ProTONE.Playlists;
using System.Diagnostics;

using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Runtime.ProTONE.ExtendedInfo;
using OPMedia.UI.Themes;
using OPMedia.UI.ProTONE.Properties;

#endregion

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    public partial class MediaInfo : OPMBaseControl
    {
        #region Controls
        OPMToolTip _tip = new OPMToolTip();
        #endregion

        #region Members
        private string _mediaName = string.Empty;
        private MediaState _mediaState = MediaState.Stopped;
        private MediaTypes _mediaType = MediaTypes.None;
        #endregion

        #region Properties
        public string MediaName
        { get { return _mediaName; } set { _mediaName = value; UpdateFileType(); } }

        public MediaState MediaState
        { get { return _mediaState; } set { _mediaState = value; UpdateMediaState(); } }

        public MediaTypes MediaType
        { get { return _mediaType; } set { _mediaType = value; UpdateMediaType(); } }
        #endregion

        #region Construction
        public MediaInfo()
        {
            InitializeComponent();
        }

        void OnThemeChanged(object sender, EventArgs e)
        {
            UpdateFileType();
            UpdateMediaState();
            UpdateMediaType();
        }
        #endregion

        #region Event Handlers
        #endregion

        #region Implementation
        PlaylistItem pli = null;

        private void UpdateFileType()
        {
            Image img = null, imgSmall = null;
            if (!string.IsNullOrEmpty(_mediaName))
            {
                img = ImageProvider.GetIcon(_mediaName, true);
                imgSmall = ImageProvider.GetIcon(_mediaName, false);

                try
                {
                    if (DvdMedia.FromPath(_mediaName) != null)
                    {
                        pli = new DvdPlaylistItem(_mediaName);
                    }
                    else
                    {
                        pli = new PlaylistItem(_mediaName, false);
                    }
                }
                catch
                {
                }

                if (pli != null)
                {
                    _tip.SetToolTip(pbFileType, pli.DisplayName, pli.MediaInfo, img, pli.MediaFileInfo.CustomImage);
                }
                else
                {
                    _tip.SetSimpleToolTip(pbFileType, _mediaName, img);
                }
            }
            else
            {
                _tip.SetSimpleToolTip(pbFileType, null);
            }

            if (imgSmall != null)
            {
                pbFileType.SizeMode = (imgSmall.Height > pbFileType.Height) ?
                    PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;
            }
            
            pbFileType.Image = imgSmall;
        }

        private void UpdateMediaState()
        {
            Image img = null;
            if (!string.IsNullOrEmpty(_mediaName))
            {
                img = Resources.ResourceManager.GetImage(_mediaState.ToString().ToLowerInvariant());
            }
            
            pbMediaState.Image = img;
            string tip = Translator.Translate("TXT_MEDIA_STATE", MediaRenderer.DefaultInstance.TranslatedMediaState);

            _tip.SetSimpleToolTip(pbMediaState, tip, img);
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
                    pbAudioOn.Image = null;
                    pbVideoOn.Image = null;
                    break;

                case MediaTypes.Audio:
                    pbAudioOn.Image = Resources.btnCfgAudio;
                    pbVideoOn.Image = null;
                    break;

                case MediaTypes.Video:
                    pbAudioOn.Image = null;
                    pbAudioOn.Image = Resources.btnCfgVideo;
                    break;

                case MediaTypes.Both:
                    pbAudioOn.Image = Resources.btnCfgAudio;
                    pbVideoOn.Image = Resources.btnCfgVideo;
                    break;
            }

            _tip.SetSimpleToolTip(pbAudioOn, tipAudio, pbAudioOn.Image);
            _tip.SetSimpleToolTip(pbVideoOn, tipVideo, pbVideoOn.Image);
        }
        #endregion
    }
}

#region ChangeLog
#region Date: 03.03.2008			Author: Octavian Paraschiv
// File created.
#endregion
#endregion