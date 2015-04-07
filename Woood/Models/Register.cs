using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using Woood.Helpers;

namespace Woood.Models
{
    public class Register
    {
        public int user_id { get; set; }
        [Required(ErrorMessage = "Voornaam")]
        public string voornaam { get; set; }
        [Required(ErrorMessage = "Achternaam")]
        public string achternaam { get; set; }
        [Required(ErrorMessage = "Adres")]
        public string adres { get; set; }
        [Required(ErrorMessage = "Huisnummer")]
        public string postcode { get; set; }
        [Required(ErrorMessage = "Plaats")]
        public string plaats { get; set; }
        [Required(ErrorMessage = "Telefoonnummer")]
        public string tel { get; set; }
        [Required(ErrorMessage = "E-mailadres")]
        [Remote("IsEmailAvailable", "Register", HttpMethod = "POST", ErrorMessage = "Het e-mail adres is al reeds in gebruik!")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Voer een geldige e-mail adres in!")]
        public string email { get; set; }
        [Required(ErrorMessage = "Wachtwoord")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Het wachtwoord moet minimaal 6 characters lang zijn")]
        public string wachtwoord { get; set; }

        public bool Insert()
        {
            DatabaseConnector conn = new DatabaseConnector();
            String query = "SELECT MAX(id) FROM user";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn.getConnection();
            cmd.CommandText = query;

            cmd.Prepare();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                this.user_id = reader.GetInt32(0);
            }
            reader.Close();
            try
            {

                String query2 = "INSERT INTO klant (`user_id`, `voornaam`,`achternaam`,`adres`,`postcode`)VALUES(@user_id, @voornaam, @achternaam, @adres, @postcode)";
                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.Connection = conn.getConnection();
                cmd2.CommandText = query2;

                cmd2.Prepare();

                cmd2.Parameters.AddWithValue("@user_id", this.user_id);
                cmd2.Parameters.AddWithValue("@voornaam", this.voornaam);
                cmd2.Parameters.AddWithValue("@achternaam", this.achternaam);
                cmd2.Parameters.AddWithValue("@adres", this.adres);
                cmd2.Parameters.AddWithValue("@postcode", this.postcode);

                cmd2.ExecuteReader();

                conn.getConnection().Close();

                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}