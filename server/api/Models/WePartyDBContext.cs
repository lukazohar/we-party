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
    }
}