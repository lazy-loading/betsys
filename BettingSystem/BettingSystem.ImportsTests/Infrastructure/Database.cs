using System;
using BettingSystem.Database;
using Microsoft.EntityFrameworkCore;

namespace BettingSystem.ImportsTests.Infrastructure
{
    public static class DatabaseHelper
    {
        public static BetsysDbContext CreateInMemoryContext(Guid? dbId = null)
        {
            var options = new DbContextOptionsBuilder<BetsysDbContext>()
//                .UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=BettingSystemgosho;" +
//                              $"Trusted_Connection=True;MultipleActiveResultSets=true")
                //.UseInMemoryDatabase(dbId.ToString())
                .UseSqlite("Data Source=goshoPeshovStamatov.sqlite3")
                .Options;

            var context = new BetsysDbContext(options);
            context.Database.EnsureCreated();
            context.Database.Migrate();
            return context;
        }
    }
}