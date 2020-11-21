// ImeProjektaDBContext
using System;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class WePartyDBContext: DbContext
    {
        public WePartyDBContext(DbContextOptions options) : base(options)
        { }

        // Tabele -  public DbSet<User> Users { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Party> Parties { get; set; } 
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Application> Applications { get; set; }
    }
}