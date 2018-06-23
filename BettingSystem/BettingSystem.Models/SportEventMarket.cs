using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BettingSystem.Models
{
    public class SportEventMarket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsClosed { get; set; }

        [Required]
        public SportEvent Event { get; set; }
        
        [Required]
        public int EventId { get; set; }

        [Required]
        public ICollection<SportEventSelection> Selections { get; set; }
    }
}