using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Wizards;
using OPMedia.Runtime.ProTONE.Rendering.Cdda;
using System.IO;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core;
using OPMedia.UI.Controls.Dialogs;
using OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Tasks;
using OPMedia.Runtime.ProTONE.Rendering.Cdda.Freedb;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.UI.Controls;
using TagLib;
using System.Threading;

namespace OPMedia.Addons.Builtin.Navigation.FileExplorer.CdRipperWizard.Forms
{
    public partial class WizCdRipperStep1 : WizardBaseCtl
    {
        ImageList ilSelection = new ImageList();

        OPMTextBox tbEditArtist = new OPMTextBox();
        OPMTextBox tbEditAlbum = new OPMTextBox();
        OPMTextBox tbEditTitle = new OPMTextBox();
        OPMComboBox cmbEditgenre = new OPMComboBox();

        public override Size DesiredSize
        {
            get
            {
                return new Size(660, 400);
            }
        }

        public WizCdRipperStep1()
        {
            InitializeComponent();

            foreach (string gi in Genres.Audio)
            {
                cmbEditgenre.Items.Add(gi);
            }

            ResizeColumns();

            ilSelection.Images.Add(OPMedia.UI.Properties.Resources.Error);
            ilSelection.Images.Add(OPMedia.UI.Properties.Resources.OK);

            lvTracks.SmallImageList = ilSelection;
            lvTracks.Resize += new EventHandler(lvTracks_Resize);

            lvTracks.RegisterEditControl(tbEditArtist);
            lvTracks.RegisterEditControl(tbEditAlbum);
            lvTracks.RegisterEditControl(tbEditTitle);
            lvTracks.RegisterEditControl(cmbEditgenre);
        }

        void lvTracks_Resize(object sender, EventArgs e)
        {
            ResizeColumns();
        }

        private void ResizeColumns()
        {
            colTrackNo.Width = 36;
            colSizeBytes.Width = 65;
            colDuration.Width = 55;

            int w = lvTracks.Width - colTrackNo.Width - colDuration.Width - colSizeBytes.Width -
                SystemInformation.VerticalScrollBarWidth;

            colAlbum.Width = colArtist.Width = colTitle.Width = colGenre.Width = w / 4;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Wizard.CanMoveNext = false;
                PopulateAudioCDDrives();
            }
            finally
            {
            }
        }

        protected override void OnWizardInitializing()
        {
            Wizard.CanMoveNext = false;
            PopulateAudioCDDrives();

            lvTracks.SubItemEdited += new OPMListView.EditableListViewEventHandler(lvTracks_SubItemEdited);
        }

        void lvTracks_SubItemEdited(object sender, ListViewSubItemEventArgs args)
        {
            Track t = args.Item.Tag as Track;
            if (t != null)
            {
                if (args.SubItemIndex == colAlbum.Index)
                {
                    t.Album = args.SubItem.Text;
                }
                else if (args.SubItemIndex == colArtist.Index)
                {
                    t.Artist = args.SubItem.Text;
                }
                else if (args.SubItemIndex == colTitle.Index)
                {
                    t.Title = args.SubItem.Text;
                }
                else if (args.SubItemIndex == colGenre.Index)
                {
                    t.Genre = args.SubItem.Text;
                }
            }
        }

        private void PopulateAudioCDDrives()
        {
            cmbAudioCDDrives.Items.Clear();

            DriveInfoItem selected = null;

            ThreadPool.QueueUserWorkItem((c) =>
                {
                    DriveInfo[] audioCDs = CDDrive.GetAllAudioCDDrives();
                    foreach (DriveInfo di in audioCDs)
                    {
                        DriveInfoItem item = new DriveInfoItem(di);

                        MainThread.Post((d) => { cmbAudioCDDrives.Items.Add(item); });

                        if ((BkgTask as Task).Drive == null)
                        {
                            (BkgTask as Task).Drive = di;
                        }

                        if (Path.Equals(di.RootDirectory.FullName, (BkgTask as Task).Drive.RootDirectory.FullName))
                        {
                            selected = item;
                        }
                    }

                    MainThread.Post((d) => { cmbAudioCDDrives.SelectedItem = selected; });
                });
        }

