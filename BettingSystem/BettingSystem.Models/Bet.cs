using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BettingSystem.Models
{
    public class Bet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public User User { get; set; }
        
        [Required]
        public int UserId { get; set; }

        public ICollection<SportEventSelection> Selections { get; set; }

        [NotMapped]
        public SportEvent Event => Selections?.FirstOrDefault()?.Market.Event;
    }
}