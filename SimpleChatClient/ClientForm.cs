using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class ClientForm : Form
    {
        private bool isConnect = false;
        private ChatClient client;

        internal string GetUsername { get => Txt_Username.Text; }
        internal ListView GetUserList { get => List_User; }

        public ClientForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            Text = Environment.MachineName + " Chat on " + Environment.OSVersion.ToString();
            client = new ChatClient(Txt_Host.Text, Txt_Port.Text, this);
        }

        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            if (isConnect)
            {
                client.Stop();
                Btn_Connect.Text = "Connect";
                Btn_Send.Enabled = false;
                isConnect = !isConnect;
            }
            else if (client.Start())
            {
                Btn_Connect.Text = "Disconnect";
                Btn_Send.Enabled = true;
                isConnect = !isConnect;
            }
        }
        
        private void Btn_Send_Click(object sender, EventArgs e)
        {
            client.Send(Txt_Send.Text);
            Txt_Send.Text = String.Empty;
        }

        public void ShowMessage(string stamp, string name, string message)
        {
            Rtxt_chatArea.AppendText(Environment.NewLine + stamp + " " + name, Color.Blue);
            Rtxt_chatArea.AppendText(Environment.NewLine + message, Color.Black);
        }

        internal void ServerStop()
        {
            Btn_Connect.Text = "Connect";
            Btn_Send.Enabled = false;
            List_User.Items.Clear();
            ShowMessage(DateTime.Now.ToString(), "server", "stop");
        }

        internal void ConnectError(string s)
        {
            MessageBox.Show(s, "Something happened", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
