using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models 
{
    public class Application 
    {
        [Key]
        public int Id { get; set; }
        public DateTime AppliedAt { get; set; }
        public int Rate { get; set; }
        public int? PartyId { get; set; } //? kjer je tuji kljuè
        public Party Party { get; set; }
        public int? UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Status { get; set; }
    }
}