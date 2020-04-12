using System;
using System.Linq;
using Dakota.Machine;
using System.IO.Ports;
using Dakota.Receiver;

namespace Dakota.ConsolTestApp
{
    public class ArduinoSerialPortDataReceiver : AbstractReceiver
    {
        static bool _continue;
        private SerialPort Serial = new SerialPort();

        public ArduinoSerialPortDataReceiver(IMachine Machine) : base(Machine)
        {
        }

        public override void Connect()
        {
            try
            {
                Serial.PortName = "COM3";
                Serial.BaudRate = 9600;
                Serial.Parity = Parity.None;
                Serial.DataBits = 8;
                Serial.StopBits = StopBits.One;
                Serial.Handshake = Handshake.None;
                Serial.DataReceived += ReceivePort;

                Serial.Open();

                _continue = true;
                Console.WriteLine(this.Machine.Name + " bağlandı ");
            }
            catch (Exception ex)
            {
                _continue = false;
                Console.WriteLine("Bağlantı Başarısız ");
            }
        }

        public void ReceivePort(object sender, SerialDataReceivedEventArgs e)
        {
            string data = Serial.ReadLine();
            if (_continue)
            {
                if(this.Machine.MovementList.Any(o=> data.IndexOf(o.RecieverTag) != -1))
                {
                    this.Machine.MovementList.Where(o => data.IndexOf(o.RecieverTag) != -1).First().Value = data;
                }
            }
        }
    }
}
