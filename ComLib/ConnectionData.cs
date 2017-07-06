using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComLib
{
    public class ConnectionData
    {
        public static System.Net.IPAddress ServerIP { get; set; } = System.Net.IPAddress.Parse("127.0.0.1");
        public static int ServerPort { get; set; } = 6017;
    }
}
