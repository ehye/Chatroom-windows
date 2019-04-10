using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace wsServer
{
    public class DBConnection
    {
        private string databaseName;
        private MySqlConnection connection = null;
        private static DBConnection _instance = null;

        private DBConnection()
        {
        }

        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (string.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server=localhost; database={0}; UID=root; password=admin", databaseName);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}