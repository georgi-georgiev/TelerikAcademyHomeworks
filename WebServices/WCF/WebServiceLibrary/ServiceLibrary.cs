using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebServiceLibrary
{
    public class ServiceLibrary : IServiceLibrary
    {
        public int GetCountSecondContainsFirst(string first, string second)
        {
            return second.ToLower().Split(new string[] { first.ToLower() }, StringSplitOptions.None).Length - 1;
        }
    }
}
