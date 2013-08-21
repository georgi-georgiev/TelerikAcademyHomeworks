using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SimpleWCFService
{
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        string GetDayInBulgarian(DateTime value);
    }
}
