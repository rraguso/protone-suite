﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.UI;
using System.ComponentModel;
using OPMedia.Runtime.ProTONE.Rendering.Cdda;
using System.IO;
using OPMedia.Runtime.ProTONE.Rendering.Cdda.Freedb;
using OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Helpers;
using OPMedia.Core.Utilities;
using OPMedia.Runtime.ProTONE.Compression.Lame;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Core.TranslationSupport;
using System.Threading;

namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Tasks
{
    internal class Task : BackgroundTask
    {
        CdRipper _grabber = null;

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

        [Browsable(false)]
        public DriveInfo Drive { get; set; }

        [Browsable(false)]
        public string OutputFolder { get; set; }

        [Browsable(false)]
        public string OutputFilePattern { get; set; }

        [Browsable(false)]
        public BE_CONFIG Mp3ConversionOptions { get; set; }

        [Browsable(false)]
        public CdRipperOutputFormatType OutputFormatType { get; set; }

        public bool GenerateTagsFromTrackMetadata { get; set; }

        public Task()
        {
            this.Mp3ConversionOptions = new BE_CONFIG();
            this.GenerateTagsFromTrackMetadata = true;
        }

        private StepDetail ProcessTrack(Track track)
        {
            string newFileName = string.Format("{0}.{1}",
                CdRipper.GetFileName(WordCasing.KeepCase, track, OutputFilePattern),
                this.OutputFormatType.ToString().ToLowerInvariant());

            StepDetail detail = new StepDetail();
            detail.Description = Translator.Translate("TXT_PROCESSING_TRACK", track, newFileName);
            RaiseTaskStepInitEvent(detail);

            detail.Results = Translator.Translate("TXT_UNHANDLED");
            detail.IsSuccess = false;

            try
            {
                _grabber = CdRipper.CreateGrabber(this.OutputFormatType);
                char letter = Drive.RootDirectory.FullName.ToUpperInvariant()[0];
                using (CDDrive cd = new CDDrive())
                {
                    if (cd.Open(letter) && cd.Refresh() && cd.HasAudioTracks())
                    {
                        string destFile = Path.Combine(OutputFolder, newFileName);

                        switch (this.OutputFormatType)
                        {
                            case CdRipperOutputFormatType.WAV:
                                break;

                            case CdRipperOutputFormatType.MP3:
                                (_grabber as GrabberToMP3).Mp3ConversionOptions = this.Mp3ConversionOptions;
                                break;
                        }

                        _grabber.Grab(cd, track, destFile, this.GenerateTagsFromTrackMetadata);
                    }
                }

                detail.IsSuccess = true;
            }
            catch (Exception ex)
            {
                detail.Results = ex.Message;
            }

            return detail;
        }

        protected override void OnTaskCancelled()
        {
            _grabber.RequestCancel();
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
