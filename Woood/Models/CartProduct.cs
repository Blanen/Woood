using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Woood.Models
{
    public class CartProduct
    {
        Product Product { get; set; }
        int Quantity { get; set; }
    }
}