using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BettingSystem.Models
{
    public class SportEvent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SportType { get; set; }

        [Required]
        public DateTime EventTime { get; set; }
        
        [Required]
        public string HomePlayer { get; set; }
        
        [Required]
        public string AwayPlayer { get; set; }
        
        [Required]
        public ICollection<SportEventMarket> Markets { get; set; }

        [Required]
        public ICollection<Bet> Bets { get; set; } 
    }
}