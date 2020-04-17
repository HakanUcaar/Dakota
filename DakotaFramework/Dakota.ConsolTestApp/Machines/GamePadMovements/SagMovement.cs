using Dakota.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.ConsolTestApp.Machines.GamePadMovements
{
    public class SagMovement : AbstractMovement
    {
        public SagMovement(IMachine Machine) : base(Machine, "FF 7F 00 00 00 00 00 00 00 00 00 00")
        {
            OnReceiveData += ReceiveData;
        }

        public void ReceiveData(IMachine Sender, object Data)
        {
            Console.WriteLine(Sender.Name + " Okunan Veri : Sağ tuşuna basılıyor");
        }
    }
}
