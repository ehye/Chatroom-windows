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

namespace Server
{
    public partial class ServerMain : Form
    {
        volatile bool isListening = false;
        volatile bool isRecevieDone = false;
        TcpListener listener;
        IPEndPoint ipe = new IPEndPoint(
            ComLib.ConnectionData.ServerIP, ComLib.ConnectionData.ServerPort);

        public ServerMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void ServerMain_Load(object sender, EventArgs e)
        {
            this.Text = "Server on " + Environment.MachineName + " " + Environment.OSVersion.ToString();
        }

        private async void Listen()
        {
            listener = new TcpListener(ipe);
            listener.Start();
            Console.WriteLine("Waiting for a connection...");

            while (true)
            {
                Console.WriteLine("While receive...");
                Byte[] bytes = new byte[1024];
                String data = null;
                var handler = await listener.AcceptTcpClientAsync();
                NetworkStream stream = handler.GetStream();

                // Loop to receive all the data sent by the client.
                int i;
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = Encoding.UTF8.GetString(bytes, 0, i);
                    Console.WriteLine("Text received : {0}", data);
                    Rtxt_chat.AppendText(Environment.NewLine + "USER" + " " + DateTime.Now, Color.Blue);
                    Rtxt_chat.AppendText(Environment.NewLine + data + Environment.NewLine, Color.Black);

                    // Send back a response.
                    byte[] msg = Encoding.UTF8.GetBytes(data);
                    data = data.ToUpper();
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Echo: {0}", data);
                }
                handler.Close();
            }
        }

        private void Btn_start_Click(object sender, EventArgs e)
        {
            isListening = !isListening;
            if (isListening)
            {
                Btn_start.Text = "Stop";

                // TODO: client object

                Thread tListen = new Thread(Listen);
                tListen.Start();
            }
            else
            {
                Btn_start.Text = "Start";
            }
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
