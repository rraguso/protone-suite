using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using OPMedia.Core.TranslationSupport;
using System.Threading;
using System.Drawing.Design;
using OPMedia.Core.Utilities;

namespace OPMedia.Addons.Builtin.Navigation.CatalogExplorer.DataLayer
{
    public enum ChildType
    {
        Root,
        Folder,
        File,

        DontCare,
    }

    public class CatalogItem
    {
        #region Members
        private Catalog _cat = null;
        private CatalogDataset.CatalogItemsRow currentRow = null;
        #endregion

        string _tmpItemTypeDesc = string.Empty;

        public override string ToString()
        {
            return string.Format("ID:{0}, Parent:{1}, Name:{2}", currentRow.ItemID, currentRow.ParentItemID, currentRow.Name);
        }

        public override bool Equals(object obj)
        {
            CatalogItem comperand = obj as CatalogItem;
            return (comperand != null && ItemID == comperand.ItemID);
        }

        public override int GetHashCode()
        {
            return ItemID.GetHashCode();
        }

        #region Properties
        [Browsable(false)]
        public Catalog Catalog
        { 
            get 
            {
                return _cat;
            } 
        }

        [Browsable(false)]
        public long ItemID
        { 
            get 
            {
                if (currentRow.RowState == DataRowState.Detached)
                {
                    return -1;
                }
                
                return currentRow.ItemID; 
            } 
        }

        [Browsable(false)]
        public long ParentItemID
        { get { return currentRow.ParentItemID; } set { currentRow.ParentItemID = value; } }

        [Browsable(false)]
        public bool IsRoot
        { get { return currentRow.IsRoot; } set { currentRow.IsRoot = value; } }

        [Browsable(false)]
        public bool IsFolder
        { get { return _cat.CatalogItemType_GetByTypeID((int)this.ItemType).TypeCode == "FLD" || IsRoot; } }

        [Browsable(false)]
        public byte ItemType
        { get { return currentRow.ItemTypeID; } set { currentRow.ItemTypeID = value; } }

        [Browsable(false)]
        public string ItemIconData
        { get { return currentRow.ItemIconData; } set { currentRow.ItemIconData = value; } }

        [Browsable(false)]
        public string VPath
        { get { return string.Format("{0}.:", ItemID); } }

        [TranslatableDisplayName("TXT_NAME")]
        [TranslatableCategory("TXT_CATALOGITEMINFO")]
        public string Name
        { get { return currentRow.Name; } set { currentRow.Name = value;} }

        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), Localizable(true)]
        [TranslatableDisplayName("TXT_DESC")]
        [TranslatableCategory("TXT_CATALOGITEMINFO")]
        public string Description
        { 
            get { return currentRow.Description; } 
            set { currentRow.Description = value; } 
        }

        [TranslatableDisplayName("TXT_ITEMDATA")]
        [TranslatableCategory("TXT_CATALOGITEMINFO")]
        public string ItemData
        { get { return currentRow.ItemData; } set { currentRow.ItemData = value;} }

        [TranslatableDisplayName("TXT_LASTCHANGEDATE")]
        [TranslatableCategory("TXT_CATALOGITEMINFO_RO")]
        public string DateModified
        { 
            get 
            {
                try
                {
                    return StringUtils.BuildTimeString(currentRow.DateModified.ToLocalTime());
                }
                catch
                {
                    return Translator.Translate("TXT_NA");
                }
            } 
        }

        [TranslatableDisplayName("TXT_CREATIONDATE")]
        [TranslatableCategory("TXT_CATALOGITEMINFO_RO")]
        public string DateCreated
        { 
            get 
            {
                try
                {
                    return StringUtils.BuildTimeString(currentRow.DateCreated.ToLocalTime());
                }
                catch
                {
                    return Translator.Translate("TXT_NA");
                }
            } 
        }
        
        [TranslatableDisplayName("TXT_INTERNALLABEL")]
        [TranslatableCategory("TXT_CATALOGITEMINFO_RO")]
        [ReadOnly(true)]
        public string RootItemLabel
        { get { return currentRow.RootItemLabel; } set { currentRow.RootItemLabel = value; currentRow.AcceptChanges();} }

        [TranslatableDisplayName("TXT_ROOTSERIALNUMBER")]
        [TranslatableCategory("TXT_CATALOGITEMINFO_RO")]
        [ReadOnly(true)]
        public string RootSerialNumber
        { get { return currentRow.RootSerialNumber; } set { currentRow.RootSerialNumber = value; currentRow.AcceptChanges(); } }

        [TranslatableDisplayName("TXT_MEDIAPATH_SHORT")]
        [TranslatableCategory("TXT_CATALOGITEMINFO_RO")]
        [ReadOnly(true)]
        public string OrigItemPath
        { get { return currentRow.OrigItemPath; } set { currentRow.OrigItemPath = value; } }

        [TranslatableDisplayName("TXT_ITEMTYPE_DESC")]
        [TranslatableCategory("TXT_CATALOGITEMINFO_RO")]
        [ReadOnly(true)]
        public string ItemTypeDesc
        { 
            get 
            {
                if (string.IsNullOrEmpty(_tmpItemTypeDesc))
                {
                    _tmpItemTypeDesc = "TXT_DISK_" + _cat.CatalogItemType_GetByTypeID(ItemType).TypeCode;
                }

                return _tmpItemTypeDesc;
            }

            set
            {
                _tmpItemTypeDesc = value;
            }
        }

