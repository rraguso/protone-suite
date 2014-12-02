using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
//using ICSharpCode.SharpZipLib.BZip2;
using System.Reflection;
using OPMedia.Core;
using System.ComponentModel;
using OPMedia.Runtime.FileInformation;
using OPMedia.Core.TranslationSupport;
using System.Windows.Forms;
using System.Linq;

namespace OPMedia.Addons.Builtin.Navigation.CatalogExplorer.DataLayer
{
    // Use this class from CatalogItemPropMC
    public class Catalog : NativeFileInfo
    {
        public const string CatalogVPath = "-1.:";

        private CatalogInfo _info = null;

        #region Members
        static string TemplateFileName = string.Format("{0}Templates{0}Catalog{0}Default Catalog", PathUtils.DirectorySeparator);

        private CatalogDataset _dataset;

        private bool _isDefaultLocation = true;

        string version = null;
        #endregion

        [Browsable(false)]
        public bool IsInDefaultLocation
        {
            get
            {
                return _isDefaultLocation;
            }
        }

        [Browsable(false)]
        public static string DefaultLocation
        {
            get
            {
                string assemblyLocation = Assembly.GetExecutingAssembly().Location;
                string assemblyFolder = new System.IO.FileInfo(assemblyLocation).Directory.FullName;
                return string.Format("{0}{1}", assemblyFolder, TemplateFileName);
            }
        }

        #region Catalog tables
        [Browsable(false)]
        public CatalogDataset.CatalogItemsDataTable CatalogItems
        { get { return _dataset.CatalogItems; } }

        [Browsable(false)]
        public CatalogDataset.CatalogItemTypeDataTable CatalogItemTypes
        { get { return _dataset.CatalogItemType; } }

        [Browsable(false)]
        public CatalogDataset.CatalogInfoDataTable CatalogInfoTable
        { get { return _dataset.CatalogInfo; } }

        [TranslatableDisplayName("TXT_CATALOGSCHEMAVERSION")]
        [TranslatableCategory("TXT_CATALOGINFO")]
        [ReadOnly(true)]
        public string CatalogSchemaVersion
        { 
            get 
            {
                if (version == null)
                {
                    version = _info.Version;
                }
                
                return version;
            }

            set
            {
                version = value;
            }
        }

        [TranslatableDisplayName("TXT_CATALOG_DESC")]
        [TranslatableCategory("TXT_CATALOGINFO")]
        [ReadOnly(false)]
        public string CatalogDescription
        { get { return Translator.TranslateTaggedString(_info.Description); } set { _info.Description = value; } }

#if HAVE_COUNTERS_DISPLAY

        [TranslatableDisplayName("TXT_TOTALCHILDRENCOUNT")]
        [TranslatableCategory("TXT_CATALOGINFO")]
        public int TotalChildrenCount
        {
            get
            {
                int count = 0;
                CatalogItem[] roots = CatalogItem.GetRoots(this);
                if (roots != null)
                {
                    foreach (CatalogItem root in roots)
                    {
                        count += CatalogItem.CountChildren(root, true, ChildType.DontCare);
                        count++;
                    }
                }

                return count;
            }
        }

        [TranslatableDisplayName("TXT_TOTALFILECOUNT")]
        [TranslatableCategory("TXT_CATALOGINFO")]
        public int TotalFileCount
        {
            get
            {
                int count = 0;
                CatalogItem[] roots = CatalogItem.GetRoots(this);
                if (roots != null)
                {
                    foreach (CatalogItem root in roots)
                    {
                        count += CatalogItem.CountChildren(root, true, ChildType.File);
                    }
                }

                return count;
            }
        }

        [TranslatableDisplayName("TXT_TOTALSUBFOLDERCOUNT")]
        [TranslatableCategory("TXT_CATALOGINFO")]
        public int TotalSubfolderCount
        {
            get
            {
                int count = 0;
                CatalogItem[] roots = CatalogItem.GetRoots(this);
                if (roots != null)
                {
                    foreach (CatalogItem root in roots)
                    {
                        count += CatalogItem.CountChildren(root, true, ChildType.Folder);
                    }
                }

                return count;
            }
        }

