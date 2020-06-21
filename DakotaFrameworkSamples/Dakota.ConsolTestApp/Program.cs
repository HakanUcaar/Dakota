using System;
using System.IO.Ports;
using Dakota.ConsolTestApp.Machines;
using Dakota.Receiver;
using Dakota.Receiver.HID;

namespace Dakota.ConsolTestApp
{
    class Program
    {
        public static Dashboard Dash = new Dashboard();

        static void Main(string[] args)
        {
            //var Receiver = new SerialPortReceiver(new ArduinoMachine());
            //Receiver.PortName = "COM3";
            //Receiver.BaudRate = 9600;
            //Receiver.Parity = Parity.None;
            //Receiver.DataBits = 8;
            //Receiver.StopBits = StopBits.One;
            //Receiver.Handshake = Handshake.None;
            //Receiver.Connect();
            //Dash.AddReceiver(Receiver);

            //var Receiver1 = new CustomAIDataReceiver(new AIMachine("AI1", "Yapay Makine 1"));
            //Receiver1.Connect();
            //Dash.AddReceiver(Receiver1);
            //var Receiver2 = new CustomAIDataReceiver(new AIMachine("AI2", "Yapay Makine 2"));
            //Receiver2.Connect();
            //Dash.AddReceiver(Receiver2);

            var Receiver = new HIDReceiver(new GamePadMachine());
            Receiver.VendorId = 0x0810;
            Receiver.ProductId = 0xe501;
            Receiver.Connect();

            //var Receiver = new HIDReceiver(new BluetoothMachine());
            //Receiver.VendorId = 0X0E8F;
            //Receiver.ProductId = 0x00A8;
            //Receiver.Connect();
            Console.ReadLine();
        }
    }     
}
