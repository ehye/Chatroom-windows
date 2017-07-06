using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComLib
{
    [Serializable]
    public class ChatClient
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        
        public ChatClient(string username, string password, string clientIP, bool connect)
        {
            Username = username;
            Password = password;
        }
    }
}
