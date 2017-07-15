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
        //static int USERCOUNT = 10;
        volatile bool isStop = false;
        volatile bool isStarting = false;
        TcpListener listener;
        List<TcpClient> socketsList;
        List<ChatClient> clientsList;
        List<MsgPackage> messageList;
        IPEndPoint ipe = ServerConf.Ipe;
        Dictionary<long, string> kvp_message;

        public ServerMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void ServerMain_Load(object sender, EventArgs e)
        {
            this.Text = "Server on " + Environment.MachineName + " " + Environment.OSVersion.ToString();

            kvp_message = new Dictionary<long, string>();
            clientsList = new List<ChatClient>();
            socketsList = new List<TcpClient>();
            messageList = new List<MsgPackage>();
            listener = new TcpListener(ipe);
        }

        private void RevInfo()
        {
            while (true)
            {
                try
                {
                    // Deserilaize the client objet form stream.
                    var formatter = new BinaryFormatter();
                    var handler = listener.AcceptTcpClient();
                    var stream = handler.GetStream();
                    ChatClient client = (ChatClient)formatter.Deserialize(stream);
                    clientsList.Add(client);
                    socketsList.Add(handler);
                    stream.Flush();

                    dgv_info.Rows.Add("id", client.Username, client.Ip);
                }
                catch (SocketException)
                {
                    break;
                }
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

                for (int i = 0; i < socketsList.Count; i++)
                {
                    try
                    {
                        var bytes = new byte[1024];
                        var stream = socketsList[i].GetStream();
                        stream.ReadTimeout = 10;
                        var count = stream.Read(bytes, 0, bytes.Length);
                        var user = clientsList.Find(p => p.Ip == socketsList[i].Client.RemoteEndPoint.ToString());
                        var data = Encoding.UTF8.GetString(bytes, 0, count);
                        string[] s = data.Split(new string[] { ChatClient.SPLIT }, StringSplitOptions.RemoveEmptyEntries);
                        MsgPackage ms = new MsgPackage(Int64.Parse(s[1]), user.Username, s[0], user.Ip);
                        messageList.Add(ms);
                    }
                    catch (System.IO.IOException)
                    {
                        continue;
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    #region Send back a response
                    //data = data.ToUpper();
                    //byte[] msg = Encoding.UTF8.GetBytes(data);
                    //stream.Write(msg, 0, msg.Length);
                    //Console.WriteLine("Echo: {0}", data);
                    #endregion
                }
                if (isStop) break;

                //Boardcast();
                ShowMessage();
            }
        }

        private void Boardcast()
        {
            while (true)
            {
                for (int j = 0; j < messageList.Count; j++)
                {
                    for (int i = 0; i < socketsList.Count; i++)
                    {
                        var bytes = Encoding.UTF8.GetBytes(messageList[i].msg);
                        if (bytes.Length != 0)
                            socketsList[i].Client.Send(bytes);
                    }
                    //byte[] msg = Encoding.UTF8.GetBytes(data);
                    //client.Client.Send(msg);
                }
            }
        }

        private void ShowMessage()
        {
            // sort use Linq
            //var sortedList = from ticks in packageList
            //                 orderby ticks ascending
            //                 select ticks;

            // sort use interface
            messageList.Sort(new TicksAscOrder());

            foreach (var item in messageList)
            {
                // show to server
                Rtxt_chat.AppendText(Environment.NewLine + item.username + "> ", Color.Blue);
                Rtxt_chat.AppendText(item.msg);

                // boardcast
                var BCgroup = from client in clientsList
                              where client.Username != item.username
                              select client;

                foreach (var socket in socketsList)
                {
                    if (item.ip != socket.Client.RemoteEndPoint.ToString())
                    {
                        Byte[] bytes = Encoding.UTF8.GetBytes(item.username + ChatClient.SPLIT + item.msg);
                        socket.Client.Send(bytes);
                    }
                }
            }

            messageList.Clear();
        }

        private void Btn_start_Click(object sender, EventArgs e)
        {
            isStarting = !isStarting;
            if (isStarting)
            {
                listener.Start();
                Console.WriteLine("Waiting for a connection...");

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

                var tBC = new Thread(Boardcast)
                {
                    Name = "Boardcast"
                };
                //tBC.Start();

                Btn_start.Text = "Stop";
            }
            else
            {
                isStop = true;
                listener.Stop();
                clientsList.Clear();
                dgv_info.Rows.Clear();
                Btn_start.Text = "Start";
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
        public string ip;

        //public long ticks { get => ticks; private set => ticks = value; }
        //public string username { get => username; private set => username = value; }
        //public string msg { get => msg; private set => msg = value; }

        public MsgPackage(long ticks, string username, string msg, string ip)
        {
            this.ticks = ticks;
            this.username = username;
            this.msg = msg;
            this.ip = ip;
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