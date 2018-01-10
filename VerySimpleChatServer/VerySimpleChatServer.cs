using ComLib;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace VerySimpleChatServer
{
    class VerySimpleChatServer
    {
        private TcpListener tcpListener;
        private List<NetworkStream> clientStreams;
        private ServerForm form;
        private List<string> userList;

        public VerySimpleChatServer(string host, string port, ServerForm serverForm)
        {
            this.form = serverForm;
            var ipe = new IPEndPoint(IPAddress.Parse(host), Int16.Parse(port));
            tcpListener = new TcpListener(ipe);
            clientStreams = new List<NetworkStream>();
            userList = new List<string>();
        }

        internal void Start()
        {
            tcpListener.Start();
            form.PrintLog("server start");

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
                    form.PrintLog($"got a connection form {tcpClient.Client.RemoteEndPoint.ToString()} \n");
                }
                catch (Exception) { throw; }
            }).Start();
        }

        internal void Broadcast(Mail mail)
        {
            var i = clientStreams.GetEnumerator();
            while (i.MoveNext()) try
            {
                new BinaryFormatter().Serialize(i.Current, mail);
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

                    // TODO: send current user list
                    StringBuilder sb = new StringBuilder("userlist");
                    foreach (var item in server.userList)
                        sb.AppendFormat(",{0}", item);

                    //byte[] buffer = new byte[sb.Length];
                    //buffer = Encoding.UTF8.GetBytes(sb.ToString());
                    //tcpClient.Client.Send(buffer);

                    Mail mail = new Mail(DateTime.Now.ToString(), "server", sb.ToString());
                    new BinaryFormatter().Serialize(networkStream, mail);
                }
                catch (Exception) { throw; }
            }

            internal void Run()
            {
                while (true) try
                {
                    var stream = tcpClient.GetStream();
                    Mail mail = (Mail)new BinaryFormatter().Deserialize(stream);

                    if (!server.userList.Contains(mail.Username))
                    {
                        server.userList.Add(mail.Username);
                        server.form.PrintLog(mail.Username + " join the chat");
                    }
                    server.Broadcast(mail);

                    #region echo
                    //message = message.ToUpper();
                    //byte[] echomsg = Encoding.UTF8.GetBytes(message);
                    //networkStream.Write(echomsg, 0, echomsg.Length);
                    //Console.WriteLine($"Echo: {message}");
                    #endregion
                }
                catch (Exception) { throw; }
            }
        }
    }
}
