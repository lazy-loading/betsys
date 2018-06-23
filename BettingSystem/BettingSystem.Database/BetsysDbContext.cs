using System;
using BettingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BettingSystem.Database
{
    public class BetsysDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<User> Users { get; set; }

        public DbSet<SportEvent> SportEvents { get; set; }

        public DbSet<SportEventMarket> Markets { get; set; }

        public DbSet<SportEventSelection> Selections { get; set; }

        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");

            builder.Entity<SportEventMarket>(entity =>
            {
                entity.HasIndex(x => x.Number).IsUnique();
            });

            builder.Entity<SportEventSelection>(entity => { entity.HasIndex(x => x.Number).IsUnique(); });
        }
    }
}