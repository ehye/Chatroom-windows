using System;
using System.Net;
using System.Net.Sockets;

namespace ComLib
{
    public class ServerConf
    {
        public static IPAddress ServerIP { get; set; } = IPAddress.Parse(Lib.GetLocalIPAddress());
        public static int ServerPort { get; set; } = 6017;
        public static IPEndPoint Ipe { get; set; } = new IPEndPoint(ServerIP, ServerPort);
    }
}