using ComLib;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
        private ClientForm clientForm;

        public SimpleChatClient(string host, string port, ClientForm clientForm)
        {
            this.host = IPAddress.Parse(host);
            this.port = Int16.Parse(port);
            ipe = new IPEndPoint(this.host, this.port);
            this.clientForm = clientForm;
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
                tcpClient.Close();
            }
            catch (Exception) { throw; }
        }

        internal void Send(string message)
        {
            Mail mail = new Mail(DateTime.Now.ToString(), clientForm.GetUsername, message);
            try
            {
                byte[] buffer = new byte[message.Length];
                buffer = Encoding.UTF8.GetBytes(message);
                tcpClient.Client.Send(buffer);
            }
            catch (Exception) { throw; }
        }

        class MessageReader
        {
            SimpleChatClient simpleChatClient;
            NetworkStream streamReader;

            public MessageReader(SimpleChatClient simpleChatClient)
            {
                this.simpleChatClient = simpleChatClient;
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
                    byte[] buffer = new byte[1024];
                    string message = String.Empty;
                    int count = streamReader.Read(buffer, 0, buffer.Length);
                    while (count != 0)
                    {
                        if (message.StartsWith("user"))
                        {
                            message = Encoding.UTF8.GetString(buffer, 0, count);
                            string user = message.Substring(4);

                            //clientForm.getList_Clients().setModel(dlm);
                            //Console.WriteLine(user);
                        }
                        else
                        {
                            message = Encoding.UTF8.GetString(buffer, 0, count);
                            simpleChatClient.clientForm.ShowMessage(message);
                            //Console.WriteLine(message);
                        }
                        count = 0;
                        streamReader.Flush();
                    }
                }
                catch (IOException) { return; }
                catch (Exception) { throw; }
            }
        }

    }
}
