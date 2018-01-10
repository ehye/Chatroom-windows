using ComLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

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
            this.host = IPAddress.Parse(host);
            this.port = Int16.Parse(port);
            ipe = new IPEndPoint(this.host, this.port);
            this.form = clientForm;
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
            tReader.Interrupt();
            tcpClient.Close();
            try
            {
                //Thread.Sleep(2000);
                tcpClient.Close();
            }
            catch (Exception) { throw; }
        }

        internal void Send(string message)
        {
            Mail mail = new Mail(DateTime.Now.ToString(), form.GetUsername, message);
            try
            {
                new BinaryFormatter().Serialize(tcpClient.GetStream(), mail);

                //byte[] buffer = new byte[message.Length];
                //buffer = Encoding.UTF8.GetBytes(message);
                //tcpClient.Client.Send(buffer);
            }
            catch (Exception) { throw; }
        }

        class MessageReader
        {
            SimpleChatClient client;
            NetworkStream streamReader;

            public MessageReader(SimpleChatClient simpleChatClient)
            {
                this.client = simpleChatClient;
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
                        string[] users = mail.Msg.Split(',');
                        if (users.Length > 1)
                        {
                            for (int i = 1; i < users.Length; i++)
                            {
                                client.userList.Add(users[i]);
                            }
                        }
                    }

                    else if (!client.userList.Contains(mail.Username) && mail.Msg.Equals("Hello"))
                        client.userList.Add(mail.Username);
                    else if (client.userList.Contains(mail.Username) && mail.Msg.Equals("Bye"))
                        client.userList.Remove(mail.Username);
                    else
                        client.form.ShowMessage(mail.Stamp, mail.Username, mail.Msg);

                    client.form.GetUserList.Items.Clear();
                    foreach (var item in client.userList)
                        client.form.GetUserList.Items.Add(item);

                    streamReader.Flush();
                }
                catch (IOException) { return; }
                catch (Exception) { throw; }
            }
        }

    }
}
