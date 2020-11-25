using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace api.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Description { get; set; }

        public List<Application> Applications { get; set; }
        public List<Party> Parties { get; set; }

        public ApplicationUser()
        {
            this.Applications = new List<Application>();
            this.Parties = new List<Party>();
        }
    }
}