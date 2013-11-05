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
using OPMedia.UI.Dialogs;

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
            chkGenerateID3.Checked = this.Task.GenerateTagsFromTrackMetadata;
            chkGenerateID3.CheckedChanged += (s, a) =>
            {
                this.Task.GenerateTagsFromTrackMetadata = chkGenerateID3.Checked;
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
