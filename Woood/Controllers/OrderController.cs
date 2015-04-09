using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Woood.Models;

namespace Woood.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        public ActionResult Index()
        {
            User user = Session["user"] as User;
            if (user != null)
            {
                ViewData.Add("Order", Order.getAll(user.id));
            }
            return View();
        }

    }
}