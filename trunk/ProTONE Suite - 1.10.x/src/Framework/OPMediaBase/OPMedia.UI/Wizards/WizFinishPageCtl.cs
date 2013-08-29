#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Themes;
using OPMedia.UI.Properties;
using OPMedia.Core;
using OPMedia.Core.Logging;


#endregion

namespace OPMedia.UI.Wizards
{
    public partial class WizFinishPageCtl : WizardBaseCtl
    {
        #region Members
        /// <summary>
        /// Type of delegate used to raise FinishPageExit events, 
        /// that occur when the OK button is clicked on the Finish Page.
        public delegate void FinishPageExitEventHandler(object sender, EventArgs args);
        /// <summary>
        /// The method that will be called when raising FinishPageExit events.
        /// </summary>
        public event FinishPageExitEventHandler FinishPageExit = null;

        private TaskRunner _runner = null;

        private bool _errorsFound = false;

        private ImageList ilStatus = null;

        #endregion

        #region Properties
        #endregion

        #region Construction
        public WizFinishPageCtl() : base()
        {
            InitializeComponent();

            ilStatus = new ImageList();
            ilStatus.ImageSize = new Size(16, 16);
            ilStatus.ColorDepth = ColorDepth.Depth32Bit;
            ilStatus.TransparentColor = Color.White;

            ilStatus.Images.Add(Resources.Error);
            ilStatus.Images.Add(Resources.OK);
            ilStatus.Images.Add(Resources.blank);

            tvResults.ImageList = ilStatus;
        }

		protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape || keyData == Keys.Enter)
            {
                Wizard.DialogResult = DialogResult.OK;
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        void hostForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Wizard == null)
                // not the active page
                return;

            bool mustClose = true;
            if (_runner != null && BkgTask != null)
            {
                if (BkgTask != null)
                {
                    if (BkgTask.IsFinished)
                    {
                        mustClose = !Wizard.RepeatWizard;
                    }
                    else
                    {
                        mustClose = _runner.Cancel();
                    }
                }

                if (mustClose)
                {
                    _runner.Dispose();
                    _runner = null;
                }
                else if (FinishPageExit != null)
                {
                    FinishPageExit(this, e);
                }
            }

            e.Cancel = !mustClose;
        }

        protected override void OnWizardFinishing()
        {
            // OK button does Cancel until processing finished.
            Wizard.OKButtonText = Translator.Translate("TXT_CANCEL");
            Wizard.ShowRepeatWizard = false;
            Wizard.ShowMovementButtons = false;
            Wizard.ShowOKButton = true;

            lblWizardResults.Text = Translator.Translate("TXT_WIZTASKSRUNNING");

            _errorsFound = false;
            tvResults.Visible = _errorsFound;

            // Execute wizard
            if (BkgTask != null)
            {
                BkgTask.Reset();

                // Resubscribe for task events
                BkgTask.TaskProgress -= new TaskProgressHandler(task_TaskProgress);
                BkgTask.TaskFinished -= new TaskFinishedHandler(task_TaskFinished);

                BkgTask.TaskProgress += new TaskProgressHandler(task_TaskProgress);
                BkgTask.TaskFinished += new TaskFinishedHandler(task_TaskFinished);

                tvResults.Nodes.Clear();

                pbProgress.Visible = true;
                pbProgress.Value = 0;

                if (BkgTask.TotalSteps > 1)
                {
                    pbProgress.Maximum = BkgTask.TotalSteps;
                    //pbProgress.Style = ProgressBarStyle.Continuous;
                }
                else
                {
                    pbProgress.Maximum = 1;
                    //pbProgress.Style = ProgressBarStyle.Marquee;
                }

                _runner = new TaskRunner(BkgTask);
                _runner.Run();
            }
        }

        void task_TaskFinished()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(task_TaskFinished));
                return;
            }

            pbProgress.Visible = false;
            tvResults.Visible = _errorsFound;

            if (_errorsFound)
            {
                lblWizardResults.Text = Translator.Translate("TXT_WIZTASKSFINISHED_ERRORS");
            }
            else
            {
                lblWizardResults.Text = Translator.Translate("TXT_WIZTASKSFINISHED");
            }

            Wizard.OKButtonText = Translator.Translate("TXT_OK");
            Wizard.ShowRepeatWizard = true;

            int newHeight = tvResults.Bottom - pbProgress.Top;

            pbProgress.Visible = false;
            tvResults.Location = pbProgress.Location;
            tvResults.Height = newHeight;

            tvResults.ExpandAll();
            tvResults.Invalidate(true);

            // Set the title bar text.
            Wizard.SetTitle(string.Format("{0} {1}",
                Translator.Translate(Wizard.WizardName),
                Translator.Translate("TXT_WIZFINISHED")));
        }

        void task_TaskProgress(StepDetail currentStepDetail, int stepsDone)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new TaskProgressHandler(task_TaskProgress),
                    new object[] { currentStepDetail, stepsDone });
                return;
            }

            try
            {
                Logger.LogInfo("Task is executing step {0} of {1}", stepsDone, BkgTask.TotalSteps);

                if (currentStepDetail != null)
                {
                    if (!currentStepDetail.IsSuccess)
                    {
                        TreeNode tnParent = new TreeNode(currentStepDetail.Description + "     ");
                        tnParent.NodeFont = ThemeManager.LargeFont;

                        tnParent.ImageIndex = 0;
                        tnParent.SelectedImageIndex = 0;

                        TreeNode tnChild = new TreeNode(currentStepDetail.Results);
                        tnChild.NodeFont = ThemeManager.SmallFont;

                        tnChild.ImageIndex = 2;
                        tnChild.SelectedImageIndex = 2;

                        tnParent.Nodes.Add(tnChild);

                        tvResults.Nodes.Add(tnParent);

                        tvResults.ExpandAll();

                        _errorsFound = true;
                    }
                }

                pbProgress.Value = stepsDone;
            }
            catch
            {
            }

            tvResults.Visible = _errorsFound;
        }
        #endregion

        #region Event Handlers


        /// <summary>
        /// Occurs when the user presses the OK button on the 
        /// wizard finish page.
        /// </summary>
        private void OnFinishPageOK(object sender, EventArgs e)
        {
            Wizard.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}