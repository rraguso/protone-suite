using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace OPMedia.Addons.Builtin.TaggedFileProp.TaggingWizard
{
    public partial class TagEditorPanel : EditPanelBase
    {
        public TagEditorPanel()
        {
            this.title = "TXT_TAGEDITOR";
            InitializeComponent();
            pgPatterns.PropertyValueChanged += new PropertyValueChangedEventHandler(pgPatterns_PropertyValueChanged);
        }

        void pgPatterns_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            _task = pgPatterns.SelectedObject as Task;
        }

        protected override void DisplayTask()
        {
            _task.TaskType = TaskType.EditTag;
            pgPatterns.SelectedObject = _task;
        }
    }
}
