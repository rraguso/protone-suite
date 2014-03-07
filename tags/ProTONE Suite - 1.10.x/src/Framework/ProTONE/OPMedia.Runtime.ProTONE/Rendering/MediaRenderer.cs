#region Copyright © 2006 OPMedia Research
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	MediaRenderer.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using OPMedia.Runtime.ProTONE.Rendering.Base;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Core.Logging;
using OPMedia.Core.TranslationSupport;

#if HAVE_DSHOW
    using OPMedia.Runtime.ProTONE.Rendering.DS;
#else
    using OPMedia.Runtime.ProTONE.Rendering.Mono;
#endif

using OPMedia.Core;
using System.IO;

using OPMedia.Core.Utilities;
using OPMedia.Runtime.ProTONE.SubtitleDownload;
using OPMedia.Runtime.ProTONE.FfdShowApi;
using OPMedia.Core.ApplicationSettings;
using OPMedia.UI.Generic;

#endregion

namespace OPMedia.Runtime.ProTONE.Rendering
{
    public enum VideoSizeAdjustmentDirection
    {
        None = 0,
        Horizontal,
        Vertical
    }
    
    public enum VideoSizeAdjustmentAction
    {
        None = 0,
        Shrink,
        Expand
    }

    public delegate void MediaRendererEventHandler();
    public delegate void FilterStateChangedHandler(OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState oldState, string oldMedia, 
        OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState newState, string newMedia);

    public delegate void MediaRenderingExceptionHandler(RenderingExceptionEventArgs args);
    
    public delegate void RenderedStreamTitleChangedHandler(string newTitle);

    public sealed class MediaRenderer : IDisposable
    {
        public const int VolumeFull = 0;
        public const int VolumeSilence = -10000;

        static string[] _playlists = new string[] { "m3u", "pls", "asx", "wpl" };

        private int _hash = DateTime.Now.GetHashCode();
        private double _position = 0;

        public event RenderedStreamTitleChangedHandler RenderedStreamTitleChanged = null;

        public class SupportedFileProvider : ISupportedFileProvider
        {
            public List<string> SupportedAudioTypes { get; internal set; }
            public List<string> SupportedHDVideoTypes { get; internal set; }
            public List<string> SupportedVideoTypes { get; internal set; }
            public List<string> SupportedPlaylists { get; internal set; }
            public List<string> SupportedSubtitles { get; internal set; }
            public List<string> AllMediaTypes { get; internal set; }
        }

        #region Members
        private static MediaRenderer __defaultInstance = new MediaRenderer();

        private Technology renderingTechnology = null;
        private Timer timerCheckState = null;

        private OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState oldState = 
            OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Stopped;

        private string oldMedia = string.Empty;

        Control renderPanel = null;
        Control messageDrain = null;

        volatile bool playlistAtEnd = false;
        object _syncPlaylist = new object();

        #endregion

        #region Properties
        
        public static MediaRenderer DefaultInstance
        {
            get
            {
                return __defaultInstance;
            }
        }

        public static MediaRenderer NewInstance()
        {
            return new MediaRenderer();
        }

        internal object GraphFilter { get { return renderingTechnology.GraphFilter; } }

        public int VolumeAvgR { get { return renderingTechnology.VolumeAvgR; } }
        public int VolumeAvgL { get { return renderingTechnology.VolumeAvgL; } }
        public int VolumePeakR { get { return renderingTechnology.VolumePeakR; } }
        public int VolumePeakL { get { return renderingTechnology.VolumePeakL; } }


        public double[] EqFrequencies
        {
            get
            {
                double[] freqs = new double[10];

                using (FfdShowLib ff = FfdShowInstance())
                {
                    for (FFDShowConstants.FFDShowDataId i = FFDShowConstants.FFDShowDataId.IDFF_filterEQ; i < FFDShowConstants.FFDShowDataId.IDFF_filterWinamp2; i++)
                    {
                        int iVal = ff.getIntParam(i);
                        string sVal = ff.getStringParam(i);
                    }

                }

                return freqs;
            }

            set
            {
            }
        }


