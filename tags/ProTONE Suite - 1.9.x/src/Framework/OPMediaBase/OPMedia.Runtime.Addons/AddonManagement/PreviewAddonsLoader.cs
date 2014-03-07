#region Copyright © 2006 OPMedia Research
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	PreviewAddonsLoader.cs
#endregion

#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using OPMedia.Runtime.Addons.AddonsBase;
using OPMedia.Runtime.Addons.AddonsBase.Preview;
using OPMedia.Core;
using OPMedia.Runtime.Addons;
using OPMedia.Core.Logging;
#endregion

namespace OPMedia.Runtime.Addons.AddonManagement
{
    /// <summary>
    /// Object that implements all functionality needed to
    /// load and initialize the preview add-ons.
    /// </summary>
    public class PreviewAddonsLoader : AddonsLoader
    {
        /// <summary>
        /// Loads the preview add-ons
        /// </summary>
        protected override void  Load()
        {
            // Initialize each of preview addons. Careful not to break the loop
            // on eventual exceptions. It's important to try loading as much as
            // possible registered addons.
            if (AddonsConfig.PreviewAddons != null)
            {
                foreach (string addonName in AddonsConfig.PreviewAddons)
                {
                    try
                    {
                        Logger.LogTrace("Loading preview addon: {0} ...", addonName);

                        PreviewAddon navAddon = new PreviewAddon(addonName);
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

        /// <summary>
        /// Selects the proper property addon to handle the given items.
        /// </summary>
        internal override Addon SelectAddon(List<string> items)
        {
            Addon retVal = null;

            try
            {
                List<string> extensions = new List<string>();

                if (items.Count > 1)
                {
                    // Only a single item can be previewed !!
                    retVal = null;
                }
                else
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(items[0]);
                    string extension = di.Extension.Trim(new char[] { '.' }).ToLowerInvariant();

                    if (di.Exists &&
                        (di.Attributes & System.IO.FileAttributes.Directory) == System.IO.FileAttributes.Directory)
                    {
                        // Cannot preview folders !!
                        retVal = null;
                    }
                    else
                    {
                        retVal = InternalSelectAddon(extension);
                    }
                }
            }
            catch
            {
                retVal = null;
            }

            return retVal;
        }

        /// <summary>
        /// Efefctively handles the addon selection.
        /// </summary>
        private Addon InternalSelectAddon(string extension)
        {
            Addon genericAddon = null;
            Addon specializedAddon = null;

            foreach (KeyValuePair<string, Addon> kv in Addons)
            {
                PreviewAddon addon = kv.Value as PreviewAddon;

                if (addon != null)
                {
                    bool canHandleAllRequiredExtensions = true;
                    if (addon.AddonPanel.HandledFileTypes != null)
                    {
                        if (!addon.AddonPanel.HandledFileTypes.Contains(extension))
                        {
                            // Cannot handle the requested extension.
                            canHandleAllRequiredExtensions = false;
                            continue;
                        }
                    }

                    if (!canHandleAllRequiredExtensions)
                    {
                        // It cannot handle all required extensions.
                        continue;
                    }

                    // Seems it fulfills all conditions.

                    // (addons that do not apply to all file types).
                    if (addon.AddonPanel.HandledFileTypes != null)
                    {
                        // It's specialized (it does not apply to all extensions).
                        specializedAddon = addon;
                        break;
                    }
                    else
                    {
                        // It's not specialized, but maybe there can be found a specialized one.
                        genericAddon = addon;
                        continue;
                    }
                }
            }

            // As much as possbile, try to select specialized addons because they will
            // give more details than the generic ones.
            if (specializedAddon != null)
            {
                return specializedAddon;
            }
            else
            {
                return genericAddon;
            }
        }

        protected override void UnloadInternal()
        {
        }
    }
}

#region ChangeLog
#region Date: 24.06.2006			Author: octavian
// File created.
#endregion
#endregion