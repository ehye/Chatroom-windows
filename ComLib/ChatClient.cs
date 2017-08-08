using System;

namespace ComLib
{
    [Serializable]
    public class ChatClient
    {
        public static string SPLIT { get; } = ":]swx";
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Ip { get; private set; }
        public bool IsConnect { get; private set; }

        public ChatClient(string username, string password, string ip, bool isConnect)
        {
            Username = username;
            Password = password;
            Ip = ip;
            IsConnect = isConnect;
        }
    }
}
