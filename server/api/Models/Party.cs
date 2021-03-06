using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Party
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Price { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public bool IsPublic { get; set; }
        public virtual string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Status { get; set; }
    }
}