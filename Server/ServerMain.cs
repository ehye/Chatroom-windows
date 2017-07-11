using ComLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        TcpListener listener;
        List<ChatClient> chatClients;
        List<TcpClient> tcpClients;
        //static int USERCOUNT = 10;
        volatile bool isStop = false;
        volatile bool isStarting = false;
        IPEndPoint ipe = ConnectionData.Ipe;
        Dictionary<long, string> kvp_message;


        List<MsgPackage> packageList = new List<MsgPackage>();

        public ServerMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void ServerMain_Load(object sender, EventArgs e)
        {
            this.Text = "Server on " + Environment.MachineName + " " + Environment.OSVersion.ToString();
        }

        private void RevInfo()
        {
            while (true)
            {
                // Deserilaize the client objet form stream.
                var formatter   = new BinaryFormatter();
                var handler     = listener.AcceptTcpClient();
                var stream      = handler.GetStream();
                var chatClient  = (ChatClient)formatter.Deserialize(stream);

                chatClients.Add(chatClient);
                tcpClients.Add(handler);
                stream.Flush();

                dgv_info.Rows.Add("id", chatClient.Username, chatClient.Ip);
            }
        }

        private void Listen()
        {
            while (true)
            {
                /*
                 * ToArray() is thread-safe
                 * but O(n) storage require
                 */
                //foreach (var client in tcpClients.ToArray())
                for (int i = 0; i < tcpClients.Count; i++)
                {
                    if (isStop) break;

                    //var stream  = client.GetStream();
                    var stream  = tcpClients[i].GetStream();
                    var bytes   = new byte[1024];
                    var count   = stream.Read(bytes, 0, bytes.Length);
                    var user    = chatClients.Find(p => p.Ip == tcpClients[i].Client.RemoteEndPoint.ToString());
                    var data    = Encoding.UTF8.GetString(bytes, 0, count);
                    string[] s  = data.Split(new Char[] { '\t' });
                    //kvp_message.Add(Int64.Parse(s[1]), s[0]);

                    MsgPackage ms = new MsgPackage(Int64.Parse(s[1]), user.Username, s[0]);
                    packageList.Add(ms);


                    #region Send back a response
                    //data = data.ToUpper();
                    //byte[] msg = Encoding.UTF8.GetBytes(data);
                    //stream.Write(msg, 0, msg.Length);
                    //Console.WriteLine("Echo: {0}", data);
                    #endregion
                }
                ShowMessage();
            }
        }

        private void ShowMessage()
        {
            // sort use Linq
            //var sortedList = from ticks in packageList
            //                 orderby ticks ascending
            //                 select ticks;
            // sort use interface
            packageList.Sort(new TicksAscOrder());

            //Rtxt_chat.AppendText(Environment.NewLine + username + " " + DateTime.Now.ToShortDateString()
            //    + " " + DateTime.FromBinary(Int64.Parse(s[1])).ToLongTimeString(), Color.Blue);
            //Rtxt_chat.AppendText(Environment.NewLine + s[0] + Environment.NewLine);

            foreach (var item in packageList)
            {

                Rtxt_chat.AppendText(Environment.NewLine + item.username +" " + DateTime.Now.ToShortDateString()
                    + " " + DateTime.FromBinary(item.ticks).ToLongTimeString(), Color.Blue);
                Rtxt_chat.AppendText(Environment.NewLine + item.msg + Environment.NewLine);
            }

            packageList.Clear();
        }

        private void Btn_start_Click(object sender, EventArgs e)
        {
            isStarting = !isStarting;
            if (isStarting)
            {
                Btn_start.Text = "Stop";
                kvp_message = new Dictionary<long, string>();
                chatClients = new List<ChatClient>();
                tcpClients = new List<TcpClient>();
                listener = new TcpListener(ipe);
                listener.Start();
                //Console.WriteLine("Waiting for a connection...");

                var tRev = new Thread(RevInfo)
                {
                    Name = "RevInfo"
                };
                tRev.Start();

                var tListen = new Thread(Listen)
                {
                    Name = "Listen"
                };
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

    public struct MsgPackage
    {
        public long ticks;
        public string username;
        public string msg;

        public MsgPackage(long ticks, string username, string msg)
        {
            this.ticks = ticks;
            this.username = username;
            this.msg = msg;
        }
    }

    public class TicksAscOrder : IComparer<MsgPackage>
    {
        public int Compare(MsgPackage x, MsgPackage y)
        {
            return x.ticks.CompareTo(y.ticks);
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