#region Copyright © opmedia research 2006
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	ActionResponse.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.Addons.AddonsBase;
#endregion

namespace OPMedia.Runtime.Addons.ActionManagement
{
    /// <summary>
    /// Class that wraps all the parameters of a response that is sent
    /// by the business logic to the user layer. Counterpart of the
    /// ActionRequest class.
    /// </summary>
    public class ActionResponse
    {
        #region Members
        /// <summary>
        /// The initial action request.
        /// </summary>
        private ActionRequest initialActionRequest = null;
        /// <summary>
        /// The addon that can handle the initial action request.
        /// </summary>
        private Addon targetAddon = null;
        /// <summary>
        /// True if action failed, false if success.
        /// </summary>
        private bool failed = false;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the initial action request.
        /// </summary>
        public ActionRequest InitialActionRequest
        {
            get
            {
                return initialActionRequest;
            }
        }

        /// <summary>
        /// Gets the addon that can handle the initial action request.
        /// </summary>
        public Addon TargetAddon
        {
            get
            {
                return targetAddon;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Verifies if the given action response represents
        /// a failed action or not.
        /// </summary>
        public static bool IsFailedAction(ActionResponse response)
        {
            return (response == null || response.TargetAddon == null || response.failed);
        }
        #endregion

        #region Construction
        /// <summary>
        /// Default contructor.
        /// </summary>
        internal ActionResponse(ActionRequest initialActionRequest, Addon targetAddon)
        {
            this.initialActionRequest = initialActionRequest;
            this.targetAddon = targetAddon;
        }
        #endregion
    }
}

#region ChangeLog
#region Date: 17.06.2006			Author: octavian
// File created.
#endregion
#endregion