using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{ 
	public class Friendship
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("Requester")]
        public string RequesterId { get; set; }
        public ApplicationUser Requester { get; set; }

        [ForeignKey("Receiver")] 
        public string ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }
        public string Status { get; set; }
    }
}