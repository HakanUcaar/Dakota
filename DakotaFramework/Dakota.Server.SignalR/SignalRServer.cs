using Dakota.Server.SignalR.Configuration;
using Microsoft.Owin.Hosting;

namespace Dakota.Server.SignalR
{
    public class SignalRServer
    {
        public string URI { get; set; }
        public int Port { get; set; }

        public SignalRServer()
        {

        }

        public void Start()
        {
            using (WebApp.Start<Startup>(url: URI+" : " + Port))
            {
                //Serial.DataReceived += ReceivePort;
                //ConnectSerialPort();
            }
        }
    }
}
