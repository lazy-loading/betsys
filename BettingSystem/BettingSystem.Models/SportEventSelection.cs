using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BettingSystem.Models
{
    public class SportEventSelection
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Odds { get; set; }

        [Required]
        public SelectionParticipantType Participant { get; set; }

        [Required]
        public int MarketId { get; set; }
        
        #region Navigation properties

        [Required]
        public SportEventMarket Market { get; set; }
        
        #endregion
    }
}