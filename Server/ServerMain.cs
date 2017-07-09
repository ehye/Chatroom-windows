using ComLib;
using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Server
{
    public partial class ServerMain : Form
    {
        volatile bool isListening = false;
        //volatile bool isRecevieDone = false;
        TcpListener listener;
        ChatClient chatClient;
        IPEndPoint ipe = ConnectionData.Ipe;

        public ServerMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void ServerMain_Load(object sender, EventArgs e)
        {
            this.Text = "Server on " + Environment.MachineName + " " + Environment.OSVersion.ToString();
        }

        private void Listen()
        {
            listener = new TcpListener(ipe);
            listener.Start();
            Console.WriteLine("Waiting for a connection...");

            while (true)
            {
                var bytes = new byte[1024];
                var data = String.Empty;
                var handler = listener.AcceptTcpClient();
                var stream = handler.GetStream();

                IFormatter formatter = new BinaryFormatter();
                chatClient = (ChatClient)formatter.Deserialize(stream);
                dgv_info.Rows.Add("id", chatClient.Username, chatClient.Ip);
                listBox_user.Items.Add(chatClient.Username);
                stream.Flush();

                // Loop to receive all the data sent by the client.
                for (int i; (i = stream.Read(bytes, 0, bytes.Length)) != 0;)
                {
                    data = Encoding.UTF8.GetString(bytes, 0, i);
                    ShowMessage(chatClient.Username, data);
                    Console.WriteLine("Text received : {0}", data);

                    #region Send back a response
                    //data = data.ToUpper();
                    //byte[] msg = Encoding.UTF8.GetBytes(data);
                    //stream.Write(msg, 0, msg.Length);
                    //Console.WriteLine("Echo: {0}", data);
                    #endregion
                }
                handler.Close();
            }
        }

        private void ShowMessage(string username, string message)
        {
            Rtxt_chat.AppendText(Environment.NewLine + username + " " + DateTime.Now, Color.Blue);
            Rtxt_chat.AppendText(Environment.NewLine + message + Environment.NewLine);
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

        private void connectToServerCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Btn_start.PerformClick();
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
