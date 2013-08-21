using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWCFService;
using SimpleWCFServiceClient.ServiceReference;

namespace SimpleWCFServiceClient
{
    class Simple
    {
        static void Main(string[] args)
        {
            ServiceClient service = new ServiceClient();
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(service.GetDayInBulgarian(DateTime.Now));
            
            //To see the result in correct format you need to change font of console from properties

            service.Close();
        }
    }
}
