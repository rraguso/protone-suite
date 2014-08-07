using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace OPMedia.Core
{
    [ServiceContract]
    public interface IPersistenceService
    {
        [OperationContract]
        string ReadObject(string persistenceId, string persistenceContext);

        [OperationContract]
        void SaveObject(string persistenceId, string persistenceContext, string objectContent);

        [OperationContract]
        void DeleteObject(string persistenceId, string persistenceContext);

    }
}
