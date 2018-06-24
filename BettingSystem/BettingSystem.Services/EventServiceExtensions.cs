using System.Collections.Generic;
using System.Diagnostics;
using BettingSystem.Models;

namespace BettingSystem.Services
{
    public static class EventServiceExtensions
    {
        public static void Create(this IEventService service, SportEvent sportEvent)
        {
            service.Create(new List<SportEvent>{sportEvent});
        }
        
        [DebuggerStepThrough]
        public static void Update(this IEventService service, SportEvent sportEvent)
        {
            service.Update(new List<SportEvent>{sportEvent});
        }
    }
}