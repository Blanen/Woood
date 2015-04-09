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

    public class Categorie
    {
        public int id { get; set; }
        public string naam { get; set; }

        public Categorie(int ID)
        {
            this.id = ID;
            DatabaseConnector conn = new DatabaseConnector();
            String query = "SELECT * FROM categorie WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn.getConnection();
            cmd.CommandText = query;

            cmd.Prepare();

            cmd.Parameters.AddWithValue("@id", this.id);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                this.id = reader.GetInt32(0);
                this.naam = reader.GetString(1);
            }
            conn.getConnection().Close();
        }

        public Categorie(Product product)
        {
            this.id = product.categorie_id;
            this.naam = product.naam;
        }

        public bool exists()
        {
            try
            {
                DatabaseConnector conn = new DatabaseConnector();
                String query = "SELECT * FROM categorie WHERE naam = @naam";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn.getConnection();
                cmd.CommandText = query;

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@naam", this.naam);

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

        public bool Create()
        {
            try
            {
                DatabaseConnector conn = new DatabaseConnector();
                String query = "INSERT INTO user (`naam`)VALUES(@naam)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn.getConnection();
                cmd.CommandText = query;

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@naam", this.naam);

                MySqlDataReader reader = cmd.ExecuteReader();
                conn.getConnection().Close();

                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }



        public static List<Categorie> getAll()
        {
            DatabaseConnector conn = new DatabaseConnector();
            List<Categorie> categorieList = new List<Categorie>();
            string query = "SELECT * FROM categorie";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn.getConnection();
            cmd.CommandText = query;

            cmd.Prepare();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                categorieList.Add(new Categorie(reader.GetInt32("id")));
            }
            return categorieList;
        }
    }

    public class CategorieViewModel
    {
        [Required(ErrorMessage = "Naam is nodig")]
        public string Naam { get; set; }
    }

}