        public int[] EqLevels
        {
            get
            {
                int[] levels = new int[10];

                return levels;
            }

            set
            {
            }
        }

        public Control RenderPanel
        {
            get { return renderPanel; }
            set { renderPanel = value; }
        }

        public Control MessageDrain
        {
            get { return messageDrain; }
            set { messageDrain = value; }
        }

        public bool PlaylistAtEnd
        {
            get 
            {
                lock (_syncPlaylist)
                {
                    return playlistAtEnd;
                }
            }
            
            set 
            {
                lock (_syncPlaylist)
                {
                    playlistAtEnd = value;
                }
            }
        }

        public double MediaPosition
        {
            get
            {
                return (renderingTechnology.FilterState == OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Stopped) ?
                    0 : renderingTechnology.MediaPosition;
            }
            
        }

        public int AudioVolume
        {
            get { return renderingTechnology.AudioVolume; }
            set 
            {
                renderingTechnology.AudioVolume = GetScaledVolume(value);
            } 
        }

        public int AudioBalance
        {
            get { return renderingTechnology.AudioBalance; }
            set
            {
                renderingTechnology.AudioBalance = value;
            }
        }

        public int SubtitleStream
        {
            get 
            { 
                return renderingTechnology.SubtitleStream; 
            }
            
            set
            {
                renderingTechnology.SubtitleStream = value;
            }
        }

        public bool CanSeekMedia
        { get { return (renderingTechnology.MediaSeekable && renderingTechnology.MediaLength > 0); } }

        public static List<string> SupportedAudioTypes
        { get { return Technology.SupportedAudioMediaTypes; } }

        public static List<string> SupportedHDVideoTypes
        { get { return Technology.SupportedHDVideoMediaTypes; } }

        public static List<string> SupportedVideoTypes
        { get { return Technology.SupportedVideoMediaTypes; } }

        public static List<string> SupportedPlaylists
        { get { return new List<string>(_playlists); } }

        public double DurationScaleFactor
        { get { return renderingTechnology.DurationScaleFactor; } }

        public double MediaLength
        { get { return renderingTechnology.MediaLength; } }

        public MediaFileInfo RenderedMediaInfo
        { get { return renderingTechnology.GetRenderMediaInfo(); } }

        public MediaTypes RenderedMediaType
        { get { return renderingTechnology.RenderedMediaType; } }

        public OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState FilterState
        { get { return renderingTechnology.FilterState; } }

        public string TranslatedFilterState
        { get { return Translator.Translate("TXT_" + FilterState.ToString().ToUpperInvariant()); } }

        public bool ShowCursor
        {
            get { return renderingTechnology.ShowCursor; }
            set { renderingTechnology.ShowCursor = value; }
        }

        //public bool FullScreen
        //{
        //    get { return renderingTechnology.FullScreen; }
        //    set { renderingTechnology.FullScreen = value; }
        //}

        public static List<string> AllMediaTypes
        {
            get
            {
                List<string> allTypes = new List<string>();
                allTypes.AddRange(Technology.SupportedAudioMediaTypes);
                allTypes.AddRange(Technology.SupportedVideoMediaTypes);
                allTypes.AddRange(_playlists); // supported playlists
                return allTypes;
            }
        }
        #endregion

        #region Methods

        public bool IsStreamedMedia { get { return renderingTechnology.IsStreamedMedia; } } 

        public string StreamTitle { get; private set; }

        internal void FireStreamTitleChanged(string newTitle)
        {
            if (renderingTechnology.IsStreamedMedia && RenderedStreamTitleChanged != null)
            {
                this.StreamTitle = newTitle;
                RenderedStreamTitleChanged(newTitle);
            }
        }

