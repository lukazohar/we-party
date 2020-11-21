using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{ 
	public class Friendship
    {
        [Key]
        public int Id { get; set; }
        public int? RequesterId { get; set; }
        public User Requester { get; set; }
        public int? ReceiverId { get; set; }
        public User Receiver { get; set; }
        public string Status { get; set; }
    }
}