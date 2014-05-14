#region Copyright © opmedia research 2006
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	NavBaseCtl.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.Core.TranslationSupport;
using System.Reflection;
#endregion

namespace OPMedia.Runtime.Addons.AddonsBase.Navigation
{
    #region Main class
    /// <summary>
    /// The base class for the navigation addons panels.
    /// All these addons must provide two things: a title
    /// property and a get image method.
    /// </summary>
    public class NavBaseCtl : BaseAddonCtl
    {
        /// <summary>
        /// Gets/sets the addon title.
        /// </summary>
        public string PanelTitle { get; set; }

        /// <summary>
        /// Gets/sets the addon image.
        /// </summary>
        public Image AddonImage { get; set; }

        /// <summary>
        /// Gets/sets the addon image.
        /// </summary>
        public Image SmallAddonImage { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public NavBaseCtl()
            : base()
        {
        }

        /// <summary>
        /// Which kind of files can this addon handle.
        /// By convention, a null value means that it cannot be used to open files.
        /// </summary>
        public virtual List<String> HandledFileTypes
        {
            get
            {
                return null;
            }
        }

        public virtual bool EditDisplayedPathAllowed
        {
            get
            {
                return false;
            }
        }

        public virtual void OnActiveStateChanged(bool isActive)
        {
        }

        public virtual void TryCommitNewPath(string newPath)
        {
        }
    }
    #endregion
}