        private void OnDriveSelected(object sender, EventArgs e)
        {
            Wizard.CanMoveNext = false;

            lvTracks.Items.Clear();

            DriveInfoItem item = cmbAudioCDDrives.SelectedItem as DriveInfoItem;
            if (item != null)
            {
                string rootPath = System.IO.Path.GetPathRoot(item.Path);
                if (!string.IsNullOrEmpty(rootPath))
                {
                    CDEntry cdEntry = null;
                    char letter = rootPath.ToUpperInvariant()[0];
                    using (CDDrive cd = new CDDrive())
                    {
                        if (cd.Open(letter) && cd.Refresh())
                        {
                            switch (AppSettings.AudioCdInfoSource)
                            {
                                case AppSettings.CddaInfoSource.CdText:
                                    cdEntry = CDAFileInfo.BuildCdEntryByCdText(cd, cd.GetCDDBDiskID());
                                    break;

                                case AppSettings.CddaInfoSource.Cddb:
                                    cdEntry = CDAFileInfo.BuildCdEntryByCddb(cd, cd.GetCDDBDiskID());
                                    break;

                                case AppSettings.CddaInfoSource.CdText_Cddb:
                                    {
                                        cdEntry = CDAFileInfo.BuildCdEntryByCdText(cd, cd.GetCDDBDiskID());
                                        CDEntry cde = CDAFileInfo.BuildCdEntryByCddb(cd, cd.GetCDDBDiskID());
                                        cdEntry = CDAFileInfo.Merge(cdEntry, cde);
                                    }
                                    break;

                                case AppSettings.CddaInfoSource.Cddb_CdText:
                                    {
                                        cdEntry = CDAFileInfo.BuildCdEntryByCddb(cd, cd.GetCDDBDiskID());
                                        CDEntry cde = CDAFileInfo.BuildCdEntryByCdText(cd, cd.GetCDDBDiskID());
                                        cdEntry = CDAFileInfo.Merge(cdEntry, cde);
                                    }
                                    break;

                                default:
                                    break;
                            }
                        }

                        for (int i = 1; i <= cdEntry.NumberOfTracks; i++)
                        {
                            double size = cd.TrackSize(i);
                            int duration = cd.GetSeconds(i);

                            ListViewItem lvItem = new ListViewItem(i.ToString());

                            lvItem.SubItems.Add(TimeSpan.FromSeconds(duration).ToString());
                            lvItem.SubItems.Add(((size / (1024 * 1024)).ToString("F")) + " MB");

                            OPMListViewSubItem subItem = new OPMListViewSubItem(tbEditAlbum, lvItem,
                                cdEntry.Tracks[i - 1].Album ?? string.Empty);
                            subItem.ReadOnly = false;
                            lvItem.SubItems.Add(subItem);

                            subItem = new OPMListViewSubItem(tbEditArtist, lvItem,
                                cdEntry.Tracks[i - 1].Artist ?? string.Empty);
                            subItem.ReadOnly = false;
                            lvItem.SubItems.Add(subItem);

                            subItem = new OPMListViewSubItem(tbEditTitle, lvItem,
                                cdEntry.Tracks[i - 1].Title ?? string.Empty);
                            subItem.ReadOnly = false;
                            lvItem.SubItems.Add(subItem);

                            subItem = new OPMListViewSubItem(cmbEditgenre, lvItem,
                                cdEntry.Tracks[i - 1].Genre ?? string.Empty);
                            subItem.ReadOnly = false;
                            lvItem.SubItems.Add(subItem);

                            if (Wizard.RepeatCount == 0)
                            {
                                lvItem.ImageIndex = 1;
                            }
                            else
                            {
                                //lvItem.ImageIndex = ((BkgTask as Task).Tracks.Contains(i)) ? 1 : 0;
                            }

                            lvItem.Tag = cdEntry.Tracks[i - 1];

                            lvTracks.Items.Add(lvItem);
                        }
                    }
                }
            }

            CheckNextButton();
        }

        private void lvTracks_DoubleClick(object sender, EventArgs e)
        {
            if (lvTracks.SelectedItems != null && lvTracks.SelectedItems.Count > 0)
            {
                ListViewItem lvItem = lvTracks.SelectedItems[0];
                lvItem.ImageIndex = (lvItem.ImageIndex == 0) ? 1 : 0;
            }

            CheckNextButton();
        }

        private void CheckNextButton()
        {
            (BkgTask as Task).Tracks.Clear();
            foreach (ListViewItem item in lvTracks.Items)
            {
                if (item.ImageIndex == 1)
                {
                    int idx = -1;
                    if (int.TryParse(item.SubItems[0].Text, out idx))
                    {
                        (BkgTask as Task).Tracks.Add(item.Tag as Track);
                    }
                }
            }

            Wizard.CanMoveNext = ((BkgTask as Task).Tracks.Count > 0);
        }


    }
}
