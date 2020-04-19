using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dakota.Client.Tcp;

namespace Dakota.Tcp.Client
{
    class Program
    {
        static TcpClient Client = new TcpClient();

        static void Main(string[] args)
        {           
            Client.Host = "127.0.0.1";
            Client.Port = 13000;
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
