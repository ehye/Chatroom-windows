using System;
using System.Windows.Forms;

namespace VerySimpleChatServer
{
    public partial class ServerForm : Form
    {
        private bool isConnect = false;
        private VerySimpleChatServer server;

        public ServerForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            Text = "Server on " + Environment.MachineName + " " + Environment.OSVersion.ToString();
        }

        internal void PrintLog(string log)
        {
            Rtxt_Log.Text += log + Environment.NewLine;
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
                server = new VerySimpleChatServer("127.0.0.1", "6017", this);
                server.Start();
                Btn_Start.Text = "Stop";
            }
            isConnect = !isConnect;
        }
    }
}
