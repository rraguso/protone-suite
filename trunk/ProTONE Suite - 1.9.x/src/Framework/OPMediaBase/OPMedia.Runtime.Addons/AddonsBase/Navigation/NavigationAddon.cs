#region Copyright © opmedia research 2006
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	NavAddonsLoader.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
#endregion

namespace OPMedia.Runtime.Addons.AddonsBase.Navigation
{
    /// <summary>
    /// Class that provides all functionality needed to load a registered navigation add-on.
    /// </summary>
    public class NavigationAddon : Addon
    {
        /// <summary>
        /// Each navigation add-on exposes a Panel. This is what the user sees in the UI.
        /// All these Panels should be derived from NavBaseCtl.
        /// </summary>
        private NavBaseCtl addonPanel = null;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public NavigationAddon(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Retrieves the addon panel.
        /// </summary>
        public NavBaseCtl AddonPanel
        {
            get
            {
                return addonPanel;
            }
        }

        /// <summary>
        /// Called from the base class constructor.
        /// Various types of addons can be initialized in various ways
        /// so Initialize must be overidden in all the Addon derived classes.
        /// </summary>
        protected override void LoadAddonType()
        {
            // Determine which of the subtypes must be loaded.
            // By convention, all navigation addons must expose a object
            // that is derived from NavBaseCtl, and this member is the addon panel.
            // This object must be initialized.
            foreach (System.Type type in this.AddonAssembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(NavBaseCtl)) &&
                    type.FullName == this.AddonTypeName)
                {
                    // Call the panel contructor, via .NET Reflection since we don't
                    // now exactly its type...
                    addonPanel = Activator.CreateInstance(type) as NavBaseCtl;

                    addonPanel.ConfigureAddon();

                    // Job done. Addon initialized, so exit.
                    return;
                }
            }

            // If we're here, the specified addon is not a valid navigation addon.
            string exception = 
                string.Format("An error occured while loading the addon: \"{0}\".\n\n" +
                    "The associated assembly: \"{1}\" does not represent a valid navigation addon,\n" +
                    "because it does not contain any subclasses of \"{2}\".\n\n" +
                    "The addon might not be properly registered as an OPMedia Navigation Addon.",
                    this.Name, this.AssemblyFileName, typeof(NavBaseCtl).ToString());

            throw new ApplicationException(exception);
        }
    }
}
