using System;
using System.Windows.Forms;

namespace VerySimpleChatServer
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            this.Text = "Server on " + Environment.MachineName + " " + Environment.OSVersion.ToString();

        }

        internal void PrintLog(string log)
        {
            Rtxt_Log.Text += log + Environment.NewLine;
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            VerySimpleChatServer verySimpleChatServer = new VerySimpleChatServer("127.0.0.1", "6017", this);
            verySimpleChatServer.Start();
        }
    }
}
