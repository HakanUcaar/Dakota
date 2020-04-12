using System;
using System.IO.Ports;
using Dakota.ConsolTestApp.Machines;
using Dakota.Receiver;

namespace Dakota.ConsolTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var Receiver = new SerialPortReceiver(new ArduinoMachine());
            Receiver.PortName = "COM3";
            Receiver.BaudRate = 9600;
            Receiver.Parity = Parity.None;
            Receiver.DataBits = 8;
            Receiver.StopBits = StopBits.One;
            Receiver.Handshake = Handshake.None;
            Receiver.Connect();
            Console.ReadLine();
        }
    }     
}
