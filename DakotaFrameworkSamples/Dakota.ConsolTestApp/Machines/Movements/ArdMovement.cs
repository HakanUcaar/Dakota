using Dakota.Machine;
using System;

namespace Dakota.ConsolTestApp.Machines.Movements
{
    public class ArdMovement : AbstractMovement
    {
        public ArdMovement(IMachine Machine) : base(Machine,"-Uret")
        {
            OnReceiveData += ReceiveData;
        }

        public void ReceiveData(IMachine Sender, object Data)
        {
            Program.Dash.UpdateDashboard();
            //Console.Write(Sender.Name +" Okunan Veri : " + Data.ToString());
        }
    }
}
