using System;
using System.Linq;
using Dakota.Machine;
using System.IO.Ports;

namespace Dakota.Receiver
{
    public class SerialPortReceiver : AbstractReceiver
    {
        static bool _continue;
        private SerialPort Serial = new SerialPort();

        public string PortName { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public Parity Parity { get; set; }
        public StopBits StopBits { get; set; }
        public Handshake Handshake { get; set; }

        public SerialPortReceiver(IMachine Machine) : base(Machine)
        {

        }

        public override void Connect()
        {
            try
            {
                Serial.PortName = PortName;
                Serial.BaudRate = BaudRate;
                Serial.Parity = Parity;
                Serial.DataBits = DataBits;
                Serial.StopBits = StopBits;
                Serial.Handshake = Handshake;
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
                if (this.Machine.MovementList.Any(o => data.IndexOf(o.RecieverTag) != -1))
                {
                    this.Machine.MovementList.Where(o => data.IndexOf(o.RecieverTag) != -1).First().Value = data;
                }
            }
        }
    }
}
