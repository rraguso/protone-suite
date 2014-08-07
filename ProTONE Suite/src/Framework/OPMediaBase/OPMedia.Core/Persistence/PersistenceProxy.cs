using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using OPMedia.Core.Logging;
using System.Security.Principal;

namespace OPMedia.Core
{
    public class PersistenceProxy : IDisposable, IPersistenceService
    {
        protected static IPersistenceService _proxy = null;

        protected string _persistenceContext = string.Empty;

        protected static PersistenceProxy CreateProxy()
        {
            return new PersistenceProxy();
        }

        protected PersistenceProxy()
        {
            try
            {
                try
                {
                    _persistenceContext = WindowsIdentity.GetCurrent().Name;
                }
                catch
                {
                    _persistenceContext = string.Format("{0}\\{1}", 
                        Environment.UserDomainName, Environment.UserName);
                }
            }
            catch
            {
                _persistenceContext = string.Empty;
            }

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

        string IPersistenceService.ReadObject(string persistenceId, string persistenceContext)
        {
            try
            {
                return _proxy.ReadObject(persistenceId, persistenceContext);
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
                Abort();
                Open();
            }

            return null;
        }

        void IPersistenceService.SaveObject(string persistenceId, string persistenceContext, string objectContent)
        {
            try
            {
                _proxy.SaveObject(persistenceId, persistenceContext, objectContent);
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
                Abort();
                Open();
            }
        }

        void IPersistenceService.DeleteObject(string persistenceId, string persistenceContext)
        {
            try
            {
                _proxy.DeleteObject(persistenceId, persistenceContext);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Abort();
                Open();
            }
        }

        public static T ReadObject<T>(string persistenceId, T defaultValue, bool usePersistenceContext = false)
        {
            T retVal = defaultValue;

            try
            {
                using (PersistenceProxy pp = new PersistenceProxy())
                {
                    string content = usePersistenceContext ?
                        (pp as IPersistenceService).ReadObject(persistenceId, pp._persistenceContext) :
                        (pp as IPersistenceService).ReadObject(persistenceId, string.Empty);

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

        public static void SaveObject<T>(string persistenceId, T objectContent, bool usePersistenceContext = false)
        {
            try
            {
                using (PersistenceProxy pp = new PersistenceProxy())
                {
                    if (usePersistenceContext)
                        (pp as IPersistenceService).SaveObject(persistenceId, pp._persistenceContext, objectContent.ToString());
                    else
                        (pp as IPersistenceService).SaveObject(persistenceId, string.Empty, objectContent.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }

        public static void DeleteObject(string persistenceId, bool usePersistenceContext = false)
        {
            try
            {
                using (PersistenceProxy pp = new PersistenceProxy())
                {
                    if (usePersistenceContext)
                        (pp as IPersistenceService).DeleteObject(persistenceId, pp._persistenceContext);
                    else
                        (pp as IPersistenceService).DeleteObject(persistenceId, string.Empty);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }
    }
}