        public static SupportedFileProvider GetSupportedFileProvider()
        {
            SupportedFileProvider retVal = new SupportedFileProvider();
            retVal.SupportedAudioTypes = MediaRenderer.SupportedAudioTypes;
            retVal.SupportedVideoTypes = MediaRenderer.SupportedVideoTypes;
            retVal.SupportedHDVideoTypes = MediaRenderer.SupportedHDVideoTypes;
            retVal.SupportedPlaylists = MediaRenderer.SupportedPlaylists;

            retVal.SupportedSubtitles = new List<string>(new string[] 
            {
                // MicroDVD
                "sub", 
                
                // SubRip
                "srt", 
                
                // Universal Subtitle Format
                "usf", 
                
                // SubStation Alpha
                "ass", "ssa", 

                //"utf", "idx", "smi", "rt", "aqt", "mpl", 
            });

            retVal.AllMediaTypes = MediaRenderer.AllMediaTypes;

            return retVal;
        }

        public static int GetScaledVolume(int rawVolume)
        {
            double a = (-1000 / Math.Log10(0.5));
            double b = 0.01;
            double c = 0.0976;
            double x = (double)(rawVolume / 100);
            double logVolume = a * Math.Log10(b * (x + c));
            int scaledVolume = (int)logVolume;
            if (logVolume < -10000)
            {
                scaledVolume = -10000;
            }
            else if (logVolume > 0)
            {
                scaledVolume = 0;
            }

            return scaledVolume;
        }

        public string GetRenderFile()
        {
            string retVal = string.Empty;
            try
            {
                retVal= renderingTechnology.GetRenderMedia();
            }
            catch (Exception ex)
            {
                ReportRenderingException(ex);
            }
            return retVal;
        }

        public void SetRenderFile(string file)
        {
            try
            {
                renderingTechnology.RenderRegion = renderPanel;

                if (renderingTechnology.FilterState == OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Stopped)
                    renderingTechnology.SetRenderMedia(file);
            }
            catch (Exception ex)
            {
                ReportRenderingException(ex);
            }
        }

        public void StartRendererWithHint(RenderingStartHint startHint)
        {
            try
            {
                _position = 0;

                if (renderingTechnology.FilterState == OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Paused)
                {
                    double position = renderingTechnology.MediaPosition;
                    renderingTechnology.ResumeRenderer(position);
                }
                else
                {
                    renderingTechnology.StartRendererWithHint(startHint);
                }
            }
            catch (Exception ex)
            {
                ReportRenderingException(ex);
            }
        }

        public void StartRenderer()
        {
            try
            {
                _position = 0;

                Logger.LogTrace("Media will be rendered using {0}", renderingTechnology.GetType().Name);

                if (renderingTechnology.FilterState == OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Stopped)
                {
                    renderingTechnology.StartRenderer();
                }
                else if (renderingTechnology.FilterState == OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Paused)
                {
                    double position = renderingTechnology.MediaPosition;
                    renderingTechnology.ResumeRenderer(position);
                }
            }
            catch (Exception ex)
            {
                ReportRenderingException(ex);
            }
        }

        public void PauseRenderer()
        {
            try
            {
                if (renderingTechnology.FilterState == OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Running)
                {
                    renderingTechnology.PauseRenderer();
                }
            }
            catch (Exception ex)
            {
                ReportRenderingException(ex);
            }
        }

        public void ResumeRenderer(double fromPosition)
        {
            try
            {
                if (renderingTechnology.FilterState == OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Paused)
                {
                    _position = fromPosition;
                    renderingTechnology.ResumeRenderer(fromPosition);
                }
            }
            catch (Exception ex)
            {
                ReportRenderingException(ex);
            }

        }

        public void StopRenderer()
        {
            try
            {
                _position = 0;

                if (renderingTechnology.FilterState == OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Running ||
                    renderingTechnology.FilterState == OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Paused)
                {
                    renderingTechnology.StopRenderer();
                }
            }
            catch (Exception ex)
            {
                ReportRenderingException(ex);
            }
        }

        public string AvailableFileTypesFilter
        {
            get
            {
                return string.Format("{0}{1}{2}{3}",
                    AudioFilesFilter, VideoFilesFilter, VideoHDFilesFilter, PlaylistsFilter);
            }
        }

