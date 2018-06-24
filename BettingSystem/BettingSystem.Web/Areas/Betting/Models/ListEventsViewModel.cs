using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSystem.Web.Areas.Betting.Models
{
    public class ListEventsViewModel
    {
        Dictionary<string, EventViewModel> EventsBySport { get; set; }
    }
}
