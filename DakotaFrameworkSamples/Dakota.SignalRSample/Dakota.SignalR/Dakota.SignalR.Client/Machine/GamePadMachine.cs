
using Dakota.Machine;
using Dakota.SignalR.Client.Machine.GamePadMovements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.SignalR.Client.Machine
{
    public class GamePadMachine : AbstractMachine
    {

        public GamePadMachine() : base("1", "Game Pad 1")
        {
            NewMovement<YukariMovement>();
            NewMovement<AsagiMovement>();
            NewMovement<SolMovement>();
            NewMovement<SagMovement>();
            NewMovement<ButtonXMovement>();
            NewMovement<ButtonYMovement>();
            NewMovement<ButtonAMovement>();
            NewMovement<ButtonBMovement>();
            NewMovement<ButtonOnSolMovement>();
            NewMovement<ButtonOnSagMovement>();
        }
    }
}

