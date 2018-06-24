using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using AutoFixture;
using BettingSystem.Database;
using BettingSystem.ImportsTests.Infrastructure;
using BettingSystem.Models;
using BettingSystem.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace BettingSystem.ImportsTests.Services
{
    [TestFixture]
    public class EventServiceTests
    {
        private Fixture _fixture;
        private BetsysDbContext _context;
        private Guid _dbId;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _fixture = new BettingSystemFixture();
        }

        [SetUp]
        public void SetUp()
        {
            _dbId = Guid.NewGuid();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }

        private IEventService MakeEventService()
        {
            _context = MakeContext();
            return new EventService(_context);
        }

        private BetsysDbContext MakeContext()
        {
            return _context = DatabaseHelper.CreateInMemoryContext(_dbId);
        }

        [Test]
        public void Create_Event_AddedEventWithMarketsAndSelections()
        {
            var sportEvent = MakeSportEvent();

            MakeEventService().Create(sportEvent);

            var dbSportEvent = _context.SportEvents.FirstOrDefault();
            Assert.That(dbSportEvent.Markets, Has.Count.Positive);
            Assert.That(dbSportEvent.Markets.First().Selections, Has.Count.Positive);
        }

        [Test]
        public void Update_EventMarketSelection_Number()
        {
            var sportEvent = SeedDatabase().First();
            sportEvent.Markets.First().Selections.First().Number = 70;
            
            MakeEventService().Update(sportEvent);

            var dbFirstSelection = MakeContext().SportEvents
                .Include(x => x.Markets)
                .ThenInclude(x => x.Selections)
                .First().Markets.First()
                .Selections.First();
            Assert.That(dbFirstSelection.Number, Is.EqualTo(70));
        }

        [Test]
        public void Update_Added_EventMarketSelection()
        {
            var sportEvent = SeedDatabase().First();
            var sportEventSelection = _fixture.Create<SportEventSelection>();
            
            sportEvent.Markets.First().Selections.Add(sportEventSelection);
            MakeEventService().Update(sportEvent);

            var dbFirstMarket = MakeContext().SportEvents
                .Include(x => x.Markets)
                .ThenInclude(x => x.Selections)
                .First().Markets.First();
            Assert.That(dbFirstMarket.Selections, Has.Count.EqualTo(4));
        }

        [Test]
        public void Update_Removed_EventMarketSelection()
        {
            var sportEvent = SeedDatabase().First();
            
            sportEvent.Markets.First().Selections.RemoveAt(0);
            MakeEventService().Update(sportEvent);
            
            var dbFirstMarket = MakeContext().SportEvents
                .Include(x => x.Markets)
                .ThenInclude(x => x.Selections)
                .First().Markets.First();

            Assert.That(dbFirstMarket.Selections, Has.Count.EqualTo(2));
        }


        [Test]
        public void Update_Added_EventMarket()
        {
            var sportEvent = SeedDatabase().First();
            sportEvent.Markets.Add(_fixture.Create<SportEventMarket>());

            MakeEventService().Update(sportEvent);

            Assert.That(sportEvent.Markets, Has.Count.EqualTo(4));
        }
        
        [Test]
        public void Update_Removed_EventMarket()
        {
            var sportEvent = SeedDatabase().First();

            sportEvent.Markets.RemoveAt(0);
            
            MakeEventService().Update(sportEvent);

            Assert.That(sportEvent.Markets, Has.Count.EqualTo(2));
        }

        [Test]
        public void Update_EventMarket()
        {
            var sportEvent = SeedDatabase().First();

            sportEvent.Markets.First().Name = "gosho";
            
            MakeEventService().Update(sportEvent);

            var firstMarket = MakeContext().SportEvents.Include(x => x.Markets).First().Markets.First();
            
            Assert.That(firstMarket.Name, Is.EqualTo("gosho"));
        }

        private IEnumerable<SportEvent> SeedDatabase()
        {
            var sportEvents = MakeSportEvent();
            var context = MakeContext();
            context.SportEvents.AddRange(sportEvents);
            context.SaveChanges();
            return context.SportEvents
                .Include(x => x.Markets)
                .ThenInclude(x => x.Selections);
        }

        private IEnumerable<SportEvent> MakeSportEvent(int count = 1)
        {
            return _fixture.Build<SportEvent>()
                .Without(x => x.Bets)
                .CreateMany(count);
        }
    }
}