#if HAVE_COUNTERS_DISPLAY
        int _totalChildrenCount = 0;
        [TranslatableDisplayName("TXT_TOTALCHILDRENCOUNT")]
        [TranslatableCategory("TXT_CATALOGITEMINFO")]
        public int TotalChildrenCount
        {
            get
            {
                RefreshCounters();
                return _totalChildrenCount;
            }
        }

        int _totalFileCount = 0;
        [TranslatableDisplayName("TXT_TOTALFILECOUNT")]
        [TranslatableCategory("TXT_CATALOGITEMINFO")]
        public int TotalFileCount
        {
            get
            {
                RefreshCounters();
                return _totalFileCount;
            }
        }

        int _subfolderCount = 0;
        [TranslatableDisplayName("TXT_TOTALSUBFOLDERCOUNT")]
        [TranslatableCategory("TXT_CATALOGITEMINFO")]
        public int TotalSubfolderCount
        {
            get
            {
                RefreshCounters();
                return _subfolderCount;
            }
        }
#endif

        #endregion

        #region Construction
        public CatalogItem(Catalog cat)
        {
            currentRow = cat.CatalogItems.NewCatalogItemsRow();
            currentRow.DateCreated = DateTime.Now;
            cat.CatalogItems.AddCatalogItemsRow(currentRow);
            _cat = cat;

#if HAVE_COUNTERS_DISPLAY
            _totalChildrenCount = -1;
#endif        
        }

        public CatalogItem(Catalog cat, CatalogDataset.CatalogItemsRow row)
        {
            currentRow = row;
            _cat = cat;

#if HAVE_COUNTERS_DISPLAY
            _totalChildrenCount = -1;
#endif
        }
        #endregion

        public void Save()
        {
            currentRow.AcceptChanges();

#if HAVE_COUNTERS_DISPLAY
            _totalChildrenCount = -1;
#endif
        }

        public void Delete()
        {
            _cat.CatalogItems.RemoveCatalogItemsRow(currentRow);
            _cat.CatalogItems.AcceptChanges();
        }


#if HAVE_COUNTERS_DISPLAY
        private void RefreshCounters()
        {
            bool refresh = (_totalChildrenCount < 0 || _totalFileCount < 0);
            if (refresh)
            {
                _totalChildrenCount = CountChildren(this, true, ChildType.DontCare);
                _totalFileCount = CountChildren(this, true, ChildType.File);
                _subfolderCount = _totalChildrenCount - _totalFileCount;
            }
        }
#endif
    }
}