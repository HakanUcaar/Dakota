using Dakota.Machine;
using System;

namespace Dakota.ConsolTestApp.Machines.Movements
{
    public class ArdMovement : AbstractMovement
    {
        public ArdMovement() : base("-Uret")
        {
            OnReceiveData += ReceiveData;
        }

        public void ReceiveData(IMovement Sender, object Data)
        {
            Console.WriteLine("Okunan Veri : " + Data.ToString());
        }
    }
}
