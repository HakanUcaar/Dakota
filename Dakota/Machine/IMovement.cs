using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.Machine
{
    public interface IMovement
    {
        string Name { get; set; }
        string RecieverTag { get; set; }
        object Value { get; set; }
    }
}
