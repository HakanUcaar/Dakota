using Dakota.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.SignalR.Client.Machine.GamePadMovements
{
    public class ButtonOnSagMovement : AbstractMovement
    {
        public ButtonOnSagMovement(IMachine Machine) : base(Machine, "7F 7F 00 00 00 00 00 01 00 00 00 00")
        {
            OnReceiveData += ReceiveData;
        }

        public void ReceiveData(IMachine Sender, object Data)
        {
            Console.WriteLine(Sender.Name + " Okunan Veri : Ön Sağ tuşuna basılıyor");
        }
    }
}
