using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class PartyStatus
    { 
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public List<Party> Parties { get; set; }

        public PartyStatus()
        {
            this.Parties = new List<Party>();
        }
    }
}