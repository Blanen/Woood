using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Woood.Helpers;

namespace Woood.Models
{
    public class Bestelling
    {
        int id { get; set; }
        public string status { get; set; }
        public string datum { get; set; }
        public int user_id { get; set; }

        public Bestelling()
        {
            this.datum = DateTime.Now.ToString();
        }

        public Bestelling(int id)
        {

            DatabaseConnector conn = new DatabaseConnector();
            String query = "SELECT * FROM bestelling WHERE bestelling.id = @id ";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn.getConnection();
            cmd.CommandText = query;
            cmd.Prepare();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                this.id = reader.GetInt32(0);
                this.status = reader.GetString(1);
                this.datum = reader.GetString(2);
                this.user_id = reader.GetInt32(3);
            }

            conn.getConnection().Close();
        }
        public int create()
        {
            try
            {
                DatabaseConnector conn = new DatabaseConnector();
                String query = "INSERT INTO bestelling (`status`, `datum`, `user_id`)VALUES(@status, @datum, @user_id)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn.getConnection();
                cmd.CommandText = query;

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@status", this.status);
                cmd.Parameters.AddWithValue("@datum", this.datum);
                cmd.Parameters.AddWithValue("@user_id", this.user_id);

                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();

                String getId = "Select MAX(id) FROM bestelling";
                MySqlCommand cmd2 = new MySqlCommand(getId, conn.getConnection());

                MySqlDataReader idReader = cmd2.ExecuteReader();

                while (idReader.Read())
                {
                    return idReader.GetInt32(0);
                }
                return 0;

                
            }
            catch (MySqlException e)
            {
                return 0;
            }
        }
    }
}