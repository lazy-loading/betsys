using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSystem.Web.Areas.Betting.Models
{
    public class BetViewModel
    {
        public string Player { get; set; }
        public decimal Odds { get; set; }
        public EventViewModel Event { get; set; }
        public string EventName => Event?.Name;
        public decimal Value { get; set; }
    }
}
