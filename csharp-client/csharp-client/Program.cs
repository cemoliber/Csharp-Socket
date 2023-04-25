using System;
using WebSocketSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace csharp_client
{
    public class Program
    {
        static string message;
        static void Main(string[] args)
        {
            using (WebSocket ws = new WebSocket("ws://192.168.1.101:7890/Echo"))
            {
                ws.OnMessage += Ws_OnMessage;
                ws.Connect();

                while (true)
                {
                    
                    message = Console.ReadLine();
                    if (message.Equals("stop")) break;

                    ws.Send(message);
                }
            }
        }

        private static void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine("Recieved From Server: " + e.Data);
        }
    }
}
