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
        string ReadObject(string persistenceId);

        [OperationContract]
        void SaveObject(string persistenceId, string objectContent);

        [OperationContract]
        void DeleteObject(string persistenceId);

    }
}
