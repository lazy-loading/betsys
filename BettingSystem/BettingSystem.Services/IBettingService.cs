using System.Collections.Generic;
using BettingSystem.Models;

namespace BettingSystem.Services
{
    public interface IBettingService
    {
        IEnumerable<SportEvent> GetOpenEvents();

        Bet MakeBet(BetRequest request);

        void CancellBet(int id);
    }
}