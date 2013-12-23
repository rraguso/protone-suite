#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using OPMedia.UI.Controls;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Themes;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Core;
using OPMedia.UI.Properties;
using OPMedia.UI.HelpSupport;
using System.Diagnostics;


#endregion

namespace OPMedia.UI.Wizards
{
    /// <summary>
    /// Windows Form that serves as a "host form"
    /// (or container) for all the wizard pages.
    /// </summary>
    public partial class WizardHostForm : ToolForm
    {
        #region Members
        /// <summary>
        /// Stores the current wizard step.
        /// </summary>
        private int wizardStep = -1;
        /// <summary>
        /// Stores a list with the wizard pages.
        /// </summary>
        private List<WizardBaseCtl> wizardPages = null;
        /// <summary>
        /// Stores the wizard name.
        /// </summary>
        private string wizardName = "";
        /// <summary>
        /// Stores if the wizard has to display a finish page.
        /// </summary>
        private bool hasFinishPage = true;
        
        /// <summary>
        /// The wizard task.
        /// </summary>
        private BackgroundTask task = null;

        private WizardDirection wizardDirection =
            WizardDirection.Initializing;

        private WizardBaseCtl wizardPage = null;

        private WizFinishPageCtl _finishPage = new WizFinishPageCtl();

        #endregion

        #region Properties
        public int RepeatCount { get; private set; }

        public bool ShowMovementButtons
        {
            get
            {
                return stepButtons.ShowMovementButtons;
            }

            set
            {
                stepButtons.ShowMovementButtons = value;
            }
        }

        public string OKButtonText
        {
            get
            {
                return stepButtons.OKButtonText;
            }

            set
            {
                stepButtons.OKButtonText = value;
            }
        }

        public bool ShowOKButton
        {
            get
            {
                return stepButtons.ShowOKButton;
            }

            set
            {
                stepButtons.ShowOKButton = value;
            }
        }

        public bool ShowRepeatWizard
        {
            get
            {
                return stepButtons.ShowRepeatWizard;
            }

            set
            {
                stepButtons.ShowRepeatWizard = value;
            }
        }

        /// <summary>
        /// Gets/sets if the Finish button must be activated
        /// in the StepButtonsCtl user control.
        /// </summary>
        public bool CanFinish
        {
            get
            {
                return stepButtons.CanFinish;
            }

            set
            {
                stepButtons.CanFinish = value;
            }
        }

        /// <summary>
        /// Gets/sets if the Cancel button must be activated
        /// in the StepButtonsCtl user control.
        /// </summary>
        public bool CanCancel
        {
            get
            {
                return stepButtons.CanCancel;
            }

            set
            {
                stepButtons.CanCancel = value;
            }
        }

        /// <summary>
        /// Gets/sets if the Back button must be activated
        /// in the StepButtonsCtl user control.
        /// </summary>
        public bool CanMoveBack
        {
            get
            {
                return stepButtons.CanMoveBack;
            }

            set
            {
                stepButtons.CanMoveBack = value;
            }
        }

        /// <summary>
        /// Gets/sets if the Next button must be activated
        /// in the StepButtonsCtl user control.
        /// </summary>
        public bool CanMoveNext
        {
            get
            {
                return stepButtons.CanMoveNext;
            }

            set
            {
                stepButtons.CanMoveNext = value;
            }
        }

        /// <summary>
        /// Gets/sets the wizard image
        /// </summary>
        public Image Image
        {
            get
            {
                return pbWizImage.Image;
            }

            set
            {
                pbWizImage.Image = value;
            }
        }

        /// <summary>
        /// 
        public bool StepButtonsVisible
        {
            get
            {
                return stepButtons.Visible;
            }

            set
            {
                stepButtons.Visible = value;
            }
        }

        /// <summary>
        /// 
        public bool ShowImage
        {
            get
            {
                return pbWizImage.Visible;
            }

            set
            {
                pbWizImage.Visible = value;
                lblSeparator2.Visible = value;
            }
        }

