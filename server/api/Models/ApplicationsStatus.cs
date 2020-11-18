using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class ApplicationStatus
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}