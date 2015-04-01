using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Woood.Models
{
    public class CartProduct
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class CartProductView
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public CartProduct toCartProduct()
        {
            Product product = new Product(ProductID);
            CartProduct cartProduct = new CartProduct();
            cartProduct.Product = product;
            cartProduct.Quantity = Quantity;
            return cartProduct;
        }
    }
}