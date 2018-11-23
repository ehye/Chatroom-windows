using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace wsServer
{
    public class Chat : WebSocketBehavior
    {
        private string _name;
        private readonly int _capacity = 10;

        public Chat()
        {
            
        }

        protected override void OnOpen()
        {
            _name = Context.QueryString["name"];
            string[] data = { ID, "com", _name, "connect", "" };
            Sessions.Broadcast(CreateMessage(data));

            if (!Program.IdNamePairs.ContainsKey(ID)) // 确保健壮后可删
            {
                Program.IdNamePairs.Add(ID, _name);
            }

            // sent online members
            var nameList = Program.IdNamePairs.Values.ToList();
            //nameList.Remove(_name);
            var idList = Program.IdNamePairs.Keys.ToList();
            //idList.Remove(ID);
            var names = string.Join(',', nameList);
            var ids = string.Join(',', idList);
            string[] data1 = { ids, "list", "", names, "" };
            Console.WriteLine(ids);
            Console.WriteLine(names);
            Sessions.SendTo(CreateMessage(data1), ID);

            // binary test
            byte[] imageArray = File.ReadAllBytes(@"C:\Users\yjw96\Documents\Visual Studio 2017\Projects\Chatroom-windows\0.jpg");
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            string[] data2 = { "", "pic", "", base64ImageRepresentation, "" };
            Sessions.SendTo(CreateMessage(data2), ID);

            // send last queue.count message
            for (int i = 0, len = Program.msg.Count; i < len; i++)
            {
                var message = Program.msg.Dequeue();
                //Sessions.SendTo(CreateMessage(message), ID);
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
            string[] data = ReciveMessage(e.RawData);

            // 通过服务器转发 因此使用 QueryString to 无意义，可以用在加密对话上
            //string _to = Context.QueryString["to"] ?? "";

            string _to = data[4];

            if (_to.Equals(string.Empty)) // 无指向则群聊
            {

                // set message buffer capacity
                if (Program.msg.Count > _capacity)
                    Program.msg.Dequeue();
                Program.msg.Enqueue(data);

                //foreach (var m in Program.msg)
                //    m.ToList().ForEach(Console.WriteLine);
                //Console.WriteLine("==========");
                Sessions.Broadcast(CreateMessage(data));
            }
            else // private chat
            {
                //foreach (var uid in Sessions.IDs)
                //{
                //    if (uid == _to)
                //    {
                //        Sessions.SendTo(CreateMessage(data), uid);
                //        if (ID != uid)
                //            Sessions.SendTo(CreateMessage(data), ID);
                //    } 
                //}
            }
        }

        protected override void OnClose(CloseEventArgs e)
        {
            string[] data = { ID, "com", _name, "disconnect", "" };
            Sessions.Broadcast(CreateMessage(data));

            Program.IdNamePairs.Remove(ID);
            Console.WriteLine(Context.UserEndPoint.ToString() + $" closed {e.Reason}");
        }

        private byte[] CreateMessage(string[] data) => new TextMessage
        {
            UserID = data[0],
            Type = data[1],
            Name = data[2],
            Data = data[3],
            To = data[4]

        }.ToJsonByte();

        private string[] ReciveMessage(byte[] bytes)
        {
            var j = Encoding.UTF8.GetString(bytes);
            var json = JObject.Parse(j);
            var uid = (string)json["uid"];
            var type = (string)json["type"];
            var name = (string)json["name"];
            var data = (string)json["data"];
            var to = (string)json["to"] ?? string.Empty;

            //switch (type)
            //{
            //    // Type: com, list, msg, pic,file
            //    case "com":
            //        //data = name + " join the chat";
            //        if (data == "connect")
            //        {
                         
            //        } else if(data == "disconnect")
            //        {
            //            Console.WriteLine($"{name} disconnect");
            //        }
            //        break;
            //    //case "list":
            //    //    break;
            //    case "msg":
            //        break;
            //    case "pic":
            //        break;
            //    case "file":
            //        break;
            //    default:
            //        break;
            //}
            return new string[5] { uid, type, name, data, to };
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
