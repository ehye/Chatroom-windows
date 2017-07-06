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
        Socket listener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ipe = new IPEndPoint(
            ComLib.ConnectionData.ServerIP, ComLib.ConnectionData.ServerPort);

        public ServerMain()
        {
            InitializeComponent();
        }

        private void Btn_start_Click(object sender, EventArgs e)
        {
            Listening();
        }

        public void Listening()
        {
            listener.Bind(ipe);
            listener.Listen(10);
            Console.WriteLine("Waiting for a connection...");
            Socket handler = listener.Accept();
            String data = null;

            while (true)
            {
                Byte[] bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
            }

            Console.WriteLine("Text received : {0}", data);

            byte[] msg = Encoding.UTF8.GetBytes(data);
            handler.Send(msg);
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
    }
}
