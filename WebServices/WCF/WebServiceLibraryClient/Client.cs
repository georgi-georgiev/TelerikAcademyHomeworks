using System;
using System.Linq;
using WebServiceLibrary;
using WebServiceLibraryClient.ServiceLibraryReference;

namespace WebServiceLibraryClient
{
    public class Client
    {
        static void Main()
        {
            ServiceLibraryClient serviceLibrary = new ServiceLibraryClient();
            Console.WriteLine(serviceLibrary.GetCountSecondContainsFirst("the",
                "The man who was on the top of his house was the is the winner of the dota 2 championship for the second time"));

            serviceLibrary.Close();
        }
    }
}
