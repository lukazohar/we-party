using System;

namespace api.Models
{
    public class User
    {
        int Id { get; set; } // polje id
        string Username { get; set; } // polkje userame
        string Password { get; set; }
        DateTime CreatedAt { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime BirthDate { get; set; }
        string Description { get; set; }
    }
}