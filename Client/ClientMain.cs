using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientMain : Form
    {
        bool isRunning = false;
        TcpClient client;
        IPEndPoint ipe = new IPEndPoint(
            ComLib.ConnectionData.ServerIP, ComLib.ConnectionData.ServerPort);

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
            try
            {
                client = new TcpClient();
                client.Connect(ipe);
                Console.WriteLine("Socket connected to {0}", ipe.ToString());
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
                var bytes = new byte[1024];
                var data = String.Empty;
                var stream = client.GetStream();
                int i;
                while ((i = stream.Read(bytes, 0, bytes.Length))!= 0)
                {
                    data = Encoding.UTF8.GetString(bytes, 0, i);
                    Console.WriteLine("Echoed text = {0}", data);

                    Rtxt_chat.AppendText(Environment.NewLine + Txt_username.Text + " " + DateTime.Now, Color.Blue);
                    Rtxt_chat.AppendText(Environment.NewLine + data + Environment.NewLine, Color.Black);
                }
            }
        }

        private void Send()
        {
            var msg = Encoding.UTF8.GetBytes(Txt_send.Text);
            if (client.Connected)
            {
                client.Client.Send(msg);
            }
        }

        private void Btn_connect_Click(object sender, EventArgs e)
        {
            isRunning = !isRunning;
            if (isRunning)
            {
                Btn_connect.Text = "Disconnect";
                Connect();
                var tReceive = new Thread(Receive);
                tReceive.Start();
            }
            else
            {
                Btn_connect.Text = "Connect";
                // Close everything.
                client.Close();
            }
            Txt_username.Enabled = !Txt_username.Enabled;
            Txt_password.Enabled = !Txt_password.Enabled;
            Btn_send.Enabled = !Btn_send.Enabled;
        }

        private void Btn_send_Click(object sender, EventArgs e)
        {
            Rtxt_chat.AppendText(Environment.NewLine + Txt_username.Text + " " + DateTime.Now, Color.Blue);
            Rtxt_chat.AppendText(Environment.NewLine + Txt_send.Text + Environment.NewLine, Color.Black);

            Send();
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
