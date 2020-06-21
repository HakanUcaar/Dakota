using Dakota.Machine;
using Dakota.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.Client
{
    public abstract class AbstractClient : IClient,IDisposable
    {
        private IReceiver Receiver { get; set; }

        public AbstractClient()
        {

        }
        public AbstractClient(IReceiver Receiver)
        {
            this.Receiver = Receiver;
        }

        public void StartReceiver()
        {
            foreach (var item in Receiver.Machine.MovementList)
            {
                (item as AbstractMovement).OnReceiveData += (o,i) =>
                {
                    SendData(i.ToString());
                };
            }
            
            Receiver.Connect();
        }

        private void AbstractClient_OnReceiveData(IMachine Sender, object Data)
        {
            throw new NotImplementedException();
        }

        public abstract void Connect();
        public abstract void DisConnect();
        public abstract void Dispose();
        public abstract void SendData(string Data);
        public abstract void SendData(byte[] Data);
    }
}
