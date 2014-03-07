using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace OPMedia.Addons.Builtin.Navigation.CatalogExplorer.DataLayer
{
    public class CatalogInfo
    {
        #region Members
        private CatalogDataset.CatalogInfoRow currentRow = null;
        #endregion

        public string Version
        { get { return currentRow.Version; } set { currentRow.Version = value; } }

        public string Description
        { get { return currentRow.Description; } set { currentRow.Description = value; } }
        
        public CatalogInfo(Catalog cat)
        {
            currentRow = cat.CatalogInfoTable.Rows[0] as CatalogDataset.CatalogInfoRow;
        }
    }
}
