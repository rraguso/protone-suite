#region Copyright © opmedia research 2006
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	NavAddonsLoader.cs
#endregion

#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using OPMedia.Runtime.Addons.AddonsBase;
using OPMedia.Runtime.Addons.AddonsBase.Navigation;
using OPMedia.Core;
using OPMedia.Runtime.Addons;
using OPMedia.Core.Logging;
#endregion 

namespace OPMedia.Runtime.Addons.AddonManagement
{
    /// <summary>
    /// Object that implements all functionality needed to
    /// load and initialize the navigation add-ons.
    /// </summary>
    public class NavAddonsLoader : AddonsLoader
    {
        /// <summary>
        /// Loads the navigation add-ons, as defined in the registry.
        /// </summary>
        protected override void Load()
        {
            // Initialize each of navigation addons. Careful not to break the loop
            // on eventual exceptions. It's important to try loading as much as
            // possible registered addons.
            if (AddonsConfig.NavigationAddons != null)
            {
                foreach (string addonName in AddonsConfig.NavigationAddons)
                {
                    try
                    {
                        Logger.LogTrace("Loading navigation addon: {0} ...", addonName);

                        NavigationAddon navAddon = new NavigationAddon(addonName);
                        Addons.Add(addonName, navAddon);
                    }
                    catch (Exception ex)
                    {
                        ErrorDispatcher.DispatchError(string.Format("Could not load addon: {0}.\nError: {1}",
                            addonName, ex.Message), Application.ProductName);
                    }
                }
            }
        }

        internal override Addon SelectAddon(List<string> items)
        {
            return null;
        }

        protected override void UnloadInternal()
        {
        }
    }
}
