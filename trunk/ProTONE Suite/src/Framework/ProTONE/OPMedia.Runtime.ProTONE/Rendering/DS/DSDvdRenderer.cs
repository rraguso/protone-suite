#if HAVE_DSHOW

using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.ProTONE.Rendering.Base;

using System.Runtime.InteropServices;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Core;
using OPMedia.Core.Logging;
using System.Drawing;
using OPMedia.Core.Configuration;
using System.Threading;

using System.Windows.Forms;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;
using OPMedia.Runtime.ProTONE.Configuration;


namespace OPMedia.Runtime.ProTONE.Rendering.DS
{
    public class DSDvdRenderer : DsCustomRenderer
    {
        IDvdGraphBuilder dvdGraphBuilder = null;
        IDvdInfo2 dvdInfo = null;
        IDvdControl2 dvdControl2 = null;
        OptIDvdCmd _lastCmd = null;

        private MenuMode menuMode;

        TimeSpan _currentPosition = new TimeSpan();
        TimeSpan _totalTime = new TimeSpan();

        VideoDvdInformation _vdi = null;

        protected override void DoStartRenderer()
        {
            // Start rendering from the beginning of DVD media
            DoStartRendererWithHint(DvdRenderingStartHint.Beginning);
        }

        protected override void DoStartRendererWithHint(RenderingStartHint startHint)
        {
            DvdRenderingStartHint hint = startHint as DvdRenderingStartHint;

            if (dvdGraphBuilder == null)
            {
                _vdi = new VideoDvdInformation(renderMediaName);

                InitMedia();
                InitAudioAndVideo();

                // Run the graph to play the media file
                int hr = mediaControl.Run();
                DsError.ThrowExceptionForHR(hr);

                // Give enough time for the filter graph to be completely built
                Thread.Sleep(500);
            }

            if (hint == DvdRenderingStartHint.MainMenu)
            {
                int hr = dvdControl2.ShowMenu(DvdMenuId.Title, DvdCmdFlags.Flush | DvdCmdFlags.Block, _lastCmd);
                DsError.ThrowExceptionForHR(hr);
            }
            else if (hint == DvdRenderingStartHint.Beginning)
            {
                int hr = 0;

                if (ProTONEConfig.DisableDVDMenu)
                    hr = dvdControl2.PlayTitle(1, DvdCmdFlags.Flush | DvdCmdFlags.Block, _lastCmd);
                else
                    //dvdControl.PlayForwards(1f, DvdCmdFlags.Flush | DvdCmdFlags.Block, _lastCmd);
                    hr = dvdControl2.ShowMenu(DvdMenuId.Title, DvdCmdFlags.Flush | DvdCmdFlags.Block, _lastCmd);

                DsError.ThrowExceptionForHR(hr);
            }
            else if (hint.Location.ChapterNum == 0)
            {
                int hr = dvdControl2.PlayTitle(hint.Location.TitleNum, DvdCmdFlags.Flush | DvdCmdFlags.Block, _lastCmd);
                DsError.ThrowExceptionForHR(hr);
            }
            else
            {
                int hr = dvdControl2.PlayChapterInTitle(hint.Location.TitleNum, hint.Location.ChapterNum,
                    DvdCmdFlags.Flush | DvdCmdFlags.Block, _lastCmd);
                DsError.ThrowExceptionForHR(hr);
            }

            if (ProTONEConfig.PrefferedSubtitleLang > 0)
            {
                int sid = _vdi.GetSubtitle(ProTONEConfig.PrefferedSubtitleLang);
                if (sid > 0)
                {
                    SetSubtitleStream(sid);
                }
            }
        }

