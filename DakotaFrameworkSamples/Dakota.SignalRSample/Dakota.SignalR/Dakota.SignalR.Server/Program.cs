using Dakota.SignalR.Server.Configuration;
using Microsoft.Owin.Hosting;
using System;

namespace Dakota.SignalR.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string URL = "http://localhost:13000/";
            using (WebApp.Start<Startup>(url: URL))
            {
                Console.WriteLine("Server Up");
                Console.ReadLine();
            }
        }
    }
}
