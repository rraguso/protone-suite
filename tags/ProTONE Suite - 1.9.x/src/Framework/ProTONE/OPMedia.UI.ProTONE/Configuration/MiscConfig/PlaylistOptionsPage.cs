using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Runtime;

using LocalEventNames = OPMedia.UI.ProTONE.GlobalEvents.EventNames;
using OPMedia.Core;
using OPMedia.Core.Utilities;
using OPMedia.UI.Controls;

namespace OPMedia.UI.ProTONE.Configuration.MiscConfig
{
    public partial class PlaylistOptionsPage : SettingsTabPage
    {
        readonly string[] DefaultFormats = new string[]
        {
            "<A> - <T>",
            "<#> <A> - <T>"
        };

        public PlaylistOptionsPage()
        {
            InitializeComponent();

            chkFileNameFormat.Checked = AppSettings.UseFileNameFormat;
            chkUseMetadata.Checked = AppSettings.UseMetadata;
            
            PopulatePlaylistEntryFormats(true);
            PopulateFileNameFormats(true);

            EnableDisableFields();
        }

        private void chkUseMetadata_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableFields();
            Modified = true;
        }

        private void EnableDisableFields()
        {
            //cmbPlaylistEntryFormat.Enabled = chkUseMetadata.Checked;
            cmbFileNameFormat.Enabled = chkFileNameFormat.Checked;

            bool formatting = chkUseMetadata.Checked || chkFileNameFormat.Checked;

            lblDisplayFileName.Visible = !formatting;
            cmbPlaylistEntryFormat.Visible = formatting;
            lblPlaylistFormat.Visible = formatting;
            txtHints.Visible = formatting;
        }

        private void chkFileNameFormat_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableFields();
            Modified = true;
        }

        private void OnClearMetadataHistory(object sender, EventArgs e)
        {
            PopulatePlaylistEntryFormats(false);
            Modified = true;
        }

        private void OnClearFileNameFormat(object sender, EventArgs e)
        {
            PopulateFileNameFormats(false);
            Modified = true;
        }

        private void OnPlaylistEntryFormatChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void OnFileNameFormatChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void PopulateFileNameFormats(bool fillCustomFormats)
        {
            cmbFileNameFormat.Items.Clear();
            cmbFileNameFormat.Items.AddRange(DefaultFormats);

            if (fillCustomFormats)
            {
                string[] customFormats = StringUtils.ToStringArray(AppSettings.CustomFileNameFormats, '?');
                if (customFormats != null)
                {
                    cmbFileNameFormat.Items.AddRange(customFormats);
                }

                cmbFileNameFormat.SelectedIndex =
                    cmbFileNameFormat.FindStringExact(AppSettings.FileNameFormat);
            }
            else
            {
                cmbFileNameFormat.SelectedIndex = 0;
            }
        }

        private void PopulatePlaylistEntryFormats(bool fillCustomFormats)
        {
            cmbPlaylistEntryFormat.Items.Clear();
            cmbPlaylistEntryFormat.Items.AddRange(DefaultFormats);

            if (fillCustomFormats)
            {
                string[] customFormats = StringUtils.ToStringArray(AppSettings.CustomPlaylistEntryFormats, '?');
                if (customFormats != null)
                {
                    cmbPlaylistEntryFormat.Items.AddRange(customFormats);
                }

                cmbPlaylistEntryFormat.SelectedIndex =
                    cmbPlaylistEntryFormat.FindStringExact(AppSettings.PlaylistEntryFormat);
            }
            else
            {
                cmbPlaylistEntryFormat.SelectedIndex = 0;
            }
        }

        private void AddToPlaylistEntryFormatHistory(string format)
        {
            if (!cmbPlaylistEntryFormat.Items.Contains(format))
            {
                cmbPlaylistEntryFormat.Items.Add(format);
            }
        }

        private void AddToFileNameFormatHistory(string format)
        {
            if (!cmbFileNameFormat.Items.Contains(format))
            {
                cmbFileNameFormat.Items.Add(format);
            }
        }

        protected override void SaveInternal()
        {
            AddToPlaylistEntryFormatHistory(cmbPlaylistEntryFormat.Text);
            AddToFileNameFormatHistory(cmbFileNameFormat.Text);

            AppSettings.UseFileNameFormat = chkFileNameFormat.Checked;
            AppSettings.UseMetadata = chkUseMetadata.Checked;

            AppSettings.PlaylistEntryFormat = cmbPlaylistEntryFormat.Text;
            AppSettings.FileNameFormat = cmbFileNameFormat.Text;

            string[] customPlaylistEntryFormats = GetCustomFormats(cmbPlaylistEntryFormat);
            string[] customFileNameFormats = GetCustomFormats(cmbFileNameFormat);

            AppSettings.CustomPlaylistEntryFormats =
                StringUtils.FromStringArray(customPlaylistEntryFormats, '?');
            AppSettings.CustomFileNameFormats =
                StringUtils.FromStringArray(customFileNameFormats, '?');

            EventDispatch.DispatchEvent(LocalEventNames.UpdatePlaylistNames, false);

            AppSettings.Save();
        }

        private string[] GetCustomFormats(OPMEditableComboBox cmb)
        {
            List<String> formats = new List<string>();
            foreach (string item in cmb.Items)
            {
                if (!DefaultFormats.Contains(item))
                {
                    formats.Add(item);
                }
            }

            return formats.ToArray();
        }
    }
}
