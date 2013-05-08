#region Copyright © opmedia research 2006
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	Addon.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.Win32;
using System.Reflection.Emit;
using System.IO;
using OPMedia.Core.TranslationSupport;
#endregion

namespace OPMedia.Runtime.Addons.AddonsBase
{
    /// <summary>
    /// Base class for all addons.
    /// 
    /// Currently there are three addon types:
    /// - navigation addons (1);
    /// - properties addons (2);
    /// - preview addons (3).
    /// 
    /// Below an explanation of where on the UI will
    /// appear the panels of these addons.
    /// 
    /// -------------------
    /// |   |       |     |
    /// |   |       | (2) | 
    /// |   |       |     |
    /// |   |  (1)  |=====|
    /// |   |       |     |
    /// |   |       | (3) |
    /// |   |       |     |
    /// -------------------
    /// 
    /// </summary>
    public abstract class Addon
    {
        private string assemblyFileName = "";
        private string addonTypeName = "";

        private Assembly addonAssembly = null;

        /// <summary>
        /// Gets the "translated" name of the addon.
        /// </summary>
        public string Name
        {
            get
            {
                return string.Format("TXT_{0}", addonTypeName.Replace(".", "").ToUpperInvariant());
            }
        }

        /// <summary>
        ///  Gets the assembly file.
        /// </summary>
        public string AssemblyFileName
        {
            get
            {
                return assemblyFileName;
            }
        }

        /// <summary>
        ///  Gets the addonTypeName
        /// </summary>
        public string AddonTypeName
        {
            get
            {
                return addonTypeName;
            }
        }

        /// <summary>
        /// Gets the assembly for the addon.
        /// </summary>
        public Assembly AddonAssembly
        {
            get
            {
                return addonAssembly;
            }
        }

        /// <summary>
        /// Standard contructor.
        /// </summary>
        public Addon(string name)
        {
            string[] assemblyInfo = AddonsConfig.GetAssemblyInfo(name).Split(new char[] { '|' });

            if (assemblyInfo.Length == 2)
            {
                this.assemblyFileName = assemblyInfo[0];
                this.addonTypeName = assemblyInfo[1]; 
            }

            this.addonAssembly = Assembly.Load(assemblyFileName);

            LoadAddonType();
        }

        /// <summary>
        /// Method that is called from constructors, to load addon type.
        /// </summary>
        protected abstract void LoadAddonType();
    }
}
