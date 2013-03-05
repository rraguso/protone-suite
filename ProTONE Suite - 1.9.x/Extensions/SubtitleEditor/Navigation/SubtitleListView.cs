using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.UI.Controls;
using System.Windows.Forms;
using OPMedia.Core.TranslationSupport;
using SubtitleEditor.extension.DataLayer;

namespace SubtitleEditor.extension.Navigation
{
    public class SubtitleListView : OPMListView
    {
        ColumnHeader hdrIndex = new ColumnHeader();
        ColumnHeader hdrStartTime = new ColumnHeader();
        ColumnHeader hdrStartFrame = new ColumnHeader();
        ColumnHeader hdrEndTime = new ColumnHeader();
        ColumnHeader hdrEndFrame = new ColumnHeader();
        ColumnHeader hdrContent = new ColumnHeader();

        private SubtitleBase _subtitle = null;
        public SubtitleBase Subtitle
        {
            get { return _subtitle; }
            set { _subtitle = value; DisplaySubtitle(); }
        }

        public SubtitleListView()
            : base(System.Windows.Forms.ColumnHeaderStyle.Nonclickable)
        {
            this.Columns.AddRange(new ColumnHeader[] 
            { 
                 hdrIndex, 
                 hdrStartTime,
                 hdrStartFrame,
                 hdrEndTime,
                 hdrEndFrame,
                 hdrContent
            });

            TranslateColumns();
            this.Resize += new EventHandler(SubtitleListView_Resize);
        }

        void SubtitleListView_Resize(object sender, EventArgs e)
        {
            SizeColumns();
        }

        private void SizeColumns()
        {
            hdrIndex.Width = 50;
            hdrStartTime.Width = 70;
            hdrStartFrame.Width = 50;
            hdrEndTime.Width = 70;
            hdrEndFrame.Width = 50;
            hdrContent.Width = this.Width - 5 - SystemInformation.VerticalScrollBarWidth;
        }

        private void TranslateColumns()
        {
            hdrIndex.Text = Translator.Translate("TXT_INDEX");
            hdrStartTime.Text = Translator.Translate("TXT_START_TIME");
            hdrStartFrame.Text = Translator.Translate("TXT_START_FRAME");
            hdrEndTime.Text = Translator.Translate("TXT_END_TIME");
            hdrEndFrame.Text = Translator.Translate("TXT_END_FRAME");
            hdrContent.Text = Translator.Translate("TXT_CONTENT");
        }

        private void DisplaySubtitle()
        {
            this.Items.Clear();

            if (_subtitle != null)
            {
                List<SubtitleElement> elements = _subtitle.Elements;

                if (elements != null && elements.Count > 0)
                {
                    int index = 0;

                    foreach (SubtitleElement se in elements)
                    {
                        index++;

                        ListViewItem item = new ListViewItem(index.ToString());
                        item.Tag = se;

                        OPMListViewSubItem si = new OPMListViewSubItem(item, se.StartTime.ToString(SubtitleBase.TimeDisplayFormat));
                        //si.ReadOnly = false;
                        item.SubItems.Add(si);

                        si = new OPMListViewSubItem(item, se.StartFrames.ToString());
                        //si.ReadOnly = false;
                        item.SubItems.Add(si);

                        si = new OPMListViewSubItem(item, se.EndTime.ToString(SubtitleBase.TimeDisplayFormat));
                        //si.ReadOnly = false;
                        item.SubItems.Add(si);

                        si = new OPMListViewSubItem(item, se.EndFrames.ToString());
                        //si.ReadOnly = false;
                        item.SubItems.Add(si);

                        si = new OPMListViewSubItem(item, se.OneLineContents);
                        //si.ReadOnly = false;
                        item.SubItems.Add(si);

                        this.Items.Add(item);
                    }
                }
            }
        }
    }
}
