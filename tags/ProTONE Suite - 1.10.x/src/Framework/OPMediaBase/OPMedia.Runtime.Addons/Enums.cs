using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPMedia.Runtime.Addons
{
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
