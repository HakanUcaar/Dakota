using Dakota.Client.WebSoket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.WebSoket.Client
{
    class Program
    {
        static WebSoketClient Client = new WebSoketClient();

        static void Main(string[] args)
        {
            Client.URI = "ws://127.0.0.1:13100";
            Client.Connect();
            Test();
        }

        static void Test()
        {
            Console.WriteLine("Bir yazı girin");
            Client.SendData(Console.ReadLine());
            Test();
        }
    }
}
