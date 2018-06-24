using BettingSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BettingSystem.Database
{
    public class BetsysDbContext : IdentityDbContext<User>
    {
        public BetsysDbContext(DbContextOptions<BetsysDbContext> options)
            : base(options)
        {
        }

        public DbSet<SportEvent> SportEvents { get; set; }

        public DbSet<SportEventMarket> Markets { get; set; }

        public DbSet<SportEventSelection> Selections { get; set; }

        public DbSet<Bet> Bets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");

            builder.Entity<SportEventMarket>(entity => { entity.HasIndex(x => x.Number).IsUnique(); });

            builder.Entity<SportEventSelection>(entity => { entity.HasIndex(x => x.Number).IsUnique(); });
        }
    }
}