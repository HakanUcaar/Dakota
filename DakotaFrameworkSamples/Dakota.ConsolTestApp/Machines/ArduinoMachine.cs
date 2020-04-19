using Dakota.Machine;
using Dakota.ConsolTestApp.Machines.Movements;

namespace Dakota.ConsolTestApp.Machines
{
    public class ArduinoMachine : AbstractMachine
    {
        public ArduinoMachine() : base("Arduino01", "Bir Arduino Cihazı")
        {
            NewMovement<ArdMovement>(); 
        }
    }
}
