using System;
using System.Net;
using System.Net.Sockets;

namespace ComLib
{
    public class Lib
    {
        public static string GetPubIp()
        {
            var publicip = new WebClient().DownloadString("http://icanhazip.com");
            string[] s = publicip.Split(new Char[] { '\n' });
            return s[0];
        }

        public static string GetLocalIPAddress()
        {
            /*
             * 精确IP
             * 需连接上互联网
             */
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP))
            {
                socket.Connect("8.8.8.8", 65530);
                var endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            return localIP;
        }

        public static object[] GetLocalIPAddresses()
        {
            string hostname = Dns.GetHostName();
            IPHostEntry localhost = Dns.GetHostEntry(hostname);
            return localhost.AddressList;
        }
    }
}
