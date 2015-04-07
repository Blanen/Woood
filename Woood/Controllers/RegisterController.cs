using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Woood.Models;
using Woood.Helpers;

namespace Woood.Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Register register)
        {
            if (ModelState.IsValid)
            {
                User user = new User(register);
                if (!user.exists())
                {
                    user.CreateUser();

                    register.Insert();
                    return Redirect("Login/Index");

                }
                else
                {
                    ModelState.AddModelError("emailError", "Email is al in gebruik");
                }
            }
            return View("Index", register);
        }

    }
}
