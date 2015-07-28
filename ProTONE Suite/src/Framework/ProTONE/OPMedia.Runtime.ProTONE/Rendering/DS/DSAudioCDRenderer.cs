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
using OPMedia.Runtime.ProTONE.Rendering.DS.DsFilters;


namespace OPMedia.Runtime.ProTONE.Rendering.DS
{
    public class DSAudioCDRenderer : DsCustomRenderer
    {
        DSBaseSourceFilter _source = null;

        protected override void DoStartRendererWithHint(RenderingStartHint startHint)
        {
            if (renderMediaName == null || renderMediaName.Length <= 0)
                return;

            GC.Collect();

            InitMedia();

            int hr = mediaPosition.put_Rate(1);
            DsError.ThrowExceptionForHR(hr);

            // Run the graph to play the media file
            hr = mediaControl.Run();
            DsError.ThrowExceptionForHR(hr);

            // HACK: call GetMedialenght once here to ensure that durationScaleFactor is buuilt up
            double len = GetMediaLength();
        }

        private void InitMedia()
        {
            GC.Collect();

            mediaControl = Activator.CreateInstance(Type.GetTypeFromCLSID(Filters.FilterGraph, true))
                        as IMediaControl;
            
            // Create Filter
            _source = new DSBaseSourceFilter(new AudioCdSourceFilter());
            
            // load the file
            _source.FileName = renderMediaName;
            
            // Add to the filter Graph
            _source.FilterGraph = (mediaControl) as IGraphBuilder;

            if (_source.OutputPin == null)
                throw new RenderingException("Unable to render the file: " + renderMediaName);

            // Render the output pin
            int hr = (int)_source.OutputPin.Render();
            DsError.ThrowExceptionForHR(hr);

            InitAudioSampleGrabber_v2();

            mediaPosition = mediaControl as IMediaPosition;
            videoWindow = null;
            basicVideo = null;
            basicAudio = mediaControl as IBasicAudio;
            mediaEvent = mediaControl as IMediaEventEx;

            try
            {
                hr = basicAudio.put_Volume((int)VolumeRange.Minimum);
                isAudioAvailable = (hr >= 0);

                CompleteAudioSampleGrabberIntialization();
            }
            catch
            {
                isAudioAvailable = false;
            }
        }
    }

}

#endif
