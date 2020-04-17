using Dakota.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.ConsolTestApp.Machines.Movements
{
    public class AIMovement : AbstractMovement
    {
        public AIMovement(IMachine Machine) : base(Machine,"-AIData")
        {
            OnReceiveData += ReceiveData;
        }

        public void ReceiveData(IMachine Sender, object Data)
        {
            Program.Dash.UpdateDashboard();
            //Console.Write(Sender.Name + " Okunan Veri : " + Data.ToString());
        }
    }
}
