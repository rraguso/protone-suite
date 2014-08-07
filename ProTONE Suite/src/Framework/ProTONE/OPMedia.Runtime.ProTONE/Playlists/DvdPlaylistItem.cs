using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.ProTONE.FileInformation;
using System.Windows.Forms;
using OPMedia.Runtime.ProTONE.Rendering;
using System.Globalization;
using OPMedia.Runtime.ProTONE.Rendering.Base;
using OPMedia.Runtime.ProTONE.Rendering.DS;

namespace OPMedia.Runtime.ProTONE.Playlists
{
    // This item appears in main playlist and in Playlist menu item of main menu
    public class DvdPlaylistItem : PlaylistItem
    {
        private VideoDvdInformation vdi
        {
            get
            {
                return base.mi as VideoDvdInformation;
            }
        }

        public override string Path
        { get { return vdi.Path; } }

        public override string DisplayName
        { get { return vdi.ToString(); } }

        public override string Type
        { get { return "DVD"; } }

        protected override Dictionary<string, string> MediaInfoInternal
        {
            get
            {
                return vdi.ExtendedInfo;
            }
        }

        public override TimeSpan Duration
        {
            get
            {
                TimeSpan ts = vdi.Duration.GetValueOrDefault();
                return new TimeSpan(ts.Hours, ts.Minutes, ts.Seconds);
            }
        }

        public override Dictionary<PlaylistSubItem, List<PlaylistSubItem>> GetSubmenu()
        {
            return ConstructDvdSubmenu();
        }

        public override bool MoveToSubitem(PlaylistSubItem subItem)
        {
            return true;
        }

        public DvdPlaylistItem(string discPath) : 
            base(discPath, true, true)
        {
            
        }

        private Dictionary<PlaylistSubItem, List<PlaylistSubItem>> ConstructDvdSubmenu()
        {
            Dictionary<PlaylistSubItem, List<PlaylistSubItem>> submenu = 
                new Dictionary<PlaylistSubItem, List<PlaylistSubItem>>();

            DvdSubItem title = new DvdSubItem("Menu", DvdRenderingStartHint.MainMenu, this);
            submenu.Add(title, null);

            if (vdi.AvailableSubtitles.Count > 0 &&
                MediaRenderer.DefaultInstance.FilterState != OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Stopped &&
                MediaRenderer.DefaultInstance.FilterState != OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.NotOpened)
            {
                title = new DvdSubItem("Subtitles", DvdRenderingStartHint.SubtitleStream, this);
                List<PlaylistSubItem> subtitles = new List<PlaylistSubItem>();

                for (int i = 0; i < vdi.AvailableSubtitles.Count; i++)
                {
                    DvdSubItem subtitle = CreateLanguageSubItem(i, vdi.AvailableSubtitles[i].Language);
                    subtitles.Add(subtitle);
                }
                submenu.Add(title, subtitles);
            }

            for (int i = 0; i < vdi.ChaptersPerTitle.Count; i++)
            {
                List<PlaylistSubItem> chapters = new List<PlaylistSubItem>();
               
                for (int j = 0; j < vdi.ChaptersPerTitle[i]; j++)
                {
                    DvdSubItem chapter = CreateChapterSubItem(i, j);
                    chapters.Add(chapter);
                }

                title = CreateTitleSubItem(i);
                submenu.Add(title, chapters);
            }

            return submenu;
        }

        private DvdSubItem CreateTitleSubItem(int titleIndex)
        {
            int dvdTitleIndex = titleIndex + 1;
            string titleName = "Title " + dvdTitleIndex;

            DvdRenderingStartHint hint = new DvdRenderingStartHint(new DvdPlaybackLocation(dvdTitleIndex, 0, 0));
            return new DvdSubItem(titleName, hint, this);
        }

        private DvdSubItem CreateChapterSubItem(int titleIndex, int chapterIndex)
        {
            int dvdTitleIndex = titleIndex + 1;
            int dvdChapterIndex = chapterIndex + 1;
            string chapterName = "Chapter " + dvdChapterIndex;

            DvdRenderingStartHint hint = new DvdRenderingStartHint(new DvdPlaybackLocation(dvdTitleIndex, dvdChapterIndex, 0));
            return new DvdSubItem(chapterName, hint, this);
        }

        private DvdSubItem CreateLanguageSubItem(int streamIndex, int languageId)
        {
            CultureInfo ci = new CultureInfo(languageId);
            DvdRenderingStartHint hint = new DvdRenderingStartHint(languageId, streamIndex);
            return new DvdSubItem(ci.NativeName, hint, this);
        }
    }

    // This item appears in the drop down menu
    // that IS attached to a DVD playlist item
    public class DvdSubItem : PlaylistSubItem
    {
        public DvdSubItem(string name, PlaylistItem parent)
            : base(name, parent)
        {
            _hint = DvdRenderingStartHint.Beginning;
        }

        public DvdSubItem(string name, DvdRenderingStartHint hint, PlaylistItem parent)
            : base(name, parent)
        {
            _hint = hint;
        }
    }
}
