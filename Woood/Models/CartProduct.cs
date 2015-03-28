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
}