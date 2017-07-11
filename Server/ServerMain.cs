﻿using ComLib;
using System;
using System.Collections.Generic;
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
        TcpListener listener;
        List<ChatClient> chatClients;
        List<TcpClient> tcpClients;
        //static int USERCOUNT = 10;
        volatile bool isStop = false;
        volatile bool isStarting = false;
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

        private void RevInfo()
        {
            while (true)
            {
                // Deserilaize the client objet form stream.
                var formatter   =   new BinaryFormatter();
                var handler     =   listener.AcceptTcpClient();
                var stream      =   handler.GetStream();
                var chatClient  =   (ChatClient)formatter.Deserialize(stream);

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
                foreach (var client in tcpClients.ToArray())
                {
                    if (isStop) break;

                    var stream  =   client.GetStream();
                    var bytes   =   new byte[1024];
                    var count   =   stream.Read(bytes, 0, bytes.Length);
                    var user    =   chatClients.Find(p => p.Ip == client.Client.RemoteEndPoint.ToString());
                    var data    =   Encoding.UTF8.GetString(bytes, 0, count);

                    ShowMessage(user.Username, data);

                    #region Send back a response
                    //data = data.ToUpper();
                    //byte[] msg = Encoding.UTF8.GetBytes(data);
                    //stream.Write(msg, 0, msg.Length);
                    //Console.WriteLine("Echo: {0}", data);
                    #endregion
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
                chatClients = new List<ChatClient>();
                tcpClients  = new List<TcpClient>();
                listener    = new TcpListener(ipe);
                listener.Start();
                //Console.WriteLine("Waiting for a connection...");

                var tRev = new Thread(RevInfo);
                tRev.Name = "RevInfo";
                tRev.Start();

                var tListen = new Thread(Listen);
                tListen.Name = "Listen";
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
