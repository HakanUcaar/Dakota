using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.Client
{
    public interface IClient
    {
        void Connect();
        void DisConnect();
        void SendData(string Data);
        void SendData(byte[] Data);
    }
}