        public string AudioFilesFilter
        { get { return ConstructFilter("TXT_AUDIO_FILES", SupportedAudioTypes); } }

        public string VideoHDFilesFilter
        { get { return ConstructFilter("TXT_VIDEO_HD_FILES", SupportedHDVideoTypes); } }

        public string VideoFilesFilter
        { get { return ConstructFilter("TXT_VIDEO_FILES", SupportedVideoTypes); } }

        public string PlaylistsFilter
        { get { return ConstructFilter("TXT_PLAYLISTS", SupportedPlaylists); } }

        private string ConstructFilter(string tag, List<string> fileTypes)
        {
            string filterFormat = tag + " ({0})|{1}|";
            string filterPart1 = "";
            string filterPart2 = "";

            foreach (string fileType in fileTypes)
            {
                filterPart1 += "*." + fileType;
                filterPart1 += ",";

                filterPart2 += "*." + fileType;
                filterPart2 += ";";
            }

            filterPart1 = filterPart1.TrimEnd(new char[] { ',' });
            filterPart2 = filterPart2.TrimEnd(new char[] { ';' });
            
            return string.Format(filterFormat, filterPart1, filterPart2);
        }

        public VideoFileInfo QueryVideoMediaInfo(string path)
        {
            return renderingTechnology.QueryVideoMediaInfo(path);
        }

        public string GetStateDescription()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("[DUR] : {0}\r\n", this.MediaLength);
            sb.AppendFormat("[POS] : {0}\r\n", this.MediaPosition);
            sb.AppendFormat("[MST] : {0}\r\n", this.FilterState);
            sb.AppendFormat("[FIL] : {0}\r\n", this.GetRenderFile());

            return sb.ToString();
        }

        public void AdjustVideoSize(VideoSizeAdjustmentDirection direction, VideoSizeAdjustmentAction action)
        {
            if ((renderingTechnology.RenderedMediaType == MediaTypes.Video ||
                renderingTechnology.RenderedMediaType == MediaTypes.Both) &&
                renderingTechnology.FilterState == OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Running)
            {
                renderingTechnology.AdjustVideoSize(direction, action);
            }
        }
        #endregion

        #region Construction
        private MediaRenderer()
        {
#if HAVE_DSHOW
            renderingTechnology = new DSTechnology();
#else
            renderingTechnology = new MonoTechnology();
#endif

            SuiteRegistrationSupport.Init(GetSupportedFileProvider());

            timerCheckState = new Timer();
            timerCheckState.Enabled = true;
            timerCheckState.Interval = 500;
            timerCheckState.Start();
            timerCheckState.Tick += new EventHandler(timerCheckState_Tick);

        }

        ~MediaRenderer()
        {
            if (timerCheckState != null)
            {
                timerCheckState.Dispose();
            }

            if (this == __defaultInstance)
            {
                if (ApplicationInfo.IsPlayer)
                {
                    SystemScheduler.Stop();
                }

                __defaultInstance = null;
            }
        }

        double oldMediaPosition = 0;
        int nofPasses = 0;

