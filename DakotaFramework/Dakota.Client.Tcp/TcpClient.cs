using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using Dakota.Client;

namespace Dakota.Client.Tcp
{
    public class TcpClient : AbstractClient
    {
        private System.Net.Sockets.TcpClient Client;

        public string Host { get; set; }
        public int Port { get; set; }
        public int TimeOut { get; set; } = 5000;

        public TcpClient()
        {
            
        }

        public override void Connect()
        {
            try
            {
                Client = new System.Net.Sockets.TcpClient(Host, Port);
                Console.WriteLine(Client.Connected ? "Bağlantı sağlandı" : "Bağlantı sağlanamadı");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void DisConnect()
        {
            Client.Close();
        }

        public override void SendData(string Data)
        {
            Byte[] data = Encoding.UTF8.GetBytes(Data);
            NetworkStream stream = Client.GetStream();
            stream.Write(data, 0, data.Length);
        }

        public override void SendData(Byte[] Data)
        {
            NetworkStream stream = Client.GetStream();
            stream.Write(Data, 0, Data.Length);
        }

        public override void Dispose()
        {
            if (Client.Connected)
            {
                Client.Close();
            }

            Client = null;
        }
    }
}
