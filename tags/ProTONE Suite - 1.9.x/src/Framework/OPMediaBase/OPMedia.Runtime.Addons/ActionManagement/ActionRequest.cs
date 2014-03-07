#region Copyright © opmedia research 2006
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	ActionRequest.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace OPMedia.Runtime.Addons.ActionManagement
{
    #region Enums
    /// <summary>
    /// Enum that defines which kind of actions can be executed.
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// Display properties in Properties Panel.
        /// </summary>
        ActionBeginEdit = 0,
        /// <summary>
        /// Display preview in Preview Panel.
        /// </summary>
        ActionBeginPreview,
    }
    #endregion

    /// <summary>
    /// Class that wraps all the parameters of a request that is made
    /// by the user layer to the business logic.
    /// </summary>
    public class ActionRequest
    {
        #region Members
        /// <summary>
        /// The action that must be executed.
        /// </summary>
        private ActionType actionType = ActionType.ActionBeginEdit;
        /// <summary>
        /// The list of items on which the action must be executed.
        /// </summary>
        private List<string> items = null;
        #endregion

        #region Properties
        /// <summary>
        /// Gets/sets the action that must be executed.
        /// </summary>
        public ActionType ActionType
        {
            get
            {
                return actionType;
            }

            set
            {
                actionType = value;
            }
        }

        /// <summary>
        /// Gets/sets the items on which the action must be executed.
        /// </summary>
        public List<string> Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
            }
        }
        #endregion

        #region Construction
        /// <summary>
        /// Default comstructor.
        /// </summary>
        public ActionRequest()
        {
        }
        #endregion
    }
}

#region ChangeLog
#region Date: 17.06.2006			Author: octavian
// File created.
#endregion
#endregion