        double _prevTime = 0;
        void timerCheckState_Tick(object sender, EventArgs e)
        {
            double nowTime = TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds;
            double diff = (nowTime - _prevTime);
            _prevTime = nowTime;

            FireMediaRendererClock();

            OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState newState = OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.NotOpened;

            try
            {
                newState = renderingTechnology.FilterState;
                string newMedia = renderingTechnology.GetRenderMedia();

                if (newState == OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Running && oldMediaPosition == renderingTechnology.MediaPosition)
                {
                    nofPasses++;
                    Logger.LogHeavyTrace("Media position did not change in the last {0} iterations", nofPasses);
                }
                else
                {
                    nofPasses = 0;
                }

                if (renderingTechnology.EndOfMedia || (!renderingTechnology.IsStreamedMedia && nofPasses > 10))
                {
                    if (newState != OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Stopped)
                    {
                        renderingTechnology.StopRenderer();
                    }

                    newState = OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.NotOpened;
                }
                else if (oldState == OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.NotOpened && newState == OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Stopped)
                {
                    newState = OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.NotOpened;
                }

                if (newState != oldState || newMedia != oldMedia)
                {
                    FireFilterStateChanged(oldState, oldMedia, newState, newMedia);
                }

                switch (newState)
                {
                    case OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Running:
                        switch (oldState)
                        {
                            case OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Running:
                                _position += diff;
                                break;

                            case OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.NotOpened:
                            case OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Stopped:
                                //break;

                            case OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Paused:
                                _position = renderingTechnology.MediaPosition;
                                break;
                        }
                        break;

                    case OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Stopped:
                    case OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.NotOpened:
                        _position = 0;
                        break;

                    case OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Paused:
                        break;
                }

                if (newState != OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Stopped &&
                    newState != OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.NotOpened)
                {
                    FireMediaRendererHeartbeat();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                oldState = newState;
                oldMedia = renderingTechnology.GetRenderMedia();
                oldMediaPosition = renderingTechnology.MediaPosition;
            }
        }

        void ReportRenderingException(Exception ex)
        {
            ErrorDispatcher.DispatchError(ex);
            try
            {
                RenderingException rex = RenderingException.FromException(ex);
                RenderingExceptionEventArgs args = new RenderingExceptionEventArgs(rex);
                FireMediaRenderingException(args);

                if (args.Handled)
                    return;
            }
            catch
            {
            }

            throw ex;
        }

        #endregion

        public override bool Equals(object obj)
        {
            MediaRenderer mr = (obj as MediaRenderer);
            if (mr != null)
            {
                return (this._hash == mr._hash);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _hash;
        }

        public static bool IsSupportedPlaylist(string path)
        {
            string ext = PathUtils.GetExtension(path);
            return MediaRenderer.SupportedPlaylists.Contains(ext);
        }


        public static bool IsSupportedMedia(string path)
        {
            try
            {
                if (PathUtils.IsRootPath(path))
                {
                    DvdMedia dvdMedia = DvdMedia.FromPath(path);
                    if (dvdMedia != null)
                        return true; // DVD's are supported media
                }

                FileInfo info = new FileInfo(path);

                if ((info.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    return FolderContainsMediaFiles(path);
                }
            }
            catch
            {
            }

            string ext = PathUtils.GetExtension(path);
            return MediaRenderer.AllMediaTypes.Contains(ext);
        }

        public static bool FolderContainsMediaFiles(string path)
        {
            return FolderContainsMediaFiles(path, 0);
        }

        const int MaxRecursionLevel = 3;

        public static bool FolderContainsMediaFiles(string path, int level)
        {
            IEnumerable<string> files = Directory.EnumerateFiles(path);
            if (files != null)
            {
                foreach (string file in files)
                {
                    if (IsSupportedMedia(file))
                    {
                        return true;
                    }
                }
            }

            IEnumerable<string> subfolders = Directory.EnumerateDirectories(path);
            if (subfolders != null)
            {
                foreach (string subfolder in subfolders)
                {
                    if (level < (MaxRecursionLevel - 1) &&
                        FolderContainsMediaFiles(subfolder, level + 1))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (renderingTechnology != null)
            {
                renderingTechnology.Dispose();
                renderingTechnology = null;
            }
        }

        #endregion

        #region Published events
        public event MediaRendererEventHandler MediaRendererClock = null;
        private void FireMediaRendererClock()
        {
            if (MediaRendererClock != null)
            {
                MediaRendererClock();
            }
        }

        public event MediaRendererEventHandler MediaRendererHeartbeat = null;
        private void FireMediaRendererHeartbeat()
        {
            if (MediaRendererHeartbeat != null)
            {
                MediaRendererHeartbeat();
            }
        }

        public event FilterStateChangedHandler FilterStateChanged = null;
        private void FireFilterStateChanged(OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState oldState, string oldMedia,
            OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState newState, string newMedia)
        {
            if (FilterStateChanged != null)
            {
                FilterStateChanged(oldState, oldMedia, newState, newMedia);
            }
        }
        
        public event MediaRenderingExceptionHandler MediaRenderingException = null;
        private void FireMediaRenderingException(RenderingExceptionEventArgs args)
        {
            if (MediaRenderingException != null)
            {
                MediaRenderingException(args);
            }
        }
        
        #endregion

        #region FFdShow subtitle and OSD

        IntPtr _oldFfdShowHandle = IntPtr.Zero;

        public string CurrentSubtitleFile
        {
            get
            {
                using (FfdShowLib i = FfdShowInstance())
                {
                    return i.CurrentSubtitleFile;
                }
            }

            set
            {
                using (FfdShowLib i = FfdShowInstance())
                {
                    i.CurrentSubtitleFile = value;
                }
            }
        }

        public void DisplayOsdMessage(string msg)
        {
            if (AppSettings.OsdEnabled)
            {
                using (FfdShowLib i = FfdShowInstance())
                {
                    int osdPersistTimer = AppSettings.OsdPersistTimer;
                    float frameRate = i.getFrameRate();
                    int persistFrames = (int)(osdPersistTimer * frameRate / 1000);

                    // OsdPersistTimer is given in msec
                    i.clearOsd();
                    i.setOsdDuration(persistFrames);
                    i.displayOSDMessage(msg, true);
                }
            }
        }

        public void ReloadFfdShowSettings()
        {
            using (FfdShowLib i = FfdShowInstance())
            {
                EnforceSettings(i);
            }
        }

        private void EnforceSettings(FfdShowLib ffdShowLib)
        {
            // Subtitles
            ffdShowLib.DoShowSubtitles = AppSettings.SubEnabled;

            if (AppSettings.SubEnabled)
            {
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_fontColor,
                    ColorHelper.BGR(AppSettings.SubColor));
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_fontSizeA,
                    AppSettings.SubFont.Height);
                ffdShowLib.setStringParam(FFDShowConstants.FFDShowDataId.IDFF_fontName,
                    AppSettings.SubFont.OriginalFontName);
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_fontCharset,
                  AppSettings.SubFont.GdiCharSet);

                LOGFONT lf = new LOGFONT();
                AppSettings.SubFont.ToLogFont(lf);

                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_fontWeight,
                    lf.lfWeight);
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_fontItalic,
                   lf.lfItalic);
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_fontUnderline,
                   lf.lfUnderline);
            }

