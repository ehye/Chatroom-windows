using ComLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace SimpleChatClient
{
    class SimpleChatClient
    {
        protected TcpClient tcpClient;
        private IPAddress host;
        private int port;
        private IPEndPoint ipe;
        private Thread tReader;
        private ClientForm form;
        private List<string> userList;

        public SimpleChatClient(string host, string port, ClientForm clientForm)
        {
            form = clientForm;
            this.host = IPAddress.Parse(host);
            this.port = Int16.Parse(port);
            ipe = new IPEndPoint(this.host, this.port);
            userList = new List<string>();
        }

        private void SetUpNetworking()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(ipe);
                Console.WriteLine($"networking established to {host}:{port}");
            }
            catch (Exception) { throw; }
        }

        internal void Start()
        {
            SetUpNetworking();
            MessageReader messageReader = new MessageReader(this);
            tReader = new Thread(new ThreadStart(messageReader.Run)) { Name = "Read" };
            tReader.Start();
        }

        internal void Stop()
        {
            Send($"Stop,{form.GetUsername}");
            tReader.Interrupt();
            tReader.Abort();
            try
            {
                tcpClient.Close();
            }
            catch (Exception) { throw; }
            form.GetUserList.Clear();
        }

        internal void Send(string message)
        {
            Mail mail = new Mail(DateTime.Now.ToString(), form.GetUsername, message);
            if (tcpClient.Connected) try
            {
                new BinaryFormatter().Serialize(tcpClient.GetStream(), mail);
            }
            catch (Exception) { throw; }
        }

        class MessageReader
        {
            SimpleChatClient client;
            NetworkStream streamReader;

            public MessageReader(SimpleChatClient simpleChatClient)
            {
                client = simpleChatClient;
                try
                {
                    streamReader = simpleChatClient.tcpClient.GetStream();
                }
                catch (Exception) { throw; }
            }

            internal void Run()
            {
                while (true) try
                {
                    Mail mail = (Mail)new BinaryFormatter().Deserialize(streamReader);

                    if (mail.Username.Equals("server") && mail.Msg.StartsWith("userlist"))
                    {
                        client.userList.Clear();
                        client.form.GetUserList.Items.Clear();

                        string[] users = mail.Msg.Split(',');
                        for (int i = 1; i < users.Length; i++)
                            client.userList.Add(users[i]);

                        foreach (var item in client.userList)
                            client.form.GetUserList.Items.Add(item);
                    }
                    else
                        client.form.ShowMessage(mail.Stamp, mail.Username, mail.Msg);

                    streamReader.Flush();
                }
                catch (IOException) { return; }
                catch (Exception) { throw; }
            }
        }

    }
}
