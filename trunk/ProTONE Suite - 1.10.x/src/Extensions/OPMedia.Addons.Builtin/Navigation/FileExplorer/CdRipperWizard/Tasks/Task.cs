using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.UI;
using System.ComponentModel;
using OPMedia.Runtime.ProTONE.Rendering.Cdda;
using System.IO;
using OPMedia.Runtime.ProTONE.Rendering.Cdda.Freedb;
using OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Helpers;

namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Tasks
{
    internal class Task : BackgroundTask
    {
        #region BackgroundTask overrides

        int currentStep = 0;
        List<Track> tracks = new List<Track>();

        [Browsable(false)]
        public override int CurrentStep
        {
            get { return currentStep; }
        }

        [Browsable(false)]
        public override int TotalSteps
        {
            get { return tracks.Count; }
        }

        [Browsable(false)]
        public override bool IsFinished
        {
            get { return (currentStep >= tracks.Count); }
        }

        public override StepDetail RunNextStep()
        {
            StepDetail result = ProcessTrack(tracks[currentStep]);
            currentStep++;
            return result;
        }

        public override void Reset()
        {
            currentStep = 0;
        }

        #endregion

        [Browsable(false)]
        public List<Track> Tracks
        { get { return tracks; } set { tracks = value; } }

        private DriveInfo _drive = null;

        [Browsable(false)]
        public DriveInfo Drive { get; set; }

        [Browsable(false)]
        public string OutputFolder { get; set; }

        [Browsable(false)]
        public string OutputFilePattern { get; set; }

        public CdRipperOutputFormatType OutputFormatType { get; set; }

        private StepDetail ProcessTrack(Track track)
        {
            StepDetail detail = new StepDetail();
            detail.Description = track.ToString();
            detail.IsSuccess = false;

            try
            {
                CdRipper grabber = CdRipper.CreateGrabber(this.OutputFormatType);
                char letter = Drive.RootDirectory.FullName.ToUpperInvariant()[0];
                using (CDDrive cd = new CDDrive())
                {
                    if (cd.Open(letter) && cd.Refresh() && cd.HasAudioTracks())
                    {
                        string tempFile = grabber.Grab(cd, track);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                detail.Results = ex.Message;
            }

            return detail;

        }
    }

    public enum CdRipperOutputFormatType
    {
        WAV = 0,
        MP3,
        WMA,
        OGG
    }
}
