using System;
using Nancy.Hosting.Self;
using ElectronicQueue.Common;

namespace Testing_Nancyfx_wnc
{
    public static class Program
    {
        static void Main(string[] args)
        {
            HostConfiguration hostConfigs = new HostConfiguration();
            hostConfigs.UrlReservations.CreateAutomatically = true;
            Uri uri = new Uri("http://localhost:1234");
            var host = new NancyHost(hostConfigs, uri);
            host.Start();

            EQAgent eqAgent = new EQAgent();
            CategoryList categoryList = new CategoryList();
            bool b = eqAgent.GetCategories(ref categoryList);

            //Console.ReadLine();
        }
    }
}
