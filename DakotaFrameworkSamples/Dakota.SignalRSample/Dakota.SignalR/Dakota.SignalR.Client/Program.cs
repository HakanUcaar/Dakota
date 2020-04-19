using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dakota.Client.SignalR;

namespace Dakota.SignalR.Client
{
    class Program
    {
        static SigalRClient Client = new SigalRClient();

        static void Main(string[] args)
        {
            Client = new SigalRClient();
            Client.URL = "http://localhost:13000/";
            Client.HubName = "DataHub";
            Client.MethodName = "Receive";
            Client.Connect();
            Test();
        }

        static void Test()
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Lütfen bir yazı girin");
            string Data = Console.ReadLine(); ;
            Client.SendData(Data);
            Test();
        }
    }
}
