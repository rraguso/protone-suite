﻿using OPMedia.UI.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.Core.TranslationSupport;
using System.IO;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.UI.Controls;
using OPMedia.Core.Logging;

namespace OPMedia.Addons.Builtin.ID3Prop.ID3Wizard.Controls
{
    public partial class PreviewForm : ToolForm
    {
        Task _task = null;

        public PreviewForm(Task task) : base("TXT_PREVIEW_FORM")
        {
            InitializeComponent();

            _task = task;

            this.Load += new EventHandler(PreviewForm_Load);

            this.Resize += new EventHandler(OnResize);
        }

        void OnResize(object sender, EventArgs e)
        {
            int w = lvPreview.Width - SystemInformation.VerticalScrollBarWidth;

            switch (_task.TaskType)
            {
                case TaskType.MultiRename:
                    {
                        lvPreview.Columns[0].Width = w / 2;
                        lvPreview.Columns[1].Width = w / 2;
                    }
                    break;
            
                case TaskType.EditID3:
                case TaskType.FillID3ByFS:
                
                    {
                        w -= 180;

                        lvPreview.Columns["TXT_FILENAME"].Width = w / 6;
                        lvPreview.Columns["TXT_ARTIST"].Width = w / 6;
                        lvPreview.Columns["TXT_ALBUM"].Width = w / 6;
                        lvPreview.Columns["TXT_TITLE"].Width = w / 6;
                        lvPreview.Columns["TXT_COMMENTS"].Width = w / 6;

                        lvPreview.Columns["TXT_GENRE"].Width = 60;
                        lvPreview.Columns["TXT_TRACK"].Width = 60;
                        lvPreview.Columns["TXT_YEAR"].Width = 60;
                    }
                    break;
            }
        }

        void PreviewForm_Load(object sender, EventArgs e)
        {
            lvPreview.Items.Clear();
            lvPreview.Columns.Clear();

            if (_task == null || _task.TotalSteps < 1)
                return;

            label1.Text = Translator.Translate("TXT_PREVIEW_DESC_" + _task.TaskType.ToString().ToUpperInvariant());

            try
            {
                switch (_task.TaskType)
                {
                    case TaskType.EditID3:
                        FillID3Columns();
                        FillID3Fields_1();
                        break;

                    case TaskType.FillID3ByFS:
                        FillID3Columns();
                        FillID3Fields_2();
                        break;

                    case TaskType.MultiRename:
                        FillFileNameColumns();
                        FillNewFileNames();
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            ThemeManager.SetFont(lvPreview, FontSizes.Small);
            OnResize(sender, e);

        }

        private void FillFileNameColumns()
        {
            AddTextColumn("TXT_OLD_FILENAME");
            AddTextColumn("TXT_NEW_FILENAME");
        }

        private void FillID3Columns()
        {
            AddTextColumn("TXT_FILENAME");
            AddTextColumn("TXT_ARTIST");
            AddTextColumn("TXT_ALBUM");
            AddTextColumn("TXT_TITLE");
            AddTextColumn("TXT_COMMENTS");
            AddTextColumn("TXT_GENRE");
            AddTextColumn("TXT_TRACK");
            AddTextColumn("TXT_YEAR");

        }

        private void AddTextColumn(string text)
        {
            lvPreview.Columns.Add(text, Translator.Translate(text));
        }

        private void FillID3Fields_1()
        {
            foreach (string file in _task.Files)
            {
                try
                {
                    ID3FileInfo ifi = new ID3Tagger(file, _task).PreviewUpdateTag(_task.WordCasing);

                    string[] data = new string[] 
                    { 
                        Path.GetFileName(file), 
                        ifi.Artist,
                        ifi.Album,
                        ifi.Title,
                        ifi.Comments,
                        ifi.Genre,
                        ifi.Track.GetValueOrDefault().ToString(),
                        ifi.Year.GetValueOrDefault().ToString()
                    };

                    ListViewItem item = new ListViewItem(data);
                    lvPreview.Items.Add(item);
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            }
        }

        private void FillID3Fields_2()
        {
            foreach (string file in _task.Files)
            {
                try
                {
                    ID3FileInfo ifi = new ID3Tagger(file, _task).PreviewTagFromFileFolderName(_task.WordCasing);

                    string[] data = new string[] 
                    { 
                        Path.GetFileName(file), 
                        ifi.Artist,
                        ifi.Album,
                        ifi.Title,
                        ifi.Comments,
                        ifi.Genre,
                        ifi.Track.GetValueOrDefault().ToString(),
                        ifi.Year.GetValueOrDefault().ToString()
                    };

                    ListViewItem item = new ListViewItem(data);
                    lvPreview.Items.Add(item);
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            }
        }

        private void FillNewFileNames()
        {
            foreach (string oldFile in _task.Files)
            {
                try
                {
                    string newFile = new ID3FileRenamer(oldFile, _task.RemamePattern).GetNewPath(_task.WordCasing);
                    string oldFileName = Path.GetFileName(oldFile);
                    string newFileName = Path.GetFileName(newFile);

                    ListViewItem item = new ListViewItem(new string[] { oldFileName, newFileName });
                    lvPreview.Items.Add(item);
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            }
        }


        

    }
}