        private void InitMedia()
        {
            GC.Collect();

            string volumePath = string.Empty;
            if (renderMediaName.ToUpperInvariant().EndsWith("VIDEO_TS"))
            {
                volumePath = renderMediaName;
            }
            else
            {
                volumePath = System.IO.Path.Combine(renderMediaName, "VIDEO_TS");
            }

            dvdGraphBuilder =
                Activator.CreateInstance(Type.GetTypeFromCLSID(Filters.DvdGraphBuilder, true))
                as IDvdGraphBuilder;

            AMDvdRenderStatus status;

            dvdGraphBuilder.RenderDvdVideoVolume(volumePath, AMDvdGraphFlags.VMR9Only, out status);
            

            if (status.bDvdVolInvalid)
                throw new COMException(VideoDvdInformation.ErrDvdVolume, -1);

            dvdInfo = GetInterface(typeof(IDvdInfo2)) as IDvdInfo2;

            dvdControl2 = GetInterface(typeof(IDvdControl2)) as IDvdControl2;

            int hr = dvdControl2.SetOption(DvdOptionFlag.HMSFTimeCodeEvents, true);	// use new HMSF timecode format
            DsError.ThrowExceptionForHR(hr);
            
            hr = dvdControl2.SetOption(DvdOptionFlag.ResetOnStop, false);
            DsError.ThrowExceptionForHR(hr);

            hr = dvdControl2.SetOption(DvdOptionFlag.AudioDuringFFwdRew, false);
            DsError.ThrowExceptionForHR(hr);
            
            //dvdControl.SelectVideoModePreference(DvdPreferredDisplayMode.DisplayContentDefault);

            dvdGraphBuilder.GetFiltergraph(out mediaControl);

            if (mediaControl == null)
                throw new RenderingException("Unable to render the file: " + renderMediaName);

#if HAVE_SAMPLES
            InitAudioSampleGrabber_v2();
            CompleteAudioSampleGrabberIntialization();
#endif

            mediaEvent = mediaControl as IMediaEventEx;
            mediaPosition = mediaControl as IMediaPosition;
            videoWindow = mediaControl as IVideoWindow;
            basicVideo = mediaControl as IBasicVideo;
            basicAudio = mediaControl as IBasicAudio;

            renderRegion.MouseMove -= new MouseEventHandler(renderRegion_MouseMove);
            renderRegion.MouseMove += new MouseEventHandler(renderRegion_MouseMove);
            renderRegion.MouseDown -= new MouseEventHandler(renderRegion_MouseDown);
            renderRegion.MouseDown += new MouseEventHandler(renderRegion_MouseDown);

        }
        
        private object GetInterface(Type interfaceType)
        {
            object comobj = null;
            dvdGraphBuilder.GetDvdInterface(interfaceType.GUID, out comobj);
            return comobj;
        }

        
        void renderRegion_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ((dvdControl2 == null) || (menuMode != MenuMode.Buttons))
                return;
            
            int hr = dvdControl2.ActivateAtPosition(DsPOINT.FromPoint(e.Location));
            DsError.ThrowExceptionForHR(hr);
        }

        void renderRegion_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ((dvdControl2 == null) || (menuMode != MenuMode.Buttons))
                return;

