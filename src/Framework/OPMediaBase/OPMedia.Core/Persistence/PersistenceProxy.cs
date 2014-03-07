﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using OPMedia.Core.Logging;

namespace OPMedia.Core
{
    public class PersistenceProxy : IDisposable, IPersistenceService
    {
        protected static IPersistenceService _proxy = null;

        protected static PersistenceProxy CreateProxy()
        {
            return new PersistenceProxy();
        }

        protected PersistenceProxy()
        {
            Open();
        }

        protected virtual void Open()
        {
            var myBinding = new NetNamedPipeBinding();
            myBinding.MaxReceivedMessageSize = int.MaxValue;
            myBinding.ReaderQuotas.MaxStringContentLength = int.MaxValue;

            var myEndpoint = new EndpointAddress("net.pipe://localhost/PersistenceService.svc");
            var myChannelFactory = new ChannelFactory<IPersistenceService>(myBinding, myEndpoint);
            _proxy = myChannelFactory.CreateChannel();
        }

        protected void Abort()
        {
            ((ICommunicationObject)_proxy).Abort();
        }

        public void Dispose()
        {
            ((ICommunicationObject)_proxy).Close();
            _proxy = null;
        }

        string IPersistenceService.ReadObject(string persistenceId)
        {
            try
            {
                return _proxy.ReadObject(persistenceId);
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
                Abort();
                Open();
            }

            return null;
        }

        void IPersistenceService.SaveObject(string persistenceId, string objectContent)
        {
            try
            {
                _proxy.SaveObject(persistenceId, objectContent);
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
                Abort();
                Open();
            }
        }

        void IPersistenceService.DeleteObject(string persistenceId)
        {
            try
            {
                _proxy.DeleteObject(persistenceId);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Abort();
                Open();
            }
        }

        public static T ReadObject<T>(string persistenceId, T defaultValue)
        {
            T retVal = defaultValue;

            try
            {
                using (PersistenceProxy pp = new PersistenceProxy())
                {
                    string content = (pp as IPersistenceService).ReadObject(persistenceId);
                    if (!string.IsNullOrEmpty(content))
                    {
                        try
                        {
                            try
                            {
                                retVal = (T)Convert.ChangeType(content, typeof(T));
                            }
                            catch (InvalidCastException)
                            {
                                retVal = (T)Enum.Parse(typeof(T), content);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.LogException(ex);
                            retVal = defaultValue;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
                retVal = defaultValue;
            }

            return retVal;
        }

        public static void SaveObject<T>(string persistenceId, T objectContent)
        {
            try
            {
                using (PersistenceProxy pp = new PersistenceProxy())
                {
                    (pp as IPersistenceService).SaveObject(persistenceId, objectContent.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }

        public static void DeleteObject(string persistenceId)
        {
            try
            {
                using (PersistenceProxy pp = new PersistenceProxy())
                {
                    (pp as IPersistenceService).DeleteObject(persistenceId);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }
    }
}
