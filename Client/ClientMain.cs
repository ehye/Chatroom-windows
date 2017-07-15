using ComLib;
using System;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientMain : Form
    {
        volatile bool isRunning = false;
        volatile bool isStop = false;
        TcpClient client;
        //IPEndPoint ipe = ConnectionData.Ipe;
        IPEndPoint ipe;


        public ClientMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void ClientMain_Load(object sender, EventArgs e)
        {
            this.Text = Environment.MachineName + " Chat on " + Environment.OSVersion.ToString();
        }

        private void Connect()
        {
            ipe = new IPEndPoint(IPAddress.Parse(Txt_host.Text), Int16.Parse(Txt_port.Text));
            client = new TcpClient();

            try
            {
                client.Connect(this.ipe);
                var stream = client.GetStream();
                var innerip = client.Client.LocalEndPoint.ToString();
                string[] s = client.Client.LocalEndPoint.ToString().Split(new Char[] { ':' });
                var port = s[1];
                var publicEndPoint = Lib.GetPubIp() + ":" + port;
                var chatClient = new ChatClient(Txt_username.Text, Txt_password.Text, publicEndPoint, true);
                new BinaryFormatter().Serialize(stream, chatClient);

                statusLabel_conInfo.Text = "Connected to" + ipe.ToString();
                //Console.WriteLine("Socket connected to {0}", client.Client.RemoteEndPoint.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void Receive()
        {
            while (true)
            {
                if (client == null) break;

                var bytes = new byte[1024];
                var data = String.Empty;
                var stream = client.GetStream();
                for (int i; (i = stream.Read(bytes, 0, bytes.Length)) != 0;)
                {
                    if (isStop) break;

                    data = Encoding.UTF8.GetString(bytes, 0, i);
                    ShowMessage(data);
                    //Console.WriteLine("Echoed text = {0}", data);
                }
            }
        }

        private void Send()
        {
            var msg = Encoding.UTF8.GetBytes(Txt_send.Text + ChatClient.SPLIT + DateTime.Now.Ticks);
            if (client.Connected)
            {
                client.Client.Send(msg);
                //MessageBox.Show(client.Client.RemoteEndPoint.ToString());
            }
            ShowMessage(Txt_send.Text);
        }

        private void ShowMessage(string data)
        {
            string[] msg = data.Split(new string[] { ChatClient.SPLIT }, StringSplitOptions.RemoveEmptyEntries);
            if (msg.Length == 1)
            {
                Rtxt_chat.AppendText(Environment.NewLine + Txt_username.Text + " " + DateTime.Now, Color.Blue);
                Rtxt_chat.AppendText(Environment.NewLine + Txt_send.Text + Environment.NewLine, Color.Black);
            }
            else
            {
                Rtxt_chat.AppendText(Environment.NewLine + msg[0] + " " + DateTime.Now, Color.Blue);
                Rtxt_chat.AppendText(Environment.NewLine + msg[1] + Environment.NewLine, Color.Black);
            }
        }

        private void Btn_connect_Click(object sender, EventArgs e)
        {
            isRunning = !isRunning;
            if (isRunning)
            {
                Connect();
                var tRev = new Thread(Receive)
                {
                    Name = "Receive"
                };
                tRev.Start();

                Btn_connect.Text = "Disconnect";
            }
            else
            {
                isStop = true;
                client.Close();
                Btn_connect.Text = "Connect";
            }

            Txt_username.Enabled = !Txt_username.Enabled;
            Txt_password.Enabled = !Txt_password.Enabled;
            Txt_host.ReadOnly = !Txt_host.ReadOnly;
            Txt_port.ReadOnly = !Txt_port.ReadOnly;
            Btn_send.Enabled = !Btn_send.Enabled;
        }

        private void Btn_send_Click(object sender, EventArgs e)
        {
            if (!Txt_send.Text.Equals(String.Empty))
            {
                Send();
            }

            Txt_send.Clear();
            Txt_send.Focus();
        }

        private void Rtxt_chat_TextChanged(object sender, EventArgs e)
        {
            Rtxt_chat.Select(Rtxt_chat.TextLength, 0);
            Rtxt_chat.ScrollToCaret();
        }
    }

    public static class RichTextBoxExtensions
    {
        // Color different parts of a RichTextBox
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}