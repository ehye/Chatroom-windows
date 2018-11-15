using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace wsClient
{
    public partial class Form1 : Form
    {

        // id and name set by sql result
        private string _uid;
        private string _name;
        private bool isConnect = false;
        private WebSocket ws;
        private Dictionary<String, String> IdNamePairs;
        private string _to = "";

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IdNamePairs = new Dictionary<string, string>
            {
                { "", "ALL" }
            };
            //list_users.Items.Add("");
        }

        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            if (isConnect)
            {

                OnClose();
            }
            else
            {
                string host = Txt_Host.Text;
                string port = Txt_Port.Text;
                _name = Txt_Username.Text;

                OnOpen(host, port);
            }

            isConnect = !isConnect;
            Btn_Send.Enabled = !Btn_Send.Enabled;
            Btn_Connect.Text = Btn_Connect.Text.Equals("Connect") ? "Disconnect" : "Connect";
        }
        
        private void Btn_Send_Click(object sender, EventArgs e)
        {
            string msg = Txt_Send.Text;

            //_to = 
            ws.Send(CreateTextMessage("message", msg));
            Txt_Send.Text = String.Empty;
        }

        private void OnOpen(string host, string port)
        {
            ws = new WebSocket($"ws://{host}:{port}/Chat?name={Txt_Username.Text}");

            #region override websocket on_event

            ws.OnOpen += (sender, e) =>
            {
                //ws.Send(CreateTextMessage("connection", String.Empty)); server will boardcast
                Rtxt_chatArea.AppendText($"Connect to server...\n");
            };

            ws.OnMessage += (sender, e) =>
            {
                if (e.IsText)
                {
                    string[] data = ProcessTextMessage(e.Data);
                    return;
                }

                if (e.IsBinary)
                {

                    return;
                }
            };

            ws.OnError += (sender, e) =>
            {
                Console.WriteLine("error: " + e.Message);
                throw new Exception("error: " + e.Message, e.Exception);
            };

            ws.OnClose += (sender, e) =>
            {
                Rtxt_chatArea.AppendText($"disconnect, reason: {e.Reason}\n");
                Btn_Send.Enabled = false;
            };

            #endregion

            ws.Connect();
        }

        private void OnClose()
        {
            //ws.Send(CreateTextMessage("disconnect", "")); server will boardcast
            ws.Close(CloseStatusCode.Normal, "user disconnect");
        }

        private string CreateTextMessage(string type, string message) => new TextMessage
        {
            UserID = _uid,
            Name = _name,
            Type = type,
            Message = message,
            To = _to

        }.ToString();

        private string[] ProcessTextMessage(string data)
        {
            var json = JObject.Parse(data);
            var uid = (string)json["uid"];
            var name = (string)json["name"];
            var type = (string)json["type"];
            var msg = (string)json["message"];
            var to = (string)json["to"];

            switch (type)
            {
                case "connection":
                    _uid = uid;
                    IdNamePairs.Add(_uid, name);
                    //list_users.Items.Add(_uid);
                    Rtxt_chatArea.AppendText($"{name} join the chat\n");
                    list_users.DataSource = IdNamePairs.Values.ToList();
                    break;
                case "message":
                    // TODO: save meassage in db
                    Rtxt_chatArea.AppendText($"{name}: {msg}\n");
                    break;
                case "disconnect":
                    IdNamePairs.Remove(_uid);
                    //list_users.Items.Remove(_uid);
                    Rtxt_chatArea.AppendText($"{name} disconnect\n");
                    list_users.DataSource = IdNamePairs.Values.ToList();
                    break;
                default:
                    break;
            }
            return new string[5] { uid, name, type, msg, to };
        }

        private void Rtxt_chatArea_TextChanged(object sender, EventArgs e)
        {
            Rtxt_chatArea.SelectionStart = Rtxt_chatArea.Text.Length;
            Rtxt_chatArea.ScrollToCaret();
        }

        private void Txt_Send_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Btn_Send.PerformClick();
            }
        }

        private void Txt_Send_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Txt_Send.Text = "";
            }
        }

        private void list_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lab_selected_user.Text = Regex.Match(list_users.SelectedItem.ToString(), @"(?<=\()\S+(?=\))").Value;
            //_to = Regex.Match(list_users.SelectedItem.ToString(), @"(?<=\()\S+(?=\))").Value;
            lab_selected_user.Text = IdNamePairs.FirstOrDefault(x => x.Value == list_users.SelectedItem.ToString()).Key;
            _to = IdNamePairs.FirstOrDefault(x => x.Value == list_users.SelectedItem.ToString()).Key;
        }
    }
}