        /// <summary>
        /// 
        public bool ShowSeparator
        {
            get
            {
                return lblSeparator.Visible;
            }

            set
            {
                lblSeparator.Visible = value;
            }
        }


        /// <summary>
        /// Gets/sets if the wizard has to be repeated.
        /// </summary>
        public bool RepeatWizard
        {
            get
            {
                return stepButtons.RepeatWizard;
            }

            set
            {
                stepButtons.RepeatWizard = value;
            }
        }
        /// <summary>
        /// Gets/sets if the wizard has to display a finish page.
        /// </summary>
        public bool HasFinishPage
        {
            get
            {
                return hasFinishPage;
            }

            set
            {
                hasFinishPage = value;
            }
        }

        /// <summary>
        /// Gets/sets the wizard name. This name will be displayed
        /// in the title bar together with the current wizard step.
        /// </summary>
        public string WizardName
        {
            get
            {
                return wizardName;
            }

            set
            {
                wizardName = value;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Overloaded. Initializes and displays the wizard container form.
        /// In order to define the wizard pages, there must be created an array
        /// of "wizard pages types". This array must be passed to the function.
        /// </summary>
        /// <param name="wizardName">The name of the wizard, 
        /// that will be displayed in the title bar.
        /// </param>
        /// <param name="wizardPages">The array of "wizard pages types" that 
        /// must be passed to the function.
        /// </param>
        /// <param name="hasFinishPage">A flag indicating if the wizard should
        /// display a finish page.</param>
        /// <param name="initVariableTable">A variable list that has to be passed
        /// to the wizard before initialization.
        /// </param>
        /// <returns>The wizard dialog result (OK, Cancel etc).</returns>
        public static DialogResult CreateWizard(string wizardName, 
            Type[] wizardPages,
            bool hasFinishPage,
            BackgroundTask initTask, 
            Icon customIcon = null)
        {
            // Test there have been defined any wizard pages.
            // If not, then do not show the wizard.
            if (wizardPages.Length <= 0)
                return DialogResult.Abort;

            // Initialize the wizard container form
            WizardHostForm wizardHostForm = new WizardHostForm();

            // Define the wizard pages/steps
            foreach (Type wizardPage in wizardPages)
            {
                wizardHostForm.AddWizardPage(wizardPage);
            }

            // Set the wizard name
            wizardHostForm.WizardName = wizardName;
            wizardHostForm.HasFinishPage = hasFinishPage;
            wizardHostForm.KeyPreview = false;

            // Display the wizard container form
            wizardHostForm.task = initTask;


            if (customIcon != null)
            {
                wizardHostForm.InheritAppIcon = false;
                wizardHostForm.Icon = customIcon;
            }

            try
            {
                return wizardHostForm.ShowDialog();
            }
            catch { }

            return DialogResult.Cancel;
        }

        /// <summary>
        /// Add a "wizard page type" into the list of pages.
        /// The order that is used when adding pages will be
        /// used by the class when navigating with next/back
        /// buttons through the wizard.
        /// </summary>
        /// <param name="type">The type of the user control to 
		/// use as wizard page.</param>
        public void AddWizardPage(Type type)
        {
            // Create the wizard page.
            WizardBaseCtl wizardPage = Activator.CreateInstance(type) as WizardBaseCtl;

            if (wizardPage != null)
            {
                // Translate and add the created wizard page
                // to the wizard pages list.
                wizardPages.Add(wizardPage);
            }
        }
        #endregion

        #region Construction
        /// <summary>
        /// Default constructor.
        /// </summary>
        public WizardHostForm()
        {
            InitializeComponent();

            RepeatCount = 0;

            stepButtons.StepBack += new StepButtonsCtl.StepButtonEventHandler(OnWizardBack);
            stepButtons.StepNext += new StepButtonsCtl.StepButtonEventHandler(OnWizardNext);
            stepButtons.StepFinish += new StepButtonsCtl.StepButtonEventHandler(OnWizardFinish);
            stepButtons.StepCancel += new StepButtonsCtl.StepButtonEventHandler(OnWizardCancel);
            stepButtons.StepOK += new StepButtonsCtl.StepButtonEventHandler(OnFinishPageExit);

            wizardPages = new List<WizardBaseCtl>();

            lblSeparator.BackColor = lblSeparator2.BackColor = ThemeManager.BorderColor;
        }

        #endregion

        #region Event Handlers
        /// <summary>
        /// Occurs when the users clicks on Next.
        /// So display the next page in the wizard.
        /// </summary>
        private void OnWizardNext(object sender, HandledEventArgs e)
        {
            if (e != null && e.Handled == false)
            {
                wizardStep++;
                wizardDirection = WizardDirection.MovingNext;
                DisplayActiveWizardPage();
            }
        }

        /// <summary>
        /// Occurs when the users clicks on Back.
        /// So display the previous page in the wizard.
        /// </summary>
        private void OnWizardBack(object sender, HandledEventArgs e)
        {
            if (e != null && e.Handled == false)
            {
                wizardStep--;
                wizardDirection = WizardDirection.MovingBack;
                DisplayActiveWizardPage();
            }
        }

        /// <summary>
        /// Occurs when the users clicks on Finish.
        /// </summary>
        private void OnWizardFinish(object sender, HandledEventArgs e)
        {
            if (e != null && e.Handled == false)
            {
                wizardDirection = WizardDirection.Finishing;

                if (hasFinishPage)
                {
                    // If the wizard has a finish page,
                    // then display it.
                    DisplayFinishPage();
                }
                else
                {
                    // If the wizard does not have a finish page,
                    // then close the wizard form with DialogResult=OK.
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        /// <summary>
        /// Occurs when the users clicks on Cancel.
        /// So close the wizard form with DialogResult=Cancel.
        /// </summary>
        private void OnWizardCancel(object sender, HandledEventArgs e)
        {
            if (e != null && e.Handled == false)
            {
                wizardDirection = WizardDirection.Initializing;
                this.DialogResult = DialogResult.Cancel;
            }
        }

        /// <summary>
        /// Occurs when the users clicks on OK in the finish page.
        /// </summary>
        private void OnFinishPageExit(object sender, EventArgs e)
        {
            // Check if the wizard must be repeated.
            if (RepeatWizard)
            {
                RepeatCount++;

                // If must be repeated, jump back to first step.
                OnShown(null, null);
            }
            else
            {
                // If must not be repeated, exit wizard.
                this.DialogResult = DialogResult.OK;
                
            }
        }

        /// <summary>
        /// Occurs when the wizard form is first loaded.
        /// So display the first wizard page.
        /// </summary>
        private void OnShown(object sender, EventArgs e)
        {
            ShowMovementButtons = true;
            ShowRepeatWizard = false;
            ShowOKButton = false;

            wizardStep = 0;
            wizardDirection = WizardDirection.Initializing;
            RepeatWizard = false;
            DisplayActiveWizardPage();


        }
        #endregion

        #region Implementation

        /// <summary>
        /// Display the wizard page that corresponds to the current
        /// wizard step.
        /// </summary>
        private void DisplayActiveWizardPage()
        {
            // Check if the specified wizardStep is in range.
            if (wizardStep < 0 || wizardStep >= wizardPages.Count)
                return;

            this.SuspendLayout();

            // Check if there was a previous wizard page.
            if (wizardPage != null)
            {
                task = wizardPage.BkgTask;
            }

            wizardPage = wizardPages[wizardStep] as WizardBaseCtl;

            if (this.wizardPage != null)
            {
                // On first wizard page, disable "Back" button
                stepButtons.CanMoveBack = (wizardStep > 0);
                // On last wizard page, disable "Next" button
                stepButtons.CanMoveNext = (wizardStep < wizardPages.Count - 1);
                // On last wizard page, enable "Finish" button
                stepButtons.CanFinish = (wizardStep >= wizardPages.Count - 1);

                // Set the title bar text (e.g. "Wizard X Step 2 of 4").
                // If the wizard has only one step show .
                if (wizardPages.Count > 1)
                {
                   SetTitle(string.Format("{0} - {1} {2} {3} {4}",
                        Translator.Translate(wizardName),
                        Translator.Translate("TXT_WIZARDSTEPTEXT"),
                        wizardStep + 1,
                        Translator.Translate("TXT_WIZARDSTEPDELIMITER"),
                        wizardPages.Count));
                }
                else
                {
                   SetTitle(Translator.Translate(wizardName));
                }

                AddPageToForm(wizardPage);

                wizardPage.BkgTask = task;
                
                // Set the wizard direction
                wizardPage.Direction = wizardDirection;
                wizardPage.Focus();

                this.ShowImage = wizardPage.ShowImage;
                this.ShowSeparator = wizardPage.ShowSeparator;
            }

            this.ResumeLayout();

            if (this.wizardPage != null)
            {
                // Execute the custom actions for the wizard page.
                // This is necessary because different actions might
                // be needed when moving next or back.
                wizardPage.ExecuteCustomActions();
            }
        }

        private void AddPageToForm(WizardBaseCtl wizardPage)
        {
            this.SuspendLayout();
            pnlWizardLayout.SuspendLayout();
            pnlWizardStep.SuspendLayout();

            wizardPage.Dock = DockStyle.Fill;
            wizardPage.Visible = true;

            Translator.TranslateControl(wizardPage, DesignMode);

            pnlContent.Margin = new Padding(0);
            pnlContent.Padding = new Padding(0);
            
            wizardPage.Margin = new Padding(0);
            wizardPage.Padding = new Padding(0);

            pnlWizardStep.Dock = DockStyle.Fill;

            pnlWizardStep.Controls.Clear();
            pnlWizardStep.Controls.Add(wizardPage);

            if (wizardPage.DesiredSize.IsEmpty)
            {
                // Standard size
                this.Width = 535;
                this.Height = 400;
            }
            else
            {
                // Custom size
                this.Width = wizardPage.DesiredSize.Width;
                this.Height = wizardPage.DesiredSize.Height;
            }

            ThemeManager.SetDoubleBuffer(wizardPage);

            pnlWizardStep.ResumeLayout();
            pnlWizardLayout.ResumeLayout();
            this.ResumeLayout();
        }

        /// <summary>
        /// Display the wizard finish page.
        /// </summary>
        private void DisplayFinishPage()
        {
            this.SuspendLayout();

            // Check if there was a previous wizard page.
            if (wizardPage != null)
            {
                task = wizardPage.BkgTask;

                // Remove the previous wizard page.
                pnlContent.Controls.Remove(wizardPage);
            }

            wizardPage = _finishPage;

            // Subscribe for wizard events.
            (wizardPage as WizFinishPageCtl).FinishPageExit += 
                new WizFinishPageCtl.FinishPageExitEventHandler(OnFinishPageExit);
            
            // Set the title bar text.
            SetTitle(string.Format("{0} {1}",
                Translator.Translate(wizardName),
                Translator.Translate("TXT_WIZFINISHING")));

            AddPageToForm(wizardPage);

            // Set the table of variables.
            // If this is the first wizard step then the table should be empty.
            wizardPage.BkgTask = task;

            // Set the wizard direction
            wizardPage.Direction = wizardDirection;
            
            wizardPage.ExecuteCustomActions();
            wizardPage.Focus();

            this.ResumeLayout();
        }
        #endregion

        /// <summary>
        /// Occurs whenever a key is pressed in any of the child controls.
        /// </summary>
        /// <param name="keyData">The key that was pressed.</param>
        /// <returns>True if the parent control can handle the key itself,
        /// false otherwise.</returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            // Allow to cancel the wizard using Escape key.
            if (keyData == Keys.Escape)
            {
                HandledEventArgs e = new HandledEventArgs();
                e.Handled = false;
                OnWizardCancel(this, e);
                return true;
            }

            if (keyData == Keys.F1)
            {
                string wizName = wizardName.Replace("TXT_", "").ToLowerInvariant();
                HelpTarget.HelpRequest(wizName, wizardPage.Name);
            }

            return base.ProcessDialogKey(keyData);
        }
    }
}