        [TranslatableDisplayName("TXT_TOTALROOTSCOUNT")]
        [TranslatableCategory("TXT_CATALOGINFO")]
        public int TotalRootsCount
        {
            get
            {
                int count = 0;
                CatalogItem[] roots = CatalogItem.GetRoots(this);
                if (roots != null)
                {
                    count = roots.Length;
                }

                return count;
            }
        }
#endif

        #endregion

        #region Merge catalogs
        public void MergeCatalog(string origCatalogPath)
        {
            Catalog origCatalog = new Catalog(origCatalogPath);
            if (!origCatalog.IsValid)
            {
                throw new CatalogException("TXT_ERROR_INVALID_CATALOG", origCatalogPath);
            }
                
            if (origCatalog.Path.ToLowerInvariant() == this.Path.ToLowerInvariant())
            {
                throw new CatalogException("TXT_ERROR_MERGE_SAME_CATALOG", origCatalogPath);
            }

            try
            {
                CatalogItem[] roots = origCatalog.GetRoots();
                if (roots != null)
                {
                    foreach (CatalogItem root in roots)
                    {
                        MergeCatalogItem(origCatalog, root, null);
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new CatalogException("TXT_ERR_MERGE_FAILED", ex.Message);
            }
        }

        private void MergeCatalogItem(Catalog origCatalog, CatalogItem origItem, CatalogItem parentItem)
        {
 	        // We create a new CatalogItem, because the existing one
            // belongs to other catalog, and all its relations are based
            // on that catalog. We need, though, an item related to this catalog.
            CatalogItem newItem = new CatalogItem(this);

            // After creation we migrate all properties.
            newItem.OrigItemPath = origItem.OrigItemPath;
            newItem.IsRoot = origItem.IsRoot;
            newItem.RootItemLabel = origItem.RootItemLabel;
            newItem.RootSerialNumber = origItem.RootSerialNumber;
            newItem.Name = origItem.Name;
            newItem.ItemType = origItem.ItemType;
            newItem.Description = origItem.Description;

            if (parentItem != null)
            {
                newItem.ParentItemID = parentItem.ItemID;
            }

            // Explore children if any
            if (origItem.IsFolder)
            {
                CatalogItem[] children = origCatalog.GetByParentItemID(origItem.ItemID);
                if (children != null)
                {
                    foreach (CatalogItem child in children)
                    {
                        MergeCatalogItem(origCatalog, child, newItem);
                        Application.DoEvents();
                    }
                }
            }

            // Save changes.
            newItem.Save();
        }

        #endregion

        #region Loading
        private void LoadTemplateCatalog(string catalogPath)
        {
            _isDefaultLocation = false;
            _dataset = new CatalogDataset();
            _dataset.ReadXml(catalogPath);
        }

        private void LoadCompressedCatalog(string catalogPath)
        {
            _isDefaultLocation = false;

            FileStream inputStream = null;
            GZipStream zipStream = null;

            try
            {
                inputStream = new FileStream(catalogPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                zipStream = new GZipStream(inputStream, CompressionMode.Decompress);

                _dataset = new CatalogDataset();
                _dataset.ReadXml(zipStream);

                MigrateDataToLatestVersion();
            }
            finally
            {
                if (zipStream != null) zipStream.Close();
                if (inputStream != null) inputStream.Close();
            }
        }
        #endregion

        #region Saving

        public void Save(string path)
        {
            FileStream outputStream = null;
            GZipStream zipStream = null;

            try
            {
                MigrateDataToLatestVersion();

                outputStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                zipStream = new GZipStream(outputStream, CompressionMode.Compress);

                _dataset.WriteXml(zipStream);
            }
            finally
            {
                if (zipStream != null) zipStream.Close();
                if (outputStream != null) outputStream.Close();
            }

            LoadFromPath(path, false);
            _info = new CatalogInfo(this);

            _isDefaultLocation = false;
        }

        private void ConsistencyCheck()
        {
            List<CatalogDataset.CatalogItemsRow> orphanedRows = new List<CatalogDataset.CatalogItemsRow>();
            foreach(CatalogDataset.CatalogItemsRow row in this.CatalogItems.Rows)
            {
                if (CheckRowAncestorship(row) == false)
                    orphanedRows.Add(row);
            }

            foreach (CatalogDataset.CatalogItemsRow row in orphanedRows)
            {
                row.Delete();
            }

            this.CatalogItems.AcceptChanges();
        }

        private bool CheckRowAncestorship(CatalogDataset.CatalogItemsRow row)
        {
            if (row != null)
            {
                if (row.IsRoot)
                    return true;

                CatalogDataset.CatalogItemsRow parentRow = this.CatalogItems.FindByItemID(row.ParentItemID);
                if (parentRow != null)
                    return CheckRowAncestorship(parentRow);
            }

            return false;
        }

        public void Save()
        {
            Save(this.Path);
        }
        #endregion

        #region Add items
        #endregion

        #region Modify items
        #endregion

        #region Delete items
        #endregion

        #region Construction
        public Catalog()
            : base(DefaultLocation, false)
        {
            LoadTemplateCatalog(DefaultLocation);
            _isDefaultLocation = true;

            _info = new CatalogInfo(this);
        }

        public Catalog(string fileName) 
            : base(fileName, false)
        {
            LoadCompressedCatalog(fileName);
        }
        #endregion

        public static bool IsNullOrEmpty(Catalog cat)
        {
            return cat == null ||
                cat.CatalogItems == null ||
                cat.CatalogItems.Rows == null ||
                cat.CatalogItems.Rows.Count <= 0;
        }

        private void MigrateDataToLatestVersion()
        {
            ConsistencyCheck();

            if (CatalogInfoTable.Rows.Count < 1)
            {
                // If catalog info does not exist, we create it.
                CatalogInfoTable.AddCatalogInfoRow(CatalogInfoTable.NewCatalogInfoRow());
                CatalogInfoTable.AcceptChanges();

                _info = new CatalogInfo(this);
            }
            else
            {
                if (_info == null)
                {
                    _info = new CatalogInfo(this);
                }

                string latestVersion = new Catalog().CatalogSchemaVersion;
                if (CatalogSchemaVersion != latestVersion)
                {
                    (CatalogInfoTable.Rows[0] as CatalogDataset.CatalogInfoRow).Version = latestVersion;
                    (CatalogInfoTable.Rows[0] as CatalogDataset.CatalogInfoRow).AcceptChanges();

                    version = latestVersion;
                }
            }
        }

        #region Methods

        public CatalogItemType CatalogItemType_GetByTypeID(int id)
        {
            var rows = from row in CatalogItemTypes
                       where row.TypeID == id
                       select row;

            return (rows.Count() == 0 ? null : new CatalogItemType(rows.FirstOrDefault()));
        }

        public CatalogItemType CatalogItemType_GetByTypeCode(string typeCode)
        {
            var rows = from row in CatalogItemTypes
                       where row.TypeCode == typeCode
                       select row;

            return (rows.Count() == 0 ? null : new CatalogItemType(rows.FirstOrDefault()));
        }

        //public CatalogItemType[] GetAll()
        //{
        //    var rows = from row in CatalogItemTypes
        //               select row;

        //    return GetArray(rows);
        //}


        internal int CountChildren(CatalogItem catalogItem, bool recursive, ChildType childType)
        {
            if (CatalogItemType_GetByTypeID(catalogItem.ItemType).TypeCode == "FIL")
                return 0; // A file cannot have any children

            string typeCode = string.Empty;
            switch (childType)
            {
                case ChildType.File:
                    typeCode = "FIL";
                    break;

                case ChildType.Folder:
                    typeCode = "FLD";
                    break;

            }

            CatalogItem[] children = FindItems(catalogItem, typeCode, string.Empty, string.Empty, true);

            if (children != null)
                return children.Length;

            return 0;
        }

        public CatalogItem[] FindItems(CatalogItem parent, string typeCode, string namePattern, string descPattern, bool searchSubfolders)
        {
            CatalogItemType type = CatalogItemType_GetByTypeCode(typeCode);
            string parentPath = null;
            long parentItemId = -1;

            if (parent != null)
            {
                if (searchSubfolders)
                {
                    parentPath = parent.OrigItemPath.TrimEnd("/\\".ToCharArray());
                }
                else
                {
                    parentItemId = parent.ItemID;
                }
            }

            var rows = from row in CatalogItems
                    where
                    (
                        (type == null || type.TypeID == row.ItemTypeID) &&

                        (string.IsNullOrEmpty(parentPath) || (row.OrigItemPath.ToLowerInvariant().StartsWith(parentPath.ToLowerInvariant()))) &&

                        (parentItemId < 0 || row.ParentItemID == parentItemId) &&

                        (string.IsNullOrEmpty(namePattern) || row.Name.ToLowerInvariant().Contains(namePattern.ToLowerInvariant())) &&

                        (string.IsNullOrEmpty(descPattern) || row.Description.ToLowerInvariant().Contains(descPattern.ToLowerInvariant()))

                    )
                    select row;

            return GetItemArray(rows.ToArray());
        }

        public CatalogItem GetByVPath(string vpath)
        {
            CatalogItem retVal = null;

            try
            {
                char[] seps = new char[] { '?', '.' };
                string[] vpathFields = vpath.Split(seps);
                if (vpathFields.Length > 0)
                {
                    long id = long.Parse(vpathFields[0]);
                    retVal = GetByItemID(id);
                }
            }
            catch
            {
            }

            return retVal;
        }

        public CatalogItem GetByItemID(long id)
        {
            var rows = from row in CatalogItems
                       where row.ItemID == id
                       select row;

            return (rows.Count() == 0 ? null : new CatalogItem(this, rows.FirstOrDefault()));
        }

        public CatalogItem[] GetByParentItemID(long id)
        {
            var rows = from row in CatalogItems
                       where row.ParentItemID == id
                       select row;

            return GetItemArray(rows.ToArray());
        }

        public CatalogItem[] GetFoldersByParentItemID(long id)
        {
            CatalogItemType folderType = CatalogItemType_GetByTypeCode("FLD");

            var rows = from row in CatalogItems
                       where (row.ItemTypeID == folderType.TypeID && row.ParentItemID == id)
                       select row;

            return GetItemArray(rows.ToArray());
        }

        //public CatalogItem[] GetByName(string name)
        //{
        //    var rows = from row in CatalogItems
        //               where (row.Name.ToLowerInvariant() == name.ToLowerInvariant())
        //               select row;

        //    return GetArray(rows);
        //}

        public CatalogItem GetRootBySerialNumber(string serialNumber)
        {
            var rows = from row in CatalogItems
                       where row.IsRoot && row.RootSerialNumber == serialNumber
                       select row;

            return (rows.Count() == 0 ? null : new CatalogItem(this, rows.FirstOrDefault()));
        }

        public CatalogItem[] GetRoots()
        {
            var rows = from row in CatalogItems
                       where row.IsRoot
                       select row;

            return GetItemArray(rows.ToArray());
        }

        #endregion

        private CatalogItem[] GetItemArray(CatalogDataset.CatalogItemsRow[] rows)
        {
            CatalogItem[] instances = new CatalogItem[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                instances[i] = new CatalogItem(this, rows[i]);
            }
            return instances;
        }
    }

    public class CatalogException : Exception
    {
        string _detail = string.Empty;

        public string Detail { get { return _detail; } }

        public CatalogException(string msg, string detail)
            : base(msg)
        {
            _detail = detail;
        }
    }
}
