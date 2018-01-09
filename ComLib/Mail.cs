using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComLib
{
    [Serializable]
    public class Mail
    {
        private string stamp;
        private string username;
        private string msg;

        public string Stamp { get => stamp; private set => stamp = value; }
        public string Username { get => username; private set => username = value; }
        public string Msg { get => msg; private set => msg = value; }

        public Mail(string stamp, string username, string msg)
        {
            this.stamp = stamp;
            this.username = username;
            this.msg = msg;
        }

        public string Display()
        {
            return String.Format("%s %s:\n%s\n", stamp, username, msg);
        }

    }
}
