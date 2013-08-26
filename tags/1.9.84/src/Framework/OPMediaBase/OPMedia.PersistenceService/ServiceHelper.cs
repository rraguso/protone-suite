using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Runtime.ServiceHelpers;
using System.ServiceModel;
using OPMedia.Core;

namespace OPMedia.PersistenceService
{
    internal class ServiceHelper : ServiceHelperBase
    {
        ServiceHost _host = null;

        public ServiceHelper()
        {
           
        }

        protected override void StartInternal()
        {
            Environment.CurrentDirectory = SuiteConfiguration.InstallationPath;

            string address = "net.pipe://localhost/PersistenceService.svc";

            NetNamedPipeBinding binding = new NetNamedPipeBinding();

            _host = new ServiceHost(typeof(PersistenceServiceImpl));
            _host.AddServiceEndpoint(typeof(IPersistenceService), binding, address);

            _host.Open();
        }

        protected override void StopInternal()
        {
            _host.Close();
            _host = null;
        }
    }
}
