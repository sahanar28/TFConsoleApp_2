
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp;
using MyApp.ServiceInterface;
using MyApp.ServiceModel;
using MyApp.Controllers;
using MyApp.Models;
using ServiceStack;
using System.Diagnostics;
using System.Net;
using System.Net.Security;


namespace testFieldConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            AppHostConfig.Initialize();
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            var client = new ServiceStack.JsonServiceClient("https://localhost:5001/hello?Name=test");

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            Hello request = new Hello() { Name = "World" };

            HelloResponse response = client.Get<HelloResponse>(request);

            if (response != null)
            {

                var fields = response.Fields;
            }
            else
            {
                Console.WriteLine("No response received.");
            }


            Console.ReadLine();
        }
    }
}
