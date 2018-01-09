using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace VerySimpleChatServer
{
    class VerySimpleChatServer
    {
        private TcpListener tcpListener;
        private List<NetworkStream> clientStreams;
        private ServerForm serverForm;

        public VerySimpleChatServer(string host, string port, ServerForm serverForm)
        {
            this.serverForm = serverForm;
            var ipe = new IPEndPoint(IPAddress.Parse(host), Int16.Parse(port));
            tcpListener = new TcpListener(ipe);
            clientStreams = new List<NetworkStream>();
        }

        internal void Start()
        {
            tcpListener.Start();
            serverForm.PrintLog("server start");
            Console.WriteLine("server start");

            new Thread(() =>
            {
                while (true) try
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    NetworkStream stream = tcpClient.GetStream();
                    clientStreams.Add(stream);
                    ClientHandler clientHandler = new ClientHandler(tcpClient, this);
                    Thread tHandler = new Thread(new ThreadStart(clientHandler.Run)) { Name = "Handler" };
                    tHandler.Start();
                    serverForm.PrintLog($"got a connection form {tcpClient.Client.RemoteEndPoint.ToString()} \n");
                    Console.WriteLine("got a connection form " + tcpClient.Client.RemoteEndPoint.ToString());
                }
                catch (Exception) { throw; }
            }).Start();
        }

        internal void Broadcast(string message)
        {
            var i = clientStreams.GetEnumerator();
            while (i.MoveNext()) try
            {
                i.Current.Write(Encoding.UTF8.GetBytes(message), 0, message.Length);
                i.Current.Flush();
            }
            catch (Exception) { throw; }
        }

        private class ClientHandler
        {
            TcpClient tcpClient;
            NetworkStream networkStream;
            VerySimpleChatServer server;

            public ClientHandler(TcpClient tcpClient, VerySimpleChatServer server)
            {
                this.server = server;
                try
                {
                    this.tcpClient = tcpClient;
                    networkStream = tcpClient.GetStream();
                }
                catch (Exception) { throw; }
            }

            internal void Run()
            {
                while (true) try
                {
                    byte[] buffer = new byte[1024];
                    string message;
                    int count = networkStream.Read(buffer, 0, buffer.Length);
                    while (count != 0)
                    {
                        message = Encoding.UTF8.GetString(buffer, 0, count);
                        count = 0;
                        networkStream.Flush();
                        server.Broadcast(message);

                        #region echo
                        //message = message.ToUpper();
                        //byte[] echomsg = Encoding.UTF8.GetBytes(message);
                        //networkStream.Write(echomsg, 0, echomsg.Length);
                        //Console.WriteLine($"Echo: {message}");
                        #endregion
                    }
                }
                catch (Exception) { throw; }
            }
        }
    }
}
