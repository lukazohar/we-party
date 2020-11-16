using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class PartyStatus
    { 
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}