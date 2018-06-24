using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BettingSystem.Models
{
    public class User : IdentityUser
    {
        public IList<Bet> Bets { get; set; }
    }
}