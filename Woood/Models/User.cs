using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Security.Cryptography;

namespace Woood.Models
{
    public class User
    {
        int id { get; set; }
        string email { get; set; }
        string password { get; set; }

    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is nog")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Wachtwoord is nodig")]
        public string Wachtwoord { get; set; }
    }
}