using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BettingSystem.Web.Areas.Admin.Models
{
    public class UpcomingEventsImportViewModel
    {
        [Required]
        public IFormFile XmlFile { get; set; }
    }
}
