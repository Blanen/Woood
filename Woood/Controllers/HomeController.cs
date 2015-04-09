﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Woood.Models;

namespace Woood.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewData.Add("Categorie", Categorie.getAll());
            return View();
        }

        public ActionResult About()
        {

            return View();

        }
    }
}
