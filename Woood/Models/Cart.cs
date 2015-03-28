using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Woood.Models
{
    public class Cart
    {
        public List<CartProduct> ProductList { get; set; }

        public void addToCart(CartProduct product){
            ProductList.Add(product);
        }
        public void removeFromCart(CartProduct product)
        {
            ProductList.Remove(product);
        } 


    }
}