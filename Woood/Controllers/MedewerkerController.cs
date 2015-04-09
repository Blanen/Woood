using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Woood.Models;
using Woood.Helpers;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Woood.Controllers
{
    public class MedewerkerController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            User user = Session["user"] as User;
            if (user != null && user.isMedewerker())
            {
                return View();
            }
            return RedirectPermanent("~/");
        }

        public ActionResult Products()
        {
            User user = Session["user"] as User;
            if (user != null && user.isMedewerker())
            {

                List<Product> productList = new List<Product>();
                DatabaseConnector conn = new DatabaseConnector();
                String query = "SELECT id from product";
                MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product(reader.GetInt32(0));
                    productList.Add(product);
                }
                ViewData["products"] = productList;
                return View();
            }
            return RedirectPermanent("~/");

        }

        public ActionResult Categories()
        {
            User user = Session["user"] as User;
            if (user != null && user.isMedewerker())
            {
                List<Categorie> categoryList = new List<Categorie>();
                DatabaseConnector conn = new DatabaseConnector();
                String query = "SELECT id from categorie";
                MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Categorie categorie = new Categorie(reader.GetInt32(0));
                    categoryList.Add(categorie);
                }
                ViewData["categories"] = categoryList;
                return View();
            }
            return RedirectPermanent("~/");
        }
   
        [HttpPost]
        public ActionResult addProduct(Product product)
        {
            return RedirectToAction("Products");
        }

        public ActionResult addProduct()
        {
            return View();
        }
    }
}
