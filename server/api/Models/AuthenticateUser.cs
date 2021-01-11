using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class AuthenticateResponse
    {
        public LoginUser User { get; set; }
    }
    public class AuthenticateUser
    {
        public string Username { get; set; } // Username je lahko Username ali Email
        public string Password { get; set; }
    }
}
