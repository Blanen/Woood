﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Woood.Models;
using MySql.Data;
namespace Woood.Helpers
{
    public class CartToOrder
    {

        public CartToOrder(Cart cart, User user)
        {
            String Order_query = "INSERT INTO bestelling (status, datum, user_id) VALUES ( @status, @datum, @user_id)";
            DatabaseConnector conn = new DatabaseConnector();
        }

        public void makeOrder()
        {

        }
    }
}