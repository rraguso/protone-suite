#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
#endregion

namespace OPMedia.UI.Wizards
{
    /// <summary>
    /// User control that encapsulates the functionality
    /// of the back/next/finish/cancel buttons, like it
    /// is encountered in any wizard.
    /// </summary>
    public partial class StepButtonsCtl : OPMBaseControl
    {
        #region Members
        /// <summary>
        /// Type of delegate used to raise StepXXX events, 
        /// that occur when back/nxt/finish/cancel buttons
        /// are clicked.
        /// </summary>
        public delegate void StepButtonEventHandler(object sender, HandledEventArgs args);
        /// <summary>
        /// The method that will be called when raising StepNext events.
        /// </summary>
        public event StepButtonEventHandler StepNext = null;
        /// <summary>
        /// The method that will be called when raising StepBack events.
        /// </summary>
        public event StepButtonEventHandler StepBack = null;
        /// <summary>
        /// The method that will be called when raising StepFinish events.
        /// </summary>
        public event StepButtonEventHandler StepFinish = null;
        /// <summary>
        /// The method that will be called when raising StepCancel events.
        /// </summary>
        public event StepButtonEventHandler StepCancel = null;
        /// <summary>
        /// The method that will be called when raising StepCancel events.
        /// </summary>
        public event StepButtonEventHandler StepOK = null;
        #endregion

        #region Properties
        /// <summary>
        /// Gets/sets if the Finish button is active.
        /// </summary>
        public bool CanFinish
        {
            get
            {
                return btnFinish.Enabled;
            }

            set
            {
                btnFinish.Enabled = value;
            }
        }

        /// <summary>
        /// Gets/sets if the Cancel button is active.
        /// </summary>
        public bool CanCancel
        {
            get
            {
                return btnCancel.Enabled;
            }

            set
            {
                btnCancel.Enabled = value;
            }
        }

        /// <summary>
        /// Gets/sets if the Back button is active.
        /// </summary>
        public bool CanMoveBack
        {
            get
            {
                return btnPrevious.Enabled;
            }

            set
            {
                btnPrevious.Enabled = value;
            }
        }

        /// <summary>
        /// Gets/sets if the Next button is active.
        /// </summary>
        public bool CanMoveNext
        {
            get
            {
                return btnNext.Enabled;
            }

            set
            {
                btnNext.Enabled = value;
            }
        }

        public string OKButtonText
        {
            get
            {
                return btnOK.Text;
            }

            set
            {
                btnOK.Text = value;
            }
        }

        public bool ShowMovementButtons
        {
            get
            {
                return pnlMovementButtons.Visible;
            }

            set
            {
                pnlMovementButtons.Visible = value;
            }
        }

        public bool ShowOKButton
        {
            get
            {
                return btnOK.Visible;
            }

            set
            {
                btnOK.Visible = value;
            }
        }

        public bool ShowRepeatWizard
        {
            get
            {
                return chkRepeatWizard.Visible;
            }

            set
            {
                chkRepeatWizard.Visible = value;
            }
        }

        public bool RepeatWizard
        {
            get
            {
                return chkRepeatWizard.Checked;
            }

            set
            {
                chkRepeatWizard.Checked = value;
            }
        }
        #endregion

        #region Methods
        #endregion

        #region Construction
        /// <summary>
        /// Default constructor.
        /// </summary>
        public StepButtonsCtl()
        {
            InitializeComponent();

            ShowMovementButtons = true;
            ShowOKButton = false;
            ShowRepeatWizard = false;
        }
        #endregion

        #region Event Handlers
        private void OnBtnOK(object sender, EventArgs e)
        {
            if (StepOK != null)
            {
                StepOK(this, new HandledEventArgs(false));
            }
        }

        /// <summary>
        /// Occurs when the Back button is clicked.
        /// Raises the StepBack event to all subscribers.
        /// </summary>
        private void OnBtnBack(object sender, EventArgs e)
        {
            if (StepBack != null)
            {
                StepBack(this, new HandledEventArgs(false));
            }
        }

        /// <summary>
        /// Occurs when the Next button is clicked.
        /// Raises the StepNext event to all subscribers.
        /// </summary>
        private void OnBtnNext(object sender, EventArgs e)
        {
            if (StepNext != null)
            {
                StepNext(this, new HandledEventArgs(false));
            }
        }

        /// <summary>
        /// Occurs when the Finish button is clicked.
        /// Raises the StepFinish event to all subscribers.
        /// </summary>
        private void OnBtnFinish(object sender, EventArgs e)
        {
            if (StepFinish != null)
            {
                StepFinish(this, new HandledEventArgs(false));
            }
        }

        /// <summary>
        /// Occurs when the Cancel button is clicked.
        /// Raises the StepCancel event to all subscribers.
        /// </summary>
        private void OnBtnCancel(object sender, EventArgs e)
        {
            if (StepCancel != null)
            {
                StepCancel(this, new HandledEventArgs(false));
            }
        }
        #endregion

        

        #region Implementation
        #endregion
    }
}
