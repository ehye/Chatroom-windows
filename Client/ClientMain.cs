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
        Socket client = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ipe =  new IPEndPoint(
            ComLib.ConnectionData.ServerIP, ComLib.ConnectionData.ServerPort);

        public ClientMain()
        {
            InitializeComponent();
        }

        private void ClientMain_Load(object sender, EventArgs e)
        {
            this.Text = Environment.MachineName + " Chat on " + Environment.OSVersion.ToString();
        }

        private void Btn_connect_Click(object sender, EventArgs e)
        {
            isRunning = !isRunning;
            if (isRunning)  Btn_connect.Text = "Disconnect";
            else            Btn_connect.Text = "Connect";
            Txt_username.Enabled = !Txt_username.Enabled;
            Txt_password.Enabled = !Txt_password.Enabled;
            Btn_send.Enabled = !Btn_send.Enabled;

            Connect();

        }

        private void Connect()
        {
            try
            {
                client.Connect(ipe);
                Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void Btn_send_Click(object sender, EventArgs e)
        {
            Rtxt_chat.AppendText(Environment.NewLine + Txt_username.Text + " " + DateTime.Now, Color.Blue);
            Rtxt_chat.AppendText(Environment.NewLine + Txt_send.Text + Environment.NewLine, Color.Black);

            Send();
            Rtxt_chat.Select(Rtxt_chat.TextLength, 0);
            Rtxt_chat.ScrollToCaret();
            Txt_send.Clear();
            Txt_send.Focus();
        }

        private void Send()
        {
            //client.Connect(ipe);

            Byte[] msg = Encoding.UTF8.GetBytes("This is a test");
            client.Send(msg);

            //client.Shutdown(SocketShutdown.Both);
            //client.Close();
        }

        private void Receive()
        {
            byte[] bytes = new byte[1024];
            int bytesRec = client.Receive(bytes);
            Console.WriteLine("Echoed text = {0}",
                System.Text.Encoding.UTF8.GetString(bytes, 0, bytesRec));
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
