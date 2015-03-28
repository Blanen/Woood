using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Woood.Models;

namespace Woood.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index(int id)
        {
            Product product = new Product(id);
            ViewData["Product"] = product;
            return View();
        }

    }
}
