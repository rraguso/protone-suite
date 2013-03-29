#region Copyright © 2006 OPMedia Research
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	AddonLoader.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.Addons.AddonsBase;
#endregion

namespace OPMedia.Runtime.Addons.AddonManagement
{
    public abstract class AddonsLoader
    {
        private Dictionary<string, Addon> addonsTable = null;

        /// <summary>
        /// Retrieves a hash table with all the loaded plugins.
        /// </summary>
        public Dictionary<string, Addon> Addons
        {
            get
            {
                return addonsTable;
            }
        }

        /// <summary>
        /// Default contructor
        /// </summary>
        public AddonsLoader()
        {
            // Create the hash table.
            addonsTable = new Dictionary<string, Addon>();

            // Load the add-ons.
            Load();
        }

        public void Unload()
        {
            UnloadInternal();
        }

        protected abstract void Load();
        protected abstract void UnloadInternal();

        internal abstract Addon SelectAddon(List<string> items);
    }
}

#region ChangeLog
#region Date: 24.06.2006			Author: octavian
// File created.
#endregion
#endregion