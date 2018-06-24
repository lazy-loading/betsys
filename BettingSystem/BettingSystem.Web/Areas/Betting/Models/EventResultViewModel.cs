using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSystem.Web.Areas.Betting.Models
{
    public class EventResultViewModel
    {
        public EventViewModel Event { get; set; }
        public List<EventMarketResultViewModel> MarketResults{get;set }
    }
}
