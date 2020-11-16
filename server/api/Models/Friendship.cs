using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{ 
	public class Friendship
    {
        [Key]
        public int Id { get; set; }
        public int RequesterId { get; set; }
        public int RecivedId { get; set; }
        public int FriendshipStatusId { get; set; }

    }
}