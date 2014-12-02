using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Transactions;
using OPMedia.Core;
using OPMedia.Core.Logging;

namespace OPMedia.PersistenceService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public class PersistenceServiceImpl : IPersistenceService
    {
        public string ReadObject(string persistenceId, string persistenceContext)
        {
            try
            {
                using (Persistence db = new Persistence("Persistence.sdf"))
                {
                    var s = (from po in db.PersistedObjects
                            where
                            ( 
                                po.PersistenceID == persistenceId
                                && (string.IsNullOrEmpty(persistenceContext) || string.Compare(persistenceContext, po.PersistenceContext, true) == 0)
                            )
                            select po.Content).FirstOrDefault();

                    return s;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return null;
        }

        public void SaveObject(string persistenceId, string persistenceContext, string objectContent)
        {
            try
            {
                TransactionOptions opt = new TransactionOptions();
                //opt.IsolationLevel = IsolationLevel.Snapshot;
                opt.Timeout = TimeSpan.FromSeconds(3);

                using (Persistence db = new Persistence("Persistence.sdf"))
                {
                    var obj = (from po in db.PersistedObjects
                                where
                                (
                                    po.PersistenceID == persistenceId
                                    && (string.IsNullOrEmpty(persistenceContext) || string.Compare(persistenceContext, po.PersistenceContext, true) == 0)
                                )
                                select po);

                    using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew, opt))
                    {
                        if (obj != null && obj.Count() > 0)
                        {
                            db.PersistedObjects.DeleteAllOnSubmit(obj);
                            db.SubmitChanges();
                        }

                        PersistedObjects po = new PersistedObjects();
                        po.PersistenceID = persistenceId;
                        po.Content = objectContent;

                        po.PersistenceContext = string.IsNullOrEmpty(persistenceContext) ?
                            string.Empty : persistenceContext;

                        db.PersistedObjects.InsertOnSubmit(po);
                        db.SubmitChanges();

                        ts.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }

        public void DeleteObject(string persistenceId, string persistenceContext)
        {
            try
            {
                TransactionOptions opt = new TransactionOptions();
                //opt.IsolationLevel = IsolationLevel.Snapshot;
                opt.Timeout = TimeSpan.FromSeconds(3);

                using (Persistence db = new Persistence("Persistence.sdf"))
                {
                    var obj = (from po in db.PersistedObjects
                                where
                                (
                                    po.PersistenceID == persistenceId
                                    && (string.IsNullOrEmpty(persistenceContext) || string.Compare(persistenceContext, po.PersistenceContext, true) == 0)
                                )
                                select po);

                    using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew, opt))
                    {
                        if (obj != null && obj.Count() > 0)
                        {
                            db.PersistedObjects.DeleteAllOnSubmit(obj);
                            db.SubmitChanges();
                        }

                        db.SubmitChanges();

                        ts.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }
    }
}
