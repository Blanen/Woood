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
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string rol { get; set; }

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

        public User(Register register)
        {
            this.email = register.email;
            this.password = register.wachtwoord;
        }

        public bool isMedewerker()
        {
            if (rol.Equals("medewerker"))
            {
                return true;
            }
            return false;
        }

        public bool exists()
        {
            try
            {
                DatabaseConnector conn = new DatabaseConnector();
                String query = "SELECT * FROM user WHERE email = @email";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn.getConnection();
                cmd.CommandText = query;

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@email", this.email);

                MySqlDataReader reader = cmd.ExecuteReader();
                conn.getConnection().Close();

                while (reader.Read())
                {
                    return true;
                }
                return false;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }

        public bool CreateUser()
        {
            try
            {
                DatabaseConnector conn = new DatabaseConnector();
                String query = "INSERT INTO user (`email`,`wachtwoord`)VALUES(@email, @wachtwoord)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn.getConnection();
                cmd.CommandText = query;

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@email", this.email);
                cmd.Parameters.AddWithValue("@wachtwoord", this.password);

                MySqlDataReader reader = cmd.ExecuteReader();
                conn.getConnection().Close();

                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is nodig")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Wachtwoord is nodig")]
        public string Wachtwoord { get; set; }

    }

}