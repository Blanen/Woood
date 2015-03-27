using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using Woood.Helpers;

namespace Woood.Models
{

    public class User
    {
        
        int id { get; set; }
        string email { get; set; }
        string password { get; set; }
        string rol { get; set; }

        public User(int ID)
        {
            this.id = ID;
            DatabaseConnector conn = new DatabaseConnector();
            String query = "SELECT * FROM user WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn.getConnection();
            cmd.CommandText = query;

            cmd.Prepare();

            cmd.Parameters.AddWithValue("@id", this.id);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                this.email = reader.GetString(0);
                this.password = reader.GetString(1);
                this.rol = reader.GetString(2);
            }
            conn.getConnection().Close();
        }

    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is nog")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Wachtwoord is nodig")]
        public string Wachtwoord { get; set; }
    }
}