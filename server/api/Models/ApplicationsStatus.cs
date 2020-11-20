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

        public List<Application> Applications { get; set; }

        public ApplicationStatus()
        {
            this.Applications = new List<Application>();
        }
    }
}