using Dakota.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dakota.Client.WebSoket
{
    public class WebSoketClient : AbstractClient
    {
        private ClientWebSocket WebSocket = new ClientWebSocket();
        public string URI { get; set; }

        public WebSoketClient()
        {

        }

        public async override void Connect()
        {
            await WebSocket.ConnectAsync(new Uri(URI), CancellationToken.None);
        }
        public override void DisConnect()
        {
            WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure,"Kapatıldı",CancellationToken.None);
        }
        public override void Dispose()
        {
            WebSocket.Dispose();
        }
        public async override void SendData(byte[] Data)
        {
            await WebSocket.SendAsync(new ArraySegment<byte>(Data), WebSocketMessageType.Text, true, CancellationToken.None);
        }
        public async override void SendData(string Data)
        {          
           await WebSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(Data)), WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
