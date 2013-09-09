using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Text;
using System.Windows.Forms;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Controls;
using OPMedia.UI.Themes;
using OPMedia.UI.Configuration;
using OPMedia.Runtime.Addons.Configuration;


namespace OPMedia.Runtime.Addons.AddonsBase
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

            this.VisibleChanged += new EventHandler(BaseAddonCtl_VisibleChanged);
        }

        void BaseAddonCtl_VisibleChanged(object sender, EventArgs e)
        {
            //if (Visible)
            //{
            //    ThemeManager.SetDoubleBuffer(this);
            //}
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseAddonCtl
            // 
            this.Name = "BaseAddonCtl";
            this.Size = new System.Drawing.Size(150, 146);
            this.ResumeLayout(false);

        }

        public virtual void ConfigureAddon()
        {
            Translator.RegisterTranslationAssembly(GetType().Assembly);

            AddonSettingsPanel.InitAddonCfg -= new InitAddonCfgHandler(_GetSettingsTabPage);
            AddonSettingsPanel.InitAddonCfg += new InitAddonCfgHandler(_GetSettingsTabPage);
        }

        private SettingsTabPage _GetSettingsTabPage()
        {
            return GetSettingsTabPage();
        }

        protected virtual SettingsTabPage GetSettingsTabPage()
        {
            return null;
        }

        public virtual void Reload(object target)
        {
        }
    }

    #region Enumerations
    public enum NavActionType
    {
        ActionDoubleClickDirectory = 0,
        ActionDoubleClickFile,
        ActionSelectDirectory,
        ActionSelectFile,
        ActionSelectMultipleItems,

        ActionPrepareAutoPreview,
        ActionCancelAutoPreview,
        ActionNotifyPreviewableItem,
        ActionNotifyNonPreviewableItem,

        ActionReloadNavigation,
        ActionReloadProperties,
        ActionReloadPreview,
    }
    #endregion

    #region Helper classes
    public class NavigationActionEventArgs : EventArgs
    {
        #region Members
        private string addonName;
        private NavActionType actionType;
        private List<string> paths;
        private object additionalData = null;
        #endregion

        #region Properties
        public string AddonName
        {
            get
            {
                return addonName;
            }
        }

        public NavActionType ActionType
        {
            get
            {
                return actionType;
            }
        }

        public List<string> Paths
        {
            get
            {
                return paths;
            }
        }

        public object AdditionalData
        {
            get
            {
                return additionalData;
            }
        }
        #endregion

        #region Construction
        public NavigationActionEventArgs(string addonName, NavActionType actionType, List<string> paths, object additionalData)
        {
            this.addonName = addonName;
            this.actionType = actionType;
            this.paths = paths;
            this.additionalData = additionalData;
        }

        public NavigationActionEventArgs(string addonName, NavActionType actionType, List<string> paths)
        {
            this.addonName = addonName;
            this.actionType = actionType;
            this.paths = paths;
        }
        #endregion
    }
    #endregion
}
