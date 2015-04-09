using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Woood.Models;

namespace Woood.Controllers
{
    public class CategorieController : Controller
    {
        //
        // GET: /Catagorie/

        public ActionResult Index(int id)
        {
            ViewData["products"] = Product.getAllInCategorie(id);
            return View();
        }

    }
}
