using ComLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace ChatClient
{
    class ChatClient
    {
        protected TcpClient tcpClient;
        private IPAddress host;
        private int port;
        private IPEndPoint ipe;
        private Thread tReader;
        private ClientForm form;
        private List<string> userList;

        public ChatClient(string host, string port, ClientForm clientForm)
        {
            form = clientForm;
            this.host = IPAddress.Parse(host);
            this.port = Int16.Parse(port);
            ipe = new IPEndPoint(this.host, this.port);
            userList = new List<string>();
        }

        private bool SetUpNetworking()
        {
            bool isPass = false;
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(ipe);
                Console.WriteLine($"networking established to {host}:{port}");
                isPass = true;
            }
            catch (SocketException ex) { form.ConnectError(ex.Message); }
            catch (Exception) { throw; }
            return isPass;
        }

        internal bool Start()
        {
            if (SetUpNetworking())
            {
                MessageReader messageReader = new MessageReader(this);
                tReader = new Thread(new ThreadStart(messageReader.Run)) { Name = "Read" };
                tReader.Start();
                Send("Hello");
                return true;
            }
            return false;
        }

        internal void Stop()
        {
            Send($"Bye,{form.GetUsername}");
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
            Mail mail = new Mail(form.GetUsername, message);
            if (tcpClient.Connected) try
            {
                new BinaryFormatter().Serialize(tcpClient.GetStream(), mail);
            }
            catch (Exception) { throw; }
        }

        class MessageReader
        {
            ChatClient client;
            NetworkStream streamReader;

            public MessageReader(ChatClient simpleChatClient)
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
                bool isRunning = true;
                while (isRunning) try
                {
                    Mail mail = (Mail)new BinaryFormatter().Deserialize(streamReader);

                    // server stop
                    if (mail.Username.Equals("server") && mail.Msg.StartsWith("stop"))
                    {
                        client.userList.Clear();
                        client.form.ServerStop();
                        client.tcpClient.Close();
                        isRunning = false;
                    }
                    // new user
                    else if (mail.Username.Equals("server") && mail.Msg.StartsWith("userlist"))
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
