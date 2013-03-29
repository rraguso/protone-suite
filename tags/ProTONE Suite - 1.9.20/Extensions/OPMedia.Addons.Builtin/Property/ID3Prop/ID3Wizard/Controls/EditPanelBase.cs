using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;

namespace OPMedia.Addons.Builtin.ID3Prop.ID3Wizard
{
    public partial class EditPanelBase : OPMBaseControl
    {
        protected Task _task = new Task();
        protected string title = "EditPanelBase";

        public string Title
        {
            get
            {
                return title;
            }
        }

        public EditPanelBase()
        {
            InitializeComponent();
        }

        public void SetTask(Task task)
        {
            if (task == null)
            {
                task = new Task();
            }
            
            _task = task;
            DisplayTask();
        }

        public Task GetTask()
        {
            return _task;
        }

        protected virtual void DisplayTask()
        {
        }
    }
}
