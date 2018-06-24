using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSystem.Web.Models
{
    public class BetViewModel
    {
        [Required]
        public UserViewModel User { get; set; }

        [Required]
        public SelectionViewModel Selection { get; set; }

        [Required]
        public decimal Value { get; set; }
    }
}
