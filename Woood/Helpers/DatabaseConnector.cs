using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Woood.Helpers
{
    public class DatabaseConnector
    {
        String address = "localhost";
        String database = "woood";
        String username = "admin";
        String password = "admin";
        MySqlConnection conn;
        public DatabaseConnector()
        {
            String connectionString = "server =" + address + ";user=" + username + ";password=" + password + ";database=" + database;
            conn = new MySqlConnection(connectionString);
        }

        public MySqlConnection getConnection()
        {
            return conn;
        }
       
    }
}