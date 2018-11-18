using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace wsServer
{
    public class Chat : WebSocketBehavior
    {
        private string _name;
        private int _capacity = 10;

        public Chat()
        {
            
        }

        protected override void OnOpen()
        {
            _name = Context.QueryString["name"];
            string[] data = { ID, _name, "connection", "", "" };
            Sessions.Broadcast(CreateTextMessage(data));

            if (!Program.IdNamePairs.ContainsKey(ID)) // 确保健壮后可删
            {
                Program.IdNamePairs.Add(ID, _name);
            }

            // sent online members
            List<string> myCollection = new List<string>();
            myCollection.Add("list");
            myCollection.AddRange(Program.IdNamePairs.Values.ToList());
            myCollection.Remove(_name);
            var json = JsonConvert.SerializeObject(myCollection);
            Sessions.SendTo(json, ID);

            // send last queue.count message
            for (int i = 0, len = Program.msg.Count; i < len; i++)
            {
                var message = Program.msg.Dequeue();
                Sessions.SendTo(CreateTextMessage(message),ID);
            }

            Console.WriteLine(Context.UserEndPoint.ToString() + " join the chat");
        }

        /// <summary>
        /// 对从客户端发来的数据经行（处理并）转发
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMessage(MessageEventArgs e)
        {
            // TODO: implement private chat here?
            string[] data = ProcessTextMessage(e.Data);

            // 通过服务器转发 因此使用 QueryString to 无意义，可以用在加密对话上
            //string _to = Context.QueryString["to"] ?? "";

            string _to = data[4];

            if (_to.Equals(string.Empty))
            {

                // set message buffer capacity
                if (Program.msg.Count > _capacity)
                    Program.msg.Dequeue();
                Program.msg.Enqueue(data);

                //foreach (var m in Program.msg)
                //    m.ToList().ForEach(Console.WriteLine);
                //Console.WriteLine("==========");

                Sessions.Broadcast(CreateTextMessage(data));
            }
            else // private chat
            {
                foreach (var uid in Sessions.IDs)
                {
                    if (uid == _to)
                    {
                        Sessions.SendTo(CreateTextMessage(data), uid);
                        if (ID != uid)
                            Sessions.SendTo(CreateTextMessage(data), ID);
                    } 
                }
            }
        }

        protected override void OnClose(CloseEventArgs e)
        {
            string[] data = { ID, _name, "disconnect", e.Reason, "" };
            Sessions.Broadcast(CreateTextMessage(data));
            Program.IdNamePairs.Remove(ID);
            Console.WriteLine(Context.UserEndPoint.ToString() + $" closed, reason: {e.Reason}");
        }

        private string CreateTextMessage(string[] data) => new TextMessage
        {
            UserID = data[0],
            Name = data[1],
            Type = data[2],
            Message = data[3],
            To = data[4]

        }.ToString();

        private string[] ProcessTextMessage(string data)
        {
            var json = JObject.Parse(data);
            var uid = (string)json["uid"];
            var name = (string)json["name"];
            var type = (string)json["type"];
            var msg = (string)json["message"];
            var to = (string)json["to"] ?? string.Empty;

            switch (type)
            {
                case "connection":
                    msg = name + " join the chat";
                    break;
                case "message":
                    break;
                case "disconnect":
                    Console.WriteLine($"{name} disconnect");
                    break;
                default:
                    break;
            }
            return new string[5] { uid, name, type, msg, to };
        }
    }

    public class Program
    {
        public static Dictionary<string, string> IdNamePairs = new Dictionary<string, string>();
        public static Queue<string[]> msg = new Queue<string[]>();

        static void Main(string[] args)
        {
            #region mysql test

            //var dbCon = DBConnection.Instance();
            //dbCon.DatabaseName = "gwdb";
            //if (dbCon.IsConnect())
            //{
            //    string query = "SELECT score FROM guitarwars";
            //    var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, dbCon.Connection);
            //    var reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        string someStringFromColumnZero = reader.GetString(0);
            //        Console.WriteLine(someStringFromColumnZero);
            //    }
            //    dbCon.Close();
            //}
            #endregion


            Console.WriteLine("use number for opening port (defalut: 6017): ");
            int.TryParse(Console.ReadLine(), out int port);
            port = String.IsNullOrEmpty(port.ToString()) ? port : 6017;

            var wssv = new WebSocketServer(port);
            wssv.AddWebSocketService<Chat>("/Chat");

            wssv.Start();

            if (wssv.IsListening)
            {
                Console.WriteLine("Listening on port {0}, and providing WebSocket services:", wssv.Port);
                foreach (var path in wssv.WebSocketServices.Paths)
                    Console.WriteLine("- {0}", path);
                Console.WriteLine("The server started successfully, press key 'q' to stop\n");
            }
            
            while (true)
            {
                if (Console.ReadKey().KeyChar == 'q')
                    break;
                
            }

            wssv.Stop(CloseStatusCode.Normal, "administor was close the server");
        }
    }
}
