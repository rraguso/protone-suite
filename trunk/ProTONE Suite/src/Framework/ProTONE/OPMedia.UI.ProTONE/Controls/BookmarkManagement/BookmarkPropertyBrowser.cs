using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using OPMedia.Runtime.ProTONE.ExtendedInfo;
using System.Security.Permissions;
using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.UI.ProTONE.Dialogs;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace OPMedia.UI.ProTONE.Controls.BookmarkManagement
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class BookmarkPropertyBrowser : UITypeEditor
    {
        public BookmarkPropertyBrowser()
            : base()
        {
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            PlaylistItem plItem = value as PlaylistItem;

            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                BookmarkManager bm = new BookmarkManager(plItem, false);
                if (edSvc.ShowDialog(bm) == DialogResult.OK)
                {
                    return bm.PlaylistItem;
                }
            }
            
            return plItem;
        }
    }
}
