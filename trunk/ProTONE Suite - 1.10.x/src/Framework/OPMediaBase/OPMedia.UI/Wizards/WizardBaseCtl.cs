#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Themes;
using OPMedia.UI.Controls;
using OPMedia.UI.Dialogs;
using System.Threading;
using OPMedia.Runtime;
using OPMedia.Core;

#endregion

#region Creating Wizards Guideline
//
// Steps to define and use a new wizard page:
// 
//  1.  Define a new UserControl class. 
//
//  2.  Make your UserControl class to inherit from WizardBaseCtl i.o. 
//      UserControl.
//
//  3.  Place your controls on the control and fill it with your data.
//
//  4.  If this data must be obtained using a query to Prolog or a PBX
//      command, do not do it on your class constructor nor on the OnLoad
//      event handler. Instead, override the custom action handlers in your
//      class, depending when would you like to do the actions:
//
//      OnWizardInitializing    ->  When the wizard first initializes.
//      OnWizardFinishing       ->  When the user has pressed Finish. However,
//                                  this happens only in the Finish page).
//      OnWizardMovingNext      ->  When the page is loaded after user pressed
//                                  Next in another wizard page.
//      OnWizardMovingBack      ->  When the page is loaded after user pressed
//                                  Back in another wizard page.
//
//  5.  If validation is required before changing the wizard page (e.g. you
//      cannot advance to the next page if some settings are not OK), then 
//      handle the events: WizardNext, WizardBack, WizardFinish, WizardCancel
//      in your class. These events occur when the wizard buttons are presed,
//      before the wizard page is actually changed. Seting the Handled property
//      of the HandledEventArgs argument to true results in preventing the
//      WizardHostForm to process the event, thus the wizard page will not
//      change. Leaving it set to false will allow the WizardHostForm to
//      process the events and hence the wizard page will be changed.
//
//  6.  Add the wizard page type to the proper wizard; use either the 
//      CreateWizard static method or call AddWizard on a WizardHostForm 
//      instance. Your wizard page should be now available...
//
#endregion

namespace OPMedia.UI.Wizards
{
    #region Enums
    /// <summary>
    /// Possible wizard directions that can occur
    /// when the user clicks on next/back/finish buttons.
    /// </summary>
    public enum WizardDirection
    {
        /// <summary>
        /// The wizard was just launched.
        /// </summary>
        Initializing = 0,
        /// <summary>
        /// The user has pressed back.
        /// </summary>
        MovingBack = 1,
        /// <summary>
        /// The user has pressed next.
        /// </summary>
        MovingNext = 2,
        /// <summary>
        /// The user has pressed finish.
        /// </summary>
        Finishing = 3
    }
    #endregion
    
    /// <summary>
    /// The base class for all the wizard pages.
    /// </summary>
    public partial class WizardBaseCtl : OPMBaseControl
    {
        #region Members
        /// <summary>
        /// Type of delegate used to raise WizardXXX events, 
        /// that occur when the associated buttons are clicked 
        /// in the StepButtonsCtl user control.
        public delegate void WizardStepEventHandler(object sender, HandledEventArgs args);
       
        #endregion

        #region Properties

        public virtual Size DesiredSize { get { return Size.Empty; } }

        public bool ShowImage { get; set; }

        public bool ShowSeparator { get; set; }

        /// <summary>
        /// Gets/sets the wizard direction.
        /// </summary>
        public WizardDirection Direction { get; set; }

        /// <summary>
        /// Gets/sets the wizard variable table.
        /// </summary>
        public BackgroundTask BkgTask { get; set; }

		/// <summary>
		/// Gets the wizard this page belongs to.
		/// </summary>
		protected WizardHostForm Wizard
		{
			get
			{
				return FindForm() as WizardHostForm;
			}
		}
        #endregion

        #region Methods
        /// <summary>
        /// Formats a string to be displayed in the config report, based on the:
        /// - untranslated text format;
        /// - format parameters (passed as params array, in a similar way like
        /// for the String.Format method).
        /// </summary>
        /// <param name="rawFormat">The untranslated text format.</param>
        /// <param name="args">The format parameters.</param>
        /// <returns>The string to be displayed in the config report.</returns>
        protected string GetFormattedString(string rawFormat, params object[] args)
        {
            string retVal = string.Empty;
            try
            {
                retVal = Translator.Translate(rawFormat);
                retVal = retVal.Replace('[', '{').Replace(']', '}');
                retVal = string.Format(retVal, args);
            }
            catch
            {
            }

            return retVal;
        }
        #endregion

        #region Construction
        /// <summary>
        /// Default constructor.
        /// </summary>
        public WizardBaseCtl()
        {
            InitializeComponent();
            ShowImage = true;
            ShowSeparator = true;
        }
        #endregion

        #region Implementation

        #region Wizard flow related implementation
     
        /// <summary>
        /// Called by the container form after the wizard page is shown.
        /// </summary>
        public void ExecuteCustomActions()
        {
            // Depending on wizard direction, call the proper
            // custom action handler.
            switch (Direction)
            {
                case WizardDirection.Initializing:
                    OnWizardInitializing();
                    break;
                case WizardDirection.MovingBack:
                    OnWizardMovingBack();
                    break;
                case WizardDirection.MovingNext:
                    OnWizardMovingNext();
                    break;

                case WizardDirection.Finishing:
                    OnWizardFinishing();
                    break;
            }
        }

        GenericWaitDialog _waitDialog = null;

        private delegate void ShowWaitDialogDG(string message);
        protected void ShowWaitDialog(string message)
        {
            //if (InvokeRequired)
            //{
            //    Invoke(new ShowWaitDialogDG(ShowWaitDialog), message);
            //    return;
            //}

            MainThread.Post((d) =>
            {
                this.Enabled = false;
                CloseWaitDialog();
                _waitDialog = new GenericWaitDialog();
                _waitDialog.ShowDialog(message);
            });
        }

        protected void CloseWaitDialog()
        {
            //if (InvokeRequired)
            //{
            //    Invoke(new MethodInvoker(CloseWaitDialog));
            //    return;
            //}

            MainThread.Post((d) =>
            {
                this.Enabled = true;

                if (_waitDialog != null)
                {
                    _waitDialog.Close();
                    _waitDialog = null;
                }
            });
        }

        /// <summary>
        /// Default custom action handler at wizard initialization.
        /// Override it to define your custom behaviour.
        /// </summary>
        protected virtual void OnWizardInitializing()
        {
        }

        /// <summary>
        /// Default custom action handler at wizard finishing.
        /// Override it to define your custom behaviour.
        /// </summary>
        protected virtual void OnWizardFinishing()
        {
        }

        /// <summary>
        /// Default custom action handler at wizard moving next step.
        /// Override it to define your custom behaviour.
        /// </summary>
        protected virtual void OnWizardMovingNext()
        {
        }

        /// <summary>
        /// Default custom action handler at wizard moving one step back.
        /// Override it to define your custom behaviour.
        /// </summary>
        protected virtual void OnWizardMovingBack()
        {
        }
        #endregion

       
        
        #endregion
    }
}
