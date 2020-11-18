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
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        public ICollection <Application> Applications { get; set; }

        public ICollection <Party> Parties { get; set; }
   
    }
}