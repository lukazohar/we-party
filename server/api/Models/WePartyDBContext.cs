// ImeProjektaDBContext
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class WePartyDBContext: IdentityDbContext<ApplicationUser>
    {
        public WePartyDBContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Party> Parties { get; set; } 
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Application> Applications { get; set; }
    }
}