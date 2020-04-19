using Dakota.Client;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.Client.SignalR
{
    public class SigalRClient : AbstractClient
    {
        private HubConnection HubConnection;
        private IHubProxy Proxy;

        public string URL { get; set; }
        public string HubName { get; set; }
        public string MethodName { get; set; }

        public SigalRClient()
        {

        }

        public override void Connect()
        {
            HubConnection = new HubConnection(URL);
            Proxy = HubConnection.CreateHubProxy(HubName);
            try
            {
                HubConnection.Start().Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void DisConnect()
        {
            HubConnection.Stop();
        }

        public override void Dispose()
        {
            HubConnection.Dispose();
        }

        public override void SendData(byte[] Data)
        {
            Proxy.Invoke(MethodName, Data);
        }

        public override void SendData(string Data)
        {
            Proxy.Invoke(MethodName, Data);
        }
    }
}
