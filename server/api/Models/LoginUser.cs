using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class LoginResponse
    {
        public LoginUser User { get; set; }
    }
    public class LoginUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email{ get; set; }
        public string AccessToken { get; set; }
    }
}