            if (AppSettings.OsdEnabled)
            {
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_OSDfontColor,
                    ColorHelper.BGR(AppSettings.OsdColor));
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_OSDfontSize,
                    AppSettings.OsdFont.Height);
                ffdShowLib.setStringParam(FFDShowConstants.FFDShowDataId.IDFF_OSDfontName,
                    AppSettings.OsdFont.OriginalFontName);
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_OSDfontCharset,
                    AppSettings.OsdFont.GdiCharSet);

                LOGFONT lf = new LOGFONT();
                AppSettings.OsdFont.ToLogFont(lf);

                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_OSDfontWeight,
                    lf.lfWeight);
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_OSDfontItalic,
                   lf.lfItalic);
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_OSDfontUnderline,
                   lf.lfUnderline);
            }
        }

        private FfdShowLib FfdShowInstance()
        {
            string renderFile = this.GetRenderFile();
            FfdShowLib ffdShowLib = new FfdShowLib(renderFile);

            if (ffdShowLib.checkFFDShowActive())
            {
                if (ffdShowLib.FFDShowInstanceHandle != _oldFfdShowHandle)
                {
                    // API re-created so enforce parameters
                    EnforceSettings(ffdShowLib);

                    _oldFfdShowHandle = ffdShowLib.FFDShowInstanceHandle;
                }
            }

            return ffdShowLib;
        }

        #endregion
    }

   

    public abstract class RenderingStartHint
    {
        public abstract bool IsSubtitleHint { get; }
    }
}

#region ChangeLog
#region Date: 01.08.2006			Author: octavian
// File created.
#endregion
#endregion