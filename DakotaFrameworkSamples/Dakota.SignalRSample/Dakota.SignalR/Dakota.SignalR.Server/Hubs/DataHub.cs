using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.SignalR.Server.Hubs
{
    public class DataHub : Hub
    {
        public void ReceiveData(Byte[] Data)
        {
            Console.WriteLine(Data.ToString());
        }

        [HubMethodName("Receive")]
        public void ReceiveData(string Data)
        {
            Console.WriteLine(Data);
        }
    }
}
