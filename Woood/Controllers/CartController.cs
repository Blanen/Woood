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
            ViewData["Cart"] = cart;
            return View();
        }

        [HttpPost]
        public ActionResult addToCart(CartProductView product)
        {
            Cart cart = Session["cart"] as Cart;
            if (cart == null)
            {
                cart = new Cart();
            }
            cart.addToCart(product.toCartProduct());
            Session["cart"] = cart;

            return RedirectToAction("Index");
        }

        public ActionResult remove(int index)
        {

            Cart cart = Session["cart"] as Cart;
            cart.removeFromCart(index);
            Session["cart"] = cart;

            return RedirectToAction("Index");
        }


    }
}
