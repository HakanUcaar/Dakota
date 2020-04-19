using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.Client
{
    public abstract class AbstractClient : IClient,IDisposable
    {
        public abstract void Connect();
        public abstract void DisConnect();
        public abstract void Dispose();
        public abstract void SendData(string Data);
        public abstract void SendData(byte[] Data);
    }
}
