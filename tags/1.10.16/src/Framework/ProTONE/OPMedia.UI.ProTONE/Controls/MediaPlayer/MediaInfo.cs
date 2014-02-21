#region Copyright © 2008 OPMedia Research
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	FilterState.cs
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
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;
using OPMedia.Core.Utilities;
using System.Windows.Forms.Design;

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
        private FilterState _FilterState = FilterState.Stopped;
        private MediaTypes _mediaType = MediaTypes.None;
        #endregion

        #region Properties
        public string MediaName
        { get { return _mediaName; } set { _mediaName = value; UpdateFileType(); } }

        public FilterState FilterState
        { get { return _FilterState; } set { _FilterState = value; UpdateFilterState(); } }

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
            UpdateFilterState();
            UpdateMediaType();
        }
        #endregion

        #region Event Handlers
        #endregion

        #region Implementation
        PlaylistItem pli = null;

        
        #endregion
    }

    [DesignerCategory("code")]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class ToolStripMediaInfo : ToolStripControlHost
    {
        public string MediaName
        { get { return MediaInfo.MediaName; } set { MediaInfo.MediaName = value; } }

        public FilterState FilterState
        { get { return MediaInfo.FilterState; } set { MediaInfo.FilterState = value; } }

        public MediaTypes MediaType
        { get { return MediaInfo.MediaType; } set { MediaInfo.MediaType = value; } }

        public MediaInfo MediaInfo
        {
            get
            {
                return this.Control as MediaInfo;
            }
        }

        public ToolStripMediaInfo()
            : base(new MediaInfo())
        {
        }
    }
}

#region ChangeLog
#region Date: 03.03.2008			Author: Octavian Paraschiv
// File created.
#endregion
#endregion