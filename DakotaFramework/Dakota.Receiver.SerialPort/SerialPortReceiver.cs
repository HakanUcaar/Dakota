using System;
using System.Linq;
using System.IO.Ports;
using System.Threading.Tasks;
using Dakota.Machine;

namespace Dakota.Receiver.SerialPort
{
    public class SerialPortReceiver : AbstractReceiver
    {
        bool _Continue;
        private System.IO.Ports.SerialPort Serial = new System.IO.Ports.SerialPort();

        public string PortName { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public Parity Parity { get; set; }
        public StopBits StopBits { get; set; }
        public Handshake Handshake { get; set; }

        public SerialPortReceiver(IMachine Machine) : base(Machine)
        {

        }

        public override bool Connect()
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

                _Continue = true;
                return true;
            }
            catch (Exception ex)
            {
                _Continue = false;
                return false;
            }
        }
        public override void DisConnect()
        {
            _Continue = false;
            Serial.Close();
        }

        public async void ReceivePort(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = Serial.ReadLine();
                if (_Continue)
                {
                    await Task.Run(() =>
                    {
                        var Movement = this.Machine.MovementList.Where(o => data.IndexOf(o.RecieverTag) != -1).FirstOrDefault();
                        if (Movement != null)
                        {
                            Movement.Value = data;
                        }
                    });
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
