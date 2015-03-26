using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Woood.Models
{
    public class Product
    {
        int id { get; set; }
        int prijs { get; set; }
        string naam { get; set; }
        int vooraad { get; set; }
        string korting { get; set; }
        string afbeelding { get; set; }
        string thumbnail { get; set; }

        public Product(int ID)
        {

        }
    }

    
}