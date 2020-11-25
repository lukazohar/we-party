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
        public string? RequesterId { get; set; }
        [ForeignKey("RequesterId")]
        public ApplicationUser Requester { get; set; }
        public string? ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public ApplicationUser Receiver { get; set; }
        public string Status { get; set; }
    }
}