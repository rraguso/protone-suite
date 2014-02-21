using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;

namespace OPMedia.Addons.Builtin.ID3Prop.ID3Wizard
{
    public partial class FSTagEditorPanel : EditPanelBase
    {
        public FSTagEditorPanel()
        {
            this.title = "TXT_FSTAGEDITOR";
            InitializeComponent();

            ThemeManager.SetFont(txtHints, FontSizes.Small);
        }

        protected override void DisplayTask()
        {
            _task.TaskType = TaskType.FillID3ByFS;
            
            if (!cmbFilePattern.Items.Contains(_task.TagFilePattern))
            {
                cmbFilePattern.Items.Add(_task.TagFilePattern);
            }
            if (!cmbFolderPattern.Items.Contains(_task.TagFolderPattern))
            {
                cmbFolderPattern.Items.Add(_task.TagFolderPattern);
            }

            cmbFilePattern.SelectedItem = _task.TagFilePattern;
            cmbFolderPattern.SelectedItem = _task.TagFolderPattern;
        }

        private void cmbFilePattern_TextChanged(object sender, EventArgs e)
        {
            _task.TagFilePattern = cmbFilePattern.Text;
        }

        private void cmbFolderPattern_TextChanged(object sender, EventArgs e)
        {
            _task.TagFolderPattern = cmbFolderPattern.Text;
        }
    }
}
