using System;

namespace ComLib
{
    [Serializable]
    public class ChatClient
    {
        public static string SPLIT { get; } = ":]swx";
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Ip { get; private set; } = ConnectionData.ServerIP.ToString();

        public ChatClient(string username, string password, string ip, bool connect)
        {
            Username = username;
            Password = password;
            Ip = ip;
        }
    }
}
