using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.UI.Configuration;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.Addons.Configuration;

namespace OPMedia.Runtime.Addons
{
    public partial class BaseAddonCtl : OPMBaseControl
    {
        #region Events
        /// <summary>
        /// Delegate used for the NavigationAction event.
        /// </summary>
        public delegate void NavigationActionEventHandler(object sender, NavigationActionEventArgs args);

        /// <summary>
        /// Occurs when a directory is double clicked.
        /// Directory path is part of the event data.
        /// </summary>
        public event NavigationActionEventHandler NavigationAction = null;
        #endregion

        #region Methods
        /// <summary>
        /// Notifies the upper layer about the action.
        /// </summary>
        public void RaiseNavigationAction(NavActionType actionType, List<string> paths)
        {
            RaiseNavigationAction(actionType, paths, null);
        }

        /// <summary>
        /// Notifies the upper layer about the action.
        /// </summary>
        public void RaiseNavigationAction(NavActionType actionType, List<string> paths, object additionalData)
        {
            if (NavigationAction != null)
            {
                NavigationActionEventArgs args = new NavigationActionEventArgs(this.Name, actionType, paths, additionalData);
                NavigationAction(this, args);
            }
        }

        #region Reload methods

        public void ReloadNavigation()
        {
            RaiseNavigationAction(NavActionType.ActionReloadNavigation, null);
        }

        public void ReloadProperties()
        {
            RaiseNavigationAction(NavActionType.ActionReloadProperties, null);
        }

        public void ReloadPreview()
        {
            RaiseNavigationAction(NavActionType.ActionReloadPreview, null);
        }

        public void GlobalReload()
        {
            ReloadNavigation();
            ReloadProperties();
            ReloadPreview();
        }
        #endregion

        #endregion

        public virtual string GetHelpTopic()
        {
            return this.Name;
        }

        public BaseAddonCtl()
        {
            InitializeComponent();
        }

        public virtual void ConfigureAddon()
        {
            Translator.RegisterTranslationAssembly(GetType().Assembly);

            AddonSettingsPanel.InitAddonCfg -= new InitAddonCfgHandler(_GetBaseCfgPanel);
            AddonSettingsPanel.InitAddonCfg += new InitAddonCfgHandler(_GetBaseCfgPanel);
        }

        private BaseCfgPanel _GetBaseCfgPanel()
        {
            return GetBaseCfgPanel();
        }

        protected virtual BaseCfgPanel GetBaseCfgPanel()
        {
            return null;
        }

        public virtual void Reload(object target)
        {
        }
    }

    
}
