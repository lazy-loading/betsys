using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSystem.Web.Areas.Betting.Models
{
    public class EventViewModel
    {
        public int EventId { get; set; }
        public string Name => $"{HomePlayer} vs {AwayPlayer}";
        public string HomePlayer { get; set; }
        public string AwayPlayer { get; set; }
        public string SportType { get; set; }
    }
}
