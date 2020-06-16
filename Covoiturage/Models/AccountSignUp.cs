using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covoiturage.Models
{
    public class AccountSignUp
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        
        public string Password { get; set; }
        public string Email { get; set; }
    }
}