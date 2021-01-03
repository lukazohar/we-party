using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class RegisterUser
    {
        public string Username { get; set; } // Userame je lahko Username ali Email
        public string Password { get; set; }
    }
}
