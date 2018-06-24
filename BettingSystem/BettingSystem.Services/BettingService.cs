using System;
using System.Collections.Generic;
using System.Linq;
using BettingSystem.Database;
using BettingSystem.Models;

namespace BettingSystem.Services
{
    public class BettingService : IBettingService
    {
        private readonly BetsysDbContext _context;

        public BettingService(BetsysDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<SportEvent> GetOpenEvents()
        {
            IQueryable<SportEvent> openEvents = _context.SportEvents
                .Where(x => x.Markets.Any(y => !y.IsClosed));

            return openEvents;
        }

        public Bet MakeBet(BetRequest request)
        {
            var bet = new Bet
            {
                SelectionId = request.SelectionId,
                BetValue = request.BetValue,
                UserId = request.UserId
            };

            _context.Bets.Add(bet);
            _context.SaveChanges();

            return bet;
        }

        public void CancellBet(int id)
        {
            Bet bet = _context.Bets
                .Single(x => x.Id == id);

            _context.Bets.Remove(bet);
            _context.SaveChanges();
        }
    }
}