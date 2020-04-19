using Dakota.ConsolTestApp.Machines.Movements;
using Dakota.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.ConsolTestApp.Machines
{
    public class AIMachine : AbstractMachine
    {
        public AIMachine(string ID, string Name) : base(ID, Name)
        {
            NewMovement<AIMovement>();
        }

    }
}
