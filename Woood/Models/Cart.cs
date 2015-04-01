using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Woood.Models
{
    public class Cart
    {
        public List<CartProduct> ProductList { get; set; }

        public Cart()
        {
            ProductList = new List<CartProduct>();
        }
        public void addToCart(CartProduct product)
        {
            Boolean added = false;
            if (ProductList.Count > 0)
            {
                foreach (CartProduct CProduct in ProductList)
                {
                    if (CProduct.Product.id == product.Product.id && !added)
                    {
                        CProduct.Quantity += product.Quantity;
                        added = true;
                    }
                }
            }
            if (!added)
            {
                ProductList.Add(product);
            }
        }

        public void removeFromCart(int index)
        {
            ProductList.RemoveAt(index);
        }


    }
}