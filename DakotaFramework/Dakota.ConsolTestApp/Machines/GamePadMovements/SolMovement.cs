using Dakota.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.ConsolTestApp.Machines.GamePadMovements
{
    public class SolMovement : AbstractMovement
    {
        public SolMovement(IMachine Machine) : base(Machine, "00 7F 00 00 00 00 00 00 00 00 00 00")
        {
            OnReceiveData += ReceiveData;
        }

        public void ReceiveData(IMachine Sender, object Data)
        {
            Console.WriteLine(Sender.Name + " Okunan Veri : Sol tuşuna basılıyor");
        }
    }
}
