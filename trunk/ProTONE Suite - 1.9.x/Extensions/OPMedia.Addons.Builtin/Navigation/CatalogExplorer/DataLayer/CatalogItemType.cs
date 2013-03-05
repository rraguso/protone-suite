using System;
using System.Collections.Generic;
using System.Text;

namespace OPMedia.Addons.Builtin.Navigation.CatalogExplorer.DataLayer
{
    public class CatalogItemType
    {
        #region Members
        private CatalogDataset.CatalogItemTypeRow currentRow = null;
        #endregion

        #region Properties
        public byte TypeID
        { get { return currentRow.TypeID; } } 

        public string TypeCode
        { get { return currentRow.TypeCode; } } 

        public bool IsDisk
        { get { return currentRow.IsDisk; } } 

        public bool IsFolder
        { get { return currentRow.IsFolder; } } 

        public bool IsFile
        { get { return currentRow.IsFile; } }
        #endregion

        #region Methods
        

        public override string ToString()
        {
            return TypeCode;
        }

        public override bool Equals(object obj)
        {
            CatalogItemType comperand = obj as CatalogItemType;
            return (comperand != null && TypeID == comperand.TypeID);
        }

        public override int GetHashCode()
        {
            return TypeID.GetHashCode();
        }
        #endregion

        #region Construction
        public CatalogItemType(CatalogDataset.CatalogItemTypeRow row)
        {
            currentRow = row;
        }
        #endregion
    }
}