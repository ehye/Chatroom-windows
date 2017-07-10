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

namespace Server
{
    public partial class ServerMain : Form
    {
        volatile bool isStarting = false;
        volatile bool isStop = false;
        static int USERCOUNT = 10;
        TcpListener listener;
        ChatClient[] chatClients;
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
            //TcpClient handler = null;
            IFormatter formatter = new BinaryFormatter();
            listener = new TcpListener(ipe);
            listener.Start();
            Console.WriteLine("Waiting for a connection...");

            while (true)
            {
                try
                {
                    // Deserilaize the client objet form stream.
                    var data        = String.Empty;
                    var bytes       = new byte[1024];
                    var handler     = listener.AcceptTcpClient();
                    var stream      = handler.GetStream();
                    var chatClient  = (ChatClient)formatter.Deserialize(stream);
                    stream.Flush();

                    chatClients.SetValue(chatClient, --USERCOUNT);
                    dgv_info.Rows.Add("id", chatClient.Username, chatClient.Ip);

                    // Loop to receive all the data sent by the client.
                    for (int i; (i = stream.Read(bytes, 0, bytes.Length)) != 0;)
                    {
                        if (isStop) break;

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
                }
                catch (SocketException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //if (handler != null)
                    //{
                    //    handler.Close();
                    //    Console.WriteLine("close handler");
                    //}
                }
            }
        }

        private void ShowMessage(string username, string message)
        {
            Rtxt_chat.AppendText(Environment.NewLine + username + " " + DateTime.Now, Color.Blue);
            Rtxt_chat.AppendText(Environment.NewLine + message + Environment.NewLine);
        }

        private void Btn_start_Click(object sender, EventArgs e)
        {
            isStarting = !isStarting;
            if (isStarting)
            {
                Btn_start.Text = "Stop";

                // TODO: client object
                chatClients = new ChatClient[10];

                Thread tListen = new Thread(Listen);
                tListen.Start();
            }
            else
            {
                Btn_start.Text = "Start";
                isStop = true;
                listener.Stop();
                chatClients = null;
                dgv_info.Rows.Clear();
            }
        }

        private void Rtxt_chat_TextChanged(object sender, EventArgs e)
        {
            Rtxt_chat.Select(Rtxt_chat.TextLength, 0);
            Rtxt_chat.ScrollToCaret();
        }

        private void ConnectToServer_Click(object sender, EventArgs e)
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
