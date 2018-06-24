using System.Collections.Generic;
using BettingSystem.Models;

namespace BettingSystem.Services
{
    public interface IEventService
    {
        void Create(IEnumerable<SportEvent> events);
        void Update(IEnumerable<SportEvent> events);
    }
}