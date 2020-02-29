﻿using System;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Collections.Generic;

namespace DbLibrary
{
    public class Connection
    {
        public MySqlConnection
                  GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password + "; old guids=true";

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }

        public MySqlConnection GetDBConnection()
        {
            string host = "db4free.net";
            int port = 3306;
            string database = "kitbox_kewlax";
            string username = "kewlaw";
            string password = "locomac6";

            return GetDBConnection(host, port, database, username, password);
        }
    }
}
