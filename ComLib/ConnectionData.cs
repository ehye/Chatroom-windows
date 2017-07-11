using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComLib
{
    public class ConnectionData
    {
        public static System.Net.IPAddress ServerIP { get; set; } = System.Net.IPAddress.Parse("192.168.2.104");
        public static int ServerPort { get; set; } = 6017;
        public static System.Net.IPEndPoint Ipe { get; set; } = new System.Net.IPEndPoint(ServerIP, ServerPort);
    }
}
