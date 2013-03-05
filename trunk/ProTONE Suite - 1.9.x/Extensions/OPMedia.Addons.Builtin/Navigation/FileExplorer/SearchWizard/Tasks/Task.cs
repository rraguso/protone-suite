using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.UI.Wizards;
using System.IO;
using OPMedia.UI;

namespace OPMedia.Addons.Builtin.FileExplorer.SearchWizard.Tasks
{
    internal class Task : BackgroundTask
    {
        #region Task properties

        private bool finished = false;
        public string SearchPattern = string.Empty;
        public string SearchText = string.Empty;
        public string SearchPath = string.Empty;

        public bool IsRecursive = true;
        public bool UseAttributes = false;
        public bool IsCaseInsensitive = true; 
        public bool SearchProperties = false;

        public bool Option1 = false;
        public bool Option2 = false;

        public FileAttributes Attributes = FileAttributes.Normal;

        public List<string> MatchingItems = new List<string>();
        public ToolAction Action = ToolAction.ToolActionNothing;

        #endregion

        #region BackgroundTask overrides

        public override int CurrentStep
        {
            get { return 0; }
        }

        public override int TotalSteps
        {
            get { return 0; }
        }

        public override bool IsFinished
        {
            get { return finished; }
        }

        public override StepDetail RunNextStep()
        {
            StepDetail sd = new StepDetail();

            //sd.Description = SearchPath;
            sd.IsSuccess = true;
            sd.Results = "TXT_SUCCESS";

            finished = true;

            return sd;
        }

        public override void Reset()
        {
            finished = false;
            RaiseTaskProgressEvent(null, 0);
        }

        #endregion
    }
}
