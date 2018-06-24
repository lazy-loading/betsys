using System.ComponentModel.DataAnnotations;

namespace BettingSystem.Web.Models
{
    public class SelectionViewModel
    {
        [Required]
        public int SelectionId { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Odds { get; set; }

        public string Participant { get; set; }
    }
}