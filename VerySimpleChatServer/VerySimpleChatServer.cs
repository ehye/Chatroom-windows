using ComLib;
using System;
using System.Data;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace VerySimpleChatServer
{
    class VerySimpleChatServer
    {
        private TcpListener tcpListener;
        private Dictionary<NetworkStream, String> clients;
        private ServerForm form;

        public VerySimpleChatServer(string host, string port, ServerForm serverForm)
        {
            form = serverForm;
            var ipe = new IPEndPoint(IPAddress.Parse(host), Int16.Parse(port));
            tcpListener = new TcpListener(ipe);
            clients = new Dictionary<NetworkStream, String>();
        }

        internal void Start()
        {
            tcpListener.Start();
            form.PrintLog("server start");

            new Thread(() =>
            {
                while (true) try
                {
                    var tcpClient = tcpListener.AcceptTcpClient();
                    var stream = tcpClient.GetStream();
                    var clientHandler = new ClientHandler(tcpClient, this);
                    var tHandler = new Thread(new ThreadStart(clientHandler.Run)) { Name = "Handler" };
                    tHandler.Start();
                    //form.PrintLog($"got a connection form {tcpClient.Client.RemoteEndPoint.ToString()} \n");
                }
                catch (SocketException)
                {
                    break;
                }
                catch (Exception) { throw; }
            }).Start();
        }

        internal void Stop()
        {
            byte[] buffer = Encoding.UTF8.GetBytes("stop");
            //tcpListener.Server.Send(buffer);
            tcpListener.Stop();
            form.PrintLog("server stop");
        }

        internal void Broadcast(Mail mail)
        {
            var j = clients.GetEnumerator();
            while (j.MoveNext()) try
            {
                new BinaryFormatter().Serialize(j.Current.Key, mail);
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

            private void SendCurrentUserList()
            {

                foreach (var stream in server.clients.Keys)
                {
                    var sb = new StringBuilder("userlist");
                    foreach (var item in server.clients.Values)
                        sb.AppendFormat(",{0}", item);
                    Mail mail = new Mail(DateTime.Now.ToString(), "server", sb.ToString());
                    new BinaryFormatter().Serialize(stream, mail);
                }
            }

            internal void Run()
            {
                while (true) try
                {
                    Mail mail = null;
                    if (networkStream.CanWrite)
                    {
                        mail = (Mail)new BinaryFormatter().Deserialize(networkStream);

                        // disconnect
                        if (server.clients.ContainsValue(mail.Username) && mail.Msg.StartsWith("Stop"))
                        {
                            string[] s = mail.Msg.Split(',');
                            var item = server.clients.First(kvp => kvp.Value == s[1]);
                            item.Key.Close();
                            server.clients.Remove(item.Key);
                            SendCurrentUserList();
                        }
                    
                        // new user
                        if (!server.clients.ContainsValue(mail.Username) && mail.Msg.Equals("Hello"))
                        {
                            server.clients.Add(networkStream, (mail.Username));
                            server.form.PrintLog($"{tcpClient.Client.RemoteEndPoint}  {mail.Username}  join the chat");
                            SendCurrentUserList();
                            //continue;
                        }

                        else
                        {
                            server.Broadcast(mail);
                        }
                    }
                }
                catch (ArgumentException) { break; }
                catch (Exception) { throw; }
            }
        }
    }
}
