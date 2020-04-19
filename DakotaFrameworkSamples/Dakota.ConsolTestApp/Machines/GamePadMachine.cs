using Dakota.ConsolTestApp.Machines.GamePadMovements;
using Dakota.ConsolTestApp.Machines.Movements;
using Dakota.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.ConsolTestApp.Machines
{
    public class GamePadMachine : AbstractMachine
    {

        public GamePadMachine() : base("1", "Game Pad 1")
        {
            NewMovement<YukariMovement>();
            NewMovement<AsagiMovement>();
            NewMovement<SolMovement>();
            NewMovement<SagMovement>();
            NewMovement<ButonXMovement>();
        }
    }
}
