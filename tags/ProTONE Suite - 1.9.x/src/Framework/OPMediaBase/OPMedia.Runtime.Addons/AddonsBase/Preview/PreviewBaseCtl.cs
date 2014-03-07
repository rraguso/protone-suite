#region Copyright © opmedia research 2006
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	PreviewBaseCtl.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
#endregion

namespace OPMedia.Runtime.Addons.AddonsBase.Preview
{
    /// <summary>
    /// The base class for the preview addons panels.
    /// </summary>
    public class PreviewBaseCtl : BaseAddonCtl
    {
        public PreviewBaseCtl() : base()
        {
        }

        /// <summary>
        /// Which kind of files can this addon handle.
        /// By convention, a null value means that it can handle all file types.
        /// </summary>
        public virtual List<String> HandledFileTypes
        {
            get
            {
                return null;
            }
        }

        string _item;
        object _additionalData;

        public override void Reload(object target)
        {
            GC.Collect();
            DoBeginPreview(_item, _additionalData);
        }

        /// <summary>
        /// Previews the given item.
        /// </summary>
        public void BeginPreview(string item, object additionalData)
        {
            _item = item;
            _additionalData = additionalData;

            DoBeginPreview(item, additionalData);
        }

        /// <summary>
        /// Ends any preview in progress.
        /// </summary>
        public void EndPreview()
        {
            DoEndPreview();
        }

        /// <summary>
        /// Previews the given item.
        /// </summary>
        protected virtual void DoBeginPreview(string item, object additionalData)
        {
        }

        /// <summary>
        /// Ends any preview in progress.
        /// </summary>
        protected virtual void DoEndPreview()
        {
        }

        public virtual bool SupportAutoPreview
        {
            get
            {
                return false;
            }
        }
    }
}
