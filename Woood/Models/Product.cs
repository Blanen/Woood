using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Woood.Helpers;

namespace Woood.Models
{
    public class Product
    {

        public int id { get; set; }
        public string naam { get; set; }
        public int prijs { get; set; }
        public int voorraad { get; set; }
        public int korting { get; set; }
        public string afbeelding { get; set; }
        public string thumbnail { get; set; }
        public int categorie_id { get; set; }
        public string beschrijving { get; set; }

        public Product()
        {
            this.id = 0;
            this.prijs = 0;
            this.naam = "";
            this.voorraad = 0;
            this.korting = 0;
            this.afbeelding = "";
            this.thumbnail = "";
            this.categorie_id = 0;
            this.beschrijving = "";
        }

        public Product(int productID)
        {
            try
            {
                DatabaseConnector conn = new DatabaseConnector();
                String query = "SELECT * FROM product WHERE product.id = @id ";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn.getConnection();
                cmd.CommandText = query;
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", productID);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    this.id = reader.GetInt32(0);
                    this.prijs = reader.GetInt32(1);
                    this.naam = reader.GetString(2);
                    this.voorraad = reader.GetInt32(3);
                    this.korting = reader.GetInt32(4);
                    this.afbeelding = reader.GetString(5);
                    this.thumbnail = reader.GetString(6);
                    this.categorie_id = reader.GetInt32(7);
                    this.beschrijving = reader.GetString(8);
                }

                conn.getConnection().Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public bool Create()
        {
            try
            {
                DatabaseConnector conn = new DatabaseConnector();
                String query = "INSERT INTO product (`prijs`, `naam`, `voorraad`, `korting`, `beschrijving`, `categorie_id`)VALUES(@prijs, @naam, @voorraad, @korting, @beschrijving, @categorie_id)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn.getConnection();
                cmd.CommandText = query;

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@prijs", this.prijs);
                cmd.Parameters.AddWithValue("@naam", this.naam);
                cmd.Parameters.AddWithValue("@voorraad", this.voorraad);
                cmd.Parameters.AddWithValue("@korting", this.korting);
                cmd.Parameters.AddWithValue("@beschrijving", this.beschrijving);
                cmd.Parameters.AddWithValue("@categorie_id", this.categorie_id);

                MySqlDataReader reader = cmd.ExecuteReader();
                conn.getConnection().Close();

                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }

        public static List<Product> getAllInCategorie(int categorieID)
        {
            List<Product> lijst = new List<Product>();
            DatabaseConnector conn = new DatabaseConnector();
            String query = "SELECT id FROM product where categorie_id =" + categorieID.ToString();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product(reader.GetInt32(0));
                lijst.Add(product);
            }

            return lijst;
        }
    }


}