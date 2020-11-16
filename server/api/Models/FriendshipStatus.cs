using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{ 
    public class FriendshipStatus
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}