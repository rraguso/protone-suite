#region Copyright © 2006 OPMedia Research
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	Core.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Core.Logging;
using OPMedia.Runtime.Addons.AddonManagement;
using OPMedia.Runtime.Addons.ActionManagement;
using System.Windows.Forms;
using OPMedia.Runtime.Addons;
using OPMedia.Runtime.Addons.AddonsBase;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core;
using System.IO;
#endregion

namespace OPMedia.Runtime.Addons
{
    public delegate void PreviewEndedEventHandler();

    /// <summary>
    /// Object that holds inside references to the addon loaders
    /// (thus also the addons themselves) and decides on the business
    /// rules (action requests / action responses).
    /// </summary>
    public class AddonsCore
    {
        #region Members
        /// <summary>
        /// The one and only core instance.
        /// </summary>
        private static AddonsCore coreInstance = new AddonsCore();
        /// <summary>
        /// Loader for navigation addons.
        /// </summary>
        private NavAddonsLoader navAddonsLoader = null;
        /// <summary>
        /// Loader for property addons.
        /// </summary>
        private PropAddonsLoader propAddonsLoader = null;
        /// <summary>
        /// Loader for property addons.
        /// </summary>
        private PreviewAddonsLoader previewAddonsLoader = null;

        public event PreviewEndedEventHandler PreviewEnded = null;
        #endregion

        #region Properties
        /// <summary>
        /// Obtains the one and only core instance.
        /// </summary>
        public static AddonsCore Instance
        {
            get
            {
                return coreInstance;
            }
        }

        /// <summary>
        /// Gets the reference to the navigation addons loader.
        /// </summary>
        public NavAddonsLoader NavAddonsLoader
        {
            get
            {
                return navAddonsLoader;
            }
        }

        /// <summary>
        /// Gets the reference to the property addons loader.
        /// </summary>
        public PropAddonsLoader PropAddonsLoader
        {
            get
            {
                return propAddonsLoader;
            }
        }

        /// <summary>
        /// Gets the reference to the preview addons loader.
        /// </summary>
        public PreviewAddonsLoader PreviewAddonsLoader
        {
            get
            {
                return previewAddonsLoader;
            }
        }
        #endregion

        #region Methods

        public void FirePreviewEnded()
        {
            if (PreviewEnded != null)
            {
                PreviewEnded();
            }
        }

        /// <summary>
        /// Forwards an ActionRequest send by an addon to the Action Dispatcher.
        /// This one is the only object able to decide which addon can handle
        /// this request.
        /// </summary>
        public ActionResponse DispatchAction(ActionRequest request)
        {
            ActionResponse retVal = null;

            Logger.LogHeavyTrace("DispatchAction() called ...");

            try
            {
                if (request.Items != null)
                {
                    retVal = ActionManagement.ActionDispatcher.DispatchAction(request);
                }
            }
            catch
            {
                retVal = null;
            }

            Logger.LogHeavyTrace("DispatchAction() done.");
            return retVal;
        }

        public bool CanDispatchAction(ActionRequest request, ref bool automatic)
        {
            Logger.LogHeavyTrace("CanDispatchAction() called ...");

            bool retVal = false;
            try
            {
                if (request.Items != null)
                {
                    retVal = ActionManagement.ActionDispatcher.CanDispatchAction(request, ref automatic);
                }
            }
            catch
            {
                retVal = false;
            }

            Logger.LogHeavyTrace("CanDispatchAction() done .. returning " + retVal);
            return retVal;
        }
        #endregion

        #region Construction
        /// <summary>
        /// Private contructor.
        /// The class is a singleton.
        /// </summary>
        private AddonsCore()
        {
            Translator.RegisterTranslationAssembly(GetType().Assembly);

            Logger.LogTrace("Checking default addons configuration ...");
            CreateDefaultAddonsConfig();

            // Init addons config first
            AddonsConfig.Init();
            InitializeAddons();
        }

        static void CreateDefaultAddonsConfig()
        {
            // Copy default addons config file if it does not exist
            if (File.Exists(ApplicationInfo.AddonsConfigFile))
            {
                Logger.LogTrace("Addons configuration is already saved in user's settings.");
            }
            else
            {
                Logger.LogTrace("Copying default addons configuration from 'DefaultAddons.config' ...");
                try
                {
                    string defaultAddonsConfig = string.Format(@".\DefaultAddons.{0}.config", ApplicationInfo.ApplicationName);
                    File.Copy(defaultAddonsConfig, ApplicationInfo.AddonsConfigFile);
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            }
        }

        #endregion

        #region Implementation
        /// <summary>
        /// Initialize all addons loaders.
        /// </summary>
        public void InitializeAddons()
        {
            bool errors = false;

            Logger.LogTrace("InitializeAddons() called ...");

            navAddonsLoader = null;
            propAddonsLoader = null;
            previewAddonsLoader = null;

            try
            {
                // Initialize navigation addons
                Logger.LogTrace("Loading navigation addons ...");
                navAddonsLoader = new NavAddonsLoader();
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
                navAddonsLoader = null;
                return; // navigations addons are critical; if they fail loading don't continue.
            }

            try
            {
                // Initialize property addons.
                Logger.LogTrace("Loading property addons ...");
                propAddonsLoader = new PropAddonsLoader();
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
                propAddonsLoader = null;
                errors = true;
            }

            try
            {
                // Initialize preview addons.
                Logger.LogTrace("Loading preview addons ...");
                previewAddonsLoader = new PreviewAddonsLoader();
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
                previewAddonsLoader = null;
                errors = true;
            }

            if (errors)
            {
                ErrorDispatcher.DispatchError("Some errors were encountered while loading addons.\n" +
                "You can open Settings -> Addon Config to check which addons are operational.", 
                "Addons loaded with errors.");
            }

            Logger.LogTrace("InitializeAddons() done.");
        }
        #endregion
    }
}

#region ChangeLog
#region Date: 24.06.2006			Author: octavian
// File created.
#endregion
#endregion
