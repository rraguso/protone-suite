#region Copyright © 2006 OPMedia Research
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	ActionDispatcher.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.Addons.AddonsBase.Preview;
using OPMedia.Runtime.Addons.AddonsBase.Prop;
#endregion

namespace OPMedia.Runtime.Addons.ActionManagement
{
    public class ActionDispatcher
    {
        private static PreviewAddon previewAddon = null;
        private static PropertyAddon propertyAddon = null;

        #region Methods
        /// <summary>
        /// Selects the proper addon that can handle the action request.
        /// </summary>
        public static ActionResponse DispatchAction(ActionRequest request)
        {
            ActionResponse response = null;

            switch (request.ActionType)
            {
                case ActionType.ActionSaveProperties:
                    if (propertyAddon != null)
                    {
                        PropBaseCtl propCtl = (propertyAddon.AddonPanel as PropBaseCtl);
                        if (propCtl != null)
                        {
                            propCtl.SaveProperties();
                        }
                    }
                    break;

                case ActionType.ActionBeginEdit:
                    {
                        // Stop editing properties if it's the case.
                        if (propertyAddon != null)
                        {
                            PropBaseCtl propCtl = (propertyAddon.AddonPanel as PropBaseCtl);
                            if (propCtl != null)
                            {
                                propCtl.EndEdit();
                                propertyAddon = null;
                            }
                        }

                        propertyAddon = SelectPropertyAddon(request.Items);
                        response = new ActionResponse(request, propertyAddon);
                    }
                    break;

                case ActionType.ActionBeginPreview:
                    {
                        // Stop previewing if it's the case.
                        if (request.ActionType == ActionType.ActionBeginPreview &&
                            previewAddon != null)
                        {
                            PreviewBaseCtl previewCtl = (previewAddon.AddonPanel as PreviewBaseCtl);
                            if (previewCtl != null)
                            {
                                previewCtl.EndPreview();
                                AddonsCore.Instance.FirePreviewEnded();
                                previewAddon = null;
                            }
                        }

                        previewAddon = SelectPreviewAddon(request.Items);
                        response = new ActionResponse(request, previewAddon);
                    }
                    break;

                default:
                    response = null;
                    break;
            }

            return response;
        }

        /// <summary>
        /// Check whether there is an addon that can handle the given action
        /// having the actual addon configuration.
        /// </summary>
        public static bool CanDispatchAction(ActionRequest request, ref bool automatic)
        {
            if (request != null)
            {
                switch (request.ActionType)
                {
                    case ActionType.ActionSaveProperties:
                        return (propertyAddon != null);

                    case ActionType.ActionBeginEdit:
                        return (SelectPropertyAddon(request.Items) != null);

                    case ActionType.ActionBeginPreview:
                        PreviewAddon addon = SelectPreviewAddon(request.Items);

                        if (addon != null)
                        {
                            PreviewBaseCtl previewCtl = addon.AddonPanel as PreviewBaseCtl;
                            if (previewCtl != null)
                            {
                                automatic = previewCtl.SupportAutoPreview;
                                return true;
                            }
                        }
                        
                        return false;
                }
            }

            return false;
        }
        #endregion

        #region Construction
        /// <summary>
        /// Default contructor.
        /// </summary>
        public ActionDispatcher()
        {
        }
        #endregion

        #region Implementation
        /// <summary>
        /// Selects the proper property addon to handle the given items.
        /// </summary>
        private static PropertyAddon SelectPropertyAddon(List<string> items)
        {
            return AddonsCore.Instance.PropAddonsLoader.SelectAddon(items) as PropertyAddon;
        }

        /// <summary>
        /// Selects the proper preview addon to handle the given items.
        /// </summary>
        private static PreviewAddon SelectPreviewAddon(List<string> items)
        {
            return AddonsCore.Instance.PreviewAddonsLoader.SelectAddon(items) as PreviewAddon;
        }
        #endregion
    }
}

#region ChangeLog
#region Date: 24.06.2006			Author: octavian
// File created.
#endregion
#endregion