            int hr = dvdControl2.SelectAtPosition(DsPOINT.FromPoint(e.Location));
            DsError.ThrowExceptionForHR(hr);
        }

        //protected override void  DoStopInternal(object state)
        //{
        //    try
        //    {
        //        if (mediaControl != null)
        //        {
        //            int hr = mediaControl.Stop();
        //            DsError.ThrowExceptionForHR(hr);

        //            if (dvdControl2 != null)
        //            {
        //                Marshal.ReleaseComObject(dvdControl2);
        //                dvdControl2 = null;
        //            }

        //            if (dvdInfo != null)
        //            {
        //                Marshal.ReleaseComObject(dvdInfo);
        //                dvdInfo = null;
        //            }

        //            if (dvdGraphBuilder != null)
        //            {
        //                Marshal.ReleaseComObject(dvdGraphBuilder);
        //                dvdGraphBuilder = null;
        //            }

        //            mediaControl = null;
        //            mediaPosition = null;
        //            videoWindow = null;
        //            basicVideo = null;
        //            basicAudio = null;
        //            mediaEvent = null;
        //        }

        //        GC.Collect();
        //    }
        //    catch (Exception ex)
        //    {
        //        // This is running on other thread than the DSRenderer,
        //        // so its exceptions are not caught in MediaRenderer
        //        ErrorDispatcher.DispatchError(ex);
        //    }
        //}

        protected override void DoResumeRenderer(double fromPosition)
            {
                if (mediaControl != null)
                {
                int hr = mediaControl.Run();
                DsError.ThrowExceptionForHR(hr);
            }

            if (fromPosition > 0)
                SetMediaPosition(fromPosition);

        }

        protected override double GetMediaLength()
        {
            return _totalTime.TotalSeconds;
        }

        protected override double GetMediaPosition()
        {
            return _currentPosition.TotalSeconds;
        }

        protected override void SetMediaPosition(double pos)
        {
            TimeSpan tsNewPos = TimeSpan.FromSeconds(pos);

            DvdHMSFTimeCode timeCode = new DvdHMSFTimeCode();
            timeCode.bHours = (byte)tsNewPos.TotalHours;
            timeCode.bMinutes = (byte)tsNewPos.Minutes;
            timeCode.bSeconds = (byte)tsNewPos.Seconds;
            timeCode.bFrames = 1;

            int hr = dvdControl2.PlayAtTime(ref timeCode, DvdCmdFlags.None, _lastCmd);
            DsError.ThrowExceptionForHR(hr);
        }

        protected override bool IsMediaSeekable()
        {
            return true;
        }

        protected override bool IsEndOfMedia()
        {
            return false;
        }

        protected override void HandleGraphEvent(EventCode code, int p1, int p2)
        {
            

            switch (code)
            {
                case EventCode.DvdCurrentHmsfTime:
                    byte[] ati = BitConverter.GetBytes(p1);
                    _currentPosition = new TimeSpan(ati[0], ati[1], ati[2]);
                    break;

                case EventCode.DvdDomChange:
                    DvdDomain dom = (DvdDomain)p1;
                    Logger.LogHeavyTrace("Currently in domain: {0}", dom);

                    if (dom == DvdDomain.Title)
                    {
                        object comobj = null;
                        dvdGraphBuilder.GetDvdInterface(typeof(IDvdInfo2).GUID, out comobj);

                        dvdInfo = comobj as IDvdInfo2;

                        DvdHMSFTimeCode timeCode;
                        DvdTimeCodeFlags flags;
                        dvdInfo.GetTotalTitleTime(out timeCode, out flags);
                        _totalTime = new TimeSpan(timeCode.bHours, timeCode.bMinutes, timeCode.bSeconds);
                    }
                    break;

                case EventCode.DvdChaptStart:
                case EventCode.DvdTitleChange:
                case EventCode.DvdCmdStart:
                case EventCode.DvdCmdEnd:
                    break;

                case EventCode.DvdStillOn:
                    if (p1 == 0)
                        menuMode = MenuMode.Buttons;
                    else
                        menuMode = MenuMode.Still;
                    break;

                case EventCode.DvdStillOff:
                    if (menuMode == MenuMode.Still)
                        menuMode = MenuMode.No;
                    break;

                case EventCode.DvdButtonChange:
                    if (p1 <= 0)
                        menuMode = MenuMode.No;
                    else
                        menuMode = MenuMode.Buttons;
                    break;

                case EventCode.DvdNoFpPgc:
                    if (dvdControl2 != null)
                    {
                        int hr = dvdControl2.PlayTitle(1, DvdCmdFlags.None, _lastCmd);
                        DsError.ThrowExceptionForHR(hr);
                    }
                    break;
                }
            }

            protected override int DoGetSubtitleStream()
            {
                int nStreams = 0;
                int crtStream = 0;
                bool disabled = true;

                dvdInfo.GetCurrentSubpicture(out nStreams, out crtStream, out disabled);

                if (!disabled)
                {
                    return crtStream;
                }

                return -1;
            }

            protected override void DoSetSubtitleStream(int sid)
            {
                try
                {
                    int hr = dvdControl2.SelectSubpictureStream(sid, DvdCmdFlags.None, _lastCmd);
                    DsError.ThrowExceptionForHR(hr);
                    
                    hr = dvdControl2.SetSubpictureState(true, DvdCmdFlags.None, _lastCmd);
                    DsError.ThrowExceptionForHR(hr);
                }
                catch (Exception exception)
                {
                    ErrorDispatcher.DispatchError(exception);
                }
            }

            protected override double GetDurationScaleFactor()
            {
                return 1;
            }
    }

    
}

#endif
