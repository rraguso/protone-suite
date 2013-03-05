using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using OPMedia.Core;
using OPMedia.Core.ApplicationSettings;
using System.Configuration;
using System.Net.Configuration;
using System.Threading;
using QuartzTypeLib;
using DexterLib;
using OPMedia.Runtime.ProTONE.Rendering.SHOUTCast;

namespace OPMedia.Runtime.ProTONE.Rendering.DS
{
    public class DSShoutcastRenderer : DsRendererBase
    {
        const int ChunkSize = 16384;

        ShoutcastStream _stream = null;
        Thread _thRead = null;
        Thread _thPlay = null;

        ManualResetEvent _stopReadEvent = new ManualResetEvent(false);
        Queue<byte[]> _bufferQueue = new Queue<byte[]>();

        protected override void DoStartRenderer()
        {
            if (renderMediaName == null || renderMediaName.Length <= 0)
                return;

            if (_stream != null)
            {
                _stream.Close();
                _stream = null;
            }

            byte[] data = new byte[ChunkSize];
            _stream = new ShoutcastStream(renderMediaName);

            int read = _stream.Read(data, 0, ChunkSize);
            if (read <= 0)
            {
                throw new System.IO.EndOfStreamException();
            }

            _thRead = new Thread(new ThreadStart(StreamRead));
            _thPlay = new Thread(new ThreadStart(StreamPlay));

            _thRead.Start();
            _thPlay.Start();
        }

        private void StreamPlay()
        {
            while (!_stopReadEvent.WaitOne(5))
            {
                byte[] data = null;
                lock (_bufferQueue)
                {
                    if (_bufferQueue.Count > 0)
                    {
                        data = _bufferQueue.Dequeue();
                    }
                }

                if (data != null)
                {
                    PlayData(data);
                }
            }
        }

        private void PlayData(byte[] data)
        {
        }

        private void StreamRead()
        {
            byte[] data = new byte[ChunkSize];

            while (!_stopReadEvent.WaitOne(5))
            {
                int read = _stream.Read(data, 0, ChunkSize);
                if (read > 0)
                {
                    byte[] playableData = new byte[read];
                    Array.Copy(data, playableData, read);

                    lock (_bufferQueue)
                    {
                        _bufferQueue.Enqueue(playableData);
                    }
                }
            }
        }

        protected override void HandleGraphEvent(int code, int p1, int p2)
        {
        }

        protected override double GetDurationScaleFactor()
        {
            return 1;
        }

        protected override int DoGetSubtitleStream()
        {
            return -1;
        }

        protected override void DoSetSubtitleStream(int sid)
        {
        }

        private void InitMedia()
        {
            mediaControl = Activator.CreateInstance(Type.GetTypeFromCLSID(Filters.FilterGraphNoThread, true))
                        as IMediaControl;

#if HAVE_SAMPLES
            //SetupAudioSampleGrabber();
#endif

            
            mediaPosition = mediaControl as IMediaPosition;
            videoWindow = mediaControl as IVideoWindow;
            basicVideo = mediaControl as IBasicVideo;
            basicAudio = mediaControl as IBasicAudio;
            mediaEvent = mediaControl as IMediaEventEx;
        }

        protected override object DoGetGraphFilter()
        {
            return null;
        }
    }

    
}
