﻿using Dakota.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakota.SignalR.Client.Machine.GamePadMovements
{
    public class ButtonXMovement : AbstractMovement
    {
        public ButtonXMovement(IMachine Machine) : base(Machine, "7F 7F 01 00 00 00 00 00 00 00 00 00")
        {
            OnReceiveData += ReceiveData;
        }

        public void ReceiveData(IMachine Sender, object Data)
        {
            Console.WriteLine(Sender.Name + " Okunan Veri : X tuşuna basılıyor");
        }
    }
}
