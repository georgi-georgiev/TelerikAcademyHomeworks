using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebServiceLibrary
{
    [ServiceContract]
    public interface IServiceLibrary
    {
        [OperationContract]
        int GetCountSecondContainsFirst(string first, string second);
    }
}
