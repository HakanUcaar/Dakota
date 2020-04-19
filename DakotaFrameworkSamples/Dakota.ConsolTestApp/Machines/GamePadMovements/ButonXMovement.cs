using Dakota.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.ConsolTestApp.Machines.GamePadMovements
{
    public class ButonXMovement : AbstractMovement
    {
        public ButonXMovement(IMachine Machine) : base(Machine, "7F 7F 01 00 00 00 00 00 00 00 00 00")
        {
            OnReceiveData += ReceiveData;
        }

        public void ReceiveData(IMachine Sender, object Data)
        {
            Console.WriteLine(Sender.Name + " Okunan Veri : X tuşuna basılıyor");
        }
    }
}
