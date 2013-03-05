#region Copyright © opmedia research 2006
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	PropBaseCtl.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI;
using OPMedia.Core.GlobalEvents;
using OPMedia.Core.ApplicationSettings;
using System.Reflection;
#endregion

namespace OPMedia.Runtime.Addons.AddonsBase.Prop
{
    /// <summary>
    /// The base class for the properties addons panels.
    /// </summary>
    public class PropBaseCtl : BaseAddonCtl
    {
        private bool _modified = false;

        public PropBaseCtl()
            : base()
        {
        }

        /// <summary>
        /// Maximum numbers of items that can be handled at once.
        /// By convention, a zero or negative value means that the
        /// maximum numbers of items is unlimited.
        /// </summary>
        public virtual int MaximumHandledItems
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// If the plugin can handle folders or not.
        /// </summary>
        public virtual bool CanHandleFolders
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Dirty flag
        /// </summary>
        public bool Modified
        { get { return _modified; } set { _modified = value; } }

        /// <summary>
        /// Which kind of files can this addon handle.
        /// By convention, a null value means that it can handle all file types
        /// (this means the addon is generic). Otherwise, the addon is a specialized
        /// addon.
        /// </summary>
        public virtual List<String> HandledFileTypes
        {
            get
            {
                return new List<string>();
            }
        }

        List<string> _strItems;
        object _additionalData;

        public override void Reload(object target)
        {
            GC.Collect();

            _modified = false;

            EditInternal();
        }

        /// <summary>
        /// Displays properties for the given items.
        /// </summary>
        public void BeginEdit(List<string> strItems, object additionalData)
        {
            _strItems = strItems;
            _additionalData = additionalData;

            EditInternal();
        }

        private void EditInternal()
        {
            if (_strItems != null)
            {
                if (_strItems.Count > AppSettings.FEMaxProcessedFiles)
                {
                    ShowProperties(_strItems.GetRange(0, AppSettings.FEMaxProcessedFiles), _additionalData);
                }
                else
                {
                    ShowProperties(_strItems, _additionalData);
                }
            }
        }

        /// <summary>
        /// Displays properties for the given items.
        /// </summary>
        public void EndEdit()
        {
            if (_modified && ConfirmSave())
            {
                SaveProperties();
            }
        }

        private bool ConfirmSave()
        {
            return MessageDisplay.Query(
                Translator.Translate("TXT_CONFIRM_PROPERTYSAVE"),
                Translator.Translate("TXT_CONFIRMSAVECHANGES"),
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public virtual void ShowProperties(List<string> strItems, object additionalData)
        {
        }

        public virtual void SaveProperties()
        {
        }

        [EventSink(OPMedia.Core.EventNames.PerformTranslation)]
        public void OnPerformTranslation()
        {
            Reload(null);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PropBaseCtl
            // 
            this.Name = "PropBaseCtl";
            this.ResumeLayout(false);

        }
    }
}
