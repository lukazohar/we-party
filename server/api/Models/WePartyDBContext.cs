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
        public DbSet<Party> Partys { get; set; } 
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<FriendshipStatus> FriendshipStatuses { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
        public DbSet<PartyStatus> PartyStatuses { get; set; }
    }
}