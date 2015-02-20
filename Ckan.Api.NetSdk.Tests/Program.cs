using Ckan.NetSdk.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ckan.Api.NetSdk.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var ckanApiClient = new CkanApiClient();

            var requestTask = ckanApiClient.User.GetAll(query: "Alex");
            requestTask.Wait();

            Console.ReadLine();
        }
    }
}
