using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dakota.WebSoket.Server
{
    class Program
    {
        static string URI = "http://127.0.0.1:13100/";

        static void Main(string[] args)
        {
            var server = new Server();
            server.Start(URI);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        class Server
        {
            private int count = 0;

            public async void Start(string listenerPrefix)
            {
                HttpListener listener = new HttpListener();
                listener.Prefixes.Add(listenerPrefix);
                listener.Start();
                Console.WriteLine("Listening...");

                while (true)
                {
                    HttpListenerContext listenerContext = await listener.GetContextAsync();
                    if (listenerContext.Request.IsWebSocketRequest)
                    {
                        ProcessRequest(listenerContext);
                    }
                    else
                    {
                        listenerContext.Response.StatusCode = 400;
                        listenerContext.Response.Close();
                    }
                }
            }

            //### Accepting WebSocket connections
            // Calling `AcceptWebSocketAsync` on the `HttpListenerContext` will accept the WebSocket connection, sending the required 101 response to the client
            // and return an instance of `WebSocketContext`. This class captures relevant information available at the time of the request and is a read-only 
            // type - you cannot perform any actual IO operations such as sending or receiving using the `WebSocketContext`. These operations can be 
            // performed by accessing the `System.Net.WebSocket` instance via the `WebSocketContext.WebSocket` property.        
            private async void ProcessRequest(HttpListenerContext listenerContext)
            {

                WebSocketContext webSocketContext = null;
                try
                {
                    // When calling `AcceptWebSocketAsync` the negotiated subprotocol must be specified. This sample assumes that no subprotocol 
                    // was requested. 
                    webSocketContext = await listenerContext.AcceptWebSocketAsync(subProtocol: null);
                    Interlocked.Increment(ref count);
                    Console.WriteLine("Processed: {0}", count);
                }
                catch (Exception e)
                {
                    // The upgrade process failed somehow. For simplicity lets assume it was a failure on the part of the server and indicate this using 500.
                    listenerContext.Response.StatusCode = 500;
                    listenerContext.Response.Close();
                    Console.WriteLine("Exception: {0}", e);
                    return;
                }

                WebSocket webSocket = webSocketContext.WebSocket;

                try
                {
                    //### Receiving
                    // Define a receive buffer to hold data received on the WebSocket connection. The buffer will be reused as we only need to hold on to the data
                    // long enough to send it back to the sender.
                    byte[] receiveBuffer = new byte[2048];

                    // While the WebSocket connection remains open run a simple loop that receives data and sends it back.
                    while (webSocket.State == WebSocketState.Open)
                    {
                        var buffer = new ArraySegment<byte>(new byte[2048]);
                        WebSocketReceiveResult result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                        var ms = new MemoryStream();
                        ms.Write(buffer.Array, buffer.Offset, result.Count);
                        ms.Seek(0, SeekOrigin.Begin);
                        var reader = new StreamReader(ms, Encoding.UTF8);
                        Console.WriteLine(await reader.ReadToEndAsync());
                    }
                }
                catch (Exception e)
                {
                    // Just log any exceptions to the console. Pretty much any exception that occurs when calling `SendAsync`/`ReceiveAsync`/`CloseAsync` is unrecoverable in that it will abort the connection and leave the `WebSocket` instance in an unusable state.
                    Console.WriteLine("Exception: {0}", e);
                }
                finally
                {
                    // Clean up by disposing the WebSocket once it is closed/aborted.
                    if (webSocket != null)
                        webSocket.Dispose();
                }
            }
        }
    }

    // This extension method wraps the BeginGetContext / EndGetContext methods on HttpListener as a Task, using a helper function from the Task Parallel Library (TPL).
    // This makes it easy to use HttpListener with the C# 5 asynchrony features.
    public static class HelperExtensions
    {
        public static Task GetContextAsync(this HttpListener listener)
        {
            return Task.Factory.FromAsync<HttpListenerContext>(listener.BeginGetContext, listener.EndGetContext, TaskCreationOptions.None);
        }
    }
}
