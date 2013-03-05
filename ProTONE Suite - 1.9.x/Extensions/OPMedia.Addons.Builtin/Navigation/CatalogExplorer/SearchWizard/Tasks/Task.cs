using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.UI.Wizards;
using System.IO;
using OPMedia.UI;
using OPMedia.Addons.Builtin.Navigation.CatalogExplorer.DataLayer;

namespace OPMedia.Addons.Builtin.CatalogExplorer.SearchWizard.Tasks
{
    internal class Task : BackgroundTask
    {
        #region Task properties

        private bool finished = false;

        public Catalog Catalog { get; set; }
        public string SearchPattern { get; set; }
        public string SearchText { get; set; }
        public string SearchPath { get; set; }

        public bool IsRecursive = true;

        public FileAttributes Attributes = FileAttributes.Normal;

        public List<string> MatchingItems = new List<string>();
        public ToolAction Action = ToolAction.ToolActionNothing;

        #endregion

        public Task()
        {
            Catalog = null;
            SearchPattern = string.Empty;
            SearchText = string.Empty;
            SearchPath = string.Empty;
        }

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
