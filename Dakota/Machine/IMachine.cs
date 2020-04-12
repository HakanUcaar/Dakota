using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.Machine
{
    public interface IMachine
    {
        string ID { get; set; }
        string Name { get; set; }
        List<IMovement> MovementList { get; set; }
    }
}
