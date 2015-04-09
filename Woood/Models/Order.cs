using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Woood.Helpers;
using MySql.Data.MySqlClient;

namespace Woood.Models
{
    public class Order
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string datum { get; set; }
        public string status { get; set; }

        public static List<OrderViewModel> getAll(int userId)
        {
            DatabaseConnector conn = new DatabaseConnector();
            List<OrderViewModel> orderList = new List<OrderViewModel>();
            string query = "SELECT b.id, SUM(p.prijs * pb.hoeveelheid) AS totaal_prijs, b.status, b.datum, SUM(pb.hoeveelheid) AS hoeveelheid, b.user_id FROM bestelling b INNER JOIN product_bestelling pb ON b.id = pb.bestelling_id INNER JOIN product p ON p.id = pb.product_id WHERE user_id = @user_id AND b.status = 'niet-betaald' GROUP BY b.id";
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());


            cmd.Prepare();

            cmd.Parameters.AddWithValue("@user_id", userId);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                OrderViewModel ovm = new OrderViewModel();
                ovm.bestelling_id = reader.GetInt32(0);
                ovm.totaal_prijs = reader.GetInt32(1);
                ovm.status = reader.GetString(2);
                ovm.datum = reader.GetString(3);
                ovm.user_id = reader.GetInt32(4);
                orderList.Add(ovm);
            }
            return orderList;
        }
    }

    public class OrderViewModel
    {
        public int bestelling_id { get; set; }
        public int user_id { get; set; }
        public string datum { get; set; }
        public string status { get; set; }
        public int totaal_prijs { get; set; }
    }

}