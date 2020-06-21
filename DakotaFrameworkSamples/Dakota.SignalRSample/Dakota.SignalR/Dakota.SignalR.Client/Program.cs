using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dakota.Client.SignalR;
using Dakota.Receiver.HID;
using Dakota.SignalR.Client.Machine;

namespace Dakota.SignalR.Client
{
    class Program
    {
        static SigalRClient Client = new SigalRClient();

        static void Main(string[] args)
        {

            var Receiver = new HIDReceiver(new GamePadMachine());
            Receiver.VendorId = 0x0810;
            Receiver.ProductId = 0xe501;

            Client = new SigalRClient(Receiver);
            Client.URL = "http://localhost:13000/";
            Client.HubName = "DataHub";
            Client.MethodName = "Receive";
            Client.Connect();

            Client.StartReceiver();

            //Test();
        }

        static void Test()
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Lütfen bir yazı girin");
            string Data = Console.ReadLine();
            Client.SendData(Data);
            Test();
        }
    }
}
