using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Woood.Models;

namespace Woood.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        public ActionResult Index()
        {
            Cart cart = Session["cart"] as Cart;

            return View();
        }

        [HttpPost]
        public ActionResult addToCart(Product product)
        {
            return View();
        }

    }
}
