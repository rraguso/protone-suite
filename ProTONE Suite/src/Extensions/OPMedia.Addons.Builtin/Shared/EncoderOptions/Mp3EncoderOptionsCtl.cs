using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.ProTONE.Compression.Lame;
using OPMedia.UI.Dialogs;

namespace OPMedia.Addons.Builtin.Shared.EncoderOptions
{
    public partial class Mp3EncoderOptionsCtl : EncoderConfiguratorCtl
    {
        public bool UsedForCdRipper { get; set; }
        
        public override AudioMediaFormatType OutputFormat
        {
            get
            {
                return AudioMediaFormatType.MP3;
            }
        }

        public Mp3EncoderSettings Mp3EncoderSettings { get; set; }

        private BE_CONFIG Mp3ConversionOptions
        {
            get
            {
                return Mp3EncoderSettings.Mp3ConversionOptions;
            }

            set
            {
                Mp3EncoderSettings.Mp3ConversionOptions = value;
            }
        }

        private bool GenerateTagsFromTrackMetadata
        {
            get { return Mp3EncoderSettings.GenerateTagsFromTrackMetadata; }
            set { Mp3EncoderSettings.GenerateTagsFromTrackMetadata = value; }
        }

        public Mp3EncoderOptionsCtl() 
        {
            InitializeComponent();
            this.Load += new EventHandler(Mp3EncoderOptionsCtl_Load);
        }

        void Mp3EncoderOptionsCtl_Load(object sender, EventArgs e)
        {
            cmbChannelMode.Items.Clear();
            foreach (var x in Enum.GetValues(typeof(MpegMode)))
            {
                switch ((MpegMode)x)
                {
                    case MpegMode.JOINT_STEREO:
                    case MpegMode.STEREO:
                        cmbChannelMode.Items.Add(x);
                        break;

                    case MpegMode.MONO:
                        {
                            // Mono not available if ripping CD tracks.
                            if (UsedForCdRipper == false)
                                cmbChannelMode.Items.Add(x);
                        }
                        break;
                }

            }

            cmbVbrMode.Items.Clear();
            foreach (var x in Enum.GetValues(typeof(VBRMETHOD)))
            {
                cmbVbrMode.Items.Add(x);
            }


            // ---- 1 ----
            grpOptionsVBR.Visible = (Mp3ConversionOptions.format.bEnableVBR != 0);
            cmbBitrateMode.SelectedIndex = Mp3ConversionOptions.format.bEnableVBR;
            cmbBitrateMode.SelectedIndexChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.bEnableVBR = cmbBitrateMode.SelectedIndex;
                Mp3ConversionOptions.format.bWriteVBRHeader = cmbBitrateMode.SelectedIndex;
                grpOptionsVBR.Visible = (Mp3ConversionOptions.format.bEnableVBR != 0);
            };

            // ---- 2 ----
            cmbChannelMode.SelectedIndex = cmbChannelMode.FindStringExact(Mp3ConversionOptions.format.nMode.ToString());
            cmbChannelMode.SelectedIndexChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.nMode =
                    (MpegMode)Enum.Parse(typeof(MpegMode), cmbChannelMode.Text);
            };

            // ---- 3 ----
            cmbBitrate.SelectedIndex = cmbBitrate.FindStringExact(Mp3ConversionOptions.format.dwBitrate.ToString());
            cmbBitrate.SelectedIndexChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.dwBitrate = uint.Parse(cmbBitrate.Text);
            };

            // ---- 4 ----
            if (Mp3ConversionOptions.format.dwMaxBitrate == 0)
                Mp3ConversionOptions.format.dwMaxBitrate = Mp3ConversionOptions.format.dwBitrate;

            cmbVbrMax.SelectedIndex = cmbBitrate.FindStringExact(Mp3ConversionOptions.format.dwMaxBitrate.ToString());
            cmbVbrMax.SelectedIndexChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.dwMaxBitrate = uint.Parse(cmbVbrMax.Text);
            };

            // ---- 5 ----
            cmbVbrQuality.SelectedIndex = Mp3ConversionOptions.format.nVBRQuality;
            cmbVbrQuality.SelectedIndexChanged += (s, a) =>
                {
                    Mp3ConversionOptions.format.nVBRQuality = cmbVbrQuality.SelectedIndex;
                };

            // ---- 6 ----
            cmbVbrMode.SelectedIndex = cmbVbrMode.FindStringExact(Mp3ConversionOptions.format.nVbrMethod.ToString());
            cmbVbrMode.SelectedIndexChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.nVbrMethod =
                    (VBRMETHOD)Enum.Parse(typeof(VBRMETHOD), cmbVbrMode.Text);
            };

            // ---- 7 ----
            chkCopyright.Checked = (Mp3ConversionOptions.format.bCopyright != 0);
            chkCopyright.CheckedChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.bCopyright = chkCopyright.Checked ? 1 : 0;
            };

            // ---- 8 ----
            chkPrivate.Checked = (Mp3ConversionOptions.format.bPrivate != 0);
            chkPrivate.CheckedChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.bPrivate = chkPrivate.Checked ? 1 : 0;
            };

            // ---- 9 ----
            chkCRC.Checked = (Mp3ConversionOptions.format.bCRC != 0);
            chkCRC.CheckedChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.bCRC = chkCRC.Checked ? 1 : 0;
            };

            // ---- 10 ----
            chkOriginal.Checked = (Mp3ConversionOptions.format.bOriginal != 0);
            chkOriginal.CheckedChanged += (s, a) =>
            {
                Mp3ConversionOptions.format.bOriginal = chkOriginal.Checked ? 1 : 0;
            };

            // --- 11 ----
            chkGenerateTag.Checked = GenerateTagsFromTrackMetadata;
            chkGenerateTag.CheckedChanged += (s, a) =>
            {
                GenerateTagsFromTrackMetadata = chkGenerateTag.Checked;
            };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Mp3ConversionOptions != null)
            {
                string conversionFlags = Mp3ConversionOptions.ToString();
                LogFileConsoleDetail dlg = new LogFileConsoleDetail(conversionFlags);
                dlg.Text = "MP3 Conversion Flags";
                dlg.ShowDialog();
            }
        }
    }
}
