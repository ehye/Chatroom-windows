﻿using ComLib;
using System;
using System.Windows.Forms;

namespace ChatServer
{
    public partial class ServerForm : Form
    {
        private bool isConnect = false;
        private ChatServer server;

        public ServerForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            Text = "Server on " + Environment.MachineName + " " + Environment.OSVersion.ToString();

            Combo_IP.Items.Add("127.0.0.1");
            Combo_IP.Items.AddRange(Lib.GetLocalIPAddresses());
            Combo_IP.SelectedIndex = 0;
        }

        internal void PrintLog(string log)
        {
            Rtxt_Log.Text += DateTime.Now + " " + log + Environment.NewLine;
        }

        internal void AddToDGV(string id, string name, string ipe)
        {
            Dgv_Info.Rows.Add(id, name, ipe);
        }

        internal void RemoveFormDGV()
        {

        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {

            if (isConnect)
            {
                server.Stop();
                Btn_Start.Text = "Star";
            }
            else
            {
                server = new ChatServer(Combo_IP.Text, Txt_port.Text, this);
                server.Start();
                Btn_Start.Text = "Stop";
            }
            isConnect = !isConnect;
        }

        private void Btn_GetPubIP_Click(object sender, EventArgs e)
        {
            Combo_IP.Text = Lib.GetPubIp();
        }
    }
}
