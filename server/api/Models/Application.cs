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
        public int PartyId { get; set; }
        public int UserId { get; set; }
        public int ApplicationStatusId { get; set; }
    }
}