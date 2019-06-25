using GardeManger.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace GardeManger.DatabaseAcces
{
    public class DatabaseContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StockElement>().HasKey(m => m.StockElementId);
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=GMDB;Username=GM_DBA;Password=K33pUrF00dS@fe");

        public DbSet<StockElement> StockElements { get; set; }

    }
}
