using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Woood.Helpers;
using Woood.Models;
using System.Web.Security;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Woood.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel login){
        {
            if (ModelState.IsValid)
            {
                
                try{
                    DatabaseConnector conn = new DatabaseConnector();
                    String query = "SELECT * FROM user WHERE email = @email";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn.getConnection();
                    cmd.CommandText = query;
                   
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@email", login.Email);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    String FinalQuery = cmd.ToString();

                    while(reader.Read()){

                        String readerzooi1 = reader.GetString(0);
                        String readerzooi2 = reader.GetString(1);
                        String readerzooi3 = reader.GetString(2);
                        String password = login.Wachtwoord;

                        if(reader.GetString(2).Equals(login.Wachtwoord)){

                            User user = new User(reader.GetInt32(0));
                            Session["User"] = user;
                            Console.WriteLine(Session["User"]);
                            return RedirectToAction("Index", "");
                        
                        }

                    }
                    conn.getConnection().Close();
                }
                catch(MySqlException e){
                    Console.WriteLine(e);
                }
            }
            return View();
        }

    }
    }
}


