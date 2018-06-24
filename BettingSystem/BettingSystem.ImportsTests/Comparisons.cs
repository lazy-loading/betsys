using System.Collections.Generic;
using System.Linq;
using BettingSystem.Models;

namespace BettingSystem.ImportsTests
{
    public static class Comparisons
    {
        public static bool CompareEvents(SportEvent x, SportEvent y)
        {
            return
                x.HomePlayer == y.HomePlayer &&
                x.AwayPlayer == y.AwayPlayer &&
                x.EventTime == y.EventTime &&
                x.Id == y.Id &&
                x.SportType == y.SportType &&
                CompareMarkets(x.Markets , y.Markets);
        }

        private static bool CompareMarkets(IEnumerable<SportEventMarket> x, IEnumerable<SportEventMarket> y)
        {
            x = x.OrderBy(z => z.Number);
            y = y.OrderBy(z => z.Number);

            return Enumerable.SequenceEqual(x, y, new FunctionEqualityComparer<SportEventMarket>(CompareMarkets));
        }

        private static bool CompareMarkets(SportEventMarket x, SportEventMarket y)
        {
            return
                x.Name == y.Name &&
                x.Number == y.Number &&
                CompareSelections(x.Selections, y.Selections)&&
                x.IsClosed == y.IsClosed;
        }

        private static bool CompareSelections(IEnumerable<SportEventSelection> x, IEnumerable<SportEventSelection> y)
        {
            x = x.OrderBy(z => z.Id);
            y = y.OrderBy(z => z.Id);

            return Enumerable.SequenceEqual(x, y, new FunctionEqualityComparer<SportEventSelection>(CompareSelections));
        }

        private static bool CompareSelections(SportEventSelection x, SportEventSelection y)
        {
            return
                x.Description == y.Description &&
                x.Id == y.Id &&
                x.Number == y.Number &&
                x.Participant == y.Participant &&
                x.Odds == y.Odds;
        }
    }
}
