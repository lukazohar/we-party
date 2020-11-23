using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } // polje id
        public string Username { get; set; } // polje username
        public string Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Description { get; set; }

        public List<Application> Applications { get; set; }
        public List<Party> Parties { get; set; }

        public User()
        {
            this.Applications = new List<Application>();
            this.Parties = new List<Party>();
        }
    }
}