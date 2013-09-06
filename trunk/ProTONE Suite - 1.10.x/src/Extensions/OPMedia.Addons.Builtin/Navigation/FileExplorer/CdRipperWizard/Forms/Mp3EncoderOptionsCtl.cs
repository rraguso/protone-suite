using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Tasks;
using OPMedia.Runtime.ProTONE.Compression.Lame;

namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Forms
{
    public partial class Mp3EncoderOptionsCtl : EncoderConfiguratorCtl
    {
        internal Task Task { get; set; }

        public BE_CONFIG Mp3ConversionOptions
        {
            get
            {
                return this.Task.Mp3ConversionOptions;
            }
        }

        public override CdRipperOutputFormatType OutputFormat
        {
            get
            {
                return CdRipperOutputFormatType.MP3;
            }
        }

        public Mp3EncoderOptionsCtl()
        {
            InitializeComponent();

            cmbChannelMode.Items.Clear();
            foreach (var x in Enum.GetValues(typeof(MpegMode)))
            {
                switch ((MpegMode)x)
                {
                    case MpegMode.JOINT_STEREO:
                    case MpegMode.STEREO:
                    case MpegMode.MONO:
                        cmbChannelMode.Items.Add(x);
                        break;
                }

            }

            cmbVbrMode.Items.Clear();
            foreach (var x in Enum.GetValues(typeof(VBRMETHOD)))
            {
                cmbVbrMode.Items.Add(x);
            }

            this.Load += new EventHandler(Mp3EncoderOptionsCtl_Load);
        }

        void Mp3EncoderOptionsCtl_Load(object sender, EventArgs e)
        {
            // ---- 1 ----
            grpOptionsVBR.Visible = (Mp3ConversionOptions.format.lhv1.bEnableVBR != 0);
            cmbBitrateMode.SelectedIndex = Mp3ConversionOptions.format.lhv1.bEnableVBR;
            cmbBitrateMode.SelectedIndexChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.lhv1.bEnableVBR = cmbBitrateMode.SelectedIndex;
                grpOptionsVBR.Visible = (Mp3ConversionOptions.format.lhv1.bEnableVBR != 0);
            };

            // ---- 2 ----
            cmbChannelMode.SelectedIndex = cmbChannelMode.FindStringExact(Mp3ConversionOptions.format.lhv1.nMode.ToString());
            cmbChannelMode.SelectedIndexChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.lhv1.nMode =
                    (MpegMode)Enum.Parse(typeof(MpegMode), cmbChannelMode.Text);
            };

            // ---- 3 ----
            cmbBitrate.SelectedIndex = cmbBitrate.FindStringExact(Mp3ConversionOptions.format.lhv1.dwBitrate.ToString());
            cmbBitrate.SelectedIndexChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.lhv1.dwBitrate = uint.Parse(cmbBitrate.Text);
            };

            // ---- 4 ----
            if (Mp3ConversionOptions.format.lhv1.dwMaxBitrate == 0)
                Mp3ConversionOptions.format.lhv1.dwMaxBitrate = Mp3ConversionOptions.format.lhv1.dwBitrate;

            cmbVbrMax.SelectedIndex = cmbBitrate.FindStringExact(Mp3ConversionOptions.format.lhv1.dwMaxBitrate.ToString());
            cmbVbrMax.SelectedIndexChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.lhv1.dwMaxBitrate = uint.Parse(cmbVbrMax.Text);
            };

            // ---- 5 ----
            cmbVbrQuality.SelectedIndex = Mp3ConversionOptions.format.lhv1.nVBRQuality;
            cmbVbrQuality.SelectedIndexChanged += (s, a) =>
                {
                    Mp3ConversionOptions.format.lhv1.nVBRQuality = cmbVbrQuality.SelectedIndex;
                };

            // ---- 6 ----
            cmbVbrMode.SelectedIndex = cmbVbrMode.FindStringExact(Mp3ConversionOptions.format.lhv1.nVbrMethod.ToString());
            cmbVbrMode.SelectedIndexChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.lhv1.nVbrMethod =
                    (VBRMETHOD)Enum.Parse(typeof(VBRMETHOD), cmbVbrMode.Text);
            };

            // ---- 7 ----
            chkCopyright.Checked = (Mp3ConversionOptions.format.lhv1.bCopyright != 0);
            chkCopyright.CheckedChanged += (s, a) =>
                {
                    Mp3ConversionOptions.format.lhv1.bCopyright = chkCopyright.Checked ? 1 : 0;
                };

            // ---- 8 ----
            chkPrivate.Checked = (Mp3ConversionOptions.format.lhv1.bPrivate != 0);
            chkPrivate.CheckedChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.lhv1.bPrivate = chkPrivate.Checked ? 1 : 0;
            };

            // ---- 9 ----
            chkCRC.Checked = (Mp3ConversionOptions.format.lhv1.bCRC != 0);
            chkCRC.CheckedChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.lhv1.bCRC = chkCRC.Checked ? 1 : 0;
            };

            // ---- 10 ----
            chkOriginal.Checked = (Mp3ConversionOptions.format.lhv1.bOriginal != 0);
            chkOriginal.CheckedChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.lhv1.bOriginal = chkOriginal.Checked ? 1 : 0;
            };

            // --- 11 ----
            chkGenerateID3.Checked = this.Task.GenerateTagsFromTrackMetadata;
            chkGenerateID3.CheckedChanged += (s, a) =>
            {
                this.Task.GenerateTagsFromTrackMetadata = chkGenerateID3.Checked;
            };
        }
    }
}
