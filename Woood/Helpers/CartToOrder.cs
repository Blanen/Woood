using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Woood.Models;
using MySql.Data.MySqlClient;
namespace Woood.Helpers
{
    public class CartToOrder
    {
        Bestelling bestelling;
        Cart cart;

        public CartToOrder(Cart cart, User user)
        {
            this.bestelling = new Bestelling();
            this.cart = cart;
            this.bestelling.status = "niet-betaald";
            this.bestelling.user_id = user.id;
        }

        public void makeOrder()
        {
            int orderId = bestelling.create();
            if (orderId > 0)
            {
                foreach (CartProduct cartproduct in cart.ProductList)
                {
                    string query = "Insert into product_bestelling(`bestelling_id`, `product_id`, `hoeveelheid`) VALUES (@bestelling_id, @product_id, @hoeveelheid)";
                    DatabaseConnector conn = new DatabaseConnector();
                    MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@bestelling_id", orderId);
                    cmd.Parameters.AddWithValue("@product_id", cartproduct.Product.id);
                    cmd.Parameters.AddWithValue("@hoeveelheid", cartproduct.Quantity);

                    cmd.ExecuteNonQuery();

                    conn.getConnection().Close();
                }
            }
        }
    }
}